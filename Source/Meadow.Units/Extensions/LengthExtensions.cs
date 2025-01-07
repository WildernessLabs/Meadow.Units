namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Length"/> instances.
/// </summary>
public static class LengthExtensions
{
    /// <summary>
    /// Creates a Length instance with the specified value in meters.
    /// </summary>
    /// <param name="v">The value of length in meters as a double.</param>
    /// <returns>A new Length instance with the specified value.</returns>
    public static Length Meters(this double v)
    {
        return new Length(v, Length.UnitType.Meters);
    }

    /// <summary>
    /// Creates a Length instance with the specified value in meters.
    /// </summary>
    /// <param name="v">The value of length in meters as an int.</param>
    /// <returns>A new Length instance with the specified value.</returns>
    public static Length Meters(this int v)
    {
        return new Length(v, Length.UnitType.Meters);
    }
}
