namespace CircleDistance
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
            this.label1 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.minimumHeywood = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.processImageButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minimumHeywood)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(474, 325);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(12, 360);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(445, 42);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(461, 359);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(24, 20);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimum Heywood";
            // 
            // minimumHeywood
            // 
            this.minimumHeywood.DecimalPlaces = 2;
            this.minimumHeywood.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.minimumHeywood.Location = new System.Drawing.Point(113, 406);
            this.minimumHeywood.Name = "minimumHeywood";
            this.minimumHeywood.Size = new System.Drawing.Size(48, 20);
            this.minimumHeywood.TabIndex = 5;
            this.minimumHeywood.Value = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.minimumHeywood.ValueChanged += new System.EventHandler(this.minimumHeywood_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(The closer to 1, the more circular)";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(398, 410);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(86, 28);
            this.loadImageButton.TabIndex = 7;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // processImageButton
            // 
            this.processImageButton.Enabled = false;
            this.processImageButton.Location = new System.Drawing.Point(398, 444);
            this.processImageButton.Name = "processImageButton";
            this.processImageButton.Size = new System.Drawing.Size(86, 28);
            this.processImageButton.TabIndex = 7;
            this.processImageButton.Text = "Process Image";
            this.processImageButton.UseVisualStyleBackColor = true;
            this.processImageButton.Click += new System.EventHandler(this.processImageButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(398, 478);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(86, 28);
            this.quitButton.TabIndex = 7;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(381, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "This example loads an image file, displays it, and performs the following process" +
                "es:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 461);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "- Automatically thresholds the image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "- Detects parts";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "- Extracts shape descriptors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 509);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "- Keeps circular parts using the Heywood circularity factor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 525);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(267, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "- Computes and draws distances between circular parts";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 548);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.processImageButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minimumHeywood);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Circle Distance Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minimumHeywood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minimumHeywood;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button processImageButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

