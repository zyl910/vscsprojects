﻿using LibShared;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;

namespace SharedWinrt {
	/// <summary>
	/// Shared Windows RT util（共享的 WindowsRT 工具）.
	/// </summary>
	internal class SharedWinrtUtil {
		/// <summary>
		/// Output Window RT info (输出 WindowsRT 信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputWinrt(StringBuilder sb, string onproject) {
			// Package
			sb.AppendLine(LibSharedUtil.GetHeadString("Package", onproject));
			Package package = Package.Current;
#if WINDOWS_UWP
			sb.AppendLine(string.Format("Description:\t{0}", package.Description));
			sb.AppendLine(string.Format("DisplayName:\t{0}", package.DisplayName));
			//sb.AppendLine(string.Format("InstallDate:\t{0}", package.InstallDate));	// Exception
			//sb.AppendLine(string.Format("InstalledDate:\t{0}", package.InstalledDate));
#endif
			//sb.AppendLine(string.Format("InstalledLocation:\t{0}", package.InstalledLocation));
			sb.AppendLine(string.Format("InstalledLocation:\t{0}", package.InstalledLocation.Path));
#if WINDOWS_UWP
			sb.AppendLine(string.Format("PublisherDisplayName:\t{0}", package.PublisherDisplayName));
#endif
			//sb.AppendLine(string.Format("Id:\t{0}", package.Id));
			sb.AppendLine(string.Format("Id.Architecture:\t{0}", package.Id.Architecture));
			////sb.AppendLine(string.Format("Id.Author:\t{0}", package.Id.Author)); // System.InvalidCastException:“Unable to cast object of type 'Windows.ApplicationModel.PackageId' to type 'Windows.ApplicationModel.IPackageIdWithMetadata'.”
			//sb.AppendLine(string.Format("Id.FamilyName:\t{0}", package.Id.FamilyName));
			sb.AppendLine(string.Format("Id.FullName:\t{0}", package.Id.FullName));
			//sb.AppendLine(string.Format("Id.Name:\t{0}", package.Id.Name));
			////sb.AppendLine(string.Format("Id.ProductId:\t{0}", package.Id.ProductId));   // System.InvalidCastException:“Unable to cast object of type 'Windows.ApplicationModel.PackageId' to type 'Windows.ApplicationModel.IPackageIdWithMetadata'.”
			//sb.AppendLine(string.Format("Id.Publisher:\t{0}", package.Id.Publisher));
			//sb.AppendLine(string.Format("Id.PublisherId:\t{0}", package.Id.PublisherId));
			//sb.AppendLine(string.Format("Id.ResourceId:\t{0}", package.Id.ResourceId));
			//sb.AppendLine(string.Format("Id.Version:\t{0}", package.Id.Version));
			PackageVersion pv = package.Id.Version;
			string pvs = string.Format("{0}.{1}.{2}.{3}", pv.Major, pv.Minor, pv.Revision, pv.Build);
			sb.AppendLine(string.Format("Id.Version:\t{0}", pvs));
			sb.AppendLine();
			// EasClientDeviceInformation
			// https://msdn.microsoft.com/zh-cn/library/windows/apps/windows.security.exchangeactivesyncprovisioning.easclientdeviceinformation.aspx
			// https://docs.microsoft.com/en-us/uwp/api/windows.security.exchangeactivesyncprovisioning.easclientdeviceinformation
			sb.AppendLine(LibSharedUtil.GetHeadString("EasClientDeviceInformation", onproject));
			EasClientDeviceInformation eas = new EasClientDeviceInformation();
			sb.AppendLine(string.Format("FriendlyName:\t{0}", eas.FriendlyName));
			sb.AppendLine(string.Format("Id:\t{0}", eas.Id));
			sb.AppendLine(string.Format("OperatingSystem:\t{0}", eas.OperatingSystem));
#if WINDOWS_UWP
			sb.AppendLine(string.Format("SystemFirmwareVersion:\t{0}", eas.SystemFirmwareVersion));
			sb.AppendLine(string.Format("SystemHardwareVersion:\t{0}", eas.SystemHardwareVersion));
#endif
			sb.AppendLine(string.Format("SystemManufacturer:\t{0}", eas.SystemManufacturer));
			sb.AppendLine(string.Format("SystemProductName:\t{0}", eas.SystemProductName));
			sb.AppendLine(string.Format("SystemSku:\t{0}", eas.SystemSku));
			sb.AppendLine();
		}
	}
}
