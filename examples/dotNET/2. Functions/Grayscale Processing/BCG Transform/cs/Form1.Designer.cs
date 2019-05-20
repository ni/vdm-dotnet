namespace BcgTransform
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
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.brightnessUpDown = new System.Windows.Forms.NumericUpDown();
            this.contrastUpDown = new System.Windows.Forms.NumericUpDown();
            this.gammaUpDown = new System.Windows.Forms.NumericUpDown();
            this.resetButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.brightnessSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.contrastSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.gammaSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 32);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(516, 269);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer1_ImagePanned);
            this.imageViewer1.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer1_ImageZoomed);
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(12, 338);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(516, 269);
            this.imageViewer2.TabIndex = 0;
            this.imageViewer2.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer2_ImagePanned);
            this.imageViewer2.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer2_ImageZoomed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Transformed Image";
            // 
            // brightnessUpDown
            // 
            this.brightnessUpDown.Location = new System.Drawing.Point(752, 60);
            this.brightnessUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.brightnessUpDown.Name = "brightnessUpDown";
            this.brightnessUpDown.Size = new System.Drawing.Size(54, 20);
            this.brightnessUpDown.TabIndex = 3;
            this.brightnessUpDown.Value = new decimal(new int[] {
            171,
            0,
            0,
            0});
            this.brightnessUpDown.ValueChanged += new System.EventHandler(this.brightnessUpDown_ValueChanged);
            // 
            // contrastUpDown
            // 
            this.contrastUpDown.Location = new System.Drawing.Point(752, 137);
            this.contrastUpDown.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.contrastUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.contrastUpDown.Name = "contrastUpDown";
            this.contrastUpDown.Size = new System.Drawing.Size(54, 20);
            this.contrastUpDown.TabIndex = 3;
            this.contrastUpDown.Value = new decimal(new int[] {
            56,
            0,
            0,
            0});
            this.contrastUpDown.ValueChanged += new System.EventHandler(this.contrastUpDown_ValueChanged);
            // 
            // gammaUpDown
            // 
            this.gammaUpDown.DecimalPlaces = 1;
            this.gammaUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gammaUpDown.Location = new System.Drawing.Point(752, 214);
            this.gammaUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.gammaUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gammaUpDown.Name = "gammaUpDown";
            this.gammaUpDown.Size = new System.Drawing.Size(54, 20);
            this.gammaUpDown.TabIndex = 3;
            this.gammaUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gammaUpDown.ValueChanged += new System.EventHandler(this.gammaUpDown_ValueChanged);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(724, 261);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(82, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset Values";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(781, 328);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(25, 20);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(537, 328);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(234, 20);
            this.imagePath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Image Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Instructions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(534, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "1. Load an image file.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "2. Modify the brightness, contrast, and gamma values.";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(649, 425);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(76, 29);
            this.loadImageButton.TabIndex = 10;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(731, 425);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(76, 29);
            this.quitButton.TabIndex = 10;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // brightnessSlide
            // 
            this.brightnessSlide.AutoSize = true;
            this.brightnessSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.brightnessSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.brightnessSlide.Location = new System.Drawing.Point(547, 44);
            this.brightnessSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.brightnessSlide.Name = "brightnessSlide";
            this.brightnessSlide.Size = new System.Drawing.Size(203, 53);
            this.brightnessSlide.TabIndex = 11;
            this.brightnessSlide.Value = 171;
            this.brightnessSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.brightnessSlide_ValueChanged);
            // 
            // contrastSlide
            // 
            this.contrastSlide.AutoSize = true;
            this.contrastSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contrastSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.contrastSlide.Location = new System.Drawing.Point(547, 126);
            this.contrastSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.OneTo90;
            this.contrastSlide.Name = "contrastSlide";
            this.contrastSlide.Size = new System.Drawing.Size(203, 53);
            this.contrastSlide.TabIndex = 11;
            this.contrastSlide.Value = 56;
            this.contrastSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.contrastSlide_ValueChanged);
            // 
            // gammaSlide
            // 
            this.gammaSlide.AutoSize = true;
            this.gammaSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gammaSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.gammaSlide.Location = new System.Drawing.Point(547, 202);
            this.gammaSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.OneTo10Log;
            this.gammaSlide.Name = "gammaSlide";
            this.gammaSlide.Size = new System.Drawing.Size(203, 53);
            this.gammaSlide.TabIndex = 11;
            this.gammaSlide.Value = 2;
            this.gammaSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.gammaSlide_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Brightness";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(563, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Contrast";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Gamma";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 619);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gammaSlide);
            this.Controls.Add(this.contrastSlide);
            this.Controls.Add(this.brightnessSlide);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.gammaUpDown);
            this.Controls.Add(this.contrastUpDown);
            this.Controls.Add(this.brightnessUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "BCG Transform Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown brightnessUpDown;
        private System.Windows.Forms.NumericUpDown contrastUpDown;
        private System.Windows.Forms.NumericUpDown gammaUpDown;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider brightnessSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider contrastSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider gammaSlide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

