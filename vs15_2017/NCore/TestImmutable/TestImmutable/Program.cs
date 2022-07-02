using System;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;

namespace TestImmutable {
    class Program {

        /// <summary>
        /// Output object.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="tw">Output TextWriter.</param>
        /// <param name="obj">The object.</param>
        static void OutputObject<T>(TextWriter tw, T obj) {
            Assembly assembly = obj.GetType().GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("list Type.Assembly:\t{0}", assembly));
            tw.WriteLine(string.Format("list Type.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            tw.WriteLine(string.Format("list Type.FullName:\t{0}", obj.GetType().FullName));
            tw.WriteLine(string.Format("list toString:\t{0}", obj));
        }

        static void Main(string[] args) {
            TextWriter tw = Console.Out;
            tw.WriteLine("TestImmutable");
            tw.WriteLine();
            ImmutableList<int> list = ImmutableList<int>.Empty.Add(10).Add(20).Add(30);
            OutputObject(tw, list);
            //ImmutableList<int> list2 = TestImmutableLib.ImmutableLibUtil.MakeImmutable(tw);
            //OutputObject(tw, list2);
        }
    }
}
