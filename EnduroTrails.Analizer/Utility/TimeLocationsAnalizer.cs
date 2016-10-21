using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class TimeLocationsAnalizer:ITimeLocationsAnalizer
    {
        private readonly double _timeTolerance;
        private readonly double _noTolerance = 0;

        public TimeLocationsAnalizer(double timeTolerance = 560)
        {
            _timeTolerance = timeTolerance;
        }

        public double GetTimeInSeconds(DateTime timeStart, DateTime timeEnd) => WhichTimeTolerance(Math.Round((timeEnd.Subtract(timeStart)).TotalSeconds, 0));        

        private double WhichTimeTolerance(double timeInSeconds) => _timeTolerance > timeInSeconds ? timeInSeconds : _noTolerance;
    }
}
