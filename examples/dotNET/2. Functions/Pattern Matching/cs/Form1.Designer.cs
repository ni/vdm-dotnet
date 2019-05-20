namespace Pattern_Matching
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
            this.imageViewerMain = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subpixelAccuracy = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.matchesRequested = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.minimumContrast = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.minimumScore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.matchMode = new System.Windows.Forms.ComboBox();
            this.resultsBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.matchesFound = new System.Windows.Forms.TextBox();
            this.imageViewerPattern = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label6 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.learnPatternButton = new System.Windows.Forms.Button();
            this.matchPatternButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesRequested)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).BeginInit();
            this.resultsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewerMain
            // 
            this.imageViewerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerMain.Location = new System.Drawing.Point(18, 14);
            this.imageViewerMain.Name = "imageViewerMain";
            this.imageViewerMain.Size = new System.Drawing.Size(358, 318);
            this.imageViewerMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subpixelAccuracy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.matchesRequested);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.minimumContrast);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minimumScore);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.matchMode);
            this.groupBox1.Location = new System.Drawing.Point(391, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameters";
            // 
            // subpixelAccuracy
            // 
            this.subpixelAccuracy.AutoSize = true;
            this.subpixelAccuracy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subpixelAccuracy.Location = new System.Drawing.Point(10, 124);
            this.subpixelAccuracy.Name = "subpixelAccuracy";
            this.subpixelAccuracy.Size = new System.Drawing.Size(117, 17);
            this.subpixelAccuracy.TabIndex = 4;
            this.subpixelAccuracy.Text = "Subpixel Accuracy:";
            this.subpixelAccuracy.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Matches Requested:";
            // 
            // matchesRequested
            // 
            this.matchesRequested.Location = new System.Drawing.Point(113, 98);
            this.matchesRequested.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.matchesRequested.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.matchesRequested.Name = "matchesRequested";
            this.matchesRequested.Size = new System.Drawing.Size(46, 20);
            this.matchesRequested.TabIndex = 2;
            this.matchesRequested.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum Contrast:";
            // 
            // minimumContrast
            // 
            this.minimumContrast.Location = new System.Drawing.Point(113, 73);
            this.minimumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.minimumContrast.Name = "minimumContrast";
            this.minimumContrast.Size = new System.Drawing.Size(46, 20);
            this.minimumContrast.TabIndex = 2;
            this.minimumContrast.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minimum Score:";
            // 
            // minimumScore
            // 
            this.minimumScore.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.minimumScore.Location = new System.Drawing.Point(113, 48);
            this.minimumScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minimumScore.Name = "minimumScore";
            this.minimumScore.Size = new System.Drawing.Size(57, 20);
            this.minimumScore.TabIndex = 2;
            this.minimumScore.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match Mode:";
            // 
            // matchMode
            // 
            this.matchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matchMode.FormattingEnabled = true;
            this.matchMode.Items.AddRange(new object[] {
            "Shift Invariant",
            "Rotation Invariant"});
            this.matchMode.Location = new System.Drawing.Point(113, 19);
            this.matchMode.Name = "matchMode";
            this.matchMode.Size = new System.Drawing.Size(116, 21);
            this.matchMode.TabIndex = 0;
            // 
            // resultsBox
            // 
            this.resultsBox.Controls.Add(this.label5);
            this.resultsBox.Controls.Add(this.matchesFound);
            this.resultsBox.Location = new System.Drawing.Point(382, 334);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(144, 47);
            this.resultsBox.TabIndex = 2;
            this.resultsBox.TabStop = false;
            this.resultsBox.Text = "Results";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Matches Found:";
            // 
            // matchesFound
            // 
            this.matchesFound.Location = new System.Drawing.Point(99, 19);
            this.matchesFound.Name = "matchesFound";
            this.matchesFound.ReadOnly = true;
            this.matchesFound.Size = new System.Drawing.Size(30, 20);
            this.matchesFound.TabIndex = 0;
            // 
            // imageViewerPattern
            // 
            this.imageViewerPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerPattern.Location = new System.Drawing.Point(532, 340);
            this.imageViewerPattern.Name = "imageViewerPattern";
            this.imageViewerPattern.Size = new System.Drawing.Size(95, 77);
            this.imageViewerPattern.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Pattern Image";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(17, 345);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(75, 36);
            this.loadImageButton.TabIndex = 5;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(87, 395);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(288, 20);
            this.imagePath.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Image Path";
            // 
            // learnPatternButton
            // 
            this.learnPatternButton.Enabled = false;
            this.learnPatternButton.Location = new System.Drawing.Point(99, 345);
            this.learnPatternButton.Name = "learnPatternButton";
            this.learnPatternButton.Size = new System.Drawing.Size(80, 36);
            this.learnPatternButton.TabIndex = 8;
            this.learnPatternButton.Text = "Learn Pattern";
            this.learnPatternButton.UseVisualStyleBackColor = true;
            this.learnPatternButton.Click += new System.EventHandler(this.learnPatternButton_Click);
            // 
            // matchPatternButton
            // 
            this.matchPatternButton.Enabled = false;
            this.matchPatternButton.Location = new System.Drawing.Point(187, 345);
            this.matchPatternButton.Name = "matchPatternButton";
            this.matchPatternButton.Size = new System.Drawing.Size(82, 36);
            this.matchPatternButton.TabIndex = 9;
            this.matchPatternButton.Text = "Match Pattern";
            this.matchPatternButton.UseVisualStyleBackColor = true;
            this.matchPatternButton.Click += new System.EventHandler(this.matchPatternButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Instructions:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "1. Load an image file.";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(388, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(239, 33);
            this.label10.TabIndex = 11;
            this.label10.Text = "2. Draw a rectangle around the pattern you want to match.  Click Learn Pattern.";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(388, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(239, 62);
            this.label11.TabIndex = 12;
            this.label11.Text = "3. Load a new image and click Match Pattern to search for pattern matches.  If ne" +
                "cessary, draw a rectangle to restrict the search to a part of the image.";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(275, 345);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(49, 36);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(384, 397);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(24, 19);
            this.browseButton.TabIndex = 15;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 420);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.matchPatternButton);
            this.Controls.Add(this.learnPatternButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imageViewerPattern);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewerMain);
            this.Name = "Form1";
            this.Text = "Pattern Matching Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesRequested)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).EndInit();
            this.resultsBox.ResumeLayout(false);
            this.resultsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewerMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minimumContrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minimumScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox matchMode;
        private System.Windows.Forms.CheckBox subpixelAccuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown matchesRequested;
        private System.Windows.Forms.GroupBox resultsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox matchesFound;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewerPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button learnPatternButton;
        private System.Windows.Forms.Button matchPatternButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

