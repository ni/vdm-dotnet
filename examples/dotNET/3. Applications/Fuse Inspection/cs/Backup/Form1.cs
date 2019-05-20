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
using NationalInstruments.Vision.WindowsForms;

// Fuse Inspection Example
//
// This example loads a reference image used to define the coordinate system for the
// inspection task.  It then loads two templates containing the defining features of the
// object.  The example loads a new image, finds the new coordinate system by locating the
// edges of the fuse, matches the region of inspection against the template images,
// and returns the results.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace FuseInspection
{
    public partial class Form1 : Form
    {
        // Global variables
        private string imagePath;
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private RotatedRectangleContour primaryAxisRectangle;
        private RotatedRectangleContour secondaryAxisRectangle;
        private FindTransformRectsOptions findTransformRectsOptions;
        private CoordinateTransform transform;
        private Roi matchPatternRoi;
        private MatchPatternOptions matchPatternOptions;
        private OverlayTextOptions overlayTextOptions;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Fuse\");
            imageViewer1.Attach(GetNextImage());
        }

        private void defineCoordinateSystemButton_Click(object sender, EventArgs e)
        {
            // Initialize search rectangles.
            primaryAxisRectangle = new RotatedRectangleContour(new PointContour(191, 275), 378, 150, 0);
            secondaryAxisRectangle = new RotatedRectangleContour(new PointContour(170, 205), 300, 250, 0);

            // Initialize the options used for the coordinate transformation detection.
            findTransformRectsOptions = new FindTransformRectsOptions(FindReferenceDirection.BottomToTopIndirect, true, false, false, true);
            findTransformRectsOptions.PrimaryStraightEdgeOptions.SearchMode = StraightEdgeSearchMode.FirstRakeEdges;
            findTransformRectsOptions.PrimaryStraightEdgeOptions.AngleRange = 45;
            findTransformRectsOptions.PrimaryStraightEdgeOptions.StepSize = 5;
            findTransformRectsOptions.SecondaryStraightEdgeOptions.SearchMode = StraightEdgeSearchMode.FirstRakeEdges;
            findTransformRectsOptions.SecondaryStraightEdgeOptions.AngleRange = 45;
            findTransformRectsOptions.SecondaryStraightEdgeOptions.StepSize = 5;
            
            // Locate the coordinate system in the reference image.
            FindTransformReport transformReport = Algorithms.FindTransformRectangles(imageViewer1.Image, new Roi(new Shape[] { primaryAxisRectangle }), new Roi(new Shape[] { secondaryAxisRectangle }), FindTransformMode.FindReference, new CoordinateTransform(), findTransformRectsOptions);
            transform = transformReport.Transform;

            // Turn on search lines and edges found overlays.
            findTransformRectsOptions.ShowSearchLines = true;
            findTransformRectsOptions.ShowEdgesFound = true;

            // Update buttons
            defineCoordinateSystemButton.Enabled = false;
            defineTemplatesButton.Enabled = true;
        }

        private void defineTemplatesButton_Click(object sender, EventArgs e)
        {
            // Load templates that represent a good part.  Because the part is not symmetric,
            // two templates are necessary for representing the two possible aspects of a valid (intact) fuse.
            imageViewer2.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template 1.png"));
            imageViewer3.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template 2.png"));

            // Update buttons
            defineTemplatesButton.Enabled = false;
            runButton.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage curImage = GetNextImage();
            imageNumberLabel.Text = imageNumber.ToString();

            // Locate the coordinate system in the reference image.
            FindTransformReport transformReport = Algorithms.FindTransformRectangles(curImage, new Roi(new Shape[] { primaryAxisRectangle }), new Roi(new Shape[] { secondaryAxisRectangle }), FindTransformMode.UpdateTransform, transform, findTransformRectsOptions);
            // Transform the Roi with the found transform.
            Roi tempRoi = new Roi(matchPatternRoi);
            Algorithms.TransformRoi(tempRoi, transformReport.Transform);
            RectangleContour searchArea = ((RotatedRectangleContour)tempRoi[0].Shape).GetBoundingRectangle();
            // Overlay the search area.
            curImage.Overlays.Default.AddRoi(tempRoi);
            // Try to match the first template.
            bool found = false;
            Collection<PatternMatch> matches = Algorithms.MatchPattern(curImage, imageViewer2.Image, matchPatternOptions, searchArea);
            if (matches.Count > 0)
            {
                found = true;
                // Overlay the results.
                // First draw the bounding box.
                curImage.Overlays.Default.AddPolygon(new PolygonContour(matches[0].Corners), Rgb32Value.RedColor);
                // Now draw the center point.
                curImage.Overlays.Default.AddOval(new OvalContour(matches[0].Position.X - 5, matches[0].Position.Y - 5, 11, 11), Rgb32Value.RedColor, DrawingMode.DrawValue);
                // Finally draw the crosshair.
                curImage.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X - 10, matches[0].Position.Y), new PointContour(matches[0].Position.X + 10, matches[0].Position.Y)), Rgb32Value.RedColor);
                curImage.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X, matches[0].Position.Y - 10), new PointContour(matches[0].Position.X, matches[0].Position.Y + 10)), Rgb32Value.RedColor);
            }
            else
            {
                // Try to match the second template.
                matches = Algorithms.MatchPattern(curImage, imageViewer3.Image, matchPatternOptions, searchArea);
                if (matches.Count > 0)
                {
                    found = true;
                    // Overlay the results.
                    // First draw the bounding box.
                    curImage.Overlays.Default.AddPolygon(new PolygonContour(matches[0].Corners), Rgb32Value.RedColor);
                    // Now draw the center point.
                    curImage.Overlays.Default.AddOval(new OvalContour(matches[0].Position.X - 5, matches[0].Position.Y - 5, 11, 11), Rgb32Value.RedColor, DrawingMode.DrawValue);
                    // Finally draw the crosshair.
                    curImage.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X - 10, matches[0].Position.Y), new PointContour(matches[0].Position.X + 10, matches[0].Position.Y)), Rgb32Value.RedColor);
                    curImage.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X, matches[0].Position.Y - 10), new PointContour(matches[0].Position.X, matches[0].Position.Y + 10)), Rgb32Value.RedColor);
                }
            }
            passOrFail.Value = found;
            string overlayText;
            Rgb32Value overlayColor;
            if (found)
            {
                overlayColor = Rgb32Value.GreenColor;
                overlayText = "PASS";
            }
            else
            {
                overlayColor = Rgb32Value.RedColor;
                overlayText = "FAIL";
            }
            curImage.Overlays.Default.AddText(overlayText, new PointContour(380, 395), overlayColor, overlayTextOptions);
            
            // Display the resulting image.
            imageViewer1.Attach(curImage);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            // Initialize the pattern matching options.
            matchPatternRoi = new Roi(new Shape[]{new RotatedRectangleContour(new PointContour(210, 220), 130, 110, 0)});
            matchPatternOptions = new MatchPatternOptions(MatchMode.RotationInvariant, 1);
            matchPatternOptions.MinimumMatchScore = 650;
            matchPatternOptions.RotationAngleRanges.Add(new Range(-40, 40));
            matchPatternOptions.SubpixelAccuracy = true;
            
            // Initialize text options.
            overlayTextOptions = new OverlayTextOptions("Arial Black", 36);

            // Update buttons.
            runButton.Enabled = false;

            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private VisionImage GetNextImage()
        {
            VisionImage nextImage;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                nextImage = new VisionImage();
                nextImage.ReadFile(System.IO.Path.Combine(imagePath, "Fuse " + String.Format("{0:00}", imageNumber) + ".tif"));
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
            if (imageNumber > 21)
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
            int newInterval = (int)delaySlider1.Value;
            timer1.Interval = (newInterval > 0) ? newInterval : 1;
        }
    }
}