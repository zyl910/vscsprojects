using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibNStd10 {
	/// <summary>
	/// Class Library (.NET Standard) 1.0 util (.NET Standard类库 1.0 工具).
	/// </summary>
	public class LibNStd10Util {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibNStd10 on " + onproject;
			LibSharedUtil.OutputCommon(sb, myproject);
		}
	}
}
