namespace Meadow.Units.Conversions;

internal static class VolumetricFlowConversions
{
    public static double Convert(double value, VolumetricFlow.UnitType from, VolumetricFlow.UnitType to)
    {
        if (from == to)
        {
            return value;
        }
        return value * flowConversions[(int)to] / flowConversions[(int)from];
    }

    //must align to enum
    private static readonly double[] flowConversions =
    {
        1.0,               // CubicMetersPerSecond (SI unit)
        2118.88,           // CubicFeetPerMinute
        60000,             // LitersPerMinute
        3600000,           // LitersPerHour
        15850.3,           // GallonsPerMinute
        951018,            // GallonsPerHour
    };
}
