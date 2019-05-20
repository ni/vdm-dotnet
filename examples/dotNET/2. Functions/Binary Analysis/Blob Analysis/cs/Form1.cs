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

// Blob Analysis example
//
// This example performs a series of grayscale filtering, threshold, binary morphology,
// and blob analysis operations and measures the areas of all large circular particles
// in the image.

namespace BlobAnalysis
{
    public partial class Form1 : Form
    {
        private int currentStep;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetExample();
        }

        private void ResetExample()
        {
            // Clear the image from the viewer.
            imageViewer1.Image.SetSize(0, 0);

            // Start over with the first step
            currentStep = 0;
            steps.SelectedIndex = 0;
        }

        private void steps_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Do not allow the user to change the step selected in the listbox
            steps.SelectedIndex = currentStep;
        }

        private void runCurrentStepButton_Click(object sender, EventArgs e)
        {
            // Call the appropriate routine based on the current step.
            switch (currentStep)
            {
                case 0:
                    LoadSampleImage();
                    break;
                case 1:
                    EnhanceEdgeInformation();
                    break;
                case 2:
                    Threshold();
                    break;
                case 3:
                    FillHolesInObjects();
                    break;
                case 4:
                    RemoveObjectsTouchingTheBorder();
                    break;
                case 5:
                    KeepRoundObjects();
                    break;
                case 6:
                    MeasureObjectsAreas();
                    break;
            }
            // Advance to the next step
            currentStep++;
            if (currentStep > 6)
            {
                currentStep = 0;
            }
            // Update the listbox.
            steps.SelectedIndex = currentStep;
        }

        private void LoadSampleImage()
        {
            // Read the image and set the viewer's palette to Gray to display it properly
            imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "metal.jpg"));
            imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray;
        }

        private void EnhanceEdgeInformation()
        {
            // Use convolution to sharpen the edges.
            Algorithms.Convolute(imageViewer1.Image, imageViewer1.Image, new Kernel(KernelFamily.Laplacian, 3, 5));
        }

        private void Threshold()
        {
            // Threshold the image and change the viewer's palette to Binary so the foreground of
            // the image is visible.
            Algorithms.Threshold(imageViewer1.Image, imageViewer1.Image, new Range(150, 255));
            imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
        }

        private void FillHolesInObjects()
        {
            // Fill holes in particles
            Algorithms.FillHoles(imageViewer1.Image, imageViewer1.Image);
        }

        private void RemoveObjectsTouchingTheBorder()
        {
            // Remove particles touching the border
            Algorithms.RejectBorder(imageViewer1.Image, imageViewer1.Image);
        }

        private void KeepRoundObjects()
        {
            // Filter out all very small particles
            Algorithms.RemoveParticle(imageViewer1.Image, imageViewer1.Image, 1);

            // Filter out non-circular particles
            Collection<ParticleFilterCriteria> criteria = new System.Collections.ObjectModel.Collection<ParticleFilterCriteria>();
            criteria.Add(new ParticleFilterCriteria(MeasurementType.HeywoodCircularityFactor, new Range(0, 1.06)));
            Algorithms.ParticleFilter(imageViewer1.Image, imageViewer1.Image, criteria);
        }

        private void MeasureObjectsAreas()
        {
            // Compute the full particle report.
            Collection<ParticleReport> reports = Algorithms.ParticleReport(imageViewer1.Image);

            // Overlay the area of each particle.
            OverlayTextOptions options = new OverlayTextOptions();
            options.HorizontalAlignment = HorizontalTextAlignment.Center;
            options.VerticalAlignment = VerticalTextAlignment.Bottom;
            options.FontSize = 16;
            foreach (ParticleReport report in reports)
            {
                imageViewer1.Image.Overlays.Default.AddText(String.Format("{0}", report.Area), new PointContour(report.CenterOfMass.X, report.BoundingRect.Top), Rgb32Value.GreenColor, options);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            steps.SelectedIndex = 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}