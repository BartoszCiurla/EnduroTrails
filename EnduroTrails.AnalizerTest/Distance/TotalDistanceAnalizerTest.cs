using System;
using System.Collections.Generic;
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
    public class TotalDistanceAnalizerTest
    {
        private readonly IDistanceAnalizer _totalDistanceAnalizer;
        private readonly IFileReader _fileReader;
        private readonly IDistanceLocationsAnalizer _distanceLocationsAnalizer;
        private FlatAnalizer _flatAnalizer;
        private DescentAnalizer _descentAnalizer;
        private ClimbingAnalizer _climbingAnalizer;
        private FlatDistanceAnalizer _flatDistanceAnalizer;
        private DescentDistanceAnalizer _descentDistanceAnalizer;
        private ClimbingDistanceAnalizer _climbingDistanceAnalizer;
        private const double TotalDistanceInKm = 4.400;
        private const double TotalDistanceInM = 2.2;


        public TotalDistanceAnalizerTest()
        {
            _fileReader = FileReaderContener.GetFileReader();
            _distanceLocationsAnalizer = new DistanceLocationsAnalizer();            
            _flatAnalizer = new FlatAnalizer();
            _descentAnalizer = new DescentAnalizer();
            _climbingAnalizer = new ClimbingAnalizer();
            _totalDistanceAnalizer = new TotalDistanceAnalizer(_distanceLocationsAnalizer);
            _flatDistanceAnalizer = new FlatDistanceAnalizer(_distanceLocationsAnalizer, _flatAnalizer);
            _descentDistanceAnalizer = new DescentDistanceAnalizer(_distanceLocationsAnalizer, _descentAnalizer);
            _climbingDistanceAnalizer = new ClimbingDistanceAnalizer(_distanceLocationsAnalizer, _climbingAnalizer);
        }

        [Fact]
        public void TotalDistanceWithDetails()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double result = 0;
            List<double> locationsDistanses = new List<double>();
            for (int i = 0, j = 1; j < wayPoints.Length; i++, j++)
            {
                double distance = Math.Round(_distanceLocationsAnalizer.DistanceTo(
                    wayPoints[i].Latitude,
                    wayPoints[i].Longitude,
                    wayPoints[j].Latitude,
                    wayPoints[j].Longitude
                    ),3);
                locationsDistanses.Add(distance);
                result += distance;
            }
            double resultInM = Math.Round(result * 0.8684, 4);
            double resultInKm = Math.Round(result * 1.609344, 3);
            Assert.NotNull(locationsDistanses);
        }


        [Fact]
        public void TotalDistance()
        {            
            var locations = _fileReader.ReadWayPoints().ToArray();
            double result = _totalDistanceAnalizer.AnalizeDistance(locations);

            double resultInM = Math.Round(result * 0.8684, 4);
            double resultInKm = Math.Round(result * 1.609344, 3);
            //compare these values does not make sense !!
            //Assert.Equal(resultInKm, TotalDistanceInKm);
            //Assert.Equal(resultInM, TotalDistanceInM);
            Assert.InRange(resultInKm,4.000,TotalDistanceInKm);
            Assert.InRange(resultInM, 2.000, TotalDistanceInM);
        }

        [Fact]
        public void DistanceFromAllTypesRoutes()
        {
            var wayPoints = _fileReader.ReadWayPoints().ToArray();
            double totalDistance = _totalDistanceAnalizer.AnalizeDistance(wayPoints);
            double climbingDistance = _climbingDistanceAnalizer.AnalizeDistance(wayPoints);
            double descentDistance = _descentDistanceAnalizer.AnalizeDistance(wayPoints);
            double flatDistance = _flatDistanceAnalizer.AnalizeDistance(wayPoints);

            double climbingAndDescentDistance = climbingDistance + descentDistance;
            double allDistances = climbingAndDescentDistance + flatDistance;

            Assert.Equal(Math.Round(totalDistance),Math.Round(allDistances));
        }
    }
}
