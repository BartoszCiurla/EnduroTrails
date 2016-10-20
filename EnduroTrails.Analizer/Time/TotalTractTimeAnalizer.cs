using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time
{
    public class TotalTractTimeAnalizer:ITimeAnalizer
    {
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;

        public TotalTractTimeAnalizer(ITimeLocationsAnalizer timeLocationsAnalizer)
        {
            _timeLocationsAnalizer = timeLocationsAnalizer;
        }

        public double AnalizeTime(WayPoint[] wayPoints)
        {
            double result = 0;
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                result += _timeLocationsAnalizer.TimeTo(wayPoints[i].Time, wayPoints[j].Time);
            }
            return result;
        }
    }
}
