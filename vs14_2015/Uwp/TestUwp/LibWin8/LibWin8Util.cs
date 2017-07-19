using LibShared;
using SharedWinrt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibWin8 {
	/// <summary>
	/// Windows 8.1 Class Library util (Windows8.1类库工具).
	/// </summary>
	public class LibWin8Util {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibWin8Util on " + onproject;
			LibSharedUtil.OutputCommon(sb, myproject);
			SharedWinrtUtil.OutputWinrt(sb, myproject);
		}
	}
}
