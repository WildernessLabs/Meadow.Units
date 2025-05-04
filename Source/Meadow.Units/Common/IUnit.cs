using System;

namespace Meadow.Units;

/// <summary>
/// Defines a standardized interface for unit value types that represent physical quantities.
/// </summary>
public interface IUnit
{
    /// <summary>
    /// Converts the current unit value to its canonical unit representation.
    /// </summary>
    /// <returns>The value expressed in the canonical unit</returns>
    double ToCanonical();
}

/// <summary>
/// Defines a standardized interface for unit value types that represent physical quantities.
/// </summary>
/// <typeparam name="TSelf">The implementing struct type</typeparam>
/// <typeparam name="TUnit">The enum type representing the available units of measurement</typeparam>
public interface IUnit<TSelf, TUnit> : IUnit
       where TSelf : struct, IUnit<TSelf, TUnit>
       where TUnit : struct, Enum
{
    /// <summary>
    /// Gets the enum value that represents the canonical unit of measurement for this type.
    /// </summary>
    /// <returns>The canonical unit type</returns>
    TUnit GetCanonicalUnitType();
}
