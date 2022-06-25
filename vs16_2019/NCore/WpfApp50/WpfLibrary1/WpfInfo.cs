using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Media;

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


        /// <summary>
        /// Output all.
        /// </summary>
        /// <param name="writer">Output writer.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputAll(TextWriter writer) {
            writer.WriteLine("PixelFormats:");
			int idx = 0;
			writer.WriteLine("idx\tName\tbits\tmasks\tmask0\tmask1\tmask2\tmask3");
			foreach (PropertyInfo pi in typeof(PixelFormats).GetProperties()) {
				PixelFormat pixelFormat = (PixelFormat)pi.GetValue(pi, null);
				if (pixelFormat != PixelFormats.Default) {
					writer.Write(String.Format("{0}\t{1}\t{2}",
						idx, pixelFormat.ToString(), pixelFormat.BitsPerPixel));
					IList<PixelFormatChannelMask> masks = pixelFormat.Masks;
					if (null != masks) {
						writer.Write(String.Format("\t{0}", masks.Count));
						foreach (PixelFormatChannelMask pfcm in masks) {
							writer.Write("\t");
							foreach (byte by in pfcm.Mask) {
								writer.Write(String.Format("{0:X2}", by));
							}
						}
					} else {
					}
					// next.
					++idx;
					writer.WriteLine();
				}
			}
		}
	}
}
