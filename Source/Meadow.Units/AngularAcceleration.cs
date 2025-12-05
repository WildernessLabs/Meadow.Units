using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents AngularAcceleration
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct AngularAcceleration :
    IUnit<AngularAcceleration, AngularAcceleration.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="AngularAcceleration"/> object.
    /// </summary>
    /// <param name="value">The AngularAcceleration value.</param>
    /// <param name="type">units of angular acceleration</param>
    public AngularAcceleration(double value, UnitType type = UnitType.RevolutionsPerSecondSquared)
    {
        Value = AngularAccelerationConversions.Convert(value, type, UnitType.RevolutionsPerSecondSquared);
    }

    /// <summary>
    /// Creates a new <see cref="AngularAcceleration"/> object from an existing object
    /// </summary>
    /// <param name="acceleration"></param>
    public AngularAcceleration(AngularAcceleration acceleration)
    {
        Value = acceleration.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the AngularAcceleration.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Revolutions per second squared </summary>
        RevolutionsPerSecondSquared,
        /// <summary> Revolutions per minute squared </summary>
        RevolutionsPerMinuteSquared,
        /// <summary> Radians per second squared </summary>
        RadiansPerSecondSquared,
        /// <summary> Radians per minutes squared </summary>
        RadiansPerMinuteSquared,

        /// <summary>
        /// Degrees per second squared
        /// </summary>
        DegreesPerSecondSquared,

        /// <summary>
        /// Degrees per minute squared
        /// </summary>
        DegreesPerMinuteSquared
    }

    /// <summary>
    /// Creates an AngularAcceleration instance from a canonical (RevolutionsPerSecondSquared) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static AngularAcceleration FromCanonical(double value)
    {
        return new AngularAcceleration(value, UnitType.RevolutionsPerSecondSquared);
    }

    /// <summary>
    /// Gets the value of the AngularAcceleration in Canonical (RevolutionsPerSecondSquared) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.RevolutionsPerSecondSquared;

    /// <summary>
    /// Get angular acceleration in revolutions per second squared
    /// </summary>
    public double RevolutionsPerSecondSquared => From(UnitType.RevolutionsPerSecondSquared);

    /// <summary>
    /// Get angular acceleration in revolutions per minutes squared
    /// </summary>
    public double RevolutionsPerMinuteSquared => From(UnitType.RevolutionsPerMinuteSquared);

    /// <summary>
    /// Get angular acceleration in radians per second squared
    /// </summary>
    public double RadiansPerSecondSquared => From(UnitType.RadiansPerSecondSquared);

    /// <summary>
    /// Get angular acceleration in radians per minute squared
    /// </summary>
    public double RadiansPerMinuteSquared => From(UnitType.RadiansPerMinuteSquared);

    /// <summary>
    /// Get angular acceleration in degrees per second squared
    /// </summary>
    public double DegreesPerSecondSquared => From(UnitType.DegreesPerSecondSquared);

    /// <summary>
    /// Get angular acceleration in degrees per minute squared
    /// </summary>
    public double DegreesPerMinuteSquared => From(UnitType.DegreesPerMinuteSquared);

    /// <summary>
    /// Get angular acceleration for a specific unit
    /// </summary>
    /// <param name="convertTo"></param>
    /// <returns>angular acceleration value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AngularAccelerationConversions.Convert(Value, UnitType.RevolutionsPerSecondSquared, convertTo);
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
    /// Compare to another AngularAcceleration object
    /// </summary>
    /// <param name="obj">The other AngularAcceleration cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is AngularAcceleration angularAcceleration)
        {
            return Value.CompareTo(angularAcceleration.Value);
        }

        throw new ArgumentException("Object is not an AngularAcceleration");
    }
}