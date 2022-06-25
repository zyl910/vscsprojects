# vscsprojects
Visual Studio C# projects snapshot (VS C# 项目快照)

Use for (用于)——

1. Analyze the difference between the project files generated by each version of VS (分析VS各个版本生成的项目文件的区别).
2. Easy to use Object Browser to analyze the difference between different platforms (便于用对象浏览器分析不同平台的库的区别).

## VS version

### vs08_2005

#### Windows

* `ClassLibrary1`: Allow unsafe. `c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`
* `ConsoleApplication1`: Allow unsafe. `C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`

#### SmartDevice

##### PocketPC

* `DeviceApplication1`: `PocketPC`, Allow unsafe. `C:\Program Files (x86)\Microsoft.NET\SDK\CompactFramework\v2.0\WindowsCE\mscorlib.dll`
* `ClassLibrary1`: `PocketPC`, Allow unsafe. `C:\Program Files (x86)\Microsoft.NET\SDK\CompactFramework\v2.0\WindowsCE\mscorlib.dll`

##### Smartphone

* `DeviceApplication1`: `Smartphone`, Allow unsafe. `C:\VS2005\SmartDevices\SDK\CompactFramework\2.0\v1.0\WindowsCE\mscorlib.dll`
* `ClassLibrary1`: `Smartphone`, Allow unsafe. `C:\VS2005\SmartDevices\SDK\CompactFramework\2.0\v1.0\WindowsCE\mscorlib.dll`

##### WindowsCE


### vs09_2008

#### Windows

* `ClassLibrary1`: Allow unsafe. `C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll`
* `ConsoleApplication1`: Allow unsafe. `C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll`
* `WindowsFormsApplication1`: Allow unsafe. `C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll`
* `WpfApplication1`: Allow unsafe. `C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll`

### vs10_2010

#### Windows

* `PortableClassLibrary1`: Profile1, .NET Framework 4, Silverlight 4, Windows Phone 7, Windows Store Apps, Xbox 360. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile1\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile5, .NET Framework 4, Windows Store Apps. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile5\mscorlib.dll`
* `ClassLibrary1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll`
* `ConsoleApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `WindowsFormsApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `WpfApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `WpfPointWhere`: Wpf point where (Wpf坐标转换).
* `TestClickOnce`: Test ClickOnce (测试ClickOnce部署).

#### Silverlight

* `SilverlightApplication1`: `SILVERLIGHT`. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\mscorlib.dll`
* `SilverlightClassLibrary1`: `SILVERLIGHT`. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\mscorlib.dll`


#### Xna4.0

* `WindowsGame1`: `WINDOWS`. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.dll`
* `WindowsGameLibrary1`: `WINDOWS`. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `Xbox360Game1`: `XBOX;XBOX360`. Allow unsafe. `C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\References\Xbox360\mscorlib.dll`
* `Xbox360GameLibrary1`: `XBOX;XBOX360`. Allow unsafe. `C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\References\Xbox360\mscorlib.dll`

### vs11_2012

#### Windows

* `PortableClassLibrary1`: Profile344, .NET Framework 4.5, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile344\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`

### vs12_2013

#### Windows

