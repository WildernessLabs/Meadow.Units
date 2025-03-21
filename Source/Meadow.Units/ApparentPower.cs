﻿using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Apparent Power 
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct ApparentPower :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ApparentPower"/> object.
    /// </summary>
    /// <param name="value">The ApparentPower value.</param>
    /// <param name="type">Volt Amperes by default.</param>
    public ApparentPower(double value, UnitType type = UnitType.VoltAmperes)
    {
        Value = ApparentPowerConversions.Convert(value, type, UnitType.VoltAmperes);
    }

    /// <summary>
    /// Creates a new <see cref="ApparentPower"/> object from an existing ApparentPower object
    /// </summary>
    /// <param name="reactivePower"></param>
    public ApparentPower(ApparentPower reactivePower)
    {
        Value = reactivePower.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe ApparentPower.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Gigavolt Ampere
        /// </summary>
        GigavoltAmperes,
        /// <summary>
        /// Megavolt Ampere
        /// </summary>
        MegavoltAmperes,
        /// <summary>
        /// Kilovolt Ampere
        /// </summary>
        KilovoltAmperes,
        /// <summary>
        /// Volt Ampere
        /// </summary>
        VoltAmperes,
        /// <summary>
        /// Millivolt Ampere
        /// </summary>
        MillivoltAmperes,
    }

    /// <summary>
    ///ApparentPower in Millovolt Amperes
    /// </summary>
    public double MillivoltAmperes => From(UnitType.MillivoltAmperes);

    /// <summary>
    ///ApparentPower in Volt Amperes
    /// </summary>
    public double VoltAmperes => From(UnitType.VoltAmperes);

    /// <summary>
    ///ApparentPower in Kilvolt Amperes
    /// </summary>
    public double KilovoltAmperes => From(UnitType.KilovoltAmperes);

    /// <summary>
    ///ApparentPower in Megavolt Amperes
    /// </summary>
    public double MegavoltAmperes => From(UnitType.MegavoltAmperes);

    /// <summary>
    ///ApparentPower in Gigavolt Amperes
    /// </summary>
    public double GigavoltAmperes => From(UnitType.GigavoltAmperes);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ApparentPowerConversions.Convert(Value, UnitType.VoltAmperes, convertTo);
    }

    /// <summary>
    /// Compare to another ApparentPower object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => Value.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator ApparentPower(ushort value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(short value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(uint value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(long value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(int value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(float value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(double value) => new ApparentPower(value);
    //[Pure] public static implicit operator ApparentPower(decimal value) => new ApparentPower((double)value);

    // Comparison
    /// <summary>
    /// Compare to another Apparent Power object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(ApparentPower other) => Value == other.Value;

    /// <summary>
    /// Equals operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(ApparentPower left, ApparentPower right) => Equals(left.Value, right.Value);

    /// <summary>
    /// Not equals operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(ApparentPower left, ApparentPower right) => !Equals(left.Value, right.Value);

    /// <summary>
    /// Compare to another ApparentPower object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(ApparentPower other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

    /// <summary>
    /// Less than operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(ApparentPower left, ApparentPower right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Greater than operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(ApparentPower left, ApparentPower right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(ApparentPower left, ApparentPower right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(ApparentPower left, ApparentPower right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new ApparentPower object with a value of left + right</returns>
    [Pure] public static ApparentPower operator +(ApparentPower left, ApparentPower right) => new(left.Value + right.Value);

    /// <summary>
    /// Subtraction operator to subtract two ApparentPower objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new ApparentPower object with a value of left - right</returns>
    [Pure] public static ApparentPower operator -(ApparentPower left, ApparentPower right) => new(left.Value - right.Value);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new ApparentPower object with a value of value multiplied by the operand</returns>
    [Pure] public static ApparentPower operator *(ApparentPower value, double operand) => new(value.Value * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new ApparentPower object with a value of value divided by the operand</returns>
    [Pure] public static ApparentPower operator /(ApparentPower value, double operand) => new(value.Value / operand);

    /// <summary>
    /// Returns the absolute length, that is, the length without regards to
    /// negative polarity
    /// </summary>
    /// <returns></returns>
    [Pure] public ApparentPower Abs() { return new ApparentPower(Math.Abs(Value)); }

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
    /// Compare to another ApparentPower object
    /// </summary>
    /// <param name="obj">The other ApparentPower cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ApparentPower apparentPower)
        {
            return Value.CompareTo(apparentPower.Value);
        }

        throw new ArgumentException("Object is not an ApparentPower");
    }

    /// <summary>
    /// Get type code of object
    /// </summary>
    /// <returns>The TypeCode</returns>
    [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();

    /// <summary>
    /// Covert to boolean
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>bool representation of the object</returns>
    [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

    /// <summary>
    /// Covert to byte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>byte representation of the object</returns>
    [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

    /// <summary>
    /// Covert to char
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>char representation of the object</returns>
    [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

    /// <summary>
    /// Covert to DateTime
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>DateTime representation of the object</returns>
    [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

    /// <summary>
    /// Covert to Decimal
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>Decimal representation of the object</returns>
    [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

    /// <summary>
    /// Covert to double
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>double representation of the object</returns>
    [Pure] public double ToDouble(IFormatProvider provider) => Value;

    /// <summary>
    /// Covert to in16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int16 representation of the object</returns>
    [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

    /// <summary>
    /// Covert to int32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int32 representation of the object</returns>
    [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

    /// <summary>
    /// Covert to int64
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>int64 representation of the object</returns>
    [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

    /// <summary>
    /// Covert to sbyte
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>sbyte representation of the object</returns>
    [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

    /// <summary>
    /// Covert to float
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>float representation of the object</returns>
    [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

    /// <summary>
    /// Covert to string
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>string representation of the object</returns>
    [Pure] public string ToString(IFormatProvider provider) => Value.ToString(provider);

    /// <summary>
    /// Covert to type
    /// </summary>
    /// <param name="conversionType">conversion type</param>
    /// <param name="provider">format provider</param>
    /// <returns>type representation of the object</returns>
    [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);

    /// <summary>
    /// Covert to uint16
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint16 representation of the object</returns>
    [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

    /// <summary>
    /// Covert to uint32
    /// </summary>
    /// <param name="provider">format provider</param>
    /// <returns>uint32 representation of the object</returns>
    [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

    /// <summary>
    /// Covert to uint64
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