using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units
{
    /// <summary>
    /// Represents Turbidity (NTU)
    /// </summary>
    [Serializable]
    [ImmutableObject(true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct Turbidity :
        IComparable, IFormattable, IConvertible,
        IEquatable<double>, IComparable<double>
    {
        /// <summary>
        /// Creates a new `Turbidity` object.
        /// </summary>
        /// <param name="value">The Turbidity value.</param>
        /// <param name="type">Turbidity unit.</param>
        public Turbidity(double value, UnitType type = UnitType.NTU)
        {
            if(value < 0) throw new ArgumentOutOfRangeException($"Turbidity cannot be less than 0");
            NTU = value;
        }

        /// <summary>
        /// Creates a new `Turbidity` object from an existing Turbidity object
        /// </summary>
        /// <param name="Turbidity"></param>
        public Turbidity(Turbidity Turbidity)
        {
            NTU = Turbidity.NTU;
        }

        /// <summary>
        /// The Turbidity expressed as NeNTUelometric Turbidity Units (NTU)
        /// </summary>
        public double NTU { get; private set; }
        /// <summary>
        /// The type of units available to describe the Turbidity.
        /// </summary>
        public enum UnitType
        {
            /// <summary>
            /// Turbidity (NTU)
            /// </summary>
            NTU
        }

        /// <summary>
        /// Compare to another Turbidity object
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (obj is null) { return false; }
            if (Equals(this, obj)) { return true; }
            return obj.GetType() == GetType() && Equals((Turbidity)obj);
        }

        /// <summary>
        /// Get hash of object
        /// </summary>
        /// <returns>int32 hash value</returns>
        [Pure] public override int GetHashCode() => NTU.GetHashCode();

        // implicit conversions
        //[Pure] public static implicit operator Turbidity(ushort value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(short value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(uint value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(long value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(int value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(float value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(double value) => new Turbidity(value);
        //[Pure] public static implicit operator Turbidity(decimal value) => new Turbidity((double)value);

        // Comparison
        /// <summary>
        /// Compare to another Turbidity object
        /// </summary>
        /// <param name="other">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure] public bool Equals(Turbidity other) => NTU == other.NTU;

        /// <summary>
        /// Equals operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if equal</returns>
        [Pure] public static bool operator ==(Turbidity left, Turbidity right) => Equals(left.NTU, right.NTU);

        /// <summary>
        /// Not equals operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if not equal</returns>
        [Pure] public static bool operator !=(Turbidity left, Turbidity right) => !Equals(left.NTU, right.NTU);

        /// <summary>
        /// Compare to another Turbidity object
        /// </summary>
        /// <param name="other"></param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(Turbidity other) => Equals(NTU, other.NTU) ? 0 : NTU.CompareTo(other.NTU);

        /// <summary>
        /// Less than operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than right</returns>
        [Pure] public static bool operator <(Turbidity left, Turbidity right) => Comparer<double>.Default.Compare(left.NTU, right.NTU) < 0;

        /// <summary>
        /// Greater than operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than right</returns>
        [Pure] public static bool operator >(Turbidity left, Turbidity right) => Comparer<double>.Default.Compare(left.NTU, right.NTU) > 0;

        /// <summary>
        /// Less than or equal operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than or equal to right</returns>
        [Pure] public static bool operator <=(Turbidity left, Turbidity right) => Comparer<double>.Default.Compare(left.NTU, right.NTU) <= 0;

        /// <summary>
        /// Greater than or equal operator to compare two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than or equal to right</returns>
        [Pure] public static bool operator >=(Turbidity left, Turbidity right) => Comparer<double>.Default.Compare(left.NTU, right.NTU) >= 0;

        // Math
        /// <summary>
        /// Addition operator to add two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new Turbidity object with a value of left + right</returns>
        [Pure] public static Turbidity operator +(Turbidity left, Turbidity right) => new(left.NTU + right.NTU);

        /// <summary>
        /// Subtraction operator to subtract two Turbidity objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new Turbidity object with a value of left - right</returns>
        [Pure] public static Turbidity operator -(Turbidity left, Turbidity right) => new(left.NTU - right.NTU);

        /// <summary>
        /// Multiplication operator to multiply by a double
        /// </summary>
        /// <param name="value">object to multiply</param>
        /// <param name="operand">operand to multiply object</param>
        /// <returns>A new Turbidity object with a value of value multiplied by the operand</returns>
        [Pure] public static Turbidity operator *(Turbidity value, double operand) => new(value.NTU * operand);

        /// <summary>
        /// Division operator to divide by a double
        /// </summary>
        /// <param name="value">object to be divided</param>
        /// <param name="operand">operand to divide object</param>
        /// <returns>A new Turbidity object with a value of value divided by the operand</returns>
        [Pure] public static Turbidity operator /(Turbidity value, double operand) => new(value.NTU / operand);

		/// <summary>
		/// Returns the absolute value of the <see cref="Turbidity"/>
		/// </summary>
		/// <returns></returns>
		[Pure] public Turbidity Abs() { return new Turbidity(Math.Abs(this.NTU)); }

        /// <summary>
        /// Get a string representation of the object
        /// </summary>
        /// <returns>A string representing the object</returns>
        [Pure] public override string ToString() => NTU.ToString();

        /// <summary>
        /// Get a string representation of the object
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>A string representing the object</returns>
        [Pure] public string ToString(string format, IFormatProvider formatProvider) => NTU.ToString(format, formatProvider);

        // IComparable
        /// <summary>
        /// Compare to another Turbidity object
        /// </summary>
        /// <param name="obj">The other Turbidity cast to object</param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(object obj) => NTU.CompareTo(obj);

        /// <summary>
        /// Get type code of object
        /// </summary>
        /// <returns>The TypeCode</returns>
        [Pure] public TypeCode GetTypeCode() => NTU.GetTypeCode();

        /// <summary>
        /// Convert to boolean
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>bool representation of the object</returns>
        [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)NTU).ToBoolean(provider);

        /// <summary>
        /// Convert to byte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>byte representation of the object</returns>
        [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)NTU).ToByte(provider);

        /// <summary>
        /// Convert to char
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>char representation of the object</returns>
        [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)NTU).ToChar(provider);

        /// <summary>
        /// Convert to DateTime
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>DateTime representation of the object</returns>
        [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)NTU).ToDateTime(provider);

        /// <summary>
        /// Convert to Decimal
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>Decimal representation of the object</returns>
        [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)NTU).ToDecimal(provider);

        /// <summary>
        /// Convert to double
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>double representation of the object</returns>
        [Pure] public double ToDouble(IFormatProvider provider) => NTU;

        /// <summary>
        /// Convert to in16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int16 representation of the object</returns>
        [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)NTU).ToInt16(provider);

        /// <summary>
        /// Convert to int32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int32 representation of the object</returns>
        [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)NTU).ToInt32(provider);

        /// <summary>
        /// Convert to int64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int64 representation of the object</returns>
        [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)NTU).ToInt64(provider);

        /// <summary>
        /// Convert to sbyte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>sbyte representation of the object</returns>
        [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)NTU).ToSByte(provider);

        /// <summary>
        /// Convert to float
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>float representation of the object</returns>
        [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)NTU).ToSingle(provider);

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>string representation of the object</returns>
        [Pure] public string ToString(IFormatProvider provider) => NTU.ToString(provider);

        /// <summary>
        /// Convert to type
        /// </summary>
        /// <param name="conversionType">unit to convert</param>
        /// <param name="provider">format provider</param>
        /// <returns>type representation of the object</returns>
        [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)NTU).ToType(conversionType, provider);

        /// <summary>
        /// Convert to uint16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint16 representation of the object</returns>
        [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)NTU).ToUInt16(provider);

        /// <summary>
        /// Convert to uint32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint32 representation of the object</returns>
        [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)NTU).ToUInt32(provider);

        /// <summary>
        /// Convert to uint64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint64 representation of the object</returns>
        [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)NTU).ToUInt64(provider);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure]
        public int CompareTo(double? other)
        {
            return (other is null) ? -1 : (NTU).CompareTo(other.Value);
        }

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double? other) => NTU.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double other) => NTU.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(double other) => NTU.CompareTo(other);
    }
}