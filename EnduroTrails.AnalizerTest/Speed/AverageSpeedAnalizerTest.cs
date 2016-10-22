using System.Globalization;
using System.Linq;
using EnduroTrails.Analizer.Area;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Speed;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.Model;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.AnalizerTest.Speed
{
    public class AverageSpeedAnalizerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WayPoint[] _wayPoints;

        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly ISpeedCalculator _speedCalculator;

        private readonly IAreaAnalizer _climbingAnalizer;
        private readonly IAreaAnalizer _descentAnalizer;
        private readonly IAreaAnalizer _flatAnalizer;
        private readonly IAreaAnalizer _anyAreaAnalizer;

        public AverageSpeedAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints().ToArray();


            _timeLocationsAnalizer = new TimeLocationsAnalizer();
            _distanceLocationsAnalizer = new DistanceLocationsAnalizer();
            _speedCalculator = new SpeedCalculator();

            _climbingAnalizer = new ClimbingAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _flatAnalizer = new FlatAnalizer();
            _anyAreaAnalizer = new AnyAreaAnalizer();
        }

        [Fact]
        public void AverageSpeed()
        {
            var averageSpeedAnalizer = new AverageSpeedAnalizer(_timeLocationsAnalizer,_distanceLocationsAnalizer,_speedCalculator,_anyAreaAnalizer);

            double result = averageSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.InRange(result, 0, 20);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void AverageClimbingSpeed()
        {
            var averageClimbingSpeedAnalizer = new AverageSpeedAnalizer(_timeLocationsAnalizer, _distanceLocationsAnalizer, _speedCalculator, _climbingAnalizer);

            double result = averageClimbingSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.InRange(result, 0, 20);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void AverageDescentSpeed()
        {
            var averageDescentSpeedAnalizer = new AverageSpeedAnalizer(_timeLocationsAnalizer, _distanceLocationsAnalizer, _speedCalculator, _descentAnalizer);

            double result = averageDescentSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.InRange(result, 0, 50);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void AverageFlatSpeed()
        {
            var averageFlatSpeedAnalizer = new AverageSpeedAnalizer(_timeLocationsAnalizer, _distanceLocationsAnalizer, _speedCalculator, _flatAnalizer);

            double result = averageFlatSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.InRange(result, 0, 20);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }
    }
}
