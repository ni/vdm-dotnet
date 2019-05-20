namespace MagicWand
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
            NationalInstruments.Vision.WindowsForms.Palette palette1 = new NationalInstruments.Vision.WindowsForms.Palette();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toleranceUpDown = new System.Windows.Forms.NumericUpDown();
            this.connectivity4Button = new System.Windows.Forms.RadioButton();
            this.connectivity8Button = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.ContextSensitiveTools = false;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(533, 297);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer1_ImagePanned);
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            this.imageViewer1.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer1_ImageZoomed);
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(12, 326);
            this.imageViewer2.Name = "imageViewer2";
            palette1.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
            this.imageViewer2.Palette = palette1;
            this.imageViewer2.Size = new System.Drawing.Size(533, 297);
            this.imageViewer2.TabIndex = 0;
            this.imageViewer2.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer2_ImagePanned);
            this.imageViewer2.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer2_ImageZoomed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 631);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(79, 628);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(430, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(517, 628);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 20);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.toleranceUpDown);
            this.groupBox1.Controls.Add(this.connectivity4Button);
            this.groupBox1.Controls.Add(this.connectivity8Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 659);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tolerance";
            // 
            // toleranceUpDown
            // 
            this.toleranceUpDown.Location = new System.Drawing.Point(11, 52);
            this.toleranceUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.toleranceUpDown.Name = "toleranceUpDown";
            this.toleranceUpDown.Size = new System.Drawing.Size(50, 20);
            this.toleranceUpDown.TabIndex = 1;
            this.toleranceUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // connectivity4Button
            // 
            this.connectivity4Button.AutoSize = true;
            this.connectivity4Button.Checked = true;
            this.connectivity4Button.Location = new System.Drawing.Point(11, 31);
            this.connectivity4Button.Name = "connectivity4Button";
            this.connectivity4Button.Size = new System.Drawing.Size(92, 17);
            this.connectivity4Button.TabIndex = 0;
            this.connectivity4Button.TabStop = true;
            this.connectivity4Button.Text = "4-Connectivity";
            this.connectivity4Button.UseVisualStyleBackColor = true;
            // 
            // connectivity8Button
            // 
            this.connectivity8Button.AutoSize = true;
            this.connectivity8Button.Location = new System.Drawing.Point(11, 15);
            this.connectivity8Button.Name = "connectivity8Button";
            this.connectivity8Button.Size = new System.Drawing.Size(92, 17);
            this.connectivity8Button.TabIndex = 0;
            this.connectivity8Button.Text = "8-Connectivity";
            this.connectivity8Button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "1. Load an image file.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 687);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "2. Click on the object you want to segment.";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(482, 706);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(63, 29);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(404, 706);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(72, 29);
            this.loadImageButton.TabIndex = 6;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 743);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Magic Wand Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton connectivity4Button;
        private System.Windows.Forms.RadioButton connectivity8Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown toleranceUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button loadImageButton;
    }
}

