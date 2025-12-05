using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents Turbidity (NTU)
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Turbidity :
    IUnit<Turbidity, Turbidity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="Turbidity"/> object.
    /// </summary>
    /// <param name="value">The Turbidity value.</param>
    /// <param name="type">Turbidity unit.</param>
    public Turbidity(double value, UnitType type = UnitType.NTU)
    {
        if (value < 0) throw new ArgumentOutOfRangeException($"Turbidity cannot be less than 0");
        NTU = value;
    }

    /// <summary>
    /// Creates a new <see cref="Turbidity"/> object from an existing Turbidity object
    /// </summary>
    /// <param name="Turbidity"></param>
    public Turbidity(Turbidity Turbidity)
    {
        NTU = Turbidity.NTU;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The Turbidity expressed as Nephelometric Turbidity Units (NTU)
    /// </summary>
    public double NTU { get; private set; }

    /// <summary>
    /// The type of units available to describe the Turbidity.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Turbidity (NTU) </summary>
        NTU
    }

    /// <summary>
    /// Creates a Turbidity instance from a canonical (NTU) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Turbidity FromCanonical(double value)
    {
        return new Turbidity(value, UnitType.NTU);
    }

    /// <summary>
    /// Gets the value of the Turbidity in Canonical (NTU) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return NTU;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.NTU;

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => NTU.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => NTU.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another Turbidity object
    /// </summary>
    /// <param name="obj">The other Turbidity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Turbidity turbidity)
        {
            return NTU.CompareTo(turbidity.NTU);
        }

        throw new ArgumentException("Object is not a Turbidity");
    }
}