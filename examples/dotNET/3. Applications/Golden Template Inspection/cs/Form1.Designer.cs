namespace GoldenTemplateInspection
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
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.brightColorLabel = new System.Windows.Forms.Label();
            this.darkColorLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.darkSwitch = new NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch();
            this.brightSwitch = new NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch();
            this.passFailLed = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(11, 24);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(319, 266);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Golden Template";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(345, 24);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(490, 351);
            this.imageViewer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inspected Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Show Bright Defects";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Show Dark Defects";
            // 
            // brightColorLabel
            // 
            this.brightColorLabel.BackColor = System.Drawing.Color.Lime;
            this.brightColorLabel.Location = new System.Drawing.Point(42, 413);
            this.brightColorLabel.Name = "brightColorLabel";
            this.brightColorLabel.Size = new System.Drawing.Size(44, 36);
            this.brightColorLabel.TabIndex = 4;
            // 
            // darkColorLabel
            // 
            this.darkColorLabel.BackColor = System.Drawing.Color.Red;
            this.darkColorLabel.Location = new System.Drawing.Point(163, 413);
            this.darkColorLabel.Name = "darkColorLabel";
            this.darkColorLabel.Size = new System.Drawing.Size(44, 36);
            this.darkColorLabel.TabIndex = 4;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(761, 454);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(74, 35);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // darkSwitch
            // 
            this.darkSwitch.AutoSize = true;
            this.darkSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.darkSwitch.Location = new System.Drawing.Point(152, 325);
            this.darkSwitch.Name = "darkSwitch";
            this.darkSwitch.Size = new System.Drawing.Size(68, 85);
            this.darkSwitch.TabIndex = 9;
            this.darkSwitch.Value = true;
            // 
            // brightSwitch
            // 
            this.brightSwitch.AutoSize = true;
            this.brightSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.brightSwitch.Location = new System.Drawing.Point(28, 325);
            this.brightSwitch.Name = "brightSwitch";
            this.brightSwitch.Size = new System.Drawing.Size(68, 85);
            this.brightSwitch.TabIndex = 9;
            this.brightSwitch.Value = true;
            // 
            // passFailLed
            // 
            this.passFailLed.Caption = "Pass?";
            this.passFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen;
            this.passFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed.Location = new System.Drawing.Point(269, 330);
            this.passFailLed.Name = "passFailLed";
            this.passFailLed.Size = new System.Drawing.Size(60, 80);
            this.passFailLed.TabIndex = 8;
            this.passFailLed.Value = true;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(345, 390);
            this.delaySlider1.Maximum = 2500;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 7;
            this.delaySlider1.Value = 1250;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 495);
            this.Controls.Add(this.darkSwitch);
            this.Controls.Add(this.brightSwitch);
            this.Controls.Add(this.passFailLed);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.darkColorLabel);
            this.Controls.Add(this.brightColorLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Golden Template Inspection Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label brightColorLabel;
        private System.Windows.Forms.Label darkColorLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed;
        private NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch brightSwitch;
        private NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch darkSwitch;
    }
}

