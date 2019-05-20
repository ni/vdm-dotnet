namespace UnwrapBarcode
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
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confidenceLevel = new System.Windows.Forms.TextBox();
            this.barcodeString = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.unwrapBarcodeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 25);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(501, 256);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original Image";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(12, 305);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(501, 74);
            this.imageViewer2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unwrapped Image";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.confidenceLevel);
            this.groupBox1.Controls.Add(this.barcodeString);
            this.groupBox1.Location = new System.Drawing.Point(12, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Confidence Level:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Barcode String:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // confidenceLevel
            // 
            this.confidenceLevel.Location = new System.Drawing.Point(108, 44);
            this.confidenceLevel.Name = "confidenceLevel";
            this.confidenceLevel.ReadOnly = true;
            this.confidenceLevel.Size = new System.Drawing.Size(60, 20);
            this.confidenceLevel.TabIndex = 0;
            // 
            // barcodeString
            // 
            this.barcodeString.Location = new System.Drawing.Point(108, 18);
            this.barcodeString.Name = "barcodeString";
            this.barcodeString.ReadOnly = true;
            this.barcodeString.Size = new System.Drawing.Size(60, 20);
            this.barcodeString.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(456, 435);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(57, 30);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(355, 397);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(96, 30);
            this.loadImageButton.TabIndex = 5;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // unwrapBarcodeButton
            // 
            this.unwrapBarcodeButton.Enabled = false;
            this.unwrapBarcodeButton.Location = new System.Drawing.Point(355, 435);
            this.unwrapBarcodeButton.Name = "unwrapBarcodeButton";
            this.unwrapBarcodeButton.Size = new System.Drawing.Size(95, 30);
            this.unwrapBarcodeButton.TabIndex = 5;
            this.unwrapBarcodeButton.Text = "Unwrap Barcode";
            this.unwrapBarcodeButton.UseVisualStyleBackColor = true;
            this.unwrapBarcodeButton.Click += new System.EventHandler(this.unwrapBarcodeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Instructions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "1. Load the image file.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "2. Unwrap the barcode.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 485);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.unwrapBarcodeButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Unwrap Barcode Example";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox confidenceLevel;
        private System.Windows.Forms.TextBox barcodeString;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button unwrapBarcodeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

