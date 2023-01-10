namespace Meadow.Units.Conversions
{
    internal static class ConductivityConversions
    {
        public static double Convert(double value, Conductivity.UnitType from, Conductivity.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * conductivityConversions[(int)to] / conductivityConversions[(int)from];
        }

        //must align to enum
        private static readonly double[] conductivityConversions =
        {
            1, //siemen per cm
            100, //siemen per m
			1000, //milli siemen per cm
            100000, //milli siemen per m
            1000000, //micro siemen per cm
            100000000, //micro siemen per m
		};
    }
}