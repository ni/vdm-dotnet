using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Find Edges Example

// This example demonstrates how to use Algorithms.FindEdges() to find straight edges in
// a given ROI.

namespace FindEdges
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            polarity.SelectedIndex = 0;
            interpolationMethod.SelectedIndex = 2;
            smoothing.SelectedIndex = 0;
            searchMode.SelectedIndex = 4;
            searchDirection.SelectedIndex = 0;
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Clamp.png");
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            FindEdges();
        }

        private void FindEdges()
        {
            if (imageViewer1.Roi.Count > 0)
            {
                // Use search direction selected.
                RakeDirection direction = (RakeDirection)Enum.Parse(typeof(RakeDirection), (string)searchDirection.SelectedItem);

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

                FindEdgeOptions options = new FindEdgeOptions(direction, true, true, true, true);
                options.EdgeOptions = edgeOptions;
                options.StraightEdgeOptions = straightEdgeOptions;

                // Clear all overlays from previous run.
                imageViewer1.Image.Overlays.Default.Clear();

                // Run the edge detection.
                FindEdgeReport report = Algorithms.FindEdge(imageViewer1.Image, imageViewer1.Roi, options);
            }
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}