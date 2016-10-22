using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class TimeLocationsAnalizer:ITimeLocationsAnalizer
    {
        private readonly double _timeToleranceInSeconds;
        private readonly double _noTolerance = 0;

        public TimeLocationsAnalizer(double timeToleranceInSeconds = 30)
        {
            _timeToleranceInSeconds = timeToleranceInSeconds;
        }

        public double GetTimeInSeconds(DateTime timeStart, DateTime timeEnd) 
            => WhichTimeTolerance(Math.Round((timeEnd.Subtract(timeStart)).TotalSeconds));        

        private double WhichTimeTolerance(double timeInSeconds) 
            => _timeToleranceInSeconds > timeInSeconds ? timeInSeconds : _noTolerance;
    }
}
