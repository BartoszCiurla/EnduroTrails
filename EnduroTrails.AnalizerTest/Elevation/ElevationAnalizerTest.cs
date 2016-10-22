using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IAreaAnalizer _anyAreaAnalizer;

        public ElevationAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints();

            _minimumElevationAnalizer = new MinimumElevationAnalizer();

            _climbingAnalizer = new ClimbingAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _anyAreaAnalizer = new AnyAreaAnalizer();
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
            var climbingAnalizer= new ClimbingAnalizer();
            double totalClimbing = 0;
            for (int i = 0,j=1; j < _wayPoints.Length; i++,j++)
            {
                if (climbingAnalizer.IsArea(_wayPoints[i].Elevation, _wayPoints[j].Elevation))
                {
                    totalClimbing += _wayPoints[i].Elevation - _wayPoints[j].Elevation;//function point
                }
            }
            totalClimbing *= -1;//function point

            Assert.InRange(totalClimbing, 75, 85);

            _testOutputHelper.WriteLine(totalClimbing.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TotalDescent()
        {
            var descentAnalizer = new DescentAnalizer();
            double totalDescent = 0;
            for (int i = 0, j = 1; j < _wayPoints.Length; i++, j++)
            {
                if (descentAnalizer.IsArea(_wayPoints[i].Elevation, _wayPoints[j].Elevation))
                {
                    totalDescent += _wayPoints[i].Elevation - _wayPoints[j].Elevation;//function point
                }
            }
            totalDescent *= 1;//function point

            Assert.InRange(totalDescent, 325, 329);

            _testOutputHelper.WriteLine(totalDescent.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FinalBalance()
        {
            // ?
        }
    }
}
