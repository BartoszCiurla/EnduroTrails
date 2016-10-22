using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class DistanceLocationsAnalizer:IDistanceLocationsAnalizer
    {
        private readonly double _earthRadiusKm;

        public DistanceLocationsAnalizer(double earthRadiusKm = 6371)
        {
            _earthRadiusKm = earthRadiusKm;
        }

        public double GetDistanceInKm(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo)
        {
            double dLat = ToRad(latitudeTo - latitudeFrom);
            double dLon = ToRad(longitudeTo - longitudeFrom);

            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(latitudeFrom)) * Math.Cos(ToRad(latitudeTo)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = _earthRadiusKm * c;
            return distance;
        }
        private double ToRad(double input) => input * (Math.PI / 180);        
    }
}
