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

// BCG Transform Example
//
// This example demonstrates how to apply a brightness, contrast, and gamma correction to an
// image.  These transformations are usually applied to an image to improve its quality as
// required by a particular application.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace BcgTransform
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
            LoadImage();
        }

        private void PerformBcg()
        {
            // Make sure the image has been loaded.
            if (imageViewer1.Image.Width > 0)
            {
                // Set up the options.
                BcgOptions bcgOptions = new BcgOptions(brightnessSlide.Value, contrastSlide.Value, gammaSlide.Value);

                // Perform the BCG transform using the parameters set by the user.
                Algorithms.BcgTransform(imageViewer1.Image, imageViewer2.Image, bcgOptions);
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            // Read and display a file and perform the BcgTransform.
            imageViewer1.Image.ReadFile(imagePath.Text);
            PerformBcg();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                LoadImage();
            }
        }

        // The following four functions keep the two image viewers in sync.
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
        private void brightnessSlide_ValueChanged(object sender, EventArgs e)
        {
            if (brightnessUpDown.Value != (decimal)brightnessSlide.Value)
            {
                brightnessUpDown.Value = (decimal)brightnessSlide.Value;
            }
            PerformBcg();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            brightnessSlide.Value = 171;
            contrastSlide.Value = 56;
            gammaSlide.Value = 2;
        }

        private void brightnessUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((decimal)brightnessSlide.Value != brightnessUpDown.Value)
            {
                brightnessSlide.Value = (double)brightnessUpDown.Value;
            }
        }

        private void contrastSlide_ValueChanged(object sender, EventArgs e)
        {
            if (contrastUpDown.Value != (decimal)contrastSlide.Value)
            {
                contrastUpDown.Value = (decimal)contrastSlide.Value;
            }
            PerformBcg();
        }

        private void contrastUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((decimal)contrastSlide.Value != contrastUpDown.Value)
            {
                contrastSlide.Value = (double)contrastUpDown.Value;
            }
        }

        private void gammaSlide_ValueChanged(object sender, EventArgs e)
        {
            if (gammaUpDown.Value != (decimal)gammaSlide.Value)
            {
                gammaUpDown.Value = (decimal)gammaSlide.Value;
            }
            PerformBcg();
        }

        private void gammaUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((decimal)gammaSlide.Value != gammaUpDown.Value)
            {
                gammaSlide.Value = (double)gammaUpDown.Value;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}