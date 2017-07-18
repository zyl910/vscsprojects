using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LibPinnedSilverlight {
    /// <summary>
    /// Pinned util for Silverlight library.
    /// </summary>
    public class LibPinnedSilverlightUtil {
        /// <summary>
        /// 输出信息.
        /// </summary>
        /// <param name="sb">字符串缓冲区.</param>
        [SecuritySafeCritical]
        public static void OutputInfo(StringBuilder sb) {
            OutputInfo_Critical(sb);
        }

        /// <summary>
        /// 输出信息_关键.
        /// </summary>
        /// <param name="sb">字符串缓冲区.</param>
        [SecurityCritical] // Only on .NET 4.0 +
        // [SecurityPermissionAttribute(SecurityAction.Deny, UnmanagedCode = true)] // Only on .NET 2.0
        public static void OutputInfo_Critical(StringBuilder sb) {
            byte[] arr = new byte[2] { 0, 1 };
            // Test SecurityCritical .
            if (true) {
                // https://msdn.microsoft.com/en-us/library/1246yz8f(v=vs.95).aspx
                // GCHandle.Alloc Method
                // This member can be used only by trusted applications. If you try to use this member in a partial-trust application, your code will throw a MethodAccessException exception. This member is security-critical, which restricts its use.
                // 
                // https://msdn.microsoft.com/zh-cn/library/1246yz8f(v=vs.95).aspx
                // GCHandle.Alloc 方法
                // 请不要在您的应用程序中使用此成员。否则，您的代码会生成 MethodAccessException。此成员是安全关键型的，这种类型将其限定为只能由 .NET Framework for Silverlight 类库在内部使用。
                // 
                // https://msdn.microsoft.com/en-us/library/1246yz8f(v=vs.105).aspx
                // GCHandle.Alloc Method
                // For apps that target Windows Phone OS 7.0 and 7.1, do not use this member in your app. If you do, your code will throw a MethodAccessException. This member is security-critical, which restricts it to internal use by the .NET Framework for Windows Phone class library.
                // 
                // https://msdn.microsoft.com/zh-cn/library/1246yz8f(v=vs.105).aspx
                // GCHandle.Alloc 方法
                // 对于针对 Windows Phone OS 7.0 和 7.1 的应用，请不要在应用中使用此成员。如果使用的话，您的代码将引发 MethodAccessException。此成员的安全是非常关键的，将其限制为由 .NET Framework for Windows Phone 类库内部使用。
                int m = Marshal.SizeOf(typeof(GCHandle));
                sb.AppendLine(String.Format("SizeOf(GCHandle): {0} // 0x{0:X}", m));
            }
            // pointer.
#if (UNSAFE)
			unsafe {
				fixed (byte* p = &arr[0]) {
					sb.AppendLine(String.Format("Unsafe pointer: {0} // 0x{0:X}", (long)p));
					long offset = 1;
					byte* q = p + offset;   // 指针加减时支持 long 型.
					*q = 3;
				}
			}
#endif
            // Pinned.
            GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            try {
                IntPtr p0 = handle.AddrOfPinnedObject();
                sb.AppendLine(String.Format("AddrOfPinnedObject: {0} // 0x{0:X}", (long)p0));   // 发现 IntPtr 不支持 {0:X} 格式符，仅输出原值.
#if (SILVERLIGHT)
                Marshal.WriteByte(p0, 4);
#else
				IntPtr p1 = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0);
				long offset = (long)p1 - (long)p0;
				//IntPtr p2 = p1 + offset;	// IntPtr 加减时不支持 long 型.
				sb.AppendLine(String.Format("UnsafeAddrOfPinnedArrayElement: {0} // 0x{1}", p1, p1.ToString("X")));
				sb.AppendLine(String.Format("offset: {0}", offset));
				Marshal.WriteByte(p1, 4);
#endif
            } finally {
                handle.Free();
            }
            // show.
            sb.AppendLine(String.Format("After arr: {0}, {1}", arr[0], arr[1]));
            //arr.LongLength	// 目前只有桌面平台的 .NET Framework 支持数组长度超过 32位.
        }

    }
}
