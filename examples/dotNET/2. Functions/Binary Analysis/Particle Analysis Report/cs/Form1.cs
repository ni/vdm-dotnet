using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System.Collections.ObjectModel;

// This example demonstrates how to grab in-depth information about the particles found in
// an image.  Threshold separates particles in the image from the background.  ParticleReport
// retrieves the information about each particle.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Particle_Analysis_Report
{
    public partial class Form1 : Form
    {
        private Collection<ParticleReport> reports = new Collection<ParticleReport>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            // Load the image
            imageViewer1.Image.ReadFile(imagePath.Text);
            processButton.Enabled = true;
        }

        // Click the Browse button to open the file dialog
        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = imagePath.Text;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel) {
                imagePath.Text = openFileDialog1.FileName;
            }
        }

        // Click the Process button to separate the particles from an image and
        // display the processed image.
        private void processButton_Click(object sender, EventArgs e)
        {
            // Process the Threshold
            Algorithms.Threshold(imageViewer1.Image, imageViewer2.Image, new Range(minimumSlide.Value, maximumSlide.Value), true, 255);

            // Get the particle reports
            reports = Algorithms.ParticleReport(imageViewer2.Image, (connectivitySwitch.Value) ? Connectivity.Connectivity8 : Connectivity.Connectivity4);

            // display results
            numberOfParticles.Text = reports.Count.ToString();

            reportIndex.Value = 0;
            reportIndex.Enabled = reports.Count > 0;
            if (reports.Count > 0)
            {
                reportIndex.Maximum = reports.Count - 1;
            }
            DisplayReport(0);
        }

        private void DisplayReport(int reportIndex)
        {
            if (reportIndex < 0 || reportIndex >= reports.Count)
            {
                area.Text = "0";
                numberOfHoles.Text = "0";
                centerOfMassX.Text = "0";
                centerOfMassY.Text = "0";
                orientation.Text = "0";
                boundingRectLeft.Text = "0";
                boundingRectRight.Text = "0";
                boundingRectTop.Text = "0";
                boundingRectBottom.Text = "0";
                width.Text = "0";
                height.Text = "0";
                return;
            }
            ParticleReport report = reports[reportIndex];
            area.Text = report.Area.ToString();
            numberOfHoles.Text = report.NumberOfHoles.ToString();
            centerOfMassX.Text = report.CenterOfMass.X.ToString();
            centerOfMassY.Text = report.CenterOfMass.Y.ToString();
            orientation.Text = report.Orientation.ToString();
            boundingRectLeft.Text = report.BoundingRect.Left.ToString();
            boundingRectTop.Text = report.BoundingRect.Top.ToString();
            width.Text = report.BoundingRect.Width.ToString();
            height.Text = report.BoundingRect.Height.ToString();
            boundingRectRight.Text = (report.BoundingRect.Left + report.BoundingRect.Width).ToString();
            boundingRectBottom.Text = (report.BoundingRect.Top + report.BoundingRect.Height).ToString();
        }

        private void reportIndex_ValueChanged(object sender, EventArgs e)
        {
            DisplayReport((int)reportIndex.Value);
        }
    }
}