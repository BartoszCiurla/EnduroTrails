using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Elevation.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation
{
    public class TotalElevationAnalizer:IElevationAnalizer
    {
        private readonly IAreaAnalizer _areaAnalizer;

        public TotalElevationAnalizer(IAreaAnalizer areaAnalizer)
        {
            _areaAnalizer = areaAnalizer;
        }

        public double AnalizeElevationInM(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_areaAnalizer.IsArea(wayPoints[i].Elevation, wayPoints[j].Elevation))
                {
                    result += wayPoints[i].Elevation - wayPoints[j].Elevation;
                }
            }
            return _areaAnalizer.GetTotalElevation(result);
        }
    }
}
