namespace Barcode
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
            this.quitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.barcodeResult = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.delaySlider1 = new NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(388, 277);
            this.imageViewer1.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(325, 388);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 29);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Code";
            // 
            // barcodeResult
            // 
            this.barcodeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeResult.Location = new System.Drawing.Point(230, 314);
            this.barcodeResult.Name = "barcodeResult";
            this.barcodeResult.ReadOnly = true;
            this.barcodeResult.Size = new System.Drawing.Size(170, 29);
            this.barcodeResult.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 79);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // delaySlider1
            // 
            this.delaySlider1.AutoSize = true;
            this.delaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delaySlider1.Location = new System.Drawing.Point(12, 298);
            this.delaySlider1.Maximum = 2000;
            this.delaySlider1.Name = "delaySlider1";
            this.delaySlider1.Size = new System.Drawing.Size(165, 78);
            this.delaySlider1.TabIndex = 7;
            this.delaySlider1.Value = 1500;
            this.delaySlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.delaySlider1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 515);
            this.Controls.Add(this.delaySlider1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.barcodeResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Barcode Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox barcodeResult;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider delaySlider1;
    }
}

