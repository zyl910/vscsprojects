# vscsprojects
Visual Studio C# projects snapshot (VS C# 项目快照)

Use for (用于)——

1. Analyze the difference between the project files generated by each version of VS (分析VS各个版本生成的项目文件的区别).
2. Easy to use Object Browser to analyze the difference between different platforms (便于用对象浏览器分析不同平台的库的区别).

## VS version

### vs10_2010

#### Windows

* `PortableClassLibrary1`: Profile1, .NET Framework 4, Silverlight 4, Windows Phone 7, Windows Store Apps, Xbox 360. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile1\mscorlib.dll`
* `PortableClassLibrary_unsafe`: Profile5, .NET Framework 4, Windows Store Apps. Not allow unsafe. `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile5\mscorlib.dll`
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

