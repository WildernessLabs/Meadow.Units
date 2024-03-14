namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Current"/> instances.
/// </summary>
public static class CurrentExtensions
{
    /// <summary>
    /// Creates a Current instance with the specified value in amps.
    /// </summary>
    /// <param name="v">The value of Current as an integer.</param>
    /// <returns>A new Current instance with the specified value.</returns>
    public static Current Amps(this int v)
    {
        return new Current(v, Current.UnitType.Amps);
    }

    /// <summary>
    /// Creates a Current instance with the specified value in amps.
    /// </summary>
    /// <param name="v">The value of Current as a double.</param>
    /// <returns>A new Current instance with the specified value.</returns>
    public static Current Amps(this double v)
    {
        return new Current(v, Current.UnitType.Amps);
    }

    /// <summary>
    /// Creates a Current instance with the specified value in amps.
    /// </summary>
    /// <param name="v">The value of Current as a float.</param>
    /// <returns>A new Current instance with the specified value.</returns>
    public static Current Amps(this float v)
    {
        return new Current(v, Current.UnitType.Amps);
    }
}
