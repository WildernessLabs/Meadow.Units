using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Illuminance
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Illuminance :
    IUnit<Illuminance, Illuminance.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Illuminance _zero;

    static Illuminance()
    {
        _zero = new Illuminance(0, UnitType.Lux);
    }

    /// <summary>
    /// Gets a voltage of 0 Volts
    /// </summary>
    public static Illuminance Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Illuminance"/> object.
    /// </summary>
    /// <param name="value">The Illuminance value.</param>
    /// <param name="type">Lux by default.</param>
    public Illuminance(double value, UnitType type = UnitType.Lux)
    {
        Value = IlluminanceConversions.Convert(value, type, UnitType.Lux);
    }

    /// <summary>
    /// Creates a new <see cref="Illuminance"/> object from an existing Illuminance object
    /// </summary>
    /// <param name="illuminance"></param>
    public Illuminance(Illuminance illuminance)
    {
        Value = illuminance.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Illuminance.
    /// </summary>
    public enum UnitType
    {
        /// <summary> KiloLux </summary>
        KiloLux,
        /// <summary> Lux </summary>
        Lux,
        /// <summary> Foot candles </summary>
        FootCandles,
    }

    /// <summary>
    /// Creates an Illuminance instance from a canonical (Lux) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Illuminance FromCanonical(double value)
    {
        return new Illuminance(value, UnitType.Lux);
    }

    /// <summary>
    /// Gets the value of the Illuminance in Canonical (Lux) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Lux;

    /// <summary>
    /// Get illuminance value as kiloLux
    /// </summary>
    public double KiloLux => From(UnitType.KiloLux);
    /// <summary>
    /// Get illuminance value as Lux
    /// </summary>
    public double Lux => From(UnitType.Lux);
    /// <summary>
    /// Get illuminance value as foot candles
    /// </summary>
    public double FootCandles => From(UnitType.FootCandles);

    /// <summary>
    /// Get illuminance value for a given unit
    /// </summary>
    /// <param name="convertTo">unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return IlluminanceConversions.Convert(Value, UnitType.Lux, convertTo);
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
    /// Compare to another Illuminance object
    /// </summary>
    /// <param name="obj">The other Illuminance cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Illuminance illuminance)
        {
            return Value.CompareTo(illuminance.Value);
        }

        throw new ArgumentException("Object is not an Illuminance");
    }
}