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
using System.IO;
using System.Diagnostics;

namespace WpfPointWhere {
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		/// <summary>
		/// 填写系统信息.
		/// </summary>
		/// <param name="tw">文本输出者.</param>
		private void FillSystemInfo(TextWriter tw) {
			tw.WriteLine("[SystemParameters]");
			tw.WriteLine(string.Format("VirtualScreenLeft: {0}", SystemParameters.VirtualScreenLeft));
			tw.WriteLine(string.Format("VirtualScreenTop: {0}", SystemParameters.VirtualScreenTop));
			tw.WriteLine(string.Format("VirtualScreenWidth: {0}", SystemParameters.VirtualScreenWidth));
			tw.WriteLine(string.Format("VirtualScreenHeight: {0}", SystemParameters.VirtualScreenHeight));
			tw.WriteLine(string.Format("PrimaryScreenWidth: {0}", SystemParameters.PrimaryScreenWidth));
			tw.WriteLine(string.Format("PrimaryScreenHeight: {0}", SystemParameters.PrimaryScreenHeight));
			tw.WriteLine(string.Format("FullPrimaryScreenWidth: {0}", SystemParameters.FullPrimaryScreenWidth));
			tw.WriteLine(string.Format("FullPrimaryScreenHeight: {0}", SystemParameters.FullPrimaryScreenHeight));
			//tw.WriteLine(string.Format("MaximizedPrimaryScreenWidth: {0}", SystemParameters.MaximizedPrimaryScreenWidth));
			//tw.WriteLine(string.Format("MaximizedPrimaryScreenHeight: {0}", SystemParameters.MaximizedPrimaryScreenHeight));
			//tw.WriteLine(string.Format("MaximumWindowTrackWidth: {0}", SystemParameters.MaximumWindowTrackWidth));
			//tw.WriteLine(string.Format("MaximumWindowTrackHeight: {0}", SystemParameters.MaximumWindowTrackHeight));
			//tw.WriteLine(string.Format("MinimizedWindowWidth: {0}", SystemParameters.MinimizedWindowWidth));
			//tw.WriteLine(string.Format("MinimizedWindowHeight: {0}", SystemParameters.MinimizedWindowHeight));
			//tw.WriteLine(string.Format("MinimumWindowTrackWidth: {0}", SystemParameters.MinimumWindowTrackWidth));
			//tw.WriteLine(string.Format("MinimumWindowTrackHeight: {0}", SystemParameters.MinimumWindowTrackHeight));
			//tw.WriteLine(string.Format("MinimumWindowTrackWidth: {0}", SystemParameters.MinimumWindowHeight));
			//tw.WriteLine(string.Format("MinimumWindowTrackWidth: {0}", SystemParameters.MinimumWindowWidth));
			tw.WriteLine(string.Format("WorkArea: {0}", SystemParameters.WorkArea));
			tw.WriteLine();
		}

		/// <summary>
		/// 填充网格信息.
		/// </summary>
		/// <param name="tw">文本输出者.</param>
		/// <param name="src">源对象.</param>
		/// <param name="title">标题</param>
		private void FillGrid(TextWriter tw, Grid src, string title) {
			tw.WriteLine(string.Format("[{0}]", title));
			tw.WriteLine(string.Format("Width: {0}", src.Width));
			tw.WriteLine(string.Format("Width: {0}", src.Height));
			tw.WriteLine(string.Format("ActualWidth: {0}", src.ActualWidth));
			tw.WriteLine(string.Format("ActualHeight: {0}", src.ActualHeight));
			tw.WriteLine(string.Format("DesiredSize: {0}", src.DesiredSize));
			tw.WriteLine(string.Format("RenderSize: {0}", src.RenderSize));
			// screen point.
			Rect rct = new Rect();
			try {
				Point client0 = new Point(0, 0);
				Point client1 = new Point(src.ActualWidth, src.ActualHeight);
				Point screen0 = src.PointToScreen(client0);
				Point screen1 = src.PointToScreen(client1);
				rct = new Rect(screen0, screen1);
			} catch (Exception ex) {
				Debug.WriteLine(ex);
			}
			tw.WriteLine(string.Format("ToScreen: {0}", rct));
			tw.WriteLine();
		}

