using System.Linq;
using EnduroTrails.Analizer.Speed;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Speed
{
    public class MinimumSpeedAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly MinimumSpeedAnalizer _minimumSpeedAnalizer;

        public MinimumSpeedAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            var timeLocationAnalizer = new TimeLocationsAnalizer();
            var distanceLocationAnalizer = new DistanceLocationsAnalizer();
            var speedCalculator = new SpeedCalculator();
            _minimumSpeedAnalizer = new MinimumSpeedAnalizer(timeLocationAnalizer,distanceLocationAnalizer,speedCalculator);
        }        

        [Fact]
        public void MinimumSpeed()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = _minimumSpeedAnalizer.AnalizeSpeedInKilometerPerHour(wayPoints);

            Assert.Equal(0, result);
        }
    }
}
