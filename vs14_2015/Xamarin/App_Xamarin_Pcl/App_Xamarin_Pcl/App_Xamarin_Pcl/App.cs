﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App_Xamarin_Pcl {
	public class App : Application {
		public App() {
			//// The root page of your application
			//var content = new ContentPage {
			//	Title = "App_Xamarin_Pcl",
			//	Content = new StackLayout {
			//		VerticalOptions = LayoutOptions.Center,
			//		Children = {
			//			new Label {
			//				HorizontalTextAlignment = TextAlignment.Center,
			//				Text = "Welcome to Xamarin Forms!"
			//			}
			//		}
			//	}
			//};

			//MainPage = new NavigationPage(content);
			MainPage = new App_Xamarin_Pcl.MainPage();
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
