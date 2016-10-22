using System.Linq;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Elevation.Abstract;
using EnduroTrails.Analizer.Extremum.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation
{
    public class AverageElevationAnalizer:IElevationAnalizer
    {
        public double AnalizeElevationInM(WayPoint[] wayPoints)
        {
            double elevationSum = 0;
            double wayPointsCount = 0;
            for (int i = 0,j = 1; j < wayPoints.Length;i++,j++)
            {
                elevationSum += wayPoints[i].Elevation;
                wayPointsCount++;
            }
            return GetAverageElevation(elevationSum, wayPointsCount);
        }

        private double GetAverageElevation(double elevationSum, double wayPointsCount) => elevationSum/wayPointsCount;
    }    
}
