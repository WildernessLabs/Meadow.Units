using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Current.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Current :
    IUnit<Current, Current.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Current _zero;

    static Current()
    {
        _zero = new Current(0, UnitType.Amps);
    }

    /// <summary>
    /// Gets a current of 0 Amps
    /// </summary>
    public static Current Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Current"/> object.
    /// </summary>
    /// <param name="value">The Current value.</param>
    /// <param name="type">Amps by default.</param>
    public Current(double value, UnitType type = UnitType.Amps)
    {
        Value = CurrentConversions.Convert(value, type, UnitType.Amps);
    }

    /// <summary>
    /// Creates a new <see cref="Current"/> object from an existing Current object
    /// </summary>
    /// <param name="Current"></param>
    public Current(Current Current)
    {
        Value = Current.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Current.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Amperes </summary>
        Amps,
        /// <summary> Milli-amperes </summary>
        Milliamps,
        /// <summary> Micro-amperes </summary>
        Microamps,
        /// <summary> Kilo-amperes </summary>
        Kiloamps,
        /// <summary> Mega-amperes </summary>
        Megaamps,
        /// <summary> Giga-amperes </summary>
        Gigaamps,
    }

    /// <summary>
    /// Creates a Current instance from a canonical (Amps) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Current FromCanonical(double value)
    {
        return new Current(value, UnitType.Amps);
    }

    /// <summary>
    /// Gets the value of the Current in Canonical (Amps) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Amps;

    /// <summary> Get current in amps </summary>
    public double Amps => From(UnitType.Amps);

    /// <summary> Get current in milliamps </summary>
    public double Milliamps => From(UnitType.Milliamps);

    /// <summary> Get current in microamps </summary>
    public double Microamps => From(UnitType.Microamps);

    /// <summary> Get current in kiloamps </summary>
    public double Kiloamps => From(UnitType.Kiloamps);

    /// <summary> Get current in megaamps </summary>
    public double Megaamps => From(UnitType.Megaamps);

    /// <summary> Get current in gigaamps </summary>
    public double Gigaamps => From(UnitType.Gigaamps);

    /// <summary>
    /// Convert to a specific unit
    /// </summary>
    /// <param name="convertTo">the unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return CurrentConversions.Convert(Value, UnitType.Amps, convertTo);
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
    /// Compare to another Current object
    /// </summary>
    /// <param name="obj">The other Current cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Current current)
        {
            return Value.CompareTo(current.Value);
        }

        throw new ArgumentException("Object is not a Current");
    }
}