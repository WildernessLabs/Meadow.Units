using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Frequency
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Frequency :
    IUnit<Frequency, Frequency.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Frequency _zero;

    static Frequency()
    {
        _zero = new Frequency(0, UnitType.Hertz);
    }

    /// <summary>
    /// Gets a length with a value of zero
    /// </summary>
    public static Frequency Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Frequency"/> object.
    /// </summary>
    /// <param name="value">The Frequency value.</param>
    /// <param name="type">cycles per second by default.</param>
    public Frequency(double value, UnitType type = UnitType.Hertz)
    {
        Value = FrequencyConversions.Convert(value, type, UnitType.Hertz);
    }

    /// <summary>
    /// Creates a new <see cref="Frequency"/> object from an existing Frequency object
    /// </summary>
    /// <param name="frequency"></param>
    public Frequency(Frequency frequency)
    {
        Value = frequency.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Frequency.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Gigahertz </summary>
        Gigahertz,
        /// <summary> Megahertz </summary>
        Megahertz,
        /// <summary> Kilohertz </summary>
        Kilohertz,
        /// <summary> Hertz </summary>
        Hertz,
    }

    /// <summary>
    /// Creates a Frequency instance from a canonical (Hertz) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Frequency FromCanonical(double value)
    {
        return new Frequency(value, UnitType.Hertz);
    }

    /// <summary>
    /// Gets the value of the Frequency in Canonical (Hertz) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Hertz;

    /// <summary>
    /// Get frequency value as gigahertz
    /// </summary>
    public double Gigahertz => From(UnitType.Gigahertz);
    /// <summary>
    /// Get frequency value as megahertz
    /// </summary>
    public double Megahertz => From(UnitType.Megahertz);
    /// <summary>
    /// Get frequency value as kilohertz
    /// </summary>
    public double Kilohertz => From(UnitType.Kilohertz);
    /// <summary>
    /// Get frequency value as hertz
    /// </summary>
    public double Hertz => From(UnitType.Hertz);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return FrequencyConversions.Convert(Value, UnitType.Hertz, convertTo);
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
    /// Compare to another Frequency object
    /// </summary>
    /// <param name="obj">The other Frequency cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Frequency frequency)
        {
            return Value.CompareTo(frequency.Value);
        }

        throw new ArgumentException("Object is not a Frequency");
    }
}