using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Apparent Power 
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct ApparentPower :
    IUnit<ApparentPower, ApparentPower.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ApparentPower"/> object.
    /// </summary>
    /// <param name="value">The ApparentPower value.</param>
    /// <param name="type">Volt Amperes by default.</param>
    public ApparentPower(double value, UnitType type = UnitType.VoltAmperes)
    {
        Value = ApparentPowerConversions.Convert(value, type, UnitType.VoltAmperes);
    }

    /// <summary>
    /// Creates a new <see cref="ApparentPower"/> object from an existing ApparentPower object
    /// </summary>
    /// <param name="reactivePower"></param>
    public ApparentPower(ApparentPower reactivePower)
    {
        Value = reactivePower.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe ApparentPower.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Gigavolt Ampere
        /// </summary>
        GigavoltAmperes,
        /// <summary>
        /// Megavolt Ampere
        /// </summary>
        MegavoltAmperes,
        /// <summary>
        /// Kilovolt Ampere
        /// </summary>
        KilovoltAmperes,
        /// <summary>
        /// Volt Ampere
        /// </summary>
        VoltAmperes,
        /// <summary>
        /// Millivolt Ampere
        /// </summary>
        MillivoltAmperes,
    }

    /// <summary>
    /// Creates an ApparentPower instance from a canonical (VoltAmperes) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ApparentPower FromCanonical(double value)
    {
        return new ApparentPower(value, UnitType.VoltAmperes);
    }

    /// <summary>
    /// Gets the value of the ApparentPower in Canonical (VoltAmperes) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.VoltAmperes;

    /// <summary>
    ///ApparentPower in Millovolt Amperes
    /// </summary>
    public double MillivoltAmperes => From(UnitType.MillivoltAmperes);

    /// <summary>
    ///ApparentPower in Volt Amperes
    /// </summary>
    public double VoltAmperes => From(UnitType.VoltAmperes);

    /// <summary>
    ///ApparentPower in Kilvolt Amperes
    /// </summary>
    public double KilovoltAmperes => From(UnitType.KilovoltAmperes);

    /// <summary>
    ///ApparentPower in Megavolt Amperes
    /// </summary>
    public double MegavoltAmperes => From(UnitType.MegavoltAmperes);

    /// <summary>
    ///ApparentPower in Gigavolt Amperes
    /// </summary>
    public double GigavoltAmperes => From(UnitType.GigavoltAmperes);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ApparentPowerConversions.Convert(Value, UnitType.VoltAmperes, convertTo);
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
    /// Compare to another ApparentPower object
    /// </summary>
    /// <param name="obj">The other ApparentPower cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ApparentPower apparentPower)
        {
            return Value.CompareTo(apparentPower.Value);
        }

        throw new ArgumentException("Object is not an ApparentPower");
    }
}