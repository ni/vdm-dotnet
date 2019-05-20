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

// Battery Clamp Inspection Example
//
// This example loads a template image and defines a coordinate system in the image.  The example
// uses the template image and matches it on the new images.  Measurement areas are repositioned
// in the image according to the location of the defined coordinate system.  The example uses a
// clamp to perform a distance measurement between two edges of the part inspected and a circular
// edge finder to perform a diameter measurement.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace BatteryClampInspection
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Battery\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private CoordinateTransform transform = new CoordinateTransform();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the first image.
            imageViewer1.Attach(GetNextImage());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Find the new coordinate transformation.
            MatchPatternOptions matchOptions = new MatchPatternOptions(MatchMode.RotationInvariant);
            matchOptions.MinimumMatchScore = 700;
            matchOptions.SubpixelAccuracy = true;
            DrawOptions drawOptions = new DrawOptions();
            drawOptions.ShowResult = true;
            FindTransformWithPattern(image, imageViewer2.Image, FindTransformMode.UpdateTransform, matchOptions, drawOptions, transform);

            // Initialize search rectangle and search annulus.
            RectangleContour searchRectangle = new RectangleContour(470, 110, 30, 190);
            AnnulusContour searchAnnulus = new AnnulusContour(new PointContour(366, 201), 33, 121, 42.71, 314.13);

            // Overlay the search area for the distance measurement.
            drawOptions.ShowEdgesFound = true;
            drawOptions.ShowSearchArea = true;
            drawOptions.ShowSearchLines = true;
            drawOptions.ShowResult = true;
            double distance = MeasureMaximumDistance(image, searchRectangle, RakeDirection.TopToBottom, drawOptions, transform);

            // Overlay the search area for the circle measurement.
            FitCircleReport circleReport = FindCircularEdge(image, searchAnnulus, SpokeDirection.InsideToOutside, drawOptions, transform);

            // Display results.
            distanceBox.Text = String.Format("{0:0.00}", distance);
            centerXBox.Text = String.Format("{0:0.00}", circleReport.Center.X);
            centerYBox.Text = String.Format("{0:0.00}", circleReport.Center.Y);
            radiusBox.Text = String.Format("{0:0.00}", circleReport.Radius);

            // Display the image.
            imageViewer1.Attach(image);
        }

        private void defineCoordinateSystemButton_Click(object sender, EventArgs e)
        {
            // Read a template file representing a characteristic portion of the object
            // used as a reference coordinate system.
            imageViewer2.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"));

            MatchPatternOptions matchOptions = new MatchPatternOptions(MatchMode.RotationInvariant);
            matchOptions.MinimumMatchScore = 700;
            matchOptions.SubpixelAccuracy = true;
            DrawOptions drawOptions = new DrawOptions();
            drawOptions.ShowResult = true;
            FindTransformWithPattern(imageViewer1.Image, imageViewer2.Image, FindTransformMode.FindReference, matchOptions, drawOptions, transform);

            // Update buttons.
            defineCoordinateSystemButton.Enabled = false;
            defineMeasurementsButton.Enabled = true;
        }

        private void defineMeasurementsButton_Click(object sender, EventArgs e)
        {
            // Initialize search rectangle and search annulus.
            RectangleContour searchRectangle = new RectangleContour(470, 110, 30, 190);
            AnnulusContour searchAnnulus = new AnnulusContour(new PointContour(366, 201), 33, 121, 42.71, 314.13);

            // Overlay the search area for the distance measurement.
            DrawOptions drawOptions = new DrawOptions();
            drawOptions.ShowEdgesFound = true;
            drawOptions.ShowSearchArea = true;
            drawOptions.ShowSearchLines = true;
            MeasureMaximumDistance(imageViewer1.Image, searchRectangle, RakeDirection.TopToBottom, drawOptions, new CoordinateTransform());

            // Overlay the search area for the circle measurement.
            FindCircularEdge(imageViewer1.Image, searchAnnulus, SpokeDirection.InsideToOutside, drawOptions, new CoordinateTransform());

            // Update buttons.
            defineMeasurementsButton.Enabled = false;
            runButton.Enabled = true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);

            // Update buttons.
            runButton.Enabled = false;
        }

        private void FindTransformWithPattern(VisionImage image, VisionImage template, FindTransformMode mode, MatchPatternOptions matchOptions, DrawOptions drawOptions, CoordinateTransform transform)
        {
            // Find the pattern in the image.
            Collection<PatternMatch> matches = Algorithms.MatchPattern(image, template, matchOptions);

            // If the pattern was found:
            if (matches.Count > 0)
            {
                // The points in the Corners collection are returned like this:
                //
                //   0 — 1
                //   |   |
                //   3 — 2
                //
                // Our main axis will be along the line from point 3 to point 2 and
                // our secondary axis will be from point 3 to point 0. The origin will
                // be at point 3.
                LineContour mainAxis = new LineContour(matches[0].Corners[3], matches[0].Corners[2]);
                LineContour secondaryAxis = new LineContour(matches[0].Corners[3], matches[0].Corners[0]);

                // Fill in the coordinate transform with the data obtained by the pattern matching.
                transform.MeasurementSystem.Origin = matches[0].Corners[3];
                transform.MeasurementSystem.Angle = matches[0].Rotation;
                transform.MeasurementSystem.AxisOrientation = AxisOrientation.Direct;

                // If this is the first run, fill in the reference system too.
                if (mode == FindTransformMode.FindReference)
                {
                    transform.ReferenceSystem.Origin = matches[0].Corners[3];
                    transform.ReferenceSystem.Angle = matches[0].Rotation;
                    transform.ReferenceSystem.AxisOrientation = AxisOrientation.Direct;
                }

                // Draw the results on the image.
                if (drawOptions.ShowResult)
                {
                    // Draw the origin.
                    image.Overlays.Default.AddRectangle(new RectangleContour(mainAxis.Start.X - 2, mainAxis.Start.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.DrawValue);

                    // Draw each axis.
                    image.Overlays.Default.AddLine(mainAxis, Rgb32Value.RedColor);
                    DrawArrow(image.Overlays.Default, mainAxis, Rgb32Value.RedColor);
                    image.Overlays.Default.AddLine(secondaryAxis, Rgb32Value.RedColor);
                    DrawArrow(image.Overlays.Default, secondaryAxis, Rgb32Value.RedColor);
                }
            }
        }

        private FitCircleReport FindCircularEdge(VisionImage image, AnnulusContour searchAnnulus, SpokeDirection spokeDirection, DrawOptions drawOptions, CoordinateTransform transform)
        {
            // Add the search rectangle to an Roi.
            Roi roi = new Roi(new Shape[] { searchAnnulus });

            // Transform the Roi.
            Algorithms.TransformRoi(roi, transform);

            // Perform a spoke operation.
            SpokeReport report = Algorithms.Spoke(image, roi, spokeDirection, EdgeProcess.FirstAndLast, 8);
   
            Collection<PointContour> circlePoints = new Collection<PointContour>();
            foreach (EdgeInfo edgeInfo in report.FirstEdges)
            {
                circlePoints.Add(edgeInfo.Position);
            }
            // Fit a circle to the points found.
            FitCircleReport circleReport = Algorithms.FitCircle(circlePoints);

            // Draw the results.
            if (drawOptions.ShowSearchLines)
            {
                foreach (SearchLineInfo lineInfo in report.SearchLines)
                {
                    image.Overlays.Default.AddLine(lineInfo.Line, Rgb32Value.BlueColor);
                    DrawArrow(image.Overlays.Default, lineInfo.Line, Rgb32Value.BlueColor);
                }
            }
            if (drawOptions.ShowSearchArea)
            {
                image.Overlays.Default.AddRoi(roi);
            }
            if (drawOptions.ShowEdgesFound)
            {
                foreach (EdgeInfo edgeInfo in report.FirstEdges)
                {
                    image.Overlays.Default.AddRectangle(new RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue);
                }
            }
            if (drawOptions.ShowResult)
            {
                // Overlay the center point.
                image.Overlays.Default.AddOval(new OvalContour(circleReport.Center.X - 2, circleReport.Center.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);

                // Overlay the circle.
                image.Overlays.Default.AddOval(new OvalContour(circleReport.Center.X - circleReport.Radius, circleReport.Center.Y - circleReport.Radius, 2 * circleReport.Radius, 2 * circleReport.Radius), Rgb32Value.RedColor, DrawingMode.DrawValue);
            }
            return circleReport;
        }

        private double MeasureMaximumDistance(VisionImage image, RectangleContour searchRectangle, RakeDirection rakeDirection, DrawOptions drawOptions, CoordinateTransform transform)
        {
            // Convert the search rectangle to an Roi.
            Roi roi = searchRectangle.ConvertToRoi();

            // Transform the Roi.
            Algorithms.TransformRoi(roi, transform);

            // Perform a rake operation.
            RakeReport report = Algorithms.Rake(image, roi, rakeDirection, EdgeProcess.FirstAndLast);

            // Find the maximum edge positions and compute the distance.
            Collection<LineContour> perpendicularLines;
            PointContour closestFirstEdge, closestLastEdge;
            double distance = FindMinMaxPosition(report, out perpendicularLines, out closestFirstEdge, out closestLastEdge);

            // Draw the results.
            if (drawOptions.ShowSearchLines)
            {
                foreach (SearchLineInfo lineInfo in report.SearchLines)
                {
                    image.Overlays.Default.AddLine(lineInfo.Line, Rgb32Value.BlueColor);
                }
            }
            if (drawOptions.ShowSearchArea)
            {
                image.Overlays.Default.AddRoi(roi);
            }
            if (drawOptions.ShowEdgesFound)
            {
                foreach (EdgeInfo edgeInfo in report.FirstEdges)
                {
                    image.Overlays.Default.AddRectangle(new RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue);
                }
                foreach (EdgeInfo edgeInfo in report.LastEdges)
                {
                    image.Overlays.Default.AddRectangle(new RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor);
                }
            }
            if (drawOptions.ShowResult)
            {
                // Overlay the measurement edge points.
                image.Overlays.Default.AddOval(new OvalContour(closestFirstEdge.X - 2, closestFirstEdge.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);
                image.Overlays.Default.AddOval(new OvalContour(closestLastEdge.X - 2, closestLastEdge.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);
                // Overlay the two lines that point inward from the search area to the clamp position.
                LineContour line1 = new LineContour(FindMidpoint(report.SearchLines[0].Line.Start, report.SearchLines[report.SearchLines.Count - 1].Line.Start),
                                                    FindMidpoint(perpendicularLines[0]));
                image.Overlays.Default.AddLine(line1, Rgb32Value.RedColor);
                DrawArrow(image.Overlays.Default, line1, Rgb32Value.RedColor);

                LineContour line2 = new LineContour(FindMidpoint(report.SearchLines[0].Line.End, report.SearchLines[report.SearchLines.Count - 1].Line.End),
                                                    FindMidpoint(perpendicularLines[1]));
                image.Overlays.Default.AddLine(line2, Rgb32Value.RedColor);
                DrawArrow(image.Overlays.Default, line2, Rgb32Value.RedColor);

                // Overlay the two lines perpendicular to the search lines that correspond to the clamp position.
                image.Overlays.Default.AddLine(perpendicularLines[0], Rgb32Value.RedColor);
                image.Overlays.Default.AddLine(perpendicularLines[1], Rgb32Value.RedColor);
            }
            return distance;
        }

        private PointContour FindMidpoint(PointContour pt1, PointContour pt2)
        {
            return new PointContour((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
        }

        private PointContour FindMidpoint(LineContour line)
        {
            return FindMidpoint(line.Start, line.End);
        }

        private double FindMinMaxPosition(RakeReport report, out Collection<LineContour> perpendicularLines, out PointContour closestFirstEdge, out PointContour closestLastEdge)
        {
            double closestFirstEdgeDistance = double.PositiveInfinity;
            double closestLastEdgeDistance = double.PositiveInfinity;
            closestFirstEdge = new PointContour();
            closestLastEdge = new PointContour();
            foreach (SearchLineInfo lineInfo in report.SearchLines) {
                // If we found an edge on this line, calculate the distances.
                if (lineInfo.EdgeReport.Edges.Count > 0)
                {
                    double firstEdgeDistance = DistanceSquared(lineInfo.Line.Start, lineInfo.EdgeReport.Edges[0].Position);
                    if (firstEdgeDistance < closestFirstEdgeDistance)
                    {
                        closestFirstEdgeDistance = firstEdgeDistance;
                        closestFirstEdge = lineInfo.EdgeReport.Edges[0].Position;
                    }
                    double lastEdgeDistance = DistanceSquared(lineInfo.Line.End, lineInfo.EdgeReport.Edges[lineInfo.EdgeReport.Edges.Count - 1].Position);
                    if (lastEdgeDistance < closestLastEdgeDistance)
                    {
                        closestLastEdgeDistance = lastEdgeDistance;
                        closestLastEdge = lineInfo.EdgeReport.Edges[lineInfo.EdgeReport.Edges.Count - 1].Position;
                    }
                }
            }
            perpendicularLines = new Collection<LineContour>();
            perpendicularLines.Add(new LineContour());
            perpendicularLines.Add(new LineContour());
            // Find the two edge lines.
            LineContour tempLine = Algorithms.FindPerpendicularLine(report.SearchLines[0].Line, closestFirstEdge);
            perpendicularLines[0].Start = (PointContour)(tempLine.End.Clone());
            tempLine = Algorithms.FindPerpendicularLine(report.SearchLines[0].Line, closestLastEdge);
            perpendicularLines[1].Start = (PointContour)(tempLine.End.Clone());
            tempLine = Algorithms.FindPerpendicularLine(report.SearchLines[report.SearchLines.Count - 1].Line, closestFirstEdge);
            perpendicularLines[0].End = (PointContour)(tempLine.End.Clone());
            tempLine = Algorithms.FindPerpendicularLine(report.SearchLines[report.SearchLines.Count - 1].Line, closestLastEdge);
            perpendicularLines[1].End = (PointContour)(tempLine.End.Clone());

            // Compute the distance between them.
            double distance = Algorithms.FindPointDistances(new Collection<PointContour>(new PointContour[]{perpendicularLines[0].Start, perpendicularLines[1].Start}))[0];
            return distance;
        }

        private double DistanceSquared(PointContour pt1, PointContour pt2)
        {
            return (pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y);
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

    public struct DrawOptions
    {
        private bool _showEdgesFound;
        private bool _showSearchArea;
        private bool _showSearchLines;
        private bool _showResult;

        public bool ShowResult
        {
            get { return _showResult; }
            set { _showResult = value; }
        }

        public bool ShowSearchLines
        {
            get { return _showSearchLines; }
            set { _showSearchLines = value; }
        }

        public bool ShowSearchArea
        {
            get { return _showSearchArea; }
            set { _showSearchArea = value; }
        }

        public bool ShowEdgesFound
        {
            get { return _showEdgesFound; }
            set { _showEdgesFound = value; }
        }
    }
}