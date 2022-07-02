using System;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;

namespace TestImmutableLib {
    public static class ImmutableLibUtil {
        public static ImmutableList<int> MakeImmutable(TextWriter tw) {
            tw.WriteLine("TestImmutable");
            tw.WriteLine();
            ImmutableList<int> list = ImmutableList<int>.Empty.Add(10).Add(20).Add(30);
            Assembly assembly = list.GetType().GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("InLib: Type.Assembly:\t{0}", assembly));
            tw.WriteLine(string.Format("InLib: Type.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            return list;
        }
    }
}
