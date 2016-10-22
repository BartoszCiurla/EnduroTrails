namespace EnduroTrails.Analizer.Extremum.Abstract
{
    public interface IExtremumElevationAnalizer
    {
        double InitialElevation { get; }
        double GetExtremumElevation(double extremumElevation, double currentElevation);
    }
}
