using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents temperature; the physical quantity that expresses hot and cold.
/// It is the manifestation of thermal energy, present in all matter, which
/// is the source of the occurrence of heat, a flow of energy, when a body
/// is in contact with another that is colder or hotter.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Temperature :
    IUnit<Temperature, Temperature.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Absolute Zero temperature.
    /// </summary>
    public static Temperature AbsoluteZero = new(0, UnitType.Kelvin);

    /// <summary>
    /// Creates a new <see cref="Temperature"/> object.
    /// </summary>
    /// <param name="value">The temperature value.</param>
    /// <param name="type">_Celsius_ (`°C`), by default.</param>
    public Temperature(double value, UnitType type = UnitType.Celsius)
    {
        Value = 0;
        switch (type)
        {
            case UnitType.Celsius:
                Value = value;
                break;
            case UnitType.Fahrenheit:
                Value = TempConversions.FToC(value);
                break;
            case UnitType.Kelvin:
                Value = TempConversions.KToC(value);
                break;
        }

        if (Kelvin < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Temperature cannot be less than 0 Kelvin");
        }
    }

    /// <summary>
    /// Creates a new <see cref="Temperature"/> object from an existing Temperature object.
    /// </summary>
    /// <param name="temperature"></param>
    public Temperature(Temperature temperature)
    {
        Value = temperature.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Temperature.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Celsius </summary>
        Celsius,
        /// <summary> Fahrenheit </summary>
        Fahrenheit,
        /// <summary> Kelvin </summary>
        Kelvin,
    }

    /// <summary>
    /// Creates a Temperature instance from a canonical (Celsius) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Temperature FromCanonical(double value)
    {
        return new Temperature(value, UnitType.Celsius);
    }

    /// <summary>
    /// Gets the value of the Temperature in Canonical (Celsius) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        // Return the internal value which is already in Celsius
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Celsius;

    /// <summary>
    /// Gets the temperature value expressed as a unit _Celsius/Centrigrade_ (`°C`).
    /// </summary>
    public double Celsius => Value;

    /// <summary>
    /// Gets the temperature value expressed as a unit _Fahrenheit_ (`°F`).
    /// </summary>
    public double Fahrenheit => TempConversions.CToF(Value);

    /// <summary>
    /// Gets the temperature value expressed as a unit _Kelvin_ (`K`).
    /// </summary>
    public double Kelvin => TempConversions.CToK(Value);

    /// <summary>
    /// Get temperature value for a given unit
    /// </summary>
    /// <param name="convertTo">unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return TempConversions.Convert(Value, UnitType.Celsius, convertTo);
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
    /// Compare to another Temperature object
    /// </summary>
    /// <param name="obj">The other Temperature cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Temperature temperature)
        {
            return Value.CompareTo(temperature.Value);
        }

        throw new ArgumentException("Object is not a Temperature");
    }
}
