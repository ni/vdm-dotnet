namespace Label
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
            this.label1 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectivity4Button = new System.Windows.Forms.RadioButton();
            this.connectivity8Button = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfParticles = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.simpleRangeSelect1 = new NationalInstruments.Vision.MeasurementStudioDemo.SimpleRangeSelect();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(72, 210);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(347, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(425, 210);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(29, 20);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectivity4Button);
            this.groupBox1.Controls.Add(this.connectivity8Button);
            this.groupBox1.Location = new System.Drawing.Point(11, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // connectivity4Button
            // 
            this.connectivity4Button.AutoSize = true;
            this.connectivity4Button.Checked = true;
            this.connectivity4Button.Location = new System.Drawing.Point(11, 37);
            this.connectivity4Button.Name = "connectivity4Button";
            this.connectivity4Button.Size = new System.Drawing.Size(92, 17);
            this.connectivity4Button.TabIndex = 0;
            this.connectivity4Button.TabStop = true;
            this.connectivity4Button.Text = "4-Connectivity";
            this.connectivity4Button.CheckedChanged += new System.EventHandler(this.connectivity4Button_CheckedChanged);
            // 
            // connectivity8Button
            // 
            this.connectivity8Button.AutoSize = true;
            this.connectivity8Button.Location = new System.Drawing.Point(11, 20);
            this.connectivity8Button.Name = "connectivity8Button";
            this.connectivity8Button.Size = new System.Drawing.Size(92, 17);
            this.connectivity8Button.TabIndex = 0;
            this.connectivity8Button.Text = "8-Connectivity";
            this.connectivity8Button.UseVisualStyleBackColor = true;
            this.connectivity8Button.CheckedChanged += new System.EventHandler(this.connectivity8Button_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Particles";
            // 
            // numberOfParticles
            // 
            this.numberOfParticles.Location = new System.Drawing.Point(113, 306);
            this.numberOfParticles.Name = "numberOfParticles";
            this.numberOfParticles.ReadOnly = true;
            this.numberOfParticles.Size = new System.Drawing.Size(31, 20);
            this.numberOfParticles.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "1. Load an image file.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(159, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 49);
            this.label5.TabIndex = 7;
            this.label5.Text = "2. Drag the red cursors to change the threshold window size.  Drag the blue curso" +
                "r to move the threshold window.";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(374, 287);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(79, 31);
            this.loadImageButton.TabIndex = 8;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(374, 324);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(79, 31);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // simpleRangeSelect1
            // 
            this.simpleRangeSelect1.AutoSize = true;
            this.simpleRangeSelect1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.simpleRangeSelect1.Location = new System.Drawing.Point(11, 7);
            this.simpleRangeSelect1.Name = "simpleRangeSelect1";
            this.simpleRangeSelect1.Size = new System.Drawing.Size(448, 197);
            this.simpleRangeSelect1.TabIndex = 9;
            this.simpleRangeSelect1.RangeChanged += new System.EventHandler<NationalInstruments.Vision.MeasurementStudioDemo.RangeChangedEventArgs>(this.simpleRangeSelect1_RangeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(465, 367);
            this.Controls.Add(this.simpleRangeSelect1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfParticles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(3, 22);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Label Example";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton connectivity8Button;
        private System.Windows.Forms.RadioButton connectivity4Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberOfParticles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button exitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.SimpleRangeSelect simpleRangeSelect1;
    }
}

