using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Meadow.Units;

/// <summary>
/// Represents a volumetric flow measurement.
/// Implements standard interfaces for comparison, formatting, and conversion operations.
/// </summary>
public struct VolumetricFlow :
    IComparable, IFormattable
{
    private static VolumetricFlow _zero;

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
    /// Determines whether the specified object is equal to the current unit.
    /// </summary>
    /// <param name="obj">The object to compare with the current unit.</param>
    /// <returns>true if the specified object is equal to the current unit; otherwise, false.</returns>
    [Pure] public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Returns the hash code for this unit.
    /// </summary>
    /// <returns>A hash code value generated from the underlying numerical value.</returns>
    [Pure] public override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Determines whether the specified unit is equal to the current unit.
    /// </summary>
    /// <param name="other">The unit to compare with the current unit.</param>
    /// <returns>true if the units are equal; otherwise, false.</returns>
    [Pure] public bool Equals(VolumetricFlow other) => Value == other.Value;

    /// <summary>
    /// Determines whether two units are equal.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the units are equal; otherwise, false.</returns>
    [Pure] public static bool operator ==(VolumetricFlow left, VolumetricFlow right) => Equals(left.Value, right.Value);

    /// <summary>
    /// Determines whether two units are not equal.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the units are not equal; otherwise, false.</returns>
    [Pure] public static bool operator !=(VolumetricFlow left, VolumetricFlow right) => !Equals(left.Value, right.Value);

    /// <summary>
    /// Compares the current unit with another unit.
    /// </summary>
    /// <param name="other">The unit to compare with the current unit.</param>
    /// <returns>A value that indicates the relative order of the units being compared. Returns 0 if equal, 
    /// less than 0 if less than the other value, or greater than 0 if greater than the other value.</returns>
    [Pure] public int CompareTo(VolumetricFlow other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

    /// <summary>
    /// Determines whether the first unit is less than the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is less than the second unit; otherwise, false.</returns>
    [Pure] public static bool operator <(VolumetricFlow left, VolumetricFlow right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Determines whether the first unit is greater than the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is greater than the second unit; otherwise, false.</returns>
    [Pure] public static bool operator >(VolumetricFlow left, VolumetricFlow right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Determines whether the first unit is less than or equal to the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is less than or equal to the second unit; otherwise, false.</returns>
    [Pure] public static bool operator <=(VolumetricFlow left, VolumetricFlow right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Determines whether the first unit is greater than or equal to the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is greater than or equal to the second unit; otherwise, false.</returns>
    [Pure] public static bool operator >=(VolumetricFlow left, VolumetricFlow right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    /// <summary>
    /// Adds two volumetric flow values.
    /// </summary>
    /// <param name="left">The first value to add.</param>
    /// <param name="right">The second value to add.</param>
    /// <returns>The sum of the two volumetric flow values.</returns>
    [Pure] public static VolumetricFlow operator +(VolumetricFlow left, VolumetricFlow right) => new(left.Value + right.Value);

    /// <summary>
    /// Subtracts one volumetric flow value from another.
    /// </summary>
    /// <param name="left">The value to subtract from.</param>
    /// <param name="right">The value to subtract.</param>
    /// <returns>The difference between the two volumetric flow values.</returns>
    [Pure] public static VolumetricFlow operator -(VolumetricFlow left, VolumetricFlow right) => new(left.Value - right.Value);

    /// <summary>
    /// Multiplies a volumetric flow value by a scalar value.
    /// </summary>
    /// <param name="value">The volumetric flow value to multiply.</param>
    /// <param name="operand">The scalar value to multiply by.</param>
    /// <returns>The product of the volumetric flow and scalar values.</returns>
    [Pure] public static VolumetricFlow operator *(VolumetricFlow value, double operand) => new(value.Value * operand);

    /// <summary>
    /// Divides a volumetric flow value by a scalar value.
    /// </summary>
    /// <param name="value">The volumetric flow value to divide.</param>
    /// <param name="operand">The scalar value to divide by.</param>
    /// <returns>The quotient of the volumetric flow value and scalar value.</returns>
    [Pure] public static VolumetricFlow operator /(VolumetricFlow value, double operand) => new(value.Value / operand);

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

    /// <summary>
    /// Returns the TypeCode for the underlying value type.
    /// </summary>
    /// <returns>The TypeCode for the underlying double value.</returns>
    [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();

    /// <inheritdoc/>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);
    /// <inheritdoc/>
    [Pure] public string ToString(IFormatProvider provider) => Value.ToString(provider);

}
