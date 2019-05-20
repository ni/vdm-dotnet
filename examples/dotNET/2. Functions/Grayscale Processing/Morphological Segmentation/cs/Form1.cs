using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Morphological Segmentation Example

// This example demonstrates the steps involved in morphological segmentation
// of an image.  This process is usually performed to segment a noisy image or
// an image that contains particles that touch each other.

namespace MorphologicalSegmentation
{
    public partial class Form1 : Form
    {
        // Stores a copy of the image for use during the Display Watershed Lines step
        private VisionImage imageCopy = new VisionImage();
        // Enumeration corresponding to each step of the morphological segmentation process.
        enum Step
        {
            LoadSampleImage = 0,
            Threshold = 1,
            DistanceTransform = 2,
            WatershedTransform = 3,
            DisplayWatershedLines = 4,
            Done = 5
        }
        // The array of labels for the viewer, which are displayed after each step is executed.
        private string[] viewerLabels = new string[] { "Image", "Image", "Thresholded Image", "Distance Transform", "Watershed Transform", "Watershed Lines" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            steps.SelectedIndex = 0;
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Pills.jp2");
        }

        // Handler for the runCurrentStepButton.  This is the main subroutine that performs
        // all the processing steps.
        private void runCurrentStepButton_Click(object sender, EventArgs e)
        {
            // Select what to do based on the current index in the listbox.
            switch ((Step)steps.SelectedIndex)
            {
                case Step.LoadSampleImage:
                    // Disable the browse button.
                    browseButton.Enabled = false;
                    // Load an image from the selected location into the viewer.
                    imageViewer1.Image.ReadFile(imagePath.Text);
                    // Store a copy of the image in imageCopy.
                    Algorithms.Copy(imageViewer1.Image, imageCopy);
                    // Set the palette on the viewer to a grayscale palette.
                    imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray;
                    break;
                case Step.Threshold:
                    // Auto threshold the image.
                    Algorithms.AutoThreshold(imageViewer1.Image, imageViewer1.Image, 2, ThresholdMethod.InterclassVariance);
                    // Set the palette on the viewer to a binary palette.
                    imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
                    break;
                case Step.DistanceTransform:
                    // Transform the image using the Danielsson method.
                    Algorithms.Danielsson(imageViewer1.Image, imageViewer1.Image);
                    // Set the palette on the viewer to a gradient palette.
                    imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gradient;
                    break;
                case Step.WatershedTransform:
                    // Disable the Connectivity-8 checkbox.
                    connectivity8.Enabled = false;
                    // Watershed transform the image.
                    Algorithms.WatershedTransform(imageViewer1.Image, imageViewer1.Image, connectivity8.Checked ? Connectivity.Connectivity8 : Connectivity.Connectivity4);
                    // Set the palette on the viewer to a binary palette.
                    imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
                    break;
                case Step.DisplayWatershedLines:
                    // Remove the value of 0 from the copy of the image
                    // by replacing everything less than 1 to 1.
                    Algorithms.Max(imageCopy, new PixelValue(1), imageCopy);
                    // Use the Watershed trasnformed image as a mask on the copy.
                    // This will cause the pixels along the watershed lines to
                    // be set to 0.
                    Algorithms.Mask(imageCopy, imageCopy, imageViewer1.Image);
                    // Attach the copy to the viewer.
                    imageViewer1.Attach(imageCopy);
                    // Create a palette where 0 is green and the rest of the values
                    // are grayscale values.  If you display masked imageCopy with this
                    // palette, the watershed lines will be green in color.
                    imageViewer1.Palette.Entries.Clear();
                    imageViewer1.Palette.Entries.Add(new NationalInstruments.Vision.WindowsForms.PaletteEntry(0, 255, 0));
                    break;
                case Step.Done:
                    Application.Exit();
                    return;
            }
            steps.SelectedIndex++;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            dialog.Title = "Select Sample Image";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Handler called whenever the list index changes.
        private void steps_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the RunCurrentStep button caption to the text corresponding
            // to the current step.
            runCurrentStepButton.Text = (string)steps.Items[steps.SelectedIndex];
            // Set the viewer label
            viewerLabel.Text = viewerLabels[steps.SelectedIndex];
        }
    }
}