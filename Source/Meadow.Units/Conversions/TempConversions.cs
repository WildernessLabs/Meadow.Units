using System;
namespace Meadow.Units.Conversions
{
    internal static class TempConversions
    {
        public static Func<double, double> FToC = (value) => (value - 32d) * (5d / 9d);
        public static Func<double, double> KToC = (value) => value - 273.15d;
        public static Func<double, double> CToF = (value) => value * (9d / 5d) + 32d;
        public static Func<double, double> CToK = (value) => value + 273.15d;
        public static Func<double, double> FToK = (value) => FToC(value) + 273.15d;
        public static Func<double, double> KToF = (value) => CToF(value - 273.15);


        public static double Convert(double value, Temperature.UnitType from, Temperature.UnitType to)
        {
            if (from == to) { return value; }

            switch (from)
            {
                case Temperature.UnitType.Celsius:
                    return to switch
                    {
                        Temperature.UnitType.Kelvin => CToK(value),
                        Temperature.UnitType.Fahrenheit => CToF(value),
                        _ => value
                    };
                case Temperature.UnitType.Fahrenheit:
                    return to switch
                    {
                        Temperature.UnitType.Kelvin => FToK(value),
                        Temperature.UnitType.Celsius => FToC(value),
                        _ => value
                    };
                case Temperature.UnitType.Kelvin:
                    return to switch
                    {
                        Temperature.UnitType.Fahrenheit => KToF(value),
                        Temperature.UnitType.Celsius => KToC(value),
                        _ => value
                    };
            }

            throw new NotSupportedException();
        }
    }
}
