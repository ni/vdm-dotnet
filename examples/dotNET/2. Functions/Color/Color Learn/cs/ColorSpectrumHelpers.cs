using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Color Spectrum Helpers
// Color Learn and Color Match examples share these functions.
namespace NationalInstruments.Vision
{
    public class ColorSpectrumHelpers
    {
        private static Collection<Color> _plotColors = new Collection<Color>();
        private static Collection<double> _colorSpectrum = new Collection<double>();
        public static Collection<Color> GetPlotColors(ColorSensitivity sensitivity)
        {
            Collection<byte> luminanceValues = new Collection<byte>();
            switch (sensitivity)
            {
                case ColorSensitivity.Low:
                    luminanceValues = new Collection<byte>(new byte[] { 76, 220, 150, 179, 100, 45, 105 });
                    break;
                case ColorSensitivity.Medium:
                    luminanceValues = new Collection<byte>(new byte[] { 76, 185, 220, 185, 150, 165, 179, 230, 100, 122, 45, 75, 105, 90 });
                    break;
                case ColorSensitivity.High:
                    luminanceValues = new Collection<byte>(new byte[] { 76, 130, 185, 200, 220, 200, 185, 167, 150, 157, 165, 172, 179, 205, 230, 165, 100, 110, 122, 83, 45, 60, 75, 90, 105, 98, 90, 83 });
                    break;
            }
            Collection<Color> plotColors = new Collection<Color>();
            double binSize = 255.0 / luminanceValues.Count;
            for (int i = 0; i < luminanceValues.Count; ++i)
            {
                byte hue = (byte)(binSize * i);
                plotColors.Add(Algorithms.ConvertColorValue(new ColorValue(new Hsl32Value((byte)hue, 80, luminanceValues[i])), ColorMode.Rgb).Rgb32.Color);
                plotColors.Add(Algorithms.ConvertColorValue(new ColorValue(new Hsl32Value((byte)hue, 255, luminanceValues[i])), ColorMode.Rgb).Rgb32.Color);
            }
            plotColors.Add(Color.Black);
            plotColors.Add(Color.White);
            return plotColors;
        }
        public static void PlotColorSpectrum(PictureBox pictureBox, ColorSensitivity sensitivity, Collection<double> colorSpectrum)
        {
            _colorSpectrum = colorSpectrum;
            _plotColors = GetPlotColors(sensitivity);
            // Make sure the PictureBox gets redrawn.
            pictureBox.Invalidate();
        }
        public static void DrawColorSpectrum(Graphics g, Rectangle bounds)
        {
            // Clear the picture
            g.Clear(Color.FromKnownColor(KnownColor.Control));

            // If we have no color spectrum, return.
            if (_colorSpectrum.Count == 0)
            {
                return;
            }

            // Find the maximum value.
            float max = (float)_colorSpectrum[0];
            foreach (double value in _colorSpectrum)
            {
                if (value > max)
                {
                    max = (float)value;
                }
            }
            max *= 1.25F;


            // Compute the width and height of the PictureBox control in pixels.
            int width = bounds.Width;
            int height = bounds.Height;

            // Draw a line of the appropriate height and color for each pixel found.
            int count = _colorSpectrum.Count;
            float lineWidth = ((float)width)/count;
            float xOffset = lineWidth / 2;
            for (int i = 0; i < count; ++i)
            {
                Pen pen = new Pen(_plotColors[i], lineWidth);
                g.DrawLine(pen, new PointF(xOffset + lineWidth * i, height), new PointF(xOffset + lineWidth * i, (float)(height * (1.0 - _colorSpectrum[i] / max))));
                pen.Dispose();
            }
        }
    }
}
