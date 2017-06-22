using LibNStd10;
using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibPcl259 {
	/// <summary>
	/// Portable Class Library Profile259 util (可移植库259工具).
	/// </summary>
	public class LibPcl259Util {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibPcl259 on " + onproject;
			LibSharedUtil.OutputCommon(sb, myproject);
			LibNStd10Util.OutputInfo(sb, myproject);
		}
	}
}
