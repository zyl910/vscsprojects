using LibSysInfo.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace LibSysInfo {
    /// <summary>
    /// System info util.
    /// </summary>
    public class SysInfoUtil {
        internal static readonly string[] TypeNames = {
            "System.Array",
            "System.Environment",
            "System.GC",
            "System.Half",
            "System.Math",
            "System.MathF",
            "System.OperatingSystem",
            //"System.Runtime.InteropServices.RuntimeInformation",
            "System.Numerics.Vector",
            "System.Runtime.Intrinsics.X86.Aes",
            "System.Runtime.Intrinsics.X86.Aes.X64",
            "System.Runtime.Intrinsics.X86.Avx",
            "System.Runtime.Intrinsics.X86.Avx.X64",
            "System.Runtime.Intrinsics.X86.Avx2",
            "System.Runtime.Intrinsics.X86.Avx2.X64",
            "System.Runtime.Intrinsics.X86.AvxVnni",
            "System.Runtime.Intrinsics.X86.AvxVnni.X64",
            "System.Runtime.Intrinsics.X86.Bmi1",
            "System.Runtime.Intrinsics.X86.Bmi1.X64",
            "System.Runtime.Intrinsics.X86.Bmi2",
            "System.Runtime.Intrinsics.X86.Bmi2.X64",
            "System.Runtime.Intrinsics.X86.Fma",
            "System.Runtime.Intrinsics.X86.Fma.X64",
            "System.Runtime.Intrinsics.X86.Lzcnt",
            "System.Runtime.Intrinsics.X86.Lzcnt.X64",
            "System.Runtime.Intrinsics.X86.Pclmulqdq",
            "System.Runtime.Intrinsics.X86.Pclmulqdq.X64",
            "System.Runtime.Intrinsics.X86.Popcnt",
            "System.Runtime.Intrinsics.X86.Popcnt.X64",
            "System.Runtime.Intrinsics.X86.Sse",
            "System.Runtime.Intrinsics.X86.Sse.X64",
            "System.Runtime.Intrinsics.X86.Sse2",
            "System.Runtime.Intrinsics.X86.Sse2.X64",
            "System.Runtime.Intrinsics.X86.Sse3",
            "System.Runtime.Intrinsics.X86.Sse3.X64",
            "System.Runtime.Intrinsics.X86.Sse41",
            "System.Runtime.Intrinsics.X86.Sse41.X64",
            "System.Runtime.Intrinsics.X86.Sse42",
            "System.Runtime.Intrinsics.X86.Sse42.X64",
            "System.Runtime.Intrinsics.X86.Ssse3",
            "System.Runtime.Intrinsics.X86.Ssse3.X64",
            "System.Runtime.Intrinsics.X86.X86Base",
            "System.Runtime.Intrinsics.X86.X86Base.X64",

        };
        /// <summary>
        /// Others types. Use for GetType not supported.
        /// </summary>
        internal static readonly Type[] OtherTypes = {
            typeof(System.Runtime.InteropServices.RuntimeEnvironment),
#if (NETSTANDARD1_0) || (NET47||NET462||NET461||NET46||NET452||NET451||NET45||NET40||NET35||NET20)
#else
            typeof(System.Runtime.InteropServices.RuntimeInformation),
#endif
            null
        };

        /// <summary>
        /// Conditional compilation symbols
        /// </summary>
        /// <remarks>
        /// <para>https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives</para>
        /// <para>https://docs.microsoft.com/en-us/dotnet/standard/frameworks#how-to-specify-a-target-framework</para>
        /// </remarks>
        internal static readonly string[] ConditionalCompilations = {
#if DEBUG
    "DEBUG",
#endif
#if TRACE
    "TRACE",
#endif
#if RELEASE
    "RELEASE",
#endif
#if CODE_ANALYSIS
    "CODE_ANALYSIS",
#endif
#if UNSAFE
    "UNSAFE",
#endif
#if PORTABLE
    "PORTABLE",
#endif
#if NETFX_CORE
    "NETFX_CORE",
#endif
#if WINDOWS
    "WINDOWS",
#endif
#if WINDOWS_APP
    "WINDOWS_APP",
#endif
#if WINDOWS_PHONE
    "WINDOWS_PHONE",
#endif
#if WINDOWS_PHONE_APP
    "WINDOWS_PHONE_APP",
#endif
#if WINDOWS_UWP
    "WINDOWS_UWP",
#endif
#if SILVERLIGHT
    "SILVERLIGHT",
#endif
#if XBOX
    "XBOX",
#endif
#if XBOX360
    "XBOX360",
#endif
#if WindowsCE
    "WindowsCE",
#endif
#if __UNIFIED__
    "__UNIFIED__",
#endif
#if __MOBILE__
    "__MOBILE__",
#endif
#if __IOS__
    "__IOS__",
#endif
#if __TVOS__
    "__TVOS__",
#endif
#if NUNIT
    "NUNIT",
#endif
#if XUNIT
    "XUNIT",
#endif
#if NETFRAMEWORK
    "NETFRAMEWORK",
#endif
#if NET48
    "NET48",
#endif
#if NET472
    "NET472",
#endif
#if NET471
    "NET471",
#endif
#if NET47
    "NET47",
#endif
#if NET462
    "NET462",
#endif
#if NET461
    "NET461",
#endif
#if NET46
    "NET46",
#endif
#if NET452
    "NET452",
#endif
#if NET451
    "NET451",
#endif
#if NET45
    "NET45",
#endif
#if NET40
    "NET40",
#endif
#if NET35
    "NET35",
#endif
#if NET20
    "NET20",
#endif
#if NET48_OR_GREATER
    "NET48_OR_GREATER",
#endif
#if NET472_OR_GREATER
    "NET472_OR_GREATER",
#endif
#if NET471_OR_GREATER
    "NET471_OR_GREATER",
#endif
#if NET47_OR_GREATER
    "NET47_OR_GREATER",
#endif
#if NET462_OR_GREATER
    "NET462_OR_GREATER",
#endif
#if NET461_OR_GREATER
    "NET461_OR_GREATER",
#endif
#if NET46_OR_GREATER
    "NET46_OR_GREATER",
#endif
#if NET452_OR_GREATER
    "NET452_OR_GREATER",
#endif
#if NET451_OR_GREATER
    "NET451_OR_GREATER",
#endif
#if NET45_OR_GREATER
    "NET45_OR_GREATER",
#endif
#if NET40_OR_GREATER
    "NET40_OR_GREATER",
#endif
#if NET35_OR_GREATER
    "NET35_OR_GREATER",
#endif
#if NET20_OR_GREATER
    "NET20_OR_GREATER",
#endif
#if NETSTANDARD
    "NETSTANDARD",
#endif
#if NETSTANDARD2_1
    "NETSTANDARD2_1",
#endif
#if NETSTANDARD2_0
    "NETSTANDARD2_0",
#endif
#if NETSTANDARD1_6
    "NETSTANDARD1_6",
#endif
#if NETSTANDARD1_5
    "NETSTANDARD1_5",
#endif
#if NETSTANDARD1_4
    "NETSTANDARD1_4",
#endif
#if NETSTANDARD1_3
    "NETSTANDARD1_3",
#endif
#if NETSTANDARD1_2
    "NETSTANDARD1_2",
#endif
#if NETSTANDARD1_1
    "NETSTANDARD1_1",
#endif
#if NETSTANDARD1_0
    "NETSTANDARD1_0",
#endif
#if NETSTANDARD2_1_OR_GREATER
    "NETSTANDARD2_1_OR_GREATER",
#endif
#if NETSTANDARD2_0_OR_GREATER
    "NETSTANDARD2_0_OR_GREATER",
#endif
#if NETSTANDARD1_6_OR_GREATER
    "NETSTANDARD1_6_OR_GREATER",
#endif
#if NETSTANDARD1_5_OR_GREATER
    "NETSTANDARD1_5_OR_GREATER",
#endif
#if NETSTANDARD1_4_OR_GREATER
    "NETSTANDARD1_4_OR_GREATER",
#endif
#if NETSTANDARD1_3_OR_GREATER
    "NETSTANDARD1_3_OR_GREATER",
#endif
#if NETSTANDARD1_2_OR_GREATER
    "NETSTANDARD1_2_OR_GREATER",
#endif
#if NETSTANDARD1_1_OR_GREATER
    "NETSTANDARD1_1_OR_GREATER",
#endif
#if NETSTANDARD1_0_OR_GREATER
    "NETSTANDARD1_0_OR_GREATER",
#endif
#if NET
    "NET",
#endif
#if NET6_0
    "NET6_0",
#endif
#if NET5_0
    "NET5_0",
#endif
#if NETCOREAPP
    "NETCOREAPP",
#endif
#if NETCOREAPP3_1
    "NETCOREAPP3_1",
#endif
#if NETCOREAPP3_0
    "NETCOREAPP3_0",
#endif
#if NETCOREAPP2_2
    "NETCOREAPP2_2",
#endif
#if NETCOREAPP2_1
    "NETCOREAPP2_1",
#endif
#if NETCOREAPP2_0
    "NETCOREAPP2_0",
#endif
#if NETCOREAPP1_1
    "NETCOREAPP1_1",
#endif
#if NETCOREAPP1_0
    "NETCOREAPP1_0",
#endif
#if NET6_0_OR_GREATER
    "NET6_0_OR_GREATER",
#endif
#if NET5_0_OR_GREATER
    "NET5_0_OR_GREATER",
#endif
#if NETCOREAPP3_1_OR_GREATER
    "NETCOREAPP3_1_OR_GREATER",
#endif
#if NETCOREAPP3_0_OR_GREATER
    "NETCOREAPP3_0_OR_GREATER",
#endif
#if NETCOREAPP2_2_OR_GREATER
    "NETCOREAPP2_2_OR_GREATER",
#endif
#if NETCOREAPP2_1_OR_GREATER
    "NETCOREAPP2_1_OR_GREATER",
#endif
#if NETCOREAPP2_0_OR_GREATER
    "NETCOREAPP2_0_OR_GREATER",
#endif
#if NETCOREAPP1_1_OR_GREATER
    "NETCOREAPP1_1_OR_GREATER",
#endif
#if NETCOREAPP1_0_OR_GREATER
    "NETCOREAPP1_0_OR_GREATER",
#endif

            null
        };

        /// <summary>
        /// Output all.
        /// </summary>
        /// <param name="iw">The IIndentedWriter.</param>
        /// <param name="obj">object. Can be null.</param>
        /// <param name="context">State Object. Can be null.</param>
        /// <returns>Returns is ok.</returns>
        public static void OutputSystem(IIndentedWriter iw, object obj, IndentedWriterContext context) {
            if (null == context) context = new IndentedWriterContext();
#if NET6_0_OR_GREATER
            iw.WriteLine(indent + "System.Array.MaxLength:\t{0}", Array.MaxLength);
#endif
            iw.WriteLine("System.BitConverter.IsLittleEndian:\t{0}", BitConverter.IsLittleEndian);
            iw.WriteLine("System.IntPtr.Size:\t{0}", IntPtr.Size);
            // TypeNames.
            foreach (string name in TypeNames) {
                if (string.IsNullOrEmpty(name)) continue;
                Type tp = Type.GetType(name, false);
                if (null == tp) continue;
                iw.WriteLine(tp.FullName + ":");
                IndentedWriterUtil.WriteTypeStaticM(iw, tp, context);
            }
            // OtherTypes.
            foreach (Type tp in OtherTypes) {
                if (null == tp) continue;
                iw.WriteLine(tp.FullName + ":");
                IndentedWriterUtil.WriteTypeStaticM(iw, tp, context);
            }
            // Vector<T>
#if NET || NETCOREAPP || NETSTANDARD2_1_OR_GREATER
            iw.WriteLine(string.Format("Vector.IsHardwareAccelerated:\t{0}", Vector.IsHardwareAccelerated));
            iw.WriteLine(string.Format("Vector<byte>:\t{0}", Vector<byte>.Count));
            iw.WriteLine(string.Format("Vector<Int16>:\t{0}", Vector<Int16>.Count));
            iw.WriteLine(string.Format("Vector<Int32>:\t{0}", Vector<Int32>.Count));
            iw.WriteLine(string.Format("Vector<Int64>:\t{0}", Vector<Int64>.Count));
            iw.WriteLine(string.Format("Vector<float>:\t{0}", Vector<float>.Count));
            iw.WriteLine(string.Format("Vector<double>:\t{0}", Vector<double>.Count));
#endif
            // ConditionalCompilations
            iw.WriteLine("Conditional compilation symbols:");
            iw.Indent(null);
            foreach(string s in ConditionalCompilations) {
                if (string.IsNullOrEmpty(s)) continue;
                iw.WriteLine(s);
            }
            iw.Unindent();
        }

        /// <summary>
        /// Output all.
        /// </summary>
        /// <param name="iw">The IIndentedWriter.</param>
        /// <param name="obj">object. Can be null.</param>
        /// <param name="context">State Object. Can be null.</param>
        /// <returns>Returns is ok.</returns>
        public static void OutputAll(IIndentedWriter iw, object obj, IndentedWriterContext context) {
            OutputSystem(iw, obj, context);
        }

        /// <summary>
        /// Output all.
        /// </summary>
        /// <param name="writer">Output writer.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputAll(TextWriter writer, string indent) {
            IIndentedWriter iw = new TextIndentedWriter(writer);
            OutputAll(iw, null, null);
        }
    }
}
