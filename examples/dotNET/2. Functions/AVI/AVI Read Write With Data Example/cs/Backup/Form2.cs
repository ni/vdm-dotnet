using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision.MeasurementStudioDemo;

namespace AVI_Read_Write_With_Data_Example
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 owner)
        {
            InitializeComponent();
            form1 = owner;
        }

        public AviSampleDataGraph Graph
        {
            get { return aviSampleDataGraph1; }
        }

        public GenericSlider FrameSlider
        {
            get { return genericSlider1; }
        }

        public NumericUpDown FrameNum
        {
            get { return numericUpDown1; }
        }

        public TextBox CurTime
        {
            get { return curTime; }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (FrameSlider.Value != (double)numericUpDown1.Value)
            {
                FrameSlider.Value = (double)numericUpDown1.Value;
            }
        }

        private void aviSampleDataGraph1_AfterCursorMove(object sender, EventArgs e)
        {
            if (FrameSlider.Value != Graph.CursorValue)
            {
                FrameSlider.Value = Graph.CursorValue;
            }
        }

        private void genericSlider1_ValueChanged(object sender, EventArgs e)
        {
            FrameNum.Value = (decimal)FrameSlider.Value;
            form1.ReadFrame((uint)FrameSlider.Value);
        }
    }
}