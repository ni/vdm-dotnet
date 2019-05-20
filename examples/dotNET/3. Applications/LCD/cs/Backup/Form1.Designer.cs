namespace LCD
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
            this.number = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.segments1 = new NationalInstruments.Vision.MeasurementStudioDemo.Segments();
            this.segments2 = new NationalInstruments.Vision.MeasurementStudioDemo.Segments();
            this.segments3 = new NationalInstruments.Vision.MeasurementStudioDemo.Segments();
            this.segments4 = new NationalInstruments.Vision.MeasurementStudioDemo.Segments();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(262, 226);
            this.imageViewer1.TabIndex = 0;
            // 
            // number
            // 
            this.number.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.Location = new System.Drawing.Point(292, 139);
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Size = new System.Drawing.Size(170, 31);
            this.number.TabIndex = 2;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(209, 261);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(64, 30);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // segments1
            // 
            this.segments1.AutoSize = true;
            this.segments1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.segments1.Location = new System.Drawing.Point(292, 12);
            this.segments1.Name = "segments1";
            this.segments1.Size = new System.Drawing.Size(63, 121);
            this.segments1.TabIndex = 5;
            // 
            // segments2
            // 
            this.segments2.AutoSize = true;
            this.segments2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.segments2.Location = new System.Drawing.Point(361, 12);
            this.segments2.Name = "segments2";
            this.segments2.Size = new System.Drawing.Size(63, 121);
            this.segments2.TabIndex = 5;
            // 
            // segments3
            // 
            this.segments3.AutoSize = true;
            this.segments3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.segments3.Location = new System.Drawing.Point(430, 12);
            this.segments3.Name = "segments3";
            this.segments3.Size = new System.Drawing.Size(63, 121);
            this.segments3.TabIndex = 5;
            // 
            // segments4
            // 
            this.segments4.AutoSize = true;
            this.segments4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.segments4.Location = new System.Drawing.Point(499, 12);
            this.segments4.Name = "segments4";
            this.segments4.Size = new System.Drawing.Size(63, 121);
            this.segments4.TabIndex = 5;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(292, 176);
            this.delaySlider1.Maximum = 1500;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 6;
            this.delaySlider1.Value = 750;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 319);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.segments4);
            this.Controls.Add(this.segments3);
            this.Controls.Add(this.segments2);
            this.Controls.Add(this.segments1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.number);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "LCD Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.Segments segments1;
        private NationalInstruments.Vision.MeasurementStudioDemo.Segments segments2;
        private NationalInstruments.Vision.MeasurementStudioDemo.Segments segments3;
        private NationalInstruments.Vision.MeasurementStudioDemo.Segments segments4;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

