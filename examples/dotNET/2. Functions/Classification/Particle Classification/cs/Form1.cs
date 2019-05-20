using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Classification Example
//
// This example demonstrates how to use the Classification functions and objects.
// The example loads in a classifier file that handles various parts.  The file is
// then used to classify images of parts loaded in by the user.

namespace Classification
{
    public partial class Form1 : Form
    {
        ParticleClassifierSession classifier;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Setup the default path for the classifier file and load it in.
            classifierPath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Classification\Parts.clf");
            classifier = new ParticleClassifierSession(classifierPath.Text);

            // Setup the default path for images
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Classification");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = classifierPath.Text;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select a classifier file";
            openFileDialog1.DefaultExt = "*.clf";
            openFileDialog1.Filter = "*.clf|*.clf";

            // Select the file
            DialogResult result = openFileDialog1.ShowDialog();
            // Don't set the path if the user cancelled.
            if (result == DialogResult.OK)
            {
                classifierPath.Text = openFileDialog1.FileName;
                // Read the classifier file.
                classifier.ReadFile(classifierPath.Text);
            }

        }

        // loadButton_Click is called when the Load File button is pressed.
        // The user is asked to load in an image to be used later in classification.
        private void loadButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            // Setup the image dialog
            dialog.InitialDirectory = imagePath.Text;
            dialog.Title = "Choose an Image to Classify";
            // Select the image.
            DialogResult result = dialog.ShowDialog();
            // Load the file and display if not cancelled.
            if (result == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                imageViewer1.Image.ReadFile(imagePath.Text);
                imageViewer1.Roi.Clear();
                classifyButton.Enabled = true;
            }
        }

        // classifyButton_Click is called when the Classify button is pressed. The
        // classify file is read in and the currently-loaded image is classified. The
        // class name and score are then displayed to the user.
        private void classifyButton_Click(object sender, EventArgs e)
        {
            // Classify the image.
            try
            {
                ClassifierReport report = classifier.Classify(imageViewer1.Image, imageViewer1.Roi);
                classBox.Text = report.BestClassName;
                scoreBox.Text = report.ClassificationScore.ToString();
            }
            catch (VisionException)
            {
                // Unable to classify image
                classBox.Text = "Unknown";
                scoreBox.Text = "0";
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}