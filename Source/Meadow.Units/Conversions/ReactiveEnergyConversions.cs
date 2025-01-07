namespace Meadow.Units.Conversions;

internal static class ReactiveEnergyConversions
{
    public static double Convert(double value, ReactiveEnergy.UnitType from, ReactiveEnergy.UnitType to)
    {
        if (from == to)
        {
            return value;
        }
        return value * reactiveEnergyConversions[(int)to] / reactiveEnergyConversions[(int)from];
    }

    //must align to enum
    private static readonly double[] reactiveEnergyConversions =
    {
        0.000000001,        //Gigavolt ampere
        0.000001,           //Megavolt ampere
        0.001,              //Kilovolt ampere
        1.0,                //Volt ampere
        1000.0,             //Millivolt ampere
    };
}