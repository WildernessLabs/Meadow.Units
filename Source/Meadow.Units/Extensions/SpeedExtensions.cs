using System.Collections.Generic;
using System.Linq;

namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Speed"/> instances.
/// </summary>
public static class SpeedExtensions
{
    /// <summary>
    /// calculates a mean Speed
    /// </summary>
    /// <param name="samples"></param>
    /// <returns></returns>
    public static Speed Mean(this IEnumerable<Speed> samples)
    {
        return new Speed(samples.Select(a => a.KilometersPerSecond).Average(), Speed.UnitType.KilometersPerSecond);
    }
}
