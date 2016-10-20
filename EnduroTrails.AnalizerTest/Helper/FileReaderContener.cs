using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.FileReader;

namespace EnduroTrails.AnalizerTest.Helper
{
    public class FileReaderContener
    {
        public static IFileReader GetFileReader()
        {
            string FilePath = "../../../twister.gpx.txt";
            string XmlNamespace = "http://www.topografix.com/GPX/1/1";
            return new GpxFileReader(FilePath, XmlNamespace);
        }
    }
}
