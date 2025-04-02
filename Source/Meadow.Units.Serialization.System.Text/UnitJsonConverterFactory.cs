using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meadow.Units.Serialization;

/// <summary>
/// A JsonConverterFactory for handling any type that implements IUnit&lt;TSelf, TUnit&gt;
/// </summary>
public class UnitJsonConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Determines whether the converter can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to check.</param>
    /// <returns>True if the type implements IUnit&lt;,&gt;; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return IsUnitType(typeToConvert);
    }

    /// <summary>
    /// Creates a converter for the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to create a converter for.</param>
    /// <param name="options">The serializer options to use.</param>
    /// <returns>A converter that can convert the specified type.</returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var unitInterfaceType = GetUnitInterfaceType(typeToConvert);
        if (unitInterfaceType == null)
        {
            throw new ArgumentException($"Type {typeToConvert.Name} is not a valid Unit type");
        }

        Type[] genericArgs = unitInterfaceType.GetGenericArguments();
        var unitConverterType = typeof(UnitJsonConverter<,>).MakeGenericType(typeToConvert, genericArgs[1]);

        return (JsonConverter)Activator.CreateInstance(unitConverterType);
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
}
