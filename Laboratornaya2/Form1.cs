using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace Laboratornaya2
{
    public partial class Form1 : Form
    {
        private bool blnFirstTimeInResizeEvent = true;
        private int intOrigFormWidth,
                     intOrigImageBoxHeight,
                     intOrigImageBoxWidth;

        private Image<Bgr, Byte> imgSceneColor = null;
        private Image<Bgr, Byte> imgToFindColor = null;
        private Image<Bgr, Byte> imgCopyOfImageToFindWithBorder = null;

        private bool blnImageSceneLoaded = false;
        private bool blnImageToFindLoaded = false;
        private bool blnImageFromCamera = false;

        private Image<Bgr, Byte> imgResult = null;

        private Bgr bgrKeyPointsColor = new Bgr(Color.Blue);
        private Bgr bgrMatchingLinesColor = new Bgr(Color.LightPink);
        private Bgr bgrFoundImageColor = new Bgr(Color.Red);

        private Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        private Capture _capture = null;
        private bool _captureInProgress;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnImageScene_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = null;

            if (ofdImageScene.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = System.Drawing.Image.FromFile(ofdImageScene.FileName);
                    txtImageScene.Text = ofdImageScene.FileName;
                    imgSceneColor = new Image<Bgr, Byte>(ofdImageScene.FileName);
                }
                catch (OutOfMemoryException)
                {
                    img = null;
                    MessageBox.Show("Your file has wrong type.", "Wrong type!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                catch (NullReferenceException)
                {
                    img = null;
                    MessageBox.Show("Unexpected result.", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                blnImageSceneLoaded = true;
            }
        }

        private void btnImageToFind_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = null;

            if (ofdImageToFind.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = System.Drawing.Image.FromFile(ofdImageToFind.FileName);
                }
                catch (OutOfMemoryException)
                {
                    img = null;
                    MessageBox.Show("Your file has wrong type.", "Wrong type!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtImageToFind.Text = ofdImageToFind.FileName;
                imgToFindColor = new Image<Bgr, Byte>(ofdImageToFind.FileName);
                blnImageToFindLoaded = true;
            }
        }

        private void rdoWebcam_CheckedChanged(object sender, EventArgs e)
        {
            blnImageFromCamera = true;
            try
            {
                _capture = new Emgu.CV.Capture(0); // Всегда используем камеру по умолчанию
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            buttonVideo.Text = "Начать захват камеры";
        }

        private void ReleaseData()
        {
            if (_capture != null)
            {
                _capture.Dispose();
                _capture = null;
            }
        }

        private void rdoImageFile_CheckedChanged(object sender, EventArgs e)
        {
            ReleaseData();
            blnImageFromCamera = false;
            buttonVideo.Text = "Загрузить изображение";
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            // Проверка наличия необходимых изображений
            if (!blnImageFromCamera)
            {
                if (!blnImageSceneLoaded || !blnImageToFindLoaded || imgSceneColor == null || imgToFindColor == null)
                {
                    this.Text = "Необходимо загрузить изображение";
                    return;
                }

                this.Text = "Идет загрузка... Пожалуйста, подождите...";
                Application.DoEvents();
                stopwatch.Restart();
            }
            else
            {
                // Для камеры проверяем только изображение для поиска
                if (!blnImageToFindLoaded || imgToFindColor == null)
                {
                    this.Text = "Необходимо загрузить изображение объекта";
                    return;
                }
            }

            try
            {
                SURFDetector surfDetector = new SURFDetector(50, false);
                Image<Gray, Byte> imgSceneGray = null;
                Image<Gray, Byte> imgToFindGray = null;

                VectorOfKeyPoint vkpSceneKeyPoints, vkpToFindKeyPoints;

                Matrix<float> mtxSceneDescriptors, mtxToFindDescriptors;

                Matrix<int> mtxMatchIndices;
                Matrix<float> mtxDistance;
                Matrix<byte> mtxMask;

                BruteForceMatcher<float> bruteForceMatcher;
                HomographyMatrix homographyMatrix = null;

                int intKNumNearestNeighbors = 2;
                double dblUniquenessThreshold = 0.8;

                int intNumNonZeroElements;

                double dblScaleIncrement = 1.5;
                int intRotationBins = 20;

                double dblRansacReprojectionThreshold = 2.0;

                Rectangle rectImageToFind;
                PointF[] ptfPointsF;
                Point[] ptPoints;

                if (blnImageFromCamera)
                {
                    if (_capture != null)
                    {
                        imgSceneColor = _capture.RetrieveBgrFrame().PyrDown();
                    }
                    else
                    {
                        return;
                    }
                }

                imgSceneGray = imgSceneColor.Convert<Gray, byte>();
                imgToFindGray = imgToFindColor.Convert<Gray, byte>();

                vkpSceneKeyPoints = surfDetector.DetectKeyPointsRaw(imgSceneGray, null);
                mtxSceneDescriptors = surfDetector.ComputeDescriptorsRaw(imgSceneGray, null, vkpSceneKeyPoints);

                vkpToFindKeyPoints = surfDetector.DetectKeyPointsRaw(imgToFindGray, null);
                mtxToFindDescriptors = surfDetector.ComputeDescriptorsRaw(imgToFindGray, null, vkpToFindKeyPoints);

                bruteForceMatcher = new BruteForceMatcher<float>(DistanceType.L2);
                bruteForceMatcher.Add(mtxToFindDescriptors);

                mtxMatchIndices = new Matrix<int>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors);
                mtxDistance = new Matrix<float>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors);

                bruteForceMatcher.KnnMatch
                (
                    mtxSceneDescriptors,
                    mtxMatchIndices,
                    mtxDistance,
                    intKNumNearestNeighbors,
                    null
                );

                mtxMask = new Matrix<byte>(mtxDistance.Rows, 1);
                mtxMask.SetValue(255);

                Features2DToolbox.VoteForUniqueness
                (
                    mtxDistance,
                    dblUniquenessThreshold,
                    mtxMask
                );

                intNumNonZeroElements = CvInvoke.cvCountNonZero(mtxMask);

                if (intNumNonZeroElements >= 4)
                {
                    intNumNonZeroElements = Features2DToolbox.VoteForSizeAndOrientation
                    (
                        vkpToFindKeyPoints,
                        vkpSceneKeyPoints,
                        mtxMatchIndices,
                        mtxMask,
                        dblScaleIncrement,
                        intRotationBins
                    );

                    if (intNumNonZeroElements >= 4)
                    {
                        homographyMatrix = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures
                        (
                            vkpToFindKeyPoints,
                            vkpSceneKeyPoints,
                            mtxMatchIndices,
                            mtxMask,
                            dblRansacReprojectionThreshold
                        );
                    }
                }

                imgCopyOfImageToFindWithBorder = imgToFindColor.Copy();
                imgCopyOfImageToFindWithBorder.Draw
                (
                    new Rectangle
                    (
                        1,
                        1,
                        imgCopyOfImageToFindWithBorder.Width - 3,
                        imgCopyOfImageToFindWithBorder.Height - 3
                    ),
                    bgrFoundImageColor,
                    2
                );

                if (ckDrawKeyPoints.Checked == true && ckDrawMatchingLines.Checked == true)
                    imgResult = Features2DToolbox.DrawMatches
                    (
                        imgCopyOfImageToFindWithBorder,
                        vkpToFindKeyPoints,
                        imgSceneColor,
                        vkpSceneKeyPoints,
                        mtxMatchIndices,
                        bgrMatchingLinesColor,
                        bgrKeyPointsColor,
                        mtxMask,
                        Features2DToolbox.KeypointDrawType.DEFAULT
                    );
                else if (ckDrawKeyPoints.Checked == true && ckDrawMatchingLines.Checked == false)
                {
                    imgResult = Features2DToolbox.DrawKeypoints
                    (
                        imgSceneColor,
                        vkpSceneKeyPoints,
                        bgrKeyPointsColor,
                        Features2DToolbox.KeypointDrawType.DEFAULT
                    );
                    imgCopyOfImageToFindWithBorder = Features2DToolbox.DrawKeypoints
                    (
                        imgCopyOfImageToFindWithBorder,
                        vkpToFindKeyPoints,
                        bgrKeyPointsColor,
                        Features2DToolbox.KeypointDrawType.DEFAULT
                    );
                    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                }
                else if (ckDrawKeyPoints.Checked == false && ckDrawMatchingLines.Checked == false)
                {
                    imgResult = imgSceneColor;
                    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                }

                if (homographyMatrix != null)
                {
                    rectImageToFind = new Rectangle(0, 0, imgToFindGray.Width, imgToFindGray.Height);

                    ptfPointsF = new PointF[]
                    {
                        new PointF(rectImageToFind.Left, rectImageToFind.Top),
                        new PointF(rectImageToFind.Right, rectImageToFind.Top),
                        new PointF(rectImageToFind.Right, rectImageToFind.Bottom),
                        new PointF(rectImageToFind.Left, rectImageToFind.Bottom)
                    };

                    homographyMatrix.ProjectPoints(ptfPointsF);
                    ptPoints = new Point[]
                    {
                        Point.Round(ptfPointsF[0]),
                        Point.Round(ptfPointsF[1]),
                        Point.Round(ptfPointsF[2]),
                        Point.Round(ptfPointsF[3]),
                    };

                    imgResult.DrawPolyline(ptPoints, true, bgrFoundImageColor, 2);
                }
                imageBoxResult.Image = imgResult;

                if (!blnImageFromCamera)
                {
                    stopwatch.Stop();
                    this.Text = "Процессорное время = " + stopwatch.Elapsed.TotalSeconds.ToString("F2") + " сек";
                }
            }
            catch (Exception ex)
            {
                this.Text = "Ошибка: " + ex.Message;
            }
        }

        private void LWForm_Resize(object sender, EventArgs e)
        {
            if (blnFirstTimeInResizeEvent)
                blnFirstTimeInResizeEvent = false;
            else
            {
                imageBoxResult.Width = this.Width - (intOrigFormWidth - intOrigImageBoxWidth);
                imageBoxResult.Height = this.Height - (intOrigImageBoxHeight - intOrigImageBoxHeight);
            }
        }

        private void buttonVideo_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    buttonVideo.Text = "Начать захват камеры";
                    _capture.Pause();
                }
                else
                {
                    if (imgToFindColor == null)
                    {
                        MessageBox.Show("Необходимо загрузить изображение объекта");
                        return;
                    }
                    //start the capture
                    buttonVideo.Text = "Остановить захват камеры";
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
                return;
            }

            if (txtImageToFind.Text != String.Empty && txtImageScene.Text != String.Empty)
                ProcessFrame(new Object(), new EventArgs());
            else
                this.Text = "Выберите изображение";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            ReleaseData();
        }
    }
}