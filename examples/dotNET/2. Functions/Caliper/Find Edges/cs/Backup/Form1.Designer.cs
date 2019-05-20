namespace FindEdges
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
            this.browseButton = new System.Windows.Forms.Button();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.minimumCoverage = new System.Windows.Forms.NumericUpDown();
            this.minimumSignalToNoiseRatio = new System.Windows.Forms.NumericUpDown();
            this.orientation = new System.Windows.Forms.NumericUpDown();
            this.angleRange = new System.Windows.Forms.NumericUpDown();
            this.angleTolerance = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.houghIterations = new System.Windows.Forms.NumericUpDown();
            this.stepSize = new System.Windows.Forms.NumericUpDown();
            this.maximumScore = new System.Windows.Forms.NumericUpDown();
            this.minimumScore = new System.Windows.Forms.NumericUpDown();
            this.numberOfLines = new System.Windows.Forms.NumericUpDown();
            this.searchDirection = new System.Windows.Forms.ComboBox();
            this.searchMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSignalToNoiseRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orientation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.houghIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.RotatedRectangle;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShowToolbar = true;
            this.imageViewer1.Size = new System.Drawing.Size(380, 354);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(366, 372);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(26, 20);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(78, 372);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(282, 20);
            this.imagePath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Path";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(413, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 137);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edge Options";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.minimumCoverage);
            this.groupBox2.Controls.Add(this.minimumSignalToNoiseRatio);
            this.groupBox2.Controls.Add(this.orientation);
            this.groupBox2.Controls.Add(this.angleRange);
            this.groupBox2.Controls.Add(this.angleTolerance);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.houghIterations);
            this.groupBox2.Controls.Add(this.stepSize);
            this.groupBox2.Controls.Add(this.maximumScore);
            this.groupBox2.Controls.Add(this.minimumScore);
            this.groupBox2.Controls.Add(this.numberOfLines);
            this.groupBox2.Controls.Add(this.searchDirection);
            this.groupBox2.Controls.Add(this.searchMode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(413, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 211);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Straight Edge Options";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(133, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 18;
            this.label15.Text = "Min Cover";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(133, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 17;
            this.label16.Text = "Min SNR";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(133, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 16;
            this.label17.Text = "Orientation";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(133, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 15;
            this.label18.Text = "Angle Range";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(133, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 16);
            this.label19.TabIndex = 14;
            this.label19.Text = "Angle Inc";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // minimumCoverage
            // 
            this.minimumCoverage.Location = new System.Drawing.Point(219, 172);
            this.minimumCoverage.Name = "minimumCoverage";
            this.minimumCoverage.Size = new System.Drawing.Size(52, 20);
            this.minimumCoverage.TabIndex = 10;
            this.minimumCoverage.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // minimumSignalToNoiseRatio
            // 
            this.minimumSignalToNoiseRatio.Location = new System.Drawing.Point(219, 146);
            this.minimumSignalToNoiseRatio.Name = "minimumSignalToNoiseRatio";
            this.minimumSignalToNoiseRatio.Size = new System.Drawing.Size(52, 20);
            this.minimumSignalToNoiseRatio.TabIndex = 9;
            // 
            // orientation
            // 
            this.orientation.Location = new System.Drawing.Point(219, 120);
            this.orientation.Name = "orientation";
            this.orientation.Size = new System.Drawing.Size(52, 20);
            this.orientation.TabIndex = 11;
            // 
            // angleRange
            // 
            this.angleRange.Location = new System.Drawing.Point(219, 94);
            this.angleRange.Name = "angleRange";
            this.angleRange.Size = new System.Drawing.Size(52, 20);
            this.angleRange.TabIndex = 13;
            this.angleRange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // angleTolerance
            // 
            this.angleTolerance.Location = new System.Drawing.Point(219, 68);
            this.angleTolerance.Name = "angleTolerance";
            this.angleTolerance.Size = new System.Drawing.Size(53, 20);
            this.angleTolerance.TabIndex = 12;
            this.angleTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-10, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "Hough Iter.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-10, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Step Size";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-10, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Max Score";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-10, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Min Score";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-10, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Num. Lines";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // houghIterations
            // 
            this.houghIterations.Location = new System.Drawing.Point(76, 172);
            this.houghIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.houghIterations.Name = "houghIterations";
            this.houghIterations.Size = new System.Drawing.Size(52, 20);
            this.houghIterations.TabIndex = 3;
            this.houghIterations.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // stepSize
            // 
            this.stepSize.Location = new System.Drawing.Point(76, 146);
            this.stepSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.stepSize.Name = "stepSize";
            this.stepSize.Size = new System.Drawing.Size(52, 20);
            this.stepSize.TabIndex = 3;
            this.stepSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // maximumScore
            // 
            this.maximumScore.Location = new System.Drawing.Point(76, 120);
            this.maximumScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximumScore.Name = "maximumScore";
            this.maximumScore.Size = new System.Drawing.Size(52, 20);
            this.maximumScore.TabIndex = 3;
            this.maximumScore.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // minimumScore
            // 
            this.minimumScore.Location = new System.Drawing.Point(76, 94);
            this.minimumScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minimumScore.Name = "minimumScore";
            this.minimumScore.Size = new System.Drawing.Size(52, 20);
            this.minimumScore.TabIndex = 3;
            this.minimumScore.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numberOfLines
            // 
            this.numberOfLines.Location = new System.Drawing.Point(76, 68);
            this.numberOfLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfLines.Name = "numberOfLines";
            this.numberOfLines.Size = new System.Drawing.Size(53, 20);
            this.numberOfLines.TabIndex = 3;
            this.numberOfLines.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // searchDirection
            // 
            this.searchDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchDirection.FormattingEnabled = true;
            this.searchDirection.Items.AddRange(new object[] {
            "LeftToRight",
            "RightToLeft",
            "BottomToTop",
            "TopToBottom"});
            this.searchDirection.Location = new System.Drawing.Point(149, 34);
            this.searchDirection.Name = "searchDirection";
            this.searchDirection.Size = new System.Drawing.Size(122, 21);
            this.searchDirection.TabIndex = 2;
            // 
            // searchMode
            // 
            this.searchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchMode.FormattingEnabled = true;
            this.searchMode.Items.AddRange(new object[] {
            "FirstRakeEdges",
            "BestRakeEdges",
            "BestHoughLine",
            "FirstProjectionEdge",
            "BestProjectionEdge"});
            this.searchMode.Location = new System.Drawing.Point(8, 34);
            this.searchMode.Name = "searchMode";
            this.searchMode.Size = new System.Drawing.Size(121, 21);
            this.searchMode.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Search Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search Mode";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(410, 405);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(289, 35);
            this.label20.TabIndex = 12;
            this.label20.Text = "2. Draw an ROI in the image. The example overlays detected straight edges on the " +
                "image.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(410, 390);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "1. Load an image and display it.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(410, 372);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "Instructions:";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(627, 445);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(71, 37);
            this.quitButton.TabIndex = 10;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(550, 445);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(71, 37);
            this.loadImageButton.TabIndex = 11;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 494);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Find Edges Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSignalToNoiseRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orientation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.houghIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox smoothing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox interpolationMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox polarity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown minimumThreshold;
        private System.Windows.Forms.NumericUpDown kernelSize;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox searchDirection;
        private System.Windows.Forms.ComboBox searchMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown houghIterations;
        private System.Windows.Forms.NumericUpDown stepSize;
        private System.Windows.Forms.NumericUpDown maximumScore;
        private System.Windows.Forms.NumericUpDown minimumScore;
        private System.Windows.Forms.NumericUpDown numberOfLines;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown minimumCoverage;
        private System.Windows.Forms.NumericUpDown minimumSignalToNoiseRatio;
        private System.Windows.Forms.NumericUpDown orientation;
        private System.Windows.Forms.NumericUpDown angleRange;
        private System.Windows.Forms.NumericUpDown angleTolerance;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button loadImageButton;
    }
}

