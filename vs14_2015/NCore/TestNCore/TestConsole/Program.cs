using LibNStd10;
using LibPcl259;
using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
	class Program {
		static void Main(string[] args) {
			const string myproject = "TestConsole";
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputHead(sb, myproject);
			LibNStd10Util.OutputInfo(sb, myproject);
			LibPcl259Util.OutputInfo(sb, myproject);
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}
