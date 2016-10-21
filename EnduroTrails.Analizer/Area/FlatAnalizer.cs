using System;
using EnduroTrails.Analizer.Area.Abstract;

namespace EnduroTrails.Analizer.Area
{
    public class FlatAnalizer : IAreaAnalizer
    {
        private readonly double _flatTolerance;

        public FlatAnalizer(double flatTolerance = 0.01)
        {
            _flatTolerance = flatTolerance;
        }
        public bool IsArea(double elevationFrom, double elevationTo) 
            => Math.Abs(elevationFrom - elevationTo) < _flatTolerance;              
    }
}
