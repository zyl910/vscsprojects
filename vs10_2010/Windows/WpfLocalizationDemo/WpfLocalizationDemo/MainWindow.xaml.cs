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
using System.Windows.Markup;
using WpfLocalizationDemo.Properties;

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
				// CurrentCulture
				// 单独修改CurrentUICulture后，只对新创建的窗口内容有用，已有的界面不会自动改变语言。例如 Calendar 的语言不变，DatePicker以首次下拉时的语言为准.
				Thread.CurrentThread.CurrentCulture = cultureInfo;
				Thread.CurrentThread.CurrentUICulture = cultureInfo;
				ApplicationResources.Current.ChangeCulture(cultureInfo);
				// XmlLanguage.
				//XmlLanguage xmlLanguage = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
				//this.Language = xmlLanguage;	// 无效.
				//clnDate.Language = xmlLanguage;	// 无效.
				// http://www.cnblogs.com/wangnmhb/p/4078663.html
				//FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xmlLanguage));	// 对界面没影响，且只能调一次，再次调用会报异常—— System.ArgumentException: PropertyMetadata 已经为类型“FrameworkElement”注册。
				// ui
				Labels.Culture = cultureInfo;
				lblLanguage.Content = Labels.MainWindow_lblLanguage;
				Debug.WriteLine(Labels.MainWindow_lblLanguage);
			} catch (Exception ex) {
				Debug.WriteLine(ex);
			}
		}
	}
}
