namespace Classification
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exitButton = new System.Windows.Forms.Button();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.classificationGraph1 = new NationalInstruments.Vision.MeasurementStudioDemo.ClassificationGraph();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(835, 439);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(62, 39);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(21, 13);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(521, 465);
            this.imageViewer1.TabIndex = 4;
            // 
            // classificationGraph1
            // 
            this.classificationGraph1.AutoSize = true;
            this.classificationGraph1.Location = new System.Drawing.Point(548, 13);
            this.classificationGraph1.Name = "classificationGraph1";
            this.classificationGraph1.Size = new System.Drawing.Size(352, 201);
            this.classificationGraph1.TabIndex = 5;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(548, 220);
            this.delaySlider1.Maximum = 2500;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 6;
            this.delaySlider1.Value = 1250;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 490);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.classificationGraph1);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.exitButton);
            this.Name = "Form1";
            this.Text = "Classification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button exitButton;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.ClassificationGraph classificationGraph1;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

