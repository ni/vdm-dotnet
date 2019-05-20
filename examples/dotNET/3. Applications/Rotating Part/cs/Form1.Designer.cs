namespace RotatingPart
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
            this.label12 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.actualEdges3 = new System.Windows.Forms.TextBox();
            this.actualEdges2 = new System.Windows.Forms.TextBox();
            this.expectedEdges3 = new System.Windows.Forms.TextBox();
            this.actualEdges1 = new System.Windows.Forms.TextBox();
            this.expectedEdges2 = new System.Windows.Forms.TextBox();
            this.expectedEdges1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.testPartsButton = new System.Windows.Forms.Button();
            this.actualEdges5 = new System.Windows.Forms.TextBox();
            this.expectedEdges5 = new System.Windows.Forms.TextBox();
            this.actualEdges4 = new System.Windows.Forms.TextBox();
            this.expectedEdges4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passFailLed1 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed2 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed3 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed4 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.passFailLed5 = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.globalPassFailLed = new NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(306, 18);
            this.label12.TabIndex = 42;
            this.label12.Text = "2. Click Test Parts.";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(156, 286);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(66, 33);
            this.quitButton.TabIndex = 38;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(570, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Status";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(504, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 35);
            this.label7.TabIndex = 28;
            this.label7.Text = "Actual # of Edges";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(437, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 35);
            this.label6.TabIndex = 27;
            this.label6.Text = "Expected # of Edges";
            // 
            // actualEdges3
            // 
            this.actualEdges3.Enabled = false;
            this.actualEdges3.Location = new System.Drawing.Point(507, 84);
            this.actualEdges3.Name = "actualEdges3";
            this.actualEdges3.ReadOnly = true;
            this.actualEdges3.Size = new System.Drawing.Size(52, 20);
            this.actualEdges3.TabIndex = 22;
            this.actualEdges3.Text = "0";
            // 
            // actualEdges2
            // 
            this.actualEdges2.Enabled = false;
            this.actualEdges2.Location = new System.Drawing.Point(507, 62);
            this.actualEdges2.Name = "actualEdges2";
            this.actualEdges2.ReadOnly = true;
            this.actualEdges2.Size = new System.Drawing.Size(52, 20);
            this.actualEdges2.TabIndex = 24;
            this.actualEdges2.Text = "0";
            // 
            // expectedEdges3
            // 
            this.expectedEdges3.Enabled = false;
            this.expectedEdges3.Location = new System.Drawing.Point(440, 84);
            this.expectedEdges3.Name = "expectedEdges3";
            this.expectedEdges3.ReadOnly = true;
            this.expectedEdges3.Size = new System.Drawing.Size(52, 20);
            this.expectedEdges3.TabIndex = 26;
            this.expectedEdges3.Text = "0";
            // 
            // actualEdges1
            // 
            this.actualEdges1.Enabled = false;
            this.actualEdges1.Location = new System.Drawing.Point(507, 40);
            this.actualEdges1.Name = "actualEdges1";
            this.actualEdges1.ReadOnly = true;
            this.actualEdges1.Size = new System.Drawing.Size(52, 20);
            this.actualEdges1.TabIndex = 25;
            this.actualEdges1.Text = "0";
            // 
            // expectedEdges2
            // 
            this.expectedEdges2.Enabled = false;
            this.expectedEdges2.Location = new System.Drawing.Point(440, 62);
            this.expectedEdges2.Name = "expectedEdges2";
            this.expectedEdges2.ReadOnly = true;
            this.expectedEdges2.Size = new System.Drawing.Size(52, 20);
            this.expectedEdges2.TabIndex = 18;
            this.expectedEdges2.Text = "0";
            // 
            // expectedEdges1
            // 
            this.expectedEdges1.Enabled = false;
            this.expectedEdges1.Location = new System.Drawing.Point(440, 40);
            this.expectedEdges1.Name = "expectedEdges1";
            this.expectedEdges1.ReadOnly = true;
            this.expectedEdges1.Size = new System.Drawing.Size(52, 20);
            this.expectedEdges1.TabIndex = 17;
            this.expectedEdges1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Target 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Target 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Target 1";
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Line;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 14);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShowToolbar = true;
            this.imageViewer1.Size = new System.Drawing.Size(349, 260);
            this.imageViewer1.TabIndex = 11;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 346);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(306, 31);
            this.label11.TabIndex = 43;
            this.label11.Text = "1. Draw an inspection line for each feature you want to detect.  To delete a line" +
                ", select it and press the Delete key.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Instructions:";
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(84, 286);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(66, 33);
            this.resetButton.TabIndex = 40;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // testPartsButton
            // 
            this.testPartsButton.Enabled = false;
            this.testPartsButton.Location = new System.Drawing.Point(12, 286);
            this.testPartsButton.Name = "testPartsButton";
            this.testPartsButton.Size = new System.Drawing.Size(66, 33);
            this.testPartsButton.TabIndex = 41;
            this.testPartsButton.Text = "Test Parts";
            this.testPartsButton.UseVisualStyleBackColor = true;
            this.testPartsButton.Click += new System.EventHandler(this.testPartsButton_Click);
            // 
            // actualEdges5
            // 
            this.actualEdges5.Enabled = false;
            this.actualEdges5.Location = new System.Drawing.Point(507, 128);
            this.actualEdges5.Name = "actualEdges5";
            this.actualEdges5.ReadOnly = true;
            this.actualEdges5.Size = new System.Drawing.Size(52, 20);
            this.actualEdges5.TabIndex = 20;
            this.actualEdges5.Text = "0";
            // 
            // expectedEdges5
            // 
            this.expectedEdges5.Enabled = false;
            this.expectedEdges5.Location = new System.Drawing.Point(440, 128);
            this.expectedEdges5.Name = "expectedEdges5";
            this.expectedEdges5.ReadOnly = true;
            this.expectedEdges5.Size = new System.Drawing.Size(52, 20);
            this.expectedEdges5.TabIndex = 23;
            this.expectedEdges5.Text = "0";
            // 
            // actualEdges4
            // 
            this.actualEdges4.Enabled = false;
            this.actualEdges4.Location = new System.Drawing.Point(507, 106);
            this.actualEdges4.Name = "actualEdges4";
            this.actualEdges4.ReadOnly = true;
            this.actualEdges4.Size = new System.Drawing.Size(52, 20);
            this.actualEdges4.TabIndex = 19;
            this.actualEdges4.Text = "0";
            // 
            // expectedEdges4
            // 
            this.expectedEdges4.Enabled = false;
            this.expectedEdges4.Location = new System.Drawing.Point(440, 106);
            this.expectedEdges4.Name = "expectedEdges4";
            this.expectedEdges4.ReadOnly = true;
            this.expectedEdges4.Size = new System.Drawing.Size(52, 20);
            this.expectedEdges4.TabIndex = 21;
            this.expectedEdges4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Target 5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Target 4";
            // 
            // passFailLed1
            // 
            this.passFailLed1.Caption = "";
            this.passFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray;
            this.passFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed1.Location = new System.Drawing.Point(573, 40);
            this.passFailLed1.Name = "passFailLed1";
            this.passFailLed1.Size = new System.Drawing.Size(32, 24);
            this.passFailLed1.TabIndex = 45;
            this.passFailLed1.Value = true;
            // 
            // passFailLed2
            // 
            this.passFailLed2.Caption = "";
            this.passFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray;
            this.passFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed2.Location = new System.Drawing.Point(573, 62);
            this.passFailLed2.Name = "passFailLed2";
            this.passFailLed2.Size = new System.Drawing.Size(32, 24);
            this.passFailLed2.TabIndex = 45;
            this.passFailLed2.Value = true;
            // 
            // passFailLed3
            // 
            this.passFailLed3.Caption = "";
            this.passFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray;
            this.passFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed3.Location = new System.Drawing.Point(573, 84);
            this.passFailLed3.Name = "passFailLed3";
            this.passFailLed3.Size = new System.Drawing.Size(32, 24);
            this.passFailLed3.TabIndex = 45;
            this.passFailLed3.Value = true;
            // 
            // passFailLed4
            // 
            this.passFailLed4.Caption = "";
            this.passFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray;
            this.passFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed4.Location = new System.Drawing.Point(573, 106);
            this.passFailLed4.Name = "passFailLed4";
            this.passFailLed4.Size = new System.Drawing.Size(32, 24);
            this.passFailLed4.TabIndex = 45;
            this.passFailLed4.Value = true;
            // 
            // passFailLed5
            // 
            this.passFailLed5.Caption = "";
            this.passFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray;
            this.passFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.passFailLed5.Location = new System.Drawing.Point(573, 128);
            this.passFailLed5.Name = "passFailLed5";
            this.passFailLed5.Size = new System.Drawing.Size(32, 24);
            this.passFailLed5.TabIndex = 45;
            this.passFailLed5.Value = true;
            // 
            // globalPassFailLed
            // 
            this.globalPassFailLed.Caption = "Global Pass/Fail";
            this.globalPassFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen;
            this.globalPassFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D;
            this.globalPassFailLed.Location = new System.Drawing.Point(390, 162);
            this.globalPassFailLed.Name = "globalPassFailLed";
            this.globalPassFailLed.Size = new System.Drawing.Size(214, 53);
            this.globalPassFailLed.TabIndex = 46;
            this.globalPassFailLed.Value = true;
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(390, 221);
            this.delaySlider1.Maximum = 1500;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 47;
            this.delaySlider1.Value = 750;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 395);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.globalPassFailLed);
            this.Controls.Add(this.passFailLed5);
            this.Controls.Add(this.passFailLed4);
            this.Controls.Add(this.passFailLed3);
            this.Controls.Add(this.passFailLed2);
            this.Controls.Add(this.passFailLed1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.actualEdges3);
            this.Controls.Add(this.actualEdges2);
            this.Controls.Add(this.expectedEdges3);
            this.Controls.Add(this.actualEdges1);
            this.Controls.Add(this.expectedEdges2);
            this.Controls.Add(this.expectedEdges1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.testPartsButton);
            this.Controls.Add(this.actualEdges5);
            this.Controls.Add(this.expectedEdges5);
            this.Controls.Add(this.actualEdges4);
            this.Controls.Add(this.expectedEdges4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox actualEdges3;
        private System.Windows.Forms.TextBox actualEdges2;
        private System.Windows.Forms.TextBox expectedEdges3;
        private System.Windows.Forms.TextBox actualEdges1;
        private System.Windows.Forms.TextBox expectedEdges2;
        private System.Windows.Forms.TextBox expectedEdges1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button testPartsButton;
        private System.Windows.Forms.TextBox actualEdges5;
        private System.Windows.Forms.TextBox expectedEdges5;
        private System.Windows.Forms.TextBox actualEdges4;
        private System.Windows.Forms.TextBox expectedEdges4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed1;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed2;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed3;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed4;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed passFailLed5;
        private NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed globalPassFailLed;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

