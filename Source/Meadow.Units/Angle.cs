﻿using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Angle
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct Angle :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static Angle? _zero;

    /// <summary>
    /// Gets an angle of 0 degrees
    /// </summary>
    public static Angle Zero => _zero ?? (_zero = new Angle(0, UnitType.Degrees)).Value;

    /// <summary>
    /// Creates a new `Angle` object.
    /// </summary>
    /// <param name="value">The Angle value.</param>
    /// <param name="type">Degrees by default.</param>
    public Angle(double value, UnitType type = UnitType.Degrees)
    {
        Value = AngleConversions.Convert(value, type, UnitType.Degrees);
    }

    /// <summary>
    /// Creates a new `Angle` object from an existing angle object
    /// </summary>
    /// <param name="angle"></param>
    public Angle(Angle angle)
    {
        Value = angle.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Angle.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Revolutions
        /// </summary>
        Revolutions,
        /// <summary>
        /// Degrees
        /// </summary>
        Degrees,
        /// <summary>
        /// Radians
        /// </summary>
        Radians,
        /// <summary>
        /// Gradians
        /// </summary>
        Gradians,
        /// <summary>
        /// Minutes
        /// </summary>
        Minutes,
        /// <summary>
        /// Seconds
        /// </summary>
        Seconds
    }

    /// <summary>
    /// Get angle in revolutions
    /// </summary>
    public double Revolutions => From(UnitType.Revolutions);

    /// <summary>
    /// Get angle in degrees
    /// </summary>
    public double Degrees => From(UnitType.Degrees);

    /// <summary>
    /// Get angle in radians
    /// </summary>
    public double Radians => From(UnitType.Radians);

    /// <summary>
    /// Get angle in gradians
    /// </summary>
    public double Gradians => From(UnitType.Gradians);

    /// <summary>
    /// Get angle in minutes
    /// </summary>
    public double Minutes => From(UnitType.Minutes);

    /// <summary>
    /// Get angle in seconds
    /// </summary>
    public double Seconds => From(UnitType.Seconds);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AngleConversions.Convert(Value, UnitType.Degrees, convertTo);
    }

    /// <summary>
    /// Compare to another Angle object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure]
    public override bool Equals(object obj)
    {
        if (obj is null) { return false; }
        if (Equals(this, obj)) { return true; }
        return obj.GetType() == GetType() && Equals((Angle)obj);
    }

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => Value.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator Angle(ushort value) => new Angle(value);
    //[Pure] public static implicit operator Angle(short value) => new Angle(value);
    //[Pure] public static implicit operator Angle(uint value) => new Angle(value);
    //[Pure] public static implicit operator Angle(long value) => new Angle(value);
    //[Pure] public static implicit operator Angle(int value) => new Angle(value);
    //[Pure] public static implicit operator Angle(float value) => new Angle(value);
    //[Pure] public static implicit operator Angle(double value) => new Angle(value);
    //[Pure] public static implicit operator Angle(decimal value) => new Angle((double)value);

    // Comparison
    /// <summary>
    /// Compare to another Angle object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(Angle other) => Value == other.Value;

    /// <summary>
    /// Equals operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(Angle left, Angle right) => Equals(left.Value, right.Value);

    /// <summary>
    /// Not equals operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(Angle left, Angle right) => !Equals(left.Value, right.Value);

    /// <summary>
    /// Compare to another Angle object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(Angle other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

    /// <summary>
    /// Less than operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(Angle left, Angle right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Greater than operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(Angle left, Angle right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(Angle left, Angle right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(Angle left, Angle right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    /// <summary>
    /// Helper method to ensure mathematical results 'wrap' correctly at 0/360 degrees.
    /// </summary>
    /// <returns>proper result in the range of [0,360)</returns>
    private static double ConvertTo360(double value)
    {
        value %= 360;
        while (value < 0)
        {
            value += 360;
        }
        return value;
    }

    /// <summary>
    /// Addition operator to add two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Angle object with a value of left + right</returns>
    [Pure] public static Angle operator +(Angle left, Angle right) => new(ConvertTo360(left.Value + right.Value));

    /// <summary>
    /// Subtraction operator to subtract two Angle objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Angle object with a value of left - right</returns>
    [Pure] public static Angle operator -(Angle left, Angle right) => new(ConvertTo360(left.Value - right.Value));

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new Angle object with a value of value multiplied by the operand</returns>
    [Pure] public static Angle operator *(Angle value, double operand) => new(ConvertTo360(value.Value * operand));

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new Angle object with a value of value divided by the operand</returns>
    [Pure] public static Angle operator /(Angle value, double operand) => new(ConvertTo360(value.Value / operand));

    /// <summary>
    /// Returns the absolute value of the <see cref="Angle"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public Angle Abs() { return new Angle(Math.Abs(this.Value)); }

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => Value.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Angle object
    /// </summary>
    /// <param name="obj">The other Angle cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(object obj) => Value.CompareTo(obj);

    /// <summary>
    /// Get type code of object
    /// </summary>
    /// <returns>The TypeCode</returns>
    [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();

    /// <summary>
    /// Convert to boolean
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>bool representation of the object</returns>
    [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

    /// <summary>
    /// Convert to byte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>byte representation of the object</returns>
    [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

    /// <summary>
    /// Convert to char
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>char representation of the object</returns>
    [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

    /// <summary>
    /// Convert to DateTime
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>DateTime representation of the object</returns>
    [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

    /// <summary>
    /// Convert to Decimal
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>Decimal representation of the object</returns>
    [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

    /// <summary>
    /// Convert to double
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>double representation of the object</returns>
    [Pure] public double ToDouble(IFormatProvider provider) => Value;

    /// <summary>
    /// Convert to in16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int16 representation of the object</returns>
    [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

    /// <summary>
    /// Convert to int32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int32 representation of the object</returns>
    [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

    /// <summary>
    /// Convert to int64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int64 representation of the object</returns>
    [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

    /// <summary>
    /// Convert to sbyte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>sbyte representation of the object</returns>
    [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

    /// <summary>
    /// Convert to float
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>float representation of the object</returns>
    [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

    /// <summary>
    /// Convert to string
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>string representation of the object</returns>
    [Pure] public string ToString(IFormatProvider provider) => Value.ToString(provider);

    /// <summary>
    /// Convert to type
    /// </summary>
    /// <param name="conversionType">conversion type</param>
    /// <param name="provider">format provider</param>
    /// <returns>type representation of the object</returns>
    [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);

    /// <summary>
    /// Convert to uint16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint16 representation of the object</returns>
    [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

    /// <summary>
    /// Convert to uint32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint32 representation of the object</returns>
    [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

    /// <summary>
    /// Convert to uint64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint64 representation of the object</returns>
    [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(double? other)
    {
        return (other is null) ? -1 : (Value).CompareTo(other.Value);
    }

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double? other) => Value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double other) => Value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(double other) => Value.CompareTo(other);
}