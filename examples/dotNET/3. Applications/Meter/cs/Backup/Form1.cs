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

// Meter Example
//
// This example uses Algorithms.ReadMeter() to read the position of a needle.
// This method has many applications, one of which is to calibrate speedometers and
// gauges in the automotive industry.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Meter
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Meter\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Create the meter arc (stores information about the meter).
            MeterArc arc = Algorithms.GetMeterArc(MeterNeedleColor.DarkOnLight,
                new LineContour(new PointContour(53, 75), new PointContour(101, 134)),
                new LineContour(new PointContour(203, 75), new PointContour(155, 138)));

            // Read the meter.
            MeterReport report = Algorithms.ReadMeter(image, arc);

            // Display results.
            image.Overlays.Default.AddOval(new OvalContour(report.EndOfNeedle.X - 2, report.EndOfNeedle.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);
            speedKnob1.Value = report.Percentage;
            speedBox.Text = String.Format("{0:0.0}", report.Percentage);
            imageViewer1.Attach(image);
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
            if (imageNumber > 17)
            {
                imageNumber = 0;
            }
            return toReturn;
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}