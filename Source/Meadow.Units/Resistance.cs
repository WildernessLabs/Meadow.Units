using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electrical resistance
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Resistance :
    IUnit<Resistance, Resistance.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Resistance _zero;

    static Resistance()
    {
        _zero = new Resistance(0, UnitType.Ohms);
    }

    /// <summary>
    /// Gets a resistance of 0 Ohms
    /// </summary>
    public static Resistance Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Resistance"/> object.
    /// </summary>
    /// <param name="value">The Resistance value.</param>
    /// <param name="type">Ohms by default.</param>
    public Resistance(double value, UnitType type = UnitType.Ohms)
    {
        Value = ResistanceConversions.Convert(value, type, UnitType.Ohms);
    }

    /// <summary>
    /// Creates a new <see cref="Resistance"/> object from an existing Resistance object
    /// </summary>
    /// <param name="resistance"></param>
    public Resistance(Resistance resistance)
    {
        Value = resistance.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Resistance.
    /// </summary>
    public enum UnitType
    {
        /// <summary> MilliOhms </summary>
        Milliohms,
        /// <summary> Ohms </summary>
        Ohms,
        /// <summary> Kiloohms </summary>
        Kiloohms,
        /// <summary> Megaohms </summary>
        Megaohms
    }

    /// <summary>
    /// Creates a Resistance instance from a canonical (Ohms) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Resistance FromCanonical(double value)
    {
        return new Resistance(value, UnitType.Ohms);
    }

    /// <summary>
    /// Gets the value of the Resistance in Canonical (Ohms) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Ohms;

    /// <summary>
    /// Get resistance in MilliOhms
    /// </summary>
    public double Milliohms => From(UnitType.Milliohms);

    /// <summary>
    /// Get resistance in Ohms
    /// </summary>
    public double Ohms => From(UnitType.Ohms);

    /// <summary>
    /// Get resistance in kiloOhms
    /// </summary>
    public double Kiloohms => From(UnitType.Kiloohms);

    /// <summary>
    /// Get resistance in megaOhms
    /// </summary>
    public double Megaohms => From(UnitType.Megaohms);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ResistanceConversions.Convert(Value, UnitType.Ohms, convertTo);
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
    /// Compare to another Resistance object
    /// </summary>
    /// <param name="obj">The other Resistance cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Resistance resistance)
        {
            return Value.CompareTo(resistance.Value);
        }

        throw new ArgumentException("Object is not a Resistance");
    }
}