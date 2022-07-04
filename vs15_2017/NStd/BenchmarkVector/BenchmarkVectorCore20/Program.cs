using BenchmarkVector;
using System;
using System.IO;

namespace BenchmarkVectorCore20 {
    class Program {
        static void Main(string[] args) {
            string indent = "";
            TextWriter tw = Console.Out;
            tw.WriteLine("BenchmarkVectorCore20");
            tw.WriteLine();
            BenchmarkVectorDemo.OutputEnvironment(tw, indent);
            BenchmarkVectorDemo.Benchmark(tw, indent);
        }
    }
}
