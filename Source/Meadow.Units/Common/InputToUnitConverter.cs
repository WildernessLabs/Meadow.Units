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
    /// <param name="current">The source current measurement</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value</returns>
    /// <exception cref="NotSupportedException">Thrown when the target unit type is not supported for conversion</exception>
    /// <remarks>
    /// The conversion formula applied is: result = (current.ToCanonical() * scale) + offset
    /// The current value is first converted to the canonical form of the target unit,
    /// then the linear transformation is applied.
    /// This method automatically supports all unit types that implement IUnit and have a FromCanonical method.
    /// </remarks>
    public static TUnit ConvertCurrentToUnit<TUnit>(Current current, double scale, double offset)
        where TUnit : struct, IUnit
    {
        // Create a unit from the current value (using the canonical current value)
        var rawUnit = (IUnit)UnitFactory.CreateUnitFromCanonicalValue(current.ToCanonical(), typeof(TUnit).Name);

        // Get the canonical value, apply transformation, and create new unit
        var transformedValue = rawUnit.ToCanonical() * scale + offset;

        return (TUnit)UnitFactory.CreateUnitFromCanonicalValue(transformedValue, typeof(TUnit).Name);
    }

    /// <summary>
    /// Converts a Current measurement to a unit specified by string name using linear transformation.
    /// </summary>
    /// <param name="current">The source current measurement</param>
    /// <param name="unitType">The name of the target unit type (case-insensitive)</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value as an object</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified unit type name is not supported for conversion</exception>
    /// <remarks>
    /// This method automatically supports all unit types that implement IUnit and have a FromCanonical method.
    /// </remarks>
    public static IUnit ConvertCurrentToUnit(Current current, string unitType, double scale, double offset)
    {
        // Create a unit from the current value (using the canonical current value)
        var rawUnit = (IUnit)UnitFactory.CreateUnitFromCanonicalValue(current.ToCanonical(), unitType);

        // Get the canonical value, apply transformation, and create new unit
        var transformedValue = rawUnit.ToCanonical() * scale + offset;

        return (IUnit)UnitFactory.CreateUnitFromCanonicalValue(transformedValue, unitType);
    }

    /// <summary>
    /// Converts a Current measurement to a unit specified by Type using linear transformation.
    /// </summary>
    /// <param name="current">The source current measurement</param>
    /// <param name="unitType">The Type of the target unit</param>
    /// <param name="scale">The scaling factor to apply to the conversion</param>
    /// <param name="offset">The offset value to add after scaling</param>
    /// <returns>The converted unit value as an object</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified unit Type is not supported for conversion</exception>
    /// <remarks>
    /// This method uses the Type.Name property to determine the conversion target.
    /// This method automatically supports all unit types that implement IUnit and have a FromCanonical method.
    /// </remarks>
    public static object ConvertCurrentToUnit(Current current, Type unitType, double scale, double offset)
    {
        // Create a unit from the current value (using the canonical current value)
        var rawUnit = (IUnit)UnitFactory.CreateUnitFromCanonicalValue(current.ToCanonical(), unitType.Name);

        // Get the canonical value, apply transformation, and create new unit
        var transformedValue = rawUnit.ToCanonical() * scale + offset;

        return UnitFactory.CreateUnitFromCanonicalValue(transformedValue, unitType.Name);
    }
}

