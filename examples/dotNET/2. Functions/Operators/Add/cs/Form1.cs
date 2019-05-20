using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

namespace Add
{
    // Add Example
    //
    // This example demonstrates how to add two images.  You can extend this example to perform
    // all basic arithmetic and logical operations (AND, OR, etc.) on images.
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
            // After both images load, enable the Add Images button.
            if (imageViewer1.Image.Width > 0 && imageViewer2.Image.Width > 0)
            {
                addImagesButton.Enabled = true;
            }
        }
        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage(0);
            LoadSelectedImage(1);
        }

        private void addImagesButton_Click(object sender, EventArgs e)
        {
            // Add the two images and display the result.
            Algorithms.Add(imageViewer1.Image, imageViewer2.Image, imageViewer3.Image);
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