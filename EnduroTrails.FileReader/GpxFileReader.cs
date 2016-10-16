using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EnduroTrails.Model;

namespace EnduroTrails.FileReader
{

    public class GpxFileReader:IFileReader
    {
        private readonly string _filePath;
        private readonly XNamespace _xmlNameSpace;

        public GpxFileReader(string filePath,string xmlNameSpace)
        {
            _filePath = filePath;
            _xmlNameSpace = XNamespace.Get(xmlNameSpace);
        }

        public IEnumerable<WayPoint> ReadWayPoints()
        {
            var document = XDocument.Load(GetFileStream());
            return document.Descendants(_xmlNameSpace + "trkpt").Select(x => new WayPoint
            {
                Longitude = double.Parse(x.Attribute("lon")?.Value, CultureInfo.InvariantCulture),
                Latitude = double.Parse(x.Attribute("lat")?.Value, CultureInfo.InvariantCulture),
                Elevation = double.Parse(x.Element(_xmlNameSpace + "ele")?.Value, CultureInfo.InvariantCulture),
                Time = DateTime.Parse(x.Element(_xmlNameSpace + "time")?.Value, CultureInfo.InvariantCulture)
            });
        }

        private FileStream GetFileStream()
        {
            return new FileStream(_filePath, FileMode.Open);
        }
    }
}
