using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Edge Detection Example

// This example demonstrates how to use Algorithms.EdgeTool() to find edges (or sharp
// transitions in the pixel values) along a given line or ROI profile. Algorithms.EdgeTool()
// is a precursor function to many gauging and inspection tasks. For example, in a gauging
// application, the location of the edges found in a line profile might indicate the boundaries of
// an object whose dimensions have to be measured. In an inspection application, the location of
// the edges might indicate a crack in the object's surface.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace EdgeDetection
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
            process.SelectedIndex = 2;
            imageViewer1.Roi.MaximumContours = 1;
            imageViewer1.Roi.Color = Rgb32Value.YellowColor;
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
            }
            LoadSelectedImage();
        }

        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);
            
            // If regions are on the viewer, remove them.
            imageViewer1.Roi.Clear();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0 && imageViewer1.Roi[0].Type == ContourType.Line)
            {
                // Fill in the edge options structure from the controls on the form.
                EdgeOptions options = new EdgeOptions();
                options.ColumnProcessingMode = (ColumnProcessingMode)Enum.Parse(typeof(ColumnProcessingMode), (string)smoothing.SelectedItem);
                options.InterpolationType = (InterpolationMethod)Enum.Parse(typeof(InterpolationMethod), (string)interpolationMethod.SelectedItem);
                options.KernelSize = (uint)kernelSize.Value;
                options.MinimumThreshold = (uint)minimumThreshold.Value;
                options.Polarity = (EdgePolaritySearchMode)Enum.Parse(typeof(EdgePolaritySearchMode), (string)polarity.SelectedItem);
                options.Width = (uint)width.Value;

                // Run the edge detection
                EdgeReport report = Algorithms.EdgeTool(imageViewer1.Image, imageViewer1.Roi, (EdgeProcess)Enum.Parse(typeof(EdgeProcess), (string)process.SelectedItem),
                    options);

                // Overlay the edge positions
                imageViewer1.Image.Overlays.Default.Clear();
                foreach (EdgeInfo edge in report.Edges) {
                    imageViewer1.Image.Overlays.Default.AddOval(new OvalContour(edge.Position.X - 2, edge.Position.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue);
                }

                // Graph the line profile and the gradient of the line.
                LineProfileReport lineProfile = Algorithms.LineProfile(imageViewer1.Image, imageViewer1.Roi);
                double[] profileData = new double[lineProfile.ProfileData.Count];
                lineProfile.ProfileData.CopyTo(profileData, 0);

                double[] gradientData = new double[report.GradientInfo.Count];
                report.GradientInfo.CopyTo(gradientData, 0);
                edgeDetectionGraph1.PlotData(profileData, gradientData);
            }
        }
    }
}