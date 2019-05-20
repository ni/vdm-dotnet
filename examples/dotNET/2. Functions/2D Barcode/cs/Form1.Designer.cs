namespace _D_Barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.barcodeType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.readTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataFound = new System.Windows.Forms.TextBox();
            this.typeFound = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.useOptionsBox = new System.Windows.Forms.CheckBox();
            this.gradeDMBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gradeUnusedErrorCorrection = new System.Windows.Forms.TextBox();
            this.gradeAxialNonuniformity = new System.Windows.Forms.TextBox();
            this.gradePrintGrowth = new System.Windows.Forms.TextBox();
            this.gradeSymbolContrast = new System.Windows.Forms.TextBox();
            this.gradeDecoding = new System.Windows.Forms.TextBox();
            this.gradeOverall = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(391, 46);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(407, 390);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image";
            // 
            // barcodeType
            // 
            this.barcodeType.FormattingEnabled = true;
            this.barcodeType.Location = new System.Drawing.Point(12, 46);
            this.barcodeType.Name = "barcodeType";
            this.barcodeType.Size = new System.Drawing.Size(119, 56);
            this.barcodeType.TabIndex = 2;
            this.barcodeType.SelectedIndexChanged += new System.EventHandler(this.barcodeType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Barcode Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.readTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataFound);
            this.groupBox1.Controls.Add(this.typeFound);
            this.groupBox1.Location = new System.Drawing.Point(12, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 235);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Read Time (ms)";
            // 
            // readTime
            // 
            this.readTime.Location = new System.Drawing.Point(5, 206);
            this.readTime.Name = "readTime";
            this.readTime.Size = new System.Drawing.Size(57, 20);
            this.readTime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // dataFound
            // 
            this.dataFound.Location = new System.Drawing.Point(5, 83);
            this.dataFound.Multiline = true;
            this.dataFound.Name = "dataFound";
            this.dataFound.Size = new System.Drawing.Size(131, 96);
            this.dataFound.TabIndex = 1;
            // 
            // typeFound
            // 
            this.typeFound.Location = new System.Drawing.Point(5, 37);
            this.typeFound.Name = "typeFound";
            this.typeFound.Size = new System.Drawing.Size(131, 20);
            this.typeFound.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 429);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(71, 37);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(92, 429);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(71, 37);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(192, 429);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(71, 37);
            this.quitButton.TabIndex = 8;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // useOptionsBox
            // 
            this.useOptionsBox.AutoSize = true;
            this.useOptionsBox.Location = new System.Drawing.Point(163, 46);
            this.useOptionsBox.Name = "useOptionsBox";
            this.useOptionsBox.Size = new System.Drawing.Size(143, 17);
            this.useOptionsBox.TabIndex = 10;
            this.useOptionsBox.Text = "Use Options (if available)";
            this.useOptionsBox.UseVisualStyleBackColor = true;
            // 
            // gradeDMBox
            // 
            this.gradeDMBox.AutoSize = true;
            this.gradeDMBox.Location = new System.Drawing.Point(163, 69);
            this.gradeDMBox.Name = "gradeDMBox";
            this.gradeDMBox.Size = new System.Drawing.Size(139, 17);
            this.gradeDMBox.TabIndex = 11;
            this.gradeDMBox.Text = "Grade Data Matrix code";
            this.gradeDMBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.gradeUnusedErrorCorrection);
            this.groupBox2.Controls.Add(this.gradeAxialNonuniformity);
            this.groupBox2.Controls.Add(this.gradePrintGrowth);
            this.groupBox2.Controls.Add(this.gradeSymbolContrast);
            this.groupBox2.Controls.Add(this.gradeDecoding);
            this.groupBox2.Controls.Add(this.gradeOverall);
            this.groupBox2.Location = new System.Drawing.Point(164, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 179);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AIM Grading Report";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Unused Error Correction Grade";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(35, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Axial Nonuniformity Grade";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(35, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Print Growth Grade";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(35, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Symbol Contrast Grade";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(35, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Decoding Grade";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(33, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Overall Grade";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradeUnusedErrorCorrection
            // 
            this.gradeUnusedErrorCorrection.Location = new System.Drawing.Point(171, 148);
            this.gradeUnusedErrorCorrection.Name = "gradeUnusedErrorCorrection";
            this.gradeUnusedErrorCorrection.Size = new System.Drawing.Size(41, 20);
            this.gradeUnusedErrorCorrection.TabIndex = 5;
            // 
            // gradeAxialNonuniformity
            // 
            this.gradeAxialNonuniformity.Location = new System.Drawing.Point(171, 122);
            this.gradeAxialNonuniformity.Name = "gradeAxialNonuniformity";
            this.gradeAxialNonuniformity.Size = new System.Drawing.Size(41, 20);
            this.gradeAxialNonuniformity.TabIndex = 4;
            // 
            // gradePrintGrowth
            // 
            this.gradePrintGrowth.Location = new System.Drawing.Point(171, 96);
            this.gradePrintGrowth.Name = "gradePrintGrowth";
            this.gradePrintGrowth.Size = new System.Drawing.Size(41, 20);
            this.gradePrintGrowth.TabIndex = 3;
            // 
            // gradeSymbolContrast
            // 
            this.gradeSymbolContrast.Location = new System.Drawing.Point(171, 70);
            this.gradeSymbolContrast.Name = "gradeSymbolContrast";
            this.gradeSymbolContrast.Size = new System.Drawing.Size(41, 20);
            this.gradeSymbolContrast.TabIndex = 2;
            // 
            // gradeDecoding
            // 
            this.gradeDecoding.Location = new System.Drawing.Point(171, 44);
            this.gradeDecoding.Name = "gradeDecoding";
            this.gradeDecoding.Size = new System.Drawing.Size(41, 20);
            this.gradeDecoding.TabIndex = 1;
            // 
            // gradeOverall
            // 
            this.gradeOverall.Location = new System.Drawing.Point(171, 18);
            this.gradeOverall.Name = "gradeOverall";
            this.gradeOverall.Size = new System.Drawing.Size(41, 20);
            this.gradeOverall.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(137, 89);
            this.delaySlider1.Maximum = 1000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 14;
            this.delaySlider1.Value = 500;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_AfterChangeValue);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 475);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gradeDMBox);
            this.Controls.Add(this.useOptionsBox);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.barcodeType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "2D Barcode";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox barcodeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dataFound;
        private System.Windows.Forms.TextBox typeFound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox readTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.CheckBox useOptionsBox;
        private System.Windows.Forms.CheckBox gradeDMBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox gradeUnusedErrorCorrection;
        private System.Windows.Forms.TextBox gradeAxialNonuniformity;
        private System.Windows.Forms.TextBox gradePrintGrowth;
        private System.Windows.Forms.TextBox gradeSymbolContrast;
        private System.Windows.Forms.TextBox gradeDecoding;
        private System.Windows.Forms.TextBox gradeOverall;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

