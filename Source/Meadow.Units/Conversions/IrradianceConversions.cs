namespace Meadow.Units.Conversions;

internal static class IrradianceConversions
{
    public static double Convert(double value, Irradiance.UnitType from, Irradiance.UnitType to)
    {
        if (from == to)
        {
            return value;
        }
        return value * irradianceConversions[(int)to] / irradianceConversions[(int)from];
    }

    //must align to enum
    private static readonly double[] irradianceConversions =
    {
        1, //WattsPerSquareMeter
        0.001, //KilowattsPerSquareMeter
        1000, //MilliwattsPerSquareMeter
        1000000, //MicrowattsPerSquareMeter
        0.0001, //WattsPerSquareCentimeter
        0.1, //MilliwattsPerSquareCentimeter
    };
}
