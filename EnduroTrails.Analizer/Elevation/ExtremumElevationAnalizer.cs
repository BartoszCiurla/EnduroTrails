using System.Linq;
using EnduroTrails.Analizer.Elevation.Abstract;
using EnduroTrails.Analizer.Extremum.Abstract;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer.Elevation
{
    public class ExtremumElevationAnalizer:IElevationAnalizer
    {
        private readonly IExtremumElevationAnalizer _extremumElevationAnalizer;

        public ExtremumElevationAnalizer(IExtremumElevationAnalizer extremumElevationAnalizer)
        {
            _extremumElevationAnalizer = extremumElevationAnalizer;
        }

        public double AnalizeElevationInM(WayPoint[] wayPoints) 
            => wayPoints
                .Aggregate(_extremumElevationAnalizer.InitialElevation, (currentElevation, wayPoint)
                => _extremumElevationAnalizer.GetExtremumElevation(currentElevation, wayPoint.Elevation));
    }
}
