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

// Barcode Example

// This example demonstrates how to use Algorithms.ReadBarcode() to read standard barcodes.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Barcode
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Barcode\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            VisionImage image = GetNextImage();

            // Initialize the barcode roi.
            Roi barcodeRoi = new Roi(new Shape[] { new RectangleContour(9, 100, 340, 48) });

            image.Overlays.Default.AddRoi(barcodeRoi);

            // Read the barcode.
            BarcodeReport report = Algorithms.ReadBarcode(image, BarcodeTypes.Ean13, barcodeRoi, true);

            // Display the result.
            barcodeResult.Text = report.OutputChar1.ToString() + report.OutputChar2.ToString() + report.Text;
            imageViewer1.Attach(image);
        }

        private VisionImage GetNextImage()
        {
            VisionImage nextImage;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                nextImage = new VisionImage();
                nextImage.ReadFile(System.IO.Path.Combine(imagePath, "Image" + String.Format("{0:00}", imageNumber) + ".jpg"));
                images.Add(nextImage);
            }
            else
            {
                nextImage = images[imageNumber];
                // Clear any overlays
                nextImage.Overlays.Default.Clear();
            }

            // Advance the number number to the next image
            imageNumber++;
            if (imageNumber > 6)
            {
                imageNumber = 0;
            }
            return nextImage;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delaySlider1_ValueChanged(object sender, EventArgs e)
        {
            int newDelay = (int)delaySlider1.Value;
            timer1.Interval = (newDelay > 0) ? newDelay : 1;
        }
    }
}