* `PortableClassLibrary1`: Profile344, .NET Framework 4.5, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile344\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile151, .NET Framework 4.5.1, Windows 8.1, Windows Phone 8.1, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.6\Profile\Profile151\mscorlib.dll`

### vs14_2015

.Net Core项目使用xpro后缀名.
csproj等项目文件里，不再逐个的描述文件清单，而是自动引用目录下的所有文件。导致难以添加其他目录的源代码.
出现project.json，用于描述项目配置.

* `LibSharedUtil_2015`: Shared Project

#### Windows

* `PortableClassLibrary1`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin, ASP.NET Core 1.0. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`
* `PortableClassLibrary_unsafe`: v5, .NET Framework 4.6, Windows 10, ASP.NET Core 1.0. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\dotnet\mscorlib.dll`

#### NStd

* `ClassLibrary1`: .NET Standard 1.0 ClassLibrary. Disabled unsafe by 1.0 . `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.1\ref\netstandard1.0\mscorlib.dll`
* `ClassLibrary11`: .NET Standard 1.1 ClassLibrary. Allow unsafe by 1.1+ . `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.1\ref\netstandard1.0\mscorlib.dll`

注：vs14_2015 最高支持 .NET Standard 1.5 ClassLibrary

#### Xamarin

* `App_Xamarin_Pcl`: Xamarin.Forms, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android (4.0.3 ~ 6.0), iOS, Uwp(10240~10586), Windows 8.1, Windows Phone 8.1. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Xamarin_Shared`: Xamarin.Forms, Shared Project, Blank app. Android (4.0.3 ~ 6.0), iOS, Uwp(10240~14393), Windows 8.1, Windows Phone 8.1. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Pcl`: Local, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android (4.0.3 ~ 6.0), iOS, Windows Phone 8.1. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\System.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Shared`: Local, Shared Project, Blank app. Android (4.0.3 ~ 6.0), iOS, Windows Phone 8.1. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `ClassLibrary1`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin, ASP.NET Core 1.0. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile111\mscorlib.dll`

#### NCore

* `ConsoleApp1`: .NETCoreApp 1.0 Console. UI no unsafe, no support Shared Project, no support link file. `C:\Users\dssdw10\.nuget\packages\System.Collections\4.0.11\ref\netstandard1.3\System.Collections.dll`
* `ClassLibrary1`: .NETCoreApp 1.0 ClassLibrary. UI no unsafe, no support Shared Project, no support link file. `C:\Users\dssdw10\.nuget\packages\System.Collections\4.0.11\ref\netstandard1.3\System.Collections.dll`
* `TestNCore`: Test .NETCoreApp Console use .NET Standard Class Library or PCL(Portable Class Library) .
	* `LibNStd10`: .NET Standard 1.0 ClassLibrary. Disabled unsafe by 1.0 . `C:\Program Files\dotnet\shared\Microsoft.NETCore.App\1.0.5\System.Private.CoreLib.ni.dll`
	* `LibPcl259`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin, ASP.NET Core 1.0. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`
	* `LibPcl111`: Profile111, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Xamarin, ASP.NET Core 1.0. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile111\mscorlib.dll`
	* `TestNCore`: .NETCoreApp 1.0 Console. UI no unsafe, no support Shared Project, no support link file. `C:\Users\dssdw10\.nuget\packages\System.Collections\4.0.11\ref\netstandard1.3\System.Collections.dll`
	* `TestConsole`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.dll`
* `ReflectSpeed`: Test Reflect Speed.
	* `ReflectSpeed`: Windows Console .
	* `ReflectSpeedNCore`: .NETCoreApp 1.0 Console.
	* `ReflectSpeedSilverlight`: Disabled unsafe. 

#### Web

