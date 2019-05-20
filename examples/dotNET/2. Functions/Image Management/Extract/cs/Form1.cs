using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Extract Example
//
// This example demonstrates how to extract one region of an image.
namespace Extract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
            imageViewer1.Roi.MaximumContours = 1;
        }

        private void ProcessImage()
        {
            // Perform the extract operation if the user loads an image and selects a region of interest.
            if (!(imageViewer1.Image.Width == 0 || imageViewer1.Image.Height == 0) && imageViewer1.Roi.Count > 0)
            {
                Algorithms.Extract(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, (int)xStep.Value, (int)yStep.Value);
            }
        }

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

        private void LoadSelectedImage()
        {
            // Load an image using ReadFile
            imageViewer1.Image.ReadFile(imagePath.Text);
            imageViewer1.Roi.Clear();
        }

        // Click the Load Image button to read an image.
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
            ProcessImage();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            ProcessImage();
        }

        // If any settings change, update the image
        private void xStep_ValueChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        private void yStep_ValueChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}