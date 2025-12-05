using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Torque
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Torque :
    IUnit<Torque, Torque.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Torque"/> object.
    /// </summary>
    /// <param name="value">The Torque value.</param>
    /// <param name="type">kilometers meters per second by default.</param>
    public Torque(double value, UnitType type = UnitType.NewtonMeter)
    {
        Value = TorqueConversions.Convert(value, type, UnitType.NewtonMeter);
    }

    /// <summary>
    /// Creates a new <see cref="Torque"/> object from an existing Torque object
    /// </summary>
    /// <param name="torque"></param>
    public Torque(Torque torque)
    {
        Value = torque.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Torque.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Newton meters </summary>
        NewtonMeter,
        /// <summary> Foot pounds </summary>
        FootPound,
        /// <summary> Kilogram meters </summary>
        KilogramMeter,
        /// <summary> Kilogram centimeters </summary>
        KilogramCentimeter,
        /// <summary> Gram centimeters </summary>
        GramCentimeter,
        /// <summary> Inch pounds </summary>
        InchPound,
        /// <summary> Inch ounces </summary>
        InchOunce,
        /// <summary> Dyne centimeters </summary>
        DyneCentimeter
    }

    /// <summary>
    /// Creates a Torque instance from a canonical (NewtonMeter) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Torque FromCanonical(double value)
    {
        return new Torque(value, UnitType.NewtonMeter);
    }

    /// <summary>
    /// Gets the value of the Torque in Canonical (NewtonMeter) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.NewtonMeter;

    /// <summary>
    /// Get torque in newton meters
    /// </summary>
    public double NewtonMeter => From(UnitType.NewtonMeter);

    /// <summary>
    /// Get torque in foot pounds
    /// </summary>
    public double FootPound => From(UnitType.FootPound);

    /// <summary>
    /// Get torque in kilogram meters
    /// </summary>
    public double KilogramMeter => From(UnitType.KilogramMeter);

    /// <summary>
    /// Get torque in kilogram centimeters
    /// </summary>
    public double KilogramCentimeter => From(UnitType.KilogramCentimeter);

    /// <summary>
    /// Get torque in gram centimeters
    /// </summary>
    public double GramCentimeter => From(UnitType.GramCentimeter);

    /// <summary>
    /// Get torque in inch pounds
    /// </summary>
    public double InchPound => From(UnitType.InchPound);

    /// <summary>
    /// Get torque in inch ounces
    /// </summary>
    public double InchOunce => From(UnitType.InchOunce);

    /// <summary>
    /// Get torque in dyne centimeters
    /// </summary>
    public double DyneCentimeter => From(UnitType.DyneCentimeter);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to covert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return TorqueConversions.Convert(Value, UnitType.NewtonMeter, convertTo);
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
    /// Compare to another Torque object
    /// </summary>
    /// <param name="obj">The other Torque cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Torque torque)
        {
            return Value.CompareTo(torque.Value);
        }

        throw new ArgumentException("Object is not a Torque");
    }
}