using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnduroTrails.Analizer;

namespace YConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var analizer = new Analizer("../../../twister.gpx.txt", "http://www.topografix.com/GPX/1/1");

            Console.WriteLine($"Climbing distance {analizer.ClimbingDistance()}" );
            Console.WriteLine($"Descent distance {analizer.DescentDistance()}");
            Console.WriteLine($"Flat distance {analizer.FlatDistance()}");
            Console.WriteLine($"Total distance {analizer.TotalDistance()}");

            Console.ReadKey();
        }
    }
}
