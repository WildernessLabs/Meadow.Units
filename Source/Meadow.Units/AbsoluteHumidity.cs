using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents AbsoluteHumidity
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct AbsoluteHumidity :
    IUnit<AbsoluteHumidity, AbsoluteHumidity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="AbsoluteHumidity"/> object.
    /// </summary>
    /// <param name="value">The AbsoluteHumidity value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public AbsoluteHumidity(double value, UnitType type = UnitType.GramsPerCubicMeter)
    {
        Value = AbsoluteHumidityConversions.Convert(value, type, UnitType.GramsPerCubicMeter);
    }

    /// <summary>
    /// Creates a new AbsoluteHumidity object.
    /// </summary>
    /// <param name="absoluteHumidity"></param>
    public AbsoluteHumidity(AbsoluteHumidity absoluteHumidity)
    {
        Value = absoluteHumidity.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the AbsoluteHumidity.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Grams per cubic meter </summary>
        GramsPerCubicMeter,
        /// <summary> Kilograms per cubic meter </summary>
        KilogramsPerCubicMeter,
    }

    /// <summary>
    /// Creates an AbsoluteHumidity instance from a canonical (GramsPerCubicMeter) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static AbsoluteHumidity FromCanonical(double value)
    {
        return new AbsoluteHumidity(value, UnitType.GramsPerCubicMeter);
    }

    /// <summary>
    /// Gets the value of the AbsoluteHumidity in Canonical (GramsPerCubicMeter) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.GramsPerCubicMeter;

    /// <summary>
    /// Get value of object in grams per cubic meter
    /// </summary>
    public double GramsPerCubicMeter => From(UnitType.GramsPerCubicMeter);

    /// <summary>
    /// Get value of object in kilograms per cubic meter
    /// </summary>
    public double KilogramsPerCubicMeter => From(UnitType.KilogramsPerCubicMeter);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return AbsoluteHumidityConversions.Convert(Value, UnitType.GramsPerCubicMeter, convertTo);
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
    /// Compare to another AbsoluteHumidity object
    /// </summary>
    /// <param name="obj">The other AbsoluteHumidity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is AbsoluteHumidity absoluteHumidity)
        {
            return Value.CompareTo(absoluteHumidity.Value);
        }

        throw new ArgumentException("Object is not an AbsoluteHumidity");
    }
}