using System;
using System.Globalization;
using System.Linq;
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

        private double ConvertToNaturalMiles(double miles) => Math.Round(miles * 0.8684, 4);

        private double ConvertToKilometers(double miles) => Math.Round(miles * 1.609344, 3);

        [Fact]
        public void TotalDistance()
        {
            var totalAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _anyAreaAnalizer);

            double result = totalAnalizer.AnalizeDistanceInMiles(_wayPoints);

            double resultInKilometers = ConvertToKilometers(result);
            double resultInNaturalMiles = ConvertToNaturalMiles(result);

            Assert.InRange(resultInKilometers, 4.000, TotalDistanceInKm);
            Assert.InRange(resultInNaturalMiles, 2.000, TotalDistanceInM);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ClimbingDistance()
        {
            var climbingAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _climbingAnalizer);

            double result = climbingAnalizer.AnalizeDistanceInMiles(_wayPoints);

            double resultInKilometers = ConvertToKilometers(result);
            double resultInNaturalMiles = ConvertToNaturalMiles(result);

            Assert.NotEqual(resultInKilometers, 0);
            Assert.NotEqual(resultInNaturalMiles, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DescentDistance()
        {
            var descentAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _descentAnalizer);

            double result = descentAnalizer.AnalizeDistanceInMiles(_wayPoints);

            double resultInKilometers = ConvertToKilometers(result);
            double resultInNaturalMiles = ConvertToNaturalMiles(result);

            Assert.NotEqual(resultInKilometers, 0);
            Assert.NotEqual(resultInNaturalMiles, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FlatDistance()
        {
            var flatAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _flatAnalizer);

            double result = flatAnalizer.AnalizeDistanceInMiles(_wayPoints);

            double resultInKilometers = ConvertToKilometers(result);
            double resultInNaturalMiles = ConvertToNaturalMiles(result);

            Assert.NotEqual(resultInKilometers, 0);
            Assert.NotEqual(resultInNaturalMiles, 0);

            _testOutputHelper.WriteLine(resultInKilometers.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DistanceFromAllTypesRoutes()
        {
            var totalAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _anyAreaAnalizer);
            var climbingAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _climbingAnalizer);
            var descentAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _descentAnalizer);
            var flatAnalizer = new DistanceAnalizer(_distanceLocationsAnalizer, _flatAnalizer);

            double totalDistance = totalAnalizer.AnalizeDistanceInMiles(_wayPoints);
            double climbingDistance = climbingAnalizer.AnalizeDistanceInMiles(_wayPoints);
            double descentDistance = descentAnalizer.AnalizeDistanceInMiles(_wayPoints);
            double flatDistance = flatAnalizer.AnalizeDistanceInMiles(_wayPoints);

            double areaDistance = climbingDistance + descentDistance + flatDistance;

            Assert.Equal(Math.Round(totalDistance), Math.Round(areaDistance));

            _testOutputHelper.WriteLine(areaDistance.ToString(CultureInfo.InvariantCulture));
            _testOutputHelper.WriteLine(totalDistance.ToString(CultureInfo.InvariantCulture));
        }
    }
}
