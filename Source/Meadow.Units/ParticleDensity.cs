using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents the density of particles per volume (typically in air)
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct ParticleDensity :
    IUnit<ParticleDensity, ParticleDensity.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    /// <summary>
    /// Creates a new <see cref="ParticleDensity"/> object.
    /// </summary>
    /// <param name="value">The Density value.</param>
    /// <param name="type">Kilograms per meters cubed by default.</param>
    public ParticleDensity(double value, UnitType type = UnitType.ParticlesPerLiter)
    {
        Value = ParticleDensityConversions.Convert(value, type, UnitType.ParticlesPerLiter);
    }

    /// <summary>
    /// Creates a new <see cref="ParticleDensity"/> object from an existing ParticleDensity object
    /// </summary>
    /// <param name="density"></param>
    public ParticleDensity(ParticleDensity density)
    {
        Value = density.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the ParticleDensity.
    /// </summary>
    public enum UnitType
    {
        /// <summary> Particles per liter </summary>
        ParticlesPerLiter,
        /// <summary> Particles per centiliter </summary>
        ParticlesPerCentiliter,
        /// <summary> Particles per milliliter </summary>
        ParticlesPerMilliliter,
    }

    /// <summary>
    /// Creates a ParticleDensity instance from a canonical (ParticlesPerLiter) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ParticleDensity FromCanonical(double value)
    {
        return new ParticleDensity(value, UnitType.ParticlesPerLiter);
    }

    /// <summary>
    /// Gets the value of the ParticleDensity in Canonical (ParticlesPerLiter) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.ParticlesPerLiter;

    /// <summary>
    /// Get the particle density in particles per liter
    /// </summary>
    public double ParticlesPerLiter => From(UnitType.ParticlesPerLiter);

    /// <summary>
    /// Get the particle density in particles per centiliter
    /// </summary>
    public double ParticlesPerCentiliter => From(UnitType.ParticlesPerCentiliter);

    /// <summary>
    /// Get the particle density in particles per milliliter
    /// </summary>
    public double ParticlesPerMilliliter => From(UnitType.ParticlesPerMilliliter);

    /// <summary>
    /// Get a double value for a specific unit
    /// </summary>
    /// <param name="convertTo">unit to convert to</param>
    /// <returns>the converted value</returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return ParticleDensityConversions.Convert(Value, UnitType.ParticlesPerLiter, convertTo);
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
    /// Compare to another ParticleDensity object
    /// </summary>
    /// <param name="obj">The other ParticleDensity cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is ParticleDensity particleDensity)
        {
            return Value.CompareTo(particleDensity.Value);
        }

        throw new ArgumentException("Object is not a ParticleDensity");
    }
}