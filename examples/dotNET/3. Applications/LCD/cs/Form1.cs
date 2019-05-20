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

// LCD Example
//
// This example shows how to use the NI Vision seven-segment display reader methods
// to read values displayed on an LCD panel.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace LCD
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"LCD\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private Roi lcdRoi;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Overlay the LCD segment Roi.
            image.Overlays.Default.AddRoi(lcdRoi);

            // Read the LCD.
            LcdReport report = Algorithms.ReadLcd(image, lcdRoi);
            
            // Display the results.
            number.Text = report.Text;
            segments1.SetSegments(report.SegmentInfo[0]);
            segments2.SetSegments(report.SegmentInfo[1]);
            segments3.SetSegments(report.SegmentInfo[2]);
            segments4.SetSegments(report.SegmentInfo[3]);

            imageViewer1.Attach(image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Use FindLcdSegments to get the appropriate Roi.
            lcdRoi = Algorithms.FindLcdSegments(GetNextImage(), new RectangleContour(27, 55, 243, 92));
            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }
        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage();
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Image" + String.Format("{0:00}", imageNumber) + ".jpg"));
                images.Add(toReturn);
            }
            else
            {
                toReturn = images[imageNumber];
                // Clear any overlays
                toReturn.Overlays.Default.Clear();
            }

            // Advance the image number to the next image
            imageNumber++;
            if (imageNumber > 11)
            {
                imageNumber = 0;
            }
            return toReturn;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delaySlider1_ValueChanged(object sender, EventArgs e)
        {
            int newDelay = (int)delaySlider1.Value;
            if (newDelay == 0)
            {
                newDelay = 1;
            }
            timer1.Interval = newDelay;
        }
    }
}