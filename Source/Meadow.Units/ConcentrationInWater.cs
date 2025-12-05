using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Concentration in water
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct ConcentrationInWater :
    IUnit<ConcentrationInWater, ConcentrationInWater.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly ConcentrationInWater _zero;

    static ConcentrationInWater()
    {
        _zero = new ConcentrationInWater(0, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Gets a ConcentrationInWater of 0
    /// </summary>
    public static ConcentrationInWater Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="ConcentrationInWater"/> object.
    /// </summary>
    /// <param name="value">The ConcentrationInWater value.</param>
    /// <param name="type">Parts Per Million by default.</param>
    public ConcentrationInWater(double value, UnitType type = UnitType.PartsPerMillion)
    {
        Value = ConcentrationInWaterConversions.Convert(value, type, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Creates a copy of a ConcentrationInWater object.
    /// </summary>
    /// <param name="concentration">ConcentrationInWater to copy</param>
    public ConcentrationInWater(ConcentrationInWater concentration)
    {
        Value = concentration.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the ConcentrationInWater.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Parts per 100
        /// </summary>
        PartsPerHundred,
        /// <summary>
        /// Parts per 1,000
        /// </summary>
        PartsPerThousand,
        /// <summary>
        /// Parts per 1,000,000
        /// </summary>
        PartsPerMillion,
        /// <summary>
        /// Milligrams per liter (mg/L)
        /// </summary>
        MilligramsPerLiter,
        /// <summary>
        /// Grams per cubic meter (g/m^3)
        /// </summary>
        GramsPerCubicMeter,
        /// <summary>
        /// Parts per 1,000,000,000
        /// </summary>
        PartsPerBillion,
        /// <summary>
        /// Micrograms per liter (ug/L)
        /// </summary>
        MicrogramsPerLiter,
        /// <summary>
        /// Parts per 1,000,000,000,000
        /// </summary>
        PartsPerTrillion,
        /// <summary>
        /// Grams per liter (g/L)
        /// </summary>
        GramsPerLiter,
        /// <summary>
        /// Kilograms per liter (kg/L)
        /// </summary>
        KilogramsPerLiter,
    }

    /// <summary>
    /// Creates a ConcentrationInWater instance from a canonical (PartsPerMillion) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ConcentrationInWater FromCanonical(double value)
    {
        return new ConcentrationInWater(value, UnitType.PartsPerMillion);
    }

    /// <summary>
    /// Gets the value of the ConcentrationInWater in Canonical (PartsPerMillion) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.PartsPerMillion;

    /// <summary>
    /// Get ConcentrationInWater in parts per 100
    /// </summary>
    public double PartsPerHundred => From(UnitType.PartsPerHundred);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1000
    /// </summary>
    public double PartsPerThousand => From(UnitType.PartsPerThousand);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000
    /// </summary>
    public double PartsPerMillion => From(UnitType.PartsPerMillion);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000,000
    /// </summary>
    public double PartsPerBillion => From(UnitType.PartsPerBillion);
    /// <summary>
    /// Get ConcentrationInWater in parts per 1,000,000,000,000
    /// </summary>
    public double PartsPerTrillion => From(UnitType.PartsPerTrillion);
    /// <summary>
    /// Get ConcentrationInWater in Grams Per Cubic Meter
    /// </summary>
    public double GramsPerCubicMeter => From(UnitType.GramsPerCubicMeter);
    /// <summary>
    /// Get ConcentrationInWater in Micrograms Per Liter
    /// </summary>
    public double MicrogramsPerLiter => From(UnitType.MicrogramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double MilligramsPerLiter => From(UnitType.MilligramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double GramsPerLiter => From(UnitType.GramsPerLiter);
    /// <summary>
    /// Get ConcentrationInWater in Milligrams Per Liter
    /// </summary>
    public double KilogramsPerLiter => From(UnitType.KilogramsPerLiter);

    /// <summary>
    /// Get ConcentrationInWater for a specific unit
    /// </summary>
    /// <param name="convertTo">unit</param>
    /// <returns>value as a double</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ConcentrationInWaterConversions.Convert(Value, UnitType.PartsPerMillion, convertTo);
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
    /// Compare to another ConcentrationInWater object
    /// </summary>
    /// <param name="obj">The other ConcentrationInWater cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ConcentrationInWater concentrationInWater)
        {
            return Value.CompareTo(concentrationInWater.Value);
        }

        throw new ArgumentException("Object is not a ConcentrationInWater");
    }
}