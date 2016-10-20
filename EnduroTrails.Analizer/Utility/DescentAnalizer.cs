using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class DescentAnalizer : IDescentAnalizer
    {
        public bool IsDescentDistance(double elevationFrom, double elevationTo) => elevationFrom > elevationTo;
    }
}
