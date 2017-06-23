using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TestSilverlight {
	public partial class MainPage : UserControl {
		public MainPage() {
			InitializeComponent();
		}

		private void btnInfo_Click(object sender, RoutedEventArgs e) {
			const string myproject = "TestSilverlight";
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputHead(sb, myproject);
			// show.
			txtOut.Text = sb.ToString();
		}
	}
}