		/// <summary>
		/// 填充基本信息.
		/// </summary>
		/// <param name="tw">文本输出者.</param>
		private void FillBaseInfo(TextWriter tw) {
			tw.WriteLine("[Window]");
			tw.WriteLine(string.Format("RestoreBounds: {0}", this.RestoreBounds));
			tw.WriteLine(string.Format("Left: {0}", this.Left));
			tw.WriteLine(string.Format("Top: {0}", this.Top));
			tw.WriteLine(string.Format("Width: {0}", this.Width));
			tw.WriteLine(string.Format("Width: {0}", this.Height));
			tw.WriteLine(string.Format("ActualWidth: {0}", this.ActualWidth));
			tw.WriteLine(string.Format("ActualHeight: {0}", this.ActualHeight));
			tw.WriteLine();
			// Grid.
			FillGrid(tw, grdRoot, "grdRoot");
			FillGrid(tw, grdMain, "grdMain");
		}

		/// <summary>
		/// 填充拖动信息.
		/// </summary>
		/// <param name="tw">文本输出者.</param>
		/// <param name="e">鼠标事件.</param>
		private void FillDragInfo(TextWriter tw, MouseEventArgs e) {
			if (null == e) return;
			ContentControl btnDrag = this.btnDrag;
			tw.WriteLine("[MouseEventArgs]");
			tw.WriteLine(string.Format("Timestamp: {0}", e.Timestamp));
			tw.WriteLine(string.Format("GetPosition(btnDrag): {0}", e.GetPosition(btnDrag)));
			tw.WriteLine(string.Format("GetPosition(grdMain): {0}", e.GetPosition(grdMain)));
			tw.WriteLine(string.Format("GetPosition(grdRoot): {0}", e.GetPosition(grdRoot)));
			tw.WriteLine();
			// MouseDevice
			MouseDevice md = e.MouseDevice;
			if (null == md) return;
			tw.WriteLine("[MouseDevice]");
			//tw.WriteLine(string.Format("ToString: {0}", md));
			tw.WriteLine(string.Format("GetPosition(btnDrag): {0}", md.GetPosition(btnDrag)));
			tw.WriteLine();
			// PointToScreen.
			tw.WriteLine("[Screen Point]");
			tw.WriteLine(string.Format("MouseEventArgs: {0}", btnDrag.PointToScreen(e.GetPosition(btnDrag))));
			tw.WriteLine(string.Format("MouseDevice: {0}", btnDrag.PointToScreen(md.GetPosition(btnDrag))));
			tw.WriteLine(string.Format("Control.MousePosition: {0}", System.Windows.Forms.Control.MousePosition));
			tw.WriteLine(string.Format("Cursor.Position: {0}", System.Windows.Forms.Cursor.Position));
			tw.WriteLine();
		}

		/// <summary>
		/// 更新拖动信息.
		/// </summary>
		/// <param name="e">鼠标事件.</param>
		private void UpdateDragInfo(MouseEventArgs e) {
			StringBuilder sb = new StringBuilder();
			using (TextWriter tw = new StringWriter(sb)) {
				FillDragInfo(tw, e);
			}
			txtDragInfo.Text = sb.ToString();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			//btnDrag_Click(btnDrag, null);
			btnSystemInfo_Click(btnSystemInfo, null);
		}

		private void btnSystemInfo_Click(object sender, RoutedEventArgs e) {
			StringBuilder sb = new StringBuilder();
			using (TextWriter tw = new StringWriter(sb)) {
				FillBaseInfo(tw);
				FillSystemInfo(tw);
			}
			txtSystemInfo.Text = sb.ToString();
		}

		private void btnDrag_MouseMove(object sender, MouseEventArgs e) {
			UpdateDragInfo(e);
		}

		private void btnDrag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			Debug.WriteLine("MouseLeftButtonDown");
			//btnDrag.CaptureMouse();
		}

		private void btnDrag_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
			Debug.WriteLine("MouseLeftButtonUp");
			btnDrag.ReleaseMouseCapture();
		}

		private void btnDrag_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
			Debug.WriteLine("PreviewMouseDown");
			if (null == e) return;
			if (e.LeftButton == MouseButtonState.Pressed) {
				e.Handled = true;
				btnDrag.CaptureMouse();
			}
		}

		private void btnDrag_PreviewMouseUp(object sender, MouseButtonEventArgs e) {
			Debug.WriteLine("PreviewMouseUp");
			if (e.LeftButton == MouseButtonState.Pressed) {
				if (btnDrag.IsMouseCaptureWithin) {
					btnDrag.ReleaseMouseCapture();
				}
			}
		}

	}
}
