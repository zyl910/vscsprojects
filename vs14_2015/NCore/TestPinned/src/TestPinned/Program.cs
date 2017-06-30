using System;
using System.Collections.Generic;
using System.Linq;
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
			TestPinnedUtil.OutputInfo(sb);
			// done.
			Console.WriteLine(sb.ToString());
        }
    }
}
