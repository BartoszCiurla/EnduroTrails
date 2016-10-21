using EnduroTrails.Analizer.Speed.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Speed
{
    public class MaximumSpeedAnalizer:ISpeedAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly ISpeedCalculator _speedCalculator;

        public MaximumSpeedAnalizer(
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
            double maximumSpeed = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                maximumSpeed = GetHigherSpeed( 
                    maximumSpeed,
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
            return maximumSpeed;
        }

        private double GetHigherSpeed(double maximumSpeed, double currentSpeed)
            => maximumSpeed < currentSpeed ? currentSpeed : maximumSpeed;
    }
}
