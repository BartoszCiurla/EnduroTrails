using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Distance;
using EnduroTrails.Analizer.Distance.Abstract;
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
        private FlatAnalizer _flatAnalizer;
        private DescentAnalizer _descentAnalizer;
        private ClimbingAnalizer _climbingAnalizer;
        private FlatTimeAnalizer _flatTimeAnalizer;
        private ClimbingTimeAnalizer _climbingTimeAnalizer;
        private DescentTimeAnalizer _descentTimeAnalizer;

        public TotalTractTimeAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            _timeLocationsAnalizer = new TimeLocationsAnalizer();
            _flatAnalizer = new FlatAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _climbingAnalizer = new ClimbingAnalizer();
            _totaltrackTimeAnalizer = new TotalTractTimeAnalizer(_timeLocationsAnalizer);
            _flatTimeAnalizer = new FlatTimeAnalizer(_timeLocationsAnalizer, _flatAnalizer);
            _climbingTimeAnalizer = new ClimbingTimeAnalizer(_timeLocationsAnalizer,_climbingAnalizer);
            _descentTimeAnalizer = new DescentTimeAnalizer(_timeLocationsAnalizer,_descentAnalizer);
        }

        [Fact]
        public void TotalTrackTimeWithDetails()
        {
            double result = 0;
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            List<double> timesForAllPoints = new List<double>();
            for (int i = 0,j=1; j < wayPoints.Length; i++,j++)
            {
                double test = _timeLocationsAnalizer.TimeTo(wayPoints[i].Time, wayPoints[j].Time);
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
            result = _totaltrackTimeAnalizer.AnalizeTime(wayPoints);

            double resultInMinutes =Math.Round(result / 60);
            double resultInHours = Math.Round(resultInMinutes/60);

            Assert.NotNull(resultInMinutes);
            Assert.NotNull(resultInHours);
        }

        [Fact]
        public void TimeFromAllTypesRoutes()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double totalTime = _totaltrackTimeAnalizer.AnalizeTime(wayPoints);
            double climbingTime = _climbingTimeAnalizer.AnalizeTime(wayPoints);
            double descentTime = _descentTimeAnalizer.AnalizeTime(wayPoints);
            double flatTime = _flatTimeAnalizer.AnalizeTime(wayPoints);

            double climbingAndDescetTime = climbingTime + descentTime;
            
            Assert.Equal(totalTime, climbingAndDescetTime + flatTime);
        }
    }
}
