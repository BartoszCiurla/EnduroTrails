using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class DescentDistanceAnalizer:IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly IDescentAnalizer _descentAnalizer;

        public DescentDistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer,IDescentAnalizer descentAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _descentAnalizer = descentAnalizer;
        }

        public double AnalizeDistanceInMiles(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_descentAnalizer.IsDescentDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
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
