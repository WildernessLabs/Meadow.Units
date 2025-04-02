using Meadow.Units;
using System;

namespace Meadow.Common;

/// <summary>
/// Factory methods for unit creation
/// </summary>
internal class UnitFactory
{
    /// <summary>
    /// Generic method to create a unit from its canonical value.
    /// Note: For .NET Standard 2.1 this requires a runtime check since static interface methods aren't available.
    /// </summary>
    public static TUnit FromCanonical<TUnit, TUnitType>(double value)
        where TUnit : struct, IUnit<TUnit, TUnitType>
        where TUnitType : struct, Enum
    {
        Type unitType = typeof(TUnit);

        if (unitType == typeof(Temperature))
            return (TUnit)(object)FromCelsius(value);

        if (unitType == typeof(Voltage))
            return (TUnit)(object)FromVolts(value);

        if (unitType == typeof(Length))
            return (TUnit)(object)FromMeters(value);

        // Add other unit types as needed

        throw new NotSupportedException($"Unit type {unitType.Name} is not supported");
    }

    /// <summary>
    /// Creates a Temperature unit from a Celsius value
    /// </summary>
    public static Temperature FromCelsius(double celsius)
    {
        return new Temperature(celsius, Temperature.UnitType.Celsius);
    }

    /// <summary>
    /// Creates a Voltage unit from a Volts value
    /// </summary>
    public static Voltage FromVolts(double volts)
    {
        return new Voltage(volts, Voltage.UnitType.Volts);
    }

    /// <summary>
    /// Creates a Length unit from a Meters value
    /// </summary>
    public static Length FromMeters(double meters)
    {
        return new Length(meters, Length.UnitType.Meters);
    }
}
