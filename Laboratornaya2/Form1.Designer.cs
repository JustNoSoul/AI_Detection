namespace Laboratornaya2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnImageScene = new System.Windows.Forms.Button();
            this.ofdImageScene = new System.Windows.Forms.OpenFileDialog();
            this.txtImageScene = new System.Windows.Forms.TextBox();
            this.btnImageToFind = new System.Windows.Forms.Button();
            this.ofdImageToFind = new System.Windows.Forms.OpenFileDialog();
            this.txtImageToFind = new System.Windows.Forms.TextBox();
            this.imageBoxResult = new Emgu.CV.UI.ImageBox();
            this.ckDrawKeyPoints = new System.Windows.Forms.CheckBox();
            this.ckDrawMatchingLines = new System.Windows.Forms.CheckBox();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.rdoImageFile = new System.Windows.Forms.RadioButton();
            this.rdoWebcam = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImageScene
            // 
            this.btnImageScene.Location = new System.Drawing.Point(8, 23);
            this.btnImageScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImageScene.Name = "btnImageScene";
            this.btnImageScene.Size = new System.Drawing.Size(160, 28);
            this.btnImageScene.TabIndex = 0;
            this.btnImageScene.Text = "Сцена";
            this.btnImageScene.UseVisualStyleBackColor = true;
            this.btnImageScene.Click += new System.EventHandler(this.btnImageScene_Click);
            // 
            // ofdImageScene
            // 
            this.ofdImageScene.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff";
            this.ofdImageScene.Title = "Выберите изображение сцены";
            // 
            // txtImageScene
            // 
            this.txtImageScene.Location = new System.Drawing.Point(176, 26);
            this.txtImageScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImageScene.Name = "txtImageScene";
            this.txtImageScene.ReadOnly = true;
            this.txtImageScene.Size = new System.Drawing.Size(399, 22);
            this.txtImageScene.TabIndex = 1;
            // 
            // btnImageToFind
            // 
            this.btnImageToFind.Location = new System.Drawing.Point(8, 23);
            this.btnImageToFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImageToFind.Name = "btnImageToFind";
            this.btnImageToFind.Size = new System.Drawing.Size(160, 28);
            this.btnImageToFind.TabIndex = 2;
            this.btnImageToFind.Text = "Образец";
            this.btnImageToFind.UseVisualStyleBackColor = true;
            this.btnImageToFind.Click += new System.EventHandler(this.btnImageToFind_Click);
            // 
            // ofdImageToFind
            // 
            this.ofdImageToFind.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff";
            this.ofdImageToFind.Title = "Выберите изображение для поиска";
            // 
            // txtImageToFind
            // 
            this.txtImageToFind.Location = new System.Drawing.Point(176, 26);
            this.txtImageToFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImageToFind.Name = "txtImageToFind";
            this.txtImageToFind.ReadOnly = true;
            this.txtImageToFind.Size = new System.Drawing.Size(399, 22);
            this.txtImageToFind.TabIndex = 3;
            // 
            // imageBoxResult
            // 
            this.imageBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxResult.Location = new System.Drawing.Point(16, 222);
            this.imageBoxResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imageBoxResult.Name = "imageBoxResult";
            this.imageBoxResult.Size = new System.Drawing.Size(1034, 440);
            this.imageBoxResult.TabIndex = 2;
            this.imageBoxResult.TabStop = false;
            // 
            // ckDrawKeyPoints
            // 
            this.ckDrawKeyPoints.AutoSize = true;
            this.ckDrawKeyPoints.Checked = true;
            this.ckDrawKeyPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDrawKeyPoints.Location = new System.Drawing.Point(199, 23);
            this.ckDrawKeyPoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckDrawKeyPoints.Name = "ckDrawKeyPoints";
            this.ckDrawKeyPoints.Size = new System.Drawing.Size(201, 20);
            this.ckDrawKeyPoints.TabIndex = 4;
            this.ckDrawKeyPoints.Text = "Рисовать ключевые точки";
            this.ckDrawKeyPoints.UseVisualStyleBackColor = true;
            // 
            // ckDrawMatchingLines
            // 
            this.ckDrawMatchingLines.AutoSize = true;
            this.ckDrawMatchingLines.Checked = true;
            this.ckDrawMatchingLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDrawMatchingLines.Location = new System.Drawing.Point(199, 53);
            this.ckDrawMatchingLines.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckDrawMatchingLines.Name = "ckDrawMatchingLines";
            this.ckDrawMatchingLines.Size = new System.Drawing.Size(175, 20);
            this.ckDrawMatchingLines.TabIndex = 5;
            this.ckDrawMatchingLines.Text = "Рисовать линии связи";
            this.ckDrawMatchingLines.UseVisualStyleBackColor = true;
            // 
            // buttonVideo
            // 
            this.buttonVideo.Location = new System.Drawing.Point(8, 80);
            this.buttonVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(200, 37);
            this.buttonVideo.TabIndex = 6;
            this.buttonVideo.Text = "Загрузить изображение";
            this.buttonVideo.UseVisualStyleBackColor = true;
            this.buttonVideo.Click += new System.EventHandler(this.buttonVideo_Click);
            // 
            // rdoImageFile
            // 
            this.rdoImageFile.AutoSize = true;
            this.rdoImageFile.Checked = true;
            this.rdoImageFile.Location = new System.Drawing.Point(8, 23);
            this.rdoImageFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoImageFile.Name = "rdoImageFile";
            this.rdoImageFile.Size = new System.Drawing.Size(183, 20);
            this.rdoImageFile.TabIndex = 7;
            this.rdoImageFile.TabStop = true;
            this.rdoImageFile.Text = "Из файла изображения";
            this.rdoImageFile.UseVisualStyleBackColor = true;
            this.rdoImageFile.CheckedChanged += new System.EventHandler(this.rdoImageFile_CheckedChanged);
            // 
            // rdoWebcam
            // 
            this.rdoWebcam.AutoSize = true;
            this.rdoWebcam.Location = new System.Drawing.Point(8, 52);
            this.rdoWebcam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoWebcam.Name = "rdoWebcam";
            this.rdoWebcam.Size = new System.Drawing.Size(105, 20);
            this.rdoWebcam.TabIndex = 8;
            this.rdoWebcam.Text = "Веб-камера";
            this.rdoWebcam.UseVisualStyleBackColor = true;
            this.rdoWebcam.CheckedChanged += new System.EventHandler(this.rdoWebcam_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImageScene);
            this.groupBox1.Controls.Add(this.txtImageScene);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(600, 62);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изображение сцены";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImageToFind);
            this.groupBox2.Controls.Add(this.txtImageToFind);
            this.groupBox2.Location = new System.Drawing.Point(16, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(600, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изображение для поиска";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoImageFile);
            this.groupBox3.Controls.Add(this.rdoWebcam);
            this.groupBox3.Controls.Add(this.ckDrawKeyPoints);
            this.groupBox3.Controls.Add(this.ckDrawMatchingLines);
            this.groupBox3.Controls.Add(this.buttonVideo);
            this.groupBox3.Location = new System.Drawing.Point(624, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(427, 130);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Управление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 677);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBoxResult);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Поиск изображения SURF";
            this.Resize += new System.EventHandler(this.LWForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImageScene;
        private System.Windows.Forms.OpenFileDialog ofdImageScene;
        private System.Windows.Forms.TextBox txtImageScene;
        private System.Windows.Forms.Button btnImageToFind;
        private System.Windows.Forms.OpenFileDialog ofdImageToFind;
        private System.Windows.Forms.TextBox txtImageToFind;
        private Emgu.CV.UI.ImageBox imageBoxResult;
        private System.Windows.Forms.CheckBox ckDrawKeyPoints;
        private System.Windows.Forms.CheckBox ckDrawMatchingLines;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.RadioButton rdoImageFile;
        private System.Windows.Forms.RadioButton rdoWebcam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}