using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class ClimbingDistanceAnalizer : IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly IClimbingAnalizer _climbingAnalizer;

        public ClimbingDistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer,IClimbingAnalizer climbingAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _climbingAnalizer = climbingAnalizer;
        }

        public double AnalizeDistanceInMiles(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_climbingAnalizer.IsClimbingDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _distanceLocationsAnalizer.GetDistanceInMiles(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude
                        );
            }
            return result;
        }       
    }
}
