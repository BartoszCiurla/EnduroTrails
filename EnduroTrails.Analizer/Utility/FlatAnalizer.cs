using System;
using EnduroTrails.Analizer.Utility.Abstract;

namespace EnduroTrails.Analizer.Utility
{
    public class FlatAnalizer : IFlatAnalizer
    {
        private readonly double _flatTolerance;

        public FlatAnalizer(double flatTolerance = 0.01)
        {
            _flatTolerance = flatTolerance;
        }

        public bool IsFlatDistance(double elevationFrom, double elevationTo) => Math.Abs(elevationFrom - elevationTo) < _flatTolerance;
    }
}
