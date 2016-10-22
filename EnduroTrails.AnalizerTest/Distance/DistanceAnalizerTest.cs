using System;
using System.Globalization;
using EnduroTrails.Analizer.Area;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Distance;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.Model;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.AnalizerTest.Distance
{
    public class DistanceAnalizerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const double TotalDistanceInKm = 4.400;
        private const double TotalDistanceInM = 2.2;
        private readonly WayPoint[] _wayPoints;

        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private readonly IAreaAnalizer _climbingAnalizer;
        private readonly IAreaAnalizer _descentAnalizer;
        private readonly IAreaAnalizer _flatAnalizer;
        private readonly IAreaAnalizer _anyAreaAnalizer;

        public DistanceAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints();

            _distanceLocationsAnalizer = new DistanceLocationsAnalizer();

            _climbingAnalizer = new ClimbingAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _flatAnalizer = new FlatAnalizer();
            _anyAreaAnalizer = new AnyAreaAnalizer();
        }        

        [Fact]
        public void TotalDistance()
        {
            var totalAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _anyAreaAnalizer);

            double resultInKilometers = totalAnalizer.AnalizeDistanceInKm(_wayPoints);

            Assert.InRange(resultInKilometers, 4.000, TotalDistanceInKm);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ClimbingDistance()
        {
            var climbingAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _climbingAnalizer);

            double resultInKilometers = climbingAnalizer.AnalizeDistanceInKm(_wayPoints);            

            Assert.NotEqual(resultInKilometers, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DescentDistance()
        {
            var descentAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _descentAnalizer);

            double resultInKilometers = descentAnalizer.AnalizeDistanceInKm(_wayPoints);

            Assert.NotEqual(resultInKilometers, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FlatDistance()
        {
            var flatAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _flatAnalizer);

            double resultInKilometers = flatAnalizer.AnalizeDistanceInKm(_wayPoints);

            Assert.NotEqual(resultInKilometers, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DistanceFromAllTypesRoutes()
        {
            var totalAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _anyAreaAnalizer);
            var climbingAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _climbingAnalizer);
            var descentAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _descentAnalizer);
            var flatAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _flatAnalizer);

            double totalDistance = totalAnalizer.AnalizeDistanceInKm(_wayPoints);
            double climbingDistance = climbingAnalizer.AnalizeDistanceInKm(_wayPoints);
            double descentDistance = descentAnalizer.AnalizeDistanceInKm(_wayPoints);
            double flatDistance = flatAnalizer.AnalizeDistanceInKm(_wayPoints);

            double areaDistance = climbingDistance + descentDistance + flatDistance;

            Assert.Equal(Math.Round(totalDistance), Math.Round(areaDistance));

            _testOutputHelper.WriteLine(areaDistance.ToString(CultureInfo.InvariantCulture));
            _testOutputHelper.WriteLine(totalDistance.ToString(CultureInfo.InvariantCulture));
        }
    }
}
