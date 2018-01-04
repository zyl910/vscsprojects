using ReflectSpeed;
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

namespace ReflectSpeedSilverlight {
	public partial class MainPage : UserControl {
		public MainPage() {
			InitializeComponent();
		}

		private void btnInfo_Click(object sender, RoutedEventArgs e) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("ReflectSpeed - Silverlight 5");
			sb.AppendLine();
			ReflectSpeedTester tester = new ReflectSpeedTester();
			tester.Run(sb);
			// show.
			txtOut.Text = sb.ToString();
		}
	}
}
