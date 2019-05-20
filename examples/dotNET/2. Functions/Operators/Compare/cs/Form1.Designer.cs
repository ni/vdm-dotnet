namespace Compare
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
            this.quitButton = new System.Windows.Forms.Button();
            this.compareImagesButton = new System.Windows.Forms.Button();
            this.loadImagesButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.browseButton2 = new System.Windows.Forms.Button();
            this.browseButton1 = new System.Windows.Forms.Button();
            this.imagePath2 = new System.Windows.Forms.TextBox();
            this.imagePath1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewer3 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label8 = new System.Windows.Forms.Label();
            this.comparisonBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(398, 431);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(98, 26);
            this.quitButton.TabIndex = 23;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // compareImagesButton
            // 
            this.compareImagesButton.Enabled = false;
            this.compareImagesButton.Location = new System.Drawing.Point(398, 399);
            this.compareImagesButton.Name = "compareImagesButton";
            this.compareImagesButton.Size = new System.Drawing.Size(98, 26);
            this.compareImagesButton.TabIndex = 25;
            this.compareImagesButton.Text = "Compare Images";
            this.compareImagesButton.UseVisualStyleBackColor = true;
            this.compareImagesButton.Click += new System.EventHandler(this.compareImagesButton_Click);
            // 
            // loadImagesButton
            // 
            this.loadImagesButton.Location = new System.Drawing.Point(398, 369);
            this.loadImagesButton.Name = "loadImagesButton";
            this.loadImagesButton.Size = new System.Drawing.Size(98, 26);
            this.loadImagesButton.TabIndex = 24;
            this.loadImagesButton.Text = "Load Images";
            this.loadImagesButton.UseVisualStyleBackColor = true;
            this.loadImagesButton.Click += new System.EventHandler(this.loadImagesButton_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(263, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 45);
            this.label7.TabIndex = 19;
            this.label7.Text = "2. Compare the two images.  Try different comparison operators.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "1. Load the images.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Result Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "(Image 2 must be the same size as Image 1)";
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(485, 275);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(25, 20);
            this.browseButton2.TabIndex = 15;
            this.browseButton2.Text = "...";
            this.browseButton2.UseVisualStyleBackColor = true;
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // browseButton1
            // 
            this.browseButton1.Location = new System.Drawing.Point(231, 275);
            this.browseButton1.Name = "browseButton1";
            this.browseButton1.Size = new System.Drawing.Size(25, 20);
            this.browseButton1.TabIndex = 16;
            this.browseButton1.Text = "...";
            this.browseButton1.UseVisualStyleBackColor = true;
            this.browseButton1.Click += new System.EventHandler(this.browseButton1_Click);
            // 
            // imagePath2
            // 
            this.imagePath2.Location = new System.Drawing.Point(266, 274);
            this.imagePath2.Multiline = true;
            this.imagePath2.Name = "imagePath2";
            this.imagePath2.Size = new System.Drawing.Size(213, 45);
            this.imagePath2.TabIndex = 13;
            // 
            // imagePath1
            // 
            this.imagePath1.Location = new System.Drawing.Point(12, 274);
            this.imagePath1.Multiline = true;
            this.imagePath1.Name = "imagePath1";
            this.imagePath1.Size = new System.Drawing.Size(213, 45);
            this.imagePath1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Source Image 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Source Image 1";
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(266, 22);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(231, 242);
            this.imageViewer2.TabIndex = 8;
            // 
            // imageViewer3
            // 
            this.imageViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer3.Location = new System.Drawing.Point(12, 347);
            this.imageViewer3.Name = "imageViewer3";
            this.imageViewer3.Size = new System.Drawing.Size(231, 242);
            this.imageViewer3.TabIndex = 9;
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 22);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(231, 242);
            this.imageViewer1.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 506);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Comparison Operator";
            // 
            // comparisonBox
            // 
            this.comparisonBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comparisonBox.FormattingEnabled = true;
            this.comparisonBox.Items.AddRange(new object[] {
            "Clear if <",
            "Clear if <=",
            "Clear if =",
            "Clear if >=",
            "Clear if >"});
            this.comparisonBox.Location = new System.Drawing.Point(266, 530);
            this.comparisonBox.Name = "comparisonBox";
            this.comparisonBox.Size = new System.Drawing.Size(104, 21);
            this.comparisonBox.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 604);
            this.Controls.Add(this.comparisonBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.compareImagesButton);
            this.Controls.Add(this.loadImagesButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browseButton2);
            this.Controls.Add(this.browseButton1);
            this.Controls.Add(this.imagePath2);
            this.Controls.Add(this.imagePath1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer3);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Compare Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button compareImagesButton;
        private System.Windows.Forms.Button loadImagesButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseButton2;
        private System.Windows.Forms.Button browseButton1;
        private System.Windows.Forms.TextBox imagePath2;
        private System.Windows.Forms.TextBox imagePath1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer3;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comparisonBox;
    }
}

