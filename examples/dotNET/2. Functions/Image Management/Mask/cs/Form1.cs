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

// Mask example

// This example demonstrates how to apply a binary image (or mask image) to mask another
// image.  When an image is masked, all the pixels in the image that correspond to pixels with
// zero values in the mask image are set to zero.  The other pixels are left untouched.
// Masking is an effective way to process specific parts of an image.

namespace Mask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sourceImagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Iron.tif");
            maskImagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Mask.tif");
            imageViewer1.ImagePanned += new EventHandler<ImagePannedEventArgs>(imageViewer1_ImagePanned);
            imageViewer1.ImageZoomed += new EventHandler<ImageZoomedEventArgs>(imageViewer1_ImageZoomed);
            imageViewer2.ImagePanned += new EventHandler<ImagePannedEventArgs>(imageViewer2_ImagePanned);
            imageViewer2.ImageZoomed += new EventHandler<ImageZoomedEventArgs>(imageViewer2_ImageZoomed);
            imageViewer1.ToolsShown = ViewerTools.Pan | ViewerTools.Point | ViewerTools.ZoomIn | ViewerTools.ZoomOut | ViewerTools.Selection;
            imageViewer2.ToolsShown = ViewerTools.Pan | ViewerTools.Point | ViewerTools.ZoomIn | ViewerTools.ZoomOut | ViewerTools.Selection;
        }

        // These four functions keep imageViewer1 and imageViewer2 at the same position in the image
        // with the same zoom scale.
        void imageViewer2_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            imageViewer1.ZoomInfo.Initialize(imageViewer2.ZoomInfo.X, imageViewer2.ZoomInfo.Y);
        }

        void imageViewer2_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y);
        }

        void imageViewer1_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y);
        }

        void imageViewer1_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y);
        }

        private void sourceBrowseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = sourceImagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceImagePath.Text = dialog.FileName;
                LoadSourceImage();
            }
        }

        private void LoadSourceImage()
        {
            // Read the source image
            imageViewer1.Image.ReadFile(sourceImagePath.Text);
        }

        private void maskImageButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = maskImagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                maskImagePath.Text = dialog.FileName;
                LoadMaskImage();
            }
        }

        private void LoadMaskImage()
        {
            // Read the mask image
            imageViewerMask.Image.ReadFile(maskImagePath.Text);
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            LoadSourceImage();
            LoadMaskImage();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0)
            {
                if (imageViewer1.Roi[0].Type == ContourType.Point)
                {
                    // Get the point from the viewer.
                    PointContour point = (PointContour)imageViewer1.Roi[0].Shape;

                    // Set the mask offset.
                    imageViewerMask.Image.MaskOffset.Initialize(point.X - imageViewerMask.Image.Width / 2, point.Y - imageViewerMask.Height / 2);

                    // Mask the image.
                    Algorithms.Mask(imageViewer1.Image, imageViewer2.Image, imageViewerMask.Image);
                }
            }
        }
    }
}