using System.Globalization;
using System.Linq;
using EnduroTrails.Analizer.Area;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Elevation;
using EnduroTrails.Analizer.Extremum;
using EnduroTrails.Analizer.Extremum.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.Model;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.AnalizerTest.Elevation
{
    public class ElevationAnalizerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IExtremumElevationAnalizer _minimumElevationAnalizer;
        private readonly WayPoint[] _wayPoints;
        private readonly IAreaAnalizer _climbingAnalizer;
        private readonly IAreaAnalizer _descentAnalizer;

        public ElevationAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints();

            _minimumElevationAnalizer = new MinimumElevationAnalizer();

            _climbingAnalizer = new ClimbingAnalizer();
            _descentAnalizer = new DescentAnalizer();
        }

        [Fact]
        public void MinimumElevation()
        {
            var minimumAnalizer = new ExtremumElevationAnalizer(_minimumElevationAnalizer);

            double result = minimumAnalizer.AnalizeElevationInM(_wayPoints);

            Assert.InRange(result, 425, 430);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void AverageElevation()
        {
            var averageAnalizer = new AverageElevationAnalizer();

            double result = averageAnalizer.AnalizeElevationInM(_wayPoints);

            Assert.InRange(result, 425,672);

            _testOutputHelper.WriteLine(result.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TotalClimbing()
        {
            var climbingAnalizer = new TotalElevationAnalizer(_climbingAnalizer);
            double totalClimbing = climbingAnalizer.AnalizeElevationInM(_wayPoints);
          
            Assert.InRange(totalClimbing, 75, 85);

            _testOutputHelper.WriteLine(totalClimbing.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TotalDescent()
        {
            var descentAnalizer = new TotalElevationAnalizer(_descentAnalizer);
            double totalDescent = descentAnalizer.AnalizeElevationInM(_wayPoints); 

            Assert.InRange(totalDescent, 325, 329);

            _testOutputHelper.WriteLine(totalDescent.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FinalBalance()
        {
            double startElevation = _wayPoints.First().Elevation;
            double endElevation = _wayPoints.Last().Elevation;


            double finalBalance = startElevation - endElevation;

            if (startElevation > endElevation)
            {
                finalBalance *= -1;
            }

            Assert.True(finalBalance <0 );

            _testOutputHelper.WriteLine(finalBalance.ToString(CultureInfo.InvariantCulture));
        }
    }
}
