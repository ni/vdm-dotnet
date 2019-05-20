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

// Blister Pack Inspection Example
//
// This example uses color pattern matching with an ImageFeatureMode of Color
// to inspect pills inside a blister pack.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace BlisterPackInspection
{
    public partial class Form1 : Form
    {
        private string imagePath;
        private int imageNumber;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private VisionImage template = new VisionImage(ImageType.Hsl32);
        private MatchColorPatternOptions matchOptions = new MatchColorPatternOptions(MatchMode.ShiftInvariant, 12, ImageFeatureMode.Color, ColorSensitivity.Low);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the image path
            imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Blister\");
            imageNumber = 0;

            // Load the template image.
            template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"));

            // Set up the color pattern matching options
            matchOptions.ColorWeight = 300;
            matchOptions.MinimumMatchScore = 500;
            matchOptions.SearchStrategy = SearchStrategy.Aggressive;

            // Enable the timer
            timer1.Enabled = true;
            timer1.Start();
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Start timing.
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Match the template image in the current image.
            Collection<PatternMatch> matches = Algorithms.MatchColorPattern(image, template, matchOptions);

            // Determine if this part passes or fails
            if (matches.Count == matchOptions.NumberOfMatchesRequested)
            {
                // All pills are present, so this part passes inspection.
                passFailLed.Value = true;
            }
            else
            {
                // Some pills are missing, so this part fails inspection.
                passFailLed.Value = false;
            }

            // Stop timing.
            stopwatch.Stop();
            timeTaken.Text = String.Format("{0:0}", stopwatch.ElapsedMilliseconds);

            // Display the results.
            matchesFound.Text = matches.Count.ToString();
            foreach (PatternMatch match in matches)
            {
                // First draw the bounding box.
                image.Overlays.Default.AddPolygon(new PolygonContour(match.Corners), Rgb32Value.RedColor);
                // Now draw the center point.
                image.Overlays.Default.AddOval(new OvalContour(match.Position.X - 5, match.Position.Y - 5, 11, 11), Rgb32Value.RedColor);
                // Finally draw the crosshair.
                image.Overlays.Default.AddLine(new LineContour(new PointContour(match.Position.X - 10, match.Position.Y), new PointContour(match.Position.X + 10, match.Position.Y)), Rgb32Value.RedColor);
                image.Overlays.Default.AddLine(new LineContour(new PointContour(match.Position.X, match.Position.Y - 10), new PointContour(match.Position.X, match.Position.Y + 10)), Rgb32Value.RedColor);
            }
            imageViewer1.Attach(image);
        }

        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage(ImageType.Hsl32);
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Blister " + String.Format("{0:00}", imageNumber) + ".jpg"));
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
            if (imageNumber > 14)
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