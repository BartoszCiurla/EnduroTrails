using EnduroTrails.Analizer.Extremum.Abstract;
using EnduroTrails.Analizer.Speed.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Speed
{
    public class ExtremumSpeedAnalizer:ISpeedAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly ISpeedCalculator _speedCalculator;
        private readonly IExtremumSpeedAnalizer _extremumSpeedAnalizer;

        public ExtremumSpeedAnalizer(
            ITimeLocationsAnalizer timeLocationsAnalizer,
            IDistanceLocationsAnalizer distanceLocationsAnalizer,
            ISpeedCalculator speedCalculator,
            IExtremumSpeedAnalizer extremumSpeedAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _speedCalculator = speedCalculator;
            _extremumSpeedAnalizer = extremumSpeedAnalizer;
        }
        public double AnalizeSpeedInKilometerPerHour(WayPoint[] wayPoints)
        {
            double extremumSpeed = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                extremumSpeed = _extremumSpeedAnalizer.GetExtremumSpeed(
                    extremumSpeed,
                    _speedCalculator.CalculateInKilometerPerHour(
                    _distanceLocationsAnalizer.GetDistanceInMiles(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude),
                    _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time)
                    ));
            }
            return extremumSpeed;
        }
    }
}
