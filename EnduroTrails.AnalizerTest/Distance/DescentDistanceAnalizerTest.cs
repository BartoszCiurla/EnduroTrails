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
    public class DescentDistanceAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly IDistanceAnalizer _decscentAnalizer;

        public DescentDistanceAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            IDistanceLocationsAnalizer distanceLocationsAnalizer = new DistanceLocationsAnalizer();
            IDescentAnalizer descentAnalizer = new DescentAnalizer();
            _decscentAnalizer = new DescentDistanceAnalizer(distanceLocationsAnalizer,descentAnalizer);
        }

        [Fact]
        public void DescentDistance()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = 0;
            result = _decscentAnalizer.AnalizeDistance(wayPoints);


            double resultInM = Math.Round(result * 0.8684, 4);
            double resultInKm = Math.Round(result * 1.609344, 3);

            Assert.NotEqual(resultInKm, 0);
            Assert.NotEqual(resultInM, 0);
        }
    }
}