* `WebApplication1`: ASP.NET Core Web Application, .NET Core 1.0. UI no unsafe, no support Shared Project, no support link file. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.App\1.0.1`

#### Uwp

* `App1`: Universal Windows Application. Allow unsafe. NETFX_CORE;WINDOWS_UWP;CODE_ANALYSIS. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\netcore50\mscorlib.dll`
* `ClassLibrary1`: Universal Windows ClassLibrary. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\netcore50\mscorlib.dll`
* `WindowsRuntimeComponent1`: Windows Runtime Component. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\netcore50\mscorlib.dll`
* `TestUwp`: Test Universal Windows Application use Windows 8/.NET Standard/Portable Class Library .
	* `TestUwp`: Universal Windows Application. Allow unsafe. NETFX_CORE;WINDOWS_UWP;CODE_ANALYSIS. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\netcore50\mscorlib.dll`
	* `LibWin8`: Profile32, Windows 8.1, Windows Phone 8.1. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.6\Profile\Profile32\mscorlib.dll`
	* `LibOnlyWin8`: Windows 8.1 ClassLibrary. Allow unsafe. NETFX_CORE;WINDOWS_APP. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5.1\mscorlib.dll`

#### Windows 8 common

* `App1`: Windows 8.1 common Application. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5.1\mscorlib.dll`
* `ClassLibrary1`: Profile32, Windows 8.1, Windows Phone 8.1. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.6\Profile\Profile32\mscorlib.dll`
* `ClassLibrary2`: Profile111, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Xamarin, ASP.NET Core 1.0. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile111\mscorlib.dll`
* `WindowsRuntimeComponent1`: Windows Runtime Component, Profile32, Windows 8.1, Windows Phone 8.1. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.6\Profile\Profile32\mscorlib.dll`

#### Windows 8

* `App1`: Windows Phone 8.1 Application. Allow unsafe. NETFX_CORE;WINDOWS_APP. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5.1\mscorlib.dll`
* `ClassLibrary1`: Windows 8.1 ClassLibrary. Allow unsafe. NETFX_CORE;WINDOWS_APP. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5.1\mscorlib.dll`

#### wpa: Windows Phone 8

* `App1`: Windows Phone 8.1 Application. Allow unsafe. NETFX_CORE;WINDOWS_PHONE_APP. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\WindowsPhoneApp\v8.1\mscorlib.dll`
* `ClassLibrary1`: Windows Phone 8.1 ClassLibrary. Allow unsafe. NETFX_CORE;WINDOWS_PHONE_APP. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\WindowsPhoneApp\v8.1\mscorlib.dll`

#### wp: Windows Phone Silverlight 8

* `PhoneApp1`: Windows Phone Silverlight 8.0 Application. Disabled unsafe. SILVERLIGHT;WINDOWS_PHONE. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\WindowsPhone\v8.0\mscorlib.dll`
* `PhoneClassLibrary1`: Windows Phone Silverlight 8.0 ClassLibrary. Disabled unsafe. SILVERLIGHT;WINDOWS_PHONE. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\WindowsPhone\v8.0\mscorlib.dll`
* `TestWpa`: Test Windows Phone Silverlight 8.0 Application use .NET Standard Class Library or PCL(Portable Class Library) .
	* `TestWpa`: Windows Phone Silverlight 8.0 Application. Disabled unsafe. SILVERLIGHT;WINDOWS_PHONE. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\WindowsPhone\v8.0\mscorlib.dll`

#### Silverlight

* `SilverlightApplication1`: Silverlight 5. Disabled unsafe, no support link file . `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v5.0\System.dll`
* `TestSilverlight`: Test Silverlight Application use .NET Standard Class Library or PCL(Portable Class Library) .
	* `TestSilverlight`: Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v5.0\System.dll`

### vs15_2017

.Net Core项目也统一使用csproj后缀名. xpro 已废弃.
project.json已弱化. 绝大多数功能已整合到csproj. 仅UWP等少量项目仍在用 project.json .

* `LibSharedUtil_2017`: Shared Project

#### Windows

* `PortableClassLibrary1`: Profile7, .NET Framework 4.5, Windows 8, ASP.NET Core 1.0, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile7\mscorlib.dll`
* `PortableClassLibrary_unsafe`: v5, .NET Framework 4.6, Windows 10, ASP.NET Core 1.0. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\dotnet\mscorlib.dll`

#### NStd

* `ClassLibrary1`: .NET Standard 1.0 ClassLibrary. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\netstandard.library\1.6.1`
* `ClassLibrary20`: .NET Standard 2.0 ClassLibrary. Allow unsafe. `C:\Users\dwin10\.nuget\packages\netstandard.library\2.0.0\build\netstandard2.0\ref\mscorlib.dll`, `C:\Users\dwin10\.nuget\packages\netstandard.library\2.0.0\build\netstandard2.0\ref\netstandard.dll`

注：vs15_2017 最高支持 .NET Standard 2.0 ClassLibrary

#### .NET Core

* `ConsoleApp1`: .NETCoreApp 1.1 Console. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\system.console\4.3.0\ref\netstandard1.3\System.Console.dll`
* `ConsoleApp20`: .NETCoreApp 2.0 Console. Allow unsafe. `C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.netcore.app\2.0.0\ref\netcoreapp2.0\System.Console.dll`
* `ClassLibrary1`: .NETCoreApp 1.1 ClassLibrary. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\system.console\4.3.0\ref\netstandard1.3\System.Console.dll`
* `ClassLibrary20`: .NETCoreApp 2.0 ClassLibrary. Allow unsafe. `C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.netcore.app\2.0.0\ref\netcoreapp2.0\System.Console.dll`, `C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.netcore.app\2.0.0\ref\netcoreapp2.0\netstandard.dll`

