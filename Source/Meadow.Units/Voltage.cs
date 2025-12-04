using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Potential, or _Voltage_.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Voltage :
    IUnit<Voltage, Voltage.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Voltage _zero;

    static Voltage()
    {
        _zero = new Voltage(0, UnitType.Volts);
    }

    /// <summary>
    /// Gets a voltage of 0 Volts
    /// </summary>
    public static Voltage Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Voltage"/> object.
    /// </summary>
    /// <param name="value">The Voltage value.</param>
    /// <param name="type">Volts by default.</param>
    public Voltage(double value, UnitType type = UnitType.Volts)
    {
        Value = VoltageConversions.Convert(value, type, UnitType.Volts);
    }

    /// <summary>
    /// Creates a new <see cref="Voltage"/> object from an existing Voltage object
    /// </summary>
    /// <param name="voltage"></param>
    public Voltage(Voltage voltage)
    {
        Value = voltage.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Voltage.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Volts </summary>
        Volts,
        /// <summary> Millivolts </summary>
        Millivolts,
        /// <summary> Microvolts </summary>
        Microvolts,
        /// <summary> Kilovolts </summary>
        Kilovolts,
        /// <summary> Megavolts </summary>
        Megavolts,
        /// <summary> Gigavolts </summary>
        Gigavolts,
        /// <summary> Statvolts </summary>
        Statvolts,
        /// <summary> Nanovolts </summary>
        Nanovolts,
    }

    /// <summary>
    /// Creates a Voltage instance from a canonical (Volts) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Voltage FromCanonical(double value)
    {
        return new Voltage(value, UnitType.Volts);
    }

    /// <summary>
    /// Gets the value of the Voltage in Canonical (Volts) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Volts;

    /// <summary> Get voltage in volts </summary>
    public double Volts => From(UnitType.Volts);
    /// <summary> Get voltage in millivolts </summary>
    public double Millivolts => From(UnitType.Millivolts);
    /// <summary> Get voltage in microvolts </summary>
    public double Microvolts => From(UnitType.Microvolts);
    /// <summary> Get voltage in kilovolts </summary>
    public double Kilovolts => From(UnitType.Kilovolts);
    /// <summary> Get voltage in megavolts </summary>
    public double Megavolts => From(UnitType.Megavolts);
    /// <summary> Get voltage in gigavolts </summary>
    public double Gigavolts => From(UnitType.Gigavolts);
    /// <summary> Get voltage in statvolts </summary>
    public double Statvolts => From(UnitType.Statvolts);
    /// <summary> Get voltage in nanovolts </summary>
    public double Nanovolts => From(UnitType.Nanovolts);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return VoltageConversions.Convert(Value, UnitType.Volts, convertTo);
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
    /// Compare to another Voltage object
    /// </summary>
    /// <param name="obj">The other Voltage cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Voltage voltage)
        {
            return Value.CompareTo(voltage.Value);
        }

        throw new ArgumentException("Object is not a Voltage");
    }
}