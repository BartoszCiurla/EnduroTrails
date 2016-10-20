using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class ClimbingAnalizer : IClimbingAnalizer
    {
        public bool IsClimbingDistance(double elevationFrom, double elevationTo) => elevationFrom < elevationTo;
    }
}