#### Web

* `ConsoleApp1`: ASP.NET Core Web Application, .NET Core 1.1. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\microsoft.netcore.app\1.1.2`
* `WebMvc20`: ASP.NET Core Web Application, Web Application(Model-View-Controller), .NET Core 2.0. Allow unsafe.
* `WebRazor20`: ASP.NET Core Web Application, Web Application (Razor), .NET Core 2.0. Allow unsafe.
* `WebReact20`: ASP.NET Core Web Application, React.js, .NET Core 2.0. Allow unsafe.
* `WebApi20`: ASP.NET Core Web Application, Web API, .NET Core 2.0. Allow unsafe.
* `WebApi20Windows`: ASP.NET Core Web Application, Web API, Windows Authentication, .NET Core 2.0. Allow unsafe.
* `WebMvc20Windows`: ASP.NET Core Web Application, Web Application(Model-View-Controller), Windows Authentication, .NET Core 2.0. Allow unsafe.


#### Xamarin

* `App_Xamarin_Shared`: Xamarin.Forms, Shared Project, Blank app. Android, iOS, Uwp. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Xamarin_Pcl`: Xamarin.Forms, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android, iOS, Uwp. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Shared`: Local, Shared Project, Blank app. Android, iOS, Uwp. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Pcl`: Local, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android, iOS, Uwp. Disabled unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\System.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `ClassLibrary1`: Profile111, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Xamarin, ASP.NET Core 1.0. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile111\mscorlib.dll`

#### Android

* `App1`: Android App. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`
* `ClassLibrary1`: Android ClassLibrary. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`
* `BindingLibrary1`: Android BindingLibrary. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\System.Core.dll`

#### iOS

* `App1`: iOS App. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.Core.dll`
* `ClassLibrary1`: iOS ClassLibrary. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`
* `NativeLibrary1`: iOS BindingLibrary. Allow unsafe.

#### tvOS

* `TVApp1`: tvOS App. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.TVOS\v1.0\System.Core.dll`
* `ClassLibrary1`: tvOS ClassLibrary. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.TVOS\v1.0\System.dll`
* `BindingsLibrary1`: tvOS BindingLibrary. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.TVOS\v1.0\System.dll`


### vs16_2019

默认不使用project.json。

#### NStd

* `ClassLibrary20`: .NET Standard 2.0 ClassLibrary. Allow unsafe. `C:\Users\dwin10\.nuget\packages\netstandard.library\2.0.0\build\netstandard2.0\ref\mscorlib.dll`, `C:\Users\dwin10\.nuget\packages\netstandard.library\2.0.0\build\netstandard2.0\ref\netstandard.dll`

注：vs16_2019 最高支持 .NET Standard 2.1 ClassLibrary

#### .NET Core

* `ConsoleApp22`: .NETCoreApp 2.2 Console. Allow unsafe. `C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.netcore.app\2.2.0\ref\netcoreapp2.2\System.Console.dll`
* `ConsoleAppNet5UseStd20`: .NET5 Console, use .NET Standard 2.0 .
* `WinFormsApp31`: WinForms used .NETCore 3.1 .
* `WpfApp50`: WpfApplication used .NETCore 5.0 .
  * `WpfLibrary1`: WPF Class Library, used .NETCore 5.0 .

#### Windows

* `TestReadonly`: Test C# 7.2 readonly struct , `.NET Framework 4.6.1 use .NET Standard 2.0`.

#### WinUI

* `WinUIApp1`: `Blank App,Packaged (WinUl 3 in Desktop)` used `net5.0-windows10.0.19041.0` . 默认编译x86版, Debug目录有 183MB . A project template for creating a Desktop app based on the WindowsuI Library (Winul 3) along with a MSIX package for side-loading ordistribution via the Microsoft Store.

#### Web

* `WebMvc22`: ASP.NET Core Web Application, Web Application(Model-View-Controller), .NET Core 2.2. Allow unsafe.
* `WebRazor22`: ASP.NET Core Web Application, Web Application (Razor), .NET Core 2.2. Allow unsafe.
	* `WebRazor22`: Razor Class Library, Web Application (Razor), .NET Standard 2.0. Allow unsafe.

