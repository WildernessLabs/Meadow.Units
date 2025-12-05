using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Volume
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Volume :
    IUnit<Volume, Volume.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Volume"/> object.
    /// </summary>
    /// <param name="value">The Volume value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public Volume(double value, UnitType type = UnitType.Liters)
    {
        Value = VolumeConversions.Convert(value, type, UnitType.Liters);
    }

    /// <summary>
    /// Creates a new <see cref="Volume"/> object from an existing Volume object
    /// </summary>
    /// <param name="volume"></param>
    public Volume(Volume volume)
    {
        Value = volume.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Volume.
    /// </summary>
    public enum UnitType
    {
        /// <summary> US Gallons </summary>
        Gallons,
        /// <summary> Fluid ounces </summary>
        Ounces,
        /// <summary> Cubic feet </summary>
        CubicFeet,
        /// <summary> Cubic inches </summary>
        CubicInches,
        /// <summary> Liters </summary>
        Liters,
        /// <summary> Centiliters </summary>
        Centiliters,
        /// <summary> Milliliters </summary>
        Milliliters,
        /// <summary> Cubic meters </summary>
        CubicMeters,
    }

    /// <summary>
    /// Creates a Volume instance from a canonical (Liters) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Volume FromCanonical(double value)
    {
        return new Volume(value, UnitType.Liters);
    }

    /// <summary>
    /// Gets the value of the Volume in Canonical (Liters) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Liters;

    /// <summary>
    /// Get volume in US gallons
    /// </summary>
    public double Gallons => From(UnitType.Gallons);

    /// <summary>
    /// Get volume in fluid ounces
    /// </summary>
    public double Ounces => From(UnitType.Ounces);

    /// <summary>
    /// Get volume in cubic feet
    /// </summary>
    public double CubicFeet => From(UnitType.CubicFeet);

    /// <summary>
    /// Get volume in cubic inches
    /// </summary>
    public double CubicInches => From(UnitType.CubicInches);

    /// <summary>
    /// Get volume in liters
    /// </summary>
    public double Liters => From(UnitType.Liters);

    /// <summary>
    /// Get volume in centiliters
    /// </summary>
    public double Centiliters => From(UnitType.Centiliters);

    /// <summary>
    /// Get volume in milliliters
    /// </summary>
    public double Milliliters => From(UnitType.Milliliters);

    /// <summary>
    /// Get volume in cubic meters
    /// </summary>
    public double CubicMeters => From(UnitType.CubicMeters);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return VolumeConversions.Convert(Value, UnitType.Liters, convertTo);
    }

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
    /// Compare to another Volume object
    /// </summary>
    /// <param name="obj">The other Volume cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Volume volume)
        {
            return Value.CompareTo(volume.Value);
        }

        throw new ArgumentException("Object is not a Volume");
    }
}