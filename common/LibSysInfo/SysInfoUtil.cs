using LibSysInfo.Writer;
using System;
using System.Collections.Generic;
using System.IO;
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
