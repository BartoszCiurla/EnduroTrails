using System.Collections.Generic;
using EnduroTrails.Model;

namespace EnduroTrails.FileReader
{
    public interface IFileReader
    {
        IEnumerable<WayPoint> ReadWayPoints();
    }
}
