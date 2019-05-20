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

// Threshold example

// This example illustrates different thresholding algorithms.
// Local thresholding calculates local statistics for each pixel in an image.
// Based on the calculation result, the algorithm categorizes the pixel as part
// of a particle or the background.  Automatic thresholding uses the histogram of
// an image to compute a single threshold value for the entire image.  Manual
// thresholding uses a specified range of values to compute a threshold value for
// the image.  Refer to the NI Vision Concept Manual for more information about
// thresholding algorithms.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Threshold
{
    public partial class Form1 : Form
    {
        private bool ready = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            localObjectBox.SelectedIndex = 1;
            localMethodBox.SelectedIndex = 0;
            autoObjectBox.SelectedIndex = 1;
            autoMethodBox.SelectedIndex = 0;
            tabControl1.SelectedIndex = 0;
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "lcd.jpg");
            LoadSelectedImage();
        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        // Load an image using ReadFile
        private void LoadSelectedImage()
        {
            // Read the image
            imageViewerOriginal.Image.ReadFile(imagePath.Text);
            // Ensure the window size is smaller than the image size.
            if (localXSize.Value >= imageViewerOriginal.Image.Width)
            {
                localXSize.Value = imageViewerOriginal.Image.Width - 1;
            }
            if (localYSize.Value >= imageViewerOriginal.Image.Height)
            {
                localYSize.Value = imageViewerOriginal.Image.Height - 1;
            }
            ready = true;
            DoThreshold();
        }

        private void DoThreshold()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    // Local threshold
                    LocalThresholdOptions options = new LocalThresholdOptions();
                    options.DeviationWeight = (double)niblackUpDown.Value;
                    if (localMethodBox.SelectedIndex == 0)
                    {
                        options.Method = LocalThresholdMethod.NiBlack;
                    }
                    else
                    {
                        options.Method = LocalThresholdMethod.BackgroundCorrection;
                    }
                    if (localObjectBox.SelectedIndex == 0)
                    {
                        options.ParticleType = ParticleType.Bright;
                    }
                    else
                    {
                        options.ParticleType = ParticleType.Dark;
                    }
                    options.WindowWidth = (uint)localXSize.Value;
                    options.WindowHeight = (uint)localYSize.Value;
                    Algorithms.LocalThreshold(imageViewerOriginal.Image, imageViewerThresholded.Image, options);
                    break;
                case 1:
                    // Auto threshold
                    // If we are looking for dark objects and the auto method is metric,
                    // moment, or interclass variance we need to take the inverse of the image
                    // first because AutoThreshold() looks for the bright objects for
                    // these methods.
                    Collection<ThresholdData> thresholdData;
                    if (autoObjectBox.SelectedIndex == 1 && autoObjectBox.SelectedIndex > 1)
                    {
                        // Use the thresholded image to temporarily hold the inverse image.  It
                        // will get set back to the threshold image after AutoThreshold() is called.
                        Algorithms.Inverse(imageViewerOriginal.Image, imageViewerThresholded.Image);
                        thresholdData = Algorithms.AutoThreshold(imageViewerThresholded.Image, imageViewerThresholded.Image, 2, (ThresholdMethod)autoMethodBox.SelectedIndex);
                    }
                    else
                    {
                        thresholdData = Algorithms.AutoThreshold(imageViewerOriginal.Image, imageViewerThresholded.Image, 2, (ThresholdMethod)autoMethodBox.SelectedIndex);
                    }
                    Range thresholdRange;
                    if (autoObjectBox.SelectedIndex == 1)
                    {
                        // Look for dark objects
                        thresholdRange = new Range(0, thresholdData[0].Range.Maximum);
                    }
                    else
                    {
                        // Look for bright objects
                        thresholdRange = new Range(thresholdData[0].Range.Minimum, 255);
                    }
                    Algorithms.Threshold(imageViewerOriginal.Image, imageViewerThresholded.Image, thresholdRange);
                    break;
                case 2:
                    // Manual threshold
                    Algorithms.Threshold(imageViewerOriginal.Image, imageViewerThresholded.Image, new Range(manualMinimumSlide.Value, manualMaximumSlide.Value));
                    break;
            }
        }

        private void manualMinimumSlide_ValueChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void manualMaximumSlide_ValueChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        // Click the Browse button to open the file dialog
        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            ready = false;
            dialog.Filter = "AIPD Images (*.apd;*.aipd)|*.apd;*.aipd|BMP Images (*.bmp)|*.bmp|JPEG Images (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Images (*.png)|*.png|TIFF Images (*.tif;*.tiff)|*.tif;*.tiff|All Image Files|*.apd;*.aipd;*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files (*.*)|*||";
            dialog.FilterIndex = 6;
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK) {
                imagePath.Text = dialog.FileName;
                // Load the image
                LoadSelectedImage();
            }
        }

        private void localObjectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void localMethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void niblackUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void localXSize_ValueChanged(object sender, EventArgs e)
        {
            if (localXSize.Value >= imageViewerOriginal.Image.Width)
            {
                localXSize.Value = imageViewerOriginal.Image.Width - 1;
            }
            else if (localXSize.Value < 3)
            {
                localXSize.Value = 3;
            }
            if (ready)
            {
                DoThreshold();
            }
        }

        private void localYSize_ValueChanged(object sender, EventArgs e)
        {
            if (localYSize.Value >= imageViewerOriginal.Image.Height)
            {
                localYSize.Value = imageViewerOriginal.Image.Height - 1;
            }
            else if (localYSize.Value < 3)
            {
                localYSize.Value = 3;
            }
            if (ready)
            {
                DoThreshold();
            }
        }

        private void autoObjectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void autoMethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                DoThreshold();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}