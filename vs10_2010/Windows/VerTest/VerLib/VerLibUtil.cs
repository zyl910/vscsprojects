using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace VerLib {
	/// <summary>
	/// VerLib 的工具.
	/// </summary>
	public class VerLibUtil {

		/// <summary>
		/// 输出基本信息.
		/// </summary>
		/// <param name="twer">文本输出者.</param>
		public static void OutputBase(System.IO.TextWriter twer) {
			twer.WriteLine("[Base]");
			//twer.WriteLine(string.Format("ImageRuntimeVersion={0}", typeof(VerLibUtil).Assembly.ImageRuntimeVersion));
			twer.WriteLine(string.Format("OSVersion={0}", Environment.OSVersion));
			twer.WriteLine(string.Format("Is64BitOperatingSystem={0}", Environment.Is64BitOperatingSystem));
			twer.WriteLine(string.Format("Is64BitProcess={0}", Environment.Is64BitProcess));
			twer.WriteLine();
		}

		/// <summary>
		/// 输出程序集信息.
		/// </summary>
		/// <param name="twer">文本输出者.</param>
		/// <param name="assembly">程序集.</param>
		public static void OutputAssembly(System.IO.TextWriter twer, System.Reflection.Assembly assembly) {
			if (null == twer) return;
			if (null == assembly) return;
			AssemblyName name = assembly.GetName();
			twer.WriteLine(string.Format("[{0}]", name.Name));
			twer.WriteLine(string.Format("FullName={0}", assembly.FullName));
			twer.WriteLine(string.Format("ImageRuntimeVersion={0}", assembly.ImageRuntimeVersion));
			twer.WriteLine(string.Format("Location={0}", assembly.Location));
			//twer.WriteLine(string.Format("CodeBase={0}", name.CodeBase));
			twer.WriteLine(string.Format("ProcessorArchitecture={0}", name.ProcessorArchitecture));
			object[] attributes = assembly.GetCustomAttributes(false);
			foreach (object o in attributes) {
				if (null == o) continue;
				//Type otype = o.GetType();
				//string tname = otype.Name;
				//if (string.IsNullOrEmpty(tname)) continue;
				//if (tname.IndexOf("version", StringComparison.OrdinalIgnoreCase) >= 0) {
				//    twer.WriteLine(string.Format("  {0}", o));
				//}
				object ovalue = GetAttributeValue(o);
				if (null != ovalue) {
					twer.WriteLine(string.Format("  {0}\t// {1}", o, ovalue));
				}
			}
			twer.WriteLine();
		}

		/// <summary>
		/// 取得特性的值.
		/// </summary>
		/// <param name="o">特性对象.</param>
		/// <returns>返回它的值.</returns>
		private static object GetAttributeValue(object o) {
			object rt = null;
			if (null == o) return rt;
			if (o is AssemblyVersionAttribute) {
				rt = (o as AssemblyVersionAttribute).Version;
			} else if (o is AssemblyInformationalVersionAttribute) {
				rt = (o as AssemblyInformationalVersionAttribute).InformationalVersion;
			} else if (o is AssemblyFileVersionAttribute) {
				rt = (o as AssemblyFileVersionAttribute).Version;
			}
			return rt;
		}
	}
}
