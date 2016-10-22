using EnduroTrails.Analizer.Area.Abstract;

namespace EnduroTrails.Analizer.Area
{
    public class DescentAnalizer : IAreaAnalizer
    {
        public bool IsArea(double elevationFrom, double elevationTo) => elevationFrom > elevationTo;
        public double GetTotalElevation(double elevation) => elevation;    
    }
}
