using System;
using System.Diagnostics.Contracts;

namespace Meadow.Units;

/// <summary>
/// Extension methods for the GeoLocation struct
/// </summary>
public static class GeoLocationExtensions
{
    [Pure]
    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    [Pure]
    private static double RadiansToDegrees(double radians)
    {
        return radians * 180 / Math.PI;
    }

    /// <summary>
    /// Calculates the distance to another GeoLocation
    /// </summary>
    /// <param name="self">A Geolocation</param>
    /// <param name="other">A second GeoLocation</param>
    [Pure]
    public static Length DistanceTo(this GeoLocation self, GeoLocation other)
    {
        var diffLat = DegreesToRadians(other.Latitude - self.Latitude);
        var diffLong = DegreesToRadians(other.Longitude - self.Longitude);

        var a = Math.Sin(diffLat / 2) * Math.Sin(diffLat / 2) +
                Math.Cos(DegreesToRadians(self.Latitude)) * Math.Cos(DegreesToRadians(other.Latitude)) *
                Math.Sin(diffLong / 2) * Math.Sin(diffLong / 2);
        var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        var d = GeoLocation.EarthRadius * c;

        return d;
    }

    /// <summary>
    /// Calculates the bearing to another GeoLocation
    /// </summary>
    /// <param name="self">A Geolocation</param>
    /// <param name="other">A second GeoLocation</param>
    [Pure]
    public static Azimuth BearingTo(this GeoLocation self, GeoLocation other)
    {
        var dLon = DegreesToRadians(other.Longitude - self.Longitude);
        var dPhi = Math.Log(Math.Tan(DegreesToRadians(other.Latitude) / 2 + Math.PI / 4) / Math.Tan(DegreesToRadians(self.Latitude) / 2 + Math.PI / 4));
        if (Math.Abs(dLon) > Math.PI)
        {
            dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
        }

        return Azimuth.FromRadians(Math.Atan2(dLon, dPhi));
    }

    /// <summary>
    /// Creates a new GeoLocation a given bearing and distance from the current GeoLocation
    /// </summary>
    /// <param name="self">A Geolocation</param>
    /// <param name="bearing">Bearing angle to the new location</param>
    /// <param name="distance">Distance to the new location</param>
    [Pure]
    public static GeoLocation Move(this GeoLocation self, Azimuth bearing, Length distance) // double initialBearingRadians, double distanceKilometres)
    {
        var distRatio = distance.Meters / GeoLocation.EarthRadius.Meters;
        var distRatioSine = Math.Sin(distRatio);
        var distRatioCosine = Math.Cos(distRatio);

        var startLatRad = DegreesToRadians(self.Latitude);
        var startLonRad = DegreesToRadians(self.Longitude);

        var startLatCos = Math.Cos(startLatRad);
        var startLatSin = Math.Sin(startLatRad);

        var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(bearing.Radians)));

        var endLonRads = startLonRad
                         + Math.Atan2(
                             Math.Sin(bearing.Radians) * distRatioSine * startLatCos,
                             distRatioCosine - startLatSin * Math.Sin(endLatRads));

        return new GeoLocation(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
    }
}
