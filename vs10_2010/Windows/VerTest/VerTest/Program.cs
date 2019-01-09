using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VerLib;

namespace VerTest {
	class Program {
		static void Main(string[] args) {
			TextWriter twer = Console.Out;
			//typeof(Program).Assembly
			VerLibUtil.OutputAssembly(twer, typeof(Program).Assembly);
			VerLibUtil.OutputAssembly(twer, typeof(VerLibUtil).Assembly);
			VerLibUtil.OutputAssembly(twer, typeof(String).Assembly);
		}
	}
}
