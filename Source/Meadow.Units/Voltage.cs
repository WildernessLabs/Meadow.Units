﻿using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Potential, or _Voltage_.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct Voltage :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static Voltage _zero;

    static Voltage()
    {
        _zero = new Voltage(0, UnitType.Volts);
    }

    /// <summary>
    /// Gets a voltage of 0 Volts
    /// </summary>
    public static Voltage Zero => _zero;

    /// <summary>
    /// Creates a new `Voltage` object.
    /// </summary>
    /// <param name="value">The Voltage value.</param>
    /// <param name="type">Volts by default.</param>
    public Voltage(double value, UnitType type = UnitType.Volts)
    {
        Value = VoltageConversions.Convert(value, type, UnitType.Volts);
    }

    /// <summary>
    /// Creates a new `Voltage` object from an existing Voltage object
    /// </summary>
    /// <param name="voltage"></param>
    public Voltage(Voltage voltage)
    {
        Value = voltage.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Voltage.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Volts </summary>
        Volts,
        /// <summary> Millivolts </summary>
        Millivolts,
        /// <summary> Microvolts </summary>
        Microvolts,
        /// <summary> Kilovolts </summary>
        Kilovolts,
        /// <summary> Megavolts </summary>
        Megavolts,
        /// <summary> Gigavolts </summary>
        Gigavolts,
        /// <summary> Statvolts </summary>
        Statvolts,
        /// <summary> Nanovolts </summary>
        Nanovolts,
    }

    /// <summary> Get voltage in volts </summary>
    public double Volts => From(UnitType.Volts);
    /// <summary> Get voltage in millivolts </summary>
    public double Millivolts => From(UnitType.Millivolts);
    /// <summary> Get voltage in microvolts </summary>
    public double Microvolts => From(UnitType.Microvolts);
    /// <summary> Get voltage in kilovolts </summary>
    public double Kilovolts => From(UnitType.Kilovolts);
    /// <summary> Get voltage in megavolts </summary>
    public double Megavolts => From(UnitType.Megavolts);
    /// <summary> Get voltage in gigavolts </summary>
    public double Gigavolts => From(UnitType.Gigavolts);
    /// <summary> Get voltage in statvolts </summary>
    public double Statvolts => From(UnitType.Statvolts);
    /// <summary> Get voltage in nanovolts </summary>
    public double Nanovolts => From(UnitType.Nanovolts);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return VoltageConversions.Convert(Value, Voltage.UnitType.Volts, convertTo);
    }

    /// <summary>
    /// Compare to another Voltage object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure]
    public override bool Equals(object obj)
    {
        if (obj is null) { return false; }
        if (Equals(this, obj)) { return true; }
        return obj.GetType() == GetType() && Equals((Voltage)obj);
    }

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => Value.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator Voltage(ushort value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(short value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(uint value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(long value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(int value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(float value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(double value) => new Voltage(value);
    //[Pure] public static implicit operator Voltage(decimal value) => new Voltage((double)value);

    // Comparison
    /// <summary>
    /// Compare to another Voltage object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(Voltage other) => Value == other.Value;

    /// <summary>
    /// Equals operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(Voltage left, Voltage right) => Equals(left.Value, right.Value);

    /// <summary>
    /// Not equals operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(Voltage left, Voltage right) => !Equals(left.Value, right.Value);

    /// <summary>
    /// Compare to another Voltage object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(Voltage other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

    /// <summary>
    /// Less than operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(Voltage left, Voltage right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Greater than operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(Voltage left, Voltage right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(Voltage left, Voltage right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(Voltage left, Voltage right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Voltage object with a value of left + right</returns>
    [Pure] public static Voltage operator +(Voltage left, Voltage right) => new(left.Value + right.Value);

    /// <summary>
    /// Subtraction operator to subtract two Voltage objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new Voltage object with a value of left - right</returns>
    [Pure] public static Voltage operator -(Voltage left, Voltage right) => new(left.Value - right.Value);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new Voltage object with a value of value multiplied by the operand</returns>
    [Pure] public static Voltage operator *(Voltage value, double operand) => new(value.Value * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new Voltage object with a value of value divided by the operand</returns>
    [Pure] public static Voltage operator /(Voltage value, double operand) => new(value.Value / operand);

    /// <summary>
    /// Returns the absolute value of the <see cref="Voltage"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public Voltage Abs() { return new Voltage(Math.Abs(this.Value)); }

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
    /// Compare to another Voltage object
    /// </summary>
    /// <param name="obj">The other Voltage cast to object</param>
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
    /// <param name="conversionType">type to convert to</param>
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