namespace ColorPatternMatching
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subpixelAccuracy = new System.Windows.Forms.CheckBox();
            this.colorScoreWeight = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.matchesRequested = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.minimumContrast = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.minimumScore = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.matchFeatureMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchStrategy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorSensitivity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.matchMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.matchesFound = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label14 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.learnPatternButton = new System.Windows.Forms.Button();
            this.matchPatternButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorScoreWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesRequested)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(525, 427);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subpixelAccuracy);
            this.groupBox1.Controls.Add(this.colorScoreWeight);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.matchesRequested);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.minimumContrast);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.minimumScore);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.matchFeatureMode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchStrategy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.colorSensitivity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.matchMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(543, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 256);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameters";
            // 
            // subpixelAccuracy
            // 
            this.subpixelAccuracy.AutoSize = true;
            this.subpixelAccuracy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subpixelAccuracy.Location = new System.Drawing.Point(20, 229);
            this.subpixelAccuracy.Name = "subpixelAccuracy";
            this.subpixelAccuracy.Size = new System.Drawing.Size(117, 17);
            this.subpixelAccuracy.TabIndex = 4;
            this.subpixelAccuracy.Text = "Subpixel Accuracy:";
            this.subpixelAccuracy.UseVisualStyleBackColor = true;
            // 
            // colorScoreWeight
            // 
            this.colorScoreWeight.Location = new System.Drawing.Point(125, 203);
            this.colorScoreWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.colorScoreWeight.Name = "colorScoreWeight";
            this.colorScoreWeight.Size = new System.Drawing.Size(45, 20);
            this.colorScoreWeight.TabIndex = 3;
            this.colorScoreWeight.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Color Score Weight:";
            // 
            // matchesRequested
            // 
            this.matchesRequested.Location = new System.Drawing.Point(125, 177);
            this.matchesRequested.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.matchesRequested.Name = "matchesRequested";
            this.matchesRequested.Size = new System.Drawing.Size(45, 20);
            this.matchesRequested.TabIndex = 3;
            this.matchesRequested.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Matches Requested:";
            // 
            // minimumContrast
            // 
            this.minimumContrast.Location = new System.Drawing.Point(125, 151);
            this.minimumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.minimumContrast.Name = "minimumContrast";
            this.minimumContrast.Size = new System.Drawing.Size(45, 20);
            this.minimumContrast.TabIndex = 3;
            this.minimumContrast.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Minimum Contrast:";
            // 
            // minimumScore
            // 
            this.minimumScore.Location = new System.Drawing.Point(125, 125);
            this.minimumScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minimumScore.Name = "minimumScore";
            this.minimumScore.Size = new System.Drawing.Size(45, 20);
            this.minimumScore.TabIndex = 3;
            this.minimumScore.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Minimum Score:";
            // 
            // matchFeatureMode
            // 
            this.matchFeatureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matchFeatureMode.FormattingEnabled = true;
            this.matchFeatureMode.Items.AddRange(new object[] {
            "ColorAndShape",
            "Color",
            "Shape"});
            this.matchFeatureMode.Location = new System.Drawing.Point(125, 98);
            this.matchFeatureMode.Name = "matchFeatureMode";
            this.matchFeatureMode.Size = new System.Drawing.Size(151, 21);
            this.matchFeatureMode.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Match Feature Mode:";
            // 
            // searchStrategy
            // 
            this.searchStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchStrategy.FormattingEnabled = true;
            this.searchStrategy.Items.AddRange(new object[] {
            "Conservative",
            "Balanced",
            "Aggressive",
            "VeryAggressive"});
            this.searchStrategy.Location = new System.Drawing.Point(125, 71);
            this.searchStrategy.Name = "searchStrategy";
            this.searchStrategy.Size = new System.Drawing.Size(151, 21);
            this.searchStrategy.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search Strategy:";
            // 
            // colorSensitivity
            // 
            this.colorSensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorSensitivity.FormattingEnabled = true;
            this.colorSensitivity.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.colorSensitivity.Location = new System.Drawing.Point(125, 44);
            this.colorSensitivity.Name = "colorSensitivity";
            this.colorSensitivity.Size = new System.Drawing.Size(151, 21);
            this.colorSensitivity.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Color Sensitivity:";
            // 
            // matchMode
            // 
            this.matchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matchMode.FormattingEnabled = true;
            this.matchMode.Items.AddRange(new object[] {
            "ShiftInvariant",
            "RotationInvariant"});
            this.matchMode.Location = new System.Drawing.Point(125, 17);
            this.matchMode.Name = "matchMode";
            this.matchMode.Size = new System.Drawing.Size(151, 21);
            this.matchMode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match Mode:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(553, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Instructions:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(553, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "1. Load an image file.";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(553, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(266, 28);
            this.label11.TabIndex = 2;
            this.label11.Text = "2. Draw a rectangle around the search item.  Click Learn Pattern.";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(553, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(266, 44);
            this.label12.TabIndex = 2;
            this.label12.Text = "3. Load a new image.  Click Match Pattern to look for the new location of the tem" +
                "plate.  Draw a rectangle to restrict the search area.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.matchesFound);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(554, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 52);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // matchesFound
            // 
            this.matchesFound.Location = new System.Drawing.Point(90, 21);
            this.matchesFound.Name = "matchesFound";
            this.matchesFound.ReadOnly = true;
            this.matchesFound.Size = new System.Drawing.Size(30, 20);
            this.matchesFound.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Matches found:";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(699, 405);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(120, 101);
            this.imageViewer2.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(696, 388);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Pattern Image";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(12, 455);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(82, 33);
            this.loadImageButton.TabIndex = 6;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // learnPatternButton
            // 
            this.learnPatternButton.Enabled = false;
            this.learnPatternButton.Location = new System.Drawing.Point(100, 455);
            this.learnPatternButton.Name = "learnPatternButton";
            this.learnPatternButton.Size = new System.Drawing.Size(82, 33);
            this.learnPatternButton.TabIndex = 6;
            this.learnPatternButton.Text = "Learn Pattern";
            this.learnPatternButton.UseVisualStyleBackColor = true;
            this.learnPatternButton.Click += new System.EventHandler(this.learnPatternButton_Click);
            // 
            // matchPatternButton
            // 
            this.matchPatternButton.Enabled = false;
            this.matchPatternButton.Location = new System.Drawing.Point(188, 455);
            this.matchPatternButton.Name = "matchPatternButton";
            this.matchPatternButton.Size = new System.Drawing.Size(82, 33);
            this.matchPatternButton.TabIndex = 6;
            this.matchPatternButton.Text = "Match Pattern";
            this.matchPatternButton.UseVisualStyleBackColor = true;
            this.matchPatternButton.Click += new System.EventHandler(this.matchPatternButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(276, 455);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(82, 33);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 506);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Image Path:";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(79, 503);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(426, 20);
            this.imagePath.TabIndex = 8;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(511, 503);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(25, 20);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 537);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.matchPatternButton);
            this.Controls.Add(this.learnPatternButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Color Pattern Matching Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorScoreWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesRequested)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox matchMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorSensitivity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox searchStrategy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox matchFeatureMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minimumScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown minimumContrast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown matchesRequested;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown colorScoreWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox subpixelAccuracy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox matchesFound;
        private System.Windows.Forms.Label label13;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button learnPatternButton;
        private System.Windows.Forms.Button matchPatternButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
    }
}

