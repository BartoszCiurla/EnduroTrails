using System;
using EnduroTrails.Analizer.Speed.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Speed
{
    public class MinimumSpeedAnalizer : ISpeedAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly ISpeedCalculator _speedCalculator;

        public MinimumSpeedAnalizer(
            ITimeLocationsAnalizer timeLocationsAnalizer, 
            IDistanceLocationsAnalizer distanceLocationsAnalizer, 
            ISpeedCalculator speedCalculator)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _speedCalculator = speedCalculator;
        }

        public double AnalizeSpeedInKilometerPerHour(WayPoint[] wayPoints)
        {
            double minimumSpeed = Double.MaxValue;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                minimumSpeed = GetLowerSpeed(
                    minimumSpeed, 
                    _speedCalculator
                    .CalculateInKilometerPerHour(
                    _distanceLocationsAnalizer.GetDistanceInMiles(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude),
                    _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time)
                    ));
            }
            return minimumSpeed;
        }

        private double GetLowerSpeed(double minimumSpeed, double currentSpeed)
            => minimumSpeed > currentSpeed ? currentSpeed : minimumSpeed;
    }
}
