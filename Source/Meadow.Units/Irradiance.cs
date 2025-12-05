using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents the radiant flux received by a surface per unit area.
/// The SI unit of irradiance is the watt per square meter (W/m²)
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Irradiance :
    IUnit<Irradiance, Irradiance.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Irradiance _zero;

    static Irradiance()
    {
        _zero = new Irradiance(0, UnitType.WattsPerSquareMeter);
    }

    /// <summary>
    /// Gets an irradiance of 0 W/m²
    /// </summary>
    public static Irradiance Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Irradiance"/> object.
    /// </summary>
    /// <param name="value">The Irradiance value.</param>
    /// <param name="type">WattsPerSquareMeter by default.</param>
    public Irradiance(double value, UnitType type = UnitType.WattsPerSquareMeter)
    {
        Value = IrradianceConversions.Convert(value, type, UnitType.WattsPerSquareMeter);
    }

    /// <summary>
    /// Creates a new <see cref="Irradiance"/> object from an existing Irradiance object
    /// </summary>
    /// <param name="irradiance"></param>
    public Irradiance(Irradiance irradiance)
    {
        Value = irradiance.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Irradiance.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Watts per square meter </summary>
        WattsPerSquareMeter,
        /// <summary> Kilowatts per square meter </summary>
        KilowattsPerSquareMeter,
        /// <summary> Milliwatts per square meter </summary>
        MilliwattsPerSquareMeter,
        /// <summary> Microwatts per square meter </summary>
        MicrowattsPerSquareMeter,
        /// <summary> Watts per square centimeter </summary>
        WattsPerSquareCentimeter,
        /// <summary> Milliwatts per square centimeter </summary>
        MilliwattsPerSquareCentimeter,
    }

    /// <summary>
    /// Creates an Irradiance instance from a canonical (WattsPerSquareMeter) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Irradiance FromCanonical(double value)
    {
        return new Irradiance(value, UnitType.WattsPerSquareMeter);
    }

    /// <summary>
    /// Gets the value of the Irradiance in Canonical (WattsPerSquareMeter) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.WattsPerSquareMeter;

    /// <summary> Get irradiance in watts per square meter </summary>
    public double WattsPerSquareMeter => From(UnitType.WattsPerSquareMeter);
    /// <summary> Get irradiance in kilowatts per square meter </summary>
    public double KilowattsPerSquareMeter => From(UnitType.KilowattsPerSquareMeter);
    /// <summary> Get irradiance in milliwatts per square meter </summary>
    public double MilliwattsPerSquareMeter => From(UnitType.MilliwattsPerSquareMeter);
    /// <summary> Get irradiance in microwatts per square meter </summary>
    public double MicrowattsPerSquareMeter => From(UnitType.MicrowattsPerSquareMeter);
    /// <summary> Get irradiance in watts per square centimeter </summary>
    public double WattsPerSquareCentimeter => From(UnitType.WattsPerSquareCentimeter);
    /// <summary> Get irradiance in milliwatts per square centimeter </summary>
    public double MilliwattsPerSquareCentimeter => From(UnitType.MilliwattsPerSquareCentimeter);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return IrradianceConversions.Convert(Value, UnitType.WattsPerSquareMeter, convertTo);
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
    /// Compare to another Irradiance object
    /// </summary>
    /// <param name="obj">The other Irradiance cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Irradiance irradiance)
        {
            return Value.CompareTo(irradiance.Value);
        }

        throw new ArgumentException("Object is not an Irradiance");
    }
}
