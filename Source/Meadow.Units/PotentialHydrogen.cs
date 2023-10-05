using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units
{
    /// <summary>
    /// Represents potential hydrogen (ph)
    /// </summary>
    [Serializable]
    [ImmutableObject(true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct PotentialHydrogen :
        IComparable, IFormattable, IConvertible,
        IEquatable<double>, IComparable<double>
    {
        /// <summary>
        /// Creates a new `PotentialHydrogen` object.
        /// </summary>
        /// <param name="value">The Potential Hydrogen value.</param>
        /// <param name="type">Potential Hydrogen unit.</param>
        public PotentialHydrogen(double value, UnitType type = UnitType.pH)
        {
            pH = value;
        }

        /// <summary>
        /// Creates a new `PotentialHydrogen` object from an existing PotentialHydrogen object
        /// </summary>
        /// <param name="PotentialHydrogen"></param>
        public PotentialHydrogen(PotentialHydrogen PotentialHydrogen)
        {
            pH = PotentialHydrogen.pH;
        }

        /// <summary>
        /// The Potential Hydrogen expressed as pH.
        /// </summary>
        public double pH { get; private set; }
        /// <summary>
        /// The type of units available to describe the PotentialHydrogen.
        /// </summary>
        public enum UnitType
        {
            /// <summary>
            /// Potential Hydrogen (pH)
            /// </summary>
            pH
        }

        /// <summary>
        /// Compare to another PotentialHydrogen object
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (obj is null) { return false; }
            if (Equals(this, obj)) { return true; }
            return obj.GetType() == GetType() && Equals((PotentialHydrogen)obj);
        }

        /// <summary>
        /// Get hash of object
        /// </summary>
        /// <returns>int32 hash value</returns>
        [Pure] public override int GetHashCode() => pH.GetHashCode();

        // implicit conversions
        //[Pure] public static implicit operator PotentialHydrogen(ushort value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(short value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(uint value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(long value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(int value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(float value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(double value) => new PotentialHydrogen(value);
        //[Pure] public static implicit operator PotentialHydrogen(decimal value) => new PotentialHydrogen((double)value);

        // Comparison
        /// <summary>
        /// Compare to another PotentialHydrogen object
        /// </summary>
        /// <param name="other">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure] public bool Equals(PotentialHydrogen other) => pH == other.pH;

        /// <summary>
        /// Equals operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if equal</returns>
        [Pure] public static bool operator ==(PotentialHydrogen left, PotentialHydrogen right) => Equals(left.pH, right.pH);

        /// <summary>
        /// Not equals operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if not equal</returns>
        [Pure] public static bool operator !=(PotentialHydrogen left, PotentialHydrogen right) => !Equals(left.pH, right.pH);

        /// <summary>
        /// Compare to another PotentialHydrogen object
        /// </summary>
        /// <param name="other"></param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(PotentialHydrogen other) => Equals(pH, other.pH) ? 0 : pH.CompareTo(other.pH);

        /// <summary>
        /// Less than operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than right</returns>
        [Pure] public static bool operator <(PotentialHydrogen left, PotentialHydrogen right) => Comparer<double>.Default.Compare(left.pH, right.pH) < 0;

        /// <summary>
        /// Greater than operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than right</returns>
        [Pure] public static bool operator >(PotentialHydrogen left, PotentialHydrogen right) => Comparer<double>.Default.Compare(left.pH, right.pH) > 0;

        /// <summary>
        /// Less than or equal operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than or equal to right</returns>
        [Pure] public static bool operator <=(PotentialHydrogen left, PotentialHydrogen right) => Comparer<double>.Default.Compare(left.pH, right.pH) <= 0;

        /// <summary>
        /// Greater than or equal operator to compare two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than or equal to right</returns>
        [Pure] public static bool operator >=(PotentialHydrogen left, PotentialHydrogen right) => Comparer<double>.Default.Compare(left.pH, right.pH) >= 0;

        // Math
        /// <summary>
        /// Addition operator to add two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new PotentialHydrogen object with a value of left + right</returns>
        [Pure] public static PotentialHydrogen operator +(PotentialHydrogen left, PotentialHydrogen right) => new(left.pH + right.pH);

        /// <summary>
        /// Subtraction operator to subtract two PotentialHydrogen objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new PotentialHydrogen object with a value of left - right</returns>
        [Pure] public static PotentialHydrogen operator -(PotentialHydrogen left, PotentialHydrogen right) => new(left.pH - right.pH);

        /// <summary>
        /// Multiplication operator to multiply by a double
        /// </summary>
        /// <param name="value">object to multiply</param>
        /// <param name="operand">operand to multiply object</param>
        /// <returns>A new PotentialHydrogen object with a value of value multiplied by the operand</returns>
        [Pure] public static PotentialHydrogen operator *(PotentialHydrogen value, double operand) => new(value.pH * operand);

        /// <summary>
        /// Division operator to divide by a double
        /// </summary>
        /// <param name="value">object to be divided</param>
        /// <param name="operand">operand to divide object</param>
        /// <returns>A new PotentialHydrogen object with a value of value divided by the operand</returns>
        [Pure] public static PotentialHydrogen operator /(PotentialHydrogen value, double operand) => new(value.pH / operand);

        /// <summary>
        /// Returns the absolute length, that is, the length without regards to
        /// negative polarity
        /// </summary>
        /// <returns></returns>
        [Pure] public PotentialHydrogen Abs() { return new PotentialHydrogen(Math.Abs(this.pH)); }

        /// <summary>
        /// Get a string representation of the object
        /// </summary>
        /// <returns>A string representing the object</returns>
        [Pure] public override string ToString() => pH.ToString();

        /// <summary>
        /// Get a string representation of the object
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>A string representing the object</returns>
        [Pure] public string ToString(string format, IFormatProvider formatProvider) => pH.ToString(format, formatProvider);

        // IComparable
        /// <summary>
        /// Compare to another PotentialHydrogen object
        /// </summary>
        /// <param name="obj">The other PotentialHydrogen cast to object</param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(object obj) => pH.CompareTo(obj);

        /// <summary>
        /// Get type code of object
        /// </summary>
        /// <returns>The TypeCode</returns>
        [Pure] public TypeCode GetTypeCode() => pH.GetTypeCode();

        /// <summary>
        /// Covert to boolean
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>bool representation of the object</returns>
        [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)pH).ToBoolean(provider);

        /// <summary>
        /// Covert to byte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>byte representation of the object</returns>
        [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)pH).ToByte(provider);

        /// <summary>
        /// Covert to char
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>char representation of the object</returns>
        [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)pH).ToChar(provider);

        /// <summary>
        /// Covert to DateTime
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>DateTime representation of the object</returns>
        [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)pH).ToDateTime(provider);

        /// <summary>
        /// Covert to Decimal
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>Decimal representation of the object</returns>
        [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)pH).ToDecimal(provider);

        /// <summary>
        /// Covert to double
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>double representation of the object</returns>
        [Pure] public double ToDouble(IFormatProvider provider) => pH;

        /// <summary>
        /// Covert to in16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int16 representation of the object</returns>
        [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)pH).ToInt16(provider);

        /// <summary>
        /// Covert to int32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int32 representation of the object</returns>
        [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)pH).ToInt32(provider);

        /// <summary>
        /// Covert to int64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int64 representation of the object</returns>
        [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)pH).ToInt64(provider);

        /// <summary>
        /// Covert to sbyte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>sbyte representation of the object</returns>
        [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)pH).ToSByte(provider);

        /// <summary>
        /// Covert to float
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>float representation of the object</returns>
        [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)pH).ToSingle(provider);

        /// <summary>
        /// Covert to string
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>string representation of the object</returns>
        [Pure] public string ToString(IFormatProvider provider) => pH.ToString(provider);

        /// <summary>
        /// Covert to type
        /// </summary>
        /// <param name="conversionType">unit to convert</param>
        /// <param name="provider">format provider</param>
        /// <returns>type representation of the object</returns>
        [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)pH).ToType(conversionType, provider);

        /// <summary>
        /// Covert to uint16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint16 representation of the object</returns>
        [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)pH).ToUInt16(provider);

        /// <summary>
        /// Covert to uint32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint32 representation of the object</returns>
        [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)pH).ToUInt32(provider);

        /// <summary>
        /// Covert to uint64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint64 representation of the object</returns>
        [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)pH).ToUInt64(provider);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure]
        public int CompareTo(double? other)
        {
            return (other is null) ? -1 : (pH).CompareTo(other.Value);
        }

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double? other) => pH.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double other) => pH.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(double other) => pH.CompareTo(other);
    }
}