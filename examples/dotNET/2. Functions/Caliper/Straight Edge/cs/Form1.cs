using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.WindowsForms;

// Find Straight Edges Example
//
// This example demonstrates how to use Algorithms.StraightEdge to find straight edges
// in a given ROI.

namespace StraightEdge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the path to the default image.
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Clamp.png");

            imageViewer1.ToolsShown = ViewerTools.Pan | ViewerTools.Rectangle | ViewerTools.RotatedRectangle | ViewerTools.Selection | ViewerTools.ZoomIn | ViewerTools.ZoomOut;

            // Initialize combo boxes.
            polarity.SelectedIndex = 0;
            interpolationMethod.SelectedIndex = 2;
            smoothing.SelectedIndex = 0;
            searchMode.SelectedIndex = 4;
            searchDirection.SelectedIndex = 0;
        }

        private void FindStraightEdges()
        {
            // Use search direction selected.
            SearchDirection direction = (SearchDirection)Enum.Parse(typeof(SearchDirection), (string)searchDirection.SelectedItem);

            // Fill in the edge options structure from the controls on the form.
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.ColumnProcessingMode = (ColumnProcessingMode)Enum.Parse(typeof(ColumnProcessingMode), (string)smoothing.SelectedItem);
            edgeOptions.InterpolationType = (InterpolationMethod)Enum.Parse(typeof(InterpolationMethod), (string)interpolationMethod.SelectedItem);
            edgeOptions.KernelSize = (uint)kernelSize.Value;
            edgeOptions.MinimumThreshold = (uint)minimumThreshold.Value;
            edgeOptions.Polarity = (EdgePolaritySearchMode)Enum.Parse(typeof(EdgePolaritySearchMode), (string)polarity.SelectedItem);
            edgeOptions.Width = (uint)width.Value;
            
            // Fill in the straight edge options structure from the controls on the form.
            StraightEdgeOptions straightEdgeOptions = new StraightEdgeOptions();
            straightEdgeOptions.AngleRange = (double)angleRange.Value;
            straightEdgeOptions.AngleTolerance = (double)angleTolerance.Value;
            straightEdgeOptions.HoughIterations = (uint)houghIterations.Value;
            straightEdgeOptions.ScoreRange.Initialize((double)minimumScore.Value, (double)maximumScore.Value);
            straightEdgeOptions.MinimumCoverage = (double)minimumCoverage.Value;
            straightEdgeOptions.MinimumSignalToNoiseRatio = (double)minimumSignalToNoiseRatio.Value;
            straightEdgeOptions.NumberOfLines = (uint)numberOfLines.Value;
            straightEdgeOptions.Orientation = (double)orientation.Value;
            straightEdgeOptions.SearchMode = (StraightEdgeSearchMode)Enum.Parse(typeof(StraightEdgeSearchMode), (string)searchMode.SelectedItem);
            straightEdgeOptions.StepSize = (uint)stepSize.Value;

            // Run the edge detection.
            StraightEdgeReport report = Algorithms.StraightEdge(imageViewer1.Image, imageViewer1.Roi, direction, edgeOptions, straightEdgeOptions);

            // Clear all overlays from previous run.
            imageViewer1.Image.Overlays.Default.Clear();

            // Overlay the straight edges.
            foreach (StraightEdgeReportItem item in report.StraightEdges)
            {
                imageViewer1.Image.Overlays.Default.AddLine(item.StraightEdge, Rgb32Value.RedColor);
            }

            // Overlay the search lines.
            foreach (SearchLineInfo info in report.SearchLines)
            {
                // First the line itself.
                imageViewer1.Image.Overlays.Default.AddLine(info.Line, Rgb32Value.BlueColor);
                // Then the found edges on each line.
                foreach (EdgeInfo edgeInfo in info.EdgeReport.Edges)
                {
                    imageViewer1.Image.Overlays.Default.AddOval(new OvalContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue);
                }
            }

        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0)
            {
                FindStraightEdges();
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);

            // If regions are on the viewer, remove them.
            imageViewer1.Roi.Clear();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                LoadSelectedImage();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}