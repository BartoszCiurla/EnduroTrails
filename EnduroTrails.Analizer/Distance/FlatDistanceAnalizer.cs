using System;
using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance
{
    public class FlatDistanceAnalizer:IDistanceAnalizer
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private const double FlatTolerance = 0.0;//todo at this moment i don't know what should be here 

        public FlatDistanceAnalizer(IDistanceLocationsAnalizer distanceLocationsAnalizer)
        {
            _distanceLocationsAnalizer = distanceLocationsAnalizer;
        }

        public double AnalizeDistance(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (IsFlatDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _distanceLocationsAnalizer.DistanceTo(
                        wayPoints[i].Latitude,
                        wayPoints[i].Longitude,
                        wayPoints[j].Latitude,
                        wayPoints[j].Longitude
                        );
            }
            return result;
        }

        private bool IsFlatDistance(double elevationFrom, double elevationTo)
        {
            return Math.Abs(elevationFrom - elevationTo) < FlatTolerance;
        }
    }
}
