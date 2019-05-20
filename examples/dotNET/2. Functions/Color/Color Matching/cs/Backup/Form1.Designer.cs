namespace ColorMatching
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.expectedLed13 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed8 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed4 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed12 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed7 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed3 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed11 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed6 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed2 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed9 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed10 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed5 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.expectedLed1 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passFailLed13 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed3 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed8 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed1 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed4 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed5 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed12 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed10 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed7 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed9 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed2 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed11 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed6 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.blackSpectrumBox = new System.Windows.Forms.PictureBox();
            this.orangeSpectrumBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.redSpectrumBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.greenSpectrumBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.passFailLed = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackSpectrumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeSpectrumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redSpectrumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSpectrumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(391, 293);
            this.imageViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.expectedLed13);
            this.groupBox1.Controls.Add(this.expectedLed8);
            this.groupBox1.Controls.Add(this.expectedLed4);
            this.groupBox1.Controls.Add(this.expectedLed12);
            this.groupBox1.Controls.Add(this.expectedLed7);
            this.groupBox1.Controls.Add(this.expectedLed3);
            this.groupBox1.Controls.Add(this.expectedLed11);
            this.groupBox1.Controls.Add(this.expectedLed6);
            this.groupBox1.Controls.Add(this.expectedLed2);
            this.groupBox1.Controls.Add(this.expectedLed9);
            this.groupBox1.Controls.Add(this.expectedLed10);
            this.groupBox1.Controls.Add(this.expectedLed5);
            this.groupBox1.Controls.Add(this.expectedLed1);
            this.groupBox1.Location = new System.Drawing.Point(420, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expected Pattern";
            // 
            // expectedLed13
            // 
            this.expectedLed13.Caption = "";
            this.expectedLed13.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen;
            this.expectedLed13.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed13.Location = new System.Drawing.Point(191, 85);
            this.expectedLed13.Name = "expectedLed13";
            this.expectedLed13.Size = new System.Drawing.Size(40, 40);
            this.expectedLed13.TabIndex = 0;
            this.expectedLed13.Value = true;
            // 
            // expectedLed8
            // 
            this.expectedLed8.Caption = "";
            this.expectedLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange;
            this.expectedLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed8.Location = new System.Drawing.Point(191, 46);
            this.expectedLed8.Name = "expectedLed8";
            this.expectedLed8.Size = new System.Drawing.Size(40, 40);
            this.expectedLed8.TabIndex = 0;
            this.expectedLed8.Value = true;
            // 
            // expectedLed4
            // 
            this.expectedLed4.Caption = "";
            this.expectedLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed;
            this.expectedLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed4.Location = new System.Drawing.Point(191, 10);
            this.expectedLed4.Name = "expectedLed4";
            this.expectedLed4.Size = new System.Drawing.Size(40, 40);
            this.expectedLed4.TabIndex = 0;
            this.expectedLed4.Value = true;
            // 
            // expectedLed12
            // 
            this.expectedLed12.Caption = "";
            this.expectedLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen;
            this.expectedLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed12.Location = new System.Drawing.Point(148, 85);
            this.expectedLed12.Name = "expectedLed12";
            this.expectedLed12.Size = new System.Drawing.Size(40, 40);
            this.expectedLed12.TabIndex = 0;
            this.expectedLed12.Value = true;
            // 
            // expectedLed7
            // 
            this.expectedLed7.Caption = "";
            this.expectedLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange;
            this.expectedLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed7.Location = new System.Drawing.Point(148, 46);
            this.expectedLed7.Name = "expectedLed7";
            this.expectedLed7.Size = new System.Drawing.Size(40, 40);
            this.expectedLed7.TabIndex = 0;
            this.expectedLed7.Value = true;
            // 
            // expectedLed3
            // 
            this.expectedLed3.Caption = "";
            this.expectedLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed;
            this.expectedLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed3.Location = new System.Drawing.Point(148, 10);
            this.expectedLed3.Name = "expectedLed3";
            this.expectedLed3.Size = new System.Drawing.Size(40, 40);
            this.expectedLed3.TabIndex = 0;
            this.expectedLed3.Value = true;
            // 
            // expectedLed11
            // 
            this.expectedLed11.Caption = "";
            this.expectedLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen;
            this.expectedLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed11.Location = new System.Drawing.Point(108, 85);
            this.expectedLed11.Name = "expectedLed11";
            this.expectedLed11.Size = new System.Drawing.Size(40, 40);
            this.expectedLed11.TabIndex = 0;
            this.expectedLed11.Value = true;
            // 
            // expectedLed6
            // 
            this.expectedLed6.Caption = "";
            this.expectedLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange;
            this.expectedLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed6.Location = new System.Drawing.Point(108, 46);
            this.expectedLed6.Name = "expectedLed6";
            this.expectedLed6.Size = new System.Drawing.Size(40, 40);
            this.expectedLed6.TabIndex = 0;
            this.expectedLed6.Value = true;
            // 
            // expectedLed2
            // 
            this.expectedLed2.Caption = "";
            this.expectedLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed;
            this.expectedLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed2.Location = new System.Drawing.Point(108, 10);
            this.expectedLed2.Name = "expectedLed2";
            this.expectedLed2.Size = new System.Drawing.Size(40, 40);
            this.expectedLed2.TabIndex = 0;
            this.expectedLed2.Value = true;
            // 
            // expectedLed9
            // 
            this.expectedLed9.Caption = "";
            this.expectedLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen;
            this.expectedLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed9.Location = new System.Drawing.Point(28, 85);
            this.expectedLed9.Name = "expectedLed9";
            this.expectedLed9.Size = new System.Drawing.Size(40, 40);
            this.expectedLed9.TabIndex = 0;
            this.expectedLed9.Value = true;
            // 
            // expectedLed10
            // 
            this.expectedLed10.Caption = "";
            this.expectedLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen;
            this.expectedLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed10.Location = new System.Drawing.Point(68, 85);
            this.expectedLed10.Name = "expectedLed10";
            this.expectedLed10.Size = new System.Drawing.Size(40, 40);
            this.expectedLed10.TabIndex = 0;
            this.expectedLed10.Value = true;
            // 
            // expectedLed5
            // 
            this.expectedLed5.Caption = "";
            this.expectedLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange;
            this.expectedLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed5.Location = new System.Drawing.Point(68, 46);
            this.expectedLed5.Name = "expectedLed5";
            this.expectedLed5.Size = new System.Drawing.Size(40, 40);
            this.expectedLed5.TabIndex = 0;
            this.expectedLed5.Value = true;
            // 
            // expectedLed1
            // 
            this.expectedLed1.Caption = "";
            this.expectedLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed;
            this.expectedLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.expectedLed1.Location = new System.Drawing.Point(68, 10);
            this.expectedLed1.Name = "expectedLed1";
            this.expectedLed1.Size = new System.Drawing.Size(40, 40);
            this.expectedLed1.TabIndex = 0;
            this.expectedLed1.Value = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passFailLed13);
            this.groupBox2.Controls.Add(this.passFailLed3);
            this.groupBox2.Controls.Add(this.passFailLed8);
            this.groupBox2.Controls.Add(this.passFailLed1);
            this.groupBox2.Controls.Add(this.passFailLed4);
            this.groupBox2.Controls.Add(this.passFailLed5);
            this.groupBox2.Controls.Add(this.passFailLed12);
            this.groupBox2.Controls.Add(this.passFailLed10);
            this.groupBox2.Controls.Add(this.passFailLed7);
            this.groupBox2.Controls.Add(this.passFailLed9);
            this.groupBox2.Controls.Add(this.passFailLed2);
            this.groupBox2.Controls.Add(this.passFailLed11);
            this.groupBox2.Controls.Add(this.passFailLed6);
            this.groupBox2.Location = new System.Drawing.Point(421, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 138);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pass/Fail";
            // 
            // passFailLed13
            // 
            this.passFailLed13.Caption = "";
            this.passFailLed13.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed13.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed13.Location = new System.Drawing.Point(190, 92);
            this.passFailLed13.Name = "passFailLed13";
            this.passFailLed13.Size = new System.Drawing.Size(40, 40);
            this.passFailLed13.TabIndex = 0;
            this.passFailLed13.Value = true;
            // 
            // passFailLed3
            // 
            this.passFailLed3.Caption = "";
            this.passFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed3.Location = new System.Drawing.Point(147, 17);
            this.passFailLed3.Name = "passFailLed3";
            this.passFailLed3.Size = new System.Drawing.Size(40, 40);
            this.passFailLed3.TabIndex = 0;
            this.passFailLed3.Value = true;
            // 
            // passFailLed8
            // 
            this.passFailLed8.Caption = "";
            this.passFailLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed8.Location = new System.Drawing.Point(190, 53);
            this.passFailLed8.Name = "passFailLed8";
            this.passFailLed8.Size = new System.Drawing.Size(40, 40);
            this.passFailLed8.TabIndex = 0;
            this.passFailLed8.Value = true;
            // 
            // passFailLed1
            // 
            this.passFailLed1.Caption = "";
            this.passFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed1.Location = new System.Drawing.Point(67, 17);
            this.passFailLed1.Name = "passFailLed1";
            this.passFailLed1.Size = new System.Drawing.Size(40, 40);
            this.passFailLed1.TabIndex = 0;
            this.passFailLed1.Value = true;
            // 
            // passFailLed4
            // 
            this.passFailLed4.Caption = "";
            this.passFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed4.Location = new System.Drawing.Point(190, 17);
            this.passFailLed4.Name = "passFailLed4";
            this.passFailLed4.Size = new System.Drawing.Size(40, 40);
            this.passFailLed4.TabIndex = 0;
            this.passFailLed4.Value = true;
            // 
            // passFailLed5
            // 
            this.passFailLed5.Caption = "";
            this.passFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed5.Location = new System.Drawing.Point(67, 53);
            this.passFailLed5.Name = "passFailLed5";
            this.passFailLed5.Size = new System.Drawing.Size(40, 40);
            this.passFailLed5.TabIndex = 0;
            this.passFailLed5.Value = true;
            // 
            // passFailLed12
            // 
            this.passFailLed12.Caption = "";
            this.passFailLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed12.Location = new System.Drawing.Point(147, 92);
            this.passFailLed12.Name = "passFailLed12";
            this.passFailLed12.Size = new System.Drawing.Size(40, 40);
            this.passFailLed12.TabIndex = 0;
            this.passFailLed12.Value = true;
            // 
            // passFailLed10
            // 
            this.passFailLed10.Caption = "";
            this.passFailLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed10.Location = new System.Drawing.Point(67, 92);
            this.passFailLed10.Name = "passFailLed10";
            this.passFailLed10.Size = new System.Drawing.Size(40, 40);
            this.passFailLed10.TabIndex = 0;
            this.passFailLed10.Value = true;
            // 
            // passFailLed7
            // 
            this.passFailLed7.Caption = "";
            this.passFailLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed7.Location = new System.Drawing.Point(147, 53);
            this.passFailLed7.Name = "passFailLed7";
            this.passFailLed7.Size = new System.Drawing.Size(40, 40);
            this.passFailLed7.TabIndex = 0;
            this.passFailLed7.Value = true;
            // 
            // passFailLed9
            // 
            this.passFailLed9.Caption = "";
            this.passFailLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed9.Location = new System.Drawing.Point(28, 92);
            this.passFailLed9.Name = "passFailLed9";
            this.passFailLed9.Size = new System.Drawing.Size(40, 40);
            this.passFailLed9.TabIndex = 0;
            this.passFailLed9.Value = true;
            // 
            // passFailLed2
            // 
            this.passFailLed2.Caption = "";
            this.passFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed2.Location = new System.Drawing.Point(107, 17);
            this.passFailLed2.Name = "passFailLed2";
            this.passFailLed2.Size = new System.Drawing.Size(40, 40);
            this.passFailLed2.TabIndex = 0;
            this.passFailLed2.Value = true;
            // 
            // passFailLed11
            // 
            this.passFailLed11.Caption = "";
            this.passFailLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed11.Location = new System.Drawing.Point(107, 92);
            this.passFailLed11.Name = "passFailLed11";
            this.passFailLed11.Size = new System.Drawing.Size(40, 40);
            this.passFailLed11.TabIndex = 0;
            this.passFailLed11.Value = true;
            // 
            // passFailLed6
            // 
            this.passFailLed6.Caption = "";
            this.passFailLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D;
            this.passFailLed6.Location = new System.Drawing.Point(107, 53);
            this.passFailLed6.Name = "passFailLed6";
            this.passFailLed6.Size = new System.Drawing.Size(40, 40);
            this.passFailLed6.TabIndex = 0;
            this.passFailLed6.Value = true;
            // 
            // blackSpectrumBox
            // 
            this.blackSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blackSpectrumBox.Location = new System.Drawing.Point(12, 328);
            this.blackSpectrumBox.Name = "blackSpectrumBox";
            this.blackSpectrumBox.Size = new System.Drawing.Size(192, 80);
            this.blackSpectrumBox.TabIndex = 5;
            this.blackSpectrumBox.TabStop = false;
            // 
            // orangeSpectrumBox
            // 
            this.orangeSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orangeSpectrumBox.Location = new System.Drawing.Point(211, 328);
            this.orangeSpectrumBox.Name = "orangeSpectrumBox";
            this.orangeSpectrumBox.Size = new System.Drawing.Size(192, 80);
            this.orangeSpectrumBox.TabIndex = 5;
            this.orangeSpectrumBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Black Color Spectrum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orange Color Spectrum";
            // 
            // redSpectrumBox
            // 
            this.redSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redSpectrumBox.Location = new System.Drawing.Point(12, 438);
            this.redSpectrumBox.Name = "redSpectrumBox";
            this.redSpectrumBox.Size = new System.Drawing.Size(192, 80);
            this.redSpectrumBox.TabIndex = 5;
            this.redSpectrumBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Red Color Spectrum";
            // 
            // greenSpectrumBox
            // 
            this.greenSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenSpectrumBox.Location = new System.Drawing.Point(211, 438);
            this.greenSpectrumBox.Name = "greenSpectrumBox";
            this.greenSpectrumBox.Size = new System.Drawing.Size(192, 80);
            this.greenSpectrumBox.TabIndex = 5;
            this.greenSpectrumBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Green Color Spectrum";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(586, 533);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(66, 31);
            this.quitButton.TabIndex = 10;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(424, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 69);
            this.label6.TabIndex = 11;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(421, 441);
            this.delaySlider1.Maximum = 2000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 12;
            this.delaySlider1.Value = 500;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // passFailLed
            // 
            this.passFailLed.Caption = "Part OK?";
            this.passFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed.Location = new System.Drawing.Point(421, 304);
            this.passFailLed.Name = "passFailLed";
            this.passFailLed.Size = new System.Drawing.Size(237, 64);
            this.passFailLed.TabIndex = 13;
            this.passFailLed.Value = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 569);
            this.Controls.Add(this.passFailLed);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.greenSpectrumBox);
            this.Controls.Add(this.orangeSpectrumBox);
            this.Controls.Add(this.redSpectrumBox);
            this.Controls.Add(this.blackSpectrumBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Color Matching Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blackSpectrumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeSpectrumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redSpectrumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSpectrumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox blackSpectrumBox;
        private System.Windows.Forms.PictureBox orangeSpectrumBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox redSpectrumBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox greenSpectrumBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed1;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed4;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed3;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed2;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed13;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed8;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed12;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed7;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed11;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed6;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed9;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed10;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed expectedLed5;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed13;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed3;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed8;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed4;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed5;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed12;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed10;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed7;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed9;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed2;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed11;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed6;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed;
    }
}

