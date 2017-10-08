using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Xamarin_Pcl {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			InitializeBind();
		}

		public void InitializeBind() {
			//Debug.WriteLine("InitializeBind");
			Button btnInfo = this.FindByName<Button>("btnInfo");
			if (null!= btnInfo) {
				btnInfo.Clicked += btnInfo_Click;
			}
		}

		private void btnInfo_Click(object sender, EventArgs e) {
			//Debug.WriteLine("btnInfo_Click");
			StringBuilder sb = new StringBuilder();
			// test.
			sb.AppendLine("App_Xamarin_Pcl");
			sb.AppendLine();
			// test.
			sb.AppendLine("[Device]");
			sb.AppendLine(string.Format("Idiom: {0}", Device.Idiom));
#pragma warning disable 0618
			sb.AppendLine(string.Format("OS: {0}", Device.OS));
#pragma warning restore 0618
			sb.AppendLine(string.Format("RuntimePlatform: {0}", Device.RuntimePlatform));
			// done.
			Editor txtInfo = this.FindByName<Editor>("txtInfo");
			txtInfo.Text = sb.ToString();
		}
	}
}