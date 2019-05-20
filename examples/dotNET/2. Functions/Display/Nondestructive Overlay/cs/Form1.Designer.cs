namespace NondestructiveOverlay
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.overlaidTextBox = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.textColorButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(451, 354);
            this.imageViewer1.TabIndex = 0;
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Lime;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overlaid Text";
            // 
            // overlaidTextBox
            // 
            this.overlaidTextBox.ForeColor = System.Drawing.Color.Lime;
            this.overlaidTextBox.Location = new System.Drawing.Point(12, 396);
            this.overlaidTextBox.Multiline = true;
            this.overlaidTextBox.Name = "overlaidTextBox";
            this.overlaidTextBox.Size = new System.Drawing.Size(148, 42);
            this.overlaidTextBox.TabIndex = 2;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(376, 396);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(87, 31);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // textColorButton
            // 
            this.textColorButton.Location = new System.Drawing.Point(273, 396);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(97, 31);
            this.textColorButton.TabIndex = 3;
            this.textColorButton.Text = "Select Text Color";
            this.textColorButton.UseVisualStyleBackColor = true;
            this.textColorButton.Click += new System.EventHandler(this.textColorButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 465);
            this.Controls.Add(this.textColorButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.overlaidTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Nondestructive Overlay Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox overlaidTextBox;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.Timer timer1;
    }
}

