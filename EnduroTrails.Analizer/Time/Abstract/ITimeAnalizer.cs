using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time.Abstract
{
    public interface ITimeAnalizer
    {
        double AnalizeTimeInSeconds(WayPoint[] wayPoints);
    }
}
