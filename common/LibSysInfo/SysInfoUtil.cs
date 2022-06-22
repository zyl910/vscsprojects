using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibSysInfo {
    /// <summary>
    /// System info util.
    /// </summary>
    public class SysInfoUtil {
        /// <summary>
        /// Next indent char.
        /// </summary>
        public const string NextIndentChar = " ";

#region namespace System
        /// <summary>
        /// Output namespace System .
        /// </summary>
        /// <param name="writer">Output writer.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputSystem(TextWriter writer, string indent) {
            if (null == indent) indent = "";
            string indentNext = indent + NextIndentChar;
#if NET6_0_OR_GREATER
            writer.WriteLine(indent + "System.Array.MaxLength\t{0}", Array.MaxLength);
#endif
            writer.WriteLine(indent + "System.BitConverter.IsLittleEndian\t{0}", BitConverter.IsLittleEndian);
            writer.WriteLine(indent + "System.IntPtr.Size\t{0}", IntPtr.Size);
        }
        #endregion // namespace System

        /// <summary>
        /// Output all.
        /// </summary>
        /// <param name="writer">Output writer.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputAll(TextWriter writer, string indent) {
            if (null == indent) indent = "";
            OutputSystem(writer, indent);
        }
    }
}
