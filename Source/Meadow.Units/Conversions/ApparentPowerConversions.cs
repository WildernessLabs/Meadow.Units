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
            0.000000001,		//Gigavolt ampere
            0.000001,			//Megavolt ampere
		    0.001,				//Kilovolt ampere
		    1.0,				//Volt ampere
		    1000.0,				//Millivolt ampere
	    };
    }
}