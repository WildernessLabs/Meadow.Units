namespace Meadow.Units.Conversions
{
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
            0.000000001,		//Gigavolt amphere
            0.000001,			//Megavolt amphere
		    0.001,				//Kilovolt amphere
		    1.0,				//Volt amphere
		    1000.0,				//Millivolt amphere
	    };
    }
}