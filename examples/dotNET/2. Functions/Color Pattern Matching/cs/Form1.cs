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

// Color Pattern Matching Example
//
// This example shows how to use the color pattern matching tools in NI Vision.
// Color pattern matching is the technique used to quickly locate known reference or
// fiducial patterns in an image.  Pattern matching is the key to many applications and
// can provide your application with information about the
// presence or absence, number, and location of the model within an image.
//
// Color pattern matching is used in three general application areas:
//
// * Alignment  - Determine the position and orientation of a known object by locating
//                features.  The features are used as points of reference on the object.
//
// * Gauging    - Measure lengths, diameters, angles, and other critical dimensions.  If
//                the measurements fall out of set tolerance levels then the component
//                is rejected.  Gauging sometimes is used in-line with the manufacturing
//                process and off-line with a sample of components to determine the quality
//                of a lot or batch of manufactured components.
//
// * Inspection - Detect simple flaws, such as missing parts or unreadable printing.
namespace ColorPatternMatching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Put a default image in the text box.
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"pcbcolor\pcbcolor-00.jpg");

            // Initialize combo boxes
            matchMode.SelectedIndex = 0;
            colorSensitivity.SelectedIndex = 2;
            searchStrategy.SelectedIndex = 0;
            matchFeatureMode.SelectedIndex = 0;

            // Set up both viewers to load color images.
            imageViewer1.Image.Type = ImageType.Rgb32;
            imageViewer2.Image.Type = ImageType.Rgb32;

            // Choose the color for drawing regions.
            imageViewer1.Roi.Color = Rgb32Value.YellowColor;
            imageViewer1.Roi.MaximumContours = 1;
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        // Load an image using ReadFile.
        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
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

        // When a region is available, the Learn button is enabled.
        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0)
            {
                learnPatternButton.Enabled = true;
            }
            else
            {
                learnPatternButton.Enabled = false;
            }
        }

        // Click the Learn button to learn the template.
        private void learnPatternButton_Click(object sender, EventArgs e)
        {
            MatchMode mode = (MatchMode)Enum.Parse(typeof(MatchMode), (string)matchMode.SelectedItem);
            ImageFeatureMode featureMode = (ImageFeatureMode)Enum.Parse(typeof(ImageFeatureMode), (string)matchFeatureMode.SelectedItem);
            if (mode == MatchMode.RotationInvariant && featureMode == ImageFeatureMode.Color)
            {
                MessageBox.Show("Rotation-Invariant Color Pattern Matching requires a feature mode including shape",
                    "Color Pattern Matching Error");
                return;
            }
            learnPatternButton.Text = "Learning...";
            Update();
            
            // Extract the region corresponding to the region of interest.
            Algorithms.Extract(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi);
            imageViewer1.Roi.Clear();

            // Set up learn parameters.
            LearnColorPatternOptions learnOptions = new LearnColorPatternOptions(LearnMode.All, featureMode);

            // Learn the template.
            Algorithms.LearnColorPattern(imageViewer2.Image, learnOptions);
            learnPatternButton.Text = "Learn Pattern";

            // Enable the Match button and disable the Learn button.
            matchPatternButton.Enabled = true;
            learnPatternButton.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Click the Match button to find the patterns in the image.  The results
        // are then displayed using regions.
        private void matchPatternButton_Click(object sender, EventArgs e)
        {
            // Get match input parameters.
            MatchColorPatternOptions matchOptions = new MatchColorPatternOptions();
            matchOptions.MatchMode = (MatchMode)Enum.Parse(typeof(MatchMode), (string)matchMode.SelectedItem);
            matchOptions.MinimumMatchScore = (double)minimumScore.Value;
            matchOptions.NumberOfMatchesRequested = (int)matchesRequested.Value;
            matchOptions.MinimumContrast = (int)minimumContrast.Value;
            matchOptions.ColorWeight = (double)colorScoreWeight.Value;
            matchOptions.FeatureMode = (ImageFeatureMode)Enum.Parse(typeof(ImageFeatureMode), (string)matchFeatureMode.SelectedItem);
            matchOptions.ColorSensitivity = (ColorSensitivity)Enum.Parse(typeof(ColorSensitivity), (string)colorSensitivity.SelectedItem);
            matchOptions.SearchStrategy = (SearchStrategy)Enum.Parse(typeof(SearchStrategy), (string)searchStrategy.SelectedItem);
            matchOptions.SubpixelAccuracy = subpixelAccuracy.Checked;
            if (matchOptions.MatchMode == MatchMode.RotationInvariant && matchOptions.FeatureMode == ImageFeatureMode.Color)
            {
                MessageBox.Show("Rotation-Invariant Color Pattern Matching requires a feature mode including shape",
                    "Color Pattern Matching Error");
                return;
            }

            // Do the match.
            Collection<PatternMatch> matches = Algorithms.MatchColorPattern(imageViewer1.Image, imageViewer2.Image, matchOptions, imageViewer1.Roi);

            // Display the matches.
            imageViewer1.Image.Overlays.Default.Clear();
            foreach (PatternMatch match in matches)
            {
                // First draw the bounding box.
                imageViewer1.Image.Overlays.Default.AddPolygon(new PolygonContour(match.Corners), Rgb32Value.RedColor);
                // Now draw the center point.
                imageViewer1.Image.Overlays.Default.AddOval(new OvalContour(match.Position.X - 5, match.Position.Y - 5, 11, 11), Rgb32Value.RedColor);
                // Finally draw the crosshair.
                imageViewer1.Image.Overlays.Default.AddLine(new LineContour(new PointContour(match.Position.X - 10, match.Position.Y), new PointContour(match.Position.X + 10, match.Position.Y)), Rgb32Value.RedColor);
                imageViewer1.Image.Overlays.Default.AddLine(new LineContour(new PointContour(match.Position.X, match.Position.Y - 10), new PointContour(match.Position.X, match.Position.Y + 10)), Rgb32Value.RedColor);
            }

            matchesFound.Text = matches.Count.ToString();
            learnPatternButton.Enabled = false;
        }
    }
}