using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Meadow.Units;

/// <summary>
/// TypeConverter for Temperature values
/// </summary>
public class TemperatureTypeConverter : TypeConverter
{
    /// <summary>
    /// Determines if the converter can convert from a given type
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) ||
               sourceType == typeof(double) ||
               base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// Determines if the converter can convert to a given type
    /// </summary>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return destinationType == typeof(string) ||
               destinationType == typeof(InstanceDescriptor) ||
               base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Converts from a given object to Temperature
    /// </summary>
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value is string stringValue)
        {
            // Remove unit suffix if present
            string suffix = "°C";
            stringValue = stringValue.Trim();

            if (stringValue.EndsWith(suffix))
            {
                stringValue = stringValue.Substring(0, stringValue.Length - suffix.Length).Trim();
            }

            if (double.TryParse(stringValue, NumberStyles.Float, culture, out double doubleValue))
            {
                return new Temperature(doubleValue, Temperature.UnitType.Celsius);
            }

            throw new FormatException($"Cannot parse {stringValue} as Temperature");
        }

        if (value is double doubleVal)
        {
            return new Temperature(doubleVal, Temperature.UnitType.Celsius);
        }

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Converts from Temperature to another type
    /// </summary>
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == null)
        {
            throw new ArgumentNullException(nameof(destinationType));
        }

        if (value is Temperature temperature)
        {
            if (destinationType == typeof(string))
            {
                return $"{temperature.Celsius.ToString(culture)}°C";
            }
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}
