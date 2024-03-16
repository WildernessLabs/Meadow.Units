namespace Meadow.Units.Conversions
{
    internal static class ResistanceConversions
    {
        public static double Convert(double value, Resistance.UnitType from, Resistance.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * resistanceConversions[(int)to] / resistanceConversions[(int)from];
        }

        //must align to enum
        private static readonly double[] resistanceConversions =
        {
            1000, //MilliOhms
            1, //Ohms
            0.001, //KiloOhms
            0.000001, //MegaOhms
        };
    }
}