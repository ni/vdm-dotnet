using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System.Collections.ObjectModel;

// Label Example
//
// This example shows how to label a binary image that contains multiple particles.
// The labeling proecssing assigns a unique value to all pixels that belong to a particle.
// Some processing functions in NI Vision require the input binary image to be labeled.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Label
{
    public partial class Form1 : Form
    {
        private Form2 form2 = null;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
            form2.Show();
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
        }

        private void simpleRangeSelect1_RangeChanged(object sender, NationalInstruments.Vision.MeasurementStudioDemo.RangeChangedEventArgs e)
        {
            ProcessImage();
        }

        public void ProcessImage()
        {
            VisionImage beforeImage = form2.BeforeImage;
            VisionImage afterImage = form2.AfterImage;

            // If an image is loaded
            if (beforeImage.Width > 0 && beforeImage.Height > 0)
            {
                // Threshold the image.
                Algorithms.Threshold(beforeImage, afterImage, new Range(simpleRangeSelect1.Minimum, simpleRangeSelect1.Maximum));

                // Label the image.
                int numParticles = Algorithms.Label(afterImage, afterImage, connectivity4Button.Checked ? Connectivity.Connectivity4 : Connectivity.Connectivity8);
                numberOfParticles.Text = numParticles.ToString();
            }
        }

        // If any inputs have changed, update the image
        private void connectivity8Button_CheckedChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        private void connectivity4Button_CheckedChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        // Click the Browse button to open the file dialog
        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;

                // Load the image
                LoadSelectedImage();
            }
        }

        // Click the Load Image button to read an image
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            // Load an image using ReadFile
            form2.BeforeImage.ReadFile(imagePath.Text);

            // Histogram the image
            HistogramReport report = Algorithms.Histogram(form2.BeforeImage);
            int[] histogram = new int[256];
            report.Histogram.CopyTo(histogram, 0);
            // Convert the int[] to a double[], which the graph requires.
            double[] histogramDouble = Array.ConvertAll<int, double>(histogram, delegate(int i) { return i; });
            simpleRangeSelect1.PlotY(histogramDouble);

            // Process the image
            ProcessImage();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }

}