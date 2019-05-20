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
using NationalInstruments.Vision.MeasurementStudioDemo;

// Gauging Example

// The objective of this gauging application example is to determine if the
// pins on a chip are straight and evenly spaced.  The example uses edge detection
// to find the boundaries of the pins and uses the distances between the edges to
// determine if the pins are uniformly spaced.  The edge locations are also used to
// compute the orientation of the pins.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Gauging
{
    public partial class Form1 : Form
    {
        private static string imagePath;
        private static int imageNumber;
        private static int numberOfPartsInspected;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the image path
            imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Pins\");
            imageNumber = 0;

            // Enable the timer
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image
            VisionImage image = GetNextImage();

            // Find peaks along 3 predetermined rows of the image.  Store the points found
            // along each line in the pointsForRow array.
            Collection<PointContour>[] pointsForRow = new Collection<PointContour>[3];
            int[] yPositions = new int[] { 145, 200, 300 };
            for (int i = 0; i < 3; ++i)
            {
                int yPosition = yPositions[i];
                byte[] rowPixels = image.GetLinePixels(new LineContour(new PointContour(0, yPosition), new PointContour(image.Width - 1, yPosition))).U8;
                double[] rowPixelsDouble = Array.ConvertAll<byte, double>(rowPixels, delegate(byte b) { return (double)b; });
                Collection<PeakValleyReportItem> peakValleyReport = Algorithms.DetectPeaksOrValleys(rowPixelsDouble, PeakOrValley.Peaks, new DetectPeaksOrValleysOptions(19, 70));
                pointsForRow[i] = new Collection<PointContour>();
                foreach (PeakValleyReportItem item in peakValleyReport)
                {
                    pointsForRow[i].Add(new PointContour(item.Location, yPosition));
                }
            }

            // Find the top and bottom points nearest each point found along the middle line.
            double[] angles = new double[12];
            Collection<PointContour> points = new Collection<PointContour>();
            points.Add(new PointContour());
            points.Add(new PointContour());
            bool allPassed = true;
            Collection<PointContour>[] pinPoints = new Collection<PointContour>[12];
            for (int i = 0; i < pointsForRow[0].Count; ++i)
            {
                // pinPoints[i][j] denotes the jth point of the ith pin.
                pinPoints[i] = new Collection<PointContour>();
                pinPoints[i].Add(new PointContour());
                pinPoints[i].Add(pointsForRow[1][i]);
                pinPoints[i].Add(new PointContour());
                points[0] = pinPoints[i][1];

                // For the top and bottom rows...
                foreach (int j in new int[2]{0, 2}) {
                    int minIndex = -1;
                    double minDistance = double.PositiveInfinity;
                    
                    // For each point along that row...
                    for (int k = 0; k < pointsForRow[j].Count; ++k)
                    {
                        // Compute the distance between this point and the current point in the center row.
                        points[1] = pointsForRow[j][k];
                        double distance = Algorithms.FindPointDistances(points)[0];

                        // The point with the smallest distance should be associated with the pin
                        // corresponding to the center point.
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minIndex = k;
                        }
                    }

                    // Save the point.
                    pinPoints[i][j] = pointsForRow[j][minIndex];
                }
                // Use the information found to determine if the angle is within range.
                points[0] = pinPoints[i][0];
                points[1] = pinPoints[i][2];
                angles[i] = Algorithms.GetAngles(points, pinPoints[i][1])[0];
                // If the angle is within [180-tolerance, 180+tolerance], the part
                // passes inspection.
                GetLed(i).Value = (angles[i] >= (180 - (double)tolerance.Value) && angles[i] <= (180 + (double)tolerance.Value));
                allPassed &= GetLed(i).Value;
            }

            // Because not all images have 12 pins, set any remaining indicators to pass.
            for (int i = pointsForRow[0].Count; i < 12; ++i)
            {
                GetLed(i).Value = true;
            }

            // Display results
            partOK.Value = allPassed;
            numberOfPartsInspected++;
            partsInspected.Text = numberOfPartsInspected.ToString();

            if (imageResultsMode.Checked)
            {
                // Display the overlay
                OverlayTextOptions textOptions = new OverlayTextOptions();
                textOptions.HorizontalAlignment = HorizontalTextAlignment.Center;
                textOptions.FontSize = 14;

                // Overlay the pin positions on the image
                for (int i = 0; i < pointsForRow[0].Count; ++i)
                {
                    if (GetLed(i).Value)
                    {
                        // Part passed

                        // Draw a circle at each point on the pin.
                        for (int j = 0; j < 3; ++j)
                        {
                            image.Overlays.Default.AddOval(new OvalContour(pinPoints[i][j].X - 2, pinPoints[i][j].Y - 2, 4, 4), Rgb32Value.GreenColor, DrawingMode.PaintValue);
                        }

                        // Connect the points
                        image.Overlays.Default.AddPolyline(new PolylineContour(pinPoints[i]), Rgb32Value.GreenColor);
                        image.Overlays.Default.AddText(String.Format("{0:0.0}", angles[i]), new PointContour(pinPoints[i][1].X, 100), Rgb32Value.GreenColor, textOptions);
                    }
                    else
                    {
                        // Part failed
                        // Overlay a rectangle with an X inside
                        RectangleContour rect = new RectangleContour(pinPoints[i][1].X - 20, 120, 40, 210);
                        image.Overlays.Default.AddRectangle(rect, Rgb32Value.RedColor, DrawingMode.DrawValue);
                        image.Overlays.Default.AddLine(new LineContour(new PointContour(rect.Left, rect.Top), new PointContour(rect.Left + rect.Width, rect.Top + rect.Height)), Rgb32Value.RedColor);
                        image.Overlays.Default.AddLine(new LineContour(new PointContour(rect.Left + rect.Width, rect.Top), new PointContour(rect.Left, rect.Top + rect.Height)), Rgb32Value.RedColor);
                    }
                }
            }

            if (imageResultsMode.Checked || imageMode.Checked)
            {
                // Display the image
                Algorithms.Copy(image, imageViewer1.Image);
            }
        }

        private PassFailLed GetLed(int i)
        {
            switch (i)
            {
                case 0:
                    return passFailLed1;
                case 1:
                    return passFailLed2;
                case 2:
                    return passFailLed3;
                case 3:
                    return passFailLed4;
                case 4:
                    return passFailLed5;
                case 5:
                    return passFailLed6;
                case 6:
                    return passFailLed7;
                case 7:
                    return passFailLed8;
                case 8:
                    return passFailLed9;
                case 9:
                    return passFailLed10;
                case 10:
                    return passFailLed11;
                default:
                    return passFailLed12;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage();
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "pins-" + String.Format("{0:00}", imageNumber) + ".bmp"));
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
            if (imageNumber > 21)
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
    }
}