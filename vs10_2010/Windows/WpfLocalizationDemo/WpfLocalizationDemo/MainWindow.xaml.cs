using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace WpfLocalizationDemo {
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;
			Debug.WriteLine(cultureInfo);
		}

		private void cboLang_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			try {
				object obj = cboLang.SelectedValue;
				if (null == obj) return;
				string lang = obj.ToString();
				CultureInfo cultureInfo = new CultureInfo(lang);
				Debug.WriteLine(string.Format("New CultureInfo: {0}", cultureInfo));
				Thread.CurrentThread.CurrentCulture = cultureInfo;
				Thread.CurrentThread.CurrentUICulture = cultureInfo;
			} catch (Exception ex) {
				Debug.WriteLine(ex);
			}
		}
	}
}
