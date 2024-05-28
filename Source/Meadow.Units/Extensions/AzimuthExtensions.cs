using System.Collections.Generic;
using System.Linq;

namespace Meadow.Units;

/// <summary>
/// Provides extension methods for creating <see cref="Azimuth"/> instances.
/// </summary>
public static class AzimuthExtensions
{
    /// <summary>
    /// calculates a mean Azimuth
    /// </summary>
    /// <param name="samples"></param>
    /// <returns></returns>
    public static Azimuth Mean(this IEnumerable<Azimuth> samples)
    {
        // if we have samples that straddle zero (i.e. some > 270 and some < 90), we need to adjust
        if (samples.Any(s => s.DecimalDegrees > 270) && samples.Any(s => s.DecimalDegrees < 90))
        {
            // adjust all > 270 samples to negatives
            var adjusted = samples.Select(s => s.DecimalDegrees > 270 ? s.DecimalDegrees - 360 : s.DecimalDegrees);
            var mean = adjusted.Average();
            if (mean < 0) mean += 360;
            return new Azimuth(mean);
        }
        else
        {
            return new Azimuth(samples.Select(a => a.DecimalDegrees).Average());
        }
    }
}
