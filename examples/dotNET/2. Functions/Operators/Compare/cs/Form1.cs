using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Compare Example
//
// This example compares two images based on the comparison operator selected by the user.

namespace Compare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath1.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Moly.tif");
            imagePath2.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Iron.tif");
            comparisonBox.SelectedIndex = 0;
        }

        // Perform the compare operation.
        private void compareImagesButton_Click(object sender, EventArgs e)
        {
            ComparisonFunction function = ComparisonFunction.ClearEqual;
            switch (comparisonBox.SelectedIndex)
            {
                case 0:
                    function = ComparisonFunction.ClearLess;
                    break;
                case 1:
                    function = ComparisonFunction.ClearLessOrEqual;
                    break;
                case 2:
                    function = ComparisonFunction.ClearEqual;
                    break;
                case 3:
                    function = ComparisonFunction.ClearGreaterOrEqual;
                    break;
                case 4:
                    function = ComparisonFunction.ClearGreater;
                    break;
            }
            Algorithms.Compare(imageViewer1.Image, imageViewer2.Image, imageViewer3.Image, function);
        }

        private void LoadSelectedImage(int index)
        {
            if (index == 0)
            {
                imageViewer1.Image.ReadFile(imagePath1.Text);
            }
            else
            {
                imageViewer2.Image.ReadFile(imagePath2.Text);
            }
            // After both images load, enable the Compare Images button.
            if (imageViewer1.Image.Width > 0 && imageViewer2.Image.Width > 0)
            {
                compareImagesButton.Enabled = true;
            }
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage(0);
            LoadSelectedImage(1);
        }

        private void browseButton1_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath1.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath1.Text = dialog.FileName;
                LoadSelectedImage(0);
            }
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath2.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath2.Text = dialog.FileName;
                LoadSelectedImage(1);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}