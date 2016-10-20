using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class FlatDistanceAnalizer:IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly IFlatAnalizer _flatAnalizer;


        public FlatDistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer,IFlatAnalizer flatAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _flatAnalizer = flatAnalizer;
        }

        public double AnalizeDistance(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_flatAnalizer.IsFlatDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _distanceLocationsAnalizer.DistanceTo(
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
