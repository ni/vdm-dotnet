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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using NationalInstruments.Vision.Internal;
using NationalInstruments.Vision;
using NationalInstruments.Vision.WindowsForms.Internal;
using NationalInstruments.Restricted;

namespace NationalInstruments.Vision.WindowsForms
{
    //==============================================================================================
    /// <summary>
    /// Represents a National Instruments Windows Forms image viewer control to display images.
    /// </summary>
    /// <remarks>
    /// At design time, you can drag and drop the image viewer control from the Toolbox onto your form.
    /// </remarks>

    [ToolboxBitmap(typeof(Resfinder), "NationalInstruments.Vision.Icons.CWIMAQViewerSmall.bmp")]
    [Description("Displays and allows user interaction on an image.")]
    [DefaultProperty("Image")]
    [DefaultEvent("RoiChanged")]
    public sealed partial class ImageViewer : UserControl, IDisposable
    {
        private VisionImage _image = new VisionImage();
        private IntPtr _childHwnd = IntPtr.Zero;
        private bool _inDesignMode = false;
        private bool _firstCall = true;
        private bool _firstOnPaint = true;
        
        private Palette _palette = null;
        private bool _showScrollbars = false;
        private ViewerTools _tool = ViewerTools.Pan;
        private ViewerTools _toolsShown = ViewerTools.All;
        private bool _showImageInfo = false;
        private bool _showToolbar = false;
        private bool _useNonTearing = false;
        private Int32 _maxContours = -1;
        private bool _immediateUpdates = false;
        private bool _zoomToFit = false;
        private ViewerRoi _roi = null;
        private PointContour _origin = new PointContour(0, 0);
        private bool _originChanged = false;
        private PointContour _center = new PointContour(0, 0);
        private bool _centerChanged = false;
        private bool _autoDelete = true;
        private bool _contextSensitiveTools = true;
        private Rgb32Value _toolsTextColor = new Rgb32Value(Color.FromKnownColor(KnownColor.WindowText));
        private ViewerBackgroundOptions _backgroundOptions = null;
        private DisplayMapping _displayMapping = null;
        private ZoomInfo _zoomInfo = null;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ActiveTool" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when the active tool changes.")]
        public event EventHandler<EventArgs> ActiveToolChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when a mouse button is pressed over the viewer.
        /// </summary>

        [Category("Mouse")]
        [Description("Occurs when a mouse button is clicked on the image.")]
        public event EventHandler<ImageMouseEventArgs> ImageMouseDown;
        //==========================================================================================
        /// <summary>
        /// Occurs when a mouse button is released over the viewer.
        /// </summary>

        [Category("Mouse")]
        [Description("Occurs when a mouse button is let go on the image.")]
        public event EventHandler<ImageMouseEventArgs> ImageMouseUp;
        //==========================================================================================
        /// <summary>
        /// Occurs when the mouse is moved over the viewer.
        /// </summary>

        [Category("Mouse")]
        [Description("Occurs when the mouse is moved on the image.")]
        public event EventHandler<ImageMouseEventArgs> ImageMouseMove;
        //==========================================================================================
        /// <summary>
        /// Occurs when the image is panned with the pan viewer tool.
        /// </summary>

        [Category("Mouse")]
        [Description("Occurs when the image is panned.")]
        public event EventHandler<ImagePannedEventArgs> ImagePanned;
        //==========================================================================================
        /// <summary>
        /// Occurs when the image is zoomed with the zoom in or zoom out viewer tool.
        /// </summary>

        [Category("Mouse")]
        [Description("Occurs when the image is zoomed in or out.")]
        public event EventHandler<ImageZoomedEventArgs> ImageZoomed;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Roi" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when the Region of Interest changes.")]
        public event EventHandler<ContoursChangedEventArgs> RoiChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.DisplayMapping" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when the DisplayMapping changes.")]
        public event EventHandler DisplayMappingChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ZoomToFit" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ZoomToFit changes.")]
        public event EventHandler ZoomToFitChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowImageInfo" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ShowImageInfo changes.")]
        public event EventHandler ShowImageInfoChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Palette" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when the Palette changes.")]
        public event EventHandler PaletteChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ContextSensitiveTools" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ContextSensitiveTools changes.")]
        public event EventHandler ContextSensitiveToolsChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Center" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when Center changes.")]
        public event EventHandler CenterChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Origin" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when Origin changes.")]
        public event EventHandler OriginChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.BackgroundOptions" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when the BackgroundOptions changes.")]
        public event EventHandler BackgroundOptionsChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImmediateUpdates" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ImmediateUpdates changes.")]
        public event EventHandler ImmediateUpdatesChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowToolbar" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ShowToolbar changes.")]
        public event EventHandler ShowToolbarChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when  <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowScrollbars" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ShowScrollbars changes.")]
        public event EventHandler ShowScrollbarsChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ToolsShown" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ToolsShown changes.")]
        public event EventHandler ToolsShownChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.NonTearingDisplay" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when NonTearingDisplay changes.")]
        public event EventHandler NonTearingDisplayChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.AutoDelete" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when AutoDelete changes.")]
        public event EventHandler AutoDeleteChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageInfoTextColor" crefType="Unqualified"/> changes.
        /// </summary>

        [Category("Property Changed")]
        [Description("Occurs when ImageInfoTextColor changes.")]
        public event EventHandler ImageInfoTextColorChanged;
        //==========================================================================================
        /// <summary>
        /// Occurs when <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Image" crefType="Unqualified"/> changes.
        /// </summary>
        /// <remarks>
        /// This event occurs when either the data in the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Image" crefType="Unqualified"/> changes, 
        /// or a new <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Image" crefType="Unqualified"/> attached with the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Attach" crefType="Unqualified"/> method.
        /// </remarks>

        [Category("Property Changed")]
        [Description("Occurs when the Image data changes.")]
        public event EventHandler ImageChanged;
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/> class.
        /// </summary>

        public ImageViewer()
        {
            InitializeComponent();
            _pictureBox1.SetOwningViewer(this);
            _palette = new Palette();
            _palette.PaletteChanged += _palette_PaletteChanged;
            _roi = new ViewerRoi(this);
            _roi.ContoursChanged += _roi_ContoursChanged;
            _backgroundOptions = new ViewerBackgroundOptions(this);
            _displayMapping = new DisplayMapping(this);
            _zoomInfo = new ZoomInfo(this);
            Attach(_image, true);
            _origin.PropertyChanged += new EventHandler<EventArgs>(_origin_PropertyChanged);
            _center.PropertyChanged += new EventHandler<EventArgs>(_center_PropertyChanged);
            this.Resize += new EventHandler(OnResize);
        }

        void OnResize(object sender,EventArgs ee) {
            VisionDllCommon.SetWindowPos(_childHwnd, IntPtr.Zero, 0, 0, _pictureBox1.Width, _pictureBox1.Height, 0);
        }

        
        void _roi_ContoursChanged(object sender, ContoursChangedEventArgs e)
        {
            OnRoiChanged(e);
        }

void _palette_PaletteChanged(object sender, EventArgs e)
        {
            UpdatePalette();
            OnPaletteChanged(EventArgs.Empty);
        }

void _center_PropertyChanged(object sender, EventArgs e)
        {
            // This means the user has changed the center, so update the viewer correspondingly.
            if (_childHwnd != IntPtr.Zero)
            {
                Point center = new Point((Int32)Math.Round(_center.X), (Int32)Math.Round(_center.Y));
                VisionDllCommon.Priv_SetCenterPos(_childHwnd, ref center);
            }
            else
            {
                _centerChanged = true;
            }
            OnCenterChanged(EventArgs.Empty);
        }

private void _origin_PropertyChanged(object sender, EventArgs e)
        {
            // This means the user has changed the origin, so update the viewer correspondingly.
            if (_childHwnd != IntPtr.Zero)
            {
                Point origin = new Point((Int32)Math.Round(_origin.X), (Int32)Math.Round(_origin.Y));
                VisionDllCommon.Priv_SetImageOrigin(_childHwnd, ref origin);
            }
            else
            {
                _originChanged = true;
            }
            OnOriginChanged(EventArgs.Empty);
        }

