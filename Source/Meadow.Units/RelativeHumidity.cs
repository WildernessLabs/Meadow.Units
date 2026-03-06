using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents relative humidity expressed as a percentage, indicates a
/// present state of absolute humidity relative to a maximum humidity given
/// the same temperature.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct RelativeHumidity :
    IUnit<RelativeHumidity, RelativeHumidity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="RelativeHumidity"/> object.
    /// </summary>
    /// <param name="value">The relative humidity value.</param>
    /// <param name="type">Relative humidity unit.</param>
    public RelativeHumidity(double value, UnitType type = UnitType.Percent)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new <see cref="RelativeHumidity"/> object from an existing RelativeHumidity object
    /// </summary>
    /// <param name="relativeHumidity"></param>
    public RelativeHumidity(RelativeHumidity relativeHumidity)
    {
        Value = relativeHumidity.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The relative expressed as a value percent.
    /// </summary>
    public double Percent => Value;
    /// <summary>
    /// The type of units available to describe the RelativeHumidity.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Relative humidity as a percentage
        /// </summary>
        Percent
    }

    /// <summary>
    /// Creates a RelativeHumidity instance from a canonical (Percent) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static RelativeHumidity FromCanonical(double value)
    {
        return new RelativeHumidity(value, UnitType.Percent);
    }

    /// <summary>
    /// Gets the value of the RelativeHumidity in Canonical (Percent) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Percent;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Percent;

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => Percent.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Percent.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another RelativeHumidity object
    /// </summary>
    /// <param name="obj">The other RelativeHumidity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is RelativeHumidity relativeHumidity)
        {
            return Percent.CompareTo(relativeHumidity.Percent);
        }

        throw new ArgumentException("Object is not a RelativeHumidity");
    }
}