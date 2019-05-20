namespace FuseInspection
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
            this.imageViewer3 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defineCoordinateSystemButton = new System.Windows.Forms.Button();
            this.defineTemplatesButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageNumberLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.passOrFail = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(531, 399);
            this.imageViewer1.TabIndex = 0;
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(12, 447);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(123, 104);
            this.imageViewer2.TabIndex = 1;
            // 
            // imageViewer3
            // 
            this.imageViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer3.Location = new System.Drawing.Point(12, 581);
            this.imageViewer3.Name = "imageViewer3";
            this.imageViewer3.Size = new System.Drawing.Size(123, 104);
            this.imageViewer3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Template Image 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template Image 2";
            // 
            // defineCoordinateSystemButton
            // 
            this.defineCoordinateSystemButton.Location = new System.Drawing.Point(426, 424);
            this.defineCoordinateSystemButton.Name = "defineCoordinateSystemButton";
            this.defineCoordinateSystemButton.Size = new System.Drawing.Size(138, 42);
            this.defineCoordinateSystemButton.TabIndex = 3;
            this.defineCoordinateSystemButton.Text = "Define Coordinate System";
            this.defineCoordinateSystemButton.UseVisualStyleBackColor = true;
            this.defineCoordinateSystemButton.Click += new System.EventHandler(this.defineCoordinateSystemButton_Click);
            // 
            // defineTemplatesButton
            // 
            this.defineTemplatesButton.Enabled = false;
            this.defineTemplatesButton.Location = new System.Drawing.Point(426, 472);
            this.defineTemplatesButton.Name = "defineTemplatesButton";
            this.defineTemplatesButton.Size = new System.Drawing.Size(138, 42);
            this.defineTemplatesButton.TabIndex = 3;
            this.defineTemplatesButton.Text = "Define Templates";
            this.defineTemplatesButton.UseVisualStyleBackColor = true;
            this.defineTemplatesButton.Click += new System.EventHandler(this.defineTemplatesButton_Click);
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(426, 520);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(138, 42);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(426, 693);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(138, 42);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passOrFail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.imageNumberLabel);
            this.groupBox1.Location = new System.Drawing.Point(141, 621);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 83);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Image Number";
            // 
            // imageNumberLabel
            // 
            this.imageNumberLabel.Location = new System.Drawing.Point(19, 40);
            this.imageNumberLabel.Name = "imageNumberLabel";
            this.imageNumberLabel.ReadOnly = true;
            this.imageNumberLabel.Size = new System.Drawing.Size(40, 20);
            this.imageNumberLabel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Instructions:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(157, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 44);
            this.label6.TabIndex = 7;
            this.label6.Text = "1. The example loads an image used to define the coordinate system for the inspec" +
                "tion task.  Click Define Coordinate System.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(157, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 64);
            this.label7.TabIndex = 7;
            this.label7.Text = "2. Click Define Templates.  The example displays two templates containing definin" +
                "g features of the part.  Two templates are necessary because the part is not sym" +
                "metric.  Click Run.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(157, 551);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 64);
            this.label8.TabIndex = 7;
            this.label8.Text = "3. The example loads a new image, finds the new coordinate system by locating the" +
                " edges of the fuse, matches the region of inspection against the template images" +
                ", and returns the results.";
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // passOrFail
            // 
            this.passOrFail.Caption = "Pass?";
            this.passOrFail.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen;
            this.passOrFail.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passOrFail.Location = new System.Drawing.Point(107, 7);
            this.passOrFail.Name = "passOrFail";
            this.passOrFail.Size = new System.Drawing.Size(69, 70);
            this.passOrFail.TabIndex = 2;
            this.passOrFail.Value = true;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(404, 568);
            this.delaySlider1.Maximum = 2000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 8;
            this.delaySlider1.Value = 750;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 737);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.defineTemplatesButton);
            this.Controls.Add(this.defineCoordinateSystemButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer3);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Fuse Inspection Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button defineCoordinateSystemButton;
        private System.Windows.Forms.Button defineTemplatesButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imageNumberLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passOrFail;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

