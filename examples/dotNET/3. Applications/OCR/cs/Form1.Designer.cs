namespace OCR
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
            this.startReadingButton = new System.Windows.Forms.Button();
            this.pauseReadingButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.delay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.readTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(19, 7);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(298, 288);
            this.imageViewer1.TabIndex = 0;
            // 
            // startReadingButton
            // 
            this.startReadingButton.Location = new System.Drawing.Point(19, 301);
            this.startReadingButton.Name = "startReadingButton";
            this.startReadingButton.Size = new System.Drawing.Size(92, 36);
            this.startReadingButton.TabIndex = 1;
            this.startReadingButton.Text = "Start Reading";
            this.startReadingButton.UseVisualStyleBackColor = true;
            this.startReadingButton.Click += new System.EventHandler(this.startReadingButton_Click);
            // 
            // pauseReadingButton
            // 
            this.pauseReadingButton.Location = new System.Drawing.Point(19, 345);
            this.pauseReadingButton.Name = "pauseReadingButton";
            this.pauseReadingButton.Size = new System.Drawing.Size(92, 36);
            this.pauseReadingButton.TabIndex = 2;
            this.pauseReadingButton.Text = "Pause Reading";
            this.pauseReadingButton.UseVisualStyleBackColor = true;
            this.pauseReadingButton.Click += new System.EventHandler(this.pauseReadingButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(21, 389);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(89, 32);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // delay
            // 
            this.delay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.delay.Location = new System.Drawing.Point(191, 317);
            this.delay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(54, 20);
            this.delay.TabIndex = 4;
            this.delay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.delay.ValueChanged += new System.EventHandler(this.delay_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Delay (ms)";
            // 
            // readTextBox
            // 
            this.readTextBox.Location = new System.Drawing.Point(122, 306);
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.Size = new System.Drawing.Size(59, 20);
            this.readTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 424);
            this.Controls.Add(this.readTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.pauseReadingButton);
            this.Controls.Add(this.startReadingButton);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "OCR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Button startReadingButton;
        private System.Windows.Forms.Button pauseReadingButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown delay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox readTextBox;
    }
}

