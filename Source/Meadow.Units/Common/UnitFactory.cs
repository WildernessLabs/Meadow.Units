using Meadow.Units;
using System;

namespace Meadow.Common;

/// <summary>
/// Factory methods for unit creation
/// </summary>
public class UnitFactory
{

    /// <summary>
    /// Method to create a unit from its canonical value.
    /// </summary>
    /// <param name="value">The canonical value to use for creation</param>
    /// <param name="unitTypeName">The name of the Unit to be created</param>
    public static object CreateUnitFromCanonicalValue(double value, string unitTypeName)
    {
        return unitTypeName switch
        {
            nameof(Temperature) => new Temperature(value),
            nameof(Voltage) => new Voltage(value),
            nameof(Length) => new Length(value),
            nameof(Pressure) => new Pressure(value),
            _ => throw new NotSupportedException($"Unit type name {unitTypeName} is not supported.")
        };
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
