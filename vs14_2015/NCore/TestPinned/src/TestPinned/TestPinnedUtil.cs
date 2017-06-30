using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TestPinned {
	/// <summary>
	/// 测试钉住值类型.
	/// </summary>
	public static class TestPinnedUtil {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">字符串缓冲区.</param>
		// [SecuritySafeCritical]  // Silverlight时, 配置 SecuritySafeCritical/AllowPartiallyTrustedCallers等均无效. 但是给项目配上 “允许再浏览器外运行程序”、“在浏览器之外运行时需要提升的信任” 后便能用, 甚至无需 SecuritySafeCritical, 待进一步研究.
		public static void OutputInfo(StringBuilder sb) {
			byte[] arr = new byte[2] { 0, 1 };
			// Test SecurityCritical .
			if (true) {
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
