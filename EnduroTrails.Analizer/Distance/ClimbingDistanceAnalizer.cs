using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class ClimbingDistanceAnalizer : IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;

        public ClimbingDistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
        }

        public double AnalizeDistance(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (IsClimbingDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _distanceLocationsAnalizer.DistanceTo(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude
                        );
            }
            return result;
        }

        private bool IsClimbingDistance(double elevationFrom, double elevationTo)
        {
            return elevationFrom < elevationTo;
        } 
    }
}
