namespace Meadow.Units.Serialization;

/// <summary>
/// Proxy class for serializing units with MicroJson
/// </summary>
internal class UnitSerializationProxy
{
    /// <summary>
    /// The canonical value
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// The unit type as a string
    /// </summary>
    public string UnitType { get; set; }

    /// <summary>
    /// Default constructor for deserialization
    /// </summary>
    public UnitSerializationProxy()
    {
        UnitType = "";
    }

    /// <summary>
    /// Create a proxy from a unit
    /// </summary>
    public UnitSerializationProxy(double value, string unitType)
    {
        Value = value;
        UnitType = unitType;
    }
}
