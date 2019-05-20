namespace ColorLearn
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
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saturationThreshold = new System.Windows.Forms.NumericUpDown();
            this.colorSensitivityBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.learnButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(479, 361);
            this.imageViewer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(505, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 173);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Learned Color Spectrum";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saturationThreshold);
            this.groupBox1.Controls.Add(this.colorSensitivityBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(505, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Learn Parameters";
            // 
            // saturationThreshold
            // 
            this.saturationThreshold.Location = new System.Drawing.Point(124, 54);
            this.saturationThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.saturationThreshold.Name = "saturationThreshold";
            this.saturationThreshold.Size = new System.Drawing.Size(44, 20);
            this.saturationThreshold.TabIndex = 2;
            this.saturationThreshold.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // colorSensitivityBox
            // 
            this.colorSensitivityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorSensitivityBox.FormattingEnabled = true;
            this.colorSensitivityBox.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.colorSensitivityBox.Location = new System.Drawing.Point(124, 20);
            this.colorSensitivityBox.Name = "colorSensitivityBox";
            this.colorSensitivityBox.Size = new System.Drawing.Size(108, 21);
            this.colorSensitivityBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Saturation Threshold:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Color Sensitivity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Instructions:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "1. Load an image file.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(502, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "2. Select a region of interest (ROI).  To select multiple ROIs, press the Ctrl ke" +
                "y while selecting an area.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(502, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 35);
            this.label7.TabIndex = 4;
            this.label7.Text = "3. Select the color sensitivity and the saturation threshold.  Click Learn Colors" +
                ".";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 384);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(85, 37);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // learnButton
            // 
            this.learnButton.Location = new System.Drawing.Point(103, 384);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(85, 37);
            this.learnButton.TabIndex = 5;
            this.learnButton.Text = "Learn Colors";
            this.learnButton.UseVisualStyleBackColor = true;
            this.learnButton.Click += new System.EventHandler(this.learnButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(194, 384);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(85, 37);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Image Path:";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(79, 430);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(381, 20);
            this.imagePath.TabIndex = 7;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(466, 430);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(25, 20);
            this.browseButton.TabIndex = 8;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 460);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.learnButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Color Learn Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown saturationThreshold;
        private System.Windows.Forms.ComboBox colorSensitivityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button learnButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
    }
}

