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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization;
using NationalInstruments.Vision.Internal;

namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>
    /// Defines a color in the RGB (Red, Green, Blue) color space.
    /// </summary>
    /// <remarks>
    /// </remarks>

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    [Serializable]
    [Editor(typeof(Rgb32ValueEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(Rgb32ValueConverter))]
    public struct Rgb32Value : IEquatable<Rgb32Value>
    {
        private byte _b;
        private byte _g;
        private byte _r;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Rgb32Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="red">
        /// </param>
        /// <param name="green">
        /// </param>
        /// <param name="blue">
        /// </param>

        public Rgb32Value(byte red, byte green, byte blue) : this (red, green, blue, 0)
        {}
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Rgb32Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="red">
        /// </param>
        /// <param name="green">
        /// </param>
        /// <param name="blue">
        /// </param>
        /// <param name="alpha">
        /// </param>

        public Rgb32Value(byte red, byte green, byte blue, byte alpha)
        {
            _b = blue;
            _g = green;
            _r = red;
            _alpha = alpha;
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Rgb32Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="color">
        /// The color to initialize this Rgb32Value to.</param>

        public Rgb32Value(Color color)
        {
            _b = color.B;
            _g = color.G;
            _r = color.R;
            // Microsoft's version of alpha is 0 means transparent, 0xFF means opaque
            // Our version of alpha is the opposite - 0 is opaque and 0xFF is transparent.
            _alpha = (byte)(0xFF - color.A);
        }
        //==========================================================================================
        /// <summary>
        /// Gets  the <see cref="NationalInstruments.Vision.Rgb32Value" crefType="Unqualified"/> as a Windows color.
        /// </summary>
        /// <value>
        /// 	<see cref="NationalInstruments.Vision.Rgb32Value" crefType="Unqualified"/> as a Windows color.
        /// </value>

        public Color Color
        {
            get
            {
                // Microsoft's version of alpha is 0 means transparent, 0xFF means opaque
                // Our version of alpha is the opposite - 0 is opaque and 0xFF is transparent.
                return Color.FromArgb((byte)(0xFF - _alpha), _r, _g, _b);
            }
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
            get { return _b; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the green value of the color.
        /// </summary>
        /// <value>
        /// The green value of the color.
        /// </value>

        public byte Green
        {
            get { return _g; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the red value of the color.
        /// </summary>
        /// <value>The red value of the color.
        /// </value>

        public byte Red
        {
            get { return _r; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// The alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An Rgb32Value instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Rgb32Value other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
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
            Rgb32Value other = (Rgb32Value)obj;
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
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are equal.</returns>

        public static bool operator ==(Rgb32Value val1, Rgb32Value val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(Rgb32Value val1, Rgb32Value val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.</summary>
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>

        public override int GetHashCode()
        {
            return _r.GetHashCode() ^ _g.GetHashCode() ^ _b.GetHashCode() ^ _alpha.GetHashCode();
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
            return "Rgb32Value: R=" + _r + ", G=" + _g + ", B=" + _b;
        }

        //==========================================================================================
        /// <summary>
        /// A color that represents transparency.
        /// </summary>

        public static readonly Rgb32Value TransparentColor = new Rgb32Value(0, 0, 0, 1);
        //==========================================================================================
        /// <summary>
        /// A color that represents red.
        /// </summary>

        public static readonly Rgb32Value RedColor = new Rgb32Value(255, 0, 0);
        //==========================================================================================
        /// <summary>
        /// A color that represents blue.
        /// </summary>

        public static readonly Rgb32Value BlueColor = new Rgb32Value(0, 0, 255);
        //==========================================================================================
        /// <summary>
        /// A color that represents green.
        /// </summary>

        public static readonly Rgb32Value GreenColor = new Rgb32Value(0, 255, 0);
        //==========================================================================================
        /// <summary>
        /// A color that represents yellow.
        /// </summary>

        public static readonly Rgb32Value YellowColor = new Rgb32Value(255, 255, 0);
        //==========================================================================================
        /// <summary>
        /// A color that represents white.
        /// </summary>

        public static readonly Rgb32Value WhiteColor = new Rgb32Value(255, 255, 255);
        //==========================================================================================
        /// <summary>
        /// A color that represents black.
        /// </summary>

        public static readonly Rgb32Value BlackColor = new Rgb32Value(0, 0, 0);
    }

    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Rgb32ValueEditor : ColorEditor
    {

        
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Take the value (which should be an Rgb32Value) and convert it to a color.
            if (value is Rgb32Value)
            {
                value = ((Rgb32Value)value).Color;
            }
            // Call the base method.
            object toReturn = base.EditValue(context, provider, value);
            // Return an Rgb32Value.
            if (toReturn is Color) {
                toReturn = new Rgb32Value((Color)toReturn);
            }
            return toReturn;
        }

        
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return base.GetEditStyle(context);
        }

        
        public override void PaintValue(PaintValueEventArgs e)
        {
            if (e != null)
            {
                PaintValueEventArgs newArgs = new PaintValueEventArgs(e.Context, ((Rgb32Value)e.Value).Color, e.Graphics, e.Bounds);
                base.PaintValue(newArgs);
            }
        }

        
        public override string ToString()
        {
            return "Rgb32ValueEditor";
        }

        
        public bool Equals(Rgb32ValueEditor other)
        {
            return other != null;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Rgb32ValueEditor other = (Rgb32ValueEditor)obj;
            return Equals(other);
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Rgb32ValueConverter : System.ComponentModel.TypeConverter
    {

        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) && value != null)
            {
                Rgb32Value rgb32 = (Rgb32Value)value;
                System.Reflection.ConstructorInfo ctor = typeof(Rgb32Value).GetConstructor(new Type[] { typeof(byte), typeof(byte), typeof(byte), typeof(byte) });
                if (ctor != null)
                {
                    return new InstanceDescriptor(ctor, new object[] { rgb32.Red, rgb32.Green, rgb32.Blue, rgb32.Alpha });
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        
        public override string ToString()
        {
            return "Rgb32ValueConverter";
        }

        
        public bool Equals(Rgb32ValueConverter other)
        {
            return other != null;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Rgb32ValueConverter other = (Rgb32ValueConverter)obj;
            return Equals(other);
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines a color in the HSL (Hue, Saturation, and Luminance) color space.
    /// </summary>
    /// <remarks>
    /// </remarks>

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    [Serializable]
    public struct Hsl32Value : IEquatable<Hsl32Value>
    {
        private byte _l;
        private byte _s;
        private byte _h;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Hsl32Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="luminance">
        /// </param>

        public Hsl32Value(byte hue, byte saturation, byte luminance)
            : this(hue, saturation, luminance, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Hsl32Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="luminance">
        /// </param>
        /// <param name="alpha">
        /// </param>

        public Hsl32Value(byte hue, byte saturation, byte luminance, byte alpha)
        {
            _l = luminance;
            _s = saturation;
            _h = hue;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color luminance. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Luminance
        {
            get { return _l; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color saturation. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Saturation
        {
            get { return _s; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color hue. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Hue
        {
            get { return _h; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction.
        /// </summary>
        /// <value>
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An Hsl32Value instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Hsl32Value other)
        {
            return Hue == other.Hue && Saturation == other.Saturation && Luminance == other.Luminance && Alpha == other.Alpha;
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
            Hsl32Value other = (Hsl32Value)obj;
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
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are equal.</returns>

        public static bool operator ==(Hsl32Value val1, Hsl32Value val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(Hsl32Value val1, Hsl32Value val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.</summary>
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>

        public override int GetHashCode()
        {
            return _h.GetHashCode() ^ _s.GetHashCode() ^ _l.GetHashCode() ^ _alpha.GetHashCode();
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
            return "Hsl32Value: H=" + _h + ", S=" + _s + ", L=" + _l;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a complex value.
    /// </summary>
    /// <remarks>
    /// </remarks>

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    [Serializable]
    public struct Complex : IEquatable<Complex>
    {
        private float _r;
        private float _i;
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Complex" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="real">
        /// The real part of the value.
        /// </param>
        /// <param name="imaginary">
        /// The imaginary part of the value.
        /// </param>

        public Complex(float real, float imaginary)
        {
            _r = real;
            _i = imaginary;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the real part of the value.
        /// </summary>
        /// <value>
        /// </value>

        public float Real
        {
            get { return _r; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the imaginary part of the value.
        /// </summary>
        /// <value>
        /// </value>

        public float Imaginary
        {
            get { return _i; }
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
            return "(" + _r + ", " + _i + ")";
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A Complex instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Complex other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
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
            Complex other = (Complex)obj;
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
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator ==(Complex val1, Complex val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are not equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator !=(Complex val1, Complex val2)
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
            return _r.GetHashCode() ^ _i.GetHashCode();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines color in the RGB (Red, Green, Blue) color space where each channel has 16 bits.</summary>
    /// <remarks>
    /// </remarks>

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    [Serializable]
    public struct RgbU64Value : IEquatable<RgbU64Value>
    {
        private UInt16 _b;
        private UInt16 _g;
        private UInt16 _r;
        private UInt16 _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RgbU64Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="red">
        /// </param>
        /// <param name="green">
        /// </param>
        /// <param name="blue">
        /// </param>

        [CLSCompliant(false)]
        public RgbU64Value(UInt16 red, UInt16 green, UInt16 blue)
            : this(red, green, blue, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.RgbU64Value" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="red">
        /// </param>
        /// <param name="green">
        /// </param>
        /// <param name="blue">
        /// </param>
        /// <param name="alpha">
        /// </param>

        [CLSCompliant(false)]
        public RgbU64Value(UInt16 red, UInt16 green, UInt16 blue, UInt16 alpha)
        {
            _b = blue;
            _g = green;
            _r = red;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the blue value of the color.
        /// </summary>
        /// <value>
        /// The blue value of the color.
        /// </value>

        [CLSCompliant(false)]
        public UInt16 Blue
        {
            get { return _b; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the green value of the color.
        /// </summary>
        /// <value>
        /// The green value of the color.
        /// </value>

        [CLSCompliant(false)]
        public UInt16 Green
        {
            get { return _g; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the red value of the color.
        /// </summary>
        /// <value>
        /// The red value of the color.
        /// </value>

        [CLSCompliant(false)]
        public UInt16 Red
        {
            get { return _r; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// The alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </value>

        [CLSCompliant(false)]
        public UInt16 Alpha
        {
            get { return _alpha; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An RgbU64Value instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(RgbU64Value other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
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
            RgbU64Value other = (RgbU64Value)obj;
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
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are equal.</returns>

        public static bool operator ==(RgbU64Value val1, RgbU64Value val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(RgbU64Value val1, RgbU64Value val2)
        {
            return !(val1.Equals(val2));
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
            return "RgbU64Value: R=" + _r + ", G=" + _g + ", B=" + _b;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.</summary>
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>

        public override int GetHashCode()
        {
            return _r.GetHashCode() ^ _g.GetHashCode() ^ _b.GetHashCode() ^ _alpha.GetHashCode();
        }
    }

    //==============================================================================================
    /// <summary>
    /// A value representing a pixel in an image.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public struct PixelValue : IEquatable<PixelValue>
    {

        
        internal enum Type
        {

            
            Grayscale,

            
            Rgb32,

            
            RgbU64,

            
            Hsl32,

            
            Complex
        }
        private Type _type;
        private float _grayscale;
        private Rgb32Value _rgb32;
        private RgbU64Value _rgbU64;
        private Hsl32Value _hsl32;
        private Complex _complex;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue" crefType="Unqualified"/> class  for images of type U8, I16, U16, and Single.
        /// </summary>
        /// <param name="value">
        /// The value of this pixel.
        /// </param>

        public PixelValue(float value) : this()
        {
            _grayscale = value;
            _type = Type.Grayscale;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue" crefType="Unqualified"/> class for images of type Rgb32Value.
        /// </summary>
        /// <param name="value">
        /// The value of this pixel.
        /// </param>

        public PixelValue(Rgb32Value value) : this()
        {
            _rgb32 = value;
            _type = Type.Rgb32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue" crefType="Unqualified"/> class for images of type RgbU64Value.
        /// </summary>
        /// <param name="value">
        /// The value of this pixel.
        /// </param>

        public PixelValue(RgbU64Value value) : this()
        {
            _rgbU64 = value;
            _type = Type.RgbU64;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue" crefType="Unqualified"/> class for images of type Hsl32Value.
        /// </summary>
        /// <param name="value">
        /// The value of this pixel.
        /// </param>

        public PixelValue(Hsl32Value value) : this()
        {
            _hsl32 = value;
            _type = Type.Hsl32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue" crefType="Unqualified"/> class for images of type Complex. 
        /// </summary>
        /// <param name="value">
        /// The value of this pixel.
        /// </param>

        public PixelValue(Complex value) : this()
        {
            _complex = value;
            _type = Type.Complex;
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="imageType">
        /// </param>

        internal PixelValue(ImageType imageType)
            : this()
        {
            switch (imageType)
            {
                case ImageType.U8:
                case ImageType.I16:
                case ImageType.U16:
                case ImageType.Single:
                    _grayscale = 0.0F;
                    _type = Type.Grayscale;
                    break;
                case ImageType.Rgb32:
                    _rgb32 = new Rgb32Value();
                    _type = Type.Rgb32;
                    break;
                case ImageType.RgbU64:
                    _rgbU64 = new RgbU64Value();
                    _type = Type.RgbU64;
                    break;
                case ImageType.Hsl32:
                    _hsl32 = new Hsl32Value();
                    _type = Type.Hsl32;
                    break;
                case ImageType.Complex:
                    _complex = new Complex();
                    _type = Type.Complex;
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    break;
            }
        }

internal PixelValue(CVI_PixValue pixValue, ImageType imageType)
            : this()
        {
            switch (imageType)
            {
                case ImageType.U8:
                case ImageType.I16:
                case ImageType.U16:
                case ImageType.Single:
                    _grayscale = pixValue.Grayscale;
                    _type = Type.Grayscale;
                    break;
                case ImageType.Rgb32:
                    _rgb32 = pixValue.Rgb;
                    _type = Type.Rgb32;
                    break;
                case ImageType.RgbU64:
                    _rgbU64 = pixValue.Rgbu64;
                    _type = Type.RgbU64;
                    break;
                case ImageType.Hsl32:
                    _hsl32 = pixValue.Hsl;
                    _type = Type.Hsl32;
                    break;
                case ImageType.Complex:
                    _complex = pixValue.Complex;
                    _type = Type.Complex;
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    break;
            }

        }

private void CheckType(Type requiredType)
        {
            if (_type != requiredType)
            {
                throw new VisionException(ErrorCode.IncompType);
            }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// This property can only be used with images of type U8, I16, U16, and Single.
        /// </remarks>

        public float Grayscale
        {
            get { CheckType(Type.Grayscale); return _grayscale; }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// This property can only be used with images of type Rgb32.
        /// </remarks>

        public Rgb32Value Rgb32
        {
            get { CheckType(Type.Rgb32); return _rgb32; }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// This property can only be used with images of type RgbU64.
        /// </remarks>

        public RgbU64Value RgbU64
        {
            get { CheckType(Type.RgbU64); return _rgbU64; }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// This property can only be used with images of type Hsl32.
        /// </remarks>

        public Hsl32Value Hsl32
        {
            get { CheckType(Type.Hsl32); return _hsl32; }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>

        public Complex Complex
        {
            get { CheckType(Type.Complex); return _complex; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A PixelValue instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PixelValue other)
        {
            if (_type != other._type) return false;
            switch (_type)
            {
                case Type.Grayscale:
                    return this._grayscale == other._grayscale;
                case Type.Rgb32:
                    return this._rgb32 == other._rgb32;
                case Type.RgbU64:
                    return this._rgbU64 == other._rgbU64;
                case Type.Hsl32:
                    return this._hsl32 == other._hsl32;
                case Type.Complex:
                    return this._complex == other._complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return false;
            }
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
            PixelValue other = (PixelValue)obj;
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
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are equal.</returns>

        public static bool operator ==(PixelValue val1, PixelValue val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(PixelValue val1, PixelValue val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>

        public override int GetHashCode()
        {
            return _type.GetHashCode() ^ _grayscale.GetHashCode() ^ _rgb32.GetHashCode() ^ _rgbU64.GetHashCode() ^ _complex.GetHashCode() ^ _hsl32.GetHashCode();
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
            string toReturn = "PixelValue: ";
            switch (_type)
            {
                case Type.Grayscale:
                    return toReturn + this._grayscale;
                case Type.Rgb32:
                    return toReturn + this._rgb32;
                case Type.RgbU64:
                    return toReturn + this._rgbU64;
                case Type.Hsl32:
                    return toReturn + this._hsl32;
                case Type.Complex:
                    return toReturn + this._complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return toReturn;
            }
        }

internal Type PixelType {
            get { return _type; }
        }

internal CVI_PixValue CVI_PixValue {
            get
            {
                CVI_PixValue toReturn = new CVI_PixValue();
                switch (_type)
                {
                    case Type.Grayscale:
                        toReturn.Grayscale = Grayscale;
                        break;
                    case Type.Rgb32:
                        toReturn.Rgb = Rgb32;
                        break;
                    case Type.RgbU64:
                        toReturn.Rgbu64 = RgbU64;
                        break;
                    case Type.Hsl32:
                        toReturn.Hsl = Hsl32;
                        break;
                    case Type.Complex:
                        toReturn.Complex = Complex;
                        break;
                    default:
                        Debug.Fail("Unknown image type!");
                        break;
                }
                return toReturn;
            }
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines an array of pixel values in an image.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PixelValue1D : IEquatable<PixelValue1D>
    {
        private ImageType _type;
        private byte[] _u8;
        private UInt16[] _u16;
        private Int16[] _i16;
        private float[] _single;
        private Rgb32Value[] _rgb32;
        private RgbU64Value[] _rgbU64;
        private Hsl32Value[] _hsl32;
        private Complex[] _complex;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class  for images of type U8.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(byte[] value)
        {
            _u8 = value;
            _type = ImageType.U8;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type U16.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        [CLSCompliant(false)]
        public PixelValue1D(UInt16[] value)
        {
            _u16 = value;
            _type = ImageType.U16;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type I16.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(Int16[] value)
        {
            _i16 = value;
            _type = ImageType.I16;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type Single.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(float[] value)
        {
            _single = value;
            _type = ImageType.Single;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type Rgb32.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(Rgb32Value[] value)
        {
            _rgb32 = value;
            _type = ImageType.Rgb32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type RgbU64.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(RgbU64Value[] value)
        {
            _rgbU64 = value;
            _type = ImageType.RgbU64;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type Hsl32.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(Hsl32Value[] value)
        {
            _hsl32 = value;
            _type = ImageType.Hsl32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue1D" crefType="Unqualified"/> class for images of type Complex.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue1D(Complex[] value)
        {
            _complex = value;
            _type = ImageType.Complex;
        }

internal void CheckType(ImageType requiredType)
        {
            if (_type != requiredType)
            {
                throw new VisionException(ErrorCode.IncompType);
            }
        }

internal System.Array GetArray()
        {
            switch (_type)
            {
                case ImageType.U8:
                    return _u8;
                case ImageType.I16:
                    return _i16;
                case ImageType.U16:
                    return _u16;
                case ImageType.Single:
                    return _single;
                case ImageType.Rgb32:
                    return _rgb32;
                case ImageType.RgbU64:
                    return _rgbU64;
                case ImageType.Hsl32:
                    return _hsl32;
                case ImageType.Complex:
                    return _complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return null;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type U8.
        /// </summary>
        /// <value>
        /// The pixel values for images of type U8.
        /// </value>

        public byte[] U8
        {
            get { CheckType(ImageType.U8); return _u8; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type I16.
        /// </summary>
        /// <value>
        /// The pixel values for images of type I16.
        /// </value>

        public Int16[] I16
        {
            get { CheckType(ImageType.I16); return _i16; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type U16.
        /// </summary>
        /// <value>
        /// The pixel values for images of type U16.
        /// </value>

        [CLSCompliant(false)]
        public UInt16[] U16
        {
            get { CheckType(ImageType.U16); return _u16; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Single.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Single.
        /// </value>

        public float[] Single
        {
            get { CheckType(ImageType.Single); return _single; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Rgb32.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Rgb32.
        /// </value>

        public Rgb32Value[] Rgb32
        {
            get { CheckType(ImageType.Rgb32); return _rgb32; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type RgbU64.
        /// </summary>
        /// <value>
        /// The pixel values for images of type RgbU64.
        /// </value>

        public RgbU64Value[] RgbU64
        {
            get { CheckType(ImageType.RgbU64); return _rgbU64; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Hsl32.</summary>
        /// <value>
        /// The pixel values for images of type Hsl32.
        /// </value>

        public Hsl32Value[] Hsl32
        {
            get { CheckType(ImageType.Hsl32); return _hsl32; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Complex.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Complex.
        /// </value>

        public Complex[] Complex
        {
            get { CheckType(ImageType.Complex); return _complex; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A PixelValue1D instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PixelValue1D other)
        {
            if (other == null) return false;
            if (_type != other._type) return false;
            switch (_type)
            {
                case ImageType.U8:
                    return Utilities.ArraysEqual(this._u8, other._u8);
                case ImageType.I16:
                    return Utilities.ArraysEqual(this._i16, other._i16);
                case ImageType.U16:
                    return Utilities.ArraysEqual(this._u16, other._u16);
                case ImageType.Single:
                    return Utilities.ArraysEqual(this._single, other._single);
                case ImageType.Rgb32:
                    return Utilities.ArraysEqual(this._rgb32, other._rgb32);
                case ImageType.RgbU64:
                    return Utilities.ArraysEqual(this._rgbU64, other._rgbU64);
                case ImageType.Hsl32:
                    return Utilities.ArraysEqual(this._hsl32, other._hsl32);
                case ImageType.Complex:
                    return Utilities.ArraysEqual(this._complex, other._complex);
                default:
                    Debug.Fail("Unknown image type!");
                    return false;
            }
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
            PixelValue1D other = (PixelValue1D)obj;
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
            return _type.GetHashCode() ^ _u8.GetHashCode() ^ _u16.GetHashCode() ^ _i16.GetHashCode() ^ _single.GetHashCode() ^ _rgb32.GetHashCode() ^ _rgbU64.GetHashCode() ^ _complex.GetHashCode() ^ _hsl32.GetHashCode();
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
            string toReturn = "PixelValue1D: ";
            switch (_type)
            {
                case ImageType.U8:
                    return toReturn + this._u8;
                case ImageType.I16:
                    return toReturn + this._i16;
                case ImageType.U16:
                    return toReturn + this._u16;
                case ImageType.Single:
                    return toReturn + this._single;
                case ImageType.Rgb32:
                    return toReturn + this._rgb32;
                case ImageType.RgbU64:
                    return toReturn + this._rgbU64;
                case ImageType.Hsl32:
                    return toReturn + this._hsl32;
                case ImageType.Complex:
                    return toReturn + this._complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return toReturn;
            }
        }

internal ImageType PixelType {
            get { return _type; }
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines a 2D array of pixel values in an image.</summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PixelValue2D : IEquatable<PixelValue2D>
    {
        private ImageType _type;
        private byte[,] _u8;
        private UInt16[,] _u16;
        private Int16[,] _i16;
        private float[,] _single;
        private Rgb32Value[,] _rgb32;
        private RgbU64Value[,] _rgbU64;
        private Hsl32Value[,] _hsl32;
        private Complex[,] _complex;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type U8.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(byte[,] value)
        {
            _u8 = value;
            _type = ImageType.U8;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type U16.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        [CLSCompliant(false)]
        public PixelValue2D(UInt16[,] value)
        {
            _u16 = value;
            _type = ImageType.U16;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type I16.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(Int16[,] value)
        {
            _i16 = value;
            _type = ImageType.I16;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type Single.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(float[,] value)
        {
            _single = value;
            _type = ImageType.Single;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type Rgb32.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(Rgb32Value[,] value)
        {
            _rgb32 = value;
            _type = ImageType.Rgb32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type RgbU64.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(RgbU64Value[,] value)
        {
            _rgbU64 = value;
            _type = ImageType.RgbU64;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type Hsl32.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(Hsl32Value[,] value)
        {
            _hsl32 = value;
            _type = ImageType.Hsl32;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.PixelValue2D" crefType="Unqualified"/> class for images of type Complex.
        /// </summary>
        /// <param name="value">
        /// The value of these pixels.
        /// </param>

        public PixelValue2D(Complex[,] value)
        {
            _complex = value;
            _type = ImageType.Complex;
        }

internal void CheckType(ImageType requiredType)
        {
            if (_type != requiredType)
            {
                throw new VisionException(ErrorCode.IncompType);
            }
        }

internal System.Array GetArray()
        {
            switch (_type)
            {
                case ImageType.U8:
                    return _u8;
                case ImageType.I16:
                    return _i16;
                case ImageType.U16:
                    return _u16;
                case ImageType.Single:
                    return _single;
                case ImageType.Rgb32:
                    return _rgb32;
                case ImageType.RgbU64:
                    return _rgbU64;
                case ImageType.Hsl32:
                    return _hsl32;
                case ImageType.Complex:
                    return _complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return null;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type U8.
        /// </summary>
        /// <value>
        /// The pixel values for images of type U8.
        /// </value>

        public byte[,] U8
        {
            get { CheckType(ImageType.U8); return _u8; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type I16.
        /// </summary>
        /// <value>
        /// The pixel values for images of type I16.
        /// </value>

        public Int16[,] I16
        {
            get { CheckType(ImageType.I16); return _i16; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type U16.
        /// </summary>
        /// <value>
        /// The pixel values for images of type U16.
        /// </value>

        [CLSCompliant(false)]
        public UInt16[,] U16
        {
            get { CheckType(ImageType.U16); return _u16; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Single.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Single.
        /// </value>

        public float[,] Single
        {
            get { CheckType(ImageType.Single); return _single; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Rgb32.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Rgb32.
        /// </value>

        public Rgb32Value[,] Rgb32
        {
            get { CheckType(ImageType.Rgb32); return _rgb32; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type RgbU64.
        /// </summary>
        /// <value>
        /// The pixel values for images of type RgbU64.
        /// </value>

        public RgbU64Value[,] RgbU64
        {
            get { CheckType(ImageType.RgbU64); return _rgbU64; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Hsl32.</summary>
        /// <value>
        /// The pixel values for images of type Hsl32.
        /// </value>

        public Hsl32Value[,] Hsl32
        {
            get { CheckType(ImageType.Hsl32); return _hsl32; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the pixel values for images of type Complex.
        /// </summary>
        /// <value>
        /// The pixel values for images of type Complex.
        /// </value>

        public Complex[,] Complex
        {
            get { CheckType(ImageType.Complex); return _complex; }
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

        public bool Equals(PixelValue2D other)
        {
            if (other == null) return false;
            if (_type != other._type) return false;
            switch (_type)
            {
                case ImageType.U8:
                    return Utilities.ArraysEqual(this._u8, other._u8);
                case ImageType.I16:
                    return Utilities.ArraysEqual(this._i16, other._i16);
                case ImageType.U16:
                    return Utilities.ArraysEqual(this._u16, other._u16);
                case ImageType.Single:
                    return Utilities.ArraysEqual(this._single, other._single);
                case ImageType.Rgb32:
                    return Utilities.ArraysEqual(this._rgb32, other._rgb32);
                case ImageType.RgbU64:
                    return Utilities.ArraysEqual(this._rgbU64, other._rgbU64);
                case ImageType.Hsl32:
                    return Utilities.ArraysEqual(this._hsl32, other._hsl32);
                case ImageType.Complex:
                    return Utilities.ArraysEqual(this._complex, other._complex);
                default:
                    Debug.Fail("Unknown image type!");
                    return false;
            }
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
            PixelValue2D other = (PixelValue2D)obj;
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
            return _type.GetHashCode() ^ _u8.GetHashCode() ^ _u16.GetHashCode() ^ _i16.GetHashCode() ^ _single.GetHashCode() ^ _rgb32.GetHashCode() ^ _rgbU64.GetHashCode() ^ _complex.GetHashCode() ^ _hsl32.GetHashCode();
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
            string toReturn = "PixelValue2D: ";
            switch (_type)
            {
                case ImageType.U8:
                    return toReturn + this._u8;
                case ImageType.I16:
                    return toReturn + this._i16;
                case ImageType.U16:
                    return toReturn + this._u16;
                case ImageType.Single:
                    return toReturn + this._single;
                case ImageType.Rgb32:
                    return toReturn + this._rgb32;
                case ImageType.RgbU64:
                    return toReturn + this._rgbU64;
                case ImageType.Hsl32:
                    return toReturn + this._hsl32;
                case ImageType.Complex:
                    return toReturn + this._complex;
                default:
                    Debug.Fail("Unknown image type!");
                    return toReturn;
            }
        }

internal ImageType PixelType
        {
            get { return _type; }
        }
    }

}