internal void SetZoom()
        {
            float zoomX = (float)_zoomInfo.X;
            float zoomY = (float)_zoomInfo.Y;
            VisionDllCommon.Priv_Zoom2(_childHwnd, ref zoomX, ref zoomY, true);
            OnImageZoomed(new ImageZoomedEventArgs(zoomX, zoomY));
        }

        internal const int WM_MOUSEMOVE = 0x200;
        internal const int WM_LBUTTONDOWN = 0x201;
        internal const int WM_LBUTTONUP = 0x202;
        internal const int WM_LBUTTONDBLCLK = 0x203;
        internal const int WM_RBUTTONDOWN = 0x204;
        internal const int WM_RBUTTONUP = 0x205;
        internal const int WM_RBUTTONDBLCLK = 0x206;
        internal const int WM_MBUTTONDOWN = 0x207;
        internal const int WM_MBUTTONUP = 0x208;
        internal const int WM_MBUTTONDBLCLK = 0x209;
        internal const int MK_LBUTTON = 0x1;
        internal const int MK_RBUTTON = 0x2;
        internal const int MK_MBUTTON = 0x10;

        //==========================================================================================
        /// <summary>
        /// Gets the collection of region objects that specify regions on the viewer.
        /// </summary>
        /// <value>
        /// The collection of region objects that specify regions on the viewer.
        /// </value>
        /// <remarks>
        /// If you specify a region through the image viewer control, the region is automatically added to this collection.
        /// </remarks>

        [Category("Behavior")]
        [Description("The Region of Interest on the viewer")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewerRoi Roi
        {
            get
            {
                return _roi;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the background style and color information for the viewer.
        /// </summary>
        /// <value>
        /// The background style and color information for the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/>.
        /// </value>

        [Category("Appearance")]
        [Description("Whether to show scrollbars on the image")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewerBackgroundOptions BackgroundOptions
        {
            get
            {
                return _backgroundOptions;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the mapping technique used when displaying a 16-bit grayscale image. 
        /// </summary>
        /// <value>
        /// The mapping technique used when displaying a 16-bit grayscale image. 
        /// </value>

        [Category("Appearance")]
        [Description("The pixel mapping policy for displaying 16-bit images")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DisplayMapping DisplayMapping
        {
            get
            {
                return _displayMapping;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the zoom factor.
        /// </summary>
        /// <value>
        /// The zoom factor.
        /// </value>

        [Category("Appearance")]
        [Description("The zoom level of the image viewer")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZoomInfo ZoomInfo
        {
            get
            {
                return _zoomInfo;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the image object that the viewer displays.
        /// </summary>
        /// <value>
        /// The image object that the viewer displays.
        /// </value>
        /// <remarks>
        /// When you create an <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/>, the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Image" crefType="Unqualified"/> property contains a new VisionImage. You can manipulate this image like any other, or you can display a new image by calling <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Attach" crefType="Unqualified"/>. 
        /// </remarks>

        [Category("Behavior")]
        [Description("The image that the viewer is displaying")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VisionImage Image
        {
            get
            {
                return _image;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the viewer displays scrollbars.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the viewer displays scrollbars; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </value>

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether to show scrollbars on the image")]
        public bool ShowScrollbars
        {
            get
            {
                return _showScrollbars;
            }
            set
            {
                bool oldShowScrollbars = _showScrollbars;
                _showScrollbars = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_ShowScrollBars(_childHwnd, _showScrollbars);
                }
                if (oldShowScrollbars != _showScrollbars)
                {
                    OnShowScrollbarsChanged(EventArgs.Empty);
                }
            }
        }

internal Int32 MaximumContours
        {
            get
            {
                return _maxContours;
            }
            set
            {
                _maxContours = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_SetMaxContourCount(_childHwnd, value);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the viewer displays image information on the status bar.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the viewer displays image information on the status bar; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </value>

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether to show image information, including type and dimensions")]
        public bool ShowImageInfo
        {
            get
            {
                return _showImageInfo;
            }
            set
            {
                bool oldShowImageInfo = _showImageInfo;
                _showImageInfo = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    RecalculateToolsPosition();
                }
                if (oldShowImageInfo != _showImageInfo)
                {
                    OnShowImageInfoChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the viewer displays a toolbar.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the viewer displays a toolbar; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </value>

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether to show the toolbar, which allows easy selection of tools")]
        public bool ShowToolbar
        {
            get
            {
                return _showToolbar;
            }
            set
            {
                bool oldShowToolbar = _showToolbar;
                _showToolbar = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    RecalculateToolsPosition();
                }
                if (oldShowToolbar != _showToolbar)
                {
                    OnShowToolbarChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the currently selected tool.
        /// </summary>
        /// <value>
        /// The currently selected tool.
        /// </value>

        [DefaultValue(typeof(ViewerTools), "Pan")]
        [Category("Behavior")]
        [Description("What tool is currently active")]
        public ViewerTools ActiveTool {
            get {
                if (_childHwnd != IntPtr.Zero)
                {
                    CVI_ViewerTool cviTool;
                    VisionDllCommon.Priv_GetTool(_childHwnd, out cviTool);
                    _tool = ViewerHelpers.ConvertToExternalTool(cviTool);
                }
                return _tool;
            }
            set {
                // Do the conversion first so if it fails (i.e. the tool they passed in is invalid)
                // we don't set it.
                CVI_ViewerTool cviTool = ViewerHelpers.ConvertToInternalTool(value);
                ViewerTools oldTool = _tool;
                _tool = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_SetTool(_childHwnd, cviTool);
                }
                if (oldTool != _tool)
                {
                    OnActiveToolChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets which tools are shown on the toolbar.
        /// </summary>
        /// <value>
        /// 	<see cref="NationalInstruments.Vision.WindowsForms.ViewerTools" crefType="Unqualified"/> information on the status bar. The default value is <see cref="NationalInstruments.Vision.WindowsForms.ViewerTools.All" crefType="Unqualified"/>.
        /// </value>
        /// <remarks>
        /// This property is only valid if <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowToolbar" crefType="Unqualified"/> is set to <see langword="true"/>.
        /// </remarks>

        [DefaultValue(ViewerTools.All)]
        [Category("Appearance")]
        [Description("Which tools are shown on the toolbar")]
        public ViewerTools ToolsShown
        {
            get
            {
                return _toolsShown;
            }
            set
            {
                ViewerTools oldToolsShown = _toolsShown;
                _toolsShown = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    UpdateToolsShown();
                }
                if (oldToolsShown != _toolsShown)
                {
                    OnToolsShownChanged(EventArgs.Empty);
                }
            }
        }

internal void UpdateToolsShown()
        {
            CVI_ViewerTool[] cviTools = new CVI_ViewerTool[32];
            for (int i = 0; i < 32; ++i)
            {
                cviTools[i] = CVI_ViewerTool.NoTool;
                ViewerTools toolToCheck = (ViewerTools)(1 << i);
                if ((_toolsShown & toolToCheck) != 0)
                {
                    cviTools[i] = ViewerHelpers.ConvertToInternalTool(toolToCheck);
                }
            }
            VisionDllCommon.Priv_SetVisibleTools(_childHwnd, cviTools, 32);
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the display should be in nontearing mode.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the display is in nontearing mode; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </value>

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether the display should be in nontearing mode")]
        public bool NonTearingDisplay
        {
            get
            {
                return _useNonTearing;
            }
            set
            {
                bool oldNonTearingDisplay = _useNonTearing;
                _useNonTearing = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_SetWindNonTearing(_childHwnd, _useNonTearing);
                }
                if (oldNonTearingDisplay != _useNonTearing)
                {
                    OnNonTearingDisplayChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the display should automatically resize the image to fit in the viewer.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the display automatically resizes the image to fit in the viewer; otherwise, <see langword="false"/>. The default value is <see langword="false"/>.  
        /// </value>

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Whether to automatically zoom to fit the image")]
        public bool ZoomToFit
        {
            get
            {
                // ZoomToFit can be changed out from under us (if the user zooms the image or
                // sets the zoom), so update it from the DLL.
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_ZoomToFit(_childHwnd, ref _zoomToFit, 0);
                }
                return _zoomToFit;
            }
            set
            {
                bool oldZoomToFit = _zoomToFit;
                _zoomToFit = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_ZoomToFit(_childHwnd, ref _zoomToFit, 1);
                }
                if (_zoomToFit != oldZoomToFit)
                {
                    OnZoomToFitChanged(EventArgs.Empty);
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the viewer draws new data as soon as it is available, or if the form refreshes the viewer when it draws other controls.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the viewer draws new data as soon as it is available; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </value>

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether the viewer draws new data as soon as it is available, or if the form refreshes the viewer when it draws other controls.")]
        public bool ImmediateUpdates
        {
            get
            {
                return _immediateUpdates;
            }
            set
            {
                bool oldImmediateUpdates = _immediateUpdates;
                _immediateUpdates = value;
                if (oldImmediateUpdates != _immediateUpdates)
                {
                    OnImmediateUpdatesChanged(EventArgs.Empty);
                }
            }
        }

internal void UpdatePalette() {
            if (_childHwnd != IntPtr.Zero) {
                if (_palette.Type != PaletteType.UserDefined)
                {
                    VisionDllCommon.Priv_SetPalette(_childHwnd, (int)_palette.Type, IntPtr.Zero);
                }
                else
                {
                    PaletteEntry[] tempEntries = new PaletteEntry[256];
                    _palette._entries.CopyTo(tempEntries, 0);
                    // Fill in the rest of the palette with grayscale entries.
                    for (int i = _palette._entries.Count; i < 256; ++i)
                    {
                        tempEntries[i] = new PaletteEntry((byte)i, (byte)i, (byte)i);
                    }
                    VisionDllCommon.Priv_SetPalette(_childHwnd, (int)_palette.Type, tempEntries);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the palette that the viewer uses to display the image.
        /// </summary>
        /// <value>
        /// The palette that the viewer uses to display the image.
        /// </value>

        [Category("Behavior")]
        [Description("The palette used to display 8-bit images")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Palette Palette
        {
            get
            {
                return _palette;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                // Remove the old handler, and install a new one.
                _palette.PaletteChanged -= _palette_PaletteChanged;
                _palette = value;
                _palette.PaletteChanged += _palette_PaletteChanged;
                // Make sure we indicate that the palette has changed now.
                _palette_PaletteChanged(_palette, EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns whether <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Palette" crefType="Unqualified"/> is different from its default value.
        /// </summary>
        /// <returns>
        /// 	<see langword="true"/> if <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Palette" crefType="Unqualified"/>   is different from its default value; otherwise, <see langword="false"/>.
        /// </returns>

        public bool ShouldSerializePalette()
        {
            return _palette.Type != PaletteType.Gray;
        }
        //==========================================================================================
        /// <summary>
        /// Resets <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Palette" crefType="Unqualified"/> to its default value.
        /// </summary>

        public void ResetPalette()
        {
            Palette = new Palette();
        }

        //==========================================================================================
        /// <summary>
        /// Gets the x-coordinate and y-coordinate of the image in the upper left corner of the viewer when the image is larger than the viewer.
        /// </summary>
        /// <value>
        /// The x-coordinate and y-coordinate of the image in the upper left corner of the viewer when the image is larger than the viewer.
        /// </value>

        [Category("Behavior")]
        [Description("The origin in pixel coordinates")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PointContour Origin
        {
            get
            {
                return _origin;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the x-coordinate and y-coordinate of the image in the center of the viewer when the image is larger than the viewer.
        /// </summary>
        /// <value>
        /// The x-coordinate and y-coordinate of the image. 
        /// </value>
        /// <remarks>
        /// If the width of the image is less than the width of the viewer, the viewer ignores this property and centers the image horizontally.
        /// </remarks>

        [Category("Behavior")]
        [Description("The center in pixel coordinates")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PointContour Center
        {
            get
            {
                // Update the center position from the DLL, if possible.
                if (_childHwnd != IntPtr.Zero)
                {
                    Point center = new Point();
                    VisionDllCommon.Priv_GetCenterPos(_childHwnd, ref center);
                    // We don't want a notification here
                    _center.PropertyChanged -= _center_PropertyChanged;
                    _center.X = center.X;
                    _center.Y = center.Y;
                    _center.PropertyChanged += _center_PropertyChanged;
                }
                return _center;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether existing regions are removed from the collection when you add a new region from the image viewer.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if existing regions are removed from the collection when you add a new region from the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/>; otherwise, <see langword="false"/>. The default value is <see langword="true"/>. 
        /// </value>

        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Whether all regions should be removed when a new region is added from the ImageViewer interface.")]
        public bool AutoDelete
        {
            get
            {
                return _autoDelete;
            }
            set
            {
                bool oldAutoDelete = _autoDelete;
                _autoDelete = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_SetAutoDelete(_childHwnd, _autoDelete);
                }
                if (oldAutoDelete != _autoDelete)
                {
                    OnAutoDeleteChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether context sensitive tool selection is enabled or disabled.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the context sensitive tool selection is enabled; otherwise, <see langword="false"/>. The default value is <see langword="true"/>. 
        /// </value>

        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Whether to show the context-sensitive tools.")]
        public bool ContextSensitiveTools
        {
            get
            {
                return _contextSensitiveTools;
            }
            set
            {
                bool oldContextSensitiveTools = _contextSensitiveTools;
                _contextSensitiveTools = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_ContextSensitiveTools(_childHwnd, _contextSensitiveTools);
                }
                if (oldContextSensitiveTools != _contextSensitiveTools)
                {
                    OnContextSensitiveToolsChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the color of the image information text, if <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowImageInfo" crefType="Unqualified"/> is set to <see langword="true"/>.
        /// </summary>
        /// <value>
        /// the color of the image information text, if <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ShowImageInfo" crefType="Unqualified"/> is set to <see langword="true"/>.
        /// </value>

        [Category("Appearance")]
        [Description("Color of the image info text")]
        public Rgb32Value ImageInfoTextColor
        {
            get
            {
                return _toolsTextColor;
            }
            set
            {
                Rgb32Value oldToolsTextColor = _toolsTextColor;
                _toolsTextColor = value;
                if (_childHwnd != IntPtr.Zero)
                {
                    VisionDllCommon.Priv_SetToolsDlgTextColor(_childHwnd, _toolsTextColor);
                }
                if (oldToolsTextColor != _toolsTextColor)
                {
                    OnImageInfoTextColorChanged(EventArgs.Empty);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns whether the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageInfoTextColor" crefType="Unqualified"/>  is different from its default value.
        /// </summary>
        /// <returns>
        /// 	<see langword="true"/> if <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageInfoTextColor" crefType="Unqualified"/>  is different from its default value; otherwise, <see langword="false"/>.
        /// </returns>

        public bool ShouldSerializeImageInfoTextColor()
        {
            return _toolsTextColor != new Rgb32Value(Color.FromKnownColor(KnownColor.WindowText));
        }
        //==========================================================================================
        /// <summary>
        /// Resets <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageInfoTextColor" crefType="Unqualified"/> to its default value.
        /// </summary>

        public void ResetImageInfoTextColor()
        {
            ImageInfoTextColor = new Rgb32Value(Color.FromKnownColor(KnownColor.WindowText));
        }

        //==========================================================================================
        /// <summary>
        /// Attaches an image object to the viewer.
        /// </summary>
        /// <param name="image">
        /// The image to attach to the viewer.
        /// </param>
        /// <remarks>
        /// After calling this method, you can manipulate the image with the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.Image" crefType="Unqualified"/> property.
        /// </remarks>

        public void Attach(VisionImage image)
        {
            Attach(image, false);
        }

        
        private void Attach(VisionImage image, bool firstCall) 
        {
            if (firstCall || _image != image)
            {
                // Don't dispose _image here, since it could be something the user passed us.
                if (!firstCall)
                {
                    _image.RemoveViewer(this);
                    _image = image;
                }
                _image.AddViewer(this);
                OnImageChange();
            }
        }

internal void OnImageUpdated(ImmediateUpdateMode mode)
        {
            System.Drawing.Rectangle clientRect = _pictureBox1.ClientRectangle;
            // Invalidate the rectangle to make sure we get redrawn
            VisionDllCommon.InvalidateRect(_childHwnd, ref clientRect, false);
            if (mode == ImmediateUpdateMode.Force || (mode == ImmediateUpdateMode.Normal && _immediateUpdates))
            {
                _pictureBox1.Update();
            }
            OnImageChanged(EventArgs.Empty);
        }

        //==========================================================================================
        /// <summary>
        /// Redraws the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/> control immediately.
        /// </summary>

        public void RefreshImage()
        {
            OnImageUpdated(ImmediateUpdateMode.Force);
        }

        
        private void OnDisplayMappingChanged(EventArgs args)
        {
            EventHandler temp = DisplayMappingChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnZoomToFitChanged(EventArgs args)
        {
            EventHandler temp = ZoomToFitChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnShowImageInfoChanged(EventArgs args)
        {
            EventHandler temp = ShowImageInfoChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnPaletteChanged(EventArgs args)
        {
            EventHandler temp = PaletteChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnContextSensitiveToolsChanged(EventArgs args)
        {
            EventHandler temp = ContextSensitiveToolsChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnCenterChanged(EventArgs args)
        {
            EventHandler temp = CenterChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnOriginChanged(EventArgs args)
        {
            EventHandler temp = OriginChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnBackgroundOptionsChanged(EventArgs args)
        {
            EventHandler temp = BackgroundOptionsChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImmediateUpdatesChanged(EventArgs args)
        {
            EventHandler temp = ImmediateUpdatesChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnShowToolbarChanged(EventArgs args)
        {
            EventHandler temp = ShowToolbarChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnShowScrollbarsChanged(EventArgs args)
        {
            EventHandler temp = ShowScrollbarsChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnToolsShownChanged(EventArgs args)
        {
            EventHandler temp = ToolsShownChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnNonTearingDisplayChanged(EventArgs args)
        {
            EventHandler temp = NonTearingDisplayChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnAutoDeleteChanged(EventArgs args)
        {
            EventHandler temp = AutoDeleteChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageInfoTextColorChanged(EventArgs args)
        {
            EventHandler temp = ImageInfoTextColorChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageChanged(EventArgs args)
        {
            EventHandler temp = ImageChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

internal void OnImageChange()
        {
            CreateChildHwndIfNotCreated();
            VisionDllCommon.Priv_AttachImage(_childHwnd, _image._image);
            OnImageUpdated(ImmediateUpdateMode.Normal);
            // Since we may have created our _childHwnd for the first time, call OnDesignModeChange().
            OnDesignModeChange();
            OnImageChanged(EventArgs.Empty);
        }

private void OnRoiChanged(ContoursChangedEventArgs args)
        {
            EventHandler<ContoursChangedEventArgs> temp = RoiChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

private void OnActiveToolChanged(EventArgs args)
        {
            EventHandler<EventArgs> temp = ActiveToolChanged;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageMouseDown(ImageMouseEventArgs args)
        {
            EventHandler<ImageMouseEventArgs> temp = ImageMouseDown;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageMouseUp(ImageMouseEventArgs args)
        {
            EventHandler<ImageMouseEventArgs> temp = ImageMouseUp;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageMouseMove(ImageMouseEventArgs args)
        {
            EventHandler<ImageMouseEventArgs> temp = ImageMouseMove;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImagePanned(ImagePannedEventArgs args)
        {
            EventHandler<ImagePannedEventArgs> temp = ImagePanned;
            if (temp != null)
            {
                temp(this, args);
            }
        }

        
        private void OnImageZoomed(ImageZoomedEventArgs args)
        {
            EventHandler<ImageZoomedEventArgs> temp = ImageZoomed;
            if (temp != null)
            {
                temp(this, args);
            }
        }
        internal void CreateChildHwndIfNotCreated() {
            if (_childHwnd == IntPtr.Zero)
            {
                IntPtr pictureBoxHandle = _pictureBox1.Handle;
                _childHwnd = VisionDllCommon.Priv_CreateChildWindow(pictureBoxHandle);
                _pictureBox1.AssignHandle(_childHwnd);
            }
        }

        
        internal void RecalculateToolsPosition()
        {
            if (!_inDesignMode && (_showImageInfo || _showToolbar))
            {
                VisionDllCommon.Priv_ShowColor(_childHwnd, _showImageInfo);
                // This is the new-style image info.
                VisionDllCommon.Priv_SetROIInfo(_childHwnd, _showImageInfo);
                VisionDllCommon.Priv_ShowToolbar(_childHwnd, _showToolbar);
                Size minSize;
                VisionDllCommon.Priv_GetToolsDlgMinSizeWithWidth(_childHwnd, _pictureBox1.Width, out minSize);
                if (_pictureBox1.Width >= minSize.Width && _pictureBox1.Height >= (minSize.Height + 1))
                {
                    UInt32 offset = (UInt32)((_pictureBox1.Width - minSize.Width) / 2);
                    VisionDllCommon.SetWindowPos(_childHwnd, IntPtr.Zero, 0, 0, _pictureBox1.Width, _pictureBox1.Height - (minSize.Height + 1), 0);
                    VisionDllCommon.Priv_SetToolsDlgHeightAndOffset(_childHwnd, (uint)(minSize.Height + 1), offset);
                }
                else
                {
                    // We don't have room to show the tools.
                    VisionDllCommon.SetWindowPos(_childHwnd, IntPtr.Zero, 0, 0, _pictureBox1.Width, _pictureBox1.Height, 0);
                }
                UpdateToolsShown();
            }
            else
            {
                VisionDllCommon.Priv_ShowColor(_childHwnd, false);
                VisionDllCommon.Priv_SetROIInfo(_childHwnd, false);
                VisionDllCommon.Priv_ShowToolbar(_childHwnd, false);
                VisionDllCommon.SetWindowPos(_childHwnd, IntPtr.Zero, 0, 0, _pictureBox1.Width, _pictureBox1.Height, 0);
            }
        }

        
        private void OnDesignModeChange()
        {
            CreateChildHwndIfNotCreated();
            if (_firstCall)
            {
                VisionDllCommon.Priv_ZoomToFit(_childHwnd, ref _zoomToFit, 1);
                CVI_ViewerTool cviTool = ViewerHelpers.ConvertToInternalTool(_tool);
                VisionDllCommon.Priv_SetTool(_childHwnd, cviTool);
                _firstCall = false;
            }
            if (_originChanged)
            {
                Point origin = new Point((Int32)Math.Round(_origin.X), (Int32)Math.Round(_origin.Y));
                VisionDllCommon.Priv_SetImageOrigin(_childHwnd, ref origin);
                _originChanged = false;
            }
            if (_centerChanged)
            {
                Point center = new Point((Int32)Math.Round(_center.X), (Int32)Math.Round(_center.Y));
                VisionDllCommon.Priv_SetCenterPos(_childHwnd, ref center);
                _centerChanged = false;
            }
            VisionDllCommon.Priv_ShowIndicators(_childHwnd, !_inDesignMode);
            VisionDllCommon.Priv_SetAutoDelete(_childHwnd, _autoDelete);
            VisionDllCommon.Priv_ContextSensitiveTools(_childHwnd, _contextSensitiveTools);
            VB_ConversionPolicy policy = new VB_ConversionPolicy();
            policy.ConvertFromExternal(_displayMapping);
            VisionDllCommon.Priv_SetDisplayMapping(_childHwnd, ref policy);
            VisionDllCommon.Priv_SetToolsDlgTextColor(_childHwnd, _toolsTextColor);
            // If possible, cache the current tool and zoom to fit so when we set it below we don't reset it to an old value.
            ViewerTools unusedTool = ActiveTool;
            bool unusedZoomToFit = ZoomToFit;
            // Show the image if we have one and we're in runtime mode.
            RecalculateToolsPosition();
            if (!_inDesignMode)
            {
                VisionDllCommon.Priv_ShowScrollBars(_childHwnd, _showScrollbars);
                VisionDllCommon.Priv_SetMaxContourCount(_childHwnd, _maxContours);
                CVI_ViewerTool cviTool = ViewerHelpers.ConvertToInternalTool(_tool);
                VisionDllCommon.Priv_SetTool(_childHwnd, cviTool);
                VisionDllCommon.Priv_SetWindNonTearing(_childHwnd, _useNonTearing);
                // Since we're transitioning from design mode to run-time mode, we haven't been displaying an image and
                // so our palette probably hasn't been set correctly.  Make sure that it is.
                UpdatePalette();
            }
            if (_inDesignMode)
            {
                VisionDllCommon.ShowWindow(_childHwnd, 0 /* SW_HIDE */);
            }
            else
            {
                VisionDllCommon.ShowWindow(_childHwnd, 5 /* SW_SHOW */);
            }
        }

protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bool newInDesignMode = (this.Site != null && this.Site.DesignMode);
            if (newInDesignMode != _inDesignMode || _firstOnPaint)
            {
                _inDesignMode = newInDesignMode;
                OnDesignModeChange();
                _firstOnPaint = false;
            }
        }

internal unsafe void OnViewerMessage(Message m)
        {
            ViewerMessage type = (ViewerMessage)m.Msg;
            IntPtr roiElement = m.WParam;
            switch (type)
            {
                case ViewerMessage.NewElement:
                    Roi.AddElementFromVision(roiElement);
                    break;
                case ViewerMessage.DeleteElement:
                    Roi.RemoveElementFromVision(roiElement);
                    break;
                case ViewerMessage.MoveElement:
                case ViewerMessage.ChangePointInElement:
                case ViewerMessage.ChangedElement:
                    Roi.HandleChangedMessage(type, roiElement, m.LParam);
                    break;
                case ViewerMessage.Updating:
                    Roi.HandleUpdatingMessage(roiElement, m.LParam != IntPtr.Zero);
                    break;
                case ViewerMessage.ToolChanged:
                    _tool = ViewerHelpers.ConvertToExternalTool((CVI_ViewerTool)m.WParam);
                    OnActiveToolChanged(EventArgs.Empty);
                    break;
                case ViewerMessage.ImageMouseEvent:
                    int mouseEvent = (int) m.WParam;
                    VB_MouseEventInfo mouseEventInfo = (VB_MouseEventInfo)Marshal.PtrToStructure(m.LParam, typeof(VB_MouseEventInfo));
                    HandleImageMouseEvent(mouseEvent, mouseEventInfo);
                    break;
                case ViewerMessage.ScrollPosChanged:
                    Point newOrigin = (Point)Marshal.PtrToStructure(m.WParam, typeof(Point));
                    Point change = (Point)Marshal.PtrToStructure(m.LParam, typeof(Point));
                    // We don't want a notification here
                    _origin.PropertyChanged -= _origin_PropertyChanged;
                    _origin.X = newOrigin.X;
                    _origin.Y = newOrigin.Y;
                    _origin.PropertyChanged += _origin_PropertyChanged;
                    OnImagePanned(new ImagePannedEventArgs(change.X, change.Y));
                    break;
                case ViewerMessage.Zoomed:
                    float xZoom = *((float*)m.WParam.ToPointer());
                    float yZoom = *((float*)m.LParam.ToPointer());
                    _zoomInfo._x = xZoom;
                    _zoomInfo._y = yZoom;
                    OnImageZoomed(new ImageZoomedEventArgs(_zoomInfo._x, _zoomInfo._y));
                    break;
                case ViewerMessage.KeyPressed:
                    VB_KeyMessage vbMessage = (VB_KeyMessage)Marshal.PtrToStructure(m.WParam, typeof(VB_KeyMessage));
                    Message message = Message.Create(this.Handle, vbMessage.Message, vbMessage.WParam, vbMessage.LParam);
                    ProcessKeyEventArgs(ref message);
                    break;
            }
        }

internal IntPtr CreateElement(IntPtr visionContour, bool redraw)
        {
            return VisionDllCommon.Priv_CreateElement(_childHwnd, visionContour, redraw);
        }

internal bool DeleteElement(IntPtr element)
        {
            return VisionDllCommon.Priv_DeleteElement(_childHwnd, element);
        }

internal IntPtr ReplaceElement(IntPtr element, IntPtr visionContour)
        {
            return VisionDllCommon.Priv_ReplaceElement(_childHwnd, element, visionContour);
        }

internal void UpdateBackgroundOptions()
        {
            if (_childHwnd != IntPtr.Zero)
            {
                Rgb32Value fillColor = _backgroundOptions.FillColor;
                Rgb32Value backgroundColor = _backgroundOptions.BackgroundColor;
                VisionDllCommon.Priv_SetWindBackgroundOptions(_childHwnd, (int)_backgroundOptions.FillStyle, (int)_backgroundOptions.HatchStyle, ref fillColor, ref backgroundColor);
                // Invalidate the rectangle to make sure we get redrawn
                System.Drawing.Rectangle clientRect = _pictureBox1.ClientRectangle;
                VisionDllCommon.InvalidateRect(_childHwnd, ref clientRect, false);
            }
            OnBackgroundOptionsChanged(EventArgs.Empty);
        }

internal void UpdateDisplayMapping()
        {
            if (_childHwnd != IntPtr.Zero)
            {
                VB_ConversionPolicy policy = new VB_ConversionPolicy();
                policy.ConvertFromExternal(_displayMapping);
                VisionDllCommon.Priv_SetDisplayMapping(_childHwnd, ref policy);
            }
            OnDisplayMappingChanged(EventArgs.Empty);
        }

internal void HandleImageMouseEvent(int mouseEvent, VB_MouseEventInfo eventInfo)
        {
            switch(mouseEvent) {
                case WM_LBUTTONDOWN:
                    OnImageMouseDown(new ImageMouseEventArgs(MouseButtons.Left, new PointContour(eventInfo.Point)));
                    break;
                case WM_MBUTTONDOWN:
                    OnImageMouseDown(new ImageMouseEventArgs(MouseButtons.Middle, new PointContour(eventInfo.Point)));
                    break;
                case WM_RBUTTONDOWN:
                    OnImageMouseDown(new ImageMouseEventArgs(MouseButtons.Right, new PointContour(eventInfo.Point)));
                    break;
                case WM_LBUTTONUP:
                    OnImageMouseUp(new ImageMouseEventArgs(MouseButtons.Left, new PointContour(eventInfo.Point)));
                    break;
                case WM_MBUTTONUP:
                    OnImageMouseUp(new ImageMouseEventArgs(MouseButtons.Middle, new PointContour(eventInfo.Point)));
                    break;
                case WM_RBUTTONUP:
                    OnImageMouseUp(new ImageMouseEventArgs(MouseButtons.Right, new PointContour(eventInfo.Point)));
                    break;
                case WM_MOUSEMOVE:
                    MouseButtons buttons = MouseButtons.None;
                    if ((eventInfo.Flags & MK_LBUTTON) != 0) buttons |= MouseButtons.Left;
                    if ((eventInfo.Flags & MK_MBUTTON) != 0) buttons |= MouseButtons.Middle;
                    if ((eventInfo.Flags & MK_RBUTTON) != 0) buttons |= MouseButtons.Right;
                    OnImageMouseMove(new ImageMouseEventArgs(buttons, new PointContour(eventInfo.Point)));
                    break;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ImageViewer";
        }
    }

    //==============================================================================================
    /// <summary>
    /// Specifies how the ViewerRoi changed.
    /// </summary>

    public enum ContoursChangedAction {
        //==========================================================================================
        /// <summary>
        /// Adds a contour to the image.
        /// </summary>

        Add,
        //==========================================================================================
        /// <summary>
        /// Removes a contour on the image.
        /// </summary>

        Remove,
        //==========================================================================================
        /// <summary>
        /// Changes a contour on the image.
        /// </summary>

        Change,
        //==========================================================================================
        /// <summary>
        /// Clears a contour on the image.
        /// </summary>

        Clear
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the available tools for creating a region of interest (ROI) in the viewer.
    /// </summary>

    [Flags]
    public enum ViewerTools
    {
        //==========================================================================================
        /// <summary>
        /// </summary>

        None = 0,
        //==========================================================================================
        /// <summary>
        /// Selects an existing ROI in an image.
        /// </summary>

        Selection = 0x1,
        //==========================================================================================
        /// <summary>
        /// Draws a point on the image. 
        /// </summary>

        Point = 0x2,
        //==========================================================================================
        /// <summary>
        /// Draws a line on the image. 
        /// </summary>

        Line = 0x4,
        //==========================================================================================
        /// <summary>
        /// Draws a rectangle on the image. 
        /// </summary>

        Rectangle = 0x8,
        //==========================================================================================
        /// <summary>
        /// Draws an oval on the image. 
        /// </summary>

        Oval = 0x10,
        //==========================================================================================
        /// <summary>
        /// Draws a polygon on the image. 
        /// </summary>

        Polygon = 0x20,
        //==========================================================================================
        /// <summary>
        /// Draws closed freehand shapes on the image. 
        /// </summary>

        ClosedFreehand = 0x40,
        //==========================================================================================
        /// <summary>
        /// Draws annuluses on the image. 
        /// </summary>

        Annulus = 0x80,
        //==========================================================================================
        /// <summary>
        /// Zooms in on the image.
        /// </summary>

        ZoomIn = 0x100,
        //==========================================================================================
        /// <summary>
        /// Zooms out on the image.
        /// </summary>

        ZoomOut = 0x200,
        //==========================================================================================
        /// <summary>
        /// Shifts the view of the image. 
        /// </summary>

        Pan = 0x400,
        //==========================================================================================
        /// <summary>
        /// Draws a series of connected straight lines on the image.
        /// </summary>

        Polyline = 0x800,
        //==========================================================================================
        /// <summary>
        /// Draws freehand lines on the image.
        /// </summary>

        Freehand = 0x1000,
        //==========================================================================================
        /// <summary>
        /// Draws rotated rectangles on the image. 
        /// </summary>

        RotatedRectangle = 0x2000,
        //==========================================================================================
        /// <summary>
        /// </summary>

        All = 0x3FFF
    }

    //==============================================================================================
    /// <summary>
    /// Specifies a predefined palette type.
    /// </summary>

    public enum PaletteType
    {
        //==========================================================================================
        /// <summary>
        /// A gradual gray-level variation from black to white. 
        /// </summary>

        Gray = 0,
        //==========================================================================================
        /// <summary>
        /// Contains 16 cycles of 16 different colors. This periodic palette is appropriate for the display of binary and labeled images.
        /// </summary>

        Binary = 1,
        //==========================================================================================
        /// <summary>
        /// A gradation from red to white with a prominent range of light blue in the upper value range.
        /// </summary>

        Gradient = 2,
        //==========================================================================================
        /// <summary>
        /// A gradation from blue to red with a prominent range of greens in the middle value range.
        /// </summary>

        Rainbow = 3,
        //==========================================================================================
        /// <summary>
        /// A gradation of brown.
        /// </summary>

        Temperature = 4,
        //==========================================================================================
        /// <summary>
        /// A user-defined palette.
        /// </summary>

        UserDefined = 5
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the fill style to use when filling the background of the image viewer.
    /// </summary>

    public enum BackgroundFillStyle
    {
        //==========================================================================================
        /// <summary>
        /// Fill the image viewer with a solid color. 
        /// </summary>

        Solid = 0,
        //==========================================================================================
        /// <summary>
        /// Fill the image viewer with a pattern defined by <see cref="NationalInstruments.Vision.WindowsForms.ViewerBackgroundOptions.HatchStyle" crefType="Unqualified"/>.
        /// </summary>

        Hatch = 2,
        //==========================================================================================
        /// <summary>
        /// Fill the image viewer with the NI Vision default pattern. 
        /// </summary>

        Default = 3
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the hatch styles to use when filling the background of the image viewer.
    /// </summary>

    public enum BackgroundHatchStyle
    {
        //==========================================================================================
        /// <summary>
        /// The background of the display window is horizontal bars.
        /// </summary>

        Horizontal = 0,
        //==========================================================================================
        /// <summary>
        /// The background of the display window is vertical bars.
        /// </summary>

        Vertical = 1,
        //==========================================================================================
        /// <summary>
        /// The background of the display window is diagonal bars, starting in the lower-left corner and ending in the upper-right corner.
        /// </summary>

        ForwardDiagonal = 2,
        //==========================================================================================
        /// <summary>
        /// The background of the display window is diagonal bars, starting in the upper-left corner and ending in the lower-right corner.
        /// </summary>

        BackwardDiagonal = 3,
        //==========================================================================================
        /// <summary>
        /// The background of the display window is intersecting horizontal and vertical bars.
        /// </summary>

        Cross = 4,
        //==========================================================================================
        /// <summary>
        /// The background of the display window is intersecting forward and backward diagonal bars.
        /// </summary>

        CrossHatch = 5
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the policy used to perform the display mapping.
    /// </summary>

    public enum DisplayMappingPolicy
    {
        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the full dynamic range to 8 bits.
        /// </summary>
        /// <remarks>
        /// This value has been deprecated.
        /// Use MapDefault instead to preserve this existing behavior. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapFullDynamicRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// </remarks>

        MapFullDynamicRange = 0,
        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, applies a given number of right shifts to the 16-bit pixels.
        /// </summary>
        /// <remarks>
        /// This value has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.DownshiftAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// </remarks>

        Downshift = 1,
        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the pixel values in a specified range to an 8-bit scale.
        /// </summary>
        /// <remarks>
        /// This value has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// </remarks>

        MapGivenRange = 2,
        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the range corresponding to the center 90 percent of the cumulative histogram to 8 bits.
        /// </summary>
        /// <remarks>
        /// This value has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.Map90PercentDynamicRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// </remarks>

        Map90PercentDynamicRange = 3,
        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the pixel values in the relative percentage range (0 to 100) of the cumulated histogram to an 8-bit scale.
        /// </summary>
        /// <remarks>
        /// This value has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenPercentRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// </remarks>

        MapGivenPercentRange = 4,
        //==========================================================================================
        /// <summary>
        /// When image bit depth is 0, maps the full dynamic to 8 bits; otherwise, right shifts until the 8 most significant bits of the image are displayed.
        /// </summary>

        MapDefault = 10,
        //==========================================================================================
        /// <summary>
        /// Right shifts until the 8 most significant bits of the image are displayed as specified by the image bit depth.
        /// </summary>
        /// <remarks>
        /// When image bit depth is 0, shifts to the right 7 times for signed 16-bit images and 8 times for unsigned 16-bit images. Otherwise, the number of shifts is calculated by subtracting 8 from the image bit depth.
        /// </remarks>

        UseMostSignificantBits = 11,
        //==========================================================================================
        /// <summary>
        /// Maps the full dynamic range to 8 bits.
        /// </summary>

        MapFullDynamicRangeAlways = 12,
        //==========================================================================================
        /// <summary>
        /// Applies a given number of right shifts to the 16-bit pixels.
        /// </summary>

        DownshiftAlways = 13,
        //==========================================================================================
        /// <summary>
        /// Maps the pixel values in a specified range to an 8-bit scale.
        /// </summary>

        MapGivenRangeAlways = 14,
        //==========================================================================================
        /// <summary>
        /// Maps the range corresponding to the center 90 percent of the cumulative histogram to 8 bits.
        /// </summary>

        Map90PercentDynamicRangeAlways = 15,
        //==========================================================================================
        /// <summary>
        /// Maps the pixel values in the relative percentage range (0 to 100) of the cumulated histogram to an 8-bit scale.
        /// </summary>

        MapGivenPercentRangeAlways = 16
    }

    //==============================================================================================
    /// <summary>
    /// An entry in a palette which contains R, G, and B representations.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct PaletteEntry : IEquatable<PaletteEntry>
    {
        private byte _red;
        private byte _green;
        private byte _blue;
        //==========================================================================================
        /// <summary>
        /// Creates a new <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntry" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="red">
        /// The red value of the color.
        /// </param>
        /// <param name="green">
        /// The green value of the color.
        /// </param>
        /// <param name="blue">
        /// The blue value of the color.
        /// </param>

        public PaletteEntry(byte red, byte green, byte blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }
        //==========================================================================================
        /// <summary>
        /// Creates a new <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntry" crefType="Unqualified"/> from an existing Rgb32Value.
        /// </summary>
        /// <param name="rgbValue">
        /// The Rgb32Value from which to copy the R, G, and B members.
        /// </param>

        public PaletteEntry(Rgb32Value rgbValue)
        {
            this._red = rgbValue.Red;
            this._green = rgbValue.Green;
            this._blue = rgbValue.Blue;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the red value of the color. </summary>
        /// <value>
        /// The red value of the color.
        /// </value>

        public byte Red
        {
            get { return _red; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the green value of the color. </summary>
        /// <value>
        /// The green value of the color.
        /// </value>

        public byte Green
        {
            get { return _green; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the blue value of the color. 
        /// </summary>
        /// <value>
        /// The blue value of the color. 
        /// </value>

        public byte Blue 
        {
            get { return _blue; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntry" crefType="Unqualified"/> as an Rgb32Value.</summary>
        /// <value>
        /// The <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntry" crefType="Unqualified"/> as an Rgb32Value.
        /// </value>

        public Rgb32Value Rgb32Value
        {
            get { return new Rgb32Value(_red, _green, _blue); }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntry" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PaletteEntry other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue;
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "PaletteEntry: R=" + _red + ", G=" + _green + ", B=" + _blue;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            PaletteEntry other = (PaletteEntry)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.</param>
        /// <returns>
        /// Whether the two values are equal.
        /// </returns>

        public static bool operator ==(PaletteEntry val1, PaletteEntry val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(PaletteEntry val1, PaletteEntry val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _red.GetHashCode() ^ _green.GetHashCode() ^ _blue.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Creates a collection of palette entries.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class PaletteEntriesCollection : Collection<PaletteEntry>, IDisposable
    {
        private CallbackManager _callbackManager = new CallbackManager();
        private object _callbackLock = new object();
        private object _disposeLock = new object();
        private bool _isDisposed = false;
        //==========================================================================================
        /// <summary>
        /// Occurs when a palette entry changes.</summary>

        public event EventHandler<EventArgs> Changed
        {
            add
            {
                _callbackManager.AddEventHandler("Changed", value);
            }
            remove
            {
                _callbackManager.RemoveEventHandler("Changed", value);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets a value that indicates how events and callback delegates are invoked. 
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if events and callbacks are invoked through the Send or Post methods; otherwise events and callbacks are invoked directly. The default value is <see langword="true"/>. 
        /// </value>

        public bool SynchronizeCallbacks
        {
            get
            {
                return _callbackManager.SynchronizeCallbacks;
            }
            set
            {
                _callbackManager.SynchronizeCallbacks = value;
            }
        }

protected override void InsertItem(int index, PaletteEntry item)
        {
            base.InsertItem(index, item);
            OnChanged(EventArgs.Empty);
        }

protected override void SetItem(int index, PaletteEntry item)
        {
            base.SetItem(index, item);
            OnChanged(EventArgs.Empty);
        }

protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            OnChanged(EventArgs.Empty);
        }

        //==========================================================================================
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>

        protected override void ClearItems()
        {
            base.ClearItems();
            OnChanged(EventArgs.Empty);
        }

private void OnChanged(EventArgs args)
        {
            System.Threading.Monitor.Enter(_callbackLock);
            try
            {
                if (_callbackManager.GetHandlerCount("Changed") == 0)
                {
                    return;
                }
                if (_callbackManager.SynchronizeCallbacks)
                {
                    _callbackManager.RaiseEvent("Changed", this, args);
                }
                else
                {
                    _callbackManager.RaiseEventAsync("Changed", this, args);
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(_callbackLock);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return base.ToString();
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.WindowsForms.PaletteEntriesCollection" crefType="Unqualified"/>.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // Only touch _callbackManager if we're being disposed explicitly
                // and if we're not disposed already.
                if (disposing && !_isDisposed)
                {
                    _callbackManager.Dispose();
                    _isDisposed = true;
                }
            }
        }

        
        ~PaletteEntriesCollection()
        {
            Dispose(false);
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents palette data that you can configure on a per palette basis.</summary>
    /// <remarks>
    /// </remarks>

    [Editor(typeof(PaletteEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(PaletteConverter))]
    public sealed class Palette : IEquatable<Palette>, IDisposable
    {
        internal PaletteType _type;
        internal PaletteEntriesCollection _entries = new PaletteEntriesCollection();
        private bool _isDisposed = false;
        private object _disposeLock = new object();

        
        internal event EventHandler<EventArgs> PaletteChanged;

        
        internal void OnPaletteChanged(EventArgs args) {
            EventHandler<EventArgs> handler = PaletteChanged;
            if (handler != null) {
                handler(this, args);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.Palette" crefType="Unqualified"/> class.
        /// </summary>

        public Palette()
            : this(PaletteType.Gray)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.Palette" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.WindowsForms.Palette.Type" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="type">
        /// The <see cref="NationalInstruments.Vision.WindowsForms.Palette.Type" crefType="Unqualified"/> of palette.
        /// </param>

        public Palette(PaletteType type)
        {
            _entries.Changed += entries_Changed;
            Type = type;
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.Palette" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.WindowsForms.Palette.Entries" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="NationalInstruments.Vision.WindowsForms.Palette.Entries" crefType="Unqualified"/> of the palette.
        /// </param>

        public Palette(Collection<Rgb32Value> entries) : this(PaletteType.UserDefined) {
            for (int i = 0; i < 256 && i < entries.Count; ++i)
            {
                _entries.Add(new PaletteEntry(entries[i]));
            }
        }

private void entries_Changed(object sender, EventArgs e)
        {
            // Since the entries have changed, change the palette type to be user-defined.
            // Setting the Type property will update the underlying viewer.
            this.Type = PaletteType.UserDefined;
        }

        //==========================================================================================
        /// <summary>Gets the palette values.
        /// </summary>
        /// <value>
        /// The entries of the palette, which contain the R, G, and B components of color values.
        /// </value>
        /// <remarks>
        /// After setting this property, <see cref="NationalInstruments.Vision.WindowsForms.Palette.Type" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.PaletteType.UserDefined" crefType="Unqualified"/>.
        /// </remarks>

        public Collection<PaletteEntry> Entries
        {
            get
            {
                return _entries;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets one of the five predefined palettes, or a user-defined color table.
        /// </summary>
        /// <value>
        /// One of the predefined <see cref="NationalInstruments.Vision.WindowsForms.PaletteType" crefType="Unqualified"/> values or a user-defined color table.
        /// </value>
        /// <remarks>
        /// Changing this property does not affect user-defined palette entries. To change them, use <see cref="NationalInstruments.Vision.WindowsForms.Palette.Entries" crefType="Unqualified"/>.
        /// </remarks>

        public PaletteType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                if (_type != PaletteType.UserDefined)
                {
                    // We need to update the entries, but we don't want that to fire a Changed
                    // event, so disable that for now.
                    lock (this)
                    {
                        _entries.Changed -= entries_Changed;
                        PaletteEntry[] tempEntries = new PaletteEntry[256];
                        VisionDllCommon.Priv_GetPalette((int)_type, tempEntries);
                        _entries.Clear();
                        foreach (PaletteEntry entry in tempEntries)
                        {
                            _entries.Add(entry);
                        }
                        _entries.Changed += entries_Changed;
                    }
                }
                OnPaletteChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A <see cref="NationalInstruments.Vision.WindowsForms.Palette" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Palette other)
        {
            return other != null && _type == other._type && Utilities.CollectionsEqual(_entries, other._entries);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Palette other = (Palette)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _type.GetHashCode() ^ _entries.Count.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Palette: Type=" + _type;
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.WindowsForms.Palette" crefType="Unqualified"/>.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // Only touch _entries if we're being disposed explicitly
                // and if we're not disposed already.
                if (disposing && !_isDisposed)
                {
                    _entries.Dispose();
                    _isDisposed = true;
                }
            }
        }

        
        ~Palette()
        {
            Dispose(false);
        }
    }

    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PaletteEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService = null;

        
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Sample taken from http://msdn.microsoft.com/en-us/library/ms171840.aspx
            if (provider != null && context != null && context.Instance != null)
            {
                _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (_editorService != null)
                {
                    ListBox box = new ListBox();
                    foreach (PaletteType type in Enum.GetValues(typeof(PaletteType)))
                    {
                        box.Items.Add(type);
                    }
                    Palette palette = value as Palette;
                    if (palette != null)
                    {
                        box.SelectedIndex = (Int32)(palette.Type);
                    }
                    else
                    {
                        box.SelectedIndex = 0;
                    }
                    box.SelectedIndexChanged += new EventHandler(box_SelectedIndexChanged);
                    _editorService.DropDownControl(box);
                    value = new Palette((PaletteType)box.Items[box.SelectedIndex]);
                }
            }
            return value;
        }

private void box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
        }

        
        public override string ToString()
        {
            return "PaletteEditor";
        }

        
        public bool Equals(PaletteEditor other)
        {
            return other != null;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            PaletteEditor other = (PaletteEditor)obj;
            return Equals(other);
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PaletteConverter : System.ComponentModel.TypeConverter
    {

        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null)
            {
                Palette palette = value as Palette;
                if (palette != null)
                {
                    return palette.Type.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        
        public override string ToString()
        {
            return "PaletteConverter";
        }

        
        public bool Equals(PaletteConverter other)
        {
            return other != null;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            PaletteConverter other = (PaletteConverter)obj;
            return Equals(other);
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides data for the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageMouseDown" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageMouseMove" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageMouseUp" crefType="Unqualified"/> events.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ImageMouseEventArgs : EventArgs
    {
        private MouseButtons _button;
        private PointContour _point;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs" crefType="Unqualified"/> class. 
        /// </summary>
        /// <param name="button">
        /// The state of the mouse buttons.
        /// </param>
        /// <param name="point">
        /// The coordinates on the image.
        /// </param>

        public ImageMouseEventArgs(MouseButtons button, PointContour point) {
            _button = button;
            _point = point;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the coordinates on the image.
        /// </summary>
        /// <value>
        /// The coordinates on the image.
        /// </value>

        public PointContour Point { get { return _point; } }
        //==========================================================================================
        /// <summary>
        /// Gets the state of the mouse buttons.
        /// </summary>
        /// <value>
        /// The following are valid values: 1 for the left button, 2 for the right button, or 4 for the middle button. For example, if both the left and right mouse buttons are pressed, value is 3 (1 + 2).
        /// </value>

        public MouseButtons Button { get { return _button; } }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An <see cref="NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ImageMouseEventArgs other)
        {
            return other != null && Object.Equals(_point, other._point) && _button == other._button;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ImageMouseEventArgs other = (ImageMouseEventArgs)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _point.GetHashCode() ^ _button.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ImageMouseEventArgs: Point=" + _point.ToString() + ", Button=" + _button.ToString();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides data for the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImageZoomed" crefType="Unqualified"/> event.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ImageZoomedEventArgs : EventArgs
    {
        private double _xZoom;
        private double _yZoom;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs" crefType="Unqualified"/> class. 
        /// </summary>
        /// <param name="xZoom">
        /// The x data value of the image to zoom.
        /// </param>
        /// <param name="yZoom">
        /// The y data value of the image to zoom.
        /// </param>

        public ImageZoomedEventArgs(double xZoom, double yZoom)
        {
            _xZoom = xZoom;
            _yZoom = yZoom;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the x data value of the image to zoom.
        /// </summary>
        /// <value>
        /// The x data value of the image to zoom.
        /// </value>

        public double XZoom { get { return _xZoom; } }
        //==========================================================================================
        /// <summary>
        /// Gets the y data value of the image to zoom.
        /// </summary>
        /// <value>
        /// The y data value of the image to zoom.
        /// </value>

        public double YZoom { get { return _yZoom; } }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An <see cref="NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs" crefType="Unqualified"/> to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ImageZoomedEventArgs other)
        {
            return other != null && _xZoom == other._xZoom && _yZoom == other._yZoom;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ImageZoomedEventArgs other = (ImageZoomedEventArgs)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _xZoom.GetHashCode() ^ _yZoom.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ImageZoomEventArgs: XZoom=" + _xZoom + ", YZoom=" + _yZoom;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides data for the <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer.ImagePanned" crefType="Unqualified"/> event.</summary>
    /// <remarks>
    /// </remarks>

    public sealed class ImagePannedEventArgs : EventArgs
    {
        private Int32 _dx;
        private Int32 _dy;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs" crefType="Unqualified"/> class. 
        /// </summary>
        /// <param name="dx">
        /// The distance in pixels to move on the x-axis.
        /// </param>
        /// <param name="dy">
        /// The distance in pixels to move on the y-axis.
        /// </param>

        public ImagePannedEventArgs(Int32 dx, Int32 dy)
        {
            _dx = dx;
            _dy = dy;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the distance in pixels to move on the x-axis.</summary>
        /// <value>
        /// The distance in pixels to move on the x-axis.
        /// </value>

        public Int32 Dx { get { return _dx; } }
        //==========================================================================================
        /// <summary>
        /// Gets the distance in pixels to move on the y-axis.</summary>
        /// <value>
        /// The distance in pixels to move on the y-axis.
        /// </value>

        public Int32 Dy { get { return _dy; } }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An <see cref="NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ImagePannedEventArgs other)
        {
            return other != null && _dx == other._dx && _dy == other._dy;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ImagePannedEventArgs other = (ImagePannedEventArgs)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _dx.GetHashCode() ^ _dy.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ImagePannedEventArgs: Dx=" + _dx + ", Dy=" + _dy;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides data for the RoiChanged event. 
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ContoursChangedEventArgs : EventArgs {
        private ContoursChangedAction _action;
        private Collection<Contour> _newItems;
        private Int32 _newStartingIndex;
        private Collection<Contour> _oldItems;
        private Int32 _oldStartingIndex;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="action">
        /// The <see cref="NationalInstruments.Vision.WindowsForms.ContoursChangedAction" crefType="Unqualified"/> that changed the contour.
        /// </param>
        /// <param name="newItems">
        /// The new contours that were added to the ViewerRoi.
        /// </param>
        /// <param name="newStartingIndex">
        /// The index in the ViewerRoi where the new contours are added.
        /// </param>
        /// <param name="oldItems">
        /// The old contours that were removed from the ViewerRoi.
        /// </param>
        /// <param name="oldStartingIndex">
        /// The index where the contours were removed from the ViewerRoi.
        /// </param>

        public ContoursChangedEventArgs(ContoursChangedAction action, Collection<Contour> newItems, Int32 newStartingIndex, Collection<Contour> oldItems, Int32 oldStartingIndex)
        {
            _action = action;
            _newItems = newItems;
            _newStartingIndex = newStartingIndex;
            _oldItems = oldItems;
            _oldStartingIndex = oldStartingIndex;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the <see cref="NationalInstruments.Vision.WindowsForms.ContoursChangedAction" crefType="Unqualified"/> that changed the that changed the ViewerRoi.
        /// </summary>
        /// <value>
        /// The <see cref="NationalInstruments.Vision.WindowsForms.ContoursChangedAction" crefType="Unqualified"/> that changed the ViewerRoi.
        /// </value>

        public ContoursChangedAction Action { get { return _action; } }
        //==========================================================================================
        /// <summary>
        /// Gets the new contours that were added to the ViewerRoi.
        /// </summary>
        /// <value>
        /// The new contours that were added to the ViewerRoi.
        /// </value>

        public Collection<Contour> NewItems { get { return _newItems; } }
        //==========================================================================================
        /// <summary>
        /// Gets the index in the ViewerRoi where the new contours are added.
        /// </summary>
        /// <value>
        /// The index in the ViewerRoi where the new contours are added.
        /// </value>

        public Int32 NewStartingIndex { get { return _newStartingIndex; } }
        //==========================================================================================
        /// <summary>
        /// Gets the old contours that were removed from the ViewerRoi.
        /// </summary>
        /// <value>
        /// The old contours that were removed from the ViewerRoi.
        /// </value>

        public Collection<Contour> OldItems { get { return _oldItems; } }
        //==========================================================================================
        /// <summary>
        /// Gets the index where the contours were removed from the ViewerRoi.
        /// </summary>
        /// <value>
        /// The index where the contours were removed from the ViewerRoi.
        /// </value>

        public Int32 OldStartingIndex { get { return _oldStartingIndex; } }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A <see cref="NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ContoursChangedEventArgs other)
        {
            return other != null && _action == other._action && Utilities.CollectionsEqual(_newItems, other._newItems) && _newStartingIndex == other._newStartingIndex && Utilities.CollectionsEqual(_oldItems, other._oldItems) && _oldStartingIndex == other._oldStartingIndex;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ContoursChangedEventArgs other = (ContoursChangedEventArgs)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>

        public override int GetHashCode()
        {
            return _action.GetHashCode() ^ _newItems.GetHashCode() ^ _newStartingIndex.GetHashCode() ^ _oldItems.GetHashCode() ^ _oldStartingIndex.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ContoursChangedEventArgs: Action=" + _action;
        }
    }

    //==============================================================================================
    /// <summary>
    /// A region of interest (ROI) that is visible on an <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ViewerRoi : Roi
    {
        private ImageViewer _viewer = null;
        internal Int32 _updating = 0;
        private Collection<ContoursChangedEventArgs> _eventsToRaise = new Collection<ContoursChangedEventArgs>();
        private CallbackManager _callbackManager = new CallbackManager();
        private object _callbackLock = new object();
        private object _disposeLock = new object();

        //==========================================================================================
        /// <summary>
        /// Gets or sets how events and callback delegates are invoked. 
        /// </summary>
        /// <value><see langword="true"/> if events and callbacks are invoked through the <see cref="System.Threading.SynchronizationContext.Send"/> or <see cref="System.Threading.SynchronizationContext.Post"/> methods; otherwise, events and callbacks are invoked directly. The default value is <see langword="true"/>. 
        /// </value>

        public bool SynchronizeCallbacks
        {
            get
            {
                return _callbackManager.SynchronizeCallbacks;
            }
            set
            {
                _callbackManager.SynchronizeCallbacks = value;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the maximum number of contours the viewer can have in its ROI.
        /// </summary>
        /// <value>
        /// The maximum number of contours the viewer can have in its ROI. The default value is -1.
        /// </value>
        /// <remarks>
        /// If this property is negative, it indicates there is no limit on the maximum number of contours.</remarks>

        public Int32 MaximumContours
        {
            get { return _viewer.MaximumContours; }
            set { _viewer.MaximumContours = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Occurs when the contours of this <see cref="NationalInstruments.Vision.WindowsForms.ViewerRoi" crefType="Unqualified"/> are changed.
        /// </summary>

        public event EventHandler<ContoursChangedEventArgs> ContoursChanged
        {
            add
            {
                _callbackManager.AddEventHandler("ContoursChanged", value);
            }
            remove
            {
                _callbackManager.RemoveEventHandler("ContoursChanged", value);
            }
        }

internal ViewerRoi(ImageViewer viewer)
        {
            _viewer = viewer;
        }

        
        private void OnContoursChanged(ContoursChangedEventArgs args) {
            System.Threading.Monitor.Enter(_callbackLock);
            try
            {
                if (_callbackManager.GetHandlerCount("ContoursChanged") == 0)
                {
                    return;
                }
                if (_callbackManager.SynchronizeCallbacks)
                {
                    _callbackManager.RaiseEvent("ContoursChanged", this, args);
                }
                else
                {
                    _callbackManager.RaiseEventAsync("ContoursChanged", this, args);
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(_callbackLock);
            }
        }

        
        protected override void InsertItem(int index, Shape item)
        {
            // Make sure we're not violating the max contour count.
            int maxContours = MaximumContours;
            if (maxContours != -1 && Count >= maxContours)
            {
                // We are violating the max contour count, so do nothing instead.
                return;
            }
            base.InsertItem(index, item);
            // Create a corresponding viewer element if one doesn't exist already
            Contour newContour = this[index];
            IntPtr visionContour = newContour.GetVisionContour();
            IntPtr newElement = IntPtr.Zero;
            try
            {
                newElement = _viewer.CreateElement(visionContour, true);
                newContour._visionRoiElement = newElement;
                Utilities.ThrowError(newElement);
            }
            finally
            {
                // If something goes wrong, be sure we dispose the contour we created.
                VisionDllCommon.Priv_DeleteContour(visionContour);
            }
            // Now that we have the viewer element we can safely set the color on the contour.
            this.SetContourColor(newContour, newContour.Color);
            newContour.ShapeChanged += HandleContourChanged;
        }

        
        protected override void RemoveItem(int index)
        {
            Contour toRemove = this[index];
            _viewer.DeleteElement(toRemove._visionRoiElement);
            base.RemoveItem(index);
        }
        //==========================================================================================
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>

        protected override void ClearItems()
        {
            int numItems = Count;
            for (int i = 0; i < numItems; ++i)
            {
                Contour toRemove = this[0];
                _viewer.DeleteElement(toRemove._visionRoiElement);
                base.RemoveItem(0);
            }
        }

        
        internal void HandleChangedMessage(ViewerMessage type, IntPtr roiElement, IntPtr lParam)
        {
            if (roiElement != IntPtr.Zero)
            {
                // An existing element was changed.  Find which one.
                Int32 contourIndex = 0;
                foreach (Contour c in this)
                {
                    if (c._visionRoiElement == roiElement)
                    {
                        // Found it!
                        bool modified = false;
                        // If the message is ChangedElement, we need to completely replace the Contour.
                        if (type == ViewerMessage.ChangedElement)
                        {
                            Shape newShape = GetElementShapeFromVision(roiElement);
                            // Reassign the new shape to the existing contour.
                            c.Shape = newShape;
                            modified = true;
                        }
                        else
                        {
                            modified = c.HandleMessage(type, lParam);
                        }
                        if (modified)
                        {
                            // We need to change the element in the underlying _roi here.  So we have to
                            // remove it from the _roi and then add it again.  This will not affect its
                            // position in the collection of Contours on the .NET side.
                            this.RemoveContourFromVisionRoi(c);
                            this.AddContourToVisionRoi(c);
                            Collection<Contour> newItems = new Collection<Contour>();
                            newItems.Add(c);
                            _eventsToRaise.Add(new ContoursChangedEventArgs(ContoursChangedAction.Change, newItems, contourIndex, new Collection<Contour>(), -1));
                        }
                    }
                    contourIndex++;
                }
            }
        }

        
        internal void HandleUpdatingMessage(IntPtr roiElement, bool newUpdating) {
            // We never expect to get more than one updating message at a time,
            // but we handle that case correctly here.
            if (newUpdating)
            {
                _updating++;
                Debug.Assert(_updating == 1, "unmatched updating message!");
            }
            else
            {
                _updating--;
                Debug.Assert(_updating == 0, "unmatched !updating message!");
            }
            foreach (Contour c in this)
            {
                if (c._visionRoiElement == roiElement)
                {
                    c.HandleUpdatingMessage(newUpdating);
                }
            }
            if (_updating == 0)
            {
                // If we're done updating, then fire off events reflecting what happened.
                if (_eventsToRaise.Count > 0)
                {
                    foreach (ContoursChangedEventArgs eventArgs in _eventsToRaise)
                    {
                        OnContoursChanged(eventArgs);
                    }
                    _eventsToRaise.Clear();
                }
            }
        }

        
        internal static Shape GetElementShapeFromVision(IntPtr element)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateContourFromElement(element);
            Utilities.ThrowError(contour);
            ContourType type = Contour.ConvertToContourType(VisionDllCommon.Priv_GetContourType(contour));
            Shape toReturn = null;
            switch (type)
            {
                case ContourType.Point:
                    PointContour pointToAdd = new PointContour();
                    pointToAdd.SetFromVisionContour(contour);
                    toReturn = pointToAdd;
                    break;
                case ContourType.Rectangle:
                    RectangleContour rectToAdd = new RectangleContour();
                    rectToAdd.SetFromVisionContour(contour);
                    toReturn = rectToAdd;
                    break;
                case ContourType.Line:
                    LineContour lineToAdd = new LineContour();
                    lineToAdd.SetFromVisionContour(contour);
                    toReturn = lineToAdd;
                    break;
                case ContourType.RotatedRectangle:
                    RotatedRectangleContour rotatedRectToAdd = new RotatedRectangleContour();
                    rotatedRectToAdd.SetFromVisionContour(contour);
                    toReturn = rotatedRectToAdd;
                    break;
                case ContourType.Oval:
                    OvalContour ovalToAdd = new OvalContour();
                    ovalToAdd.SetFromVisionContour(contour);
                    toReturn = ovalToAdd;
                    break;
                case ContourType.Annulus:
                    AnnulusContour annulusToAdd = new AnnulusContour();
                    annulusToAdd.SetFromVisionContour(contour);
                    toReturn = annulusToAdd;
                    break;
                case ContourType.Polygon:
                    PolygonContour polygonToAdd = new PolygonContour();
                    polygonToAdd.SetFromVisionContour(contour);
                    toReturn = polygonToAdd;
                    break;
                case ContourType.FreehandRegion:
                    FreehandRegionContour freeRegionToAdd = new FreehandRegionContour();
                    freeRegionToAdd.SetFromVisionContour(contour);
                    toReturn = freeRegionToAdd;
                    break;
                case ContourType.FreehandLine:
                    FreehandLineContour freeLineToAdd = new FreehandLineContour();
                    freeLineToAdd.SetFromVisionContour(contour);
                    toReturn = freeLineToAdd;
                    break;
                case ContourType.Polyline:
                    PolylineContour brokenLineToAdd = new PolylineContour();
                    brokenLineToAdd.SetFromVisionContour(contour);
                    toReturn = brokenLineToAdd;
                    break;
                default:
                    Debug.Fail("Unknown contour type!");
                    break;
            }
            VisionDllCommon.Priv_DeleteContour(contour);
            return toReturn;
        }

internal void AddElementFromVision(IntPtr element)
        {
            Shape newShape = GetElementShapeFromVision(element);
            Contour newContour = new Contour(newShape, element);
            newContour.ShapeChanged += HandleContourChanged;
            AddContour(newContour);
            Collection<Contour> newItems = new Collection<Contour>();
            newItems.Add(newContour);
            _eventsToRaise.Add(new ContoursChangedEventArgs(ContoursChangedAction.Add, newItems, Count - 1, new Collection<Contour>(), -1));
        }

        
        internal void RemoveElementFromVision(IntPtr element)
        {
            if (element != IntPtr.Zero)
            {
                // Remove the contour that corresponds with this element.
                Int32 indexToRemove = -1;
                for (int i = 0; i < Count; ++i)
                {
                    if (this[i]._visionRoiElement == element)
                    {
                        indexToRemove = i;
                        break;
                    }
                }
                if (indexToRemove != -1)
                {
                    Contour toRemove = this[indexToRemove];
                    RemoveAt(indexToRemove);
                    Collection<Contour> oldItems = new Collection<Contour>();
                    oldItems.Add(toRemove);
                    _eventsToRaise.Add(new ContoursChangedEventArgs(ContoursChangedAction.Remove, new Collection<Contour>(), -1, oldItems, indexToRemove));
                }
                else
                {
                    Debug.Fail("Didn't find element to remove!");
                }
            }
            else
            {
                // Passing in element = 0 means to remove all of them.
                Collection<Contour> oldItems = new Collection<Contour>();
                foreach (Contour c in this) {
                    oldItems.Add(c);
                }
                Clear();
                _eventsToRaise.Add(new ContoursChangedEventArgs(ContoursChangedAction.Clear, new Collection<Contour>(), -1, oldItems, 0));
            }
        }

internal override void SetContourColor(Contour item, Rgb32Value color)
        {
            base.SetContourColor(item, color);
            if (item._visionRoiElement != IntPtr.Zero)
            {
                VisionDllCommon.Priv_SetElementColor(item._visionRoiElement, color);
            }
        }

protected internal override void OnSetColor(Rgb32Value color)
        {
            base.OnSetColor(color);
            VisionDllCommon.Priv_SetROIDefaultColor(this._roi, color);
        }

private void HandleContourChanged(object sender, EventArgs args)
        {
            Contour contour = (Contour)sender;
            IntPtr visionContour = contour.Shape.GetVisionContour(contour.Color, contour.IsExternal);
            Utilities.ThrowError(contour._visionRoiElement = _viewer.ReplaceElement(contour._visionRoiElement, visionContour));
            VisionDllCommon.Priv_DeleteContour(visionContour);
        }

        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("ViewerRoi: {");
            // Only display the first contour
            if (this.Count > 0)
            {
                sb.Append(this[0].ToString());
                if (this.Count > 1)
                {
                    sb.Append(", ...");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.WindowsForms.ViewerRoi" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="disposing">
        /// </param>

        protected override void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                try
                {
                    // Only touch _callbackManager if we're being disposed explicitly.
                    // And not if we're already disposed.
                    if (disposing && _roi != IntPtr.Zero)
                    {
                        _callbackManager.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the pixel mapping policy for displaying 16-bit images.
    /// </summary>
    /// <remarks>
    /// Because 16-bit grayscale images (65,536 grayscale values) 
    ///  cannot be displayed with their full resolution on 32-bit color displays using common video adapters limited to 8-bit resolution per color plane, 16-bit images must be mapped to the 8-bit range (0 to 255). 
    /// </remarks>

    public sealed class DisplayMapping
    {
        private ImageViewer _viewer = null;
        private DisplayMappingPolicy _policy = DisplayMappingPolicy.MapDefault;
        private ReadOnlyRange _range;
        private Int32 _shifts = 0;

        
        internal DisplayMapping(ImageViewer owner)
        {
            _viewer = owner;
            _range = new ReadOnlyRange();
        }

        //==========================================================================================
        /// <summary>
        /// Gets the number of bits to right-shift the pixel values for the <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Downshift" crefType="Unqualified"/> method.
        /// </summary>
        /// <value>
        /// The number of bits to right-shift the pixel values for the <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Downshift" crefType="Unqualified"/> method.
        /// </value>

        public Int32 Shifts
        {
            get { return _shifts; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the policy used to perform the display mapping.
        /// </summary>
        /// <value>
        /// The <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy" crefType="Unqualified"/> used to perform the display mapping.
        /// </value>

        public DisplayMappingPolicy Policy
        {
            get { return _policy; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the range used when the display mapping policy is <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenRange" crefType="Unqualified"/> or <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenPercentRange" crefType="Unqualified"/>.
        /// </summary>
        /// <value>
        /// The range used when the display mapping policy is <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenRange" crefType="Unqualified"/> or <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenPercentRange" crefType="Unqualified"/>.
        /// </value>

        public ReadOnlyRange Range
        {
            get { return _range; }
        }

private bool CheckChanges()
        {
            return VisionDllCommon.Priv_CheckDisplayMapping((Int32)_policy, (Int32)Math.Round(_range.Minimum), (Int32)Math.Round(_range.Maximum), _shifts) != 0;
        }

        //==========================================================================================
        /// <summary>
        /// When image bit depth is 0, maps the full dynamic to 8 bits; otherwise, right shifts until the 8 most significant bits of the image are displayed.
        /// </summary>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapDefault" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapDefault()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapDefault;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// Right shifts until the 8 most significant bits of the image are displayed as specified by the image bit depth.
        /// </summary>
        /// <remarks>
        /// When image bit depth is 0, shifts to the right 7 times for signed 16-bit images and 8 times for unsigned 16-bit images. Otherwise, the number of shifts is calculated by subtracting 8 from the image bit depth.
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.UseMostSignificantBits" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void UseMostSignificantBits()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.UseMostSignificantBits;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }
        
        //==========================================================================================
        /// <summary>
        /// Maps the full dynamic range to 8 bits.
        /// </summary>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapFullDynamicRangeAlways" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapFullDynamicRangeAlways()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapFullDynamicRangeAlways;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// Maps the range corresponding to the center 90 percent of the cumulative histogram to 8 bits.
        /// </summary>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// <list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.Map90PercentDynamicRangeAlways" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void Map90PercentDynamicRangeAlways()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.Map90PercentDynamicRangeAlways;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// Maps the pixel values in a specified range to an 8-bit scale.
        /// </summary>
        /// <param name="minimum">
        /// Specifies the minimum value of the range to map.
        /// </param>
        /// <param name="maximum">
        /// Specifies the maximum value of the range to map.
        /// </param>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenRangeAlways" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is the specified range. 
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> is undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapGivenRangeAlways(Int32 minimum, Int32 maximum)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapGivenRangeAlways;
            Int32 oldMinimum = (Int32)Math.Round(_range.Minimum);
            _range.Minimum = minimum;
            Int32 oldMaximum = (Int32)Math.Round(_range.Maximum);
            _range.Maximum = maximum;
            if (oldPolicy == _policy && oldMinimum == _range.Minimum && oldMaximum == _range.Maximum)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _range.Minimum = oldMinimum;
                _range.Maximum = oldMaximum;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// Maps the pixel values in the relative percentage range (0 to 100) of the cumulated histogram to an 8-bit scale.
        /// </summary>
        /// <param name="minimum">
        /// Specifies the minimum value of the relative percentage range of the cumulated histogram.
        /// </param>
        /// <param name="maximum">
        /// Specifies the maximum value of the relative percentage range of the cumulated histogram.
        /// </param>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenPercentRangeAlways" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is the relative percentage range (0 to 100) of the cumulated histogram. 
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> is undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapGivenPercentRangeAlways(Int32 minimum, Int32 maximum)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapGivenPercentRangeAlways;
            Int32 oldMinimum = (Int32)Math.Round(_range.Minimum);
            _range.Minimum = minimum;
            Int32 oldMaximum = (Int32)Math.Round(_range.Maximum);
            _range.Maximum = maximum;
            if (oldPolicy == _policy && oldMinimum == _range.Minimum && oldMaximum == _range.Maximum)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _range.Minimum = oldMinimum;
                _range.Maximum = oldMaximum;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// Applies a given number of right shifts to the 16-bit pixels.
        /// </summary>
        /// <param name="shifts">
        /// Number of right shifts to apply.
        /// </param>
        /// <remarks>
        /// After the execution of this method, the following hold true:
        /// <list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.DownshiftAlways" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is set to undefined.
        /// </description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void DownshiftAlways(Int32 shifts)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.DownshiftAlways;
            Int32 oldShifts = _shifts;
            _shifts = shifts;
            if (oldPolicy == _policy && oldShifts == _shifts)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _shifts = oldShifts;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the full dynamic range to 8 bits.
        /// </summary>
        /// <remarks>
        /// This method has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed.
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapDefault" crefType="Unqualified"/> instead to preserve this existing behavior. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapFullDynamicRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapFullDynamicRange" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapFullDynamicRange()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapFullDynamicRange;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the range corresponding to the center 90 percent of the cumulative histogram to 8 bits.
        /// </summary>
        /// <remarks>
        /// This method has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed.
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Map90PercentDynamicRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// After the execution of this method, the following hold true:
        /// <list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.Map90PercentDynamicRange" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> are undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void Map90PercentDynamicRange()
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.Map90PercentDynamicRange;
            if (oldPolicy == _policy)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the pixel values in a specified range to an 8-bit scale.
        /// </summary>
        /// <param name="minimum">
        /// Specifies the minimum value of the range to map.
        /// </param>
        /// <param name="maximum">
        /// Specifies the maximum value of the range to map.
        /// </param>
        /// <remarks>
        /// This method has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed.
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenRange" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is the specified range. 
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> is undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapGivenRange(Int32 minimum, Int32 maximum)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapGivenRange;
            Int32 oldMinimum = (Int32)Math.Round(_range.Minimum);
            _range.Minimum = minimum;
            Int32 oldMaximum = (Int32)Math.Round(_range.Maximum);
            _range.Maximum = maximum;
            if (oldPolicy == _policy && oldMinimum == _range.Minimum && oldMaximum == _range.Maximum)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _range.Minimum = oldMinimum;
                _range.Maximum = oldMaximum;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, maps the pixel values in the relative percentage range (0 to 100) of the cumulated histogram to an 8-bit scale.
        /// </summary>
        /// <param name="minimum">
        /// Specifies the minimum value of the relative percentage range of the cumulated histogram.
        /// </param>
        /// <param name="maximum">
        /// Specifies the maximum value of the relative percentage range of the cumulated histogram.
        /// </param>
        /// <remarks>
        /// This method has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed.
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.MapGivenPercentRangeAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// After the execution of this method, the following hold true:
        /// 	<list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.MapGivenPercentRange" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is the relative percentage range (0 to 100) of the cumulated histogram. 
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Shifts" crefType="Unqualified"/> is undefined.
        /// 			</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void MapGivenPercentRange(Int32 minimum, Int32 maximum)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.MapGivenPercentRange;
            Int32 oldMinimum = (Int32)Math.Round(_range.Minimum);
            _range.Minimum = minimum;
            Int32 oldMaximum = (Int32)Math.Round(_range.Maximum);
            _range.Maximum = maximum;
            if (oldPolicy == _policy && oldMinimum == _range.Minimum && oldMaximum == _range.Maximum)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _range.Minimum = oldMinimum;
                _range.Maximum = oldMaximum;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

        //==========================================================================================
        /// <summary>
        /// (Obsolete) When image bit depth is 0, applies a given number of right shifts to the 16-bit pixels.
        /// </summary>
        /// <param name="shifts">
        /// Number of right shifts to apply.
        /// </param>
        /// <remarks>
        /// This method has been deprecated. 
        /// This method only maps the image values when the image bit depth is 0. Otherwise, the 8 most significant bits of the image are displayed.
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.DownshiftAlways" crefType="Unqualified"/> instead to have the mapping applied regardless of the image bit depth. 
        /// Use <see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.UseMostSignificantBits" crefType="Unqualified"/> instead to display the 8 most significant bits regardless of the image bit depth.
        /// After the execution of this method, the following hold true:
        /// <list type="bullet">
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Policy" crefType="Unqualified"/> is set to <see cref="NationalInstruments.Vision.WindowsForms.DisplayMappingPolicy.Downshift" crefType="Unqualified"/>.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// 				<see cref="NationalInstruments.Vision.WindowsForms.DisplayMapping.Range" crefType="Unqualified"/> is set to undefined.
        /// </description>
        /// 		</item>
        /// 	</list>
        /// </remarks>

        public void Downshift(Int32 shifts)
        {
            DisplayMappingPolicy oldPolicy = _policy;
            _policy = DisplayMappingPolicy.Downshift;
            Int32 oldShifts = _shifts;
            _shifts = shifts;
            if (oldPolicy == _policy && oldShifts == _shifts)
            {
                // Nothing has changed.
                return;
            }
            bool success = CheckChanges();
            if (!success)
            {
                _policy = oldPolicy;
                _shifts = oldShifts;
                Utilities.ThrowError();
            }
            CommitChanges();
        }

private void CommitChanges()
        {
            _viewer.UpdateDisplayMapping();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "DisplayMappingPolicy: Policy=" + _policy;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the options you can use to change the viewer background.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ViewerBackgroundOptions
    {
        private ImageViewer _viewer = null;

        
        internal ViewerBackgroundOptions(ImageViewer owner)
        {
            _viewer = owner;
            _fillStyle = BackgroundFillStyle.Default;
            _hatchStyle = BackgroundHatchStyle.Horizontal;
            _fillColor = Rgb32Value.BlackColor;
            _backgroundColor = Rgb32Value.WhiteColor;
        }
        private BackgroundFillStyle _fillStyle;
        private BackgroundHatchStyle _hatchStyle;
        private Rgb32Value _fillColor;
        private Rgb32Value _backgroundColor;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the background color of the image viewer. 
        /// </summary>
        /// <value>
        /// The RGB background color of the image viewer.
        /// </value>

        public Rgb32Value BackgroundColor
        {
            get { return _backgroundColor; }
            set {
                Rgb32Value oldBackgroundColor = _backgroundColor;
                _backgroundColor = value;
                if (oldBackgroundColor != _backgroundColor)
                {
                    CommitChanges();
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the fill color of the image viewer.
        /// </summary>
        /// <value>
        /// The RGB fill color of the image viewer.
        /// </value>

        public Rgb32Value FillColor
        {
            get { return _fillColor; }
            set {
                Rgb32Value oldFillColor = _fillColor;
                _fillColor = value;
                if (oldFillColor != _fillColor)
                {
                    CommitChanges();
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the hatch style of the image viewer.</summary>
        /// <value>
        /// The <see cref="NationalInstruments.Vision.WindowsForms.BackgroundHatchStyle" crefType="Unqualified"/> of the image viewer.
        /// </value>

        public BackgroundHatchStyle HatchStyle
        {
            get { return _hatchStyle; }
            set {
                BackgroundHatchStyle oldHatchStyle = _hatchStyle;
                _hatchStyle = value;
                if (oldHatchStyle != _hatchStyle)
                {
                    CommitChanges();
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the fill style of the image viewer. 
        /// </summary>
        /// <value>
        /// The <see cref="NationalInstruments.Vision.WindowsForms.BackgroundFillStyle" crefType="Unqualified"/> of the image viewer. 
        /// </value>

        public BackgroundFillStyle FillStyle
        {
            get { return _fillStyle; }
            set {
                BackgroundFillStyle oldFillStyle = _fillStyle;
                _fillStyle = value;
                if (oldFillStyle != _fillStyle)
                {
                    CommitChanges();
                }
            }
        }

private void CommitChanges()
        {
            _viewer.UpdateBackgroundOptions();
        }
        //==========================================================================================
        /// <summary>
        /// Sets the background to the default.
        /// </summary>

        public void DefaultBackground()
        {
            BackgroundFillStyle oldFillStyle = _fillStyle;
            _fillStyle = BackgroundFillStyle.Default;
            if (oldFillStyle != _fillStyle)
            {
                CommitChanges();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Sets the background to a solid color with the specified <see cref="NationalInstruments.Vision.WindowsForms.ViewerBackgroundOptions.FillColor" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="fillColor">
        /// The RGB fill color of the image viewer.
        /// </param>

        public void SolidBackground(Rgb32Value fillColor)
        {
            BackgroundFillStyle oldFillStyle = _fillStyle;
            _fillStyle = BackgroundFillStyle.Solid;
            Rgb32Value oldFillColor = _fillColor;
            _fillColor = fillColor;
            if (oldFillStyle != _fillStyle || oldFillColor != _fillColor)
            {
                CommitChanges();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Sets the background to a hatched pattern with the specified <see cref="NationalInstruments.Vision.WindowsForms.ViewerBackgroundOptions.FillColor" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.WindowsForms.ViewerBackgroundOptions.BackgroundColor" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.WindowsForms.ViewerBackgroundOptions.HatchStyle" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="fillColor">
        /// The RGB fill color of the image viewer.
        /// </param>
        /// <param name="backgroundColor">
        /// The RGB background color of the image viewer.
        /// </param>
        /// <param name="hatchStyle">
        /// The <see cref="NationalInstruments.Vision.WindowsForms.BackgroundHatchStyle" crefType="Unqualified"/> of the image viewer.
        /// </param>

        public void HatchBackground(Rgb32Value fillColor, Rgb32Value backgroundColor, BackgroundHatchStyle hatchStyle)
        {
            BackgroundFillStyle oldFillStyle = _fillStyle;
            _fillStyle = BackgroundFillStyle.Hatch;
            Rgb32Value oldBackgroundColor = _backgroundColor;
            _backgroundColor = backgroundColor;
            Rgb32Value oldFillColor = _fillColor;
            _fillColor = fillColor;
            BackgroundHatchStyle oldHatchStyle = _hatchStyle;
            _hatchStyle = hatchStyle;
            if (oldFillStyle != _fillStyle || oldBackgroundColor != _backgroundColor || oldFillColor != _fillColor || oldHatchStyle != _hatchStyle)
            {
                CommitChanges();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ViewerBackgroundOptions: FillStyle=" + _fillStyle;
        }

    }

    //==============================================================================================
    /// <summary>
    /// Represents the x and y zoom information on an <see cref="NationalInstruments.Vision.WindowsForms.ImageViewer" crefType="Unqualified"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ZoomInfo
    {
        private ImageViewer _viewer = null;
        internal double _x = 1.0;
        internal double _y = 1.0;

        
        internal ZoomInfo(ImageViewer owner)
        {
            _viewer = owner;
        }
        //==========================================================================================
        /// <summary>
        /// Sets the x and y zoom factors.</summary>
        /// <param name="x">
        /// The amount to zoom in the x direction.
        /// </param>
        /// <param name="y">
        /// The amount to zoom in the y direction.
        /// </param>

        public void Initialize(double x, double y)
        {
            if (_x != x || _y != y)
            {
                _x = x;
                _y = y;
                _viewer.SetZoom();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the amount of zoom in the x direction.
        /// </summary>
        /// <value>
        /// The amount of zoom in the x direction.
        /// </value>

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    _viewer.SetZoom();
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the amount of zoom in the y direction.
        /// </summary>
        /// <value>
        /// The amount of zoom in the y direction.
        /// </value>

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    _viewer.SetZoom();
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ZoomInfo: X=" + _x + ", Y=" + _y;
        }
    }
}
// We use this class to find the icon for the Viewer (see the ToolboxBitmap attribute above).
// Please do not remove.
internal class Resfinder {}
