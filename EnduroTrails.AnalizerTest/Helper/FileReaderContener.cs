using System.Linq;
using EnduroTrails.FileReader;
using EnduroTrails.Model;

namespace EnduroTrails.AnalizerTest.Helper
{
    public static class FileReaderContener
    {
        static string FilePath = "../../../twister.gpx.txt";
        static string XmlNamespace = "http://www.topografix.com/GPX/1/1";
        private static readonly WayPoint[] WayPoints;

        static FileReaderContener()
        {
            IFileReader fileReader = new GpxFileReader(FilePath, XmlNamespace);
            WayPoints = fileReader.ReadWayPoints().ToArray();
        }

        public static WayPoint[] GetWayPoints() => WayPoints;

    }
}
