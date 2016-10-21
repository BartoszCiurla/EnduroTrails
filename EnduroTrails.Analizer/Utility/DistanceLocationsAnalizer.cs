using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class DistanceLocationsAnalizer:IDistanceLocationsAnalizer
    {
        public double GetDistanceInMiles(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo)
        {
            var radFrom = Math.PI * latitudeFrom / 180;
            var radTo = Math.PI * latitudeTo / 180;
            var theta = longitudeFrom - longitudeTo;
            var thetaRad = Math.PI * theta / 180;

            double distance =
                Math.Sin(radFrom) * Math.Sin(radTo) + Math.Cos(radFrom) *
                Math.Cos(radTo) * Math.Cos(thetaRad);
            distance = Math.Acos(distance);

            distance = distance * 180 / Math.PI;
            distance = distance * 60 * 1.1515;
            return distance;
        }
    }
}
