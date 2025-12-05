using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;
// TODO: add DegreesMinutes type. 

// Notes:
//  1. there are additional precision compass cardinal points: http://tamivox.org/dave/compass/index.html

/// <summary>
/// Represents a cardinal direction; 
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Azimuth :
    IUnit<Azimuth, Azimuth.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object.
    /// </summary>
    /// <param name="value">The cardinal direction value.</param>
    public Azimuth(double value)
    {
        Value = ConvertTo360(value);
    }

    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object.
    /// </summary>
    /// <param name="cardinalPoint">The cardinal direction.</param>
    public Azimuth(Azimuth16PointCardinalNames cardinalPoint)
    {
        Value = AzimuthConversions.Compass16CardinalsToDegrees(cardinalPoint);
    }

    private static double ConvertTo360(double value)
    {
        value %= 360;
        if (value < 0) value += 360;
        return value;
    }

    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object.
    /// </summary>
    /// <param name="azimuth">source object</param>
    public Azimuth(Azimuth azimuth)
    {
        Value = azimuth.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the azimuth.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Degrees (decimal)
        /// </summary>
        DecimalDegrees,
        /// <summary>
        /// Cardinal compass point names (English)
        /// </summary>
        Compass16CardinalPointNames
    }

    /// <summary>
    /// Creates an Azimuth instance from a canonical (DecimalDegrees) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Azimuth FromCanonical(double value)
    {
        return new Azimuth(value);
    }

    /// <summary>
    /// Gets the value of the Azimuth in Canonical (DecimalDegrees) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.DecimalDegrees;

    //========================
    // TO property conversions

    /// <summary>
    /// Gets the cardinal direction value expressed as a unit _Decimal Degrees_ (`Â°`)
    /// </summary>
    public double DecimalDegrees => Value;
    /// <summary>
    /// Gets the cardinal direction value expressed as Radians
    /// </summary>
    public double Radians => Value * Math.PI / 180.0;

    /// <summary>
    /// Gets the cardinal direction value expressed as a unit a 16 division cardinal point
    /// name.
    /// </summary>
    public Azimuth16PointCardinalNames Compass16PointCardinalName => AzimuthConversions.DegressToCompass16PointCardinalName(Value);

    //=============================
    // FROM convenience conversions

    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object from a unit value in _Decimal Degrees_ (`Â°`).
    /// </summary>
    /// <param name="degrees">The cardinal direction value.</param>
    /// <returns>A new cardinal direction object.</returns>
    [Pure] public static Azimuth FromDecimalDegrees(double degrees) => new(ConvertTo360(degrees));

    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object from a unit value in Radians.
    /// </summary>
    /// <param name="radians">The cardinal direction value.</param>
    /// <returns>A new cardinal direction object.</returns>
    [Pure] public static Azimuth FromRadians(double radians) => new(ConvertTo360(radians * 180 / Math.PI));

    /// <summary>
    /// Creates a new <see cref="Azimuth"/> object
    /// </summary>
    /// <param name="name">The 16 point cardinal direction.</param>
    /// <returns>A new cardinal direction object.</returns>
    [Pure] public static Azimuth FromCompass16PointCardinalName(Azimuth16PointCardinalNames name) => new(name);

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
    /// Compare to another Azimuth object
    /// </summary>
    /// <param name="obj">The other Azimuth cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Azimuth azimuth)
        {
            return Value.CompareTo(azimuth.Value);
        }

        throw new ArgumentException("Object is not an Azimuth");
    }
}