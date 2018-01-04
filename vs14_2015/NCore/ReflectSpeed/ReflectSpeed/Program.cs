using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectSpeed {
	/// <summary>
	/// 反射速度测试的程序 - .NET framework.
	/// </summary>
	class Program {
		static void Main(string[] args) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("ReflectSpeed - .NET Core 1.0");
			sb.AppendLine();
			ReflectSpeedTester tester = new ReflectSpeedTester();
			tester.Run(sb);
			// done.
			Console.WriteLine(sb);
		}
	}
}
