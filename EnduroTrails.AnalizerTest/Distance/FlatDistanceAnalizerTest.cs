using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Distance;
using EnduroTrails.Analizer.Distance.Abstract;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Distance
{
    public class FlatDistanceAnalizerTest
    {
        private readonly IFileReader _fileReader;
        private readonly IDistanceAnalizer _flatAnalizer;

        public FlatDistanceAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            IDistanceLocationsAnalizer distanceLocationsAnalizer = new DistanceLocationsAnalizer();
            IFlatAnalizer flatAnalizer = new FlatAnalizer();
            _flatAnalizer = new FlatDistanceAnalizer(distanceLocationsAnalizer,flatAnalizer);
        }

        [Fact]
        public void FlatDistance()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = 0;
            result = _flatAnalizer.AnalizeDistance(wayPoints);


            double resultInM = Math.Round(result * 0.8684, 4);
            double resultInKm = Math.Round(result * 1.609344, 3);

            Assert.NotEqual(resultInKm, 0);
            Assert.NotEqual(resultInM, 0);
        }
    }
}
