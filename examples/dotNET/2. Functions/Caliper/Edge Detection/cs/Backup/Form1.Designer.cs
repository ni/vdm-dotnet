namespace EdgeDetection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.process = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.smoothing = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.interpolationMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.polarity = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.minimumThreshold = new System.Windows.Forms.NumericUpDown();
            this.kernelSize = new System.Windows.Forms.NumericUpDown();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.edgeDetectionGraph1 = new NationalInstruments.Vision.MeasurementStudioDemo.EdgeDetectionGraph();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Line;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(394, 329);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(78, 355);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(295, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(380, 355);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(26, 20);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.process);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.smoothing);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.interpolationMethod);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.polarity);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.minimumThreshold);
            this.groupBox1.Controls.Add(this.kernelSize);
            this.groupBox1.Controls.Add(this.width);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(417, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 171);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edge Options";
            // 
            // process
            // 
            this.process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.process.FormattingEnabled = true;
            this.process.Items.AddRange(new object[] {
            "First",
            "FirstAndLast",
            "All",
            "Best"});
            this.process.Location = new System.Drawing.Point(151, 144);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(122, 21);
            this.process.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Process";
            // 
            // smoothing
            // 
            this.smoothing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothing.FormattingEnabled = true;
            this.smoothing.Items.AddRange(new object[] {
            "Average",
            "Median"});
            this.smoothing.Location = new System.Drawing.Point(151, 104);
            this.smoothing.Name = "smoothing";
            this.smoothing.Size = new System.Drawing.Size(122, 21);
            this.smoothing.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Smoothing";
            // 
            // interpolationMethod
            // 
            this.interpolationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationMethod.FormattingEnabled = true;
            this.interpolationMethod.Items.AddRange(new object[] {
            "ZeroOrder",
            "Bilinear",
            "BilinearFixed"});
            this.interpolationMethod.Location = new System.Drawing.Point(151, 66);
            this.interpolationMethod.Name = "interpolationMethod";
            this.interpolationMethod.Size = new System.Drawing.Size(122, 21);
            this.interpolationMethod.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Interpolation Method";
            // 
            // polarity
            // 
            this.polarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.polarity.FormattingEnabled = true;
            this.polarity.Items.AddRange(new object[] {
            "All",
            "Rising ",
            "Falling"});
            this.polarity.Location = new System.Drawing.Point(151, 27);
            this.polarity.Name = "polarity";
            this.polarity.Size = new System.Drawing.Size(122, 21);
            this.polarity.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Polarity";
            // 
            // minimumThreshold
            // 
            this.minimumThreshold.Location = new System.Drawing.Point(89, 65);
            this.minimumThreshold.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.minimumThreshold.Name = "minimumThreshold";
            this.minimumThreshold.Size = new System.Drawing.Size(41, 20);
            this.minimumThreshold.TabIndex = 1;
            this.minimumThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // kernelSize
            // 
            this.kernelSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.kernelSize.Location = new System.Drawing.Point(89, 42);
            this.kernelSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.kernelSize.Name = "kernelSize";
            this.kernelSize.Size = new System.Drawing.Size(41, 20);
            this.kernelSize.TabIndex = 1;
            this.kernelSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(89, 19);
            this.width.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(41, 20);
            this.width.TabIndex = 1;
            this.width.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Min Threshold:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kernel Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(555, 416);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(71, 37);
            this.loadImageButton.TabIndex = 7;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(632, 416);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(71, 37);
            this.quitButton.TabIndex = 7;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(414, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Instructions:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(414, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "1. Load an image and display it.";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(414, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(289, 36);
            this.label12.TabIndex = 8;
            this.label12.Text = "2. Draw a line in the image. The example overlays the detected edge on the image." +
                "";
            // 
            // edgeDetectionGraph1
            // 
            this.edgeDetectionGraph1.AutoSize = true;
            this.edgeDetectionGraph1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.edgeDetectionGraph1.Location = new System.Drawing.Point(417, 12);
            this.edgeDetectionGraph1.Name = "edgeDetectionGraph1";
            this.edgeDetectionGraph1.Size = new System.Drawing.Size(290, 144);
            this.edgeDetectionGraph1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 465);
            this.Controls.Add(this.edgeDetectionGraph1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Edge Detection Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown kernelSize;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minimumThreshold;
        private System.Windows.Forms.ComboBox interpolationMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox polarity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox process;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox smoothing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private NationalInstruments.Vision.MeasurementStudioDemo.EdgeDetectionGraph edgeDetectionGraph1;
    }
}

