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
using System.Text;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Internal;

namespace NationalInstruments.Vision.Analysis.Internal
{
//==============================================================================================
    internal class OcrRange : IRange
    {

        
        internal delegate Int32 OcrSingleGetter(IntPtr _session, out Int32 _value);

        
        internal delegate Int32 OcrSingleSetter(IntPtr _session, Int32 _value);

        
        internal delegate Int32 OcrDoubleGetter(IntPtr _session, out Int32 _minValue, out Int32 _maxValue);

        
        internal delegate Int32 OcrDoubleSetter(IntPtr _session, Int32 _minValue, Int32 _maxValue);

        private IntPtr _charSet = IntPtr.Zero;
        private OcrSingleGetter _minGetter = null;
        private OcrSingleSetter _minSetter = null;
        private OcrSingleGetter _maxGetter = null;
        private OcrSingleSetter _maxSetter = null;
        private OcrDoubleGetter _getter = null;
        private OcrDoubleSetter _setter = null;

        
        public OcrRange(IntPtr _session, OcrSingleGetter minGetter, OcrSingleSetter minSetter, OcrSingleGetter maxGetter, OcrSingleSetter maxSetter) {
            _charSet = _session;
            _minGetter = minGetter;
            _minSetter = minSetter;
            _maxGetter = maxGetter;
            _maxSetter = maxSetter;
        }

        
        public OcrRange(IntPtr _session, OcrDoubleGetter getter, OcrDoubleSetter setter) {
            _charSet = _session;
            _getter = getter;
            _setter = setter;
        }

public double Maximum
        {
            get
            {
                if (_maxGetter != null)
                {
                    Int32 toReturn;
                    Utilities.ThrowError(_maxGetter(_charSet, out toReturn));
                    return toReturn;
                }
                else
                {
                    Int32 toReturn, unused;
                    Utilities.ThrowError(_getter(_charSet, out unused, out toReturn));
                    return toReturn;
                }
            }
            set
            {
                if (_maxSetter != null)
                {
                    Utilities.ThrowError(_maxSetter(_charSet, (Int32)Math.Round(value)));
                }
                else
                {
                    Utilities.ThrowError(_setter(_charSet, (Int32)Math.Round(Minimum), (Int32)Math.Round(value)));
                }
            }
        }

        
        public double Minimum
        {
            get
            {
                if (_minGetter != null)
                {
                    Int32 toReturn;
                    Utilities.ThrowError(_minGetter(_charSet, out toReturn));
                    return toReturn;
                }
                else
                {
                    Int32 toReturn, unused;
                    Utilities.ThrowError(_getter(_charSet, out toReturn, out unused));
                    return toReturn;
                }
            }
            set
            {
                if (_minSetter != null)
                {
                    Utilities.ThrowError(_minSetter(_charSet, (Int32)Math.Round(value)));
                }
                else
                {
                    Utilities.ThrowError(_setter(_charSet, (Int32)Math.Round(value), (Int32)Math.Round(Maximum)));
                }
            }
        }

public void Initialize(double minimum, double maximum)
        {
            if (_setter != null)
            {
                Utilities.ThrowError(_setter(_charSet, (Int32)Math.Round(minimum), (Int32)Math.Round(maximum)));
            }
            else
            {
                Utilities.ThrowError(_minSetter(_charSet, (Int32)Math.Round(minimum)));
                Utilities.ThrowError(_maxSetter(_charSet, (Int32)Math.Round(maximum)));
            }
        }
    }

}
