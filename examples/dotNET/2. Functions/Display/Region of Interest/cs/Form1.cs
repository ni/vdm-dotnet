using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Region of Interest Example

// This example demonstrates how to set up the display tools in order to interactively
// select one or more regions for inspection.
namespace Region_of_Interest
{
    public partial class Form1 : Form
    {
        private VisionImage source = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "alu.bmp");
        }

        private void InvertImage()
        {
            // Invert any pixels inside a region of interest.
            if (imageViewer1.Roi.Count > 0)
            {
                using (VisionImage mask = new VisionImage())
                {
                    // Compute the mask image of the selected regions
                    Algorithms.RoiToMask(mask, imageViewer1.Roi, new PixelValue(255), source);

                    // Invert the image
                    Algorithms.Inverse(source, imageViewer1.Image, mask);
                }
            }
            else
            {
                Algorithms.Copy(source, imageViewer1.Image);
            }
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

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            source.ReadFile(imagePath.Text);
            InvertImage();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            InvertImage();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}