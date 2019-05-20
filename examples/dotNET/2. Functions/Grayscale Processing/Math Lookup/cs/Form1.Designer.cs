namespace MathLookup
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
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.operatorBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(500, 267);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer1_ImagePanned);
            this.imageViewer1.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer1_ImageZoomed);
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(12, 285);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(500, 267);
            this.imageViewer2.TabIndex = 0;
            this.imageViewer2.ImagePanned += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs>(this.imageViewer2_ImagePanned);
            this.imageViewer2.ImageZoomed += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs>(this.imageViewer2_ImageZoomed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(76, 554);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(403, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(485, 555);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(27, 19);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.xValueUpDown);
            this.groupBox1.Controls.Add(this.xValueLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.operatorBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 580);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "(for Power X and Power 1/X only)";
            // 
            // xValueUpDown
            // 
            this.xValueUpDown.DecimalPlaces = 1;
            this.xValueUpDown.Enabled = false;
            this.xValueUpDown.Location = new System.Drawing.Point(67, 46);
            this.xValueUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xValueUpDown.Name = "xValueUpDown";
            this.xValueUpDown.Size = new System.Drawing.Size(39, 20);
            this.xValueUpDown.TabIndex = 3;
            this.xValueUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.xValueUpDown.ValueChanged += new System.EventHandler(this.xValueUpDown_ValueChanged);
            // 
            // xValueLabel
            // 
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Location = new System.Drawing.Point(14, 48);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(44, 13);
            this.xValueLabel.TabIndex = 2;
            this.xValueLabel.Text = "X Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operator";
            // 
            // operatorBox
            // 
            this.operatorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorBox.FormattingEnabled = true;
            this.operatorBox.Items.AddRange(new object[] {
            "Linear",
            "Log",
            "Exponential",
            "Square",
            "Square Root",
            "Power X",
            "Power 1/X"});
            this.operatorBox.Location = new System.Drawing.Point(67, 19);
            this.operatorBox.Name = "operatorBox";
            this.operatorBox.Size = new System.Drawing.Size(103, 21);
            this.operatorBox.TabIndex = 0;
            this.operatorBox.SelectedIndexChanged += new System.EventHandler(this.operatorBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 579);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Instructions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 597);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "1. Load an image file.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(200, 613);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 28);
            this.label7.TabIndex = 5;
            this.label7.Text = "2. Modify the mathematical operator and the exponent of the power function (X Val" +
                "ue).";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(453, 649);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(66, 25);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(371, 649);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(76, 25);
            this.loadImageButton.TabIndex = 6;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 679);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Math Lookup Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValueUpDown)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox operatorBox;
        private System.Windows.Forms.NumericUpDown xValueUpDown;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button loadImageButton;
    }
}

