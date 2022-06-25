using LibSysInfo;
using LibSysInfo.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp50 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //
        }

        private void btnTest_Click(object sender, RoutedEventArgs e) {
            StringWriter strWriter = new StringWriter();
            //strWriter.WriteLine("Test);
            TextIndentedWriter iw = new TextIndentedWriter(strWriter);
            SysInfoUtil.OutputAll(iw, null, null);
            txtOutput.Text = strWriter.ToString();
        }
    }
}
