using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Image Averaging Example
//
// This example demonstrates how to use image averaging to improve the signal/noise
// ratio of noisy images.

namespace ImageAveraging
{
    public partial class Form1 : Form
    {
        private int imageNumber = 0;
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Noisy Images\");
        private VisionImage result = new VisionImage();
        private VisionImage operand = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the first image.
            loadImageButton_Click(loadImageButton, EventArgs.Empty);
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            ReadNoisyImage(imageViewer1.Image, imageNumber);

            // Change the label to indicate the current image number.
            filenameLabel.Text = "noise-" + String.Format("{0:00}", imageNumber) + ".png";

            // Advance to the next image.
            imageNumber++;
            if (imageNumber > 19)
            {
                imageNumber = 0;
            }
        }

        private void ReadNoisyImage(VisionImage image, int index)
        {
            image.ReadFile(System.IO.Path.Combine(imagePath, "noise-" + String.Format("{0:00}", index) + ".png"));
        }

        private void averageButton_Click(object sender, EventArgs e)
        {
            // Set the destination image to I16 to allow for accumulation of the 8-bit values.
            result.Type = ImageType.I16;
            operand.Type = ImageType.I16;

            // Read the first image into the result.
            ReadNoisyImage(result, 0);

            // Initialize index and start processing.
            imageNumber = 1;
            timer1.Enabled = true;
            loadImageButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check to see if all images have been averaged.
            if (imageNumber > 19)
            {
                imageNumber = 0;
                timer1.Enabled = false;
                loadImageButton.Enabled = true;
                return;
            }

            // Initialize averaging buffer to I16 for compatibility with the Result image.
            using (VisionImage average = new VisionImage(ImageType.I16))
            {
                // Read the next image into the operand.
                ReadNoisyImage(operand, imageNumber);

                // Add it to the result image.
                Algorithms.Add(result, operand, result);

                // Perform the average to show the user how much the result has improved so far.
                Algorithms.Divide(result, new PixelValue(imageNumber), average);

                // Change the average type to U8 for display.
                average.Type = ImageType.U8;

                // Display the result in imageViewer2.
                Algorithms.Copy(average, imageViewer2.Image);
            }

            // Increment image index.
            imageNumber++;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // These functions make sure the viewers keep the same position and zoom level.
        void imageViewer1_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            if (!imageViewer2.Center.Equals(imageViewer1.Center))
            {
                imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y);
            }
        }

        void imageViewer1_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            if (!imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo))
            {
                imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y);
            }
        }

        void imageViewer2_ImagePanned(object sender, NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs e)
        {
            if (!imageViewer1.Center.Equals(imageViewer2.Center))
            {
                imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y);
            }
        }

        void imageViewer2_ImageZoomed(object sender, NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs e)
        {
            if (!imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo))
            {
                imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y);
            }
        }
    }
}