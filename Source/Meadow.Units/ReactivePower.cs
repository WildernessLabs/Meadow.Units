using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Reactive Power
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct ReactivePower :
    IUnit<ReactivePower, ReactivePower.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ReactivePower"/> object.
    /// </summary>
    /// <param name="value">The ReactivePower value.</param>
    /// <param name="type">Volt Amperes by default.</param>
    public ReactivePower(double value, UnitType type = UnitType.VoltAmperes)
    {
        Value = ReactivePowerConversions.Convert(value, type, UnitType.VoltAmperes);
    }

    /// <summary>
    /// Creates a new <see cref="ReactivePower"/> object from an existingReactivePower object
    /// </summary>
    /// <param name="reactivePower"></param>
    public ReactivePower(ReactivePower reactivePower)
    {
        Value = reactivePower.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe ReactivePower.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Gigavolt Ampere </summary>
        GigavoltAmperes,
        /// <summary> Megavolt Ampere </summary>
        MegavoltAmperes,
        /// <summary> Kilovolt Ampere </summary>
        KilovoltAmperes,
        /// <summary> Volt Ampere </summary>
        VoltAmperes,
        /// <summary> Millivolt Ampere </summary>
        MillivoltAmperes,
    }

    /// <summary>
    /// Creates a ReactivePower instance from a canonical (VoltAmperes) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ReactivePower FromCanonical(double value)
    {
        return new ReactivePower(value, UnitType.VoltAmperes);
    }

    /// <summary>
    /// Gets the value of the ReactivePower in Canonical (VoltAmperes) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.VoltAmperes;

    /// <summary>
    ///ReactivePower in Millovolt Amperes
    /// </summary>
    public double MillivoltAmperes => From(UnitType.MillivoltAmperes);

    /// <summary>
    ///ReactivePower in Volt Amperes
    /// </summary>
    public double VoltAmperes => From(UnitType.VoltAmperes);

    /// <summary>
    ///ReactivePower in Kilvolt Amperes
    /// </summary>
    public double KilovoltAmperes => From(UnitType.KilovoltAmperes);

    /// <summary>
    ///ReactivePower in Megavolt Amperes
    /// </summary>
    public double MegavoltAmperes => From(UnitType.MegavoltAmperes);

    /// <summary>
    ///ReactivePower in Gigavolt Amperes
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
        return ReactivePowerConversions.Convert(Value, UnitType.VoltAmperes, convertTo);
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
    /// Compare to another ReactivePower object
    /// </summary>
    /// <param name="obj">The otherReactivePower cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ReactivePower reactivePower)
        {
            return Value.CompareTo(reactivePower.Value);
        }

        throw new ArgumentException("Object is not a ReactivePower");
    }
}