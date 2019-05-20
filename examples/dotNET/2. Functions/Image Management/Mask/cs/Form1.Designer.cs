namespace Mask
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
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceImagePath = new System.Windows.Forms.TextBox();
            this.maskImagePath = new System.Windows.Forms.TextBox();
            this.sourceBrowseButton = new System.Windows.Forms.Button();
            this.maskImageButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.imageViewerMask = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.loadImagesButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(10, 8);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShowToolbar = true;
            this.imageViewer1.Size = new System.Drawing.Size(249, 270);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(265, 8);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.ShowToolbar = true;
            this.imageViewer2.Size = new System.Drawing.Size(249, 270);
            this.imageViewer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Image Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mask Image Path";
            // 
            // sourceImagePath
            // 
            this.sourceImagePath.Location = new System.Drawing.Point(110, 289);
            this.sourceImagePath.Name = "sourceImagePath";
            this.sourceImagePath.Size = new System.Drawing.Size(368, 20);
            this.sourceImagePath.TabIndex = 2;
            // 
            // maskImagePath
            // 
            this.maskImagePath.Location = new System.Drawing.Point(110, 313);
            this.maskImagePath.Name = "maskImagePath";
            this.maskImagePath.Size = new System.Drawing.Size(368, 20);
            this.maskImagePath.TabIndex = 2;
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Location = new System.Drawing.Point(484, 290);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(30, 19);
            this.sourceBrowseButton.TabIndex = 3;
            this.sourceBrowseButton.Text = "...";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            this.sourceBrowseButton.Click += new System.EventHandler(this.sourceBrowseButton_Click);
            // 
            // maskImageButton
            // 
            this.maskImageButton.Location = new System.Drawing.Point(484, 313);
            this.maskImageButton.Name = "maskImageButton";
            this.maskImageButton.Size = new System.Drawing.Size(30, 19);
            this.maskImageButton.TabIndex = 3;
            this.maskImageButton.Text = "...";
            this.maskImageButton.UseVisualStyleBackColor = true;
            this.maskImageButton.Click += new System.EventHandler(this.maskImageButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mask Image";
            // 
            // imageViewerMask
            // 
            this.imageViewerMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerMask.Location = new System.Drawing.Point(10, 376);
            this.imageViewerMask.Name = "imageViewerMask";
            this.imageViewerMask.Size = new System.Drawing.Size(93, 86);
            this.imageViewerMask.TabIndex = 5;
            // 
            // loadImagesButton
            // 
            this.loadImagesButton.Location = new System.Drawing.Point(425, 390);
            this.loadImagesButton.Name = "loadImagesButton";
            this.loadImagesButton.Size = new System.Drawing.Size(88, 33);
            this.loadImagesButton.TabIndex = 6;
            this.loadImagesButton.Text = "Load Images";
            this.loadImagesButton.UseVisualStyleBackColor = true;
            this.loadImagesButton.Click += new System.EventHandler(this.loadImagesButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(425, 429);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(88, 33);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instructions:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "1. Load the image files.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(138, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 27);
            this.label6.TabIndex = 7;
            this.label6.Text = "2. Click a point in viewer 1 to view the masked image in viewer 2.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 474);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loadImagesButton);
            this.Controls.Add(this.imageViewerMask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskImageButton);
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.maskImagePath);
            this.Controls.Add(this.sourceImagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Mask Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceImagePath;
        private System.Windows.Forms.TextBox maskImagePath;
        private System.Windows.Forms.Button sourceBrowseButton;
        private System.Windows.Forms.Button maskImageButton;
        private System.Windows.Forms.Label label3;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewerMask;
        private System.Windows.Forms.Button loadImagesButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

