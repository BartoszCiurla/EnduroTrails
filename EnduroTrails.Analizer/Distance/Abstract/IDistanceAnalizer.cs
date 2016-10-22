using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Distance.Abstract
{
    public interface IDistanceAnalizer
    {
        double AnalizeDistanceInKm(WayPoint[] wayPoints);
    }
}
