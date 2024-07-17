namespace Meadow.Units.Conversions;

internal static class TimePeriodConversions
{
    public static double Convert(double value, TimePeriod.UnitType from, TimePeriod.UnitType to)
    {
        if (from == to)
        {
            return value;
        }
        return value * timeConversions[(int)to] / timeConversions[(int)from];
    }

    //must align to enum
    private static readonly double[] timeConversions =
    {
        1_000_000_000,//ns
        1_000_000,//us
        1_000,//ms
        1,//s
        1/60d, //min
        1/(60d * 60d), //hrs
        1/(60d * 60d *24d), //days
    };
}
