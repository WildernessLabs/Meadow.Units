﻿using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Concentration in water
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct ConcentrationInWater :
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ConcentrationInWater"/> object.
    /// </summary>
    /// <param name="value">The ConcentrationInWater value.</param>
    /// <param name="type">Parts Per Million by default.</param>
    public ConcentrationInWater(double value, UnitType type = UnitType.PartsPerMillion)
    {
        Value = ConcentrationInWaterConversions.Convert(value, type, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Creates a copy of a ConcentrationInWater object.
    /// </summary>
    /// <param name="concentration">ConcentrationInWater to copy</param>
    public ConcentrationInWater(ConcentrationInWater concentration)
    {
        Value = concentration.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the ConcentrationInWater.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Parts per 100
        /// </summary>
        PartsPerHundred,
        /// <summary>
        /// Parts per 1,000
        /// </summary>
        PartsPerThousand,
        /// <summary>
        /// Parts per 1,000,000
        /// </summary>
        PartsPerMillion,
        /// <summary>
        /// Milligrams per liter (mg/L)
        /// </summary>
        MilligramsPerLiter,
        /// <summary>
        /// Grams per cubic meter (g/m^3)
        /// </summary>
        GramsPerCubicMeter,
        /// <summary>
        /// Parts per 1,000,000,000
        /// </summary>
        PartsPerBillion,
        /// <summary>
        /// Micrograms per liter (ug/L)
        /// </summary>
        MicrogramsPerLiter,
        /// <summary>
        /// Parts per 1,000,000,000,000
        /// </summary>
        PartsPerTrillion,
        /// <summary>
        /// Grams per liter (g/L)
        /// </summary>
        GramsPerLiter,
        /// <summary>
        /// Kilograms per liter (kg/L)
        /// </summary>
        KilogramsPerLiter,
    }

    /// <summary>
    /// Get ConcentrationInWater in parts per 100
    /// </summary>
    public double PartsPerHundred => From(UnitType.PartsPerHundred);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1000
    /// </summary>
    public double PartsPerThousand => From(UnitType.PartsPerThousand);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000
    /// </summary>
    public double PartsPerMillion => From(UnitType.PartsPerMillion);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000,000
    /// </summary>
    public double PartsPerBillion => From(UnitType.PartsPerBillion);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000,000,000
    /// </summary>
    public double PartsPerTrillion => From(UnitType.PartsPerTrillion);
    /// <summary>
    /// Get ConcentrationInWater in Grams Per Cubic Meter
    /// </summary>
    public double GramsPerCubicMeter => From(UnitType.GramsPerCubicMeter);
    /// <summary>
    /// Get ConcentrationInWater in Micrograms Per Liter
    /// </summary>
    public double MicrogramsPerLiter => From(UnitType.MicrogramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double MilligramsPerLiter => From(UnitType.MilligramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double GramsPerLiter => From(UnitType.GramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double KilogramsPerLiter => From(UnitType.KilogramsPerLiter);

    /// <summary>
    /// Get ConcentrationInWater for a specific unit
    /// </summary>
    /// <param name="convertTo">unit</param>
    /// <returns>value as a double</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ConcentrationInWaterConversions.Convert(Value, UnitType.PartsPerMillion, convertTo);
    }

    /// <summary>
    /// Compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>true if equal</returns>
    [Pure]
    public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Get hash of ConcentrationInWater object
    /// </summary>
    /// <returns>int32 hash of object</returns>
    [Pure] public override int GetHashCode() => Value.GetHashCode();

    // implicit conversions
    //[Pure] public static implicit operator Concentration(ushort value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(short value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(uint value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(long value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(int value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(float value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(double value) => new Concentration(value);
    //[Pure] public static implicit operator Concentration(decimal value) => new Concentration((double)value);

    // Comparison
    /// <summary>
    /// Compare to another ConcentrationInWater objects
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals(ConcentrationInWater other) => Value == other.Value;

    /// <summary>
    /// Equals operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==(ConcentrationInWater left, ConcentrationInWater right) => Equals(left.Value, right.Value);

    /// <summary>
    /// Not equals operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=(ConcentrationInWater left, ConcentrationInWater right) => !Equals(left.Value, right.Value);

    /// <summary>
    /// Compare to another ConcentrationInWater object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(ConcentrationInWater other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

    /// <summary>
    /// Less than operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(ConcentrationInWater left, ConcentrationInWater right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Greater than operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(ConcentrationInWater left, ConcentrationInWater right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(ConcentrationInWater left, ConcentrationInWater right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(ConcentrationInWater left, ConcentrationInWater right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    // Math
    /// <summary>
    /// Addition operator to add two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new ConcentrationInWater object with a value of left + right</returns>
    [Pure] public static ConcentrationInWater operator +(ConcentrationInWater left, ConcentrationInWater right) => new(left.Value + right.Value);

    /// <summary>
    /// Subtraction operator to subtract two ConcentrationInWater objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new ConcentrationInWater object with a value of left - right</returns>
    [Pure] public static ConcentrationInWater operator -(ConcentrationInWater left, ConcentrationInWater right) => new(left.Value - right.Value);

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new ConcentrationInWater object with a value of value multiplied by the operand</returns>
    [Pure] public static ConcentrationInWater operator *(ConcentrationInWater value, double operand) => new(value.Value * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new ConcentrationInWater object with a value of value divided by the operand</returns>
    [Pure] public static ConcentrationInWater operator /(ConcentrationInWater value, double operand) => new(value.Value / operand);

    /// <summary>
    /// Returns the absolute value of the <see cref="ConcentrationInWater"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public ConcentrationInWater Abs() { return new ConcentrationInWater(Math.Abs(Value)); }

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
    /// Compare to another ConcentrationInWater object
    /// </summary>
    /// <param name="obj">The other ConcentrationInWater cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ConcentrationInWater concentrationInWater)
        {
            return Value.CompareTo(concentrationInWater.Value);
        }

        throw new ArgumentException("Object is not a ConcentrationInWater");
    }

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