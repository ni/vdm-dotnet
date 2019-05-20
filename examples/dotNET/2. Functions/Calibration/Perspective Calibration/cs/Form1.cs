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

// Perspective Calibration Example
//
// This example illustrates how to use a calibration grid to calibrate an image for perspective
// distortion.  The example converts the locations of features found in the image into real-world
// locations.  It uses these locations to perform accurate measurements in real-world units.
//
// The example loads a template image of a grid that is used to calibrate a system, learns the
// calibration from that grid, and measures distances in a distorted image with the learned
// calibration information.

namespace PerspectiveCalibration
{
    public partial class Form1 : Form
    {
        private VisionImage calibrationTemplate = new VisionImage();
        private VisionImage testImage = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void loadCalibrationButton_Click(object sender, EventArgs e)
        {
            // Load the calibration grid image.
            calibrationTemplate.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Calibration grid.tif"));
            imageViewer1.Attach(calibrationTemplate);

            // Update command buttons.
            learnCalibrationButton.Enabled = true;
            measureDistancesButton.Enabled = false;
        }

        private void learnCalibrationButton_Click(object sender, EventArgs e)
        {
            // Set up the grid options.
            CalibrationGridOptions gridOptions = new CalibrationGridOptions(new GridDescriptor(.5, .5), new Range(0, 128));

            // Setup the learn calibration options.
            LearnCalibrationOptions learnOptions = new LearnCalibrationOptions(new CoordinateSystem(), CalibrationMethod.Perspective, ScalingMethod.ScaleToFit, CalibrationCorrectionMode.FullImage);
            learnOptions.LearnCorrectionTable = false;
            learnOptions.LearnErrorMap = false;

            // Learn the calibration from the grid image.
            Algorithms.LearnCalibrationGrid(imageViewer1.Image, gridOptions, learnOptions);

            // Update command buttons.
            learnCalibrationButton.Enabled = false;
            measureDistancesButton.Enabled = true;
        }

        enum Direction {
            Horizontal,
            Vertical
        }

        private void measureDistancesButton_Click(object sender, EventArgs e)
        {
            // In a point-based measurement, it is not necessary to correct the image.  The
            // coordinates of the fiducial points can be found and transformed to real-world
            // coordinates.  All point measurements can then be performed on these
            // coordinates.
            
            // Load the Distortion Target image.
            testImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Distortion target.tif"));

            // Copy the calibration information from the calibrated image to the test image.
            Algorithms.CopyCalibrationInformation(calibrationTemplate, testImage);

            // Initialize the two search lines.
            Collection<LineContour> searchLines = new Collection<LineContour>();
            searchLines.Add(new LineContour(new PointContour(150, 250), new PointContour(490, 248.57)));
            searchLines.Add(new LineContour(new PointContour(318, 165), new PointContour(319.62, 340)));

            foreach (Direction d in new Direction[]{Direction.Horizontal, Direction.Vertical})
            {
                // Detect the edges along a line and convert the coordinates of the edge points
                // to real-world coordinates.
                EdgeReport report = Algorithms.EdgeTool(testImage, new Roi(new Shape[] { searchLines[d == Direction.Horizontal ? 0 : 1] }), EdgeProcess.All);
                Collection<PointContour> pixelPoints = new Collection<PointContour>();
                Collection<PointContour> realWorldPoints = new Collection<PointContour>();
                foreach (EdgeInfo info in report.Edges)
                {
                    pixelPoints.Add(info.Position);
                    realWorldPoints.Add(info.CalibratedPosition);
                }
                Collection<PointContour> realWorldPoints2 = Algorithms.ConvertPixelToRealWorldCoordinates(testImage, pixelPoints).Points;
                MeasureDistortionTarget(testImage, pixelPoints, realWorldPoints, d);
            }

            imageViewer1.Attach(testImage);
        }

        private void MeasureDistortionTarget(VisionImage image, Collection<PointContour> pixelPoints, Collection<PointContour> realWorldPoints, Direction d)
        {
            OverlayTextOptions overlayOptions = new OverlayTextOptions("Arial", 16);
            overlayOptions.TextDecoration.Bold = true;
            if (d == Direction.Horizontal)
            {
                overlayOptions.HorizontalAlignment = HorizontalTextAlignment.Right;
                overlayOptions.VerticalAlignment = VerticalTextAlignment.Baseline;
            }
            else
            {
                overlayOptions.HorizontalAlignment = HorizontalTextAlignment.Center;
                overlayOptions.VerticalAlignment = VerticalTextAlignment.Bottom;
            }
            for (int i = 0; i < 3; ++i)
            {
                // Measure the real-world distance.
                Collection<PointContour> realWorldDistancePoints = new Collection<PointContour>();
                realWorldDistancePoints.Add(realWorldPoints[2 * i]);
                realWorldDistancePoints.Add(realWorldPoints[9 - 2 * i]);
                double realWorldDistance = Algorithms.FindPointDistances(realWorldDistancePoints)[0];

                // Find the line to overlay.
                LineContour line = new LineContour();
                line.Start = pixelPoints[2 * i];
                line.End = pixelPoints[9 - 2 * i];

                if (d == Direction.Horizontal)
                {
                    // Measurement is horizontal, so arrows stack vertically.
                    line.Start.Y += (2 - i) * 30;
                    line.End.Y += (2 - i) * 30;
                }
                else
                {
                    // Measurement is vertical, so arrows stack horizontally.
                    line.Start.X += (2 - i) * 30;
                    line.End.X += (2 - i) * 30;
                }

                // Draw the line with arrows.
                image.Overlays.Default.AddLine(line, Rgb32Value.RedColor);
                DrawArrow(image.Overlays.Default, line, Rgb32Value.RedColor);
                // Flip the start and end to draw an arrow at the beginning.
                PointContour tempStart = line.Start;
                line.Start = line.End;
                line.End = tempStart;
                DrawArrow(image.Overlays.Default, line, Rgb32Value.RedColor);

                // Find the origin of the text to overlay.
                image.Overlays.Default.AddText(String.Format("{0:0.00}", realWorldDistance), tempStart, Rgb32Value.RedColor, overlayOptions);
            }
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}