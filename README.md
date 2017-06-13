# vscsprojects
Visual Studio C# projects snapshot (VS C# 项目快照)

Use for (用于)——

1. Analyze the difference between the project files generated by each version of VS (分析VS各个版本生成的项目文件的区别).
2. Easy to use Object Browser to analyze the difference between different platforms (便于用对象浏览器分析不同平台的库的区别).

## VS version

### vs08_2005

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

* `PortableClassLibrary1`: Profile1, .NET Framework 4, Silverlight 4, Windows Phone 7, Windows Store Apps, Xbox 360. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile1\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile5, .NET Framework 4, Windows Store Apps. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile5\mscorlib.dll`
* `ClassLibrary1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll`
* `ConsoleApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `WindowsFormsApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `WpfApplication1`: Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`

#### Silverlight

* `SilverlightApplication1`: `SILVERLIGHT`. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\mscorlib.dll`
* `SilverlightClassLibrary1`: `SILVERLIGHT`. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\mscorlib.dll`


#### Xna4.0

* `WindowsGame1`: `WINDOWS`. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll`, `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.dll`
* `WindowsGameLibrary1`: `WINDOWS`. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\mscorlib.dll`
* `Xbox360Game1`: `XBOX;XBOX360`. Allow unsafe. `C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\References\Xbox360\mscorlib.dll`
* `Xbox360GameLibrary1`: `XBOX;XBOX360`. Allow unsafe. `C:\Program Files (x86)\Microsoft XNA\XNA Game Studio\v4.0\References\Xbox360\mscorlib.dll`

### vs11_2012

#### Windows

* `PortableClassLibrary1`: Profile344, .NET Framework 4.5, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile344\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`

### vs12_2013

#### Windows

* `PortableClassLibrary1`: Profile344, .NET Framework 4.5, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile344\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile151, .NET Framework 4.5.1, Windows 8.1, Windows Phone 8.1, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.6\Profile\Profile151\mscorlib.dll`

### vs14_2015

#### Windows

* `PortableClassLibrary1`: Profile259, .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8, Xamarin, ASP.NET Core 1.0. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`
* `PortableClassLibrary_unsafe`: v5, .NET Framework 4.6, Windows 10, ASP.NET Core 1.0. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\dotnet\mscorlib.dll`

### vs15_2017

#### Windows

* `PortableClassLibrary1`: Profile7, .NET Framework 4.5, Windows 8, ASP.NET Core 1.0, Xamarin. Allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile7\mscorlib.dll`
* `PortableClassLibrary_unsafe`: v5, .NET Framework 4.6, Windows 10, ASP.NET Core 1.0. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\Microsoft.NETCore.Portable.Compatibility\1.0.0\ref\dotnet\mscorlib.dll`

#### .NET Core

* `ConsoleApp1`: .NETCoreApp 1.1. Allow unsafe. `C:\Users\dssdw10\.nuget\packages\system.console\4.3.0\ref\netstandard1.3\System.Console.dll`

#### Xamarin

* `App_Xamarin_Shared`: Xamarin.Forms, Shared Project, Blank app. Android, iOS, Uwp. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Xamarin_Pcl`: Xamarin.Forms, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android, iOS, Uwp. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Shared`: Local, Shared Project, Blank app. Android, iOS, Uwp. Allow unsafe. `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
* `App_Local_Pcl`: Local, Pcl Project(Profile259, portable45-net45+win8+wp8+wpa81), Blank app. Android, iOS, Uwp. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile259\mscorlib.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v1.0\System.dll`, `C:\VS2017\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\Xamarin.iOS\v1.0\System.dll`, `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\facade\Windows.winmd`
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


