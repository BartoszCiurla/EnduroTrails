using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class TimeLocationsAnalizer:ITimeLocationsAnalizer
    {
        private readonly double _timeTolerance;
        private readonly double _noTolerance = 0;

        public TimeLocationsAnalizer(double timeTolerance = 15)
        {
            _timeTolerance = timeTolerance;
        }

        public double TimeTo(DateTime timeStart, DateTime timeEnd) => WhichTimeTolerance(Math.Abs((timeStart - timeEnd).TotalSeconds));        

        private double WhichTimeTolerance(double timeInSeconds) => _timeTolerance > timeInSeconds ? timeInSeconds : _noTolerance;
    }
}
