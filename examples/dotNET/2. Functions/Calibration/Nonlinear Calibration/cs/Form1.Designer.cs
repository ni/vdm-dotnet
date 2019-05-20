namespace NonlinearCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.loadCalibrationButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.learnCalibrationButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.loadTargetButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.measurePartsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.wholeImageTime = new System.Windows.Forms.TextBox();
            this.coinsImageTime = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(17, 21);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(542, 282);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Load the calibration grid.";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(17, 314);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(542, 282);
            this.imageViewer2.TabIndex = 0;
            // 
            // loadCalibrationButton
            // 
            this.loadCalibrationButton.Location = new System.Drawing.Point(568, 39);
            this.loadCalibrationButton.Name = "loadCalibrationButton";
            this.loadCalibrationButton.Size = new System.Drawing.Size(149, 34);
            this.loadCalibrationButton.TabIndex = 2;
            this.loadCalibrationButton.Text = "Load Calibration Template";
            this.loadCalibrationButton.UseVisualStyleBackColor = true;
            this.loadCalibrationButton.Click += new System.EventHandler(this.loadCalibrationButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(565, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "2. Learn the calibration grid. (This process is computation intensive and may tak" +
                "e a while)";
            // 
            // learnCalibrationButton
            // 
            this.learnCalibrationButton.Enabled = false;
            this.learnCalibrationButton.Location = new System.Drawing.Point(568, 125);
            this.learnCalibrationButton.Name = "learnCalibrationButton";
            this.learnCalibrationButton.Size = new System.Drawing.Size(149, 34);
            this.learnCalibrationButton.TabIndex = 2;
            this.learnCalibrationButton.Text = "Learn Calibration";
            this.learnCalibrationButton.UseVisualStyleBackColor = true;
            this.learnCalibrationButton.Click += new System.EventHandler(this.learnCalibrationButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(565, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "3. Use the calibration information learned in the previous step to measure the ob" +
                "ject areas in the distorted target image.";
            // 
            // loadTargetButton
            // 
            this.loadTargetButton.Enabled = false;
            this.loadTargetButton.Location = new System.Drawing.Point(568, 222);
            this.loadTargetButton.Name = "loadTargetButton";
            this.loadTargetButton.Size = new System.Drawing.Size(149, 34);
            this.loadTargetButton.TabIndex = 2;
            this.loadTargetButton.Text = "Load Target Image";
            this.loadTargetButton.UseVisualStyleBackColor = true;
            this.loadTargetButton.Click += new System.EventHandler(this.loadTargetButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(565, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "4. Correct the image and measure the object areas.";
            // 
            // measurePartsButton
            // 
            this.measurePartsButton.Enabled = false;
            this.measurePartsButton.Location = new System.Drawing.Point(568, 306);
            this.measurePartsButton.Name = "measurePartsButton";
            this.measurePartsButton.Size = new System.Drawing.Size(149, 34);
            this.measurePartsButton.TabIndex = 2;
            this.measurePartsButton.Text = "Measure Parts";
            this.measurePartsButton.UseVisualStyleBackColor = true;
            this.measurePartsButton.Click += new System.EventHandler(this.measurePartsButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(565, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 69);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(565, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 41);
            this.label6.TabIndex = 3;
            this.label6.Text = "time (ms) to correct entire image, threshold and calculate measurements";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(697, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 41);
            this.label7.TabIndex = 3;
            this.label7.Text = "time (ms) to threshold, correct just coins, and then take measurements";
            // 
            // wholeImageTime
            // 
            this.wholeImageTime.Location = new System.Drawing.Point(568, 497);
            this.wholeImageTime.Name = "wholeImageTime";
            this.wholeImageTime.ReadOnly = true;
            this.wholeImageTime.Size = new System.Drawing.Size(46, 20);
            this.wholeImageTime.TabIndex = 4;
            // 
            // coinsImageTime
            // 
            this.coinsImageTime.Location = new System.Drawing.Point(700, 497);
            this.coinsImageTime.Name = "coinsImageTime";
            this.coinsImageTime.ReadOnly = true;
            this.coinsImageTime.Size = new System.Drawing.Size(46, 20);
            this.coinsImageTime.TabIndex = 4;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(568, 574);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(149, 34);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 611);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.coinsImageTime);
            this.Controls.Add(this.wholeImageTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.measurePartsButton);
            this.Controls.Add(this.loadTargetButton);
            this.Controls.Add(this.learnCalibrationButton);
            this.Controls.Add(this.loadCalibrationButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Nonlinear Calibration Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Button loadCalibrationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button learnCalibrationButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadTargetButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button measurePartsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox wholeImageTime;
        private System.Windows.Forms.TextBox coinsImageTime;
        private System.Windows.Forms.Button quitButton;
    }
}

