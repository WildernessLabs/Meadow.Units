using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Angle
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Angle :
    IUnit<Angle, Angle.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Angle _zero;

    static Angle()
    {
        _zero = new Angle(0, UnitType.Degrees);
    }

    /// <summary>
    /// Gets an angle with a value of zero
    /// </summary>
    public static Angle Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Angle"/> object.
    /// </summary>
    /// <param name="value">The Angle value.</param>
    /// <param name="type">Degrees by default.</param>
    public Angle(double value, UnitType type = UnitType.Degrees)
    {
        Value = AngleConversions.Convert(value, type, UnitType.Degrees);
    }

    /// <summary>
    /// Creates a new <see cref="Angle"/> object from an existing angle object
    /// </summary>
    /// <param name="angle"></param>
    public Angle(Angle angle)
    {
        Value = angle.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Angle.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Revolutions </summary>
        Revolutions,
        /// <summary> Degrees </summary>
        Degrees,
        /// <summary> Radians </summary>
        Radians,
        /// <summary> Gradians </summary>
        Gradians,
        /// <summary> Minutes </summary>
        Minutes,
        /// <summary> Seconds </summary>
        Seconds
    }

    /// <summary>
    /// Creates an Angle instance from a canonical (Degrees) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Angle FromCanonical(double value)
    {
        return new Angle(value, UnitType.Degrees);
    }

    /// <summary>
    /// Gets the value of the Angle in Canonical (Degrees) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Degrees;

    /// <summary>
    /// Get angle in revolutions
    /// </summary>
    public double Revolutions => From(UnitType.Revolutions);

    /// <summary>
    /// Get angle in degrees
    /// </summary>
    public double Degrees => From(UnitType.Degrees);

    /// <summary>
    /// Get angle in radians
    /// </summary>
    public double Radians => From(UnitType.Radians);

    /// <summary>
    /// Get angle in gradians
    /// </summary>
    public double Gradians => From(UnitType.Gradians);

    /// <summary>
    /// Get angle in minutes
    /// </summary>
    public double Minutes => From(UnitType.Minutes);

    /// <summary>
    /// Get angle in seconds
    /// </summary>
    public double Seconds => From(UnitType.Seconds);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AngleConversions.Convert(Value, UnitType.Degrees, convertTo);
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
    /// Compare to another Angle object
    /// </summary>
    /// <param name="obj">The other Angle cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Angle angle)
        {
            return Value.CompareTo(angle.Value);
        }

        throw new ArgumentException("Object is not an Angle");
    }
}