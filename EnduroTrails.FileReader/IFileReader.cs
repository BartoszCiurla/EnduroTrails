using System.Collections.Generic;
using System.Linq;
using EnduroTrails.Model;

namespace EnduroTrails.FileReader
{
    public interface IFileReader
    {
        IQueryable<WayPoint> ReadWayPoints();
    }
}
