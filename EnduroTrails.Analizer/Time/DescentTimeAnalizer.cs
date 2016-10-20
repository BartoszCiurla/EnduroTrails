using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time
{
    public class DescentTimeAnalizer:ITimeAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDescentAnalizer _descentAnalizer;

        public DescentTimeAnalizer(ITimeLocationsAnalizer timeLocationsAnalizer,IDescentAnalizer descentAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _descentAnalizer = descentAnalizer;
        }

        public double AnalizeTime(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_descentAnalizer.IsDescentDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _timeLocationsAnalizer.TimeTo(wayPoints[i].Time, wayPoints[j].Time);
            }
            return result;
        }
    }
}
