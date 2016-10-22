using EnduroTrails.Analizer.Elevation.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation
{
    public class AverageElevationAnalizer:IElevationAnalizer
    {
        public double AnalizeElevationInM(WayPoint[] wayPoints)
        {
            double elevationSum = 0;
            for (var i = 0; i < wayPoints.Length; i++)
            {
                elevationSum =(elevationSum + wayPoints[i].Elevation)/i;
            }
            return elevationSum;
        }
    }    
}
