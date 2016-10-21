using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class DistanceAnalizer:IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly IAreaAnalizer _areaAnalizer;

        public DistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer,IAreaAnalizer areaAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
            _areaAnalizer = areaAnalizer;
        }

        public double AnalizeDistanceInMiles(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if(_areaAnalizer.IsArea(wayPoints[i].Elevation,wayPoints[j].Elevation))
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
