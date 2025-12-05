using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents MagneticField
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct MagneticField :
    IUnit<MagneticField, MagneticField.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="MagneticField"/> object.
    /// </summary>
    /// <param name="value">The MagneticField value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public MagneticField(double value, UnitType type = UnitType.Tesla)
    {
        Value = MagneticFieldConversions.Convert(value, type, UnitType.Tesla);
    }

    /// <summary>
    /// Creates a new <see cref="MagneticField"/> object from an existing MagneticField object
    /// </summary>
    /// <param name="magneticField"></param>
    public MagneticField(MagneticField magneticField)
    {
        Value = magneticField.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the MagneticField.
    /// </summary>
    public enum UnitType
    {
        /// <summary> MegaTelsa </summary>
        MegaTesla,
        /// <summary> KiloTesla </summary>
        KiloTesla,
        /// <summary> Tesla </summary>
        Tesla,
        /// <summary> MilliTesla </summary>
        MilliTesla,
        /// <summary> MicroTesla </summary>
        MicroTesla,
        /// <summary> NanoTesla </summary>
        NanoTesla,
        /// <summary> PicoTesla </summary>
        PicoTesla,
        /// <summary> Gauss </summary>
        Gauss
    }

    /// <summary>
    /// Creates a MagneticField instance from a canonical (Tesla) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MagneticField FromCanonical(double value)
    {
        return new MagneticField(value, UnitType.Tesla);
    }

    /// <summary>
    /// Gets the value of the MagneticField in Canonical (Tesla) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Tesla;

    /// <summary>
    /// Get the magnetic field value as MegaTesla
    /// </summary>
    public double MegaTesla => From(UnitType.MegaTesla);
    /// <summary>
    /// Get the magnetic field value as KiloTesla
    /// </summary>
    public double KiloTesla => From(UnitType.KiloTesla);
    /// <summary>
    /// Get the magnetic field value as Tesla
    /// </summary>
    public double Tesla => From(UnitType.Tesla);
    /// <summary>
    /// Get the magnetic field value as MilliTesla
    /// </summary>
    public double MilliTesla => From(UnitType.MilliTesla);
    /// <summary>
    /// Get the magnetic field value as MicroTesla
    /// </summary>
    public double MicroTesla => From(UnitType.MicroTesla);
    /// <summary>
    /// Get the magnetic field value as NanoTesla
    /// </summary>
    public double NanoTesla => From(UnitType.NanoTesla);
    /// <summary>
    /// Get the magnetic field value as PicoTesla
    /// </summary>
    public double PicoTesla => From(UnitType.PicoTesla);
    /// <summary>
    /// Get the magnetic field value as Gauss
    /// </summary>
    public double Gauss => From(UnitType.Gauss);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return MagneticFieldConversions.Convert(Value, UnitType.Tesla, convertTo);
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
    /// Compare to another MagneticField object
    /// </summary>
    /// <param name="obj">The other MagneticField cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is MagneticField magneticField)
        {
            return Value.CompareTo(magneticField.Value);
        }

        throw new ArgumentException("Object is not a MagneticField");
    }
}