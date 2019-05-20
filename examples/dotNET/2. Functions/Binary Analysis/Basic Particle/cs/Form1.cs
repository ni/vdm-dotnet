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

// Basic Particle Example
//
// This example introduces processing blob area (particle analysis).  The example
// uses the threshold function, which converts a grayscale image into a binary image.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace BasicParticle
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

            afterImage.Overlays.Default.DefaultColor = Rgb32Value.GreenColor;
            // If an image is loaded
            if (beforeImage.Width > 0 && beforeImage.Height > 0)
            {
                // Threshold the image.
                Algorithms.Threshold(beforeImage, afterImage, new Range(simpleRangeSelect1.Minimum, simpleRangeSelect1.Maximum));

                // Perform the particle report operation
                Collection<ParticleReport> reports = Algorithms.ParticleReport(afterImage, connectivity4Button.Checked ? Connectivity.Connectivity4 : Connectivity.Connectivity8);

                // Display the number of particles found
                numberOfParticles.Text = reports.Count.ToString();

                // Overlay the information BasicParticle found.
                afterImage.Overlays.Default.Clear();
                foreach (ParticleReport report in reports)
                {
                    // Overlay the bounding rectangle.
                    afterImage.Overlays.Default.AddRectangle(report.BoundingRect, Rgb32Value.GreenColor, DrawingMode.DrawValue);

                    // Overlay the particle area at user's request.
                    if (showParticleArea.Checked)
                    {
                        afterImage.Overlays.Default.AddText(string.Format("{0:0.00}", report.Area), new PointContour(report.BoundingRect.Left, report.BoundingRect.Top));
                    }
                }
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

        private void showParticleArea_CheckedChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        // Click the Browse button to open the file dialog
        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = imagePath.Text;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                imagePath.Text = openFileDialog1.FileName;

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