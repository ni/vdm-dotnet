namespace ImageToArray
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
            this.imagePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.quitbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(11, 10);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(393, 313);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.RoiChanged += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(this.imageViewer1_RoiChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(75, 332);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(296, 20);
            this.imagePath.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(377, 333);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(27, 19);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pixel Values";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(440, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(24, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(470, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(24, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(500, 29);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(24, 20);
            this.textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(530, 29);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(24, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(560, 29);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(24, 20);
            this.textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(590, 29);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(24, 20);
            this.textBox7.TabIndex = 5;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(410, 55);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(24, 20);
            this.textBox8.TabIndex = 5;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(440, 55);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(24, 20);
            this.textBox9.TabIndex = 5;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(470, 55);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(24, 20);
            this.textBox10.TabIndex = 5;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(500, 55);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(24, 20);
            this.textBox11.TabIndex = 5;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(530, 55);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(24, 20);
            this.textBox12.TabIndex = 5;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(560, 55);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(24, 20);
            this.textBox13.TabIndex = 5;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(590, 55);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(24, 20);
            this.textBox14.TabIndex = 5;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(410, 81);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(24, 20);
            this.textBox15.TabIndex = 5;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(440, 81);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(24, 20);
            this.textBox16.TabIndex = 5;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(470, 81);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(24, 20);
            this.textBox17.TabIndex = 5;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(500, 81);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(24, 20);
            this.textBox18.TabIndex = 5;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(530, 81);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(24, 20);
            this.textBox19.TabIndex = 5;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(560, 81);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(24, 20);
            this.textBox20.TabIndex = 5;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(590, 81);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(24, 20);
            this.textBox21.TabIndex = 5;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(410, 107);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(24, 20);
            this.textBox22.TabIndex = 5;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(440, 107);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(24, 20);
            this.textBox23.TabIndex = 5;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(470, 107);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(24, 20);
            this.textBox24.TabIndex = 5;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(500, 107);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(24, 20);
            this.textBox25.TabIndex = 5;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(530, 107);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(24, 20);
            this.textBox26.TabIndex = 5;
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(560, 107);
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(24, 20);
            this.textBox27.TabIndex = 5;
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(590, 107);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(24, 20);
            this.textBox28.TabIndex = 5;
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(410, 133);
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(24, 20);
            this.textBox29.TabIndex = 5;
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(440, 133);
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(24, 20);
            this.textBox30.TabIndex = 5;
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(470, 133);
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(24, 20);
            this.textBox31.TabIndex = 5;
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(500, 133);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(24, 20);
            this.textBox32.TabIndex = 5;
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(530, 133);
            this.textBox33.Name = "textBox33";
            this.textBox33.ReadOnly = true;
            this.textBox33.Size = new System.Drawing.Size(24, 20);
            this.textBox33.TabIndex = 5;
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(560, 133);
            this.textBox34.Name = "textBox34";
            this.textBox34.ReadOnly = true;
            this.textBox34.Size = new System.Drawing.Size(24, 20);
            this.textBox34.TabIndex = 5;
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(590, 133);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(24, 20);
            this.textBox35.TabIndex = 5;
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(410, 159);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(24, 20);
            this.textBox36.TabIndex = 5;
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(440, 159);
            this.textBox37.Name = "textBox37";
            this.textBox37.ReadOnly = true;
            this.textBox37.Size = new System.Drawing.Size(24, 20);
            this.textBox37.TabIndex = 5;
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(470, 159);
            this.textBox38.Name = "textBox38";
            this.textBox38.ReadOnly = true;
            this.textBox38.Size = new System.Drawing.Size(24, 20);
            this.textBox38.TabIndex = 5;
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(500, 159);
            this.textBox39.Name = "textBox39";
            this.textBox39.ReadOnly = true;
            this.textBox39.Size = new System.Drawing.Size(24, 20);
            this.textBox39.TabIndex = 5;
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(530, 159);
            this.textBox40.Name = "textBox40";
            this.textBox40.ReadOnly = true;
            this.textBox40.Size = new System.Drawing.Size(24, 20);
            this.textBox40.TabIndex = 5;
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(560, 159);
            this.textBox41.Name = "textBox41";
            this.textBox41.ReadOnly = true;
            this.textBox41.Size = new System.Drawing.Size(24, 20);
            this.textBox41.TabIndex = 5;
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(590, 159);
            this.textBox42.Name = "textBox42";
            this.textBox42.ReadOnly = true;
            this.textBox42.Size = new System.Drawing.Size(24, 20);
            this.textBox42.TabIndex = 5;
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(410, 185);
            this.textBox43.Name = "textBox43";
            this.textBox43.ReadOnly = true;
            this.textBox43.Size = new System.Drawing.Size(24, 20);
            this.textBox43.TabIndex = 5;
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(440, 185);
            this.textBox44.Name = "textBox44";
            this.textBox44.ReadOnly = true;
            this.textBox44.Size = new System.Drawing.Size(24, 20);
            this.textBox44.TabIndex = 5;
            // 
            // textBox45
            // 
            this.textBox45.Location = new System.Drawing.Point(470, 185);
            this.textBox45.Name = "textBox45";
            this.textBox45.ReadOnly = true;
            this.textBox45.Size = new System.Drawing.Size(24, 20);
            this.textBox45.TabIndex = 5;
            // 
            // textBox46
            // 
            this.textBox46.Location = new System.Drawing.Point(500, 185);
            this.textBox46.Name = "textBox46";
            this.textBox46.ReadOnly = true;
            this.textBox46.Size = new System.Drawing.Size(24, 20);
            this.textBox46.TabIndex = 5;
            // 
            // textBox47
            // 
            this.textBox47.Location = new System.Drawing.Point(530, 185);
            this.textBox47.Name = "textBox47";
            this.textBox47.ReadOnly = true;
            this.textBox47.Size = new System.Drawing.Size(24, 20);
            this.textBox47.TabIndex = 5;
            // 
            // textBox48
            // 
            this.textBox48.Location = new System.Drawing.Point(560, 185);
            this.textBox48.Name = "textBox48";
            this.textBox48.ReadOnly = true;
            this.textBox48.Size = new System.Drawing.Size(24, 20);
            this.textBox48.TabIndex = 5;
            // 
            // textBox49
            // 
            this.textBox49.Location = new System.Drawing.Point(590, 185);
            this.textBox49.Name = "textBox49";
            this.textBox49.ReadOnly = true;
            this.textBox49.Size = new System.Drawing.Size(24, 20);
            this.textBox49.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(542, 303);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(71, 35);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // quitbutton
            // 
            this.quitbutton.Location = new System.Drawing.Point(542, 344);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(71, 35);
            this.quitbutton.TabIndex = 6;
            this.quitbutton.Text = "Quit";
            this.quitbutton.UseVisualStyleBackColor = true;
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "1. Load an image file.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(410, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 35);
            this.label5.TabIndex = 7;
            this.label5.Text = "2. Click an area to display its pixel values.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 386);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quitbutton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.textBox49);
            this.Controls.Add(this.textBox42);
            this.Controls.Add(this.textBox35);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox48);
            this.Controls.Add(this.textBox41);
            this.Controls.Add(this.textBox34);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox47);
            this.Controls.Add(this.textBox40);
            this.Controls.Add(this.textBox33);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox46);
            this.Controls.Add(this.textBox39);
            this.Controls.Add(this.textBox32);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox45);
            this.Controls.Add(this.textBox38);
            this.Controls.Add(this.textBox31);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox44);
            this.Controls.Add(this.textBox37);
            this.Controls.Add(this.textBox30);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox43);
            this.Controls.Add(this.textBox36);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Image to Array Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.TextBox textBox47;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button quitbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

