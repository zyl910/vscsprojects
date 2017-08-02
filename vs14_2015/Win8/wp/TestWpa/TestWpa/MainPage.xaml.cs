﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestWpa.Resources;
using System.Text;
using LibShared;

namespace TestWpa {
	public partial class MainPage : PhoneApplicationPage {
		// 构造函数
		public MainPage() {
			InitializeComponent();

			// 用于本地化 ApplicationBar 的示例代码
			//BuildLocalizedApplicationBar();
		}

		private void btnInfo_Click(object sender, RoutedEventArgs e) {
			const string myproject = "TestWpa";
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputHead(sb, myproject);
			// show.
			txtOut.Text = sb.ToString();
		}

		// 用于生成本地化 ApplicationBar 的示例代码
		//private void BuildLocalizedApplicationBar()
		//{
		//    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
		//    ApplicationBar = new ApplicationBar();

		//    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
		//    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
		//    appBarButton.Text = AppResources.AppBarButtonText;
		//    ApplicationBar.Buttons.Add(appBarButton);

		//    // 使用 AppResources 中的本地化字符串创建新菜单项。
		//    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
		//    ApplicationBar.MenuItems.Add(appBarMenuItem);
		//}
	}
}