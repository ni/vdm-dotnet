namespace Particle_Analysis_Report
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
            this.loadImageButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numberOfParticles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orientation = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.height = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.centerOfMassY = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.centerOfMassX = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.boundingRectBottom = new System.Windows.Forms.TextBox();
            this.boundingRectRight = new System.Windows.Forms.TextBox();
            this.boundingRectTop = new System.Windows.Forms.TextBox();
            this.boundingRectLeft = new System.Windows.Forms.TextBox();
            this.numberOfHoles = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.area = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.imageViewer2 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.minimumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.maximumSlide = new NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider();
            this.reportIndex = new System.Windows.Forms.NumericUpDown();
            this.connectivitySwitch = new NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Demonstration Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(11, 22);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(175, 20);
            this.imagePath.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(192, 22);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(51, 20);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(11, 51);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(93, 31);
            this.loadImageButton.TabIndex = 3;
            this.loadImageButton.Text = "Load Image File";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // processButton
            // 
            this.processButton.Enabled = false;
            this.processButton.Location = new System.Drawing.Point(11, 88);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(93, 31);
            this.processButton.TabIndex = 3;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(11, 125);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(93, 31);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "1. Click Load Image File.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(119, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "2. Threshold the image, and get the particles.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Threshold Values";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minimum Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Maximum Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Connectivity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Connectivity-8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Connectivity-4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "# of Particles Found";
            // 
            // numberOfParticles
            // 
            this.numberOfParticles.Location = new System.Drawing.Point(116, 211);
            this.numberOfParticles.Name = "numberOfParticles";
            this.numberOfParticles.ReadOnly = true;
            this.numberOfParticles.Size = new System.Drawing.Size(43, 20);
            this.numberOfParticles.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orientation);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.numberOfHoles);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.area);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(61, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 250);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Particle Reports (pixels)";
            // 
            // orientation
            // 
            this.orientation.Location = new System.Drawing.Point(118, 135);
            this.orientation.Name = "orientation";
            this.orientation.Size = new System.Drawing.Size(63, 20);
            this.orientation.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(113, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Orientation";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.height);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.width);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Location = new System.Drawing.Point(110, 161);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(104, 76);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dimensions";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(6, 45);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(55, 20);
            this.height.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(67, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Height";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(6, 19);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(55, 20);
            this.width.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(67, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Width";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.centerOfMassY);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.centerOfMassX);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(110, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(104, 76);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Center of Mass";
            // 
            // centerOfMassY
            // 
            this.centerOfMassY.Location = new System.Drawing.Point(6, 45);
            this.centerOfMassY.Name = "centerOfMassY";
            this.centerOfMassY.Size = new System.Drawing.Size(65, 20);
            this.centerOfMassY.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(75, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Y";
            // 
            // centerOfMassX
            // 
            this.centerOfMassX.Location = new System.Drawing.Point(6, 19);
            this.centerOfMassX.Name = "centerOfMassX";
            this.centerOfMassX.Size = new System.Drawing.Size(65, 20);
            this.centerOfMassX.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(75, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "X";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.boundingRectBottom);
            this.groupBox2.Controls.Add(this.boundingRectRight);
            this.groupBox2.Controls.Add(this.boundingRectTop);
            this.groupBox2.Controls.Add(this.boundingRectLeft);
            this.groupBox2.Location = new System.Drawing.Point(8, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 129);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bounding Rect";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(55, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Bottom";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(55, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Right";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(55, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Top";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Left";
            // 
            // boundingRectBottom
            // 
            this.boundingRectBottom.Location = new System.Drawing.Point(6, 97);
            this.boundingRectBottom.Name = "boundingRectBottom";
            this.boundingRectBottom.Size = new System.Drawing.Size(46, 20);
            this.boundingRectBottom.TabIndex = 0;
            // 
            // boundingRectRight
            // 
            this.boundingRectRight.Location = new System.Drawing.Point(6, 71);
            this.boundingRectRight.Name = "boundingRectRight";
            this.boundingRectRight.Size = new System.Drawing.Size(46, 20);
            this.boundingRectRight.TabIndex = 0;
            // 
            // boundingRectTop
            // 
            this.boundingRectTop.Location = new System.Drawing.Point(6, 45);
            this.boundingRectTop.Name = "boundingRectTop";
            this.boundingRectTop.Size = new System.Drawing.Size(46, 20);
            this.boundingRectTop.TabIndex = 0;
            // 
            // boundingRectLeft
            // 
            this.boundingRectLeft.Location = new System.Drawing.Point(6, 19);
            this.boundingRectLeft.Name = "boundingRectLeft";
            this.boundingRectLeft.Size = new System.Drawing.Size(46, 20);
            this.boundingRectLeft.TabIndex = 0;
            // 
            // numberOfHoles
            // 
            this.numberOfHoles.Location = new System.Drawing.Point(6, 77);
            this.numberOfHoles.Name = "numberOfHoles";
            this.numberOfHoles.Size = new System.Drawing.Size(47, 20);
            this.numberOfHoles.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Number of Holes";
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(6, 36);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(47, 20);
            this.area.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Area";
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(460, 5);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(327, 229);
            this.imageViewer1.TabIndex = 15;
            // 
            // imageViewer2
            // 
            this.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer2.Location = new System.Drawing.Point(460, 240);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(327, 237);
            this.imageViewer2.TabIndex = 15;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // minimumSlide
            // 
            this.minimumSlide.AutoSize = true;
            this.minimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.minimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.minimumSlide.Location = new System.Drawing.Point(251, 40);
            this.minimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.minimumSlide.Name = "minimumSlide";
            this.minimumSlide.Size = new System.Drawing.Size(203, 53);
            this.minimumSlide.TabIndex = 16;
            this.minimumSlide.Value = 0;
            // 
            // maximumSlide
            // 
            this.maximumSlide.AutoSize = true;
            this.maximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Default;
            this.maximumSlide.Location = new System.Drawing.Point(249, 122);
            this.maximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.Default;
            this.maximumSlide.Name = "maximumSlide";
            this.maximumSlide.Size = new System.Drawing.Size(203, 53);
            this.maximumSlide.TabIndex = 16;
            this.maximumSlide.Value = 100;
            // 
            // reportIndex
            // 
            this.reportIndex.Location = new System.Drawing.Point(23, 247);
            this.reportIndex.Name = "reportIndex";
            this.reportIndex.Size = new System.Drawing.Size(35, 20);
            this.reportIndex.TabIndex = 17;
            this.reportIndex.ValueChanged += new System.EventHandler(this.reportIndex_ValueChanged);
            // 
            // connectivitySwitch
            // 
            this.connectivitySwitch.AutoSize = true;
            this.connectivitySwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectivitySwitch.Location = new System.Drawing.Point(281, 202);
            this.connectivitySwitch.Name = "connectivitySwitch";
            this.connectivitySwitch.Size = new System.Drawing.Size(68, 85);
            this.connectivitySwitch.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 484);
            this.Controls.Add(this.connectivitySwitch);
            this.Controls.Add(this.reportIndex);
            this.Controls.Add(this.maximumSlide);
            this.Controls.Add(this.minimumSlide);
            this.Controls.Add(this.imageViewer2);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numberOfParticles);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Particle Analysis Report Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox numberOfParticles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox numberOfHoles;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox area;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox boundingRectBottom;
        private System.Windows.Forms.TextBox boundingRectRight;
        private System.Windows.Forms.TextBox boundingRectTop;
        private System.Windows.Forms.TextBox boundingRectLeft;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox centerOfMassY;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox centerOfMassX;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox orientation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label label22;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider minimumSlide;
        private NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider maximumSlide;
        private System.Windows.Forms.NumericUpDown reportIndex;
        private NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch connectivitySwitch;
    }
}

