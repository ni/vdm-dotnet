using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Unwrap Barcode Example
// 
// This example unwraps and reads a circular barcode.
namespace UnwrapBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Unwrap the original image, read the barcode, and display the results.
        private void unwrapBarcodeButton_Click(object sender, EventArgs e)
        {
            // Unwrap annulus region of image.
            Algorithms.Unwrap(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, RectangleOrientation.BaseOutside, InterpolationMethod.Bilinear);

            // Invert unwrapped image for barcode reader.
            Algorithms.Inverse(imageViewer2.Image, imageViewer2.Image);

            // Read the barcode from the wrapped image.
            BarcodeReport report = Algorithms.ReadBarcode(imageViewer2.Image, BarcodeTypes.Code39);

            // Display results
            barcodeString.Text = report.Text;
            confidenceLevel.Text = String.Format("{0:0.0}", report.ConfidenceLevel);
        }

        // This function loads the CD image into memory and displays it.
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            // Read the image.
            imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "CD.jpg"));
            // Update the viewer so the image is loaded before we set the center.
            // We could also set ImmediateUpdates to true to make this happen, but this
            // hurts performance.
            imageViewer1.RefreshImage();
            imageViewer1.Center.Initialize(310, 300);

            // Initialize and display the annulus region of interest.
            imageViewer1.Roi.Clear();
            imageViewer1.Roi.Add(new AnnulusContour(new PointContour(295, -62), 390, 425, 238, 308));

            // Enable the Unwrap Image button.
            unwrapBarcodeButton.Enabled = true;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}