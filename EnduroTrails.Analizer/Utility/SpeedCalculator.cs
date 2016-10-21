using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class SpeedCalculator : ISpeedCalculator
    {
        public double CalculateInKilometerPerHour(double distanceInMiles, double timeInSeconds)
            => IsDivisionByZero(timeInSeconds) ? 0 : SpeedInKilometerPerHour(distanceInMiles, timeInSeconds);
            
        private bool IsDivisionByZero(double timeInSeconds) => Math.Abs(timeInSeconds) <= 0;

        private double SpeedInKilometerPerHour(double distanceInMiles, double timeInSeconds) 
            => Math.Abs(Math.Round(((distanceInMiles * 1.609344) / Math.Abs(timeInSeconds)) * 60 * 60, 0));
    }
}
