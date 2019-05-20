namespace MorphologicalSegmentation
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
            this.viewerLabel = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.steps = new System.Windows.Forms.ListBox();
            this.connectivity8 = new System.Windows.Forms.CheckBox();
            this.runCurrentStepButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(219, 29);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(331, 344);
            this.imageViewer1.TabIndex = 0;
            // 
            // viewerLabel
            // 
            this.viewerLabel.AutoSize = true;
            this.viewerLabel.Location = new System.Drawing.Point(216, 13);
            this.viewerLabel.Name = "viewerLabel";
            this.viewerLabel.Size = new System.Drawing.Size(36, 13);
            this.viewerLabel.TabIndex = 1;
            this.viewerLabel.Text = "Image";
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(13, 29);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(157, 68);
            this.imagePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image Path";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(176, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 22);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // steps
            // 
            this.steps.FormattingEnabled = true;
            this.steps.Items.AddRange(new object[] {
            "Load sample image",
            "Threshold",
            "Distance Transform",
            "Watershed Transform",
            "Display Watershed Lines",
            "Stop"});
            this.steps.Location = new System.Drawing.Point(13, 119);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(156, 95);
            this.steps.TabIndex = 4;
            this.steps.SelectedIndexChanged += new System.EventHandler(this.steps_SelectedIndexChanged);
            // 
            // connectivity8
            // 
            this.connectivity8.AutoSize = true;
            this.connectivity8.Checked = true;
            this.connectivity8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.connectivity8.Location = new System.Drawing.Point(12, 229);
            this.connectivity8.Name = "connectivity8";
            this.connectivity8.Size = new System.Drawing.Size(93, 17);
            this.connectivity8.TabIndex = 5;
            this.connectivity8.Text = "Connectivity-8";
            this.connectivity8.UseVisualStyleBackColor = true;
            // 
            // runCurrentStepButton
            // 
            this.runCurrentStepButton.Location = new System.Drawing.Point(12, 299);
            this.runCurrentStepButton.Name = "runCurrentStepButton";
            this.runCurrentStepButton.Size = new System.Drawing.Size(156, 34);
            this.runCurrentStepButton.TabIndex = 6;
            this.runCurrentStepButton.Text = "Run Current Step";
            this.runCurrentStepButton.UseVisualStyleBackColor = true;
            this.runCurrentStepButton.Click += new System.EventHandler(this.runCurrentStepButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(12, 339);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(156, 34);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 402);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.runCurrentStepButton);
            this.Controls.Add(this.connectivity8);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.viewerLabel);
            this.Controls.Add(this.imageViewer1);
            this.Name = "Form1";
            this.Text = "Morphological Segmentation Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.Vision.WindowsForms.ImageViewer imageViewer1;
        private System.Windows.Forms.Label viewerLabel;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ListBox steps;
        private System.Windows.Forms.CheckBox connectivity8;
        private System.Windows.Forms.Button runCurrentStepButton;
        private System.Windows.Forms.Button quitButton;
    }
}

