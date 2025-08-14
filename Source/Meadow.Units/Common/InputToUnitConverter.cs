using System;

namespace Meadow.Units;

/// <summary>
/// Provides methods to convert electrical current measurements to various physical units
/// using linear transformation (scale and offset).
/// </summary>
public static class InputToUnitConverter
{
    /// <summary>
    /// Converts a Current measurement to a specified unit type using linear transformation.
    /// </summary>
    /// <typeparam name="TUnit">The target unit type to convert to. Must implement IUnit.</typeparam>
    /// <param name="current">The source current measurement in milliamps</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value</returns>
    /// <exception cref="NotSupportedException">Thrown when the target unit type is not supported for conversion</exception>
    /// <remarks>
    /// The conversion formula applied is: result = (current.Milliamps * scale) + offset
    /// The current value is first converted to the canonical form of the target unit,
    /// then the linear transformation is applied.
    /// </remarks>
    public static TUnit ConvertCurrentToUnit<TUnit>(Current current, double scale, double offset)
        where TUnit : struct, IUnit
    {
        var rawUnit = UnitFactory.CreateUnitFromCanonicalValue(current.Milliamps, typeof(TUnit).Name);

        return rawUnit switch
        {
            Temperature temperature => (TUnit)(object)new Temperature(
                temperature.Celsius * scale + offset,
                Temperature.UnitType.Celsius),

            Voltage voltage => (TUnit)(object)new Voltage(
                voltage.Volts * scale + offset,
                Voltage.UnitType.Volts),

            Length length => (TUnit)(object)new Length(
                length.Meters * scale + offset,
                Length.UnitType.Meters),

            Pressure pressure => (TUnit)(object)new Pressure(
                pressure.Bar * scale + offset,
                Pressure.UnitType.Bar),

            VolumetricFlow volumetricFlow => (TUnit)(object)new VolumetricFlow(
                volumetricFlow.CubicMetersPerSecond * scale + offset,
                VolumetricFlow.UnitType.CubicMetersPerSecond),

            _ => throw new NotSupportedException($"Conversion to {typeof(TUnit).Name} not supported")
        };
    }

    /// <summary>
    /// Converts a Current measurement to a unit specified by string name using linear transformation.
    /// </summary>
    /// <param name="current">The source current measurement in milliamps</param>
    /// <param name="unitType">The name of the target unit type (case-insensitive)</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value as an object</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified unit type name is not supported for conversion</exception>
    public static IUnit ConvertCurrentToUnit(Current current, string unitType, double scale, double offset)
    {
        return unitType.ToLower() switch
        {
            "temperature" => ConvertCurrentToUnit<Temperature>(current, scale, offset),
            "voltage" => ConvertCurrentToUnit<Voltage>(current, scale, offset),
            "length" => ConvertCurrentToUnit<Length>(current, scale, offset),
            "pressure" => ConvertCurrentToUnit<Pressure>(current, scale, offset),
            "volumetricflow" => ConvertCurrentToUnit<VolumetricFlow>(current, scale, offset),
            _ => throw new NotSupportedException($"Conversion to {unitType} not supported")
        };
    }

    /// <summary>
    /// Converts a Current measurement to a unit specified by Type using linear transformation.
    /// </summary>
    /// <param name="current">The source current measurement in milliamps</param>
    /// <param name="unitType">The Type of the target unit</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value as an object</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified unit Type is not supported for conversion</exception>
    /// <remarks>
    /// This method uses the Type.Name property to determine the conversion target.
    /// Supported types: Temperature, Voltage, Length, Pressure, VolumetricFlow
    /// </remarks>
    public static object ConvertCurrentToUnit(Current current, Type unitType, double scale, double offset)
    {
        var rawUnit = UnitFactory.CreateUnitFromCanonicalValue(current.Milliamps, unitType.Name);

        return rawUnit switch
        {
            Temperature temperature => new Temperature(
                temperature.Celsius * scale + offset,
                Temperature.UnitType.Celsius),

            Voltage voltage => new Voltage(
                voltage.Volts * scale + offset,
                Voltage.UnitType.Volts),

            Length length => new Length(
                length.Meters * scale + offset,
                Length.UnitType.Meters),

            Pressure pressure => new Pressure(
                pressure.Bar * scale + offset,
                Pressure.UnitType.Bar),

            VolumetricFlow volumetricFlow => new VolumetricFlow(
                volumetricFlow.CubicMetersPerSecond * scale + offset,
                VolumetricFlow.UnitType.CubicMetersPerSecond),

            _ => throw new NotSupportedException($"Conversion to {unitType.Name} not supported")
        };
    }
}

