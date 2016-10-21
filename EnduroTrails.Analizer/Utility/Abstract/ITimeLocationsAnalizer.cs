using System;

namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface ITimeLocationsAnalizer
    {
        double GetTimeInSeconds(DateTime timeStart, DateTime timeEnd);
    }
}
