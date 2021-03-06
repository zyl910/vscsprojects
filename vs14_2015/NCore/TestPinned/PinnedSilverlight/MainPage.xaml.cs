﻿using LibPinnedSilverlight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TestPinned;

namespace PinnedSilverlight {
	public partial class MainPage : UserControl {
		public MainPage() {
			InitializeComponent();
		}

        [SecurityPermissionAttribute(SecurityAction.Deny, Flags = SecurityPermissionFlag.AllFlags)]
        private void btnInfo_Click(object sender, RoutedEventArgs e) {
			StringBuilder sb = new StringBuilder();
            // test.
            sb.AppendLine("== LibPinnedSilverlightUtil ==");
            try
            {
                LibPinnedSilverlightUtil.OutputInfo(sb);
            }
            catch (Exception ex)
            {
                sb.Append(ex.ToString());
            }
            sb.AppendLine("== TestPinnedUtil ==");
            try
            {
				TestPinnedUtil.OutputInfo(sb);
			} catch(Exception ex) {
				sb.Append(ex.ToString());
			}
			// done.
			txtOut.Text = sb.ToString();
		}
	}
}
