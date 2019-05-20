namespace ReadImage
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
            this.imageType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(18, 8);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShowImageInfo = true;
            this.imageViewer1.ShowScrollbars = true;
            this.imageViewer1.Size = new System.Drawing.Size(467, 336);
            this.imageViewer1.TabIndex = 0;
            // 
            // imageType
            // 
            this.imageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageType.FormattingEnabled = true;
            this.imageType.Items.AddRange(new object[] {
            "8 bits",
            "16 bits (signed)",
            "Float",
            "Complex",
            "Rgb32",
            "Hsl32",
            "RgbU64",
            "16 bits (unsigned)"});
            this.imageType.Location = new System.Drawing.Point(18, 377);
            this.imageType.Name = "imageType";
            this.imageType.Size = new System.Drawing.Size(131, 21);
            this.imageType.TabIndex = 1;
            this.imageType.SelectedIndexChanged += new System.EventHandler(this.imageType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image Type";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(319, 361);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(80, 35);
            this.loadImageButton.TabIndex = 3;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(405, 361);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 35);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 431);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageType);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.ComboBox imageType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button exitButton;
    }
}

