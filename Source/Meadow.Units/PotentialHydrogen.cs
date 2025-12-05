using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents potential hydrogen (ph)
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct PotentialHydrogen :
    IUnit<PotentialHydrogen, PotentialHydrogen.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly PotentialHydrogen _neutral;

    static PotentialHydrogen()
    {
        _neutral = new PotentialHydrogen(7, UnitType.pH);
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// Gets a voltage of 0 Volts
    /// </summary>
    public static PotentialHydrogen Neutral => _neutral;

    /// <summary>
    /// Creates a new <see cref="PotentialHydrogen"/> object.
    /// </summary>
    /// <param name="value">The Potential Hydrogen value.</param>
    /// <param name="type">Potential Hydrogen unit.</param>
    public PotentialHydrogen(double value, UnitType type = UnitType.pH)
    {
        pH = value;
    }

    /// <summary>
    /// Creates a new <see cref="PotentialHydrogen"/> object from an existing PotentialHydrogen object
    /// </summary>
    /// <param name="PotentialHydrogen"></param>
    public PotentialHydrogen(PotentialHydrogen PotentialHydrogen)
    {
        pH = PotentialHydrogen.pH;
    }

    /// <summary>
    /// The Potential Hydrogen expressed as pH.
    /// </summary>
    public double pH { get; private set; }

    /// <summary>
    /// The type of units available to describe the PotentialHydrogen.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Potential Hydrogen (pH) </summary>
        pH
    }

    /// <summary>
    /// Creates a PotentialHydrogen instance from a canonical (pH) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static PotentialHydrogen FromCanonical(double value)
    {
        return new PotentialHydrogen(value, UnitType.pH);
    }

    /// <summary>
    /// Gets the value of the PotentialHydrogen in Canonical (pH) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return pH;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.pH;

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => pH.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => pH.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another PotentialHydrogen object
    /// </summary>
    /// <param name="obj">The other PotentialHydrogen cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is PotentialHydrogen potentialHydrogen)
        {
            return pH.CompareTo(potentialHydrogen.pH);
        }

        throw new ArgumentException("Object is not a PotentialHydrogen");
    }
}