namespace Classification
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
            this.classifierPath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.classifyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.scoreBox = new System.Windows.Forms.TextBox();
            this.classBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(279, 22);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(634, 405);
            this.imageViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image";
            // 
            // classifierPath
            // 
            this.classifierPath.Location = new System.Drawing.Point(10, 20);
            this.classifierPath.Multiline = true;
            this.classifierPath.Name = "classifierPath";
            this.classifierPath.Size = new System.Drawing.Size(173, 56);
            this.classifierPath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(189, 20);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(57, 29);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Classifier File Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(10, 100);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(172, 59);
            this.imagePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image File Path";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(10, 177);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(87, 40);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "1. Click Load File.";
            // 
            // classifyButton
            // 
            this.classifyButton.Enabled = false;
            this.classifyButton.Location = new System.Drawing.Point(10, 223);
            this.classifyButton.Name = "classifyButton";
            this.classifyButton.Size = new System.Drawing.Size(87, 40);
            this.classifyButton.TabIndex = 7;
            this.classifyButton.Text = "Classify";
            this.classifyButton.UseVisualStyleBackColor = true;
            this.classifyButton.Click += new System.EventHandler(this.classifyButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(103, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "2. Draw an ROI around the object to classify, and then click Classify.";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(10, 421);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 41);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(103, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 27);
            this.label6.TabIndex = 8;
            this.label6.Text = "3. Stop the example.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.scoreBox);
            this.groupBox1.Controls.Add(this.classBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 98);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Score (0-1000)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Class";
            // 
            // scoreBox
            // 
            this.scoreBox.Location = new System.Drawing.Point(6, 71);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(74, 20);
            this.scoreBox.TabIndex = 0;
            // 
            // classBox
            // 
            this.classBox.Location = new System.Drawing.Point(6, 32);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(105, 20);
            this.classBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.classifyButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.classifierPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Color Classification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox classifierPath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button classifyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox scoreBox;
        private System.Windows.Forms.TextBox classBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

