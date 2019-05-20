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

// Simple Calibration Example
//
// This example demonstrates how to build a local coordinate system based on the information
// returned by an X-Y-Theta positioning system using the Algorithms.SetSimpleCalibration() method.
// It then finds the template location in the image and transforms the coordinates from the image
// coordinate system to the local system using the Algorithms.ConvertPixelToRealWorldCoordinates() method.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace SimpleCalibration
{
    public partial class Form1 : Form
    {
        private string imagePath;
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private VisionImage template = new VisionImage();
        private Collection<CoordinateSystem> stageMotionInformation = new Collection<CoordinateSystem>();
        private const int maxImageNumber = 11;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the image path
            imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Roundcard\");

            // Load the pattern matching template.
            template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"));
            
            // Initialize the coordinate system data.
            InitializeStageMotionInformation();

            // Enable the timer.
            timer1.Enabled = true;
            timer1.Start();
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the current coordinate system.
            CoordinateSystem coordinateSystem = stageMotionInformation[imageNumber];

            // Display the current coordinate system.
            calibrationOriginPixelX.Text = String.Format("{0:0.0}", coordinateSystem.Origin.X);
            calibrationOriginPixelY.Text = String.Format("{0:0.0}", coordinateSystem.Origin.Y);
            calibrationAngle.Text = String.Format("{0:0.0}", coordinateSystem.Angle);
            calibrationAxisReference.Text = (coordinateSystem.AxisOrientation == AxisOrientation.Direct) ? "Direct" : "Indirect";

            // Get the next image in the sequence.
            VisionImage image = GetNextImage();

            // Set the local coordinate system information using simple calibration.
            Algorithms.SetSimpleCalibration(image, coordinateSystem, new GridDescriptor());

            // Find the location of the fiducial in the image.
            MatchPatternOptions matchOptions = new MatchPatternOptions(MatchMode.RotationInvariant);
            matchOptions.MinimumMatchScore = 600;
            Collection<PatternMatch> matches = Algorithms.MatchPattern(image, template, matchOptions);

            // Convert the match position to real-world coordinates.
            PointContour realWorldPoint = Algorithms.ConvertPixelToRealWorldCoordinates(image, matches[0].Position).Points[0];

            // Display the coordinates of the pattern.
            measurementsPixelX.Text = String.Format("{0:0.0}", matches[0].Position.X);
            measurementsPixelY.Text = String.Format("{0:0.0}", matches[0].Position.Y);
            measurementsCalibratedX.Text = String.Format("{0:0.0}", realWorldPoint.X);
            measurementsCalibratedY.Text = String.Format("{0:0.0}", realWorldPoint.Y);

            // Overlay the position of the pattern match.
            // First draw the bounding box.
            image.Overlays.Default.AddPolygon(new PolygonContour(matches[0].Corners), Rgb32Value.RedColor);
            // Now draw the center point.
            image.Overlays.Default.AddOval(new OvalContour(matches[0].Position.X - 5, matches[0].Position.Y - 5, 11, 11), Rgb32Value.RedColor);
            // Finally draw the crosshair.
            image.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X - 10, matches[0].Position.Y), new PointContour(matches[0].Position.X + 10, matches[0].Position.Y)), Rgb32Value.RedColor);
            image.Overlays.Default.AddLine(new LineContour(new PointContour(matches[0].Position.X, matches[0].Position.Y - 10), new PointContour(matches[0].Position.X, matches[0].Position.Y + 10)), Rgb32Value.RedColor);

            // Overlay the coordinate system on the image.
            OverlayCoordinateSystem(image.Overlays.Default, coordinateSystem);

            // Display the image.
            imageViewer1.Attach(image);
        }

        private void OverlayCoordinateSystem(Overlay overlay, CoordinateSystem system)
        {
            const int axisLength = 150;

            // Overlay the origin point.
            overlay.AddRectangle(new RectangleContour(system.Origin.X - 2, system.Origin.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);

            // Draw the main axis line.
            double theta = system.Angle * Math.PI / 180.0;
            PointContour axisEnd = new PointContour(system.Origin.X + axisLength * Math.Cos(theta), system.Origin.Y - axisLength * Math.Sin(theta));
            LineContour axisLine = new LineContour(system.Origin, axisEnd);
            overlay.AddLine(axisLine, Rgb32Value.RedColor);
            // Draw an arrow on the end of the line.
            DrawArrow(overlay, axisLine, Rgb32Value.RedColor);

            // Overlay the main axis legend.
            overlay.AddText("X", new PointContour(axisLine.End.X - 10, axisLine.End.Y - 10), Rgb32Value.RedColor, new OverlayTextOptions("Arial", 16));

            // Overlay the secondary axis line.
            if (system.AxisOrientation == AxisOrientation.Indirect)
            {
                theta += Math.PI;
            }
            axisLine.End.Initialize(system.Origin.X - axisLength * Math.Sin(theta), system.Origin.Y - axisLength* Math.Cos(theta));
            overlay.AddLine(axisLine, Rgb32Value.RedColor);
            // Draw an arrow on the end of the line.
            DrawArrow(overlay, axisLine, Rgb32Value.RedColor);

            // Overlay the secondary axis legend.
            overlay.AddText("Y", new PointContour(axisLine.End.X - 10, axisLine.End.Y - 10), Rgb32Value.RedColor, new OverlayTextOptions("Arial", 16));
        }

        // Overlay an arrowhead at the end of a line segment.
        private void DrawArrow(Overlay overlay, LineContour line, Rgb32Value color)
        {
            // This code computes the position of the arrow.
            double dX = line.End.X - line.Start.X;
            double dY = line.End.Y - line.Start.Y;

            double lineAngle = Math.Atan2(dY, dX);

            // The arrow has 3 points.
            Collection<PointContour> arrowPoints = new Collection<PointContour>();
            arrowPoints.Add(line.End);
            arrowPoints.Add(new PointContour(line.End.X - 6 * Math.Cos(lineAngle - .35), line.End.Y - 6 * Math.Sin(lineAngle - .35)));
            arrowPoints.Add(new PointContour(line.End.X - 6 * Math.Cos(lineAngle + .35), line.End.Y - 6 * Math.Sin(lineAngle + .35)));
            overlay.AddPolygon(new PolygonContour(arrowPoints), color, DrawingMode.PaintValue);
        }

        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage();
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Roundcard " + String.Format("{0:00}", imageNumber + 1) + ".tif"));
                images.Add(toReturn);
            }
            else
            {
                toReturn = images[imageNumber];
                // Clear any calibration information or overlays.
                toReturn.RemoveVisionInfo(InfoTypes.Calibration | InfoTypes.Overlay);
            }

            // Advance the image number to the next image
            imageNumber++;
            if (imageNumber >= maxImageNumber)
            {
                imageNumber = 0;
            }
            return toReturn;
        }

        private void InitializeStageMotionInformation()
        {
            // Load information about how the rotate.  This information is used to calculate
            // the real-world position of the fiducial.
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(341, 246), 180));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(342, 279), 174));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(343, 312), 186));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(344, 344), 200));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(394, 244), 190));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(395, 278), 170));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(396, 310), 185));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(450, 343), 170));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(448, 242), 179));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(449, 275), 220));
            stageMotionInformation.Add(new CoordinateSystem(new PointContour(450, 310), 179.5));
        }

        private void delaySlide_ValueChanged(object sender, EventArgs e)
        {
            int newDelay = (int)delaySlide.Value;
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