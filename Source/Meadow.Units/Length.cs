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
[GenerateUnitBoilerplate]
public partial struct Length :
    IUnit<Length, Length.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Length _zero;

    static Length()
    {
        _zero = new Length(0, UnitType.Meters);
    }

    /// <summary>
    /// Gets a length with a value of zero
    /// </summary>
    public static Length Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Length"/> object.
    /// </summary>
    /// <param name="value">The Length value.</param>
    /// <param name="type">Meters by default.</param>
    public Length(double value, UnitType type = UnitType.Meters)
    {
        Value = LengthConversions.Convert(value, type, UnitType.Meters);
    }

    /// <summary>
    /// Creates a new <see cref="Length"/> object from an existing Length object
    /// </summary>
    /// <param name="length"></param>
    public Length(Length length)
    {
        Value = length.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Length.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Kilometers </summary>
        Kilometers,
        /// <summary> Meters </summary>
        Meters,
        /// <summary> Centimeters </summary>
        Centimeters,
        /// <summary> Decimeters </summary>
        Decimeters,
        /// <summary> Millimeters </summary>
        Millimeters,
        /// <summary> Microns </summary>
        Microns,
        /// <summary> Nanometers </summary>
        Nanometers,
        /// <summary> Miles </summary>
        Miles,
        /// <summary> Nautical miles </summary>
        NauticalMiles,
        /// <summary> Yards </summary>
        Yards,
        /// <summary> Feet </summary>
        Feet,
        /// <summary> Inches </summary>
        Inches,
    }

    /// <summary>
    /// Creates a Length instance from a canonical (Meters) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Length FromCanonical(double value)
    {
        return new Length(value, UnitType.Meters);
    }

    /// <summary>
    /// Gets the value of the Length in Canonical (Meters) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Meters;

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
    [Pure]
    public readonly double From(UnitType convertTo)
    {
        return LengthConversions.Convert(Value, UnitType.Meters, convertTo);
    }

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public readonly override string ToString() => Value.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public readonly string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Length object
    /// </summary>
    /// <param name="obj">The other Length cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public readonly int CompareTo(object obj)
    {
        if (obj is Length length)
        {
            return Value.CompareTo(length.Value);
        }

        throw new ArgumentException("Object is not a Length");
    }
}
