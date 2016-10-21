using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EnduroTrails.Model;

namespace EnduroTrails.FileReader
{

    public class GpxFileReader : IFileReader
    {
        private readonly string _filePath;
        private readonly XNamespace _xmlNameSpace;

        public GpxFileReader(string filePath, string xmlNameSpace)
        {
            _filePath = filePath;
            _xmlNameSpace = XNamespace.Get(xmlNameSpace);
        }

        public IQueryable<WayPoint> ReadWayPoints()
        {
            return LoadXDocument()
                .Descendants(_xmlNameSpace + "trkpt")
                .Select(x => new WayPoint
                {
                    Longitude = double.Parse(x.Attribute("lon")?.Value, CultureInfo.InvariantCulture),
                    Latitude = double.Parse(x.Attribute("lat")?.Value, CultureInfo.InvariantCulture),
                    Elevation = double.Parse(x.Element(_xmlNameSpace + "ele")?.Value, CultureInfo.InvariantCulture),
                    Time = DateTime.Parse(x.Element(_xmlNameSpace + "time")?.Value, CultureInfo.InvariantCulture)
                }).AsQueryable();
        }

        private XDocument LoadXDocument()
        {
            return XDocument.Load(GetFileStream());
        }

        private FileStream GetFileStream()
        {
            return new FileStream(_filePath, FileMode.Open);
        }
    }
}
