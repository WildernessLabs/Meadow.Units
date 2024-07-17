namespace Meadow.Units;

/// <summary>
/// A geographic 
/// </summary>
public record GeographicCoordinate : GeoLocation
{
    /// <summary>
    /// The altitude portion of the GeographicCoordinate
    /// </summary>
    public Length Altitude { get; set; }
}
