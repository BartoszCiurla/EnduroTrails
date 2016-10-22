using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Factory;
using EnduroTrails.FileReader;
using EnduroTrails.Model;

namespace EnduroTrails.Analizer
{
    public class Analizer
    {
        private readonly WayPoint[] _wayPoints;
        private readonly DistanceAnalizerFactory _distanceAnalizerFactory;

        public Analizer(string filePath,string xmlNameSpace)
        {
            _distanceAnalizerFactory = new DistanceAnalizerFactory();
            IFileReader fileReader = new GpxFileReader(filePath, xmlNameSpace);
            _wayPoints = fileReader.ReadWayPoints().ToArray();
        }

        public double TotalDistance() =>_distanceAnalizerFactory.TotalDistance().AnalizeDistanceInKm(_wayPoints);

        public double ClimbingDistance() => _distanceAnalizerFactory.ClimbingDistance().AnalizeDistanceInKm(_wayPoints);

        public double DescentDistance() => _distanceAnalizerFactory.DescentDistance().AnalizeDistanceInKm(_wayPoints);

        public double FlatDistance() => _distanceAnalizerFactory.FlatDistance().AnalizeDistanceInKm(_wayPoints);
    }
}
