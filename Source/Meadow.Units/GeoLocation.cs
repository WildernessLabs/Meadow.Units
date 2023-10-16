using System;
using System.Diagnostics.Contracts;

namespace Meadow.Units
{
    /// <summary>
    /// Represents a location on the surface of an ideal Earth (latitude and longitude)
    /// </summary>
    public record GeoLocation
    {
        /// <summary>
        /// Idealized earth radius used for internal calculations
        /// </summary>
        public Length EarthRadius => new Length(6371.01, Length.UnitType.Kilometers);

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
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

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
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public Length DistanceTo(GeoLocation other)
        {
            var diffLat = DegreesToRadians(other.Latitude - this.Latitude);
            var diffLong = DegreesToRadians(other.Longitude - this.Longitude);

            var a = Math.Sin(diffLat / 2) * Math.Sin(diffLat / 2) +
                    Math.Cos(DegreesToRadians(this.Latitude)) * Math.Cos(DegreesToRadians(other.Latitude)) *
                    Math.Sin(diffLong / 2) * Math.Sin(diffLong / 2);
            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = EarthRadius * c;

            return d;
        }

        /// <summary>
        /// Calculates the bearing to another GeoLocation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public Azimuth BearingTo(GeoLocation other)
        {
            var dLon = DegreesToRadians(other.Longitude - this.Longitude);
            var dPhi = Math.Log(Math.Tan(DegreesToRadians(other.Latitude) / 2 + Math.PI / 4) / Math.Tan(DegreesToRadians(this.Latitude) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
            {
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            }

            return Azimuth.FromRadians(Math.Atan2(dLon, dPhi));
        }

        /// <summary>
        /// Creates a new GeoLocation a given bearing and distance from the current GeoLocation
        /// </summary>
        /// <param name="bearing">Bearing angle to the new location</param>
        /// <param name="distance">Distance to the new location</param>
        /// <returns></returns>
        [Pure]
        public GeoLocation Move(Azimuth bearing, Length distance) // double initialBearingRadians, double distanceKilometres)
        {
            var distRatio = distance.Meters / EarthRadius.Meters;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(this.Latitude);
            var startLonRad = DegreesToRadians(this.Longitude);

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
}