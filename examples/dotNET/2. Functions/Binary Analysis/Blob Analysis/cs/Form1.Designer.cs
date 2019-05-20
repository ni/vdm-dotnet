namespace BlobAnalysis
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
            this.steps = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runCurrentStepButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 7);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(520, 497);
            this.imageViewer1.TabIndex = 0;
            // 
            // steps
            // 
            this.steps.FormattingEnabled = true;
            this.steps.Items.AddRange(new object[] {
            "Load sample image",
            "Enhance edge information",
            "Threshold",
            "Fill holes in objects",
            "Remove objects touching the border",
            "Keep round objects",
            "Measure objects areas"});
            this.steps.Location = new System.Drawing.Point(12, 510);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(188, 108);
            this.steps.TabIndex = 1;
            this.steps.SelectedIndexChanged += new System.EventHandler(this.steps_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(206, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 63);
            this.label1.TabIndex = 2;
            this.label1.Text = "This example performs a series of grayscale processing, binary morphology, and bl" +
                "ob analysis operations and measures the areas of all large circular particles in" +
                " the image.";
            // 
            // runCurrentStepButton
            // 
            this.runCurrentStepButton.Location = new System.Drawing.Point(326, 586);
            this.runCurrentStepButton.Name = "runCurrentStepButton";
            this.runCurrentStepButton.Size = new System.Drawing.Size(100, 32);
            this.runCurrentStepButton.TabIndex = 3;
            this.runCurrentStepButton.Text = "Run Current Step";
            this.runCurrentStepButton.UseVisualStyleBackColor = true;
            this.runCurrentStepButton.Click += new System.EventHandler(this.runCurrentStepButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(445, 541);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 32);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset Example";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(445, 586);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 32);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 630);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.runCurrentStepButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Blob Analysis Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.ListBox steps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runCurrentStepButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exitButton;
    }
}

