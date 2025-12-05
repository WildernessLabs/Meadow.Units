using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Energy
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Energy :
    IUnit<Energy, Energy.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Energy"/> object.
    /// </summary>
    /// <param name="value">The Energy value.</param>
    /// <param name="type">Joules by default.</param>
    public Energy(double value, UnitType type = UnitType.Joules)
    {
        Value = EnergyConversions.Convert(value, type, UnitType.Joules);
    }

    /// <summary>
    /// Creates a new <see cref="Energy"/> object from an existing Energy object
    /// </summary>
    /// <param name="energy"></param>
    public Energy(Energy energy)
    {
        Value = energy.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Energy.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// BTU
        /// </summary>
        BTU,
        /// <summary>
        /// Calories
        /// </summary>
        Calories,
        /// <summary>
        /// Joules
        /// </summary>
        Joules,
        /// <summary>
        /// Kilocalories
        /// </summary>
        Kilocalories,
        /// <summary>
        /// Kilojoules
        /// </summary>
        Kilojoules,
        /// <summary>
        /// Kilowatt hours
        /// </summary>
        KilowattHours,
        /// <summary>
        /// Therms
        /// </summary>
        Therms,
        /// <summary>
        /// Watt hours
        /// </summary>
        WattHours,
        /// <summary>
        /// Watt seconds
        /// </summary>
        WattSeconds
    }

    /// <summary>
    /// Creates an Energy instance from a canonical (Joules) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Energy FromCanonical(double value)
    {
        return new Energy(value, UnitType.Joules);
    }

    /// <summary>
    /// Gets the value of the Energy in Canonical (Joules) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Joules;

    /// <summary>
    /// Get energy value as BTUs
    /// </summary>
    public double BTU => From(UnitType.BTU);
    /// <summary>
    /// Get energy value as calories
    /// </summary>
    public double Calories => From(UnitType.Calories);
    /// <summary>
    /// Get energy value as joules
    /// </summary>
    public double Joules => From(UnitType.Joules);
    /// <summary>
    /// Get energy value as kilocalories
    /// </summary>
    public double Kilocalories => From(UnitType.Kilocalories);
    /// <summary>
    /// Get energy value kilojoules
    /// </summary>
    public double Kilojoules => From(UnitType.Kilojoules);
    /// <summary>
    /// Get energy value as kilowatt hours
    /// </summary>
    public double KilowattHours => From(UnitType.KilowattHours);
    /// <summary>
    /// Get energy value as Therms
    /// </summary>
    public double Therms => From(UnitType.Therms);
    /// <summary>
    /// Get energy value as watt hours
    /// </summary>
    public double WattHours => From(UnitType.WattHours);
    /// <summary>
    /// Get energy value as watt seconds
    /// </summary>
    public double WattSecond => From(UnitType.WattSeconds);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return EnergyConversions.Convert(Value, UnitType.Joules, convertTo);
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
    /// Compare to another Energy object
    /// </summary>
    /// <param name="obj">The other Energy cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Energy energy)
        {
            return Value.CompareTo(energy.Value);
        }

        throw new ArgumentException("Object is not an Energy");
    }
}