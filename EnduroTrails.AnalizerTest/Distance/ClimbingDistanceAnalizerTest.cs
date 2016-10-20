using System;
using System.Linq;
using EnduroTrails.Analizer.Distance;
using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using EnduroTrails.Model;
using Xunit;

namespace EnduroTrails.AnalizerTest.Distance
{
    public class ClimbingDistanceAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly IDistanceAnalizer _climbingAnalizer;

        public ClimbingDistanceAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            IDistanceLocationsAnalizer distanceLocationsAnalizer = new DistanceLocationsAnalizer();
            _climbingAnalizer = new ClimbingDistanceAnalizer(distanceLocationsAnalizer);
        }

        [Fact]
        public void ClimbingDistance()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = 0;
            result = _climbingAnalizer.AnalizeDistance(wayPoints);


            double resultInM = Math.Round(result * 0.8684, 4);
            double resultInKm = Math.Round(result * 1.609344, 3);

            Assert.NotEqual(resultInKm,0);
            Assert.NotEqual(resultInM, 0);
        }
    }
}
