using Meadow.Foundation.Serialization;
using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Meadow.Units.Serialization;

/// <summary>
/// Serialization strategy for IUnit types with MicroJson
/// </summary>
public class MicroJsonUnitJsonConverter : IUnitJsonConverter
{
    /// <summary>
    /// Serializes a Unit object to JSON
    /// </summary>
    /// <param name="obj">The object to serialize</param>
    /// <param name="convertNamesToCamelCase">Whether to convert property names to camel case</param>
    /// <returns>A JSON string representing the Unit object, or null if the object is not a supported Unit type</returns>
    public string? Serialize(object obj, bool convertNamesToCamelCase)
    {
        if (obj == null)
        {
            return null;
        }

        // Check if this is an array/collection of objects
        if (obj is IEnumerable enumerable && !(obj is string))
        {
            return SerializeEnumerable(enumerable, convertNamesToCamelCase);
        }

        // For non-collection objects, check if it's a Unit type
        return SerializeUnitObject(obj, convertNamesToCamelCase);
    }

    private string? SerializeEnumerable(IEnumerable enumerable, bool convertNamesToCamelCase)
    {
        // Check if this enumerable contains unit types by examining the first item
        bool containsUnitTypes = false;
        foreach (var item in enumerable)
        {
            if (item != null && IsUnitType(item.GetType()))
            {
                containsUnitTypes = true;
                break;
            }
        }

        // If no unit types found, return null to allow default serialization
        if (!containsUnitTypes)
        {
            return null;
        }

        var result = new StringBuilder("[");
        bool firstItem = true;

        foreach (var item in enumerable)
        {
            if (!firstItem)
            {
                result.Append(",");
            }

            string? itemJson = Serialize(item, convertNamesToCamelCase);
            if (itemJson == null)
            {
                // For non-unit items in a collection, use default serialization
                itemJson = MicroJson.Serialize(item, new SerializerOptions
                {
                    ConvertNamesToCamelCase = convertNamesToCamelCase
                });
            }

            result.Append(itemJson);
            firstItem = false;
        }

        result.Append("]");
        return result.ToString();
    }

    private string? SerializeUnitObject(object obj, bool convertNamesToCamelCase)
    {
        Type type = obj.GetType();
        if (!IsUnitType(type))
        {
            return null;
        }

        // Find the IUnit<,> interface
        var unitInterfaceType = GetUnitInterfaceType(type)
            ?? throw new Exception("Not a Unit type");

        // Get the canonical value using the ToCanonical method
        var toCanonicalMethod = unitInterfaceType.GetMethod("ToCanonical");
        double value = (double)toCanonicalMethod.Invoke(obj, null);

        // Get the canonical unit type using GetCanonicalUnitType method
        MethodInfo getCanonicalUnitTypeMethod = unitInterfaceType.GetMethod("GetCanonicalUnitType");
        object unitTypeEnum = getCanonicalUnitTypeMethod.Invoke(obj, null);
        string unitType = unitTypeEnum.ToString();

        // Format property names based on camelCase preference
        string jsonValueName = convertNamesToCamelCase ? "value" : "Value";
        string jsonUnitTypeName = convertNamesToCamelCase ? "unitType" : "UnitType";

        // Construct the JSON manually
        return $"{{\"{jsonValueName}\":{value},\"{jsonUnitTypeName}\":\"{unitType}\"}}";
    }

    /// <summary>
    /// Deserializes a JSON string to a Unit object
    /// </summary>
    /// <typeparam name="T">The expected Unit type</typeparam>
    /// <param name="json">The JSON string to deserialize</param>
    /// <returns>A deserialized Unit object, or default value if deserialization fails</returns>
    public T? Deserialize<T>(string json)
    {
        Type targetType = typeof(T);
        var result = Deserialize(json, targetType);
        return (T?)result;
    }

    /// <summary>
    /// Deserializes a JSON string to a Unit object of the specified type
    /// </summary>
    /// <param name="json">The JSON string to deserialize</param>
    /// <param name="targetType">The expected Unit type</param>
    /// <returns>A deserialized Unit object, or null if deserialization fails</returns>
    public object? Deserialize(string json, Type targetType)
    {
        if (string.IsNullOrEmpty(json))
        {
            return GetDefaultValue(targetType);
        }

