using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer.Extremum.Abstract;

namespace EnduroTrails.Analizer.Extremum
{
    public class MinimumElevationAnalizer:IExtremumElevationAnalizer
    {
        public double InitialElevation => double.MaxValue;

        public double GetExtremumElevation(double extremumElevation, double currentElevation)
            => extremumElevation > currentElevation ? currentElevation : extremumElevation;
    }
}
