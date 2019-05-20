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

// Fusebox Inspection Example
//
// This example uses color pattern matching to inspect a fusebox.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace FuseboxInspection
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Fusebox\");
        private int imageNumber = 0;
        private MatchColorPatternOptions matchColorPatternOptions;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the template image.
            imageViewer2.Image.Type = ImageType.Hsl32;
            imageViewer2.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"));
            
            // Set up the color pattern matching options.
            matchColorPatternOptions = new MatchColorPatternOptions(MatchMode.ShiftInvariant, 2, ImageFeatureMode.ColorAndShape, ColorSensitivity.Low);
            matchColorPatternOptions.ColorWeight = 500;
            matchColorPatternOptions.SearchStrategy = SearchStrategy.Balanced;
            matchColorPatternOptions.MinimumMatchScore = 775;

            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Determine the match mode based on image number.
            if (imageNumber < 9)
            {
                matchColorPatternOptions.MatchMode = MatchMode.ShiftInvariant;
                matchModeLabel.Text = "Shift";
            }
            else
            {
                matchColorPatternOptions.MatchMode = MatchMode.RotationInvariant;
                matchModeLabel.Text = "Rotation";
            }

            // Get the next image.
            VisionImage image = GetNextImage();

            // Start timing.
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Match the template image in the current image.
            Collection<PatternMatch> matches = Algorithms.MatchColorPattern(image, imageViewer2.Image, matchColorPatternOptions);

            // Stop timing.
            stopwatch.Stop();
            timeLabel.Text = stopwatch.ElapsedMilliseconds.ToString();

            // Display the results.
            matchesLabel.Text = matches.Count.ToString();

            // Display the matches found.
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
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "fuse01-" + String.Format("{0:00}", imageNumber) + ".jpg"));
                images.Add(toReturn);
            }
            else
            {
                toReturn = images[imageNumber];
                // Remove any overlays.
                toReturn.Overlays.Default.Clear();
            }

            // Advance the image number to the next image
            imageNumber++;
            if (imageNumber > 16)
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