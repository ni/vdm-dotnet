namespace PerspectiveCalibration
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
            this.loadCalibrationButton = new System.Windows.Forms.Button();
            this.learnCalibrationButton = new System.Windows.Forms.Button();
            this.measureDistancesButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(592, 423);
            this.imageViewer1.TabIndex = 0;
            // 
            // loadCalibrationButton
            // 
            this.loadCalibrationButton.Location = new System.Drawing.Point(12, 441);
            this.loadCalibrationButton.Name = "loadCalibrationButton";
            this.loadCalibrationButton.Size = new System.Drawing.Size(163, 31);
            this.loadCalibrationButton.TabIndex = 1;
            this.loadCalibrationButton.Text = "Load Calibration Template";
            this.loadCalibrationButton.UseVisualStyleBackColor = true;
            this.loadCalibrationButton.Click += new System.EventHandler(this.loadCalibrationButton_Click);
            // 
            // learnCalibrationButton
            // 
            this.learnCalibrationButton.Enabled = false;
            this.learnCalibrationButton.Location = new System.Drawing.Point(12, 478);
            this.learnCalibrationButton.Name = "learnCalibrationButton";
            this.learnCalibrationButton.Size = new System.Drawing.Size(163, 31);
            this.learnCalibrationButton.TabIndex = 1;
            this.learnCalibrationButton.Text = "Learn Calibration";
            this.learnCalibrationButton.UseVisualStyleBackColor = true;
            this.learnCalibrationButton.Click += new System.EventHandler(this.learnCalibrationButton_Click);
            // 
            // measureDistancesButton
            // 
            this.measureDistancesButton.Enabled = false;
            this.measureDistancesButton.Location = new System.Drawing.Point(12, 515);
            this.measureDistancesButton.Name = "measureDistancesButton";
            this.measureDistancesButton.Size = new System.Drawing.Size(163, 31);
            this.measureDistancesButton.TabIndex = 1;
            this.measureDistancesButton.Text = "Measure Distances";
            this.measureDistancesButton.UseVisualStyleBackColor = true;
            this.measureDistancesButton.Click += new System.EventHandler(this.measureDistancesButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(546, 520);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(58, 26);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Instructions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "1. Load the calibration grid.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "2. Learn the calibration grid.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 496);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "3. Measure the distances in the distorted image.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 558);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.measureDistancesButton);
            this.Controls.Add(this.learnCalibrationButton);
            this.Controls.Add(this.loadCalibrationButton);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Perspective Calibration Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Button loadCalibrationButton;
        private System.Windows.Forms.Button learnCalibrationButton;
        private System.Windows.Forms.Button measureDistancesButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

