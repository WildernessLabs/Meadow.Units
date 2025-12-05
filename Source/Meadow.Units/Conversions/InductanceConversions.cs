using System;

namespace Meadow.Units.Conversions;

internal static class InductanceConversions
{
    /// <summary>
    /// Converts an inductance value to a different inductance unit type
    /// </summary>
    /// <param name="value">The inductance value to convert</param>
    /// <param name="from">The source unit type</param>
    /// <param name="to">The target unit type</param>
    /// <returns>The converted value</returns>
    public static double Convert(double value, Inductance.UnitType from, Inductance.UnitType to)
    {
        // First convert to the canonical unit (Henries)
        var henries = ConvertToCanonical(value, from);

        // Then convert from canonical unit to the target unit
        return ConvertFromCanonical(henries, to);
    }

    /// <summary>
    /// Converts the specified value to Henries
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <param name="from">The source unit type</param>
    /// <returns>The value in Henries</returns>
    public static double ConvertToCanonical(double value, Inductance.UnitType from)
    {
        return from switch
        {
            Inductance.UnitType.Henries => value,
            Inductance.UnitType.Millihenries => value * 1e-3,
            Inductance.UnitType.Microhenries => value * 1e-6,
            Inductance.UnitType.Nanohenries => value * 1e-9,
            Inductance.UnitType.Picohenries => value * 1e-12,
            Inductance.UnitType.Kilohenries => value * 1e3,
            Inductance.UnitType.Megahenries => value * 1e6,
            _ => throw new ArgumentOutOfRangeException(nameof(from), $"Invalid source unit type: {from}")
        };
    }

    /// <summary>
    /// Converts the specified value from Henries to the target unit
    /// </summary>
    /// <param name="henries">The value in Henries</param>
    /// <param name="to">The target unit type</param>
    /// <returns>The value in the target unit</returns>
    public static double ConvertFromCanonical(double henries, Inductance.UnitType to)
    {
        return to switch
        {
            Inductance.UnitType.Henries => henries,
            Inductance.UnitType.Millihenries => henries * 1e3,
            Inductance.UnitType.Microhenries => henries * 1e6,
            Inductance.UnitType.Nanohenries => henries * 1e9,
            Inductance.UnitType.Picohenries => henries * 1e12,
            Inductance.UnitType.Kilohenries => henries * 1e-3,
            Inductance.UnitType.Megahenries => henries * 1e-6,
            _ => throw new ArgumentOutOfRangeException(nameof(to), $"Invalid target unit type: {to}")
        };
    }
}
