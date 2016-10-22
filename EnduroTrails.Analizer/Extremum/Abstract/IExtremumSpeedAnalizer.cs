namespace EnduroTrails.Analizer.Extremum.Abstract
{
    public interface IExtremumSpeedAnalizer
    {
        double InitialSpeed { get; }
        double GetExtremumSpeed(double extremumSpeed, double currentSpeed);        
    }
}
