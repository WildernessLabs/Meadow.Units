namespace Meadow.Units.Conversions
{
    internal static class ApparentPowerConversions
    {
        public static double Convert(double value, ApparentPower.UnitType from, ApparentPower.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * apparentPowerConversions[(int)to] / apparentPowerConversions[(int)from];
        }

        //must align to enum
        private static readonly double[] apparentPowerConversions =
        {
            0.000000001,		//Gigavolt amphere
            0.000001,			//Megavolt amphere
		    0.001,				//Kilovolt amphere
		    1.0,				//Volt amphere
		    1000.0,				//Millivolt amphere
	    };
    }
}