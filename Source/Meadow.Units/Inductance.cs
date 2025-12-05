using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a measurement of electrical inductance.
/// </summary>
/// <remarks>Inductance is a property of an electrical circuit or component that opposes changes in current flow, 
/// typically measured in henries (H). This struct is immutable and can be used to represent inductance values  in
/// calculations or as part of a larger electrical modeling system.</remarks>
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct Inductance :
    IUnit<Inductance, Inductance.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly Inductance _zero;

    static Inductance()
    {
        _zero = new Inductance(0, UnitType.Henries);
    }

    /// <summary>
    /// Gets an inductance of 0 Henries
    /// </summary>
    public static Inductance Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="Inductance"/> object.
    /// </summary>
    /// <param name="value">The Inductance value.</param>
    /// <param name="type">Henries by default.</param>
    public Inductance(double value, UnitType type = UnitType.Henries)
    {
        Value = InductanceConversions.Convert(value, type, UnitType.Henries);
    }

    /// <summary>
    /// Creates a new <see cref="Inductance"/> object from an existing Inductance object
    /// </summary>
    /// <param name="inductance"></param>
    public Inductance(Inductance inductance)
    {
        Value = inductance.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the Inductance.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Henries </summary>
        Henries,
        /// <summary> Millihenries </summary>
        Millihenries,
        /// <summary> Microhenries </summary>
        Microhenries,
        /// <summary> Nanohenries </summary>
        Nanohenries,
        /// <summary> Picohenries </summary>
        Picohenries,
        /// <summary> Kilohenries </summary>
        Kilohenries,
        /// <summary> Megahenries </summary>
        Megahenries
    }

    /// <summary>
    /// Creates an Inductance instance from a canonical (Henries) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Inductance FromCanonical(double value)
    {
        return new Inductance(value, UnitType.Henries);
    }

    /// <summary>
    /// Gets the value of the Inductance in Canonical (Henries) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Henries;

    /// <summary> Get inductance in henries </summary>
    public double Henries => From(UnitType.Henries);

    /// <summary> Get inductance in millihenries </summary>
    public double Millihenries => From(UnitType.Millihenries);

    /// <summary> Get inductance in microhenries </summary>
    public double Microhenries => From(UnitType.Microhenries);

    /// <summary> Get inductance in nanohenries </summary>
    public double Nanohenries => From(UnitType.Nanohenries);

    /// <summary> Get inductance in picohenries </summary>
    public double Picohenries => From(UnitType.Picohenries);

    /// <summary> Get inductance in kilohenries </summary>
    public double Kilohenries => From(UnitType.Kilohenries);

    /// <summary> Get inductance in megahenries </summary>
    public double Megahenries => From(UnitType.Megahenries);

    /// <summary>
    /// Convert to a specific unit
    /// </summary>
    /// <param name="convertTo">the unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return InductanceConversions.Convert(Value, UnitType.Henries, convertTo);
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
    /// Compare to another Inductance object
    /// </summary>
    /// <param name="obj">The other Inductance cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is Inductance inductance)
        {
            return Value.CompareTo(inductance.Value);
        }

        throw new ArgumentException("Object is not an Inductance");
    }
}
