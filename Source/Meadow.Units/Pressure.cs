using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents pressure; the force applied perpendicular to the surface of
/// an object per unit area over which that force is distributed.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Pressure :
    IUnit<Pressure, Pressure.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Pressure"/> object.
    /// </summary>
    /// <param name="value">The pressure value.</param>
    /// <param name="type">_Bar_ (`Bar`), by default.</param>
    public Pressure(double value, UnitType type = UnitType.Bar)
    {
        Value = PressureConversions.Convert(value, type, UnitType.Bar);
    }

    /// <summary>
    /// Creates a new <see cref="Pressure"/> object from an existing Pressure object
    /// </summary>
    /// <param name="pressure"></param>
    public Pressure(Pressure pressure)
    {
        Value = pressure.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Pressure.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Bar </summary>
        Bar,
        /// <summary> Pascal </summary>
        Pascal,
        /// <summary> Psi </summary>
        Psi,
        /// <summary> Standard atmospheric pressure </summary>
        StandardAtmosphere,
        /// <summary> Millibar </summary>
        Millibar,
        /// <summary> Hectopascal </summary>
        Hectopascal,
        /// <summary> Kilopascal </summary>
        KiloPascal
    }

    /// <summary>
    /// Creates a Pressure instance from a canonical (Bar) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Pressure FromCanonical(double value)
    {
        // Assuming Celsius is your canonical form
        return new Pressure(value, UnitType.Bar);
    }

    /// <summary>
    /// Gets the value of the Pressure in Canonical (Bar) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        // Return the internal value which is already in Celsius
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Bar;

    /// <summary>
    /// Gets the pressure value expressed as a unit _Bar_ (`Bar`)
    /// </summary>
    public double Bar => Value;

    /// <summary>
    /// Gets the pressure value expressed as a unit _Pascal_ (`Pa`).
    /// </summary>
    public double Pascal => From(UnitType.Pascal);

    /// <summary>
    /// Gets the pressure value expressed as a unit _Pound-force per square inch_ (`Psi`).
    /// </summary>
    public double Psi => From(UnitType.Psi);

    /// <summary>
    /// Gets the pressure value expressed as a unit _Standard Atmosphere_ (`At`).
    /// </summary>
    public double StandardAtmosphere => From(UnitType.StandardAtmosphere);

    /// <summary>
    /// Gets the pressure value expressed as a unit _Bar_ (`Bar`)
    /// </summary>
    public double Millibar => From(UnitType.Millibar);

    /// <summary>
    /// Gets the pressure value expressed as a unit _Bar_ (`Bar`)
    /// </summary>
    public double Hectopascal => From(UnitType.Hectopascal);

    /// <summary>
    /// Get pressure value for a specific unit
    /// </summary>
    /// <param name="convertTo">the pressure unit</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return PressureConversions.Convert(Value, UnitType.Bar, convertTo);
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
    /// Compare to another Pressure object
    /// </summary>
    /// <param name="obj">The other Pressure cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Pressure pressure)
        {
            return Value.CompareTo(pressure.Value);
        }

        throw new ArgumentException("Object is not a Pressure");
    }
}