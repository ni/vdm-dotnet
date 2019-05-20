namespace AVI_Read_Write_With_Data_Example
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.curTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aviSampleDataGraph1 = new NationalInstruments.Vision.MeasurementStudioDemo.AviSampleDataGraph();
            this.genericSlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Waveform Graph";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(34, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time";
            // 
            // curTime
            // 
            this.curTime.Location = new System.Drawing.Point(37, 295);
            this.curTime.MaxLength = 0;
            this.curTime.Name = "curTime";
            this.curTime.Size = new System.Drawing.Size(135, 20);
            this.curTime.TabIndex = 5;
            this.curTime.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Frame to Examine";
            // 
            // aviSampleDataGraph1
            // 
            this.aviSampleDataGraph1.AutoSize = true;
            this.aviSampleDataGraph1.CursorValue = 5;
            this.aviSampleDataGraph1.Location = new System.Drawing.Point(37, 21);
            this.aviSampleDataGraph1.Name = "aviSampleDataGraph1";
            this.aviSampleDataGraph1.Size = new System.Drawing.Size(405, 236);
            this.aviSampleDataGraph1.TabIndex = 9;
            this.aviSampleDataGraph1.AfterCursorMove += new System.EventHandler<System.EventArgs>(this.aviSampleDataGraph1_AfterCursorMove);
            // 
            // genericSlider1
            // 
            this.genericSlider1.AutoSize = true;
            this.genericSlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.genericSlider1.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.genericSlider1.Enabled = false;
            this.genericSlider1.Location = new System.Drawing.Point(192, 276);
            this.genericSlider1.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.AviFrame;
            this.genericSlider1.Name = "genericSlider1";
            this.genericSlider1.Size = new System.Drawing.Size(203, 53);
            this.genericSlider1.TabIndex = 10;
            this.genericSlider1.Value = 0;
            this.genericSlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.genericSlider1_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(386, 290);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 363);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.genericSlider1);
            this.Controls.Add(this.aviSampleDataGraph1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.curTime);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(620, 30);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frame Data";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox curTime;
        private System.Windows.Forms.Label label3;
        private NationalInstruments.Vision.MeasurementStudioDemo.AviSampleDataGraph aviSampleDataGraph1;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider genericSlider1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}