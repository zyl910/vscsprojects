using LibSysInfo;
using LibSysInfo.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp31 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            StringWriter strWriter = new StringWriter();
            //strWriter.WriteLine("Test);
            TextIndentedWriter iw = new TextIndentedWriter(strWriter);
            SysInfoUtil.OutputAll(iw, null, null);
            txtOutput.Text = strWriter.ToString();
        }
    }
}
