using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Power
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Power :
    IUnit<Power, Power.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Power _zero;

    static Power()
    {
        _zero = new Power(0, UnitType.Watts);
    }

    /// <summary>
    /// Gets a power of 0 Watts
    /// </summary>
    public static Power Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Power"/> object.
    /// </summary>
    /// <param name="value">The Power value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public Power(double value, UnitType type = UnitType.Watts)
    {
        Value = PowerConversions.Convert(value, type, UnitType.Watts);
    }

    /// <summary>
    /// Creates a new <see cref="Power"/> object from an existing Power object
    /// </summary>
    /// <param name="power"></param>
    public Power(Power power)
    {
        Value = power.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Power.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Gigawatts </summary>
        Gigawatts,
        /// <summary> Megawatts </summary>
        Megawatts,
        /// <summary> Kilowatts </summary>
        Kilowatts,
        /// <summary> Watts </summary>
        Watts,
        /// <summary> Milliwatts </summary>
        Milliwatts,
        /// <summary> Horsepower - metric </summary>
        HorsePowerMetric,
        /// <summary> Horsepower - IT </summary>
        HorsePowerIT,
        /// <summary> Calories per second </summary>
        CaloriesPerSecond,
        /// <summary> Calories per minute </summary>
        CaloriesPerMinute,
        /// <summary> Calories per hour </summary>
        CaloriesPerHour,
        /// <summary> BTUs per second </summary>
        BTUsPerSecond,
        /// <summary> BTUs per minute </summary>
        BTUsPerMinute,
        /// <summary> BTUs per hour </summary>
        BTUsPerHour,
        /// <summary> Foot-pounds per second </summary>
        FootPoundsPerSecond,
        /// <summary> Foot-pounds per minute </summary>
        FootPoundsPerMinute,
        /// <summary> Foot-pounds per hour </summary>
        FootPoundsPerHour,
        /// <summary> Tons refrigeration </summary>
        TonsRefrigeration
    }

    /// <summary>
    /// Creates a Power instance from a canonical (Watts) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Power FromCanonical(double value)
    {
        return new Power(value, UnitType.Watts);
    }

    /// <summary>
    /// Gets the value of the Power in Canonical (Watts) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Watts;

    /// <summary>
    /// Power in gigawatts
    /// </summary>
    public double Gigawatts => From(UnitType.Gigawatts);
    /// <summary>
    /// Power in megawatts
    /// </summary>
    public double Megawatts => From(UnitType.Megawatts);
    /// <summary>
    /// Power in kilowatts
    /// </summary>
    public double Kilowatts => From(UnitType.Kilowatts);
    /// <summary>
    /// Power in watts
    /// </summary>
    public double Watts => From(UnitType.Watts);
    /// <summary>
    /// Power in milliwatts
    /// </summary>
    public double Milliwatts => From(UnitType.Milliwatts);
    /// <summary>
    /// Power in horsepower metric
    /// </summary>
    public double HorsePowerMetric => From(UnitType.HorsePowerMetric);
    /// <summary>
    /// Power in horsepower IT
    /// </summary>
    public double HorsePowerIT => From(UnitType.HorsePowerIT);
    /// <summary>
    /// Power in calories per second
    /// </summary>
    public double CaloriesPerSecond => From(UnitType.CaloriesPerSecond);
    /// <summary>
    /// Power in calories per minute
    /// </summary>
    public double CaloriesPerMinute => From(UnitType.CaloriesPerMinute);
    /// <summary>
    /// Power in calories per hour
    /// </summary>
    public double CaloriesPerHour => From(UnitType.CaloriesPerHour);
    /// <summary>
    /// Power in BTUs per second
    /// </summary>
    public double BTUsPerSecond => From(UnitType.BTUsPerSecond);
    /// <summary>
    /// Power in BTUs per minute
    /// </summary>
    public double BTUsPerMinute => From(UnitType.BTUsPerMinute);
    /// <summary>
    /// Power in BTUs per hour
    /// </summary>
    public double BTUsPerHour => From(UnitType.BTUsPerHour);
    /// <summary>
    /// Power in foot-pounds per second
    /// </summary>
    public double FootPoundsPerSecond => From(UnitType.FootPoundsPerSecond);
    /// <summary>
    /// Power in foot-pounds per minute
    /// </summary>
    public double FootPoundsPerMinute => From(UnitType.FootPoundsPerMinute);
    /// <summary>
    /// Power in foot-pounds per hour
    /// </summary>
    public double FootPoundsPerHour => From(UnitType.FootPoundsPerHour);
    /// <summary>
    /// Power in tons refrigeration
    /// </summary>
    public double TonsRefridgeration => From(UnitType.TonsRefrigeration);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return PowerConversions.Convert(Value, UnitType.Watts, convertTo);
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
    /// Compare to another Power object
    /// </summary>
    /// <param name="obj">The other Power cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Power power)
        {
            return Value.CompareTo(power.Value);
        }

        throw new ArgumentException("Object is not a Power");
    }
}