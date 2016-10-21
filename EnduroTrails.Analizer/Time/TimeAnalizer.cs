using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time
{
    public class TimeAnalizer : ITimeAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IAreaAnalizer _areaAnalizer;

        public TimeAnalizer(ITimeLocationsAnalizer timeLocationsAnalizer, IAreaAnalizer areaAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _areaAnalizer = areaAnalizer;
        }

        public double AnalizeTimeInSeconds(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_areaAnalizer.IsArea(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time);
            }
            return result;
        }
    }
}
