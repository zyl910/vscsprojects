using System;
using System.Collections.Generic;
using System.Text;

namespace WpfLibrary1 {
    /// <summary>
    /// WpfInfo
    /// </summary>
    public static class WpfInfo {
        /// <summary>
        /// Get FrameworkDescription.
        /// </summary>
        public static string FrameworkDescription {
            get {
                return System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            }
        }
    }
}
