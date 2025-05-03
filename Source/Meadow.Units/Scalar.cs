using Meadow.Units;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

/// <summary>
/// Represents a Scalar measurement.
/// Implements standard interfaces for comparison, formatting, and conversion operations.
/// </summary>
public struct Scalar :
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
    /// Determines whether the specified object is equal to the current unit.
    /// </summary>
    /// <param name="obj">The object to compare with the current unit.</param>
    /// <returns>true if the specified object is equal to the current unit; otherwise, false.</returns>
    [Pure] public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Returns the hash code for this unit.
    /// </summary>
    /// <returns>A hash code value generated from the underlying numerical value.</returns>
    [Pure] public override int GetHashCode() => value.GetHashCode();

    /// <summary>
    /// Determines whether the specified unit is equal to the current unit.
    /// </summary>
    /// <param name="other">The unit to compare with the current unit.</param>
    /// <returns>true if the units are equal; otherwise, false.</returns>
    [Pure] public bool Equals(Scalar other) => value == other.value;

    /// <summary>
    /// Determines whether two units are equal.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the units are equal; otherwise, false.</returns>
    [Pure] public static bool operator ==(Scalar left, Scalar right) => Equals(left.value, right.value);

    /// <summary>
    /// Determines whether two units are not equal.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the units are not equal; otherwise, false.</returns>
    [Pure] public static bool operator !=(Scalar left, Scalar right) => !Equals(left.value, right.value);

    /// <summary>
    /// Compares the current unit with another unit.
    /// </summary>
    /// <param name="other">The unit to compare with the current unit.</param>
    /// <returns>A value that indicates the relative order of the units being compared. Returns 0 if equal, 
    /// less than 0 if less than the other value, or greater than 0 if greater than the other value.</returns>
    [Pure] public int CompareTo(Scalar other) => Equals(value, other.value) ? 0 : value.CompareTo(other.value);

    /// <summary>
    /// Determines whether the first unit is less than the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is less than the second unit; otherwise, false.</returns>
    [Pure] public static bool operator <(Scalar left, Scalar right) => Comparer<double>.Default.Compare(left.value, right.value) < 0;

    /// <summary>
    /// Determines whether the first unit is greater than the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is greater than the second unit; otherwise, false.</returns>
    [Pure] public static bool operator >(Scalar left, Scalar right) => Comparer<double>.Default.Compare(left.value, right.value) > 0;

    /// <summary>
    /// Determines whether the first unit is less than or equal to the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is less than or equal to the second unit; otherwise, false.</returns>
    [Pure] public static bool operator <=(Scalar left, Scalar right) => Comparer<double>.Default.Compare(left.value, right.value) <= 0;

    /// <summary>
    /// Determines whether the first unit is greater than or equal to the second unit.
    /// </summary>
    /// <param name="left">The first unit to compare.</param>
    /// <param name="right">The second unit to compare.</param>
    /// <returns>true if the first unit is greater than or equal to the second unit; otherwise, false.</returns>
    [Pure] public static bool operator >=(Scalar left, Scalar right) => Comparer<double>.Default.Compare(left.value, right.value) >= 0;

    /// <summary>
    /// Adds two scalar values.
    /// </summary>
    /// <param name="left">The first value to add.</param>
    /// <param name="right">The second value to add.</param>
    /// <returns>The sum of the two scalar values.</returns>
    [Pure] public static Scalar operator +(Scalar left, Scalar right) => new(left.value + right.value);

    /// <summary>
    /// Subtracts one scalar value from another.
    /// </summary>
    /// <param name="left">The value to subtract from.</param>
    /// <param name="right">The value to subtract.</param>
    /// <returns>The difference between the two scalar values.</returns>
    [Pure] public static Scalar operator -(Scalar left, Scalar right) => new(left.value - right.value);

    /// <summary>
    /// Multiplies a scalar value by a scalar value.
    /// </summary>
    /// <param name="value">The scalar value to multiply.</param>
    /// <param name="operand">The scalar value to multiply by.</param>
    /// <returns>The product of the scalar and scalar values.</returns>
    [Pure] public static Scalar operator *(Scalar value, double operand) => new(value.value * operand);

    /// <summary>
    /// Divides a scalar value by a scalar value.
    /// </summary>
    /// <param name="value">The scalar value to divide.</param>
    /// <param name="operand">The scalar value to divide by.</param>
    /// <returns>The quotient of the scalar value and scalar value.</returns>
    [Pure] public static Scalar operator /(Scalar value, double operand) => new(value.value / operand);

    /// <summary>
    /// Compares the current unit with another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current unit.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <exception cref="ArgumentException">The object is not a Scalar.</exception>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Scalar Scalar)
        {
            return value.CompareTo(Scalar.value);
        }
        throw new ArgumentException("Object is not a Scalar");
    }

    /// <summary>
    /// Returns the TypeCode for the underlying value type.
    /// </summary>
    /// <returns>The TypeCode for the underlying double value.</returns>
    [Pure] public TypeCode GetTypeCode() => value.GetTypeCode();

    /// <inheritdoc/>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => value.ToString(format, formatProvider);
    /// <inheritdoc/>
    [Pure] public string ToString(IFormatProvider provider) => value.ToString(provider);

}
