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

// Pattern Matching Example
// 
// This example demonstrates how to use the NI Vision pattern matching tools. The pattern
// matching technique allows you to quickly locate known references or fiducial patterns
// in an image. Pattern matching is the key to many applications and can
// provide your application with information about the presence or absence, number,
// and location of the model within an image.
// 
// Pattern matching is used in three general applications areas:
// 
//   * Alignment  Determine the position and orientation of a known object by locating
//                features. The features serve as reference points on the object.
// 
//   * Gauging    Measure lengths, diameters, angles, and other critical dimensions. If
//                the measurements fall outside set tolerance levels, the component
//                is rejected. Gauging is sometimes used in-line with the manufacturing
//                process and off-line with a sample of components to determine the quality
//                of a lot or batch of manufactured components.
// 
//   * Inspection Detect simple flaws, such as missing parts or unreadable printing.

namespace Pattern_Matching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetImagePath();
            matchMode.SelectedIndex = 0;
            imageViewerMain.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle;
            imageViewerMain.Roi.ContoursChanged += new EventHandler<NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs>(Roi_ContoursChanged);
        }

        void Roi_ContoursChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            learnPatternButton.Enabled = imageViewerMain.Roi.Count > 0;
        }

        private void SetImagePath()
        {
            if (imagePath.Text == "")
            {
                imagePath.Text = System.IO.Path.GetFullPath(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"pcb\pcb03-01.png"));
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            imageViewerMain.Image.ReadFile(imagePath.Text);
            imageViewerMain.Roi.Clear();
        }

        private void learnPatternButton_Click(object sender, EventArgs e)
        {
            learnPatternButton.Text = "Learning...";
            // Extract region corresponding to the region of interest in the image window
            Algorithms.Extract(imageViewerMain.Image, imageViewerPattern.Image, (RectangleContour)imageViewerMain.Roi[0].Shape);
            imageViewerMain.Roi.Clear();

            // Learn template
            Algorithms.LearnPattern(imageViewerPattern.Image);

            learnPatternButton.Text = "Learn Pattern";

            // Enable the Match button and disable the Learn button
            learnPatternButton.Enabled = false;
            matchPatternButton.Enabled = true;
        }

        private void matchPatternButton_Click(object sender, EventArgs e)
        {
            MatchPatternOptions options = new MatchPatternOptions((MatchMode)(matchMode.SelectedIndex + 1), (int)matchesRequested.Value);
            options.MinimumMatchScore = (int)minimumScore.Value;
            options.MinimumContrast = (int)minimumContrast.Value;
            options.SubpixelAccuracy = subpixelAccuracy.Checked;

            // Match
            Collection<PatternMatch> matches = Algorithms.MatchPattern(imageViewerMain.Image, imageViewerPattern.Image, options, imageViewerMain.Roi);

            // Display results.
            imageViewerMain.Image.Overlays.Default.Clear();
            foreach (PatternMatch match in matches)
            {
                imageViewerMain.Image.Overlays.Default.AddPolygon(new PolygonContour(match.Corners), Rgb32Value.RedColor);
            }
            matchesFound.Text = matches.Count.ToString();
            learnPatternButton.Enabled = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(imagePath.Text);
            openFileDialog1.FileName = System.IO.Path.GetFileName(imagePath.Text);
            openFileDialog1.ShowDialog();
            imagePath.Text = openFileDialog1.FileName;

        }

    }
}