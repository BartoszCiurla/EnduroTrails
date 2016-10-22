using EnduroTrails.Analizer.Extremum.Abstract;

namespace EnduroTrails.Analizer.Extremum
{
    public class MaximumSpeedAnalizer:IExtremumSpeedAnalizer
    {
        public double GetExtremumSpeed(double extremumSpeed, double currentSpeed) 
            => extremumSpeed < currentSpeed ? currentSpeed : extremumSpeed;

        public double InitialSpeed => double.MinValue;
    }
}
