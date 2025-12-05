using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Reactive Energy
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct ReactiveEnergy :
    IUnit<ReactiveEnergy, ReactiveEnergy.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ReactiveEnergy"/> object.
    /// </summary>
    /// <param name="value">The ReactiveEnergy value.</param>
    /// <param name="type">Volt Amphere Hours by default.</param>
    public ReactiveEnergy(double value, UnitType type = UnitType.VoltAmpereHours)
    {
        Value = ReactiveEnergyConversions.Convert(value, type, UnitType.VoltAmpereHours);
    }

    /// <summary>
    /// Creates a new <see cref="ReactiveEnergy"/> object from an existingReactiveEnergy object
    /// </summary>
    /// <param name="reactiveEnergy"></param>
    public ReactiveEnergy(ReactiveEnergy reactiveEnergy)
    {
        Value = reactiveEnergy.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe ReactiveEnergy.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Gigavolt Ampere hours
        /// </summary>
        GigavoltAmpereHours,
        /// <summary>
        /// Megavolt Ampere hours
        /// </summary>
        MegavoltAmpereHours,
        /// <summary>
        /// Kilovolt Ampere hours
        /// </summary>
        KilovoltAmpereHours,
        /// <summary>
        /// Volt Ampere hours
        /// </summary>
        VoltAmpereHours,
        /// <summary>
        /// Millivolt Ampere hours
        /// </summary>
        MillivoltAmpereHours,
    }

    /// <summary>
    /// Creates a ReactiveEnergy instance from a canonical (VoltAmpereHours) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ReactiveEnergy FromCanonical(double value)
    {
        return new ReactiveEnergy(value, UnitType.VoltAmpereHours);
    }

    /// <summary>
    /// Gets the value of the ReactiveEnergy in Canonical (VoltAmpereHours) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.VoltAmpereHours;

    /// <summary>
    ///ReactiveEnergy in Millovolt Ampere Hours
    /// </summary>
    public double MillivoltAmpereHours => From(UnitType.MillivoltAmpereHours);

    /// <summary>
    ///ReactiveEnergy in Volt Ampere Hours
    /// </summary>
    public double VoltAmpereHours => From(UnitType.VoltAmpereHours);

    /// <summary>
    ///ReactiveEnergy in Kilvolt Ampere Hours
    /// </summary>
    public double KilovoltAmpereHours => From(UnitType.KilovoltAmpereHours);

    /// <summary>
    ///ReactiveEnergy in Megavolt Ampere Hours
    /// </summary>
    public double MegavoltAmpereHours => From(UnitType.MegavoltAmpereHours);

    /// <summary>
    ///ReactiveEnergy in Gigavolt Ampere Hours
    /// </summary>
    public double GigavoltAmpereHours => From(UnitType.GigavoltAmpereHours);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ReactiveEnergyConversions.Convert(Value, UnitType.VoltAmpereHours, convertTo);
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
    /// Compare to another ReactiveEnergy object
    /// </summary>
    /// <param name="obj">The other ReactiveEnergy cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ReactiveEnergy reactiveEnergy)
        {
            return Value.CompareTo(reactiveEnergy.Value);
        }

        throw new ArgumentException("Object is not a ReactiveEnergy");
    }
}