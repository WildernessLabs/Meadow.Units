namespace Meadow.Units.Conversions
{
    internal static class ParticleDensityConversions
    {
        public static double Convert(double value, ParticleDensity.UnitType from, ParticleDensity.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * densityConversions[(int)to] / densityConversions[(int)from];
        }

        //must align to enum
        private static readonly double[] densityConversions =
        {
            1.0,//particles/l
	    };
    }
}