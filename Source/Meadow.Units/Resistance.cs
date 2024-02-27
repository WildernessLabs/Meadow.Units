using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electrical resistance
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct Resistance :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static Resistance _zero;

    static Resistance()
    {
        _zero = new Resistance(0, UnitType.Ohms);
    }

    /// <summary>
    /// Gets a resistance of 0 Ohms
    /// </summary>
    public static Resistance Zero => _zero;

    /// <summary>
    /// Creates a new `Resistance` object.
    /// </summary>
    /// <param name="value">The Resistance value.</param>
    /// <param name="type">Ohms by default.</param>
    public Resistance(double value, UnitType type = UnitType.Ohms)
    {
        _value = ResistanceConversions.Convert(value, type, UnitType.Ohms);
    }

    /// <summary>
    /// Creates a new `Resistance` object from an existing Resistance object
    /// </summary>
    /// <param name="resistance"></param>
    public Resistance(Resistance resistance)
    {
        _value = resistance._value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double _value;

    /// <summary>
    /// The type of units available to describe the Resistance.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// MilliOhms
        /// </summary>
        Milliohms,
        /// <summary>
        /// Ohms
        /// </summary>
        Ohms,
        /// <summary>
        /// Kiloohms
        /// </summary>
        Kiloohms,
        /// <summary>
        /// Megaohms
        /// </summary>
        Megaohms
    }

    /// <summary>
    /// Get resistance in MilliOhms
    /// </summary>
    public double Milliohms => From(UnitType.Milliohms);
    /// <summary>
    /// Get resistance in Ohms
    /// </summary>
    public double Ohms => From(UnitType.Ohms);
    /// <summary>
    /// Get resistance in kiloOhms
    /// </summary>
    public double Kiloohms => From(UnitType.Kiloohms);
    /// <summary>
    /// Get resistance in megaOhms
    /// </summary>
    public double Megaohms => From(UnitType.Megaohms);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ResistanceConversions.Convert(_value, Resistance.UnitType.Ohms, convertTo);
    }

    /// <summary>
    /// Compare to another Resistance object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure]
    public override bool Equals(object obj)
    {
        if (obj is null) { return false; }
        if (Equals(this, obj)) { return true; }
        return obj.GetType() == GetType() && Equals((Resistance)obj);
    }

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => _value.GetHashCode();

    // Comparison
    /// <summary>
    /// Compare to another Resistance object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(Resistance other) => _value == other._value;

    /// <summary>
    /// Equals operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(Resistance left, Resistance right) => Equals(left._value, right._value);

    /// <summary>
    /// Not equals operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(Resistance left, Resistance right) => !Equals(left._value, right._value);

    /// <summary>
    /// Compare to another Resistance object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(Resistance other) => Equals(_value, other._value) ? 0 : _value.CompareTo(other._value);

    /// <summary>
    /// Less than operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(Resistance left, Resistance right) => Comparer<double>.Default.Compare(left._value, right._value) < 0;

    /// <summary>
    /// Greater than operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(Resistance left, Resistance right) => Comparer<double>.Default.Compare(left._value, right._value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(Resistance left, Resistance right) => Comparer<double>.Default.Compare(left._value, right._value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(Resistance left, Resistance right) => Comparer<double>.Default.Compare(left._value, right._value) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Resistance object with a value of left + right</returns>
    [Pure] public static Resistance operator +(Resistance left, Resistance right) => new(left._value + right._value);

    /// <summary>
    /// Subtraction operator to subtract two Resistance objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Resistance object with a value of left - right</returns>
    [Pure] public static Resistance operator -(Resistance left, Resistance right) => new(left._value - right._value);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new Resistance object with a value of value multiplied by the operand</returns>
    [Pure] public static Resistance operator *(Resistance value, double operand) => new(value._value * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new Resistance object with a value of value divided by the operand</returns>
    [Pure] public static Resistance operator /(Resistance value, double operand) => new(value._value / operand);

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => _value.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Resistance object
    /// </summary>
    /// <param name="obj">The other Resistance cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(object obj) => _value.CompareTo(obj);

    /// <summary>
    /// Get type code of object
    /// </summary>
    /// <returns>The TypeCode</returns>
    [Pure] public TypeCode GetTypeCode() => _value.GetTypeCode();

    /// <summary>
    /// Convert to boolean
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>bool representation of the object</returns>
    [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);

    /// <summary>
    /// Convert to byte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>byte representation of the object</returns>
    [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);

    /// <summary>
    /// Convert to char
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>char representation of the object</returns>
    [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);

    /// <summary>
    /// Convert to DateTime
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>DateTime representation of the object</returns>
    [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);

    /// <summary>
    /// Convert to Decimal
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>Decimal representation of the object</returns>
    [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);

    /// <summary>
    /// Convert to double
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>double representation of the object</returns>
    [Pure] public double ToDouble(IFormatProvider provider) => _value;

    /// <summary>
    /// Convert to in16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int16 representation of the object</returns>
    [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);

    /// <summary>
    /// Convert to int32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int32 representation of the object</returns>
    [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);

    /// <summary>
    /// Convert to int64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int64 representation of the object</returns>
    [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);

    /// <summary>
    /// Convert to sbyte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>sbyte representation of the object</returns>
    [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);

    /// <summary>
    /// Convert to float
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>float representation of the object</returns>
    [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);

    /// <summary>
    /// Convert to string
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>string representation of the object</returns>
    [Pure] public string ToString(IFormatProvider provider) => _value.ToString(provider);

    /// <summary>
    /// Convert to type
    /// </summary>
    /// <param name="conversionType">type to convert to</param>
    /// <param name="provider">format provider</param>
    /// <returns>type representation of the object</returns>
    [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

    /// <summary>
    /// Convert to uint16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint16 representation of the object</returns>
    [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);

    /// <summary>
    /// Convert to uint32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint32 representation of the object</returns>
    [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);

    /// <summary>
    /// Convert to uint64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint64 representation of the object</returns>
    [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(double? other)
    {
        return (other is null) ? -1 : (_value).CompareTo(other.Value);
    }

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double? other) => _value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double other) => _value.Equals(other);

    /// <summary>
    /// Compare the default value to a double 
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(double other) => _value.CompareTo(other);
}