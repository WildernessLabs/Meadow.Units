using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Acceleration
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Acceleration :
    IUnit<Acceleration, Acceleration.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Acceleration"/> object.
    /// </summary>
    /// <param name="value">The Acceleration value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public Acceleration(double value, UnitType type = UnitType.MetersPerSecondSquared)
    {
        Value = AccelerationConversions.Convert(value, type, UnitType.MetersPerSecondSquared);
    }

    /// <summary>
    /// Creates a new Acceleration object.
    /// </summary>
    /// <param name="acceleration"></param>
    public Acceleration(Acceleration acceleration)
    {
        Value = acceleration.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Acceleration.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Meters per second squared </summary>
        MetersPerSecondSquared,
        /// <summary> Centimeters per second squared </summary>
        CentimetersPerSecondSquared,
        /// <summary> Galileo </summary>
        Galileo,
        /// <summary> MilliGalileo </summary>
        MilliGalileo,
        /// <summary> MilliGravity </summary>
        MilliGravity,
        /// <summary> Gravity </summary>
        Gravity,
        /// <summary> Feet per second squared </summary>
        FeetPerSecondSquared,
        /// <summary> Inches per second squared </summary>
        InchesPerSecondSquared,
    }

    /// <summary>
    /// Creates an Acceleration instance from a canonical (MetersPerSecondSquared) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Acceleration FromCanonical(double value)
    {
        return new Acceleration(value, UnitType.MetersPerSecondSquared);
    }

    /// <summary>
    /// Gets the value of the Acceleration in Canonical (MetersPerSecondSquared) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.MetersPerSecondSquared;

    /// <summary>
    /// Get acceleration in meters per second squared
    /// </summary>
    public double MetersPerSecondSquared => From(UnitType.MetersPerSecondSquared);

    /// <summary>
    /// Get acceleration in centimeters per second squared
    /// </summary>
    public double CentimetersPerSecondSquared => From(UnitType.CentimetersPerSecondSquared);

    /// <summary>
    /// Get acceleration in g
    /// </summary>
    public double Gravity => From(UnitType.Gravity);

    /// <summary>
    /// Get acceleration in feet per second squared
    /// </summary>
    public double FeetPerSecondSquared => From(UnitType.FeetPerSecondSquared);

    /// <summary>
    /// Get acceleration in inches per second squared
    /// </summary>
    public double InchesPerSecondSquared => From(UnitType.InchesPerSecondSquared);

    /// <summary>
    /// Get acceleration value for a given unit
    /// </summary>
    /// <param name="convertTo">acceleration unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AccelerationConversions.Convert(Value, UnitType.MetersPerSecondSquared, convertTo);
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
    /// Compare to another Acceleration object
    /// </summary>
    /// <param name="obj">The other Acceleration cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Acceleration acceleration)
        {
            return Value.CompareTo(acceleration.Value);
        }

        throw new ArgumentException("Object is not an Acceleration");
    }
}