namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Temperature"/> instances.
/// </summary>
public static class TemperatureExtensions
{
    /// <summary>
    /// Creates a Temperature instance with the specified value in Fahrenheit.
    /// </summary>
    /// <param name="v">The value of temperature in Fahrenheit as a double.</param>
    /// <returns>A new Temperature instance with the specified value.</returns>
    public static Temperature Fahrenheit(this double v)
    {
        return new Temperature(v, Temperature.UnitType.Fahrenheit);
    }

    /// <summary>
    /// Creates a Temperature instance with the specified value in Celsius.
    /// </summary>
    /// <param name="v">The value of temperature in Celsius as a double.</param>
    /// <returns>A new Temperature instance with the specified value.</returns>
    public static Temperature Celsius(this double v)
    {
        return new Temperature(v, Temperature.UnitType.Celsius);
    }

    /// <summary>
    /// Creates a Temperature instance with the specified value in Fahrenheit.
    /// </summary>
    /// <param name="v">The value of temperature in Fahrenheit as an integer.</param>
    /// <returns>A new Temperature instance with the specified value.</returns>
    public static Temperature Fahrenheit(this int v)
    {
        return new Temperature(v, Temperature.UnitType.Fahrenheit);
    }

    /// <summary>
    /// Creates a Temperature instance with the specified value in Celsius.
    /// </summary>
    /// <param name="v">The value of temperature in Celsius as an integer.</param>
    /// <returns>A new Temperature instance with the specified value.</returns>
    public static Temperature Celsius(this int v)
    {
        return new Temperature(v, Temperature.UnitType.Celsius);
    }
}

