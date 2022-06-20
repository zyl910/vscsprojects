using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReadonlyLib;

namespace TestReadonly {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("TestReadonly");
            TestCoords();
        }

        private static void TestCoords() {
            Coords coords = new Coords(3, 4);
            Console.Write("Coords:\t");
            Console.WriteLine(coords);
            Console.WriteLine(string.Format("GetLength:\t{0}", coords.GetLength()));
            Console.WriteLine();
        }
    }
}
