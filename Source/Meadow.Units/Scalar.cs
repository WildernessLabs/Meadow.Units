using System;
using System.Diagnostics.Contracts;

namespace Meadow.Units;

/// <summary>
/// Represents a Scalar measurement.
/// Implements standard interfaces for comparison, formatting, and conversion operations.
/// </summary>
[GenerateUnitBoilerplate]
public partial struct Scalar :
    IUnit<Scalar, Scalar.UnitType>,
    IComparable, IFormattable
{
    private static readonly Scalar _zero;

    static Scalar()
    {
        _zero = new Scalar(0, UnitType.One);
    }

    /// <summary>
    /// Gets a scalar 0
    /// </summary>
    public static Scalar Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Scalar"/> object.
    /// </summary>
    /// <param name="value">The Scalar value.</param>
    /// <param name="type">One by default.</param>
    public Scalar(double value, UnitType type = UnitType.One)
    {
        this.value = value;
    }

    /// <summary>
    /// Creates a new <see cref="Scalar"/> object from an existing Scalar object
    /// </summary>
    /// <param name="value"></param>
    public Scalar(Scalar value)
    {
        this.value = value.value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double value;

    /// <summary>
    /// The type of units available to describe the Scalar.
    /// </summary>
    public enum UnitType
    {
        /// <summary>Scalar</summary>
        One
    }

    /// <summary>
    /// Creates a Scalar instance from a canonical (One) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Scalar FromCanonical(double value)
    {
        return new Scalar(value, UnitType.One);
    }

    /// <summary>
    /// Gets the value of the Scalar in Canonical (One) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        // Return the internal value which is already in One
        return value;
    }

    /// <summary>
    /// Gets the scalar value
    /// </summary>
    public double Value => value;

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.One;

    /// <summary>
    /// Compares the current unit with another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current unit.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <exception cref="ArgumentException">The object is not a Scalar.</exception>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Scalar scalar)
        {
            return value.CompareTo(scalar.value);
        }
        throw new ArgumentException("Object is not a Scalar");
    }

    /// <inheritdoc/>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => value.ToString(format, formatProvider);

    /// <summary>
    /// Converts a <see cref="Scalar"/> instance to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Scalar"/> instance to convert.</param>
    public static explicit operator double(Scalar value) => value.value;
    /// <summary>
    /// Converts a <see cref="double"/> value to a <see cref="Scalar"/> instance.
    /// </summary>
    /// <param name="value">The <see cref="double"/> value to convert.</param>
    public static explicit operator Scalar(double value) => new Scalar(value);
}
