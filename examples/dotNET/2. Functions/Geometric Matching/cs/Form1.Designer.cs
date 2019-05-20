namespace GeometricMatching
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
            this.imageViewer = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.templatePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.occlusionInvariant = new System.Windows.Forms.CheckBox();
            this.scaleInvariant = new System.Windows.Forms.CheckBox();
            this.rotationInvariant = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.minScore = new System.Windows.Forms.NumericUpDown();
            this.numMatches = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.templateImageViewer = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label8 = new System.Windows.Forms.Label();
            this.searchParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer
            // 
            this.imageViewer.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer.Location = new System.Drawing.Point(390, 29);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(601, 472);
            this.imageViewer.TabIndex = 0;
            this.imageViewer.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer_RoiChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image";
            // 
            // templatePath
            // 
            this.templatePath.Location = new System.Drawing.Point(10, 27);
            this.templatePath.Multiline = true;
            this.templatePath.Name = "templatePath";
            this.templatePath.Size = new System.Drawing.Size(292, 40);
            this.templatePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(308, 27);
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
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Template File Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(10, 125);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(292, 39);
            this.imagePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image File Path";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(10, 184);
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
            this.label4.Location = new System.Drawing.Point(103, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "1. Click Load File.";
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(10, 230);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(87, 40);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(103, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "2. Search the ROI to look for the locations of the template.  If no ROI is specif" +
                "ied, the entire image will be searched.";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(10, 511);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 41);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(103, 526);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 27);
            this.label6.TabIndex = 8;
            this.label6.Text = "3. Stop the example.";
            // 
            // searchParameters
            // 
            this.searchParameters.Controls.Add(this.occlusionInvariant);
            this.searchParameters.Controls.Add(this.scaleInvariant);
            this.searchParameters.Controls.Add(this.rotationInvariant);
            this.searchParameters.Controls.Add(this.label11);
            this.searchParameters.Controls.Add(this.label10);
            this.searchParameters.Controls.Add(this.label9);
            this.searchParameters.Controls.Add(this.minScore);
            this.searchParameters.Controls.Add(this.numMatches);
            this.searchParameters.Location = new System.Drawing.Point(13, 283);
            this.searchParameters.Name = "searchParameters";
            this.searchParameters.Size = new System.Drawing.Size(141, 218);
            this.searchParameters.TabIndex = 9;
            this.searchParameters.TabStop = false;
            this.searchParameters.Text = "Search Parameters";
            // 
            // occlusionInvariant
            // 
            this.occlusionInvariant.AutoSize = true;
            this.occlusionInvariant.Location = new System.Drawing.Point(27, 82);
            this.occlusionInvariant.Name = "occlusionInvariant";
            this.occlusionInvariant.Size = new System.Drawing.Size(73, 17);
            this.occlusionInvariant.TabIndex = 14;
            this.occlusionInvariant.Text = "Occlusion";
            this.occlusionInvariant.UseVisualStyleBackColor = true;
            this.occlusionInvariant.CheckedChanged += new System.EventHandler(this.occlusionInvariant_CheckedChanged);
            // 
            // scaleInvariant
            // 
            this.scaleInvariant.AutoSize = true;
            this.scaleInvariant.Location = new System.Drawing.Point(27, 59);
            this.scaleInvariant.Name = "scaleInvariant";
            this.scaleInvariant.Size = new System.Drawing.Size(53, 17);
            this.scaleInvariant.TabIndex = 13;
            this.scaleInvariant.Text = "Scale";
            this.scaleInvariant.UseVisualStyleBackColor = true;
            this.scaleInvariant.CheckedChanged += new System.EventHandler(this.scaleInvariant_CheckedChanged);
            // 
            // rotationInvariant
            // 
            this.rotationInvariant.AutoSize = true;
            this.rotationInvariant.Checked = true;
            this.rotationInvariant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotationInvariant.Location = new System.Drawing.Point(27, 36);
            this.rotationInvariant.Name = "rotationInvariant";
            this.rotationInvariant.Size = new System.Drawing.Size(66, 17);
            this.rotationInvariant.TabIndex = 12;
            this.rotationInvariant.Text = "Rotation";
            this.rotationInvariant.UseVisualStyleBackColor = true;
            this.rotationInvariant.CheckedChanged += new System.EventHandler(this.rotationInvariant_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Minimum Score";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Number of Matches";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Match Mode";
            // 
            // minScore
            // 
            this.minScore.Location = new System.Drawing.Point(26, 183);
            this.minScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minScore.Name = "minScore";
            this.minScore.Size = new System.Drawing.Size(63, 20);
            this.minScore.TabIndex = 1;
            this.minScore.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // numMatches
            // 
            this.numMatches.Location = new System.Drawing.Point(26, 133);
            this.numMatches.Name = "numMatches";
            this.numMatches.Size = new System.Drawing.Size(63, 20);
            this.numMatches.TabIndex = 1;
            this.numMatches.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numMatches.ValueChanged += new System.EventHandler(this.numMatches_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 40);
            this.label7.TabIndex = 10;
            this.label7.Text = "The Template File was created using the Geometric Matching Training Interface.  ";
            // 
            // templateImageViewer
            // 
            this.templateImageViewer.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            this.templateImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templateImageViewer.Location = new System.Drawing.Point(167, 299);
            this.templateImageViewer.Name = "templateImageViewer";
            this.templateImageViewer.Size = new System.Drawing.Size(211, 202);
            this.templateImageViewer.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Template";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 563);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.templateImageViewer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.templatePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer);
            this.Name = "Form1";
            this.Text = "Geometric Matching";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox templatePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private NationalInstruments.Vision.WindowsForms.ImageViewer templateImageViewer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown minScore;
        private System.Windows.Forms.NumericUpDown numMatches;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox occlusionInvariant;
        private System.Windows.Forms.CheckBox scaleInvariant;
        private System.Windows.Forms.CheckBox rotationInvariant;
    }
}

