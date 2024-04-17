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
            1_000,                    // Kilobyte
            1_000_000,                // Megabyte
            1_000_000_000,            // Gigabyte
            1_000_000_000_000,        // Terabyte
            1_000_000_000_000_000,    // Petabyte
            1_000_000_000_000_000_000,// Exabyte
            1024,                     // KiB
            1024 * 8,                 // Kib
            1024 * 1024,              // MiB
            1024 * 1024 * 8,          // Mib
            1024 * 1024 * 1024,       // GiB
            // 1024 * 1024 * 1204 * 8    // Gib  OVERFLOW - NOT SUPPORTED
        };
    }
}