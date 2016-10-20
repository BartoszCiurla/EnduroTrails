using System;

namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface ITimeLocationsAnalizer
    {
        double TimeTo(DateTime timeStart, DateTime timeEnd);
    }
}
