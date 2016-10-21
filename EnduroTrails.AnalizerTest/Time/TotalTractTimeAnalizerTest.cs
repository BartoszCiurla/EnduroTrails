using System;
using System.Collections.Generic;
using System.Linq;
using EnduroTrails.Analizer.Time;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Time
{
    public class TotalTractTimeAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly ITimeLocationsAnalizer _timeLocationsAnalizer;
        private readonly TotalTractTimeAnalizer _totaltrackTimeAnalizer;
        private readonly FlatTimeAnalizer _flatTimeAnalizer;
        private readonly ClimbingTimeAnalizer _climbingTimeAnalizer;
        private readonly DescentTimeAnalizer _descentTimeAnalizer;

        public TotalTractTimeAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            _timeLocationsAnalizer = new TimeLocationsAnalizer();
            var flatAnalizer = new FlatAnalizer();
            var descentAnalizer = new DescentAnalizer();
            var climbingAnalizer = new ClimbingAnalizer();
            _totaltrackTimeAnalizer = new TotalTractTimeAnalizer(_timeLocationsAnalizer);
            _flatTimeAnalizer = new FlatTimeAnalizer(_timeLocationsAnalizer, flatAnalizer);
            _climbingTimeAnalizer = new ClimbingTimeAnalizer(_timeLocationsAnalizer,climbingAnalizer);
            _descentTimeAnalizer = new DescentTimeAnalizer(_timeLocationsAnalizer,descentAnalizer);
        }

        [Fact]
        public void TotalTrackTimeWithDetails()
        {
            double result = 0;
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            List<double> timesForAllPoints = new List<double>();
            for (int i = 0,j=1; j < wayPoints.Length; i++,j++)
            {
                double test = _timeLocationsAnalizer.GetTimeInSeconds(wayPoints[i].Time, wayPoints[j].Time);
                timesForAllPoints.Add(test);
                result += test;
            }

            double resultInMinutes = (result/60);

            Assert.NotNull(result);
        }

        [Fact]
        public void TotalTrackTime()
        {
            double result = 0;
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            result = _totaltrackTimeAnalizer.AnalizeTimeInSeconds(wayPoints);

            double resultInMinutes =Math.Round(result / 60);
            double resultInHours = Math.Round(resultInMinutes/60);

            Assert.NotNull(resultInMinutes);
            Assert.NotNull(resultInHours);
        }

        [Fact]
        public void TimeFromAllTypesRoutes()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double totalTime = _totaltrackTimeAnalizer.AnalizeTimeInSeconds(wayPoints);
            double climbingTime = _climbingTimeAnalizer.AnalizeTimeInSeconds(wayPoints);
            double descentTime = _descentTimeAnalizer.AnalizeTimeInSeconds(wayPoints);
            double flatTime = _flatTimeAnalizer.AnalizeTimeInSeconds(wayPoints);

            double climbingAndDescetTime = climbingTime + descentTime;
            
            Assert.Equal(totalTime, climbingAndDescetTime + flatTime);
        }
    }
}
