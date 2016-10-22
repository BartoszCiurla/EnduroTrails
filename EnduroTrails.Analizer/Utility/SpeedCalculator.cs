using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class SpeedCalculator : ISpeedCalculator
    {
        public double CalculateInKilometerPerHour(double distanceInKm, double timeInSeconds)
            => IsDivisionByZero(timeInSeconds) ? 0 : SpeedInKilometerPerHour(distanceInKm, timeInSeconds);
            
        private bool IsDivisionByZero(double timeInSeconds) => Math.Abs(timeInSeconds) <= 0;

        private double SpeedInKilometerPerHour(double distanceInKm, double timeInSeconds) 
            => Math.Abs(Math.Round((distanceInKm / Math.Abs(timeInSeconds)) * 60 * 60, 0));
    }
}
