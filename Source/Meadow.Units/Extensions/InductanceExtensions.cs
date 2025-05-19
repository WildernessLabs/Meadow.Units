namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Inductance"/> instances.
/// </summary>
public static class InductanceExtensions
{
    /// <summary>
    /// Creates an Inductance instance with the specified value in henries.
    /// </summary>
    /// <param name="v">The value of inductance as an integer.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Henries(this int v)
    {
        return new Inductance(v, Inductance.UnitType.Henries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in henries.
    /// </summary>
    /// <param name="v">The value of inductance as a double.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Henries(this double v)
    {
        return new Inductance(v, Inductance.UnitType.Henries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in henries.
    /// </summary>
    /// <param name="v">The value of inductance as a float.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Henries(this float v)
    {
        return new Inductance(v, Inductance.UnitType.Henries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in millihenries.
    /// </summary>
    /// <param name="v">The value of inductance as an integer.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Millihenries(this int v)
    {
        return new Inductance(v, Inductance.UnitType.Millihenries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in millihenries.
    /// </summary>
    /// <param name="v">The value of inductance as a double.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Millihenries(this double v)
    {
        return new Inductance(v, Inductance.UnitType.Millihenries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in millihenries.
    /// </summary>
    /// <param name="v">The value of inductance as a float.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Millihenries(this float v)
    {
        return new Inductance(v, Inductance.UnitType.Millihenries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in microhenries.
    /// </summary>
    /// <param name="v">The value of inductance as an integer.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Microhenries(this int v)
    {
        return new Inductance(v, Inductance.UnitType.Microhenries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in microhenries.
    /// </summary>
    /// <param name="v">The value of inductance as a double.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Microhenries(this double v)
    {
        return new Inductance(v, Inductance.UnitType.Microhenries);
    }

    /// <summary>
    /// Creates an Inductance instance with the specified value in microhenries.
    /// </summary>
    /// <param name="v">The value of inductance as a float.</param>
    /// <returns>A new Inductance instance with the specified value.</returns>
    public static Inductance Microhenries(this float v)
    {
        return new Inductance(v, Inductance.UnitType.Microhenries);
    }
}