using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Math Lookup Example
//
// This example demonstrates how to apply a lookup table to an image.  Lookup table (LUT)
// transformations are basic mathematical functions used to improve the contrast and
// brightness of an image by modifying the intensity dynamics of regions with poor
// contrast.  The LUT can also highlight details in areas containing important information.
// In NI Vision, apart from the predefined functions that can be used through the
// Algorithms.MathLookup() function, you can also apply your own lookup tables using
// the Algorithms.UserLookup() function.

namespace MathLookup
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
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");

            // Initialize combo box.
            operatorBox.SelectedIndex = 0;
        }

        private void ProcessImage()
        {
            // Perform the math lookup if an image is loaded.
            if (imageViewer1.Image.Width > 0 && imageViewer1.Image.Height > 0)
            {
                Algorithms.MathLookup(imageViewer1.Image, imageViewer2.Image, (MathLookupOperator)operatorBox.SelectedIndex, (double)xValueUpDown.Value);
            }
        }

        // Click the Load Image button to read an image.
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            ProcessImage();
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

        private void operatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            xValueUpDown.Enabled = operatorBox.SelectedIndex >= 5;
            xValueLabel.Enabled = xValueUpDown.Enabled;
            ProcessImage();
        }

        private void xValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        // The following four functions keep the two image viewers in sync
        private void imageViewer1_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            if (!imageViewer2.Center.Equals(imageViewer1.Center))
            {
                imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y);
            }
        }

        private void imageViewer2_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            if (!imageViewer1.Center.Equals(imageViewer2.Center))
            {
                imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y);
            }
        }

        private void imageViewer1_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            if (!imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo))
            {
                imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y);
            }
        }

        private void imageViewer2_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            if (!imageViewer1.ZoomInfo.Equals(imageViewer2.ZoomInfo))
            {
                imageViewer1.ZoomInfo.Initialize(imageViewer2.ZoomInfo.X, imageViewer2.ZoomInfo.Y);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}