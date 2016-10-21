using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time
{
    public class FlatTimeAnalizer : ITimeAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IFlatAnalizer _flatAnalizer;

        public FlatTimeAnalizer(ITimeLocationsAnalizer timeLocationsAnalizer, IFlatAnalizer flatAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
            _flatAnalizer = flatAnalizer;
        }

        public double AnalizeTimeInSeconds(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                if (_flatAnalizer.IsFlatDistance(wayPoints[i].Elevation, wayPoints[j].Elevation))
                    result += _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time);
            }
            return result;
        }
    }
}
