using System;

namespace Meadow.Units.Conversions
{
    internal static class DigitalStorageConversions
    {
        public static double Convert(double value, DigitalStorage.UnitType from, DigitalStorage.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * digitalStorageConversions[(int)from] / digitalStorageConversions[(int)to];
        }

        private static readonly double[] digitalStorageConversions =
        {
            1.0 / 8.0,                // Bit
            1,                        // Byte
            Math.Pow(2.0, 10.0),      // Kilobyte
            Math.Pow(2.0, 20.0),      // Megabyte
            Math.Pow(2.0, 30.0),      // Gigabyte
            Math.Pow(2.0, 40.0),      // Terabyte
            Math.Pow(2.0, 50.0),      // Petabyte
            Math.Pow(2.0, 60.0),      // Exabyte
            1.0 / 8.0 / 1024.0,       // Kibit (Kibibit)
            1.0 / 8.0 / 1024.0 / 1024.0,  // Mibit (Mebibit)
            1.0 / 8.0 / 1024.0 / 1024.0 / 1024.0,  // Gibit (Gibibit)
        };
    }
}