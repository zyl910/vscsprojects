#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

#endregion

namespace DeviceApplication1 {
	/// <summary>
	/// 窗体的摘要描述。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form {
		/// <summary>
		/// 窗体的主菜单。
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;

		public Form1() {
			InitializeComponent();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.Menu = this.mainMenu1;

			this.Text = "Form1";
		}

		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		static void Main() {
			Application.Run(new Form1());
		}

	}
}

