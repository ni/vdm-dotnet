using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.WindowsForms;

// Magic Wand Example
//
// This example demonstrates how to create an image mask by extracting a region surrounding
// a reference pixel, called the origin, and using a tolerance (+ or -) of intensity
// variations based on this reference pixel.  Using this origin, Algorithms.MagicWand()
// searches for its neighbors with an intensity equal to or falling within the tolerance
// value of the point of reference.

namespace MagicWand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageViewer1.Roi.Color = Rgb32Value.YellowColor;
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            // If a point is on the viewer, perform the magic wand operation.
            if (imageViewer1.Roi.Count > 0 && imageViewer1.Roi[0].Type == ContourType.Point)
            {
                Algorithms.MagicWand(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, (double)toleranceUpDown.Value, connectivity4Button.Checked ? Connectivity.Connectivity4 : Connectivity.Connectivity8);
                MaskToRoiReport report = Algorithms.MaskToRoi(imageViewer2.Image);
                imageViewer1.Roi.Clear();
                foreach (Contour c in report.Roi)
                {
                    imageViewer1.Roi.Add(c.Shape);
                }
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
        }

        // Click the Browse button to open the file dialog.
        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog imageDialog = new ImagePreviewFileDialog();
            imageDialog.FileName = imagePath.Text;
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = imageDialog.FileName;
                // Load the image.
                LoadSelectedImage();
            }
        }

        // The following four functions keep the two image viewers in sync.
        private void imageViewer1_ImagePanned(object sender, ImagePannedEventArgs e)
        {
            if (!imageViewer2.Center.Equals(imageViewer1.Center))
            {
                imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y);
            }
        }

        private void imageViewer2_ImagePanned(object sender, ImagePannedEventArgs e)
        {
            if (!imageViewer1.Center.Equals(imageViewer2.Center))
            {
                imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y);
            }
        }

        private void imageViewer1_ImageZoomed(object sender, ImageZoomedEventArgs e)
        {
            if (!imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo))
            {
                imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y);
            }
        }

        private void imageViewer2_ImageZoomed(object sender, ImageZoomedEventArgs e)
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