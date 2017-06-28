using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestPinned
{
    public class Program
    {
        public static void Main(string[] args)
        {
			StringBuilder sb = new StringBuilder();
			// test.
			byte[] arr = new byte[2] { 0, 1 };
			unsafe
			{
				fixed (byte* p = &arr[0]) {
					sb.AppendLine(String.Format("Unsafe pointer: {0} // 0x{0:X}", (long)p));
					long offset = 1;
					byte* q = p + offset;   // 指针加减时支持 long 型.
					*q = 3;
				}
			}
			GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
			try {
				IntPtr p0 = handle.AddrOfPinnedObject();
				IntPtr p1 = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0);
				long offset = (long)p1 - (long)p0;
				//IntPtr p2 = p1 + offset;	// IntPtr 加减时不支持 long 型.
				sb.AppendLine(String.Format("AddrOfPinnedObject: {0} // 0x{0:X}", (long)p0));   // 发现 IntPtr 不支持 {0:X} 格式符，仅输出原值.
				sb.AppendLine(String.Format("UnsafeAddrOfPinnedArrayElement: {0} // 0x{1}", p1, p1.ToString("X")));
				sb.AppendLine(String.Format("offset: {0}", offset));
				Marshal.WriteByte(p1, 4);
			} finally {
				handle.Free();
			}
			sb.AppendLine(String.Format("After arr: {0}, {1}", arr[0], arr[1]));
			//arr.LongLength	// 目前只有桌面平台的 .NET Framework 支持数组长度超过 4G.
			// done.
			Console.WriteLine(sb.ToString());
        }
    }
}
