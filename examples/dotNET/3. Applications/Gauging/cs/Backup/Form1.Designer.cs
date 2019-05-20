namespace Gauging
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
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noneMode = new System.Windows.Forms.RadioButton();
            this.imageMode = new System.Windows.Forms.RadioButton();
            this.imageResultsMode = new System.Windows.Forms.RadioButton();
            this.tolerance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.partsInspected = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.quitButton = new System.Windows.Forms.Button();
            this.partOK = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed1 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed2 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed3 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed4 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed5 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed6 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed7 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed8 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed9 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed10 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed11 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed12 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(521, 353);
            this.imageViewer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pass/Fail";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noneMode);
            this.groupBox1.Controls.Add(this.imageMode);
            this.groupBox1.Controls.Add(this.imageResultsMode);
            this.groupBox1.Location = new System.Drawing.Point(12, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Options";
            // 
            // noneMode
            // 
            this.noneMode.AutoSize = true;
            this.noneMode.Location = new System.Drawing.Point(10, 56);
            this.noneMode.Name = "noneMode";
            this.noneMode.Size = new System.Drawing.Size(74, 17);
            this.noneMode.TabIndex = 0;
            this.noneMode.TabStop = true;
            this.noneMode.Text = "No display";
            this.noneMode.UseVisualStyleBackColor = true;
            // 
            // imageMode
            // 
            this.imageMode.AutoSize = true;
            this.imageMode.Location = new System.Drawing.Point(10, 35);
            this.imageMode.Name = "imageMode";
            this.imageMode.Size = new System.Drawing.Size(54, 17);
            this.imageMode.TabIndex = 0;
            this.imageMode.TabStop = true;
            this.imageMode.Text = "Image";
            this.imageMode.UseVisualStyleBackColor = true;
            // 
            // imageResultsMode
            // 
            this.imageResultsMode.AutoSize = true;
            this.imageResultsMode.Checked = true;
            this.imageResultsMode.Location = new System.Drawing.Point(10, 16);
            this.imageResultsMode.Name = "imageResultsMode";
            this.imageResultsMode.Size = new System.Drawing.Size(101, 17);
            this.imageResultsMode.TabIndex = 0;
            this.imageResultsMode.TabStop = true;
            this.imageResultsMode.Text = "Image + Results";
            this.imageResultsMode.UseVisualStyleBackColor = true;
            // 
            // tolerance
            // 
            this.tolerance.DecimalPlaces = 2;
            this.tolerance.Location = new System.Drawing.Point(164, 391);
            this.tolerance.Name = "tolerance";
            this.tolerance.Size = new System.Drawing.Size(49, 20);
            this.tolerance.TabIndex = 4;
            this.tolerance.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tolerance (deg)";
            // 
            // partsInspected
            // 
            this.partsInspected.Location = new System.Drawing.Point(491, 501);
            this.partsInspected.Name = "partsInspected";
            this.partsInspected.ReadOnly = true;
            this.partsInspected.Size = new System.Drawing.Size(42, 20);
            this.partsInspected.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Number of parts inspected";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(446, 571);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(87, 36);
            this.quitButton.TabIndex = 11;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // partOK
            // 
            this.partOK.Caption = "Part OK?";
            this.partOK.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.partOK.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.partOK.Location = new System.Drawing.Point(261, 434);
            this.partOK.Name = "partOK";
            this.partOK.Size = new System.Drawing.Size(271, 56);
            this.partOK.TabIndex = 12;
            this.partOK.Value = false;
            // 
            // passFailLed1
            // 
            this.passFailLed1.Caption = "";
            this.passFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed1.Location = new System.Drawing.Point(258, 394);
            this.passFailLed1.Name = "passFailLed1";
            this.passFailLed1.Size = new System.Drawing.Size(22, 33);
            this.passFailLed1.TabIndex = 13;
            this.passFailLed1.Value = false;
            // 
            // passFailLed2
            // 
            this.passFailLed2.Caption = "";
            this.passFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed2.Location = new System.Drawing.Point(280, 394);
            this.passFailLed2.Name = "passFailLed2";
            this.passFailLed2.Size = new System.Drawing.Size(22, 33);
            this.passFailLed2.TabIndex = 13;
            this.passFailLed2.Value = false;
            // 
            // passFailLed3
            // 
            this.passFailLed3.Caption = "";
            this.passFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed3.Location = new System.Drawing.Point(302, 394);
            this.passFailLed3.Name = "passFailLed3";
            this.passFailLed3.Size = new System.Drawing.Size(22, 33);
            this.passFailLed3.TabIndex = 13;
            this.passFailLed3.Value = false;
            // 
            // passFailLed4
            // 
            this.passFailLed4.Caption = "";
            this.passFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed4.Location = new System.Drawing.Point(324, 394);
            this.passFailLed4.Name = "passFailLed4";
            this.passFailLed4.Size = new System.Drawing.Size(22, 33);
            this.passFailLed4.TabIndex = 13;
            this.passFailLed4.Value = false;
            // 
            // passFailLed5
            // 
            this.passFailLed5.Caption = "";
            this.passFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed5.Location = new System.Drawing.Point(346, 394);
            this.passFailLed5.Name = "passFailLed5";
            this.passFailLed5.Size = new System.Drawing.Size(22, 33);
            this.passFailLed5.TabIndex = 13;
            this.passFailLed5.Value = false;
            // 
            // passFailLed6
            // 
            this.passFailLed6.Caption = "";
            this.passFailLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed6.Location = new System.Drawing.Point(368, 394);
            this.passFailLed6.Name = "passFailLed6";
            this.passFailLed6.Size = new System.Drawing.Size(22, 33);
            this.passFailLed6.TabIndex = 13;
            this.passFailLed6.Value = false;
            // 
            // passFailLed7
            // 
            this.passFailLed7.Caption = "";
            this.passFailLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed7.Location = new System.Drawing.Point(390, 394);
            this.passFailLed7.Name = "passFailLed7";
            this.passFailLed7.Size = new System.Drawing.Size(22, 33);
            this.passFailLed7.TabIndex = 13;
            this.passFailLed7.Value = false;
            // 
            // passFailLed8
            // 
            this.passFailLed8.Caption = "";
            this.passFailLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed8.Location = new System.Drawing.Point(412, 394);
            this.passFailLed8.Name = "passFailLed8";
            this.passFailLed8.Size = new System.Drawing.Size(22, 33);
            this.passFailLed8.TabIndex = 13;
            this.passFailLed8.Value = false;
            // 
            // passFailLed9
            // 
            this.passFailLed9.Caption = "";
            this.passFailLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed9.Location = new System.Drawing.Point(434, 394);
            this.passFailLed9.Name = "passFailLed9";
            this.passFailLed9.Size = new System.Drawing.Size(22, 33);
            this.passFailLed9.TabIndex = 13;
            this.passFailLed9.Value = false;
            // 
            // passFailLed10
            // 
            this.passFailLed10.Caption = "";
            this.passFailLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed10.Location = new System.Drawing.Point(455, 394);
            this.passFailLed10.Name = "passFailLed10";
            this.passFailLed10.Size = new System.Drawing.Size(22, 33);
            this.passFailLed10.TabIndex = 13;
            this.passFailLed10.Value = false;
            // 
            // passFailLed11
            // 
            this.passFailLed11.Caption = "";
            this.passFailLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed11.Location = new System.Drawing.Point(478, 394);
            this.passFailLed11.Name = "passFailLed11";
            this.passFailLed11.Size = new System.Drawing.Size(22, 33);
            this.passFailLed11.TabIndex = 13;
            this.passFailLed11.Value = false;
            // 
            // passFailLed12
            // 
            this.passFailLed12.Caption = "";
            this.passFailLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal;
            this.passFailLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed12.Location = new System.Drawing.Point(500, 394);
            this.passFailLed12.Name = "passFailLed12";
            this.passFailLed12.Size = new System.Drawing.Size(22, 33);
            this.passFailLed12.TabIndex = 13;
            this.passFailLed12.Value = false;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(12, 478);
            this.delaySlider1.Maximum = 1000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 14;
            this.delaySlider1.Value = 250;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 614);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.passFailLed12);
            this.Controls.Add(this.passFailLed11);
            this.Controls.Add(this.passFailLed10);
            this.Controls.Add(this.passFailLed9);
            this.Controls.Add(this.passFailLed8);
            this.Controls.Add(this.passFailLed7);
            this.Controls.Add(this.passFailLed6);
            this.Controls.Add(this.passFailLed5);
            this.Controls.Add(this.passFailLed4);
            this.Controls.Add(this.passFailLed3);
            this.Controls.Add(this.passFailLed2);
            this.Controls.Add(this.passFailLed1);
            this.Controls.Add(this.partOK);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.partsInspected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tolerance);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Gauging Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton noneMode;
        private System.Windows.Forms.RadioButton imageMode;
        private System.Windows.Forms.RadioButton imageResultsMode;
        private System.Windows.Forms.NumericUpDown tolerance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox partsInspected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button quitButton;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed partOK;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed2;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed3;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed4;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed5;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed6;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed7;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed8;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed9;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed10;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed11;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed12;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

