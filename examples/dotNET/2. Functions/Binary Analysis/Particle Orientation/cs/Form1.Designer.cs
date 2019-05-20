namespace ParticleOrientation
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
            this.loadButton = new System.Windows.Forms.Button();
            this.measureButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(15, 10);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(420, 305);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(78, 325);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(320, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(404, 325);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(31, 19);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(15, 360);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(71, 35);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // measureButton
            // 
            this.measureButton.Location = new System.Drawing.Point(15, 401);
            this.measureButton.Name = "measureButton";
            this.measureButton.Size = new System.Drawing.Size(71, 35);
            this.measureButton.TabIndex = 4;
            this.measureButton.Text = "Measure Orientation";
            this.measureButton.UseVisualStyleBackColor = true;
            this.measureButton.Click += new System.EventHandler(this.measureButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(364, 401);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(71, 35);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(101, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Instructions:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(101, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "1. Load an image file.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(101, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "2. Measure the particle orientation.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 444);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.measureButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Particle Orientation Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button measureButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

