namespace Threshold
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
            NationalInstruments.Vision.WindowsForms.Palette palette3 = new NationalInstruments.Vision.WindowsForms.Palette();
            this.imageViewerOriginal = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewerThresholded = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.localTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localYSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.localXSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.niblackUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.localMethodBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.localObjectBox = new System.Windows.Forms.ComboBox();
            this.autoTab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.autoObjectBox = new System.Windows.Forms.ComboBox();
            this.autoMethodBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.manualTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.manualMinimumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.manualMaximumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.tabControl1.SuspendLayout();
            this.localTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localYSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localXSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niblackUpDown)).BeginInit();
            this.autoTab.SuspendLayout();
            this.manualTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewerOriginal
            // 
            this.imageViewerOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerOriginal.Location = new System.Drawing.Point(289, 7);
            this.imageViewerOriginal.Name = "imageViewerOriginal";
            this.imageViewerOriginal.Size = new System.Drawing.Size(267, 242);
            this.imageViewerOriginal.TabIndex = 0;
            // 
            // imageViewerThresholded
            // 
            this.imageViewerThresholded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerThresholded.Location = new System.Drawing.Point(289, 267);
            this.imageViewerThresholded.Name = "imageViewerThresholded";
            palette3.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
            this.imageViewerThresholded.Palette = palette3;
            this.imageViewerThresholded.Size = new System.Drawing.Size(267, 242);
            this.imageViewerThresholded.TabIndex = 1;
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(12, 25);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(185, 120);
            this.imagePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Path";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(203, 25);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(30, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.localTab);
            this.tabControl1.Controls.Add(this.autoTab);
            this.tabControl1.Controls.Add(this.manualTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 161);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(220, 227);
            this.tabControl1.TabIndex = 5;
            // 
            // localTab
            // 
            this.localTab.Controls.Add(this.groupBox1);
            this.localTab.Controls.Add(this.label4);
            this.localTab.Controls.Add(this.niblackUpDown);
            this.localTab.Controls.Add(this.label3);
            this.localTab.Controls.Add(this.localMethodBox);
            this.localTab.Controls.Add(this.label2);
            this.localTab.Controls.Add(this.localObjectBox);
            this.localTab.Location = new System.Drawing.Point(4, 22);
            this.localTab.Name = "localTab";
            this.localTab.Padding = new System.Windows.Forms.Padding(3);
            this.localTab.Size = new System.Drawing.Size(212, 201);
            this.localTab.TabIndex = 0;
            this.localTab.Text = "Local";
            this.localTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localYSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.localXSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window Size";
            // 
            // localYSize
            // 
            this.localYSize.Location = new System.Drawing.Point(64, 44);
            this.localYSize.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.localYSize.Name = "localYSize";
            this.localYSize.Size = new System.Drawing.Size(43, 20);
            this.localYSize.TabIndex = 9;
            this.localYSize.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.localYSize.ValueChanged += new System.EventHandler(this.localYSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Y";
            // 
            // localXSize
            // 
            this.localXSize.Location = new System.Drawing.Point(64, 18);
            this.localXSize.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.localXSize.Name = "localXSize";
            this.localXSize.Size = new System.Drawing.Size(43, 20);
            this.localXSize.TabIndex = 7;
            this.localXSize.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.localXSize.ValueChanged += new System.EventHandler(this.localXSize_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "X";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 43);
            this.label4.TabIndex = 5;
            this.label4.Text = "Niblack Deviation Factor";
            // 
            // niblackUpDown
            // 
            this.niblackUpDown.DecimalPlaces = 1;
            this.niblackUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.niblackUpDown.Location = new System.Drawing.Point(76, 84);
            this.niblackUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.niblackUpDown.Name = "niblackUpDown";
            this.niblackUpDown.Size = new System.Drawing.Size(47, 20);
            this.niblackUpDown.TabIndex = 4;
            this.niblackUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.niblackUpDown.ValueChanged += new System.EventHandler(this.niblackUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Method";
            // 
            // localMethodBox
            // 
            this.localMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localMethodBox.FormattingEnabled = true;
            this.localMethodBox.Items.AddRange(new object[] {
            "Niblack",
            "Background Correction"});
            this.localMethodBox.Location = new System.Drawing.Point(77, 45);
            this.localMethodBox.Name = "localMethodBox";
            this.localMethodBox.Size = new System.Drawing.Size(104, 21);
            this.localMethodBox.TabIndex = 2;
            this.localMethodBox.SelectedIndexChanged += new System.EventHandler(this.localMethodBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object Type";
            // 
            // localObjectBox
            // 
            this.localObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localObjectBox.FormattingEnabled = true;
            this.localObjectBox.Items.AddRange(new object[] {
            "Bright Objects",
            "Dark Objects"});
            this.localObjectBox.Location = new System.Drawing.Point(77, 16);
            this.localObjectBox.Name = "localObjectBox";
            this.localObjectBox.Size = new System.Drawing.Size(104, 21);
            this.localObjectBox.TabIndex = 0;
            this.localObjectBox.SelectedIndexChanged += new System.EventHandler(this.localObjectBox_SelectedIndexChanged);
            // 
            // autoTab
            // 
            this.autoTab.Controls.Add(this.label7);
            this.autoTab.Controls.Add(this.autoObjectBox);
            this.autoTab.Controls.Add(this.autoMethodBox);
            this.autoTab.Controls.Add(this.label8);
            this.autoTab.Location = new System.Drawing.Point(4, 22);
            this.autoTab.Name = "autoTab";
            this.autoTab.Padding = new System.Windows.Forms.Padding(3);
            this.autoTab.Size = new System.Drawing.Size(212, 201);
            this.autoTab.TabIndex = 1;
            this.autoTab.Text = "Automatic";
            this.autoTab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Method";
            // 
            // autoObjectBox
            // 
            this.autoObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoObjectBox.FormattingEnabled = true;
            this.autoObjectBox.Items.AddRange(new object[] {
            "Bright Objects",
            "Dark Objects"});
            this.autoObjectBox.Location = new System.Drawing.Point(77, 16);
            this.autoObjectBox.Name = "autoObjectBox";
            this.autoObjectBox.Size = new System.Drawing.Size(104, 21);
            this.autoObjectBox.TabIndex = 6;
            this.autoObjectBox.SelectedIndexChanged += new System.EventHandler(this.autoObjectBox_SelectedIndexChanged);
            // 
            // autoMethodBox
            // 
            this.autoMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoMethodBox.FormattingEnabled = true;
            this.autoMethodBox.Items.AddRange(new object[] {
            "clustering",
            "entropy",
            "metric",
            "moments",
            "inter-class variance"});
            this.autoMethodBox.Location = new System.Drawing.Point(77, 45);
            this.autoMethodBox.Name = "autoMethodBox";
            this.autoMethodBox.Size = new System.Drawing.Size(104, 21);
            this.autoMethodBox.TabIndex = 8;
            this.autoMethodBox.SelectedIndexChanged += new System.EventHandler(this.autoMethodBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Object Type";
            // 
            // manualTab
            // 
            this.manualTab.Controls.Add(this.manualMaximumSlide);
            this.manualTab.Controls.Add(this.manualMinimumSlide);
            this.manualTab.Controls.Add(this.label10);
            this.manualTab.Controls.Add(this.label11);
            this.manualTab.Location = new System.Drawing.Point(4, 22);
            this.manualTab.Name = "manualTab";
            this.manualTab.Padding = new System.Windows.Forms.Padding(3);
            this.manualTab.Size = new System.Drawing.Size(212, 201);
            this.manualTab.TabIndex = 2;
            this.manualTab.Text = "Manual";
            this.manualTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Maximum Value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Minimum Value";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(17, 468);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(72, 40);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // manualMinimumSlide
            // 
            this.manualMinimumSlide.AutoSize = true;
            this.manualMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.manualMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.manualMinimumSlide.Location = new System.Drawing.Point(6, 25);
            this.manualMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.manualMinimumSlide.Name = "manualMinimumSlide";
            this.manualMinimumSlide.Size = new System.Drawing.Size(203, 53);
            this.manualMinimumSlide.TabIndex = 16;
            this.manualMinimumSlide.Value = 0;
            this.manualMinimumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.manualMinimumSlide_ValueChanged);
            // 
            // manualMaximumSlide
            // 
            this.manualMaximumSlide.AutoSize = true;
            this.manualMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.manualMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.manualMaximumSlide.Location = new System.Drawing.Point(6, 109);
            this.manualMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.manualMaximumSlide.Name = "manualMaximumSlide";
            this.manualMaximumSlide.Size = new System.Drawing.Size(203, 53);
            this.manualMaximumSlide.TabIndex = 16;
            this.manualMaximumSlide.Value = 100;
            this.manualMaximumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.manualMaximumSlide_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 520);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.imageViewerThresholded);
            this.Controls.Add(this.imageViewerOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.localTab.ResumeLayout(false);
            this.localTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localYSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localXSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niblackUpDown)).EndInit();
            this.autoTab.ResumeLayout(false);
            this.autoTab.PerformLayout();
            this.manualTab.ResumeLayout(false);
            this.manualTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewerOriginal;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewerThresholded;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage localTab;
        private System.Windows.Forms.NumericUpDown niblackUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox localMethodBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox localObjectBox;
        private System.Windows.Forms.TabPage autoTab;
        private System.Windows.Forms.TabPage manualTab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown localYSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown localXSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox autoObjectBox;
        private System.Windows.Forms.ComboBox autoMethodBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider manualMaximumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider manualMinimumSlide;
    }
}