        if (targetType.IsArray)
        {
            var elementType = targetType.GetElementType();
            return DeserializeArray(json, elementType);
        }

        // Check if the target type is a Unit type
        if (!IsUnitType(targetType))
        {
            throw new ArgumentException($"Type {targetType.Name} is not a valid Unit type");
        }

        // Parse the JSON
        if (MicroJson.Deserialize(json) is not Hashtable parsedJson)
        {
            throw new ArgumentException("Invalid JSON format");
        }

        // Extract value and unit type from JSON
        if (!parsedJson.Contains("value") && !parsedJson.Contains("Value"))
        {
            throw new ArgumentException("JSON is missing a 'value' property");
        }

        if (!parsedJson.Contains("unitType") && !parsedJson.Contains("UnitType"))
        {
            throw new ArgumentException("JSON is missing a 'unitType' property");
        }

        double value = GetJsonValue(parsedJson);
        string unitTypeString = GetJsonUnitType(parsedJson);

        // Get the Unit interface type
        var unitInterfaceType = GetUnitInterfaceType(targetType);
        Type[] genericArgs = unitInterfaceType?.GetGenericArguments()
            ?? throw new Exception($"{targetType} is not an IUnit");

        Type unitEnumType = genericArgs[1]; // TUnit type

        // Parse the unit type string to the enum value
        object unitTypeEnum = Enum.Parse(unitEnumType, unitTypeString, true);

        // Find a constructor that takes a double and the unit type enum
        ConstructorInfo constructor = targetType.GetConstructor(new[] { typeof(double), unitEnumType });
        if (constructor != null)
        {
            // Create the unit object using the constructor
            return constructor.Invoke(new[] { value, unitTypeEnum });
        }

        // If no direct constructor, try to use a static factory method named FromCanonical
        MethodInfo factoryMethod = targetType.GetMethod("FromCanonical", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(double) }, null);
        if (factoryMethod != null)
        {
            return factoryMethod.Invoke(null, new object[] { value });
        }

        // If we can't find a suitable constructor or factory method
        throw new NotSupportedException($"Could not find a suitable constructor or factory method for {targetType.Name}");
    }

    /// <summary>
    /// Deserializes a JSON array to an array of objects of the specified type
    /// </summary>
    /// <param name="json">The JSON array string to deserialize</param>
    /// <param name="elementType">The type of elements in the array</param>
    /// <returns>An array of deserialized objects</returns>
    private Array DeserializeArray(string json, Type elementType)
    {
        if (string.IsNullOrEmpty(json))
        {
            return Array.CreateInstance(elementType, 0);
        }

        if (MicroJson.Deserialize(json) is not ArrayList arrayList)
        {
            throw new ArgumentException("JSON is not a valid array");
        }

        var result = Array.CreateInstance(elementType, arrayList.Count);
        for (int i = 0; i < arrayList.Count; i++)
        {
            if (arrayList[i] is Hashtable itemJson)
            {
                var itemJsonString = MicroJson.Serialize(itemJson);
                result.SetValue(Deserialize(itemJsonString ?? string.Empty, elementType), i);
            }
            else
            {
                throw new ArgumentException($"Invalid item at index {i} in the JSON array");
            }
        }

        return result;
    }

    private double GetJsonValue(Hashtable json)
    {
        object valueObj = json["value"] ?? json["Value"];
        if (valueObj is double doubleValue)
        {
            return doubleValue;
        }
        else if (valueObj is long longValue)
        {
            return longValue;
        }
        return Convert.ToDouble(valueObj);
    }

    private string GetJsonUnitType(Hashtable json)
    {
        object unitTypeObj = json["unitType"] ?? json["UnitType"];
        return unitTypeObj.ToString();
    }

    private bool IsUnitType(Type type)
    {
        return GetUnitInterfaceType(type) != null;
    }

    private Type? GetUnitInterfaceType(Type type)
    {
        foreach (var interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition() == typeof(IUnit<,>))
            {
                return interfaceType;
            }
        }
        return null;
    }

    private object? GetDefaultValue(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
