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
            0.000000001,		//Gigavolt amphere
            0.000001,			//Megavolt amphere
		    0.001,				//Kilovolt amphere
		    1.0,				//Volt amphere
		    1000.0,				//Millivolt amphere
	    };
    }
}