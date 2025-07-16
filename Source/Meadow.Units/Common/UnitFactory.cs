using System;

namespace Meadow.Units;

/// <summary>
/// Factory methods for unit creation
/// </summary>
public class UnitFactory
{
    /// <summary>
    /// Method to create a unit from its canonical value.
    /// </summary>
    /// <param name="value">The canonical value to use for creation</param>
    /// <param name="unitTypeName">The (case-insensitive) name of the Unit to be created</param>
    public static object CreateUnitFromCanonicalValue(double value, string unitTypeName)
    {
        return unitTypeName.ToLower() switch
        {
            "temperature" => new Temperature(value, Temperature.UnitType.Celsius),
            "voltage" => new Voltage(value, Voltage.UnitType.Volts),
            "length" => new Length(value, Length.UnitType.Meters),
            "pressure" => new Pressure(value, Pressure.UnitType.Bar),
            "volumetricflow" => new VolumetricFlow(value, VolumetricFlow.UnitType.CubicMetersPerSecond),
            _ => throw new NotSupportedException($"Unit type name {unitTypeName} is not supported.")
        };
    }
}
