using EnduroTrails.Analizer.Area;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Distance;
using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Factory
{
    public class DistanceAnalizerFactory
    {
        private readonly IDistanceLocationsAnalizer _distanceLocationAnalizer;
        private readonly IAreaAnalizer _anyAreaAnalizer;
        private readonly IAreaAnalizer _descentAreaAnalizer;
        private readonly IAreaAnalizer _climbingAreaAnalizer;
        private readonly IAreaAnalizer _flatAreaAnalizer;

        public DistanceAnalizerFactory()
        {
            _distanceLocationAnalizer = new DistanceLocationsAnalizer();
            _anyAreaAnalizer = new AnyAreaAnalizer();
            _descentAreaAnalizer = new DescentAnalizer();
            _climbingAreaAnalizer = new ClimbingAnalizer();
            _flatAreaAnalizer = new FlatAnalizer();
        }

        public IDistanceAnalizer TotalDistance() => DistanceAnalizer(_anyAreaAnalizer);

        public IDistanceAnalizer ClimbingDistance() => DistanceAnalizer(_climbingAreaAnalizer);

        public IDistanceAnalizer DescentDistance() => DistanceAnalizer(_descentAreaAnalizer);

        public IDistanceAnalizer FlatDistance() => DistanceAnalizer(_flatAreaAnalizer);

        private IDistanceAnalizer DistanceAnalizer(IAreaAnalizer areaAnalizer)
            => new DistanceAnalizer(_distanceLocationAnalizer, areaAnalizer);


    }
}
