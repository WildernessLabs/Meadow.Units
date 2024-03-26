namespace Meadow.Units.Conversions
{
    internal static class ReactivePowerConversions
    {
        public static double Convert(double value, ReactivePower.UnitType from, ReactivePower.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * reactivePowerConversions[(int)to] / reactivePowerConversions[(int)from];
        }

        //must align to enum
        private static readonly double[] reactivePowerConversions =
        {
            0.000000001,        //Gigavolt ampere
            0.000001,           //Megavolt ampere
            0.001,              //Kilovolt ampere
            1.0,                //Volt ampere
            1000.0,             //Millivolt ampere
        };
    }
}