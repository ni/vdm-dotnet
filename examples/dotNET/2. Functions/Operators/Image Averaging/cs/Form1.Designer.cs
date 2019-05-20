namespace ImageAveraging
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
            this.filenameLabel = new System.Windows.Forms.Label();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.averageButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(10, 21);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(443, 225);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer1_ImagePanned);
            this.imageViewer1.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer1_ImageZoomed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Image:";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(82, 5);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(68, 13);
            this.filenameLabel.TabIndex = 2;
            this.filenameLabel.Text = "noise-00.png";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(10, 278);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(443, 225);
            this.imageViewer2.TabIndex = 0;
            this.imageViewer2.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer2_ImagePanned);
            this.imageViewer2.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer2_ImageZoomed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Averaged Image:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(459, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 45);
            this.label4.TabIndex = 3;
            this.label4.Text = "1. Click the Load Next Image button several times to load the noisy images.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(459, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "2. Average the images.";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(462, 115);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(124, 31);
            this.loadImageButton.TabIndex = 4;
            this.loadImageButton.Text = "Load Next Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // averageButton
            // 
            this.averageButton.Location = new System.Drawing.Point(462, 152);
            this.averageButton.Name = "averageButton";
            this.averageButton.Size = new System.Drawing.Size(124, 31);
            this.averageButton.TabIndex = 4;
            this.averageButton.Text = "Average Images";
            this.averageButton.UseVisualStyleBackColor = true;
            this.averageButton.Click += new System.EventHandler(this.averageButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(462, 189);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(124, 31);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 511);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.averageButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Image Averaging Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label filenameLabel;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button averageButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Timer timer1;
    }
}

