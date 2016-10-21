using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time
{
    public class ClimbingTimeAnalizer : ITimeAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IClimbingAnalizer _climbingAnalizer;

        public ClimbingTimeAnalizer(ITimeLocationsAnalizer timeLocationsAnalizer, IClimbingAnalizer climbingAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _climbingAnalizer = climbingAnalizer;
        }

        public double AnalizeTimeInSeconds(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_climbingAnalizer.IsClimbingDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time);
            }
            return result;
        }
    }
}
