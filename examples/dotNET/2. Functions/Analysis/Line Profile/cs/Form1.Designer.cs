namespace LineProfile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countBox = new System.Windows.Forms.TextBox();
            this.maximumBox = new System.Windows.Forms.TextBox();
            this.stdDevBox = new System.Windows.Forms.TextBox();
            this.meanBox = new System.Windows.Forms.TextBox();
            this.minimumBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.simpleGraph1 = new NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShowToolbar = true;
            this.imageViewer1.Size = new System.Drawing.Size(452, 347);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.countBox);
            this.groupBox1.Controls.Add(this.maximumBox);
            this.groupBox1.Controls.Add(this.stdDevBox);
            this.groupBox1.Controls.Add(this.meanBox);
            this.groupBox1.Controls.Add(this.minimumBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(470, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 102);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Line Information";
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(63, 76);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(55, 20);
            this.countBox.TabIndex = 1;
            // 
            // maximumBox
            // 
            this.maximumBox.Location = new System.Drawing.Point(63, 50);
            this.maximumBox.Name = "maximumBox";
            this.maximumBox.Size = new System.Drawing.Size(55, 20);
            this.maximumBox.TabIndex = 1;
            // 
            // stdDevBox
            // 
            this.stdDevBox.Location = new System.Drawing.Point(229, 63);
            this.stdDevBox.Name = "stdDevBox";
            this.stdDevBox.Size = new System.Drawing.Size(55, 20);
            this.stdDevBox.TabIndex = 1;
            // 
            // meanBox
            // 
            this.meanBox.Location = new System.Drawing.Point(229, 36);
            this.meanBox.Name = "meanBox";
            this.meanBox.Size = new System.Drawing.Size(55, 20);
            this.meanBox.TabIndex = 1;
            // 
            // minimumBox
            // 
            this.minimumBox.Location = new System.Drawing.Point(63, 23);
            this.minimumBox.Name = "minimumBox";
            this.minimumBox.Size = new System.Drawing.Size(55, 20);
            this.minimumBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maximum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Standard Deviation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mean Value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Image Path:";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(81, 371);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(348, 20);
            this.imagePath.TabIndex = 4;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(435, 372);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(29, 19);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "...";
            this.browseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(467, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Instructions:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(466, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "1. Load an image file.";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(466, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 32);
            this.label10.TabIndex = 7;
            this.label10.Text = "2. Draw a line on the image.  The line information is computed and displayed.";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(470, 401);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(73, 32);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(549, 401);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(73, 32);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // simpleGraph1
            // 
            this.simpleGraph1.AutoSize = true;
            this.simpleGraph1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.simpleGraph1.Location = new System.Drawing.Point(470, 12);
            this.simpleGraph1.Name = "simpleGraph1";
            this.simpleGraph1.Size = new System.Drawing.Size(303, 166);
            this.simpleGraph1.TabIndex = 9;
            this.simpleGraph1.XAxisScaling = NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph.AxisScalingMode.Auto;
            this.simpleGraph1.YAxisScaling = NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph.AxisScalingMode.Fixed;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 445);
            this.Controls.Add(this.simpleGraph1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Line Profile Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.TextBox maximumBox;
        private System.Windows.Forms.TextBox stdDevBox;
        private System.Windows.Forms.TextBox meanBox;
        private System.Windows.Forms.TextBox minimumBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph simpleGraph1;
    }
}

