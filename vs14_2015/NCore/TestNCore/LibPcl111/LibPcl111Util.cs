using LibPcl259;
using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibPcl111
{
	/// <summary>
	/// Portable Class Library Profile111 util (可移植库111工具).
	/// </summary>
	public class LibPcl111Util
    {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibPcl111 on " + onproject;
			LibSharedUtil.OutputCommon(sb, myproject);
			LibPcl259Util.OutputInfo(sb, myproject);
		}
	}
}
