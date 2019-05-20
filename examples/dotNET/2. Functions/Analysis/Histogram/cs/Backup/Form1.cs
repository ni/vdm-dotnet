using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Histogram example
//
// This example demonstrates how to compute the histogram of a region of interest (ROI).
// The example also demonstrates how to set up and use the display tools to interactively
// select and work on different regions in the image.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Histogram
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
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            imageViewer1.Roi.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = imagePath.Text;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "") {
                imagePath.Text = openFileDialog1.FileName;
                // Load the image
                LoadSelectedImage();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            simpleGraph1.ClearData();
            // Compute the histogram of the regions selected
            if (imageViewer1.Roi.Count > 0)
            {
                using (VisionImage mask = new VisionImage())
                {
                    // Find the histogram of a portal of the image in imageViewer1
                    // defined by the Roi of imageViewer1.
                    Algorithms.RoiToMask(mask, imageViewer1.Roi);
                    HistogramReport report = Algorithms.Histogram(imageViewer1.Image, 256, new Range(0, 255), mask);

                    // Plot the histogram on the graph
                    int[] histogram = new int[256];
                    report.Histogram.CopyTo(histogram, 0);
                    // Convert the int[] to a double[], which the graph requires.
                    double[] histogramDouble = Array.ConvertAll<int, double>(histogram, delegate(int i) { return i; });
                    simpleGraph1.PlotY(histogramDouble);
                }
            }
        }

    }
}