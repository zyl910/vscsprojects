using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using WpfLocalizationDemo.Properties;

namespace WpfLocalizationDemo {
	/// <summary>
	/// WPF应用程序级资源. 对应的资源文件是 Labels.resx .
	/// </summary>
	public class ApplicationResources : INotifyPropertyChanged {
		private static ApplicationResources current;
		private static Labels lables;

		public event PropertyChangedEventHandler PropertyChanged;

		public ApplicationResources() {
			current = this;	// 自动绑定最后一个创建的对象.
			lables = new Labels();
		}

		public static ApplicationResources Current {
			get { return ApplicationResources.current; }
			set { ApplicationResources.current = value; }
		}

		public static Labels Labels {
			get { return ApplicationResources.lables; }
			set { ApplicationResources.lables = value; }
		}

		protected virtual void RaisePropertyChanged(string propertyName = null) {
			var handler = this.PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void ChangeCulture(System.Globalization.CultureInfo cultureInfo) {
			if (null == cultureInfo) return;
			if (cultureInfo.Equals(Labels.Culture)) return;
			Labels.Culture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			RaisePropertyChanged("");
		}

	}
}
