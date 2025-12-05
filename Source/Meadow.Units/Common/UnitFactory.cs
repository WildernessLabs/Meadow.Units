using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Meadow.Units;

/// <summary>
/// Factory methods for unit creation
/// </summary>
public class UnitFactory
{
    private static readonly ConcurrentDictionary<string, MethodInfo> _fromCanonicalCache = new();
    private static readonly ConcurrentDictionary<string, Type> _unitTypeCache = new();

    /// <summary>
    /// Method to create a unit from its canonical value.
    /// </summary>
    /// <param name="value">The canonical value to use for creation</param>
    /// <param name="unitTypeName">The (case-insensitive) name of the Unit to be created</param>
    /// <returns>A unit instance with the specified canonical value</returns>
    /// <exception cref="NotSupportedException">Thrown when the unit type is not found or doesn't have a FromCanonical method</exception>
    public static object CreateUnitFromCanonicalValue(double value, string unitTypeName)
    {
        var normalizedName = unitTypeName.ToLower();

        // Get the FromCanonical method from cache or discover it
        if (!_fromCanonicalCache.TryGetValue(normalizedName, out var fromCanonicalMethod))
        {
            // Find the unit type
            var unitType = GetUnitType(unitTypeName);
            if (unitType == null)
            {
                throw new NotSupportedException($"Unit type '{unitTypeName}' is not supported.");
            }

            // Find the FromCanonical static method
            fromCanonicalMethod = unitType.GetMethod(
                "FromCanonical",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(double) },
                null);

            if (fromCanonicalMethod == null)
            {
                throw new NotSupportedException($"Unit type '{unitTypeName}' does not have a FromCanonical method.");
            }

            _fromCanonicalCache[normalizedName] = fromCanonicalMethod;
        }

        // Invoke the FromCanonical method
        return fromCanonicalMethod.Invoke(null, new object[] { value });
    }

    /// <summary>
    /// Gets the Type for a unit by name, using cache for performance
    /// </summary>
    private static Type GetUnitType(string unitTypeName)
    {
        var normalizedName = unitTypeName.ToLower();

        if (!_unitTypeCache.TryGetValue(normalizedName, out var unitType))
        {
            // Search for the type in the current assembly
            var assembly = typeof(UnitFactory).Assembly;
            unitType = assembly.GetTypes()
                .FirstOrDefault(t => t.Namespace == "Meadow.Units" &&
                                    t.Name.Equals(unitTypeName, StringComparison.OrdinalIgnoreCase) &&
                                    t.IsValueType &&
                                    typeof(IUnit).IsAssignableFrom(t));

            if (unitType != null)
            {
                _unitTypeCache[normalizedName] = unitType;
            }
        }

        return unitType ?? throw new NotSupportedException("provided type name not supported");
    }
}
