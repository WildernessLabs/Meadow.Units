using System;

namespace Meadow.Units;

/// <summary>
/// Serialization proxy for unit types to use with MicroJson
/// </summary>
/// <typeparam name="TUnit">The unit type</typeparam>
/// <typeparam name="TUnitType">The enum type for unit values</typeparam>
internal class UnitSerializationProxy<TUnit, TUnitType>
    where TUnit : struct, IUnit<TUnit, TUnitType>
    where TUnitType : struct, Enum
{
    /// <summary>
    /// The canonical value of the unit
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// The unit type as a string
    /// </summary>
    public string UnitType { get; set; }

    /// <summary>
    /// Creates a new proxy object from a unit
    /// </summary>
    public UnitSerializationProxy(TUnit unit)
    {
        Value = unit.ToCanonical();
        UnitType = unit.GetCanonicalUnitType().ToString();
    }

    /// <summary>
    /// Creates an empty proxy for deserialization
    /// </summary>
    public UnitSerializationProxy()
    {
        UnitType = "";
    }

    /// <summary>
    /// Converts the proxy back to a unit instance
    /// </summary>
    public TUnit ToUnit(Func<double, TUnitType, TUnit> factory)
    {
        TUnitType unitType = (TUnitType)Enum.Parse(typeof(TUnitType), UnitType);
        return factory(Value, unitType);
    }
}