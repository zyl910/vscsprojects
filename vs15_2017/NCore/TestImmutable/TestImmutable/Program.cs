using System;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;

namespace TestImmutable {
    class Program {
        static void Main(string[] args) {
            TextWriter tw = Console.Out;
            tw.WriteLine("TestImmutable");
            tw.WriteLine();
            ImmutableList<int> list = ImmutableList<int>.Empty.Add(10).Add(20).Add(30);
            Assembly assembly = list.GetType().GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("list Type.Assembly:\t{0}", assembly));
            tw.WriteLine(string.Format("list Type.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            tw.WriteLine(string.Format("list Type.FullName:\t{0}", list.GetType().FullName));
            tw.WriteLine(string.Format("list toString:\t{0}", list));
        }
    }
}
