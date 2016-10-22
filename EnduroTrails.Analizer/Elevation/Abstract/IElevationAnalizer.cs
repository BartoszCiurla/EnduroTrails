using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation.Abstract
{
    public interface IElevationAnalizer
    {
        double AnalizeElevationInM(WayPoint[] wayPoints);
    }
}
