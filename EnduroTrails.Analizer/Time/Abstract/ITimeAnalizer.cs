using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Time.Abstract
{
    public interface ITimeAnalizer
    {
        double AnalizeTime(WayPoint[] wayPoints);
    }
}
