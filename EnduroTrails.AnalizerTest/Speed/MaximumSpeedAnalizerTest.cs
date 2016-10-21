using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Speed;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Speed
{
    public class MaximumSpeedAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly MaximumSpeedAnalizer _maximumSpeedAnalizer;

        public MaximumSpeedAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            var timeLocationAnalizer = new TimeLocationsAnalizer();
            var distanceLocationAnalizer = new DistanceLocationsAnalizer();
            var speedCalculator = new SpeedCalculator();
            _maximumSpeedAnalizer = new MaximumSpeedAnalizer(timeLocationAnalizer, distanceLocationAnalizer, speedCalculator);
        }

        [Fact]
        public void MaximumSpeed()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = _maximumSpeedAnalizer.AnalizeSpeedInKilometerPerHour(wayPoints);

            Assert.True(result > 0);
        }
    }
}
