namespace Meadow.Units;

/// <summary>
/// Represents a location on the surface of an ideal Earth (latitude and longitude)
/// </summary>
public record GeoLocation
{
    private static Length? _earthRadius;

    /// <summary>
    /// Idealized earth radius used for internal calculations
    /// </summary>
    public static Length EarthRadius => _earthRadius ??= new Length(6371.01, Length.UnitType.Kilometers);

    /// <summary>
    /// The latitude portion of the GeoLocation
    /// </summary>
    public double Latitude { get; set; }
    /// <summary>
    /// The Longitude portion of the GeoLocation
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Creates a GeoLocation instance
    /// </summary>
    public GeoLocation()
    {
        Latitude = 0;
        Longitude = 0;
    }

    /// <summary>
    /// Creates a GeoLocation instance
    /// </summary>
    /// <param name="latitude">The latitude portion of the GeoLocation</param>
    /// <param name="longitude">The longitude portion of the GeoLocation</param>
    public GeoLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}