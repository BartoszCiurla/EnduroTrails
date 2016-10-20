using System;
using System.Linq;
using EnduroTrails.Analizer.Utility;
using EnduroTrails.Analizer.Utility.Abstract;
using EnduroTrails.AnalizerTest.Helper;
using EnduroTrails.FileReader;
using Xunit;

namespace EnduroTrails.AnalizerTest.Distance
{
    public class TwoWayPointDistanceAnalizerTest
    {        
        private readonly IFileReader _fileReader;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;

        public TwoWayPointDistanceAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            _distanceLocationsAnalizer = new DistanceLocationsAnalizer();
        }
       
        [Fact]
        public void TwoWaypointDistance()
        {
            double shouldBeInM = 0.002;
            double shouldBeInKm = 0.004;
            var wayPoints = _fileReader.ReadWayPoints().Take(2).ToArray();
            double result = _distanceLocationsAnalizer.DistanceTo(
                wayPoints[0].Latitude,
                wayPoints[0].Longitude,
                wayPoints[1].Latitude,
                wayPoints[1].Longitude);

            double resultInM = Math.Round(result * 0.8684 ,4);
            double resultInKm = Math.Round(result* 1.609344, 3);

            Assert.Equal(shouldBeInKm,resultInKm);
            Assert.Equal(shouldBeInM,resultInM);


        }
    }
}
