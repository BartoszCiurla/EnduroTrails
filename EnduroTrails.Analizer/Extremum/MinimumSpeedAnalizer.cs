using System;
using EnduroTrails.Analizer.Extremum.Abstract;

namespace EnduroTrails.Analizer.Extremum
{
    public class MinimumSpeedAnalizer : IExtremumSpeedAnalizer
    {
        private readonly bool _acceptStoppedState;
        public double InitialSpeed => double.MaxValue;

        public MinimumSpeedAnalizer(bool acceptStoppedState = false)
        {
            _acceptStoppedState = acceptStoppedState;
        }

        public double GetExtremumSpeed(double extremumSpeed, double currentSpeed)
            => extremumSpeed > currentSpeed 
            ? 
            IsSpeedEqualToZero(currentSpeed)
                ? 
                AcceptStoppedState(extremumSpeed, currentSpeed) 
                : 
                extremumSpeed
            :
            extremumSpeed;        

        private bool IsSpeedEqualToZero(double currentSpeed) => Math.Abs(Math.Abs(currentSpeed)) <= 0;

        private double AcceptStoppedState(double extremumSpeed, double currentSpeeed)
            => _acceptStoppedState ? currentSpeeed : extremumSpeed;
    }
}
