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

// Line Profile Example
//
// This example demonstrates how to use the display tools to draw a line on 
// an image to display the line's pixel values (line profile).  Line profiles are
// typically used in inspection and gauging tasks to find the edges of the object
// being inspected.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace LineProfile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LineProfile()
        {
            // Perform the line profile
            LineProfileReport report = Algorithms.LineProfile(imageViewer1.Image, imageViewer1.Roi);
            countBox.Text = report.ProfileData.Count.ToString();

            // Graph the line profile.
            double[] profileData = new double[report.ProfileData.Count];
            report.ProfileData.CopyTo(profileData, 0);
            simpleGraph1.PlotY(profileData);

            // Display the results
            minimumBox.Text = report.PixelRange.Minimum.ToString();
            maximumBox.Text = report.PixelRange.Maximum.ToString();
            meanBox.Text = report.Mean.ToString();
            stdDevBox.Text = report.StandardDeviation.ToString();
        }

        private void LoadImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            // Remove the Roi on the viewer.
            imageViewer1.Roi.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
            openFileDialog1.InitialDirectory = ExampleImagesFolder.GetExampleImagesFolder();
            imageViewer1.Roi.MaximumContours = 1;
            imageViewer1.ToolsShown = ViewerTools.Line | ViewerTools.Pan | ViewerTools.Selection | ViewerTools.ZoomIn | ViewerTools.ZoomOut;
            imageViewer1.ActiveTool = ViewerTools.Line;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = openFileDialog1.FileName;
                LoadImage();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0)
            {
                LineProfile();
            }

        }
    }
}