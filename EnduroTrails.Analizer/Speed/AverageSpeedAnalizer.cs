using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Speed.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Speed
{
    public class AverageSpeedAnalizer : ISpeedAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly ISpeedCalculator _speedCalculator;
        private readonly IAreaAnalizer _areaAnalizer;

        public AverageSpeedAnalizer(
          ITimeLocationsAnalizer timeLocationsAnalizer,
          IDistanceLocationsAnalizer distanceLocationsAnalizer,
          ISpeedCalculator speedCalculator,
          IAreaAnalizer areaAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _speedCalculator = speedCalculator;
            _areaAnalizer = areaAnalizer;
        }
        public double AnalizeSpeedInKilometerPerHour(WayPoint[] wayPoints)
        {
            double sumSpeed = 0;
            double wayPointsCount = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (!_areaAnalizer.IsArea(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    continue;

                sumSpeed +=
                _speedCalculator.CalculateInKilometerPerHour(
                    _distanceLocationsAnalizer.GetDistanceInMiles(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude),
                    _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time));
                wayPointsCount++;
            }
            return GetAverageSpeed(sumSpeed, wayPointsCount);
        }

        private double GetAverageSpeed(double sumSpeed, double wayPointsCount) => sumSpeed / wayPointsCount;

    }
}
