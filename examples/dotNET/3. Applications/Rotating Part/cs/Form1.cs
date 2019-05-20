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
using NationalInstruments.Vision.MeasurementStudioDemo;

// Rotating Part Example
//
// This example shows inspection of a rotating brake drum.  The inspection task
// is to determine if the brake drum contains all holes required for proper
// mounting.  To perform the inspection, the example uses edge detection and a function
// that tracks objects that undergo pure rotation.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace RotatingPart
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Rotate\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private Roi testLines = new Roi();
        private SimpleEdgeOptions simpleEdgeOptions;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Do not delete new lines that the user places.
            imageViewer1.AutoDelete = false;
            EnableRoiSelection();

            // Limit the number of regions to 5.
            imageViewer1.Roi.MaximumContours = 5;

            // Set up the edge options.
            simpleEdgeOptions = new SimpleEdgeOptions();
            simpleEdgeOptions.Threshold = 200;

            // Display the first image.
            imageViewer1.Attach(GetNextImage());
        }

        private void imageViewer1_RoiChanged(object sender, ContoursChangedEventArgs e)
        {
            // Enable the Test Parts button if at least one region is selected.
            testPartsButton.Enabled = imageViewer1.Roi.Count > 0;

            // Update the target display.
            for (int i = 0; i < imageViewer1.Roi.Count; ++i)
            {
                // Enable the indicators.
                GetExpectedTextBox(i).Enabled = true;
                GetActualTextBox(i).Enabled = true;
                GetPassFailLed(i).Enabled = true;
                GetPassFailLed(i).LedColorMode = PassFailLed.ColorMode.RedGreen;

                // Find the number of edges along the line.  This is the expected
                // number of edges.
                Collection<PointContour> linePoints = Algorithms.GetPointsOnLine((LineContour)imageViewer1.Roi[i].Shape);
                Collection<PointContour> edges = Algorithms.SimpleEdge(imageViewer1.Image, linePoints, simpleEdgeOptions);
                GetExpectedTextBox(i).Text = edges.Count.ToString();

            }
            for (int i = imageViewer1.Roi.Count; i < 5; ++i)
            {
                // Disable the indicators.
                GetExpectedTextBox(i).Text = "0";
                GetExpectedTextBox(i).Enabled = false;
                GetActualTextBox(i).Text = "0";
                GetActualTextBox(i).Enabled = false;
                GetPassFailLed(i).Enabled = false;
                GetPassFailLed(i).LedColorMode = PassFailLed.ColorMode.RedGray;
            }
        }

        private void testPartsButton_Click(object sender, EventArgs e)
        {
            // Save the regions on the viewer.
            testLines.Clear();
            foreach (Contour c in imageViewer1.Roi)
            {
                testLines.Add(c.Shape);
            }

            // Clear the viewer regions and disable the Test Parts button.
            imageViewer1.Roi.Clear();
            DisableRoiSelection();
            testPartsButton.Enabled = false;
            resetButton.Enabled = true;

            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Look for rotational shift in the image.
            PointContour imageCenter = new PointContour(image.Width / 2.0, image.Height / 2.0);
            double angle = Algorithms.DetectRotation(images[0], image, imageCenter, imageCenter, (int)(.475 * image.Width));

            // Transform the regions of interest.
            CoordinateTransform transform = new CoordinateTransform(new CoordinateSystem(imageCenter), new CoordinateSystem(imageCenter, angle));
            // Copy to a new Roi so we don't lose the information.
            Roi transformedRoi = new Roi(testLines);
            Algorithms.TransformRoi(transformedRoi, transform);

            // Find the actual number of edges along each line in the image.
            bool allTargetsPassed = true;
            for (int i = 0; i < transformedRoi.Count; ++i)
            {
                Collection<PointContour> linePoints = Algorithms.GetPointsOnLine((LineContour)transformedRoi[i].Shape);
                Collection<PointContour> edges = Algorithms.SimpleEdge(image, linePoints, simpleEdgeOptions);
                
                // Display the results.
                GetActualTextBox(i).Text = edges.Count.ToString();
                foreach (PointContour pt in edges)
                {
                    image.Overlays.Default.AddOval(new OvalContour(pt.X - 2, pt.Y - 2, 5, 5), Rgb32Value.YellowColor, DrawingMode.PaintValue);
                }

                if (Int32.Parse(GetExpectedTextBox(i).Text) == edges.Count)
                {
                    // Part passes.
                    GetPassFailLed(i).Value = true;
                    image.Overlays.Default.AddLine((LineContour)transformedRoi[i].Shape, Rgb32Value.GreenColor);
                }
                else
                {
                    // Part fails.
                    GetPassFailLed(i).Value = false;
                    image.Overlays.Default.AddLine((LineContour)transformedRoi[i].Shape, Rgb32Value.RedColor);
                }
                allTargetsPassed = allTargetsPassed && GetPassFailLed(i).Value;
            }
            globalPassFailLed.Value = allTargetsPassed;
            // Overlay the outside circle of the part.
            OvalContour outsideOval = new OvalContour(image.Width * .025, image.Height * .025, image.Width * .95, image.Height * .95);
            image.Overlays.Default.AddOval(outsideOval, allTargetsPassed ? Rgb32Value.GreenColor : Rgb32Value.RedColor);

            imageViewer1.Attach(image);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // Disable the timer.
            timer1.Enabled = false;
            resetButton.Enabled = false;

            // Reset the output state.
            for (int i = 0; i < 5; ++i)
            {
                GetPassFailLed(i).Value = true;
                GetActualTextBox(i).Text = "0";
                GetExpectedTextBox(i).Text = "0";
            }
            globalPassFailLed.Value = true;

            // Display the first image.
            imageNumber = 0;

            // Enable region of interest selection.
            EnableRoiSelection();
            imageViewer1.Attach(GetNextImage());
            imageViewer1_RoiChanged(imageViewer1, new ContoursChangedEventArgs(ContoursChangedAction.Clear, new Collection<Contour>(), 0, new Collection<Contour>(), 0));
        }

        private TextBox GetExpectedTextBox(int i)
        {
            switch (i)
            {
                case 0:
                    return expectedEdges1;
                case 1:
                    return expectedEdges2;
                case 2:
                    return expectedEdges3;
                case 3:
                    return expectedEdges4;
                case 4:
                    return expectedEdges5;
                default:
                    // This should never happen.
                    return null;
            }
        }

        private TextBox GetActualTextBox(int i)
        {
            switch (i)
            {
                case 0:
                    return actualEdges1;
                case 1:
                    return actualEdges2;
                case 2:
                    return actualEdges3;
                case 3:
                    return actualEdges4;
                case 4:
                    return actualEdges5;
                default:
                    // This should never happen.
                    return null;
            }
        }

        private PassFailLed GetPassFailLed(int i)
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
                default:
                    // This should never happen.
                    return null;
            }
        }

        private void DisableRoiSelection()
        {
            imageViewer1.ToolsShown = ViewerTools.Selection | ViewerTools.ZoomIn | ViewerTools.ZoomOut | ViewerTools.Pan;
            imageViewer1.ActiveTool = ViewerTools.Pan;
        }

        private void EnableRoiSelection()
        {
            imageViewer1.ToolsShown = ViewerTools.Line | ViewerTools.Selection | ViewerTools.ZoomIn | ViewerTools.ZoomOut | ViewerTools.Pan;
            imageViewer1.ActiveTool = ViewerTools.Line;
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
                // Remove any overlays.
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