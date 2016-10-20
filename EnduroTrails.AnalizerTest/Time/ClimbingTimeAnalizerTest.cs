using System.Linq;
using EnduroTrails.Analizer.Time;
using EnduroTrails.Analizer.Time.Abstract;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Time
{
    public class ClimbingTimeAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly ITimeAnalizer _climbingAnalizer;

        public ClimbingTimeAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            IClimbingAnalizer climbingAnalizer = new ClimbingAnalizer();
            ITimeLocationsAnalizer timeLocationsAnalizer = new TimeLocationsAnalizer();
            _climbingAnalizer = new ClimbingTimeAnalizer(timeLocationsAnalizer,climbingAnalizer);
        }

        [Fact]
        public void ClimbingTime()
        {
            double result = 0;
            result = _climbingAnalizer.AnalizeTime(_fileReader.ReadWayPoints().ToArray());

            double resultInMinutes = (result / 60);

            Assert.True(result > 0);
        }
    }
}
