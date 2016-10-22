using System;
using System.Linq;
using EnduroTrails.Analizer.Elevation.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation
{
    public class FinalElevationBalanceAnalizer : IElevationAnalizer
    {
        public double AnalizeElevationInM(WayPoint[] wayPoints)
        {
            return _getFinalBalance(wayPoints.First().Elevation, wayPoints.Last().Elevation);
        }

        private readonly Func<double, double, double> _getFinalBalance =
            (elevationFrom, elevationTo) =>
                elevationFrom > elevationTo ? SubstractElevation(elevationFrom, elevationTo) * -1 : SubstractElevation(elevationFrom, elevationTo);

        private static double SubstractElevation(double elevationFrom, double elevationTo) => elevationFrom - elevationTo;

    }
}
