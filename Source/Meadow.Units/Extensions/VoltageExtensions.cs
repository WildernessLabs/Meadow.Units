namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating Resistance instances.
/// </summary>
public static class VoltageExtensions
{
    /// <summary>
    /// Creates a Voltage instance with the specified value in volts.
    /// </summary>
    /// <param name="v">The value of voltage as an integer.</param>
    /// <returns>A new Voltage instance with the specified value.</returns>
    public static Voltage Volts(this int v)
    {
        return new Voltage(v, Voltage.UnitType.Volts);
    }

    /// <summary>
    /// Creates a Voltage instance with the specified value in volts.
    /// </summary>
    /// <param name="v">The value of voltage as a double.</param>
    /// <returns>A new Voltage instance with the specified value.</returns>
    public static Voltage Volts(this double v)
    {
        return new Voltage(v, Voltage.UnitType.Volts);
    }

    /// <summary>
    /// Creates a Voltage instance with the specified value in volts.
    /// </summary>
    /// <param name="v">The value of voltage as a float.</param>
    /// <returns>A new Voltage instance with the specified value.</returns>
    public static Voltage Volts(this float v)
    {
        return new Voltage(v, Voltage.UnitType.Volts);
    }
}
