using System.IO;
using System.Linq;
using System.Xml.Linq;
using EnduroTrails.FileReader;
using Xunit;
using Xunit.Abstractions;

namespace EnduroTrails.FileReaderTest
{
    public class GxpFileReaderTest
    {
        private readonly ITestOutputHelper _outHelper;
        private const string FilePath = "../../../twister.gpx.txt";
        private const string XmlNamespace = "http://www.topografix.com/GPX/1/1";

        public GxpFileReaderTest(ITestOutputHelper outHelper)
        {
            _outHelper = outHelper;
        }


        [Fact]
        public void IsFileExists()
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            _outHelper.WriteLine(fileInfo.DirectoryName);
            Assert.Equal(fileInfo.Exists, true);
        }

        FileStream GetFileStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Open);
        }

        [Fact]
        public void IsFileStreamWork()
        {
            var stream = GetFileStream(FilePath);
            _outHelper.WriteLine(stream.Length.ToString());
            Assert.True(stream.Length > 0);
        }

        dynamic ReadFileToDynamic()
        {
            var stream = GetFileStream(FilePath);
            XDocument gpxDoc = XDocument.Load(stream);
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return gpxDoc.Descendants(gpx + "trkpt").Select(x => new
            {
                Longitude = x.Attribute("lon")?.Value,
                Latitude = x.Attribute("lat")?.Value,
                Elevation = x.Element(gpx + "ele")?.Value,
                Time = x.Element(gpx + "time")?.Value
            });
        }
        [Fact]
        public void ReadFileToDynamicStructure()
        {
            dynamic result = ReadFileToDynamic();
            Assert.NotNull(result);
        }

        [Fact]
        public void ReadFiletoWayPointStructure()
        {
            var fileReader = new GpxFileReader(FilePath, XmlNamespace);
            var result = fileReader.ReadWayPoints().ToArray();

            Assert.NotEmpty(result);
        }
    }
}
