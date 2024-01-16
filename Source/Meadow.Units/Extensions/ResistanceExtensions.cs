namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating Resistance instances.
/// </summary>
public static class ResistanceExtensions
{
    /// <summary>
    /// Creates a Resistance instance with the specified value in ohms.
    /// </summary>
    /// <param name="v">The value of resistance in ohms as an integer.</param>
    /// <returns>A new Resistance instance with the specified value.</returns>
    public static Resistance Ohms(this int v)
    {
        return new Resistance(v, Resistance.UnitType.Ohms);
    }

    /// <summary>
    /// Creates a Resistance instance with the specified value in ohms.
    /// </summary>
    /// <param name="v">The value of resistance in ohms as a double.</param>
    /// <returns>A new Resistance instance with the specified value.</returns>
    public static Resistance Ohms(this double v)
    {
        return new Resistance(v, Resistance.UnitType.Ohms);
    }

    /// <summary>
    /// Creates a Resistance instance with the specified value in ohms.
    /// </summary>
    /// <param name="v">The value of resistance in ohms as a float.</param>
    /// <returns>A new Resistance instance with the specified value.</returns>
    public static Resistance Ohms(this float v)
    {
        return new Resistance(v, Resistance.UnitType.Ohms);
    }
}
