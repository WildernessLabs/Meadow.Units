using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Electric Charge.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Charge :
    IUnit<Charge, Charge.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Charge"/> object.
    /// </summary>
    /// <param name="value">The Charge value.</param>
    /// <param name="type">Coulombs by default.</param>
    public Charge(double value, UnitType type = UnitType.Coulombs)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new <see cref="Charge"/> object from an existing Charge object
    /// </summary>
    /// <param name="Charge"></param>
    public Charge(Charge Charge)
    {
        Value = Charge.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The Charge in coulombs
    /// </summary>
    public double Coulombs => Value;

    /// <summary>
    /// The type of units available to describe the Charge.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// coulombs
        /// </summary>
        Coulombs
    }

    /// <summary>
    /// Creates a Charge instance from a canonical (Coulombs) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Charge FromCanonical(double value)
    {
        return new Charge(value, UnitType.Coulombs);
    }

    /// <summary>
    /// Gets the value of the Charge in Canonical (Coulombs) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Coulombs;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Coulombs;

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => Coulombs.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Coulombs.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Charge object
    /// </summary>
    /// <param name="obj">The other Charge cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Charge charge)
        {
            return Coulombs.CompareTo(charge.Coulombs);
        }

        throw new ArgumentException("Object is not a Charge");
    }
}