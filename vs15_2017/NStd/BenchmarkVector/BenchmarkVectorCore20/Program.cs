﻿using BenchmarkVector;
using System;
using System.IO;
using System.Numerics;

namespace BenchmarkVectorCore20 {
    class Program {
        static void Main(string[] args) {
            string indent = "";
            TextWriter tw = Console.Out;
            tw.WriteLine("BenchmarkVectorCore20");
            tw.WriteLine();
            BenchmarkVectorDemo.OutputEnvironment(tw, indent);
            tw.WriteLine(string.Format("Main-Vector4.Assembly.CodeBase:\t{0}", typeof(Vector4).Assembly.CodeBase));
            tw.WriteLine(indent);
            BenchmarkVectorDemo.Benchmark(tw, indent);
        }
    }
}
