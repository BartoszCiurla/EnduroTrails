using System;
using System.Globalization;
using EnduroTrails.Analizer.Area;
using EnduroTrails.Analizer.Area.Abstract;
using EnduroTrails.Analizer.Time;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.Model;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.AnalizerTest.Time
{
    public class TimeAnalizerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WayPoint[] _wayPoints;
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly IAreaAnalizer _climbingAnalizer;
        private readonly IAreaAnalizer _descentAnalizer;
        private readonly IAreaAnalizer _flatAnalizer;
        private readonly IAreaAnalizer _anyAreaAnalizer;        

        public TimeAnalizerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _wayPoints = FileReaderContener.GetWayPoints();
            _timeLocationsAnalizer = new TimeLocationsAnalizer();

            _climbingAnalizer = new ClimbingAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _flatAnalizer = new FlatAnalizer();
            _anyAreaAnalizer = new AnyAreaAnalizer();
        }

        private double ConvertToHours(double resultInSeconds) => Math.Round((resultInSeconds / 60)/60,2);

        private double ConvertToMinutes(double resultInSeconds) => Math.Round(resultInSeconds / 60);

        [Fact]
        public void TotalTime()
        {
            var timeAnalizer = new TimeAnalizer(_timeLocationsAnalizer,_anyAreaAnalizer);

            double result = timeAnalizer.AnalizeTimeInSeconds(_wayPoints);

            double resultInMinutes = ConvertToMinutes(result);
            double resultInHours = ConvertToHours(result);

            Assert.True(resultInMinutes > 0);
            Assert.True(resultInHours > 0);

            _testOutputHelper.WriteLine(resultInMinutes.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ClimbingTime()
        {
            var climbingAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _climbingAnalizer);

            double result = climbingAnalizer.AnalizeTimeInSeconds(_wayPoints);

            double resultInMinutes = ConvertToMinutes(result);
            double resultInHours = ConvertToHours(result);

            Assert.True(resultInMinutes > 0);
            Assert.True(resultInHours > 0);

            _testOutputHelper.WriteLine(resultInMinutes.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DescentTime()
        {
            var descentAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _descentAnalizer);

            double result = descentAnalizer.AnalizeTimeInSeconds(_wayPoints);

            double resultInMinutes = ConvertToMinutes(result);
            double resultInHours = ConvertToHours(result);

            Assert.True(resultInMinutes > 0);
            Assert.True(resultInHours > 0);

            _testOutputHelper.WriteLine(resultInMinutes.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FlatTime()
        {
            var flatAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _flatAnalizer);

            double result = flatAnalizer.AnalizeTimeInSeconds(_wayPoints);

            double resultInMinutes = ConvertToMinutes(result);
            double resultInHours = ConvertToHours(result);

            Assert.True(resultInMinutes > 0);
            Assert.True(resultInHours > 0);

            _testOutputHelper.WriteLine(resultInMinutes.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TimeFromAllTypesRoutes()
        {
            var timeAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _anyAreaAnalizer);
            var climbingAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _climbingAnalizer);
            var descentAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _descentAnalizer);
            var flatAnalizer = new TimeAnalizer(_timeLocationsAnalizer, _flatAnalizer);

            double totalTime = timeAnalizer.AnalizeTimeInSeconds(_wayPoints);
            double climbingTime = climbingAnalizer.AnalizeTimeInSeconds(_wayPoints);
            double descentTime = descentAnalizer.AnalizeTimeInSeconds(_wayPoints);
            double flatTime = flatAnalizer.AnalizeTimeInSeconds(_wayPoints);

            double areaTime = climbingTime + descentTime + flatTime;

            double areaTimeInMinutes = ConvertToMinutes(areaTime);
            double totalTimeInMinutes = ConvertToMinutes(areaTime);

            Assert.Equal(Math.Round(totalTime), Math.Round(areaTime));

            _testOutputHelper.WriteLine(areaTimeInMinutes.ToString(CultureInfo.InvariantCulture));
            _testOutputHelper.WriteLine(totalTimeInMinutes.ToString(CultureInfo.InvariantCulture));
        }
    }
}
