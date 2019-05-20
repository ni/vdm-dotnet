using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// ColorLearn Example
//
// This example demonstrates how to use color matching operations to learn a color set.
// Color matching compares the colors and the number of colors in a portion of an image to another
// image.  Use this example to better understand how NI Vision learns a color set and how to
// visualize the color spectrum (a result of the learning process).
namespace ColorLearn
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
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Color cubes.jpg");

            // Set the viewer's image type to RGB
            imageViewer1.Image.Type = ImageType.Rgb32;

            // Initialize combo box
            colorSensitivityBox.SelectedIndex = 0;

            // Register for the Paint event
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the color spectrum.
            ColorSpectrumHelpers.DrawColorSpectrum(e.Graphics, pictureBox1.ClientRectangle);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        // Load an image using ReadFile.
        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            imageViewer1.Roi.Clear();
            // Enable the learn colors button
            learnButton.Enabled = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                LoadSelectedImage();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void learnButton_Click(object sender, EventArgs e)
        {
            // Learn the color information.
            ColorInformation colorInformation = Algorithms.LearnColor(imageViewer1.Image, imageViewer1.Roi, (ColorSensitivity)colorSensitivityBox.SelectedIndex, (int)saturationThreshold.Value);

            // Plot the color spectrum on the graph.
            ColorSpectrumHelpers.PlotColorSpectrum(pictureBox1, (ColorSensitivity)colorSensitivityBox.SelectedIndex, colorInformation.Information);
        }
    }
}