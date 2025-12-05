using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Concentration
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Concentration :
    IUnit<Concentration, Concentration.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Concentration"/> object.
    /// </summary>
    /// <param name="value">The Concentration value.</param>
    /// <param name="type">Parts Per Million by default.</param>
    public Concentration(double value, UnitType type = UnitType.PartsPerMillion)
    {
        Value = ConcentrationConversions.Convert(value, type, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Creates a copy of a <see cref="Concentration"/> object.
    /// </summary>
    /// <param name="concentration">Concentration to copy</param>
    public Concentration(Concentration concentration)
    {
        Value = concentration.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Concentration.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Parts per 100
        /// </summary>
        PartsPerHundred,
        /// <summary>
        /// Parts per 1,000
        /// </summary>
        PartsPerThousand,
        /// <summary>
        /// Parts per 1,000,000
        /// </summary>
        PartsPerMillion,
        /// <summary>
        /// Parts per 1,000,000,000
        /// </summary>
        PartsPerBillion,
    }

    /// <summary>
    /// Creates a Concentration instance from a canonical (PartsPerMillion) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Concentration FromCanonical(double value)
    {
        return new Concentration(value, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Gets the value of the Concentration in Canonical (PartsPerMillion) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.PartsPerMillion;

    /// <summary>
    /// Get Concentration in parts per 100
    /// </summary>
    public double PartsPerHundred => From(UnitType.PartsPerHundred);
    /// <summary>
    /// Get Concentration in parts per 1000
    /// </summary>
    public double PartsPerThousand => From(UnitType.PartsPerThousand);
    /// <summary>
    /// Get Concentration in parts per 1,000,000
    /// </summary>
    public double PartsPerMillion => From(UnitType.PartsPerMillion);
    /// <summary>
    /// Get Concentration in parts per 1,000,000,000
    /// </summary>
    public double PartsPerBillion => From(UnitType.PartsPerBillion);

    /// <summary>
    /// Get Concentration for a specific unit
    /// </summary>
    /// <param name="convertTo">unit</param>
    /// <returns>value as a double</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ConcentrationConversions.Convert(Value, UnitType.PartsPerMillion, convertTo);
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
    /// Compare to another Concentration object
    /// </summary>
    /// <param name="obj">The other Concentration cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Concentration concentration)
        {
            return Value.CompareTo(concentration.Value);
        }

        throw new ArgumentException("Object is not a Concentration");
    }
}