using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Density
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Density :
    IUnit<Density, Density.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Density"/> object.
    /// </summary>
    /// <param name="value">The Density value.</param>
    /// <param name="type">Kilograms per meters cubed by default.</param>
    public Density(double value, UnitType type = UnitType.KilogramsPerMetersCubed)
    {
        Value = DensityConversions.Convert(value, type, UnitType.KilogramsPerMetersCubed);
    }

    /// <summary>
    /// Creates a new <see cref="Density"/> object from an existing Density object
    /// </summary>
    /// <param name="density"></param>
    public Density(Density density)
    {
        Value = density.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Density.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Grams per meters cubed
        /// </summary>
        MicroGramsPerMetersCubed,
        /// <summary>
        /// Grams per meters cubed
        /// </summary>
        MilliGramsPerMetersCubed,
        /// <summary>
        /// Grams per centimeters cubed
        /// </summary>
        GramsPerCentimetersCubed,
        /// <summary>
        /// Grams per meters cubed
        /// </summary>
        GramsPerMetersCubed,
        /// <summary>
        /// Grams per liter
        /// </summary>
        GramsPerLiter,
        /// <summary>
        /// Kilograms per meters cubed
        /// </summary>
        KilogramsPerMetersCubed,
        /// <summary>
        /// Ounces per inches cubed
        /// </summary>
        OuncesPerInchesCubed,
        /// <summary>
        /// Ounces per feet cubed
        /// </summary>
        OuncesPerFeetCubed,
        /// <summary>
        /// Pounds per inches cubed
        /// </summary>
        PoundsPerInchesCubed,
        /// <summary>
        /// Pounds per feet cubed
        /// </summary>
        PoundsPerFeetCubed,
        /// <summary>
        /// Density of water
        /// </summary>
        Water
    }

    /// <summary>
    /// Creates a Density instance from a canonical (KilogramsPerMetersCubed) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Density FromCanonical(double value)
    {
        return new Density(value, UnitType.KilogramsPerMetersCubed);
    }

    /// <summary>
    /// Gets the value of the Density in Canonical (KilogramsPerMetersCubed) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.KilogramsPerMetersCubed;

    /// <summary>
    /// Get the density in micrograms per meters cubed
    /// </summary>
    public double MicroGramsPerMetersCubed => From(UnitType.MicroGramsPerMetersCubed);
    /// <summary>
    /// Get the density in milligrams per meters cubed
    /// </summary>
    public double MilliGramsPerMetersCubed => From(UnitType.MilliGramsPerMetersCubed);
    /// <summary>
    /// Get the density in grams per centimeters cubed
    /// </summary>
    public double GramsPerCentimetersCubed => From(UnitType.GramsPerCentimetersCubed);
    /// <summary>
    /// Get the density in grams per meters cubed
    /// </summary>
    public double GramsPerMetersCubed => From(UnitType.GramsPerMetersCubed);
    /// <summary>
    /// Get the density in grams per liter cubed
    /// </summary>
    public double GramsPerLiter => From(UnitType.GramsPerLiter);
    /// <summary>
    /// Get the density in kilograms per meters cubed
    /// </summary>
    public double KilogramsPerMetersCubed => From(UnitType.KilogramsPerMetersCubed);
    /// <summary>
    /// Get the density in ounces per inches cubed
    /// </summary>
    public double OuncesPerInchesCubed => From(UnitType.OuncesPerInchesCubed);
    /// <summary>
    /// Get the density in ounces per feet cubed
    /// </summary>
    public double OuncesPerFeetCubed => From(UnitType.OuncesPerFeetCubed);
    /// <summary>
    /// Get the density in pounds per inches cubed
    /// </summary>
    public double PoundsPerInchesCubed => From(UnitType.PoundsPerInchesCubed);
    /// <summary>
    /// Get the density in pounds per feet cubed
    /// </summary>
    public double PoundsPerFeetCubed => From(UnitType.PoundsPerFeetCubed);
    /// <summary>
    /// Get the density relative to water
    /// </summary>
    public double Water => From(UnitType.Water);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return DensityConversions.Convert(Value, UnitType.KilogramsPerMetersCubed, convertTo);
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
    /// Compare to another Density object
    /// </summary>
    /// <param name="obj">The other Density cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Density density)
        {
            return Value.CompareTo(density.Value);
        }

        throw new ArgumentException("Object is not a Density");
    }
}