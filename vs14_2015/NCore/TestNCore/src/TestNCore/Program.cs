using LibNStd10;
using LibNStd10U;
using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
			const string myproject = "TestNCore";
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputHead(sb, myproject);
			LibNStd10Util.OutputInfo(sb, myproject);
			LibNStd10UUtil.OutputInfo(sb, myproject);
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}
