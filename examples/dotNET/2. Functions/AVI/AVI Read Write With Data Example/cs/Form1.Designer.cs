namespace AVI_Read_Write_With_Data_Example
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
            this.browseButton = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.imageViewer1 = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(203, 279);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(57, 25);
            this.browseButton.TabIndex = 18;
            this.browseButton.Text = "&Browse";
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(35, 305);
            this.Path.MaxLength = 0;
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(225, 20);
            this.Path.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(-118, 61);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(96, 14);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Path to Output AVI";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(322, 391);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(240, 80);
            this.Label4.TabIndex = 16;
            this.Label4.Text = resources.GetString("Label4.Text");
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(322, 343);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(240, 41);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "2. Click Start. The sample Images, waveforms, and time stamps are acquired and sa" +
                "ved to the AVI during the Writing phase.";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(322, 295);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(240, 41);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "1. Select the path to save the AVI to.  The AVI you create has sample data associ" +
                "ated with each image.";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(27, 382);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(57, 25);
            this.stopButton.TabIndex = 22;
            this.stopButton.Text = "S&top";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(27, 413);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(57, 25);
            this.QuitButton.TabIndex = 21;
            this.QuitButton.Text = "&Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // startButton
            // 
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(27, 350);
            this.startButton.Name = "startButton";
            this.startButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startButton.Size = new System.Drawing.Size(57, 25);
            this.startButton.TabIndex = 20;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Selected Path for AVI";
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(16, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(546, 261);
            this.imageViewer1.TabIndex = 25;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(13, 486);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(553, 46);
            this.statusLabel.TabIndex = 26;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 541);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Location = new System.Drawing.Point(4, 30);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AVI Read Write With Data Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox Path;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.Button QuitButton;
        public System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label6;
        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

