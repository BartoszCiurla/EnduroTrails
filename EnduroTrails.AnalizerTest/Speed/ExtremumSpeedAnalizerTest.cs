using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Extremum;
using EnduroTrails.Analizer.Extremum.Abstract;
using EnduroTrails.Analizer.Speed;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.Model;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.AnalizerTest.Speed
{
    public class ExtremumSpeedAnalizerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly TimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly DistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly SpeedCalculator _speedCalculator;
        private readonly IExtremumSpeedAnalizer _minimumSpeedAnalizer;
        private readonly IExtremumSpeedAnalizer _maximumSpeedAnalizer;
        private readonly WayPoint[] _wayPoints;

        public ExtremumSpeedAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints().ToArray();
            _timeLocationsAnalizer = new TimeLocationsAnalizer();
            _distanceLocationsAnalizer = new DistanceLocationsAnalizer();
            _speedCalculator = new SpeedCalculator();
            _minimumSpeedAnalizer = new MinimumSpeedAnalizer();
            _maximumSpeedAnalizer = new MaximumSpeedAnalizer();
        }

        [Fact]
        public void MinimumSpeed()
        {
            var mininumSpeedAnalizer = new ExtremumSpeedAnalizer(_timeLocationsAnalizer, _distanceLocationsAnalizer, _speedCalculator, _minimumSpeedAnalizer);

            double result = mininumSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.InRange(result,0,10);
            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void MaximumSpeed()
        {
            var maximumSpeedAnalizer = new ExtremumSpeedAnalizer(_timeLocationsAnalizer, _distanceLocationsAnalizer, _speedCalculator, _maximumSpeedAnalizer);

            double result = maximumSpeedAnalizer.AnalizeSpeedInKilometerPerHour(_wayPoints);

            Assert.True(result > 0);
            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }
    }
}
