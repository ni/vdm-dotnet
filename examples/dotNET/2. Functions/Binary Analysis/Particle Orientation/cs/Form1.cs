using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Particle Orientation Example

// This example shows how to use blob analysis to determine the orientation of
// particles or objects in an image.

namespace ParticleOrientation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Put a default image in the text box.
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Angle Test.png");
        }

        private void measureButton_Click(object sender, EventArgs e)
        {
            // Threshold the image.
            Algorithms.Threshold(imageViewer1.Image, imageViewer1.Image);

            // Change the viewer's palette to Binary to display the image.
            imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;

            // Compute the basic particle statistics to get the center of mass and orientation.
            Collection<ParticleReport> reports = Algorithms.ParticleReport(imageViewer1.Image);

            OverlayTextOptions textOptions = new OverlayTextOptions();
            textOptions.HorizontalAlignment = HorizontalTextAlignment.Center;
            textOptions.VerticalAlignment = VerticalTextAlignment.Baseline;
            textOptions.FontSize = 16;
            foreach (ParticleReport report in reports)
            {
                imageViewer1.Image.Overlays.Default.AddText(String.Format("Angle = {0:###.#}", report.Orientation),
                    report.CenterOfMass, Rgb32Value.WhiteColor);
            }
        }

        // Click the Load Image button to read an image.
        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }


        // Load an image using ReadFile.
        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray;
        }

        // Click the Browse button to open the file dialog.
        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                // Load the image.
                LoadSelectedImage();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}