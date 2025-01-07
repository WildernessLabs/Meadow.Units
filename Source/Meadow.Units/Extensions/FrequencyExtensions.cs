namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Frequency"/> instances.
/// </summary>
public static class FrequencyExtensions
{
    /// <summary>
    /// Creates a Frequency instance with the specified value in Hertz.
    /// </summary>
    /// <param name="v">The value of frequency in Hertz as a double.</param>
    /// <returns>A new Frequency instance with the specified value.</returns>
    public static Frequency Hertz(this double v)
    {
        return new Frequency(v, Frequency.UnitType.Hertz);
    }

    /// <summary>
    /// Creates a Frequency instance with the specified value in Hertz.
    /// </summary>
    /// <param name="v">The value of frequency in Hertz as an int.</param>
    /// <returns>A new Frequency instance with the specified value.</returns>
    public static Frequency Hertz(this int v)
    {
        return new Frequency(v, Frequency.UnitType.Hertz);
    }
}
