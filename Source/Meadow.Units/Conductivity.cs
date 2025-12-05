using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Conductivity.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Conductivity :
    IUnit<Conductivity, Conductivity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Conductivity _zero;

    static Conductivity()
    {
        _zero = new Conductivity(0, UnitType.SiemensPerCentimeter);
    }

    /// <summary>
    /// Gets a Conductivity of 0 SiemensPerCentimeter
    /// </summary>
    public static Conductivity Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Conductivity"/> object.
    /// </summary>
    /// <param name="value">The Conductivity value.</param>
    /// <param name="type">SiemensPerCentimeter by default.</param>
    public Conductivity(double value, UnitType type = UnitType.SiemensPerCentimeter)
    {
        Value = ConductivityConversions.Convert(value, type, UnitType.SiemensPerCentimeter);
    }

    /// <summary>
    /// Creates a new <see cref="Conductivity"/> object from an existing Conductivity object
    /// </summary>
    /// <param name="Conductivity"></param>
    public Conductivity(Conductivity Conductivity)
    {
        Value = Conductivity.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Conductivity.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Siemens per centimeter (S/cm)
        /// </summary>
        SiemensPerCentimeter,
        /// <summary>
        /// Siemens per 
        /// </summary>
        SiemensPerMeter,
        /// <summary>
        /// Milli siemens per centimeter (mS/cm)
        /// </summary>
        MilliSiemensPerCentimeter,
        /// <summary>
        /// Milli siemens per meter (mS/m)
        /// </summary>
        MilliSiemensPerMeter,
        /// <summary>
        /// Micro siemens per centimeter (uS/vm)
        /// </summary>
        MicroSiemensPerCentimeter,
        /// <summary>
        /// Micro siemens per meter (uS/m)
        /// </summary>
        MicroSiemensPerMeter,
    }

    /// <summary>
    /// Creates a Conductivity instance from a canonical (SiemensPerCentimeter) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Conductivity FromCanonical(double value)
    {
        return new Conductivity(value, UnitType.SiemensPerCentimeter);
    }

    /// <summary>
    /// Gets the value of the Conductivity in Canonical (SiemensPerCentimeter) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.SiemensPerCentimeter;

    /// <summary>
    /// Get Conductivity in Siemens Per Centimeter
    /// </summary>
    public double SiemensPerCentimeter => From(UnitType.SiemensPerCentimeter);

    /// <summary>
    /// Get Conductivity in Siemens Per Meter
    /// </summary>
    public double SiemensPerMeter => From(UnitType.SiemensPerMeter);

    /// <summary>
    /// Get Conductivity in MilliSiemens Per Centimeter
    /// </summary>
    public double MilliSiemensPerCentimeter => From(UnitType.MilliSiemensPerCentimeter);

    /// <summary>
    /// Get Conductivity in MilliSiemens Per Meter
    /// </summary>
    public double MilliSiemensPerMeter => From(UnitType.MilliSiemensPerMeter);

    /// <summary>
    /// Get Conductivity in Micro Siemens Per Centimeter
    /// </summary>
    public double MicroSiemensPerCentimeter => From(UnitType.MicroSiemensPerCentimeter);

    /// <summary>
    /// Get Conductivity in Micro Siemens PerMeter
    /// </summary>
    public double MicroSiemensPerMeter => From(UnitType.MicroSiemensPerMeter);

    /// <summary>
    /// Convert to a specific unit
    /// </summary>
    /// <param name="convertTo">the unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ConductivityConversions.Convert(Value, UnitType.SiemensPerCentimeter, convertTo);
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
    /// Compare to another Conductivity object
    /// </summary>
    /// <param name="obj">The other Conductivity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Conductivity conductivity)
        {
            return Value.CompareTo(conductivity.Value);
        }

        throw new ArgumentException("Object is not a Conductivity");
    }
}