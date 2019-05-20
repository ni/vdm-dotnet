namespace ColorThreshold
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
            NationalInstruments.Vision.WindowsForms.Palette palette8 = new NationalInstruments.Vision.WindowsForms.Palette();
            this.label1 = new System.Windows.Forms.Label();
            this.stepNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageSelection2 = new System.Windows.Forms.RadioButton();
            this.imageSelection1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageTypeHSL = new System.Windows.Forms.RadioButton();
            this.imageTypeRGB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label12 = new System.Windows.Forms.Label();
            this.imageViewer2Label = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.redMinimumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.redMaximumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.greenMinimumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.greenMaximumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.blueMinimumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.blueMaximumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "This example illustrates how to use the HSL color space to perform inspection tas" +
                "ks based on object colors.";
            // 
            // stepNumber
            // 
            this.stepNumber.Location = new System.Drawing.Point(44, 59);
            this.stepNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.stepNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepNumber.Name = "stepNumber";
            this.stepNumber.Size = new System.Drawing.Size(38, 20);
            this.stepNumber.TabIndex = 1;
            this.stepNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepNumber.ValueChanged += new System.EventHandler(this.stepNumber_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Step";
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.Location = new System.Drawing.Point(12, 85);
            this.stepsTextBox.Multiline = true;
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.ReadOnly = true;
            this.stepsTextBox.Size = new System.Drawing.Size(296, 87);
            this.stepsTextBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageSelection2);
            this.groupBox1.Controls.Add(this.imageSelection1);
            this.groupBox1.Location = new System.Drawing.Point(12, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Image";
            // 
            // imageSelection2
            // 
            this.imageSelection2.AutoSize = true;
            this.imageSelection2.Location = new System.Drawing.Point(10, 43);
            this.imageSelection2.Name = "imageSelection2";
            this.imageSelection2.Size = new System.Drawing.Size(63, 17);
            this.imageSelection2.TabIndex = 0;
            this.imageSelection2.Text = "Image 2";
            this.imageSelection2.UseVisualStyleBackColor = true;
            this.imageSelection2.CheckedChanged += new System.EventHandler(this.imageSelection2_CheckedChanged);
            // 
            // imageSelection1
            // 
            this.imageSelection1.AutoSize = true;
            this.imageSelection1.Checked = true;
            this.imageSelection1.Location = new System.Drawing.Point(10, 20);
            this.imageSelection1.Name = "imageSelection1";
            this.imageSelection1.Size = new System.Drawing.Size(63, 17);
            this.imageSelection1.TabIndex = 0;
            this.imageSelection1.TabStop = true;
            this.imageSelection1.Text = "Image 1";
            this.imageSelection1.UseVisualStyleBackColor = true;
            this.imageSelection1.CheckedChanged += new System.EventHandler(this.imageSelection1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imageTypeHSL);
            this.groupBox2.Controls.Add(this.imageTypeRGB);
            this.groupBox2.Location = new System.Drawing.Point(102, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 69);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Threshold Color Mode";
            // 
            // imageTypeHSL
            // 
            this.imageTypeHSL.AutoSize = true;
            this.imageTypeHSL.Location = new System.Drawing.Point(12, 43);
            this.imageTypeHSL.Name = "imageTypeHSL";
            this.imageTypeHSL.Size = new System.Drawing.Size(187, 17);
            this.imageTypeHSL.TabIndex = 0;
            this.imageTypeHSL.Text = "HSL (Hue, Saturation, Luminance)";
            this.imageTypeHSL.UseVisualStyleBackColor = true;
            this.imageTypeHSL.CheckedChanged += new System.EventHandler(this.imageTypeHSL_CheckedChanged);
            // 
            // imageTypeRGB
            // 
            this.imageTypeRGB.AutoSize = true;
            this.imageTypeRGB.Checked = true;
            this.imageTypeRGB.Location = new System.Drawing.Point(12, 20);
            this.imageTypeRGB.Name = "imageTypeRGB";
            this.imageTypeRGB.Size = new System.Drawing.Size(139, 17);
            this.imageTypeRGB.TabIndex = 0;
            this.imageTypeRGB.TabStop = true;
            this.imageTypeRGB.Text = "RGB (Red, Green, Blue)";
            this.imageTypeRGB.UseVisualStyleBackColor = true;
            this.imageTypeRGB.CheckedChanged += new System.EventHandler(this.imageTypeRGB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Red or Hue";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Green or Saturation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Blue or Luminance";
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(342, 18);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(312, 247);
            this.imageViewer1.TabIndex = 16;
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(342, 293);
            this.imageViewer2.Name = "imageViewer2";
            palette8.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
            this.imageViewer2.Palette = palette8;
            this.imageViewer2.Size = new System.Drawing.Size(312, 247);
            this.imageViewer2.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(339, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Original Image";
            // 
            // imageViewer2Label
            // 
            this.imageViewer2Label.AutoSize = true;
            this.imageViewer2Label.Location = new System.Drawing.Point(339, 277);
            this.imageViewer2Label.Name = "imageViewer2Label";
            this.imageViewer2Label.Size = new System.Drawing.Size(0, 13);
            this.imageViewer2Label.TabIndex = 17;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(229, 9);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(79, 35);
            this.quitButton.TabIndex = 18;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // redMinimumSlide
            // 
            this.redMinimumSlide.AutoSize = true;
            this.redMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.redMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Red;
            this.redMinimumSlide.Location = new System.Drawing.Point(22, 277);
            this.redMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.redMinimumSlide.Name = "redMinimumSlide";
            this.redMinimumSlide.Size = new System.Drawing.Size(203, 53);
            this.redMinimumSlide.TabIndex = 19;
            this.redMinimumSlide.Value = 42;
            this.redMinimumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.redMinimumSlide_ValueChanged);
            // 
            // redMaximumSlide
            // 
            this.redMaximumSlide.AutoSize = true;
            this.redMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.redMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Red;
            this.redMaximumSlide.Location = new System.Drawing.Point(22, 321);
            this.redMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.redMaximumSlide.Name = "redMaximumSlide";
            this.redMaximumSlide.Size = new System.Drawing.Size(203, 53);
            this.redMaximumSlide.TabIndex = 19;
            this.redMaximumSlide.Value = 121;
            this.redMaximumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.redMaximumSlide_ValueChanged);
            // 
            // greenMinimumSlide
            // 
            this.greenMinimumSlide.AutoSize = true;
            this.greenMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.greenMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Green;
            this.greenMinimumSlide.Location = new System.Drawing.Point(22, 387);
            this.greenMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.greenMinimumSlide.Name = "greenMinimumSlide";
            this.greenMinimumSlide.Size = new System.Drawing.Size(203, 53);
            this.greenMinimumSlide.TabIndex = 19;
            this.greenMinimumSlide.Value = 15;
            this.greenMinimumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.greenMinimumSlide_ValueChanged);
            // 
            // greenMaximumSlide
            // 
            this.greenMaximumSlide.AutoSize = true;
            this.greenMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.greenMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Green;
            this.greenMaximumSlide.Location = new System.Drawing.Point(22, 431);
            this.greenMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.greenMaximumSlide.Name = "greenMaximumSlide";
            this.greenMaximumSlide.Size = new System.Drawing.Size(203, 53);
            this.greenMaximumSlide.TabIndex = 19;
            this.greenMaximumSlide.Value = 255;
            this.greenMaximumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.greenMaximumSlide_ValueChanged);
            // 
            // blueMinimumSlide
            // 
            this.blueMinimumSlide.AutoSize = true;
            this.blueMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.blueMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Blue;
            this.blueMinimumSlide.Location = new System.Drawing.Point(22, 499);
            this.blueMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.blueMinimumSlide.Name = "blueMinimumSlide";
            this.blueMinimumSlide.Size = new System.Drawing.Size(203, 53);
            this.blueMinimumSlide.TabIndex = 19;
            this.blueMinimumSlide.Value = 54;
            this.blueMinimumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.blueMinimumSlide_ValueChanged);
            // 
            // blueMaximumSlide
            // 
            this.blueMaximumSlide.AutoSize = true;
            this.blueMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.blueMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Blue;
            this.blueMaximumSlide.Location = new System.Drawing.Point(22, 543);
            this.blueMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.blueMaximumSlide.Name = "blueMaximumSlide";
            this.blueMaximumSlide.Size = new System.Drawing.Size(203, 53);
            this.blueMaximumSlide.TabIndex = 19;
            this.blueMaximumSlide.Value = 255;
            this.blueMaximumSlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.blueMaximumSlide_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 597);
            this.Controls.Add(this.blueMaximumSlide);
            this.Controls.Add(this.blueMinimumSlide);
            this.Controls.Add(this.greenMaximumSlide);
            this.Controls.Add(this.greenMinimumSlide);
            this.Controls.Add(this.redMaximumSlide);
            this.Controls.Add(this.redMinimumSlide);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.imageViewer2Label);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stepsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stepNumber);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Color Threshold Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stepNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown stepNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton imageSelection2;
        private System.Windows.Forms.RadioButton imageSelection1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton imageTypeHSL;
        private System.Windows.Forms.RadioButton imageTypeRGB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label imageViewer2Label;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider redMinimumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider redMaximumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider greenMinimumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider greenMaximumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider blueMinimumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider blueMaximumSlide;
    }
}

