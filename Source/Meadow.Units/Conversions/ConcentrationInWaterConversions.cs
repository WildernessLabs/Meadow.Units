namespace Meadow.Units.Conversions;

internal static class ConcentrationInWaterConversions
{
    public static double Convert(double value, ConcentrationInWater.UnitType from, ConcentrationInWater.UnitType to)
    {
        if (from == to)
        {
            return value;
        }

        return value * concentrationConversions[(int)to] / concentrationConversions[(int)from];
    }

    private static readonly double[] concentrationConversions =
    {
        1.0,//pph
        10.0,//ppt
        10000.0,    // ppm
        10000.0,    // mg/L
        10000.0,    // g/m^3
        10000000.0,   // ppb
        10000000.0,   // ug/L
        10000000000.0,   // ppt
    };
}