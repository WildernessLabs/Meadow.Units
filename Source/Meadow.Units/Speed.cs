using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Speed
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Speed :
    IUnit<Speed, Speed.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Speed"/> object.
    /// </summary>
    /// <param name="value">The Speed value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public Speed(double value, UnitType type = UnitType.KilometersPerSecond)
    {
        Value = SpeedConversions.Convert(value, type, UnitType.KilometersPerSecond);
    }

    /// <summary>
    /// Creates a new <see cref="Speed"/> object from an existing Speed object
    /// </summary>
    /// <param name="speed"></param>
    public Speed(Speed speed)
    {
        Value = speed.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Speed.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Feet per minute </summary>
        FeetPerMinute,
        /// <summary> Feet per second </summary>
        FeetPerSecond,
        /// <summary> Kilometers per hour </summary>
        KilometersPerHour,
        /// <summary> Kilometers per minute </summary>
        KilometersPerMinute,
        /// <summary> Kilometers per second </summary>
        KilometersPerSecond,
        /// <summary> Knots </summary>
        Knots,
        /// <summary> Meters per minute </summary>
        MetersPerMinute,
        /// <summary> Meters per second </summary>
        MetersPerSecond,
        /// <summary> Miles per hour </summary>
        MilesPerHour,
        /// <summary> Miles per minute </summary>
        MilesPerMinute,
        /// <summary> Miles per second </summary>
        MilesPerSecond,
        /// <summary> Speed of light </summary>
        SpeedOfLight,
        /// <summary> Mach </summary>
        Mach,
    }

    /// <summary>
    /// Creates a Speed instance from a canonical (KilometersPerSecond) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Speed FromCanonical(double value)
    {
        return new Speed(value, UnitType.KilometersPerSecond);
    }

    /// <summary>
    /// Gets the value of the Speed in Canonical (KilometersPerSecond) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.KilometersPerSecond;

    /// <summary>
    /// Get speed in feet per second
    /// </summary>
    public double FeetPerSecond => From(UnitType.FeetPerSecond);
    /// <summary>
    /// Get speed in feet per minute
    /// </summary>
    public double FeetPerMinute => From(UnitType.FeetPerMinute);
    /// <summary>
    /// Get speed in kilometers per hour
    /// </summary>
    public double KilometersPerHour => From(UnitType.KilometersPerHour);
    /// <summary>
    /// Get speed in kilometers per minute
    /// </summary>
    public double KilometersPerMinute => From(UnitType.KilometersPerMinute);
    /// <summary>
    /// Get speed in kilometers per second
    /// </summary>
    public double KilometersPerSecond => From(UnitType.KilometersPerSecond);
    /// <summary>
    /// Get speed in knots
    /// </summary>
    public double Knots => From(UnitType.Knots);
    /// <summary>
    /// Get speed in meters per minute
    /// </summary>
    public double MetersPerMinute => From(UnitType.MetersPerMinute);
    /// <summary>
    /// Get speed in meters per second
    /// </summary>
    public double MetersPerSecond => From(UnitType.MetersPerSecond);
    /// <summary>
    /// Get speed in miles per hour
    /// </summary>
    public double MilesPerHour => From(UnitType.MilesPerHour);
    /// <summary>
    /// Get speed in miles per minute 
    /// </summary>
    public double MilesPerMinute => From(UnitType.MilesPerMinute);
    /// <summary>
    /// Get speed in miles per second
    /// </summary>
    public double MilesPerSecond => From(UnitType.MilesPerSecond);
    /// <summary>
    /// Get speed as a multiple of the speed of light - 299792458m/s
    /// </summary>
    public double SpeedOfLight => From(UnitType.SpeedOfLight);
    /// <summary>
    /// Get speed as a multiple of mach
    /// </summary>
    public double Mach => From(UnitType.Mach);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return SpeedConversions.Convert(Value, UnitType.KilometersPerSecond, convertTo);
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
    /// Compare to another Speed object
    /// </summary>
    /// <param name="obj">The other Speed cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Speed speed)
        {
            return Value.CompareTo(speed.Value);
        }

        throw new ArgumentException("Object is not a Speed");
    }
}