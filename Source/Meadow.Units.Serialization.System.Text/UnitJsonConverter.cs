using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meadow.Units.Serialization;

/// <summary>
/// A JsonConverter for a specific Unit type.
/// </summary>
/// <typeparam name="TUnit">The Unit type.</typeparam>
/// <typeparam name="TUnitType">The Unit's enum type.</typeparam>
public class UnitJsonConverter<TUnit, TUnitType> : JsonConverter<TUnit>
    where TUnit : struct, IUnit<TUnit, TUnitType>
    where TUnitType : struct, Enum
{
    /// <summary>
    /// Reads and converts the JSON to a Unit type.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The converted value.</returns>
    public override TUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of object");
        }

        double value = 0;
        string unitTypeStr = string.Empty;
        bool hasValue = false;
        bool hasUnitType = false;

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected property name");
            }

            var propertyName = reader.GetString();
            reader.Read();

            // Handle different property naming policies
            if (string.Equals(propertyName, "value", StringComparison.OrdinalIgnoreCase))
            {
                if (reader.TokenType == JsonTokenType.Number)
                {
                    value = reader.GetDouble();
                    hasValue = true;
                }
                else
                {
                    throw new JsonException("Value property must be a number");
                }
            }
            else if (string.Equals(propertyName, "unitType", StringComparison.OrdinalIgnoreCase))
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    unitTypeStr = reader.GetString() ?? string.Empty;
                    hasUnitType = true;
                }
                else
                {
                    throw new JsonException("UnitType property must be a string");
                }
            }
            else
            {
                // Skip other properties
                reader.Skip();
            }
        }

        if (!hasValue || !hasUnitType)
        {
            throw new JsonException("Required properties 'value' and 'unitType' not found");
        }

        // Parse the unit type string to the enum value
        TUnitType unitType = (TUnitType)Enum.Parse(typeof(TUnitType), unitTypeStr, true);

        // Try to create the Unit object
        try
        {
            // First try to find a constructor that takes (double, TUnitType)
            ConstructorInfo constructor = typeof(TUnit).GetConstructor(new[] { typeof(double), typeof(TUnitType) });
            if (constructor != null)
            {
                return (TUnit)constructor.Invoke(new object[] { value, unitType });
            }

            // Try to find a static FromCanonical method
            MethodInfo factoryMethod = typeof(TUnit).GetMethod("FromCanonical", BindingFlags.Public | BindingFlags.Static);
            if (factoryMethod != null)
            {
                return (TUnit)factoryMethod.Invoke(null, new object[] { value });
            }

            throw new JsonException($"Could not find a suitable constructor or factory method for {typeof(TUnit).Name}");
        }
        catch (Exception ex) when (ex is not JsonException)
        {
            throw new JsonException($"Error creating {typeof(TUnit).Name}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Writes the Unit type as JSON.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, TUnit value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Get canonical value
        double canonicalValue = value.ToCanonical();

        // Get unit type name
        TUnitType unitType = value.GetCanonicalUnitType();
        string unitTypeName = unitType.ToString();

        // Use naming policy from options if available
        string valuePropName = options.PropertyNamingPolicy != null
            ? options.PropertyNamingPolicy.ConvertName("Value")
            : "Value";

        string unitTypePropName = options.PropertyNamingPolicy != null
            ? options.PropertyNamingPolicy.ConvertName("UnitType")
            : "UnitType";

        writer.WriteNumber(valuePropName, canonicalValue);
        writer.WriteString(unitTypePropName, unitTypeName);

        writer.WriteEndObject();
    }
}