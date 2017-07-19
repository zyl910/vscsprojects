using LibShared;
using LibWin8;
using SharedWinrt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace TestUwp {
	/// <summary>
	/// 可用于自身或导航至 Frame 内部的空白页。
	/// </summary>
	public sealed partial class MainPage : Page {
		public MainPage() {
			this.InitializeComponent();
		}

		private void btnInfo_Click(object sender, RoutedEventArgs e) {
			const string myproject = "TestUwp";
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputHead(sb, myproject);
			OutputUwp(sb, myproject);
			SharedWinrtUtil.OutputWinrt(sb, myproject);
			LibWin8Util.OutputInfo(sb, myproject);
			// show.
			txtOut.Text = sb.ToString();
		}

		/// <summary>
		/// Output UWP info (输出 UWP 信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputUwp(StringBuilder sb, string onproject) {
			// AnalyticsVersionInfo
			sb.AppendLine(LibSharedUtil.GetHeadString("AnalyticsVersionInfo", onproject));
			AnalyticsVersionInfo ai = AnalyticsInfo.VersionInfo;
			sb.AppendLine(string.Format("DeviceFamily:\t{0}", ai.DeviceFamily));
			sb.AppendLine(string.Format("DeviceFamilyVersion:\t{0}", ai.DeviceFamilyVersion));
			sb.AppendLine(string.Format("DeviceFamilyVersion$:\t{0}", LibSharedUtil.VersionFromInt(ulong.Parse(ai.DeviceFamilyVersion))));
			sb.AppendLine();
		}
	}
}
