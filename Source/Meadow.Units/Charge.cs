using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Charge.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct Charge :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Charge"/> object.
    /// </summary>
    /// <param name="value">The Charge value.</param>
    /// <param name="type">Coulombs by default.</param>
    public Charge(double value, UnitType type = UnitType.Coulombs)
    {
        Coulombs = value;
    }

    /// <summary>
    /// Creates a new <see cref="Charge"/> object from an existing Charge object
    /// </summary>
    /// <param name="Charge"></param>
    public Charge(Charge Charge)
    {
        Coulombs = Charge.Coulombs;
    }

    /// <summary>
    /// The Charge in coulombs
    /// </summary>
    public double Coulombs { get; private set; }

    /// <summary>
    /// The type of units available to describe the Charge.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// coulombs
        /// </summary>
        Coulombs
    }

    /// <summary>
    /// Compare to another Charge object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => Coulombs.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator Charge(ushort value) => new Charge(value);
    //[Pure] public static implicit operator Charge(short value) => new Charge(value);
    //[Pure] public static implicit operator Charge(uint value) => new Charge(value);
    //[Pure] public static implicit operator Charge(long value) => new Charge(value);
    //[Pure] public static implicit operator Charge(int value) => new Charge(value);
    //[Pure] public static implicit operator Charge(float value) => new Charge(value);
    //[Pure] public static implicit operator Charge(double value) => new Charge(value);
    //[Pure] public static implicit operator Charge(decimal value) => new Charge((double)value);

    // Comparison
    /// <summary>
    /// Compare to another Charge object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(Charge other) => Coulombs == other.Coulombs;

    /// <summary>
    /// Equals operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(Charge left, Charge right) => Equals(left.Coulombs, right.Coulombs);

    /// <summary>
    /// Not equals operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(Charge left, Charge right) => !Equals(left.Coulombs, right.Coulombs);

    /// <summary>
    /// Compare to another Charge object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(Charge other) => Equals(Coulombs, other.Coulombs) ? 0 : Coulombs.CompareTo(other.Coulombs);

    /// <summary>
    /// Less than operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(Charge left, Charge right) => Comparer<double>.Default.Compare(left.Coulombs, right.Coulombs) < 0;

    /// <summary>
    /// Greater than operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(Charge left, Charge right) => Comparer<double>.Default.Compare(left.Coulombs, right.Coulombs) > 0;

    /// <summary>
    /// Less than or equal operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(Charge left, Charge right) => Comparer<double>.Default.Compare(left.Coulombs, right.Coulombs) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(Charge left, Charge right) => Comparer<double>.Default.Compare(left.Coulombs, right.Coulombs) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Charge object with a value of left + right</returns>
    [Pure] public static Charge operator +(Charge left, Charge right) => new(left.Coulombs + right.Coulombs);

    /// <summary>
    /// Subtraction operator to subtract two Charge objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Charge object with a value of left - right</returns>
    [Pure] public static Charge operator -(Charge left, Charge right) => new(left.Coulombs - right.Coulombs);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new Charge object with a value of value multiplied by the operand</returns>
    [Pure] public static Charge operator *(Charge value, double operand) => new(value.Coulombs * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new Charge object with a value of value divided by the operand</returns>
    [Pure] public static Charge operator /(Charge value, double operand) => new(value.Coulombs / operand);

    /// <summary>
    /// Returns the absolute value of the <see cref="Charge"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public Charge Abs() { return new Charge(Math.Abs(Coulombs)); }

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => Coulombs.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Coulombs.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Charge object
    /// </summary>
    /// <param name="obj">The other Charge cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Charge charge)
        {
            return Coulombs.CompareTo(charge.Coulombs);
        }

        throw new ArgumentException("Object is not a Charge");
    }

    /// <summary>
    /// Get type code of object
    /// </summary>
    /// <returns>The TypeCode</returns>
    [Pure] public TypeCode GetTypeCode() => Coulombs.GetTypeCode();

    /// <summary>
    /// Convert to boolean
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>bool representation of the object</returns>
    [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Coulombs).ToBoolean(provider);

    /// <summary>
    /// Convert to byte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>byte representation of the object</returns>
    [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Coulombs).ToByte(provider);

    /// <summary>
    /// Convert to char
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>char representation of the object</returns>
    [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Coulombs).ToChar(provider);

    /// <summary>
    /// Convert to DateTime
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>DateTime representation of the object</returns>
    [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Coulombs).ToDateTime(provider);

    /// <summary>
    /// Convert to Decimal
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>Decimal representation of the object</returns>
    [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Coulombs).ToDecimal(provider);

    /// <summary>
    /// Convert to double
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>double representation of the object</returns>
    [Pure] public double ToDouble(IFormatProvider provider) => Coulombs;

    /// <summary>
    /// Convert to in16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int16 representation of the object</returns>
    [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Coulombs).ToInt16(provider);

    /// <summary>
    /// Convert to int32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int32 representation of the object</returns>
    [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Coulombs).ToInt32(provider);

    /// <summary>
    /// Convert to int64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int64 representation of the object</returns>
    [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Coulombs).ToInt64(provider);

    /// <summary>
    /// Convert to sbyte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>sbyte representation of the object</returns>
    [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Coulombs).ToSByte(provider);

    /// <summary>
    /// Convert to float
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>float representation of the object</returns>
    [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Coulombs).ToSingle(provider);

    /// <summary>
    /// Convert to string
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>string representation of the object</returns>
    [Pure] public string ToString(IFormatProvider provider) => Coulombs.ToString(provider);

    /// <summary>
    /// Convert to type
    /// </summary>
    /// <param name="conversionType">conversion unit type</param>
    /// <param name="provider">format provider</param>
    /// <returns>type representation of the object</returns>
    [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Coulombs).ToType(conversionType, provider);

    /// <summary>
    /// Convert to uint16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint16 representation of the object</returns>
    [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Coulombs).ToUInt16(provider);

    /// <summary>
    /// Convert to uint32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint32 representation of the object</returns>
    [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Coulombs).ToUInt32(provider);

    /// <summary>
    /// Convert to uint64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint64 representation of the object</returns>
    [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Coulombs).ToUInt64(provider);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(double? other)
    {
        return (other is null) ? -1 : (Coulombs).CompareTo(other.Value);
    }

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double? other) => Coulombs.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double other) => Coulombs.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(double other) => Coulombs.CompareTo(other);
}