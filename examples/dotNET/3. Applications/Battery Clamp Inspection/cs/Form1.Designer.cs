namespace BatteryClampInspection
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
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.distanceBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.centerYBox = new System.Windows.Forms.TextBox();
            this.centerXBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.defineCoordinateSystemButton = new System.Windows.Forms.Button();
            this.defineMeasurementsButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.quitButton = new System.Windows.Forms.Button();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(622, 436);
            this.imageViewer1.TabIndex = 0;
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(643, 29);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(247, 237);
            this.imageViewer2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coordinate System Template";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.distanceBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(643, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(199, 33);
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.ReadOnly = true;
            this.distanceBox.Size = new System.Drawing.Size(41, 20);
            this.distanceBox.TabIndex = 2;
            this.distanceBox.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Distance:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.radiusBox);
            this.groupBox2.Controls.Add(this.centerYBox);
            this.groupBox2.Controls.Add(this.centerXBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(11, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Best Circle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Radius:";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point(67, 61);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.ReadOnly = true;
            this.radiusBox.Size = new System.Drawing.Size(55, 20);
            this.radiusBox.TabIndex = 2;
            this.radiusBox.Text = "0.00";
            // 
            // centerYBox
            // 
            this.centerYBox.Location = new System.Drawing.Point(67, 37);
            this.centerYBox.Name = "centerYBox";
            this.centerYBox.ReadOnly = true;
            this.centerYBox.Size = new System.Drawing.Size(55, 20);
            this.centerYBox.TabIndex = 2;
            this.centerYBox.Text = "0.00";
            // 
            // centerXBox
            // 
            this.centerXBox.Location = new System.Drawing.Point(67, 15);
            this.centerXBox.Name = "centerXBox";
            this.centerXBox.ReadOnly = true;
            this.centerXBox.Size = new System.Drawing.Size(55, 20);
            this.centerXBox.TabIndex = 2;
            this.centerXBox.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Center ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Instructions:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 470);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(455, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "1. Click Define Coordinate System to load a template image that is matched in eac" +
                "h new image.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 502);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(359, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "2. Click Define Measurements to define the regions of interest in the image.";
            // 
            // defineCoordinateSystemButton
            // 
            this.defineCoordinateSystemButton.Location = new System.Drawing.Point(494, 464);
            this.defineCoordinateSystemButton.Name = "defineCoordinateSystemButton";
            this.defineCoordinateSystemButton.Size = new System.Drawing.Size(140, 25);
            this.defineCoordinateSystemButton.TabIndex = 5;
            this.defineCoordinateSystemButton.Text = "Define Coordinate System";
            this.defineCoordinateSystemButton.UseVisualStyleBackColor = true;
            this.defineCoordinateSystemButton.Click += new System.EventHandler(this.defineCoordinateSystemButton_Click);
            // 
            // defineMeasurementsButton
            // 
            this.defineMeasurementsButton.Enabled = false;
            this.defineMeasurementsButton.Location = new System.Drawing.Point(494, 496);
            this.defineMeasurementsButton.Name = "defineMeasurementsButton";
            this.defineMeasurementsButton.Size = new System.Drawing.Size(140, 25);
            this.defineMeasurementsButton.TabIndex = 5;
            this.defineMeasurementsButton.Text = "Define Measurements";
            this.defineMeasurementsButton.UseVisualStyleBackColor = true;
            this.defineMeasurementsButton.Click += new System.EventHandler(this.defineMeasurementsButton_Click);
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(494, 528);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(140, 25);
            this.runButton.TabIndex = 5;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(479, 32);
            this.label10.TabIndex = 4;
            this.label10.Text = "3. Click Run.  The example loads a new image, finds the new coordinate system by " +
                "matching the pattern, adjusts the regions of interest, and returns the results.";
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(822, 536);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(68, 31);
            this.quitButton.TabIndex = 8;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(643, 418);
            this.delaySlider1.Maximum = 2000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 9;
            this.delaySlider1.Value = 750;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 575);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.defineMeasurementsButton);
            this.Controls.Add(this.defineCoordinateSystemButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Battery Clamp Inspection Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox centerYBox;
        private System.Windows.Forms.TextBox centerXBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.TextBox distanceBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button defineCoordinateSystemButton;
        private System.Windows.Forms.Button defineMeasurementsButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

