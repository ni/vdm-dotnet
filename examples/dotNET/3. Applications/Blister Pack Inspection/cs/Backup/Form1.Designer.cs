namespace BlisterPackInspection
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.matchesRequested = new System.Windows.Forms.Label();
            this.matchesFound = new System.Windows.Forms.Label();
            this.timeTaken = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.quitButton = new System.Windows.Forms.Button();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.passFailLed = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(426, 279);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of matches requested:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of matches found:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time (ms):";
            // 
            // matchesRequested
            // 
            this.matchesRequested.AutoSize = true;
            this.matchesRequested.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchesRequested.Location = new System.Drawing.Point(312, 294);
            this.matchesRequested.Name = "matchesRequested";
            this.matchesRequested.Size = new System.Drawing.Size(32, 24);
            this.matchesRequested.TabIndex = 2;
            this.matchesRequested.Text = "12";
            // 
            // matchesFound
            // 
            this.matchesFound.AutoSize = true;
            this.matchesFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchesFound.Location = new System.Drawing.Point(312, 318);
            this.matchesFound.Name = "matchesFound";
            this.matchesFound.Size = new System.Drawing.Size(21, 24);
            this.matchesFound.TabIndex = 2;
            this.matchesFound.Text = "0";
            // 
            // timeTaken
            // 
            this.timeTaken.AutoSize = true;
            this.timeTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTaken.Location = new System.Drawing.Point(312, 342);
            this.timeTaken.Name = "timeTaken";
            this.timeTaken.Size = new System.Drawing.Size(21, 24);
            this.timeTaken.TabIndex = 2;
            this.timeTaken.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(385, 426);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(51, 29);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(12, 378);
            this.delaySlider1.Maximum = 1000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 5;
            this.delaySlider1.Value = 750;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // passFailLed
            // 
            this.passFailLed.Caption = "Pass?";
            this.passFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen;
            this.passFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed.Location = new System.Drawing.Point(347, 297);
            this.passFailLed.Name = "passFailLed";
            this.passFailLed.Size = new System.Drawing.Size(88, 91);
            this.passFailLed.TabIndex = 6;
            this.passFailLed.Value = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 468);
            this.Controls.Add(this.passFailLed);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.timeTaken);
            this.Controls.Add(this.matchesFound);
            this.Controls.Add(this.matchesRequested);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Blister Pack Inspection Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label matchesRequested;
        private System.Windows.Forms.Label matchesFound;
        private System.Windows.Forms.Label timeTaken;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed;
    }
}

