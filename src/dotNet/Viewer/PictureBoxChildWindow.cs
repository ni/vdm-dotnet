//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2019, National Instruments Corp.

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision.WindowsForms;

namespace NationalInstruments.Vision.WindowsForms.Internal
{
    internal partial class PictureBoxChildWindow : System.Windows.Forms.PictureBox
    {
        FakeNativeWindow _nativeWindow = null;
        public PictureBoxChildWindow()
        {
            InitializeComponent();
        }
        internal void SetOwningViewer(ImageViewer viewer)
        {
            _nativeWindow = new FakeNativeWindow(viewer);
        }

        internal void AssignHandle(IntPtr handle)
        {
            _nativeWindow.AssignHandle(handle);
        }

    }

    internal class FakeNativeWindow : NativeWindow
    {
        ImageViewer _viewer = null;
        // These are the minimum and maximum message numbers we're interested in
        Int32 _minMessage, _maxMessage;
        internal FakeNativeWindow(ImageViewer viewer)
        {
            _viewer = viewer;
            int[] values = (int[]) Enum.GetValues(typeof(ViewerMessage));
            // Enum.GetValues() returns the values in order.
            _minMessage = values[0];
            _maxMessage = values[values.Length - 1];
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= _minMessage && m.Msg <= _maxMessage)
            {
                _viewer.OnViewerMessage(m);
            }
            base.WndProc(ref m);
        }
    }
}

