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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using NationalInstruments.Vision.Internal;
using NationalInstruments.Vision.WindowsForms;
using NationalInstruments.Vision.WindowsForms.Internal;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;

namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>
    /// Specifies the type of a contour.
    /// </summary>

    public enum ContourType
    {
        //==========================================================================================
        /// <summary>
        /// The contour represents a point.
        /// </summary>

        Point = 0,
        //==========================================================================================
        /// <summary>
        /// The contour represents a line.
        /// </summary>

        Line = 1,
        //==========================================================================================
        /// <summary>
        /// The contour represents a rectangle.
        /// </summary>

        Rectangle = 2,
        //==========================================================================================
        /// <summary>
        /// The contour represents a rotated rectangle.
        /// </summary>

        RotatedRectangle = 3,
        //==========================================================================================
        /// <summary>
        /// The contour represents an oval.
        /// </summary>

        Oval = 4,
        //==========================================================================================
        /// <summary>
        /// The contour represents an annulus. 
        /// </summary>

        Annulus = 5,
        //==========================================================================================
        /// <summary>
        /// The contour represents a polygon.
        /// </summary>

        Polygon = 6,
        //==========================================================================================
        /// <summary>
        /// The contour represents a freehand region.
        /// </summary>

        FreehandRegion = 7,
        //==========================================================================================
        /// <summary>
        /// The contour represents a freehand line.
        /// </summary>

        FreehandLine = 8,
        //==========================================================================================
        /// <summary>
        /// The contour represents a polyline.
        /// </summary>

        Polyline = 9
    };

    //==============================================================================================
    /// <summary>
    /// An abstract class that represents a shape, such as a point, line, rectangle, or annulus.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public abstract class Shape
    {
        //==========================================================================================
        /// <summary>
        /// Moves the shape horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.
        /// </param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.
        /// </param>

        public abstract void Move(double dx, double dy);
        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source shape.
        /// </summary>
        /// <returns>
        /// A new shape with the same properties as the source shape.</returns>

        public abstract Shape Clone();
        //==========================================================================================
        /// <summary>
        /// Returns an Roi that contains this shape.</summary>
        /// <returns>
        /// An Roi that contains this shape.</returns>

        public Roi ConvertToRoi()
        {
            return new Roi(new Shape[] { this });
        }

        
        internal abstract void SetFromVisionContour(IntPtr contour);

        
        internal abstract IntPtr GetVisionContour(Rgb32Value color, bool external);

        
        internal abstract ContourType ContourType { get; }

        
        internal virtual bool ChangePoint(double x, double y, Int32 index)
        {
            // We should never get here.
            Debug.Fail("Got ChangePoint() message in contour of type " + this.GetType().FullName);
            return false;
        }

        
        internal event EventHandler<EventArgs> PropertyChanged;

        
        internal virtual void OnPropertyChanged(EventArgs args) {
            EventHandler<EventArgs> handler = PropertyChanged;
            if (handler != null) {
                handler(this, args);
            }
        }

        
        internal event EventHandler<CancelEventArgs> PropertyChanging;

        
        internal virtual void OnPropertyChanging(CancelEventArgs args) {
            EventHandler<CancelEventArgs> handler = PropertyChanging;
            if (handler != null) {
                handler(this, args);
            }
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents contour data and properties that you can configure on a per contour basis.  
    /// </summary>
    /// <remarks>
    /// Contours are contained in an <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/>.
    /// </remarks>

    public sealed class Contour
    {
        internal Int32 _contourID;
        internal Shape _shape;
        private bool _isExternal;
        private bool _userHasSetColor;
        private Rgb32Value _color;
        internal Roi _containingRoi = null;
        internal IntPtr _visionRoiElement = IntPtr.Zero;
        internal bool _updating = false;

        
        internal event EventHandler<EventArgs> ShapeChanged;
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Contour" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.Contour.Shape" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="shape">
        /// The shape that this contour contains.
        /// </param>

        public Contour(Shape shape) : this(shape, IntPtr.Zero)
        {
        }

internal Contour(Shape shape, IntPtr visionRoiElement)
        {
            if (shape == null) { throw new ArgumentNullException("shape"); }
            _shape = shape;
            // 0 is an invalid contourID.
            _contourID = 0;
            _isExternal = true;
            _visionRoiElement = visionRoiElement;
            _color = Rgb32Value.GreenColor;
            _userHasSetColor = false;
            // We only want to do this if we're inside a ViewerRoi, but this is a kinda hacky check.
            if (_visionRoiElement != IntPtr.Zero)
            {
                _shape.PropertyChanging += HandleShapePropertyChanging;
                _shape.PropertyChanged += HandleShapePropertyChanged;
            }
        }

internal Int32 ContourID
        {
            set
            {
                _contourID = value;
                // If we now have a non-zero contourID, if the user has set a different color
                // than the default for the Roi, set that.
                if (_contourID != 0 && _containingRoi != null)
                {
                    _containingRoi.SetContourColor(this, _color);
                }
            }
            get
            {
                return _contourID;
            }
        }

internal void OnShapeChanged(EventArgs args) {
            EventHandler<EventArgs> handler = ShapeChanged;
            if (handler != null) {
                handler(this, args);
            }
        }

        
        void HandleShapePropertyChanging(object sender, CancelEventArgs e)
        {
            // We get this event when the user is attempting to change the contour programmatically.
            // Disallow this if the contour is being changed interactively.
            if (_updating)
            {
                e.Cancel = true;
            }
        }

        
        private void HandleShapePropertyChanged(object sender, EventArgs args)
        {
            OnShapeChanged(args);
        }

        
        internal static ContourType ConvertToContourType(CVI_SelectionMode selectionMode)
        {
            switch (selectionMode)
            {
                case CVI_SelectionMode.None:
                    return (ContourType)(-1);
                case CVI_SelectionMode.Click:
                    return ContourType.Point;
                case CVI_SelectionMode.Line:
                    return ContourType.Line;
                case CVI_SelectionMode.Rectangle:
                    return ContourType.Rectangle;
                case CVI_SelectionMode.Oval:
                    return ContourType.Oval;
                case CVI_SelectionMode.Polygon:
                    return ContourType.Polygon;
                case CVI_SelectionMode.Free:
                    return ContourType.FreehandRegion;
                case CVI_SelectionMode.Annulus:
                    return ContourType.Annulus;
                case CVI_SelectionMode.Zoom:
                    return (ContourType)(-1);
                case CVI_SelectionMode.Pan:
                    return (ContourType)(-1);
                case CVI_SelectionMode.BrokenLine:
                    return ContourType.Polyline;
                case CVI_SelectionMode.FreeLine:
                    return ContourType.FreehandLine;
                case CVI_SelectionMode.RotatedRectangle:
                    return ContourType.RotatedRectangle;
                default:
                    Debug.Fail("Unknown selection mode!");
                    return (ContourType)(-1);
            }
        }

        
        internal bool HandleMessage(ViewerMessage msg, IntPtr lParam)
        {
            if (msg == ViewerMessage.MoveElement)
            {
                System.Drawing.Size size = (System.Drawing.Size)Marshal.PtrToStructure(lParam, typeof(System.Drawing.Size));
                Shape.Move(size.Width, size.Height);
                return true;
            }
            else if (msg == ViewerMessage.ChangePointInElement)
            {
                VB_PointData pointData = (VB_PointData)Marshal.PtrToStructure(lParam, typeof(VB_PointData));
                return Shape.ChangePoint(pointData.Point.X, pointData.Point.Y, pointData.Index);
            }
            return false;
        }

internal void HandleUpdatingMessage(bool newUpdating) {
            // Make sure that we're toggling.
            Debug.Assert(_updating != newUpdating, "Got non-toggling update message!");
            _updating = newUpdating;
        }

internal IntPtr GetVisionContour()
        {
            return Shape.GetVisionContour(_color, _isExternal);
        }

        
        internal void SetContainingRoi(Roi roi)
        {
            _containingRoi = roi;
            // If the user has not set the color, get the default color for the ROI.
            if (_containingRoi != null)
            {
                if (!_userHasSetColor)
                {
                    // Assign to _color, not Color, in case we don't have a ContourID yet.
                    _color = _containingRoi.Color;
                }
                // We don't care anymore whether the user has set the color or not - we have a color now.
                _userHasSetColor = false;
                if (_contourID != 0)
                {
                    _containingRoi.SetContourColor(this, _color);
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the color of this contour.
        /// </summary>
        /// <value>
        /// If this contour is contained in an <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/>, the default value is the same as the <see cref="NationalInstruments.Vision.Roi.Color" crefType="Unqualified"/> property.  If not, the default value is <see cref="NationalInstruments.Vision.Rgb32Value.GreenColor" crefType="PartiallyQualified"/>.
        /// </value>

        public Rgb32Value Color
        {
            get { return _color; }
            set {
                _color = value;
                // If we don't have a containing Roi yet, save the color and record the fact that it was set by the user.
                _userHasSetColor = true;
                if (_containingRoi != null)
                {
                    _containingRoi.SetContourColor(this, _color);
                }
           }
        }
        //==========================================================================================
        /// <summary>
        /// Copies this contour to another <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="destination">
        /// The <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/> to add a copy of this contour to.
        /// </param>

        public void CopyTo(Roi destination)
        {
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            destination.Add(Shape.Clone());
            Contour c = destination[destination.Count - 1];
            c.IsExternal = _isExternal;
            c.Color = _color;
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the contour is external or internal.
        /// </summary>
        /// <value>
        /// The default is <see langword="true"/>, meaning the contour is external.
        /// </value>

        public bool IsExternal
        {
            get { return _isExternal; }
            set { _isExternal = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the shape that this contour contains.
        /// </summary>
        /// <value>
        /// </value>

        public Shape Shape
        {
            get { return _shape; }
            internal set { _shape = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the type of shape that this contour contains.
        /// </summary>
        /// <value>
        /// </value>

        public ContourType Type
        {
            get { return _shape.ContourType; }
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
            return "Contour: Type=" + Type.ToString() + ", Shape=" + Shape.ToString();
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A Contour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Contour other)
        {
            return (other != null) && Object.Equals(_shape, other._shape) && _isExternal == other._isExternal && _color == other._color;
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
            Contour other = (Contour)obj;
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
            return _shape.GetHashCode() ^ _isExternal.GetHashCode() ^ _color.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a region of interest, typically used to indicate what parts of the image to process.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public class Roi : IEnumerable<Contour>, IEnumerable, IDisposable
    {
        internal IntPtr _roi = IntPtr.Zero;
        private Rgb32Value _color;
        private Collection<Contour> _collection;
        private object _disposeLock = new object();

        //==========================================================================================
        /// <summary>
        /// Gets or sets the color of a region of interest (ROI). This is the default color of Contours added to this Roi.
        /// </summary>
        /// <value>
        /// The color of an ROI. 
        /// </value>

        public Rgb32Value Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnSetColor(_color);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/> class. 
        /// </summary>

        public Roi()
        {
            _color = Rgb32Value.GreenColor;
            _roi = VisionDllCommon.imaqCreateROI();
            Utilities.ThrowError(_roi);
            _collection = new Collection<Contour>();
        }

        //==========================================================================================
        /// <summary>
        /// Creates a new <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/> containing one shape.
        /// </summary>
        /// <param name="shape">
        /// </param>

        public Roi(Shape shape)
            : this()
        {
            Add(shape);
        }
        //==========================================================================================
        /// <summary>
        /// Creates a new <see cref="NationalInstruments.Vision.Roi" crefType="Unqualified"/> containing some shapes.
        /// </summary>
        /// <param name="shapes">
        /// </param>

        public Roi(IList<Shape> shapes) : this()
        {
            foreach (Shape shape in shapes) {
                Add(shape);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Creates a new ROI that is a copy of an existing one.
        /// </summary>
        /// <param name="existing">The ROI to copy.</param>

        public Roi(Roi existing)
            : this()
        {
            if (existing == null) { throw new ArgumentNullException("existing"); }
            existing.ThrowIfDisposed();
            Color = existing.Color;
            foreach (Contour c in existing)
            {
                Add(c.Shape.Clone());
            }
        }

        
        internal Roi(IntPtr roiPtr)
        {
            _roi = VisionDllCommon.imaqCreateROI();
            Utilities.ThrowError(_roi);
            Utilities.ThrowError(VisionDllCommon.imaqGetROIColor(roiPtr, out _color));
            Utilities.ThrowError(VisionDllCommon.imaqSetROIColor(_roi, ref _color));
            _collection = new Collection<Contour>();
            Int32 numContours = VisionDllCommon.imaqGetContourCount(roiPtr);
            for (int i = 0; i < numContours; ++i)
            {
                // Get the contour out of the existing Roi and add it into ours.
                // We don't assign the contourID here because we're copying an existing Roi here, and we still
                // need to add it to this Roi.
                Contour c = GetExistingContour(i, roiPtr, false);
                AddContour(c);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns the bounding rectangle for the region of interest (ROI). The bounding rectangle is the smallest rectangle that contains all of the contours that comprise the ROI. 
        /// </summary>
        /// <returns>
        /// </returns>

        public RectangleContour GetBoundingRectangle()
        {
            ThrowIfDisposed();
            CVI_Rectangle cviRect = new CVI_Rectangle();
            Utilities.ThrowError(VisionDllCommon.imaqGetROIBoundingBox(_roi, out cviRect));
            return cviRect.ConvertToExternal();
        }

        
        internal void PointerUpdated() {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqGetROIColor(_roi, out _color));
            _collection.Clear();
            Int32 numContours = VisionDllCommon.imaqGetContourCount(_roi);
            for (int i = 0; i < numContours; ++i)
            {
                // Get the contour out of this Roi.
                Contour c = GetExistingContour(i, _roi, true);
                // Add it to our collection.
                _collection.Insert(_collection.Count, c);
                c.SetContainingRoi(this);
            }
        }

        
        private static Contour GetExistingContour(Int32 index, IntPtr _roiPtr, bool copyContourId)
        {
            Int32 contourID = VisionDllCommon.imaqGetContour(_roiPtr, (UInt32)index);
            IntPtr contourInfoPtr = VisionDllCommon.imaqGetContourInfo2(_roiPtr, contourID);
            Utilities.ThrowError(contourInfoPtr);
            Contour toReturn = Utilities.ConvertIntPtrToStructure<Contour, CVI_ContourInfo2>(contourInfoPtr, true);
            if (copyContourId)
            {
                toReturn._contourID = contourID;
            }
            return toReturn;
        }
        //==========================================================================================
        /// <summary>
        /// Returns an enumerator of the Contours in this Roi.
        /// </summary>
        /// <returns>
        /// </returns>

        public IEnumerator<Contour> GetEnumerator()
        {
            ThrowIfDisposed();
            return _collection.GetEnumerator();
        }
        //==========================================================================================
        /// <summary>
        /// Gets an enumerator for the Contours in this Roi.
        /// </summary>
        /// <returns>
        /// </returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            ThrowIfDisposed();
            return _collection.GetEnumerator();
        }
        //==========================================================================================
        /// <summary>
        /// Adds the shape to this Roi.
        /// </summary>
        /// <param name="item">
        /// The shape to add to this Roi.
        /// </param>

        public void Add(Shape item)
        {
            ThrowIfDisposed();
            if (item == null) { throw new ArgumentNullException("item"); }
            InsertItem(_collection.Count, item);
        }

        
        internal void AddContour(Contour item)
        {
            ThrowIfDisposed();
            _collection.Insert(_collection.Count, item);
            AddContourToVisionRoi(item);
            item.SetContainingRoi(this);
        }

        //==========================================================================================
        /// <summary>
        /// Removes all contours from this Roi.
        /// </summary>

        public void Clear()
        {
            ClearItems();
        }
        //==========================================================================================
        /// <summary>
        /// Gets the number of Contours this Roi contains.
        /// </summary>
        /// <value>
        /// </value>

        public int Count { get { ThrowIfDisposed();  return _collection.Count; } }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>

        public Contour this[int index]
        {
            get
            {
                ThrowIfDisposed();
                return _collection[index];
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns the contour for the region of interest (ROI).  
        /// </summary>
        /// <returns>
        /// </returns>

        public Contour GetContour(int index)
        {
            return this[index];
        }
        //==========================================================================================
        /// <summary>
        /// Removes the contour at the given index.</summary>
        /// <param name="index">
        /// </param>

        public void RemoveAt(int index)
        {
            ThrowIfDisposed();
            RemoveItem(index);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="item">
        /// </param>

        protected virtual void InsertItem(int index, Shape item)
        {
            ThrowIfDisposed();
            Contour toInsert = new Contour(item);
            _collection.Insert(index, toInsert);
            toInsert.SetContainingRoi(this);
            AddContourToVisionRoi(toInsert);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>

        protected virtual void RemoveItem(int index)
        {
            ThrowIfDisposed();
            Contour toRemove = this[index];
            RemoveContourFromVisionRoi(toRemove);
            _collection.RemoveAt(index);
        }

        
        protected virtual void ClearItems()
        {
            ThrowIfDisposed();
            Int32 numItems = Count;
            for (int i = 0; i < numItems; ++i)
            {
                RemoveItem(0);
            }
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="item">
        /// </param>

        protected virtual void SetItem(int index, Contour item)
        {
            ThrowIfDisposed();
            RemoveContourFromVisionRoi(this[index]);
            _collection[index] = item;
            item.SetContainingRoi(this);
            AddContour(item);
        }

        
        protected void AddContourToVisionRoi(Contour item)
        {
            ThrowIfDisposed();
            if (item == null) { throw new ArgumentNullException("item"); }
            switch (item.Type)
            {
                case ContourType.Point:
                    PointContour pointShape = (PointContour)item.Shape;
                    CVI_Point cviPoint = new CVI_Point();
                    cviPoint.ConvertFromExternal(pointShape);
                    item.ContourID = VisionDllCommon.imaqAddPointContour(_roi, cviPoint);
                    break;
                case ContourType.Rectangle:
                    RectangleContour rectangleShape = (RectangleContour)item.Shape;
                    CVI_Rectangle cviRect = new CVI_Rectangle();
                    cviRect.ConvertFromExternal(rectangleShape);
                    item.ContourID = VisionDllCommon.imaqAddRectContour(_roi, cviRect);
                    break;
                case ContourType.Line:
                    LineContour lineShape = (LineContour)item.Shape;
                    CVI_Point cviStart = new CVI_Point();
                    cviStart.ConvertFromExternal(lineShape.Start);
                    CVI_Point cviEnd = new CVI_Point();
                    cviEnd.ConvertFromExternal(lineShape.End);
                    item.ContourID = VisionDllCommon.imaqAddLineContour(_roi, cviStart, cviEnd);
                    break;
                case ContourType.RotatedRectangle:
                    RotatedRectangleContour rotatedRectangleShape = (RotatedRectangleContour)item.Shape;
                    CVI_RotatedRectangle cviRotatedRect = new CVI_RotatedRectangle();
                    cviRotatedRect.ConvertFromExternal(rotatedRectangleShape);
                    item.ContourID = VisionDllCommon.imaqAddRotatedRectContour(_roi, cviRotatedRect);
                    break;
                case ContourType.Oval:
                    OvalContour ovalShape = (OvalContour)item.Shape;
                    CVI_Rectangle cviOvalRect = new CVI_Rectangle();
                    cviOvalRect.ConvertFromExternal(ovalShape);
                    item.ContourID = VisionDllCommon.imaqAddOvalContour(_roi, cviOvalRect);
                    break;
                case ContourType.Annulus:
                    AnnulusContour annulusShape = (AnnulusContour)item.Shape;
                    CVI_Annulus cviAnnulus = new CVI_Annulus();
                    cviAnnulus.ConvertFromExternal(annulusShape);
                    item.ContourID = VisionDllCommon.imaqAddAnnulusContour(_roi, cviAnnulus);
                    break;
                case ContourType.Polygon:
                    PolygonContour polygonShape = (PolygonContour)item.Shape;
                    CVI_Point[] cviPolygonPoints = polygonShape.GetCVIPoints();
                    item.ContourID = VisionDllCommon.imaqAddClosedContour(_roi, cviPolygonPoints, cviPolygonPoints.Length);
                    break;
                case ContourType.FreehandRegion:
                    FreehandRegionContour freeRegionShape = (FreehandRegionContour)item.Shape;
                    CVI_Point[] cviFreeRegionPoints = freeRegionShape.GetCVIPoints();
                    item.ContourID = VisionDllCommon.imaqAddClosedContour(_roi, cviFreeRegionPoints, cviFreeRegionPoints.Length);
                    break;
                case ContourType.FreehandLine:
                    FreehandLineContour freeLineShape = (FreehandLineContour)item.Shape;
                    CVI_Point[] cviFreeLinePoints = freeLineShape.GetCVIPoints();
                    item.ContourID = VisionDllCommon.imaqAddOpenContour(_roi, cviFreeLinePoints, cviFreeLinePoints.Length);
                    break;
                case ContourType.Polyline:
                    PolylineContour brokenLineShape = (PolylineContour)item.Shape;
                    CVI_Point[] cviBrokenLinePoints = brokenLineShape.GetCVIPoints();
                    item.ContourID = VisionDllCommon.imaqAddOpenContour(_roi, cviBrokenLinePoints, cviBrokenLinePoints.Length);
                    break;
                default:
                    Debug.Fail("Unknown contour type!");
                    break;
            }
            Utilities.ThrowError(item.ContourID == 0);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="item">
        /// </param>

        protected void RemoveContourFromVisionRoi(Contour item)
        {
            ThrowIfDisposed();
            if (item == null) { throw new ArgumentNullException("item"); }
            Utilities.ThrowError(VisionDllCommon.imaqRemoveContour(_roi, item.ContourID));
            // So we don't remove it again, set its contour ID to 0.
            item.ContourID = 0;
        }

internal virtual void SetContourColor(Contour item, Rgb32Value color)
        {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqSetContourColor(_roi, item.ContourID, ref color));
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="color">
        /// </param>

        internal protected virtual void OnSetColor(Rgb32Value color) {
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// An Roi instance to compare to this instance.</param>
        /// <returns>
        /// </returns>

        public bool Equals(Roi other)
        {
            return (other != null) && _color == other._color && Utilities.CollectionsEqual(_collection, other._collection);
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
            Roi other = (Roi)obj;
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
            return _color.GetHashCode() ^ _collection.GetHashCode();
        }

internal void ThrowIfDisposed()
		{
			if (_roi == IntPtr.Zero)
			{
                throw new ObjectDisposedException("NationalInstruments.Vision.Roi");
			}
		}

        
        internal static IntPtr GetIntPtr(Roi roi)
        {
            IntPtr cviRoi = IntPtr.Zero;
            if (roi != null)
            {
                cviRoi = roi._roi;
            }
            return cviRoi;
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
            StringBuilder sb = new StringBuilder("Roi: {");
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

        
        internal static void ThrowIfNonNullAndDisposed(Roi roi)
        {
            if (roi != null)
            {
                roi.ThrowIfDisposed();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by Roi.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="disposing">
        /// </param>

        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // _roi is safe to use since it's unmanaged.
                if (_roi != IntPtr.Zero)
                {
                    VisionDllCommon.imaqDispose(_roi);
                    _roi = IntPtr.Zero;
                }
            }
        }

        
        ~Roi()
        {
            Dispose(false);
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the height, width, and coordinate values of a rectangle.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class RectangleContour : Shape, IEquatable<RectangleContour>
    {
        private double _top;
        private double _left;
        private double _height;
        private double _width;

        //==========================================================================================
        /// <summary>
        /// Gets a rectangle that includes the whole image.</summary>
        /// <value>
        /// A rectangle that includes the whole image.
        /// </value>
        /// <remarks>
        ///  If a method takes in a <see cref="NationalInstruments.Vision.RectangleContour" crefType="Unqualified"/>, you can pass <see cref="NationalInstruments.Vision.RectangleContour.None" crefType="Unqualified"/> to make the method process the whole image.
        /// </remarks>

        public static RectangleContour None {
            get {
                return new RectangleContour(0, 0, 0x7FFFFFFF, 0x7FFFFFFF);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RectangleContour" crefType="Unqualified"/> class. 
        /// </summary>

        public RectangleContour()
            : this(0, 0, 0x7FFFFFFF, 0x7FFFFFFF)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RectangleContour" crefType="Unqualified"/> class with the specified dimensions. 
        /// </summary>
        /// <param name="left">
        /// The left coordinate of the rectangle.
        /// </param>
        /// <param name="top">
        /// The top coordinate of the rectangle.
        /// </param>
        /// <param name="width">
        /// The width of the rectangle.
        /// </param>
        /// <param name="height">
        /// The height of the rectangle.
        /// </param>

        public RectangleContour(double left, double top, double width, double height)
        {
            _top = top;
            _left = left;
            _height = height;
            _width = width;
        }
        //==========================================================================================
        /// <summary>
        /// Copies all of the properties from the source rectangle into the destination rectangle.
        /// </summary>
        /// <returns>
        /// A new rectangle with the same properties as the source rectangle.
        /// </returns>

        public override Shape Clone()
        {
            return new RectangleContour(_left, _top, _width, _height);
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.Rectangle; }
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.</param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.</param>

        public override void Move(double dx, double dy)
        {
            _top += dy;
            _left += dx;
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _top = VisionDllCommon.Priv_GetRectangleContourTop(contour);
            _left = VisionDllCommon.Priv_GetRectangleContourLeft(contour);
            _height = VisionDllCommon.Priv_GetRectangleContourHeight(contour);
            _width = VisionDllCommon.Priv_GetRectangleContourWidth(contour);
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateRectangleContour(color, external, (Int32)Math.Round(_left), (Int32)Math.Round(_top), (Int32)Math.Round(_width), (Int32)Math.Round(_height));
            Utilities.ThrowError(contour);
            return contour;
        }
        //==========================================================================================
        /// <summary>
        /// Sets the properties of the rectangle.
        /// </summary>
        /// <param name="left">
        /// The left coordinate of the rectangle.
        /// </param>
        /// <param name="top">
        /// The top coordinate of the rectangle.
        /// </param>
        /// <param name="width">
        /// The width of the rectangle.
        /// </param>
        /// <param name="height">
        /// The height of the rectangle.
        /// </param>

        public void Initialize(double left, double top, double width, double height)
        {
            if (_left == left && _top == top && _width == width && _height == height) return;
            CancelEventArgs args = new CancelEventArgs();
            OnPropertyChanging(args);
            if (args.Cancel) return;
            _left = left;
            _top = top;
            _width = width;
            _height = height;
            OnPropertyChanged(EventArgs.Empty);
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value>
        /// The width of the rectangle.
        /// The default value is 2147483647.
        /// </value>

        public double Width
        {
            get { return _width; }
            set {
                if (_width == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _width = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        /// <value>
        /// The height of the rectangle.
        /// The default value is 2147483647.
        /// </value>

        public double Height
        {
            get { return _height; }
            set {
                if (_height == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _height = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the left coordinate of the rectangle.
        /// </summary>
        /// <value>
        /// The left coordinate of the rectangle.
        /// The default value is 0.
        /// </value>

        public double Left
        {
            get { return _left; }
            set {
                if (_left == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _left = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the top coordinate of the rectangle.
        /// </summary>
        /// <value>
        /// The top coordinate of the rectangle.
        /// The default value is 0.
        /// </value>

        public double Top
        {
            get { return _top; }
            set {
                if (_top == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _top = value;
                OnPropertyChanged(EventArgs.Empty);
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
            return "RectangleContour: (" + _left + "," + _top + ")-(" + (_left + _width) + "," + (_top + _height) + ")";
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A RectangleContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(RectangleContour other)
        {
            return (other != null) && _left == other._left && _top == other._top && _width == other._width && _height == other._height;
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
            RectangleContour other = (RectangleContour)obj;
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
            return _left.GetHashCode() ^ _top.GetHashCode() ^ _width.GetHashCode() ^ _height.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the end point and start point of a line.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class LineContour : Shape, IEquatable<LineContour>
    {
        private PointContour _start;
        private PointContour _end;
        //==========================================================================================
        /// <summary>
        /// Starting point of the line segment.
        /// </summary>
        /// <value>
        /// Starting point of the line segment.
        /// The default value is (0,0).
        /// </value>

        public PointContour Start
        {
            get { return _start; }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                if (_start.X == value.X && _start.Y == value.Y) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _start.PropertyChanging -= ChildPropertyChanging;
                _start.PropertyChanged -= ChildPropertyChanged;
                _start = value;
                _start.PropertyChanged += ChildPropertyChanged;
                _start.PropertyChanging += ChildPropertyChanging;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Ending point of the line segment.
        /// </summary>
        /// <value>
        /// Ending point of the line segment.
        /// The default value is (0,0).
        /// </value>

        public PointContour End
        {
            get { return _end; }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                if (_end.X == value.X && _end.Y == value.Y) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _end.PropertyChanging -= ChildPropertyChanging;
                _end.PropertyChanged -= ChildPropertyChanged;
                _end = value;
                _end.PropertyChanged += ChildPropertyChanged;
                _end.PropertyChanging += ChildPropertyChanging;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LineContour" crefType="Unqualified"/> class.
        /// </summary>

        public LineContour()
            : this(new PointContour(), new PointContour())
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LineContour" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.LineContour.Start" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.LineContour.End" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="start">
        /// Starting point of the line segment.
        /// </param>
        /// <param name="end">
        /// Ending point of the line segment.
        /// </param>

        public LineContour(PointContour start, PointContour end)
        {
            if (start == null) { throw new ArgumentNullException("start"); }
            if (end == null) { throw new ArgumentNullException("end"); }
            _start = start;
            _end = end;
            Start.PropertyChanged += ChildPropertyChanged;
            Start.PropertyChanging += ChildPropertyChanging;
            End.PropertyChanged += ChildPropertyChanged;
            End.PropertyChanging += ChildPropertyChanging;
        }

        //==========================================================================================
        /// <summary>
        /// Copies all of the properties from the source line segment into the destination line segment.
        /// </summary>
        /// <returns>
        /// A new line segment with the same properties as the source line segment.
        /// </returns>

        public override Shape Clone()
        {
            return new LineContour((PointContour)_start.Clone(), (PointContour)_end.Clone());
        }

void ChildPropertyChanging(object sender, CancelEventArgs e)
        {
            // If our child is changing, we are changing.
            OnPropertyChanging(e);
        }

        
        void ChildPropertyChanged(object sender, EventArgs e)
        {
            // If our child has changed, we have changed.
            OnPropertyChanged(e);
        }
        //==========================================================================================
        /// <summary>
        /// Moves the contour horizontally or vertically.</summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.
        /// </param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.
        /// </param>

        public override void Move(double dx, double dy)
        {
            _start.Move(dx, dy);
            _end.Move(dx, dy);
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.Line; }
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateLineContour(color, external, (int)Math.Round(_start.X), (int)Math.Round(_start.Y), (int)Math.Round(_end.X), (int)Math.Round(_end.Y));
            Utilities.ThrowError(contour);
            return contour;
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _start.X = VisionDllCommon.Priv_GetLineContourX1(contour);
            _start.Y = VisionDllCommon.Priv_GetLineContourY1(contour);
            _end.X = VisionDllCommon.Priv_GetLineContourX2(contour);
            _end.Y = VisionDllCommon.Priv_GetLineContourY2(contour);
        }

        
        internal override bool ChangePoint(double x, double y, int index)
        {
            if (index == 0)
            {
                return _start.ChangePoint(x, y, 0);
            }
            else if (index == 1)
            {
                return _end.ChangePoint(x, y, 0);
            }
            return false;
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
            return "LineContour: " + _start.ToString() + "-" + _end.ToString();
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A LineContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(LineContour other)
        {
            return (other != null) && Object.Equals(_start, other._start) && Object.Equals(_end, other._end);
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
            LineContour other = (LineContour)obj;
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
            return _start.GetHashCode() ^ _end.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the x and y-coordinates of a point.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PointContour : Shape, IEquatable<PointContour>
    {
        private double _x;
        private double _y;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PointContour" crefType="Unqualified"/> class.
        /// </summary>

        public PointContour() : this(0, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PointContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="x">
        /// X-coordinate of the point.
        /// </param>
        /// <param name="y">
        /// Y-coordinate of the point.
        /// </param>

        public PointContour(double x, double y)
        {
            _x = x;
            _y = y;
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PointContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="point">
        /// The point to copy the x and y coordinate from.
        /// </param>

        public PointContour(System.Drawing.Point point)
        {
            _x = point.X;
            _y = point.Y;
        }
        //==========================================================================================
        /// <summary>
        /// Copies the source point into the destination point.
        /// </summary>
        /// <returns>
        /// A new point with the same properties as the source point.
        /// </returns>

        public override Shape Clone()
        {
            return new PointContour(_x, _y);
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.Point; }
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _x = (double) VisionDllCommon.Priv_GetPointContourX(contour);
            _y = (double) VisionDllCommon.Priv_GetPointContourY(contour);
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreatePointContour(color, external, (int)Math.Round(_x), (int)Math.Round(_y));
            Utilities.ThrowError(contour);
            return contour;
        }

        
        internal override bool ChangePoint(double x, double y, int index)
        {
            _x = (double)x;
            _y = (double)y;
            return true;
        }
        //==========================================================================================
        /// <summary>
        /// Moves the point horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.
        /// </param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.
        /// </param>

        public override void Move(double dx, double dy)
        {
            _x += dx;
            _y += dy;
        }
        //==========================================================================================
        /// <summary>
        /// X-coordinate of the point.
        /// </summary>
        /// <value>
        /// X-coordinate of the point.
        /// The default value is 0.
        /// </value>

        public double X
        {
            get { return _x; }
            set {
                if (_x == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _x = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Y-coordinate of the point.
        /// </summary>
        /// <value>
        /// Y-coordinate of the point.
        /// The default value is 0.
        /// </value>

        public double Y
        {
            get { return _y; }
            set { 
                if (_y == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _y = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Sets the X- and Y- coordinate of the point.
        /// </summary>
        /// <param name="x">
        /// The X-coordinate of the point.
        /// </param>
        /// <param name="y">
        /// The Y-coordinate of the point.
        /// </param>

        public void Initialize(double x, double y)
        {
            if (_x == x && _y == y) return;
            CancelEventArgs args = new CancelEventArgs();
            OnPropertyChanging(args);
            if (args.Cancel) return;
            _x = x;
            _y = y;
            OnPropertyChanged(EventArgs.Empty);
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
            return "(" + X + ", " + Y + ")";
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A PointContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PointContour other)
        {
            return (other != null) && _x == other._x && _y == other._y;
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
            PointContour other = (PointContour)obj;
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
            return _x.GetHashCode() ^ _y.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the center point, width, height, and angle of a rotated rectangle.
    /// </summary>
    /// <remarks>
    /// The width and height parameters set the axes that are horizontal and vertical, respectively, when the rectangle is not rotated (Angle = 0).
    /// </remarks>

    [Serializable]
    public sealed class RotatedRectangleContour : Shape, IEquatable<RotatedRectangleContour>
    {
        private PointContour _center;
        private double _width;
        private double _height;
        private double _angle;

void ChildPropertyChanging(object sender, CancelEventArgs e)
        {
            // If our child is changing, we are changing.
            OnPropertyChanging(e);
        }

        
        void ChildPropertyChanged(object sender, EventArgs e)
        {
            // If our child has changed, we have changed.
            OnPropertyChanged(e);
        }
        //==========================================================================================
        /// <summary>
        /// A rotated rectangle that includes the whole image.</summary>
        /// <value>
        /// Rotated rectangle that includes the whole image.
        /// </value>
        /// <remarks>
        /// If a method takes in a RotatedRectangleContour, you can pass <see cref="NationalInstruments.Vision.RotatedRectangleContour.None" crefType="Unqualified"/> to make the method process the whole image.
        /// </remarks>

        public static RotatedRectangleContour None {
            get {
                return new RotatedRectangleContour(new PointContour(), 0x7FFFFFFF, 0x7FFFFFFF, 0);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RotatedRectangleContour" crefType="Unqualified"/> class. 
        /// </summary>

        public RotatedRectangleContour()
            : this(new PointContour(), 0.0, 0.0, 0.0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RotatedRectangleContour" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.RotatedRectangleContour.Center" crefType="Unqualified"/>,
        /// <see cref="NationalInstruments.Vision.RotatedRectangleContour.Width" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.RotatedRectangleContour.Height" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="center">
        /// The center point of the rectangle.
        /// </param>
        /// <param name="width">
        /// Length of the rectangle axis that is horizontal when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// </param>
        /// <param name="height">
        /// Length of the rectangle axis that is vertical when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// </param>
        /// <param name="angle">
        /// The rotation angle, in degrees, of the rectangle.
        /// </param>

        public RotatedRectangleContour(PointContour center, double width, double height, double angle)
        {
            if (center == null) { throw new ArgumentNullException("center"); }
            _center = center;
            _center.PropertyChanged += ChildPropertyChanged;
            _center.PropertyChanging += ChildPropertyChanging;
            _width = width;
            _height = height;
            _angle = angle;
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RotatedRectangleContour" crefType="Unqualified"/> class. 
        /// </summary>
        /// <param name="rect">
        /// The rectangle to copy data from.
        /// </param>

        public RotatedRectangleContour(RectangleContour rect)
        {
            if (rect == null) { throw new ArgumentNullException("rect"); }
            _center = new PointContour(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
            _center.PropertyChanged += ChildPropertyChanged;
            _center.PropertyChanging += ChildPropertyChanging;
            _width = rect.Width;
            _height = rect.Height;
            _angle = 0;
        }
        //==========================================================================================
        /// <summary>
        /// Copies all of the properties from the source rotated rectangle into the destination rotated rectangle.
        /// </summary>
        /// <returns>
        /// A new rotated rectangle with the same properties as the source rotated rectangle.</returns>

        public override Shape Clone()
        {
            return new RotatedRectangleContour((PointContour)_center.Clone(), _width, _height, _angle);
        }
        //==========================================================================================
        /// <summary>
        /// Gets the bounding rectangle of the rotated rectangle.
        /// </summary>
        /// <returns>
        /// </returns>

        public unsafe RectangleContour GetBoundingRectangle()
        {
            VB_RotatedRectangle vbRotatedRect = new VB_RotatedRectangle(new CVI_PointFloat((float)_center.X, (float)_center.Y), (float)_width, (float)_height, (float)_angle);
            VB_Rectangle result = new VB_Rectangle();
            VisionDllCommon.Priv_GetRotatedRectangleBoundingRect(ref vbRotatedRect, out result);
            return new RectangleContour(result.Left, result.Top, result.Width, result.Height);
        }
        //==========================================================================================
        /// <summary>
        /// Moves the rectangle horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.</param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.
        /// </param>

        public override void Move(double dx, double dy)
        {
            _center.Move(dx, dy);
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.RotatedRectangle; }
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _center.X = VisionDllCommon.Priv_GetRotatedRectangleContourCenterX(contour);
            _center.Y = VisionDllCommon.Priv_GetRotatedRectangleContourCenterY(contour);
            _width = VisionDllCommon.Priv_GetRotatedRectangleContourWidth(contour);
            _height = VisionDllCommon.Priv_GetRotatedRectangleContourHeight(contour);
            _angle = VisionDllCommon.Priv_GetRotatedRectangleContourAngle(contour);
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateRotatedRectangleContour(color, external, (int)Math.Round(_center.X - (_width / 2.0)), (int)Math.Round(_center.Y - (_height / 2.0)), (int)_width, (int)_height, _angle);
            Utilities.ThrowError(contour);
            return contour;
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the rotation angle of the rectangle.
        /// </summary>
        /// <value>
        /// The rotation angle, in degrees, of the rectangle.
        /// The default value is 0.
        /// </value>

        public double Angle
        {
            get { return _angle; }
            set {
                if (_angle == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _angle = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the center point of the rectangle.
        /// </summary>
        /// <value>
        /// The center point of the rectangle.
        /// The default value is (0,0).
        /// </value>

        public PointContour Center
        {
            get { return _center; }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                if (_center.X == value.X && _center.Y == value.Y) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _center.PropertyChanging -= ChildPropertyChanging;
                _center.PropertyChanged -= ChildPropertyChanged;
                _center = value;
                _center.PropertyChanged += ChildPropertyChanged;
                _center.PropertyChanging += ChildPropertyChanging;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the length of the rectangle axis that is horizontal when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// </summary>
        /// <value>
        /// The length of the rectangle axis that is horizontal when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// The default value is 0.
        /// </value>

        public double Width
        {
            get { return _width; }
            set {
                if (_width == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _width = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the length of the rectangle axis that is vertical when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// </summary>
        /// <value>
        /// Length of the rectangle axis that is vertical when <see cref="NationalInstruments.Vision.RotatedRectangleContour.Angle" crefType="Unqualified"/> equals 0. 
        /// The default value is 0.
        /// </value>

        public double Height
        {
            get { return _height; }
            set {
                if (_height == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _height = value;
                OnPropertyChanged(EventArgs.Empty);
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
            return "RotatedRectangleContour: Center=" + _center + ", Width=" + _width + ", Height=" + _height + ", Angle=" + _angle;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A RotatedRectangleContour instance to compare to this instance.</param>
        /// <returns>
        /// </returns>

        public bool Equals(RotatedRectangleContour other)
        {
            return (other != null) && Object.Equals(_center, other._center) && _width == other._width && _height == other._height && _angle == other._angle;
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
            RotatedRectangleContour other = (RotatedRectangleContour)obj;
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
            return _center.GetHashCode() ^ _width.GetHashCode() ^ _height.GetHashCode() ^ _angle.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the x and y-coordinates and axes of an oval.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class OvalContour : Shape, IEquatable<OvalContour>
    {
        private double _top;
        private double _left;
        private double _height;
        private double _width;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OvalContour" crefType="Unqualified"/> class.
        /// </summary>

        public OvalContour()
            : this(0, 0, 0, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OvalContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="left">
        /// The leftmost x-coordinate of the oval.
        /// </param>
        /// <param name="top">
        /// The topmost y-coordinate of the oval.
        /// </param>
        /// <param name="width">
        /// The length of the horizontal axis of the oval.
        /// </param>
        /// <param name="height">
        /// The length of the vertical axis of the oval.
        /// </param>

        public OvalContour(double left, double top, double width, double height)
        {
            _top = top;
            _left = left;
            _height = height;
            _width = width;
        }
        //==========================================================================================
        /// <summary>
        /// Sets all the properties of the oval.
        /// </summary>
        /// <param name="left">
        /// The leftmost x-coordinate of the oval.
        /// </param>
        /// <param name="top">
        /// The topmost y-coordinate of the oval.
        /// </param>
        /// <param name="width">
        /// The length of the horizontal axis of the oval.
        /// </param>
        /// <param name="height">
        /// The length of the vertical axis of the oval.
        /// </param>

        public void Initialize(double left, double top, double width, double height)
        {
            if (_left == left && _top == top && _width == width && _height == height) return;
            CancelEventArgs args = new CancelEventArgs();
            OnPropertyChanging(args);
            if (args.Cancel) return;
            _top = top;
            _left = left;
            _height = height;
            _width = width;
            OnPropertyChanged(EventArgs.Empty);
        }
        //==========================================================================================
        /// <summary>
        /// Copies all of the properties from the source oval into the destination oval.
        /// </summary>
        /// <returns>
        /// </returns>

        public override Shape Clone()
        {
            return new OvalContour(_left, _top, _width, _height);
        }
        //==========================================================================================
        /// <summary>
        /// Moves the contour horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.</param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.</param>

        public override void Move(double dx, double dy)
        {
            _top += dy;
            _left += dx;
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.Oval; }
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _top = VisionDllCommon.Priv_GetOvalContourTop(contour);
            _left = VisionDllCommon.Priv_GetOvalContourLeft(contour);
            _height = VisionDllCommon.Priv_GetOvalContourHeight(contour);
            _width = VisionDllCommon.Priv_GetOvalContourWidth(contour);
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateOvalContour(color, external, (Int32)Math.Round(_left), (Int32)Math.Round(_top), (Int32)Math.Round(_width), (Int32)Math.Round(_height));
            Utilities.ThrowError(contour);
            return contour;
        }
        //==========================================================================================
        /// <summary>
        /// Length of the horizontal axis of the oval.
        /// </summary>
        /// <value>
        /// Length of the horizontal axis of the oval.
        /// The default value is 0.
        /// </value>

        public double Width
        {
            get { return _width; }
            set {
                if (_width == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _width = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Length of the vertical axis of the oval.
        /// </summary>
        /// <value>
        /// Length of the vertical axis.
        /// The default value is 0.
        /// </value>

        public double Height
        {
            get { return _height; }
            set {
                if (_height == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _height = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Leftmost x-coordinate of the oval.
        /// </summary>
        /// <value>
        /// Leftmost x-coordinate of the oval. The default value is 0.
        /// </value>

        public double Left
        {
            get { return _left; }
            set {
                if (_left == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _left = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Topmost y-coordinate of the oval.
        /// </summary>
        /// <value>
        /// Topmost y-coordinate of the oval.
        /// The default value is 0.
        /// </value>

        public double Top
        {
            get { return _top; }
            set {
                if (_top == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _top = value;
                OnPropertyChanged(EventArgs.Empty);
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
            return "OvalContour: (" + _left + "," + _top + ")-(" + (_left + _width) + "," + (_top + _height) + ")";
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An OvalContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(OvalContour other)
        {
            return (other != null) && _left == other._left && _top == other._top && _width == other._width && _height == other._height;
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
            OvalContour other = (OvalContour)obj;
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
            return _left.GetHashCode() ^ _top.GetHashCode() ^ _width.GetHashCode() ^ _height.GetHashCode();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the location and size that specify an annulus, a ring-shaped geometric figure.
    /// </summary>
    /// <remarks>
    /// </remarks>
/// <approved>True</approved>
    //==============================================================================================
    [Serializable]
    public sealed class AnnulusContour : Shape, IEquatable<AnnulusContour>
    {
        private PointContour _center;
        private double _innerRadius;
        private double _outerRadius;
        private double _startAngle;
        private double _endAngle;

void ChildPropertyChanging(object sender, CancelEventArgs e)
        {
            // If our child is changing, we are changing.
            OnPropertyChanging(e);
        }

        
        void ChildPropertyChanged(object sender, EventArgs e)
        {
            // If our child has changed, we have changed.
            OnPropertyChanged(e);
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AnnulusContour" crefType="Unqualified"/> class. 
        /// </summary>
/// <approved>True</approved>
        //==========================================================================================
        public AnnulusContour()
            : this(new PointContour(), 0, 0, 0.0, 0.0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AnnulusContour" crefType="Unqualified"/> class with the specified center, radii, and angles. 
        /// </summary>
        /// <param name="center">
        /// The x-coordinate and y-coordinate of the center point.
        /// </param>
        /// <param name="innerRadius">
        /// The internal radius.
        /// </param>
        /// <param name="outerRadius">
        /// The external radius.
        /// </param>
        /// <param name="startAngle">
        /// The start angle, in degrees.
        /// </param>
        /// <param name="endAngle">
        /// The end angle, in degrees.
        /// </param>
/// <approved>True</approved>
        //==========================================================================================
        public AnnulusContour(PointContour center, double innerRadius, double outerRadius, double startAngle, double endAngle)
        {
            if (center == null) { throw new ArgumentNullException("center"); }
            _center = center;
            _center.PropertyChanged += ChildPropertyChanged;
            _center.PropertyChanging += ChildPropertyChanging;
            _innerRadius = innerRadius;
            _outerRadius = outerRadius;
            _startAngle = startAngle;
            _endAngle = endAngle;
        }
        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source annulus.
        /// </summary>
        /// <returns>
        /// A new annulus with the same properties as the source annulus.
        /// </returns>
/// <approved>True</approved>
        //==========================================================================================
        public override Shape Clone()
        {
            return new AnnulusContour((PointContour)_center.Clone(), _innerRadius, _outerRadius, _startAngle, _endAngle);
        }
        //==========================================================================================
        /// <summary>
        /// Moves the contour horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move the contour on the x-axis.</param>
        /// <param name="dy">
        /// Distance in pixels to move the contour on the y-axis.</param>
/// <approved>True</approved>
        //==========================================================================================
        public override void Move(double dx, double dy)
        {
            _center.Move(dx, dy);
        }

        
        internal override ContourType ContourType
        {
            get { return ContourType.Annulus; }
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            _center.X = VisionDllCommon.Priv_GetAnnulusContourCenterX(contour);
            _center.Y = VisionDllCommon.Priv_GetAnnulusContourCenterY(contour);
            _innerRadius = VisionDllCommon.Priv_GetAnnulusContourInnerRadius(contour);
            _outerRadius = VisionDllCommon.Priv_GetAnnulusContourOuterRadius(contour);
            _startAngle = VisionDllCommon.Priv_GetAnnulusContourStartAngle(contour);
            _endAngle = VisionDllCommon.Priv_GetAnnulusContourEndAngle(contour);
        }

        
        internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = VisionDllCommon.Priv_CreateAnnulusContour(color, external, (int)Math.Round(_center.X), (int)Math.Round(_center.Y), (int)Math.Round(_innerRadius), (int)Math.Round(_outerRadius), _startAngle, _endAngle);
            Utilities.ThrowError(contour);
            return contour;
        }
        //==========================================================================================
        /// <summary> 
        /// Gets or sets  the center point of the annulus.
        /// </summary>
        /// <value>
        /// The value is an x and y-coordinate pair. The default value is (0,0).
        /// </value>
        /// <remarks>
        /// The following figure illustrates an annulus.
        /// <image src="annulus.gif"/>
        /// </remarks>

        public PointContour Center
        {
            get { return _center; }
            set {
                if (value == null) { throw new ArgumentNullException("value"); }
                if (_center.X == value.X && _center.Y == value.Y) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _center.PropertyChanging -= ChildPropertyChanging;
                _center.PropertyChanged -= ChildPropertyChanged;
                _center = value;
                _center.PropertyChanged += ChildPropertyChanged;
                _center.PropertyChanging += ChildPropertyChanging;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the internal radius of the annulus.
        /// </summary>
        /// <value>
        /// The internal radius of the annulus.
        /// The default value is 0.
        /// </value>
        /// <remarks>
        /// The following figure illustrates an annulus.
        /// <image src="annulus.gif"/>
        /// </remarks>

        public double InnerRadius
        {
            get { return _innerRadius; }
            set {
                if (_innerRadius == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _innerRadius = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the external radius of the annulus.
        /// </summary>
        /// <value>
        /// The external radius of the annulus.
        /// The default value is 0.
        /// </value>
        /// <remarks>
        /// The following figure illustrates an annulus.
        /// <image src="annulus.gif"/>
        /// </remarks>

        public double OuterRadius
        {
            get { return _outerRadius; }
            set {
                if (_outerRadius == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _outerRadius = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the start angle, in degrees, of the annulus.
        /// </summary>
        /// <value>
        /// The start angle, in degrees, of the annulus.
        /// The default value is 0.
        /// </value>
        /// <remarks>
        /// The following figure illustrates an annulus.
        /// <image src="annulus.gif"/>
        /// </remarks>

        public double StartAngle 
        {
            get { return _startAngle; }
            set {
                if (_startAngle == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _startAngle = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the end angle, in degrees, of the annulus.
        /// </summary>
        /// <value>
        /// The end angle, in degrees, of the annulus.
        /// The default value is 0.
        /// </value>
        /// <remarks>
        /// The following figure illustrates an annulus.
        /// <image src="annulus.gif"/>
        /// </remarks>

        public double EndAngle
        {
            get { return _endAngle; }
            set {
                if (_endAngle == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _endAngle = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>
/// <approved>True</approved>
        //==========================================================================================
        public override string ToString()
        {
            return "AnnulusContour: Center=" + _center + ", InnerRadius=" + _innerRadius + ", OuterRadius=" + _outerRadius + ", StartAngle=" + _startAngle + ", EndAngle=" + _endAngle;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// 	An <see cref="NationalInstruments.Vision.AnnulusContour" crefType="Unqualified"/> instance to compare to this instance.
        /// </returns>
/// <approved>True</approved>
        //==========================================================================================
        public bool Equals(AnnulusContour other)
        {
            return (other != null) && Object.Equals(_center, other._center) && _innerRadius == other._innerRadius && _outerRadius == other._outerRadius && _startAngle == other._startAngle && _endAngle == other._endAngle;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is instance of <see cref="NationalInstruments.Vision.AnnulusContour" crefType="Unqualified"/> and equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>
/// <approved>True</approved>
        //==========================================================================================
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            AnnulusContour other = (AnnulusContour)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
/// <approved>True</approved>
        //==========================================================================================
        public override int GetHashCode()
        {
            return _center.GetHashCode() ^ _innerRadius.GetHashCode() ^ _outerRadius.GetHashCode() ^ _startAngle.GetHashCode() ^ _endAngle.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines a general contour, either open or closed, that contains a collection of points.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public abstract class OpenClosedContour : Shape
    {
        internal ObservablePointsCollection _points;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OpenClosedContour" crefType="Unqualified"/> class.
        /// </summary>

        protected OpenClosedContour()
        {
            _points = new ObservablePointsCollection();
            _points.Changing += ChildPropertyChanging;
            _points.Changed += ChildPropertyChanged;
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OpenClosedContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="points">
        /// The points this <see cref="NationalInstruments.Vision.OpenClosedContour" crefType="Unqualified"/> will contain.
        /// </param>

        protected OpenClosedContour(IList<PointContour> points)
            : this()
        {
            foreach (PointContour point in points)
            {
                _points.Add(point);
            }
        }

void ChildPropertyChanging(object sender, CancelEventArgs e)
        {
            // If our child is changing, we are changing.
            OnPropertyChanging(e);
        }

        
        void ChildPropertyChanged(object sender, EventArgs e)
        {
            // If our child has changed, we have changed.
            OnPropertyChanged(e);
        }

        
        internal abstract IntPtr CreateContour(Rgb32Value color, bool external);

        
        internal abstract CVI_ViewerTool ViewerTool { get; }

internal override IntPtr GetVisionContour(Rgb32Value color, bool external)
        {
            IntPtr contour = CreateContour(color, external);
            Utilities.ThrowError(contour);
            CVI_Point[] points = GetCVIPoints();
            // Add the points to the contour
            Utilities.ThrowError(VisionDllCommon.Priv_SetContourPoints(contour, ViewerTool, points, points.Length));
            return contour;
        }

        
        internal override void SetFromVisionContour(IntPtr contour)
        {
            UInt32 numPoints = VisionDllCommon.Priv_GetNumberOfPoints(contour);
            Int32[] xVals = new Int32[numPoints];
            Int32[] yVals = new Int32[numPoints];
            VisionDllCommon.Priv_GetXData(contour, xVals, numPoints);
            VisionDllCommon.Priv_GetYData(contour, yVals, numPoints);
            _points.Clear();
            for (uint i = 0; i < numPoints; ++i)
            {
                PointContour toAdd = new PointContour(xVals[i], yVals[i]);
                toAdd.PropertyChanging += ChildPropertyChanging;
                toAdd.PropertyChanged += ChildPropertyChanged;
                _points.Add(toAdd);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Moves the contour horizontally or vertically.
        /// </summary>
        /// <param name="dx">
        /// Distance in pixels to move on the x-axis.
        /// </param>
        /// <param name="dy">
        /// Distance in pixels to move on the y-axis.
        /// </param>

        public override void Move(double dx, double dy)
        {
            foreach (PointContour p in _points)
            {
                p.Move(dx, dy);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the points that this OpenClosedContour contains.
        /// </summary>
        /// <value>
        /// </value>

        public Collection<PointContour> Points
        {
            get { return _points; }
        }

        
        internal CVI_Point[] GetCVIPoints()
        {
            CVI_Point[] points = new CVI_Point[_points.Count];
            for (int i = 0; i < _points.Count; ++i)
            {
                points[i] = new CVI_Point(_points[i]);
            }
            return points;
        }

        
        internal abstract string GetClassName();
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder(GetClassName());
            toReturn.Append(": Points=[");
            if (_points.Count > 0)
            {
                toReturn.Append(_points[0].ToString());
                toReturn.Append(", ...");
            }
            toReturn.Append("] (Count=");
            toReturn.Append(_points.Count);
            toReturn.Append(")");
            return toReturn.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the location and size of a closed contour, which is a series of connected points where the last point connects to the first.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public abstract class ClosedContour : OpenClosedContour
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ClosedContour" crefType="Unqualified"/> class.
        /// </summary>

        protected ClosedContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ClosedContour" crefType="Unqualified"/> class with the specified points.
        /// </summary>
        /// <param name="points">
        /// The points that make up the closed contour.
        /// </param>

        protected ClosedContour(IList<PointContour> points)
            : base(points)
        {
        }

internal override bool ChangePoint(double x, double y, int index)
        {
            if (index < _points.Count)
            {
                // This does not set off events, which is what we want.
                return _points[index].ChangePoint(x, y, 0);
            }
            else if (index == _points.Count)
            {
                // Since we're a closed contour, moving the last point is the same as moving the first.
                return _points[0].ChangePoint(x, y, 0);
            }
            return false;
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the location and size of an open contour, which is a series of connected points where the last point does not connect to the first.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public abstract class OpenContour : OpenClosedContour
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OpenContour" crefType="Unqualified"/> class.
        /// </summary>

        protected OpenContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OpenContour" crefType="Unqualified"/> class with the specified points.
        /// </summary>
        /// <param name="points">
        /// The points that make up the open contour.
        /// </param>

        protected OpenContour(IList<PointContour> points)
            : base(points)
        {
        }

internal override bool ChangePoint(double x, double y, int index)
        {
            if (index < _points.Count)
            {
                // This does not set off events, which is what we want.
                return _points[index].ChangePoint(x, y, 0);
            }
            return false;
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines a polygon.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PolygonContour : ClosedContour, IEquatable<PolygonContour>
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PolygonContour" crefType="Unqualified"/> class.
        /// </summary>

        public PolygonContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PolygonContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="points">
        /// The points this PolygonContour will contain.
        /// </param>

        public PolygonContour(IList<PointContour> points)
            : base(points)
        {
        }

        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source polygon.</summary>
        /// <returns>
        /// A new polygon with the same properties as the source polygon.</returns>

        public override Shape Clone()
        {
            PointContour[] points = new PointContour[_points.Count];
            for (int i = 0; i < points.Length; ++i) {
                points[i] = (PointContour)_points[i].Clone();
            }
            return new PolygonContour(points);
        }

internal override ContourType ContourType
        {
            get { return ContourType.Polygon; }
        }

        
        internal override IntPtr CreateContour(Rgb32Value color, bool external)
        {
            return VisionDllCommon.Priv_CreatePolygonContour(color, external);
        }

        
        internal override string GetClassName()
        {
         	return "PolygonContour";
        }

        
        internal override CVI_ViewerTool ViewerTool
        {
            get { return CVI_ViewerTool.Polygon; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A PolygonContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PolygonContour other)
        {
            if (other == null) return false;
            return Utilities.CollectionsEqual(_points, other._points);
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
            PolygonContour other = (PolygonContour)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.</summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (PointContour point in _points)
            {
                hashCode ^= point.GetHashCode();
            }
            return hashCode;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the points of a free-form region. This shape is similar to a polygon, but individual points are not draggable.</summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class FreehandRegionContour : ClosedContour, IEquatable<FreehandRegionContour>
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.FreehandRegionContour" crefType="Unqualified"/> class.
        /// </summary>

        public FreehandRegionContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.FreehandRegionContour" crefType="Unqualified"/> class with the specified points.
        /// </summary>
        /// <param name="points">
        /// The points that this FreehandRegionContour will contain.
        /// </param>

        public FreehandRegionContour(IList<PointContour> points)
            : base(points)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source freehand region.
        /// </summary>
        /// <returns>
        /// A new freehand region with the same properties as the source freehand region.</returns>

        public override Shape Clone()
        {
            PointContour[] points = new PointContour[_points.Count];
            for (int i = 0; i < points.Length; ++i) {
                points[i] = (PointContour)_points[i].Clone();
            }
            return new FreehandRegionContour(points);
        }

internal override ContourType ContourType
        {
            get { return ContourType.FreehandRegion; }
        }

        
        internal override IntPtr CreateContour(Rgb32Value color, bool external)
        {
            return VisionDllCommon.Priv_CreateFreeregionContour(color, external);
        }

        
        internal override string GetClassName()
        {
         	return "FreehandRegionContour";
        }

        
        internal override CVI_ViewerTool ViewerTool
        {
            get { return CVI_ViewerTool.ClosedFreehand; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(FreehandRegionContour other)
        {
            if (other == null) return false;
            return Utilities.CollectionsEqual(_points, other._points);
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
            FreehandRegionContour other = (FreehandRegionContour)obj;
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
            int hashCode = 0;
            foreach (PointContour point in _points)
            {
                hashCode ^= point.GetHashCode();
            }
            return hashCode;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Contains the points of a free-form line shape. This shape is similar to a polyline, but individual points can not be dragged.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class FreehandLineContour : OpenContour, IEquatable<FreehandLineContour>
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.FreehandLineContour" crefType="Unqualified"/> class.
        /// </summary>

        public FreehandLineContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.FreehandLineContour" crefType="Unqualified"/> class with the specified points.
        /// </summary>
        /// <param name="points">
        /// The points that this FreehandLineContour will contain.
        /// </param>

        public FreehandLineContour(IList<PointContour> points)
            : base(points)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source freehand line.
        /// </summary>
        /// <returns>
        /// A new freehand line with the same properties as the source freehand line.
        /// </returns>

        public override Shape Clone()
        {
            PointContour[] points = new PointContour[_points.Count];
            for (int i = 0; i < points.Length; ++i) {
                points[i] = (PointContour)_points[i].Clone();
            }
            return new FreehandLineContour(points);
        }

internal override ContourType ContourType
        {
            get { return ContourType.FreehandLine; }
        }

        
        internal override IntPtr CreateContour(Rgb32Value color, bool external)
        {
            return VisionDllCommon.Priv_CreateFreelineContour(color, external);
        }

        
        internal override string GetClassName()
        {
         	return "FreehandLineContour";
        }

        
        internal override CVI_ViewerTool ViewerTool
        {
            get { return CVI_ViewerTool.Freehand; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A FreehandLineContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// </returns>

        public bool Equals(FreehandLineContour other)
        {
            if (other == null) return false;
            return Utilities.CollectionsEqual(_points, other._points);
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
            FreehandLineContour other = (FreehandLineContour)obj;
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
            int hashCode = 0;
            foreach (PointContour point in _points)
            {
                hashCode ^= point.GetHashCode();
            }
            return hashCode;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines a polyline shape. This shape is similar to a polygon, but is not closed.</summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PolylineContour : OpenContour, IEquatable<PolylineContour>
    {
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PolylineContour" crefType="Unqualified"/> class.
        /// </summary>

        public PolylineContour() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PolylineContour" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="points">
        /// The points this PolygonContour will contain.
        /// </param>

        public PolylineContour(IList<PointContour> points)
            : base(points)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Creates a copy of the source polyline.
        /// </summary>
        /// <returns>
        /// A new polyline with the same properties as the source polyline.
        /// </returns>

        public override Shape Clone()
        {
            PointContour[] points = new PointContour[_points.Count];
            for (int i = 0; i < points.Length; ++i) {
                points[i] = (PointContour)_points[i].Clone();
            }
            return new PolylineContour(points);
        }

internal override ContourType ContourType
        {
            get { return ContourType.Polyline; }
        }

        
        internal override IntPtr CreateContour(Rgb32Value color, bool external)
        {
            return VisionDllCommon.Priv_CreateBrokenlineContour(color, external);
        }

        
        internal override string GetClassName()
        {
         	return "PolylineContour";
        }

        
        internal override CVI_ViewerTool ViewerTool
        {
            get { return CVI_ViewerTool.Polyline; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A PolylineContour instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="other"/> is a object that represents the same as the current; otherwise, <see langword="false"/>.</returns>

        public bool Equals(PolylineContour other)
        {
            if (other == null) return false;
            return Utilities.CollectionsEqual(_points, other._points);
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
            PolylineContour other = (PolylineContour)obj;
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
            int hashCode = 0;
            foreach (PointContour point in _points)
            {
                hashCode ^= point.GetHashCode();
            }
            return hashCode;
        }
    }
}
