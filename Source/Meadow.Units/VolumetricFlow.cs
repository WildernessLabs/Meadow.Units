using Meadow.Units.Conversions;
using System;
using System.Diagnostics.Contracts;

namespace Meadow.Units;

/// <summary>
/// Represents a volumetric flow measurement.
/// Implements standard interfaces for comparison, formatting, and conversion operations.
/// </summary>
[GenerateUnitBoilerplate]
public partial struct VolumetricFlow :
    IUnit<VolumetricFlow, VolumetricFlow.UnitType>,
    IComparable, IFormattable
{
    private static readonly VolumetricFlow _zero;

    static VolumetricFlow()
    {
        _zero = new VolumetricFlow(0, UnitType.CubicMetersPerSecond);
    }

    /// <summary>
    /// Gets a flow of 0
    /// </summary>
    public static VolumetricFlow Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="VolumetricFlow"/> object.
    /// </summary>
    /// <param name="value">The VolumetricFlow value.</param>
    /// <param name="type">CubicMetersPerSecond by default.</param>
    public VolumetricFlow(double value, UnitType type = UnitType.CubicMetersPerSecond)
    {
        Value = VolumetricFlowConversions.Convert(value, type, UnitType.CubicMetersPerSecond);
    }

    /// <summary>
    /// Creates a new <see cref="VolumetricFlow"/> object from an existing VolumetricFlow object
    /// </summary>
    /// <param name="flow"></param>
    public VolumetricFlow(VolumetricFlow flow)
    {
        Value = flow.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the VolumetricFlow.
    /// </summary>
    public enum UnitType
    {
        /// <summary>CubicMetersPerSecond</summary>
        CubicMetersPerSecond,
        /// <summary>CubicFeetPerMinute</summary>
        CubicFeetPerMinute,
        /// <summary>LitersPerMinute</summary>
        LitersPerMinute,
        /// <summary>LitersPerHour</summary>
        LitersPerHour,
        /// <summary>GallonsPerMinute</summary>
        GallonsPerMinute,
        /// <summary>GallonsPerHour</summary>
        GallonsPerHour,
    }

    /// <summary>
    /// Creates a VolumetricFlow instance from a canonical (CubicMetersPerSecond) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static VolumetricFlow FromCanonical(double value)
    {
        return new VolumetricFlow(value, UnitType.CubicMetersPerSecond);
    }

    /// <summary>
    /// Gets the value of the VolumetricFlow in Canonical (CubicMetersPerSecond) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        // Return the internal value which is already in CubicMetersPerSecond
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.CubicMetersPerSecond;

    /// <summary>
    /// Gets the flow rate in cubic meters per second (m³/s).
    /// </summary>
    public double CubicMetersPerSecond => From(UnitType.CubicMetersPerSecond);

    /// <summary>
    /// Gets the flow rate in cubic feet per minute (CFM).
    /// </summary>
    public double CubicFeetPerMinute => From(UnitType.CubicFeetPerMinute);

    /// <summary>
    /// Gets the flow rate in liters per minute (L/min).
    /// </summary>
    public double LitersPerMinute => From(UnitType.LitersPerMinute);

    /// <summary>
    /// Gets the flow rate in liters per hour (L/h).
    /// </summary>
    public double LitersPerHour => From(UnitType.LitersPerHour);

    /// <summary>
    /// Gets the flow rate in gallons per minute (GPM).
    /// </summary>
    public double GallonsPerMinute => From(UnitType.GallonsPerMinute);

    /// <summary>
    /// Gets the flow rate in gallons per hour (GPH).
    /// </summary>
    public double GallonsPerHour => From(UnitType.GallonsPerHour);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return VolumetricFlowConversions.Convert(Value, UnitType.CubicMetersPerSecond, convertTo);
    }

    /// <summary>
    /// Compares the current unit with another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current unit.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <exception cref="ArgumentException">The object is not a VolumetricFlow.</exception>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is VolumetricFlow VolumetricFlow)
        {
            return Value.CompareTo(VolumetricFlow.Value);
        }
        throw new ArgumentException("Object is not a VolumetricFlow");
    }

    /// <inheritdoc/>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);
}
