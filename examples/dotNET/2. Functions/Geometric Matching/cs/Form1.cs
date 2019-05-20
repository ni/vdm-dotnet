using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Edge Based Geometric Matching Example
//
// This example demonstrates how to use the edge based Geometric Matching functions and objects.
// The example loads in a geometric matching template image that is used to search for similar parts 
// in images loaded in by the user.

namespace GeometricMatching
{
    public partial class Form1 : Form
    {
        MatchGeometricPatternEdgeBasedOptions matchOptions = new MatchGeometricPatternEdgeBasedOptions(GeometricMatchModes.ShiftInvariant, 1);

        public Form1()
        {
            InitializeComponent();
        }

        public void FindMatches()
        {
            // Match the template in the image

            // Setup match options
            CurveOptions curveOptions = new CurveOptions();
            GeometricMatchModes mode;
            if (rotationInvariant.Checked)
            {
                mode = GeometricMatchModes.RotationInvariant;
            }
            else
            {
                mode = GeometricMatchModes.ShiftInvariant;
            }
            if (occlusionInvariant.Checked)
            {
                mode |= GeometricMatchModes.OcclusionInvariant;
            }
            if (scaleInvariant.Checked)
            {
                mode |= GeometricMatchModes.ScaleInvariant;
            }
            matchOptions.Mode = mode;
            matchOptions.Advanced.MatchStrategy = GeometricMatchingSearchStrategy.Balanced;
            matchOptions.SubpixelAccuracy = false;
            matchOptions.RotationAngleRanges.Add(new Range(0, 360));
            matchOptions.NumberOfMatchesRequested = (int)numMatches.Value;
            matchOptions.MinimumMatchScore = (double)minScore.Value;

            // Match
            Collection<GeometricEdgeBasedPatternMatch> matches = Algorithms.MatchGeometricPatternEdgeBased(imageViewer.Image, templateImageViewer.Image, curveOptions, matchOptions, imageViewer.Roi);

            // Display results
            imageViewer.Image.Overlays.Default.Clear();
            foreach (GeometricEdgeBasedPatternMatch match in matches)
            {
                imageViewer.Image.Overlays.Default.AddPolygon(new PolygonContour(match.Corners), Rgb32Value.RedColor);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set image type to be U8
            templateImageViewer.Image.Type = ImageType.U8;
            imageViewer.Image.Type = ImageType.U8;

            // Setup the default path for the classifier file and load it in.
            templatePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Geometric Matching\Template.png");
            // Read the template file and load it into the template viewer image
            templateImageViewer.Image.ReadVisionFile(templatePath.Text);
            // Setup the default path for images
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Geometric Matching");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = templatePath.Text;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select a geometric matching template file";
            openFileDialog1.DefaultExt = "*.png";
            openFileDialog1.Filter = "*.png|*.png";

            // Select the file
            DialogResult result = openFileDialog1.ShowDialog();
            // Don't set the path if the user cancelled.
            if (result == DialogResult.OK)
            {
                templatePath.Text = openFileDialog1.FileName;
                // Read the template file and load it into the template image
                templateImageViewer.Image.ReadVisionFile(templatePath.Text);
            }

        }

        // loadButton_Click is called when the Load File button is pressed.
        // The user is asked to load in an image to be used later in classification.
        private void loadButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            // Setup the image dialog
            dialog.InitialDirectory = imagePath.Text;
            dialog.Title = "Choose an Image to search patterns in";
            // Select the image.
            DialogResult result = dialog.ShowDialog();
            // Load the file and display if not cancelled.
            if (result == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                imageViewer.Image.ReadFile(imagePath.Text);
                imageViewer.Roi.Clear();
                searchButton.Enabled = true;
            }
        }

        // searchButton_Click is called when the Search button is pressed. 
        private void searchButton_Click(object sender, EventArgs e)
        {
            FindMatches();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numMatches_ValueChanged(object sender, EventArgs e)
        {
            FindMatches();
        }

        private void rotationInvariant_CheckedChanged(object sender, EventArgs e)
        {
            FindMatches();
        }

        private void scaleInvariant_CheckedChanged(object sender, EventArgs e)
        {
            FindMatches();
        }

        private void occlusionInvariant_CheckedChanged(object sender, EventArgs e)
        {
            FindMatches();
        }

        private void imageViewer_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            FindMatches();
        }

    }
}