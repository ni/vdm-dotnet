namespace SimpleCalibration
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
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calibrationOriginPixelY = new System.Windows.Forms.TextBox();
            this.calibrationOriginPixelX = new System.Windows.Forms.TextBox();
            this.calibrationAxisReference = new System.Windows.Forms.TextBox();
            this.calibrationAngle = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.measurementsCalibratedY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.measurementsCalibratedX = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.measurementsPixelY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.measurementsPixelX = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.quitButton = new System.Windows.Forms.Button();
            this.delaySlide = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(486, 410);
            this.imageViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.calibrationAxisReference);
            this.groupBox1.Controls.Add(this.calibrationAngle);
            this.groupBox1.Location = new System.Drawing.Point(504, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration Axis Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Axis Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Angle relative to horizontal (deg):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.calibrationOriginPixelY);
            this.groupBox2.Controls.Add(this.calibrationOriginPixelX);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(78, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origin Pixel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // calibrationOriginPixelY
            // 
            this.calibrationOriginPixelY.Location = new System.Drawing.Point(32, 42);
            this.calibrationOriginPixelY.Name = "calibrationOriginPixelY";
            this.calibrationOriginPixelY.ReadOnly = true;
            this.calibrationOriginPixelY.Size = new System.Drawing.Size(38, 20);
            this.calibrationOriginPixelY.TabIndex = 0;
            // 
            // calibrationOriginPixelX
            // 
            this.calibrationOriginPixelX.Location = new System.Drawing.Point(32, 19);
            this.calibrationOriginPixelX.Name = "calibrationOriginPixelX";
            this.calibrationOriginPixelX.ReadOnly = true;
            this.calibrationOriginPixelX.Size = new System.Drawing.Size(38, 20);
            this.calibrationOriginPixelX.TabIndex = 0;
            // 
            // calibrationAxisReference
            // 
            this.calibrationAxisReference.Location = new System.Drawing.Point(254, 61);
            this.calibrationAxisReference.Name = "calibrationAxisReference";
            this.calibrationAxisReference.ReadOnly = true;
            this.calibrationAxisReference.Size = new System.Drawing.Size(51, 20);
            this.calibrationAxisReference.TabIndex = 0;
            // 
            // calibrationAngle
            // 
            this.calibrationAngle.Location = new System.Drawing.Point(254, 38);
            this.calibrationAngle.Name = "calibrationAngle";
            this.calibrationAngle.ReadOnly = true;
            this.calibrationAngle.Size = new System.Drawing.Size(51, 20);
            this.calibrationAngle.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(504, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 168);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurements";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(158, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 31);
            this.label10.TabIndex = 1;
            this.label10.Text = "Location of the fiducial in the local coordinate system";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(158, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 27);
            this.label9.TabIndex = 1;
            this.label9.Text = "Location of the fiducial in the image coordinate system";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.measurementsCalibratedY);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.measurementsCalibratedX);
            this.groupBox5.Location = new System.Drawing.Point(6, 93);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(134, 68);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Calibrated Coordinates";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Y:";
            // 
            // measurementsCalibratedY
            // 
            this.measurementsCalibratedY.Location = new System.Drawing.Point(32, 40);
            this.measurementsCalibratedY.Name = "measurementsCalibratedY";
            this.measurementsCalibratedY.ReadOnly = true;
            this.measurementsCalibratedY.Size = new System.Drawing.Size(38, 20);
            this.measurementsCalibratedY.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "X:";
            // 
            // measurementsCalibratedX
            // 
            this.measurementsCalibratedX.Location = new System.Drawing.Point(32, 17);
            this.measurementsCalibratedX.Name = "measurementsCalibratedX";
            this.measurementsCalibratedX.ReadOnly = true;
            this.measurementsCalibratedX.Size = new System.Drawing.Size(38, 20);
            this.measurementsCalibratedX.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.measurementsPixelY);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.measurementsPixelX);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(134, 68);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pixel Coordinates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y:";
            // 
            // measurementsPixelY
            // 
            this.measurementsPixelY.Location = new System.Drawing.Point(32, 40);
            this.measurementsPixelY.Name = "measurementsPixelY";
            this.measurementsPixelY.ReadOnly = true;
            this.measurementsPixelY.Size = new System.Drawing.Size(38, 20);
            this.measurementsPixelY.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "X:";
            // 
            // measurementsPixelX
            // 
            this.measurementsPixelX.Location = new System.Drawing.Point(32, 17);
            this.measurementsPixelX.Name = "measurementsPixelX";
            this.measurementsPixelX.ReadOnly = true;
            this.measurementsPixelX.Size = new System.Drawing.Size(38, 20);
            this.measurementsPixelX.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(759, 389);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(56, 33);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // delaySlide
            // 
            this.delaySlide.AutoSize = true;
            this.delaySlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlide.Location = new System.Drawing.Point(510, 300);
            this.delaySlide.Maximum = 1500;
            this.delaySlide.Name = "delaySlide";
            this.delaySlide.Size = new System.Drawing.Size(165, 78);
            this.delaySlide.TabIndex = 6;
            this.delaySlide.Value = 750;
            this.delaySlide.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlide_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 434);
            this.Controls.Add(this.delaySlide);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Simple Calibration Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox calibrationOriginPixelY;
        private System.Windows.Forms.TextBox calibrationOriginPixelX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox calibrationAxisReference;
        private System.Windows.Forms.TextBox calibrationAngle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox measurementsCalibratedY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox measurementsCalibratedX;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox measurementsPixelY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox measurementsPixelX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlide;
    }
}

