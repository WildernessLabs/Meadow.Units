using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Length
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct Length :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static Length _zero;

    static Length()
    {
        _zero = new Length(0, UnitType.Meters);
    }

    /// <summary>
    /// Gets a length with a value of zero
    /// </summary>
    public static Length Zero => _zero;

    /// <summary>
    /// Creates a new `Length` object.
    /// </summary>
    /// <param name="value">The Length value.</param>
    /// <param name="type">Meters by default.</param>
    public Length(double value, UnitType type = UnitType.Meters)
    {
        _value = LengthConversions.Convert(value, type, UnitType.Meters);
    }

    /// <summary>
    /// Creates a new `Length` object from an existing Length object
    /// </summary>
    /// <param name="length"></param>
    public Length(Length length)
    {
        this._value = length._value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double _value;

    /// <summary>
    /// The type of units available to describe the Length.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Kilometers
        /// </summary>
        Kilometers,
        /// <summary>
        /// Meters
        /// </summary>
        Meters,
        /// <summary>
        /// Centimeters
        /// </summary>
        Centimeters,
        /// <summary>
        /// Decimeters
        /// </summary>
        Decimeters,
        /// <summary>
        /// Millimeters
        /// </summary>
        Millimeters,
        /// <summary>
        /// Microns
        /// </summary>
        Microns,
        /// <summary>
        /// Nanometers
        /// </summary>
        Nanometers,
        /// <summary>
        /// Miles
        /// </summary>
        Miles,
        /// <summary>
        /// Nautical miles
        /// </summary>
        NauticalMiles,
        /// <summary>
        /// Yards
        /// </summary>
        Yards,
        /// <summary>
        /// Feet
        /// </summary>
        Feet,
        /// <summary>
        /// Inches
        /// </summary>
        Inches,
    }

    /// <summary>
    /// Get length value as Kilometers
    /// </summary>
    public readonly double Kilometers => From(UnitType.Kilometers);
    /// <summary>
    /// Get length value as Meters
    /// </summary>
    public readonly double Meters => From(UnitType.Meters);
    /// <summary>
    /// Get length value as Centimeters
    /// </summary>
    public readonly double Centimeters => From(UnitType.Centimeters);
    /// <summary>
    /// Get length value as Decimeters
    /// </summary>
    public readonly double Decimeters => From(UnitType.Decimeters);
    /// <summary>
    /// Get length value as Millimeters
    /// </summary>
    public readonly double Millimeters => From(UnitType.Millimeters);
    /// <summary>
    /// Get length value as Microns
    /// </summary>
    public readonly double Microns => From(UnitType.Microns);
    /// <summary>
    /// Get length value as Nanometers
    /// </summary>
    public readonly double Nanometers => From(UnitType.Nanometers);
    /// <summary>
    /// Get length value as Miles
    /// </summary>
    public readonly double Miles => From(UnitType.Miles);
    /// <summary>
    /// Get length value as NauticalMiles
    /// </summary>
    public readonly double NauticalMiles => From(UnitType.NauticalMiles);
    /// <summary>
    /// Get length value as Yards
    /// </summary>
    public readonly double Yards => From(UnitType.Yards);
    /// <summary>
    /// Get length value as Feet
    /// </summary>
    public readonly double Feet => From(UnitType.Feet);
    /// <summary>
    /// Get length value as Inches
    /// </summary>
    public readonly double Inches => From(UnitType.Inches);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure] public readonly double From(UnitType convertTo)
    {
        return LengthConversions.Convert(_value, UnitType.Meters, convertTo);
    }

    /// <summary>
    /// Compare to another Length object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public override readonly bool Equals(object obj)
    {
        if (obj is null) { return false; }
        if (Equals(this, obj)) { return true; }
        return obj.GetType() == GetType() && Equals((Length)obj);
    }

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override readonly int GetHashCode() => _value.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator Length(ushort value) => new Length(value);
    //[Pure] public static implicit operator Length(short value) => new Length(value);
    //[Pure] public static implicit operator Length(uint value) => new Length(value);
    //[Pure] public static implicit operator Length(long value) => new Length(value);
    //[Pure] public static implicit operator Length(int value) => new Length(value);
    //[Pure] public static implicit operator Length(float value) => new Length(value);
    //[Pure] public static implicit operator Length(double value) => new Length(value);
    //[Pure] public static implicit operator Length(decimal value) => new Length((double)value);

    // Comparison
    /// <summary>
    /// Compare to another Length object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public readonly bool Equals(Length other) => _value == other._value;

    /// <summary>
    /// Equals operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(Length left, Length right) => Equals(left._value, right._value);

    /// <summary>
    /// Not equals operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(Length left, Length right) => !Equals(left._value, right._value);

    /// <summary>
    /// Compare to another Length object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public readonly int CompareTo(Length other) => Equals(_value, other._value) ? 0 : _value.CompareTo(other._value);

    /// <summary>
    /// Less than operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(Length left, Length right) => Comparer<double>.Default.Compare(left._value, right._value) < 0;

    /// <summary>
    /// Greater than operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(Length left, Length right) => Comparer<double>.Default.Compare(left._value, right._value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(Length left, Length right) => Comparer<double>.Default.Compare(left._value, right._value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(Length left, Length right) => Comparer<double>.Default.Compare(left._value, right._value) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Length object with a value of left + right</returns>
    [Pure] public static Length operator +(Length left, Length right) => new(left._value + right._value);

    /// <summary>
    /// Subtraction operator to subtract two Length objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Length object with a value of left - right</returns>
    [Pure] public static Length operator -(Length left, Length right) => new(left._value - right._value);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new Length object with a value of value multiplied by the operand</returns>
    [Pure] public static Length operator *(Length value, double operand) => new(value._value * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new Length object with a value of value divided by the operand</returns>
    [Pure] public static Length operator /(Length value, double operand) => new(value._value / operand);

    /// <summary>
    /// Returns the absolute value of the <see cref="Length"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public readonly Length Abs() { return new Length(Math.Abs(this._value)); }

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override readonly string ToString() => _value.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public readonly string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Length object
    /// </summary>
    /// <param name="obj">The other Length cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure] public readonly int CompareTo(object obj) => _value.CompareTo(obj);

    /// <summary>
    /// Get type code of object
    /// </summary>
    /// <returns>The TypeCode</returns>
    [Pure] public readonly TypeCode GetTypeCode() => _value.GetTypeCode();

    /// <summary>
    /// Convert to boolean
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>bool representation of the object</returns>
    [Pure] public readonly bool ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);

    /// <summary>
    /// Convert to byte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>byte representation of the object</returns>
    [Pure] public readonly byte ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);

    /// <summary>
    /// Convert to char
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>char representation of the object</returns>
    [Pure] public readonly char ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);

    /// <summary>
    /// Convert to DateTime
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>DateTime representation of the object</returns>
    [Pure] public readonly DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);

    /// <summary>
    /// Convert to Decimal
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>Decimal representation of the object</returns>
    [Pure] public readonly decimal ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);

    /// <summary>
    /// Convert to double
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>double representation of the object</returns>
    [Pure] public readonly double ToDouble(IFormatProvider provider) => _value;

    /// <summary>
    /// Convert to in16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int16 representation of the object</returns>
    [Pure] public readonly short ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);

    /// <summary>
    /// Convert to int32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int32 representation of the object</returns>
    [Pure] public readonly int ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);

    /// <summary>
    /// Convert to int64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int64 representation of the object</returns>
    [Pure] public readonly long ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);

    /// <summary>
    /// Convert to sbyte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>sbyte representation of the object</returns>
    [Pure] public readonly sbyte ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);

    /// <summary>
    /// Convert to float
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>float representation of the object</returns>
    [Pure] public readonly float ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);

    /// <summary>
    /// Convert to string
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>string representation of the object</returns>
    [Pure] public readonly string ToString(IFormatProvider provider) => _value.ToString(provider);

    /// <summary>
    /// Convert to type
    /// </summary>
    /// <param name="conversionType">type to covert to</param>
    /// <param name="provider">format provider</param>
    /// <returns>type representation of the object</returns>
    [Pure] public readonly object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

    /// <summary>
    /// Convert to uint16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint16 representation of the object</returns>
    [Pure] public readonly ushort ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);

    /// <summary>
    /// Convert to uint32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint32 representation of the object</returns>
    [Pure] public readonly uint ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);

    /// <summary>
    /// Convert to uint64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint64 representation of the object</returns>
    [Pure] public readonly ulong ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public readonly int CompareTo(double? other)
    {
        return (other is null) ? -1 : (_value).CompareTo(other.Value);
    }

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public readonly bool Equals(double? other) => _value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public readonly bool Equals(double other) => _value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public readonly int CompareTo(double other) => _value.CompareTo(other);
}