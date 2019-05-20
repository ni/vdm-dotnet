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

namespace NationalInstruments.Vision.WindowsForms.Internal
{
    /// <summary>
    /// These are messages that we receive from the Vision DLL.
    /// </summary>
    internal enum ViewerMessage
    {
        ToolChanged = 0x403,
        Zoomed = 0x404,
        ScrollPosChanged = 0x405,
        UpdateWindowCorrectly = 0x406,
        CallWindowHandler = 0x407,
        NewElement = 0x408,
        MoveElement = 0x409,
        ChangePointInElement = 0x40A,
        DeleteElement = 0x40B,
        Updating = 0x40C,
        ImageMouseEvent = 0x40D,
        ImageDisplayMsgCall = 0x40E,
        ScaleRect = 0x40F,
        ChangedElement = 0x410,
        KeyPressed = 0x411
    }

    internal enum CVI_ViewerTool
    {
        NoTool = -1,
        Selection = 0,
        Point = 1,
        Line = 2,
        Rectangle = 3,
        Oval = 4,
        Polygon = 5,
        ClosedFreehand = 6,
        Annulus = 7,
        ZoomIn = 8,
        Pan = 9,
        Polyline = 10,
        Freehand = 11,
        RotatedRectangle = 12,
        ZoomOut = 13
    }
    internal enum ImmediateUpdateMode
    {
        Normal = 0,
        Ignore = 1,
        Force = 2
    }

    static internal class ViewerHelpers
    {
        public static ViewerTools ConvertToExternalTool(CVI_ViewerTool tool)
        {
            string toolName = Enum.GetName(typeof(CVI_ViewerTool), tool);
            try
            {
                return (ViewerTools) Enum.Parse(typeof(ViewerTools), toolName);
            }
            catch (ArgumentException)
            {
                throw new VisionException(ErrorCode.InvalidTool);
            }
        }
        public static CVI_ViewerTool ConvertToInternalTool(ViewerTools tool)
        {
            string toolName = Enum.GetName(typeof(ViewerTools), tool);
            try
            {
                return (CVI_ViewerTool) Enum.Parse(typeof(CVI_ViewerTool), toolName);
            }
            catch (ArgumentException)
            {
                throw new VisionException(ErrorCode.InvalidTool);
            }
        }
    }
}
