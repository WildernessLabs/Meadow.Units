using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents mass, or weight of an object
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Mass :
    IUnit<Mass, Mass.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Mass"/> object.
    /// </summary>
    /// <param name="value">The mass value.</param>
    /// <param name="type">Grams by default.</param>
    public Mass(double value, UnitType type = UnitType.Grams)
    {
        Value = MassConversions.Convert(value, type, UnitType.Grams);
    }

    /// <summary>
    /// Creates a new <see cref="Mass"/> object from an existing Mass object
    /// </summary>
    /// <param name="mass"></param>
    public Mass(Mass mass)
    {
        Value = mass.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Mass.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Grams </summary>
        Grams,
        /// <summary> Kilograms </summary>
        Kilograms,
        /// <summary> Ounces </summary>
        Ounces,
        /// <summary> Pounds </summary>
        Pounds,
        /// <summary> Tons metric </summary>
        TonsMetric,
        /// <summary> Tons US short </summary>
        TonsUSShort,
        /// <summary> Tons UK long </summary>
        TonsUKLong,
        /// <summary> Grains </summary>
        Grains,
        /// <summary> Carats </summary>
        Carats
    }

    /// <summary>
    /// Creates a Mass instance from a canonical (Grams) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Mass FromCanonical(double value)
    {
        return new Mass(value, UnitType.Grams);
    }

    /// <summary>
    /// Gets the value of the Mass in Canonical (Grams) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Grams;

    /// <summary>
    /// Mass in grams
    /// </summary>
    public double Grams => From(UnitType.Grams);
    /// <summary>
    /// Mass in kilograms
    /// </summary>
    public double Kilograms => From(UnitType.Kilograms);
    /// <summary>
    /// Mass in ounces
    /// </summary>
    public double Ounces => From(UnitType.Ounces);
    /// <summary>
    /// Mass in pounds
    /// </summary>
    public double Pounds => From(UnitType.Pounds);
    /// <summary>
    /// Mass in tons metric
    /// </summary>
    public double TonsMetric => From(UnitType.TonsMetric);
    /// <summary>
    /// Mass in tons US short
    /// </summary>
    public double TonsUSShort => From(UnitType.TonsUSShort);
    /// <summary>
    /// Mass in tons UK long
    /// </summary>
    public double TonsUKLong => From(UnitType.TonsUKLong);
    /// <summary>
    /// Mass in grains
    /// </summary>
    public double Grains => From(UnitType.Grains);
    /// <summary>
    /// Mass in karats
    /// </summary>
    public double Karats => From(UnitType.Carats);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return MassConversions.Convert(Value, UnitType.Grams, convertTo);
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
    /// Compare to another Mass object
    /// </summary>
    /// <param name="obj">The other Mass cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Mass mass)
        {
            return Value.CompareTo(mass.Value);
        }

        throw new ArgumentException("Object is not a Mass");
    }
}
