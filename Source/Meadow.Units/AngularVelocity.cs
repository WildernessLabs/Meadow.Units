using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents AngularVelocity
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct AngularVelocity :
    IUnit<AngularVelocity, AngularVelocity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly AngularVelocity _zero;

    static AngularVelocity()
    {
        _zero = new AngularVelocity(0, UnitType.RevolutionsPerSecond);
    }

    /// <summary>
    /// Gets an angle of 0 degrees
    /// </summary>
    public static AngularVelocity Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="AngularVelocity"/> object.
    /// </summary>
    /// <param name="value">The AngularVelocity value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public AngularVelocity(double value, UnitType type = UnitType.RevolutionsPerSecond)
    {
        Value = AngularVelocityConversions.Convert(value, type, UnitType.RevolutionsPerSecond);
    }

    /// <summary>
    /// Creates a new AngularVelocity object.
    /// </summary>
    /// <param name="angularVelocity"></param>
    public AngularVelocity(AngularVelocity angularVelocity)
    {
        Value = angularVelocity.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the AngularVelocity.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Revolutions per second
        /// </summary>
        RevolutionsPerSecond,
        /// <summary>
        /// Revolutions per minute
        /// </summary>
        RevolutionsPerMinute,
        /// <summary>
        /// Radians per second
        /// </summary>
        RadiansPerSecond,
        /// <summary>
        /// Radians per minute
        /// </summary>
        RadiansPerMinute,
        /// <summary>
        /// Degrees per second
        /// </summary>
        DegreesPerSecond,
        /// <summary>
        /// Degrees per minute
        /// </summary>
        DegreesPerMinute
    }

    /// <summary>
    /// Creates an AngularVelocity instance from a canonical (RevolutionsPerSecond) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static AngularVelocity FromCanonical(double value)
    {
        return new AngularVelocity(value, UnitType.RevolutionsPerSecond);
    }

    /// <summary>
    /// Gets the value of the AngularVelocity in Canonical (RevolutionsPerSecond) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.RevolutionsPerSecond;

    /// <summary>
    /// Get angular velocity in revolutions per second
    /// </summary>
    public double RevolutionsPerSecond => From(UnitType.RevolutionsPerSecond);

    /// <summary>
    /// Get angular velocity in revolutions per minute
    /// </summary>
    public double RevolutionsPerMinute => From(UnitType.RevolutionsPerMinute);

    /// <summary>
    /// Get angular velocity in radians per second
    /// </summary>
    public double RadiansPerSecond => From(UnitType.RadiansPerSecond);

    /// <summary>
    /// Get angular velocity in radians per minute
    /// </summary>
    public double RadiansPerMinute => From(UnitType.RadiansPerMinute);

    /// <summary>
    /// Get angular velocity in degrees per second
    /// </summary>
    public double DegreesPerSecond => From(UnitType.DegreesPerSecond);

    /// <summary>
    /// Get angular velocity in degrees per minute
    /// </summary>
    public double DegreesPerMinute => From(UnitType.DegreesPerMinute);

    /// <summary>
    /// Get angular velocity for specific unit
    /// </summary>
    /// <param name="convertTo">the unit to covert to</param>
    /// <returns>the angular velocity</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AngularVelocityConversions.Convert(Value, UnitType.RevolutionsPerSecond, convertTo);
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
    /// Compare to another AngularVelocity object
    /// </summary>
    /// <param name="obj">The other AngularVelocity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is AngularVelocity angularVelocity)
        {
            return Value.CompareTo(angularVelocity.Value);
        }

        throw new ArgumentException("Object is not an AngularVelocity");
    }
}