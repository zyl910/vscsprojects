using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Linq.Expressions;

//[assembly: System.Security.AllowPartiallyTrustedCallers]

namespace LibShared {
	/// <summary>
	/// VS Class Library test util（VS类库项目测试工具）.
	/// </summary>
	[System.Security.SecuritySafeCritical]
	internal class LibSharedUtil {
		/// <summary>
		/// Define constants(Conditional compilation symbols) field (定义的常量(条件编译符号)字段) .
		/// </summary>
		private static readonly string[] m_DefineConstants = {
#if DEBUG
			"DEBUG",
#endif
#if TRACE
			"TRACE",
#endif
#if RELEASE
			"RELEASE",
#endif
#if CODE_ANALYSIS
			"CODE_ANALYSIS",
#endif
#if UNSAFE
			"UNSAFE",
#endif
#if NETFX_CORE
			"NETFX_CORE",
#endif
#if WINDOWS_UWP
			"WINDOWS_UWP",
#endif
#if NETSTANDARD
			"NETSTANDARD",
#endif
#if NET20
			"NET20",
#endif
#if NET30
			"NET30",
#endif
#if NET35
			"NET35",
#endif
#if NET40
			"NET40",
#endif
#if NET45
			"NET45",
#endif
#if NET451
			"NET451",
#endif
#if NET452
			"NET452",
#endif
#if NET46
			"NET46",
#endif
#if NET461
			"NET461",
#endif
#if NET462
			"NET462",
#endif
#if NET47
			"NET47",
#endif
#if NETCOREAPP1_0
			"NETCOREAPP1_0",
#endif
#if NETCOREAPP1_1
			"NETCOREAPP1_1",
#endif
#if NETCOREAPP2_0
			"NETCOREAPP2_0",
#endif
#if NETSTANDARD1_0
			"NETSTANDARD1_0",
#endif
#if NETSTANDARD1_1
			"NETSTANDARD1_1",
#endif
#if NETSTANDARD1_2
			"NETSTANDARD1_2",
#endif
#if NETSTANDARD1_3
			"NETSTANDARD1_3",
#endif
#if NETSTANDARD1_4
			"NETSTANDARD1_4",
#endif
#if NETSTANDARD1_5
			"NETSTANDARD1_5",
#endif
#if NETSTANDARD1_6
			"NETSTANDARD1_6",
#endif
#if NETSTANDARD2_0
			"NETSTANDARD2_0",
#endif
		};

		/// <summary>
		/// Define constants(Conditional compilation symbols) (定义的常量(条件编译符号)) .
		/// </summary>
		public static string[] DefineConstants {
			get {
				return m_DefineConstants;
			}
		}

		/// <summary>
		/// 将64位整数转为版本字符串.
		/// </summary>
		/// <param name="v">整数值.</param>
		/// <returns>返回版本字符串.</returns>
		public static string VersionFromInt(ulong v) {
			ulong v1 = (v & 0xFFFF000000000000UL) >> 48;
			ulong v2 = (v & 0x0000FFFF00000000UL) >> 32;
			ulong v3 = (v & 0x00000000FFFF0000UL) >> 16;
			ulong v4 = (v & 0x000000000000FFFFUL);
			return string.Format("{0}.{1}.{2}.{3}", v1, v2, v3, v4);
		}

		/// <summary>
		/// 取得端序魔数字节. 即返回 0x01020304 在内存中的首字节.
		/// </summary>
		/// <returns></returns>
		public static byte GetEndianMagicByte() {
			UInt32[] n = { 0x01020304 };
			byte by;    // first byte.
#if (UNSAFE)
			unsafe {
				fixed (UInt32* pn = &n[0]) {
					byte* pb = (byte*)pn;
					by = *pb;
				}
			}
#else
			byte[] byArr = new byte[4];
			Buffer.BlockCopy(n, 0, byArr, 0, byArr.Length);
			by = byArr[0];
#endif
			return by;
		}

		/// <summary>
		/// 判断是不是大端系统.
		/// </summary>
		/// <returns>当为大端系统时, 返回true, 否则返回false.</returns>
		public static bool IsBigEndian() {
			return (1 == GetEndianMagicByte());
		}

		/// <summary>
		/// 判断是不是小端系统.
		/// </summary>
		/// <returns>当为小端系统时, 返回true, 否则返回false.</returns>
		public static bool IsLittleEndian() {
			return (4 == GetEndianMagicByte());
		}

#if (SILVERLIGHT)
		/// <summary>
		/// 根据 PropertyInfo , 创建 Func 委托, 具有 casttarget/castresult 参数可控制是否总是做转型.
		/// </summary>
		/// <typeparam name="T">目标对象的类型.</typeparam>
		/// <typeparam name="TResult">返回值的类型.</typeparam>
		/// <param name="pi">属性信息.</param>
		/// <param name="casttarget">是否对目标对象进行转型. 即转为 pi.DeclaringType .</param>
		/// <param name="castresult">是否对返回值进行转型. 即转为 TResult. </param>
		/// <returns>返回所创建的 Func 委托.</returns>
		public static Func<T, TResult> CreateGetFunction<T, TResult>(PropertyInfo pi, bool casttarget=false, bool castresult = false) {
			MethodInfo getMethod = pi.GetGetMethod();
			ParameterExpression target = Expression.Parameter(typeof(T), "target");
			Expression castedTarget = (getMethod.IsStatic) ? null :
				(casttarget) ? Expression.Convert(target, pi.DeclaringType) as Expression: target;
			MemberExpression getProperty = Expression.Property(castedTarget, pi);
			Expression castPropertyValue = (castresult) ? Expression.Convert(getProperty, typeof(TResult)) as Expression : getProperty;
			return Expression.Lambda<Func<T, TResult>>(castPropertyValue, target).Compile();
		}

		/// <summary>
		/// 根据 PropertyInfo , 创建 Func 委托.
		/// </summary>
		/// <param name="pi"></param>
		/// <returns>返回所创建的 Func 委托.</returns>
		public static Func<object, object> CreateGetFunction(PropertyInfo pi) {
			return CreateGetFunction<object, object>(pi, true, true);
		}
#endif

		/// <summary>
		/// 取得属性值.
		/// </summary>
		/// <param name="typ">类型. 为空时自动根据obj来取类型.</param>
		/// <param name="obj">对象.</param>
		/// <param name="membername">成员名.</param>
		/// <param name="ishad">返回是否存在该属性.</param>
		/// <returns>返回属性值.</returns>
		[System.Security.SecuritySafeCritical]
		public static object GetPropertyValue(Type typ, object obj, String membername, out bool ishad) {
			object rt = null;
			ishad = false;
			if (null == typ && null == obj) return rt;
			if (string.IsNullOrEmpty(membername)) return rt;
			if (null == typ) typ = obj.GetType();
			// Get Property.
#if (SILVERLIGHT)
			PropertyInfo pi = typ.GetProperty(membername);
#else
			PropertyInfo pi = typ.GetRuntimeProperty(membername);
#endif
			if (null == pi) return rt;
			// Get Value.
			if (!pi.CanRead) return rt;
			//object[] attrs = pi.GetCustomAttributes(true);
			//object[] attrs2 = pi.GetGetMethod().GetCustomAttributes(true);
			try {
#if (SILVERLIGHT)
				// -- 研究 SILVERLIGHT 如何反射访问 SecuritySafeCritical . 发现均不行, 可能是为了安全性故意限制了.

				//System.MethodAccessException: 安全透明方法 System.Reflection.Assembly.get_FullName() 无法使用反射访问 LibShared.LibSharedUtil.GetPropertyValue(System.Type, System.Object, System.String, Boolean ByRef)。
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, RuntimeMethodHandleInternal method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, IRuntimeMethodInfo method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture, Boolean skipVisibilityChecks)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
				//   位于 System.RuntimeType.InvokeMember(String name, BindingFlags bindingFlags, Binder binder, Object target, Object[] providedArgs, ParameterModifier[] modifiers, CultureInfo culture, String[] namedParams)
				//   位于 System.Type.InvokeMember(String name, BindingFlags invokeAttr, Binder binder, Object target, Object[] args)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				//typ.InvokeMember(membername, BindingFlags.GetProperty, null, obj, null);

				//System.MethodAccessException: 安全透明方法 System.Reflection.RuntimeAssembly.get_Location() 无法使用反射访问 LibShared.LibSharedUtil.GetPropertyValue(System.Type, System.Object, System.String, Boolean ByRef)。
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, RuntimeMethodHandleInternal method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, IRuntimeMethodInfo method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture, Boolean skipVisibilityChecks)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
				//   位于 System.Reflection.RuntimePropertyInfo.GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture)
				//   位于 System.Reflection.RuntimePropertyInfo.GetValue(Object obj, Object[] index)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				//rt = pi.GetValue(obj, null);

				// System.Reflection.RuntimeAssembly.get_FullName: [SecuritySafeCritical]
				//System.MethodAccessException: 安全透明方法 System.Reflection.RuntimeAssembly.get_FullName() 无法使用反射访问 LibShared.LibSharedUtil.GetPropertyValue(System.Type, System.Object, System.String, Boolean ByRef)。
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, RuntimeMethodHandleInternal method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, IRuntimeMethodInfo method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture, Boolean skipVisibilityChecks)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
				//   位于 System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				// System.Reflection.RuntimeAssembly.get_Location: [SecurityCritical]
				//System.MethodAccessException: 安全透明方法 System.Reflection.RuntimeAssembly.get_Location() 无法使用反射访问 LibShared.LibSharedUtil.GetPropertyValue(System.Type, System.Object, System.String, Boolean ByRef)。
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, RuntimeMethodHandleInternal method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.RuntimeMethodHandle.PerformSecurityCheck(Object obj, IRuntimeMethodInfo method, RuntimeType parent, UInt32 invocationFlags)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture, Boolean skipVisibilityChecks)
				//   位于 System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
				//   位于 System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				//MethodInfo mi = pi.GetGetMethod();
				//rt = mi.Invoke(obj, null);

				// 通过 RuntimeAssembly 访问 SecuritySafeCritical: error
				//System.TypeAccessException: 方法“DynamicClass.lambda_method(System.Runtime.CompilerServices.Closure, System.Object)”访问类型“System.Reflection.RuntimeAssembly”的尝试失败。
				//   位于 lambda_method(Closure, Object)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				// 通过 Assembly 访问 SecuritySafeCritical: ok
				// 通过 Assembly 访问 SecurityCritical: error
				//System.MethodAccessException: 安全透明方法“DynamicClass.lambda_method(System.Runtime.CompilerServices.Closure, System.Object)”访问安全关键方法“System.Reflection.Assembly.get_Location()”的尝试失败。
				//   位于 lambda_method(Closure, Object)
				//   位于 LibShared.LibSharedUtil.GetPropertyValue(Type typ, Object obj, String membername, Boolean & ishad)
				Func< object, object> f = CreateGetFunction(pi);
				rt = f(obj);

#else
				rt = pi.GetValue(obj);
#endif
				ishad = true;
			}catch(Exception ex) {
				Debug.WriteLine(ex.ToString());
			}
			return rt;
		}

		/// <summary>
		/// 输出属性值.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="typ">类型. 为空时自动根据obj来取类型.</param>
		/// <param name="obj">对象.</param>
		/// <param name="membername">成员名.</param>
		/// <param name="formatargidx">属性值的格式化参数索引. 默认为 0.</param>
		/// <param name="format">格式化串. 默认为 membername + ":\t{0}". </param>
		/// <param name="args">参数.</param>
		/// <returns>返回该属性是否成功输出.</returns>
		public static bool AppendProperty(StringBuilder sb, Type typ, object obj, String membername, int formatargidx = 0, string format=null, params object[] args) {
			bool rt = false;
			if (null == sb) return rt;
			bool ishad = false;
			object v = GetPropertyValue(typ, obj, membername, out ishad);
			if (!ishad) return rt;
			object[] args2 = args;
			if (null== format) {
				format = membername + ":\t{0}";
				args2 = new object[] { v };
			} else {
				if (null == args) {
					args2 = new object[] { };
				} else {
					if (formatargidx >= args.Length) {
						args2 = new object[formatargidx + 1];
						Array.Copy(args, args2, args.Length);
					}
					args2[formatargidx] = v;
				}
			}
			string str = string.Format(format, args2);
			sb.AppendLine(str);
			return rt;
		}

		/// <summary>
		/// Output head info (输出头信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputHead(StringBuilder sb, string onproject) {
			sb.AppendLine(onproject);
			sb.AppendLine();
			// OutputCommon
			OutputCommon(sb, onproject);
		}

		/// <summary>
		/// Output common info (输出公用信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputCommon(StringBuilder sb, string onproject) {
			// Environment
			OutputEnvironment(sb, onproject);
			// DefineConstants.
			OutputDefineConstants(sb, onproject);
		}

		/// <summary>
		/// Get head string (取得标题字符串).
		/// </summary>
		/// <param name="headname">Head name (标题名)</param>
		/// <param name="onproject">On project (所处项目)</param>
		/// <param name="remark">Remark (备注)</param>
		/// <returns></returns>
		public static string GetHeadString(string headname, string onproject, string remark = null) {
			String rt = string.Format("[{0}]", headname);
			if (!string.IsNullOrEmpty(onproject) || !string.IsNullOrEmpty(remark))
				rt += "\t# " + remark;
			if (!string.IsNullOrEmpty(onproject))
				rt += " on " + onproject;
			return rt;
		}

		/// <summary>
		/// Output Environment (输出环境信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		[System.Security.SecuritySafeCritical]
		public static void OutputEnvironment(StringBuilder sb, string onproject) {
			sb.AppendLine(GetHeadString("Environment", onproject));
			//sb.AppendLine(string.Format("Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
			//sb.AppendLine(string.Format("Is64BitProcess:\t{0}", Environment.Is64BitProcess));
			//sb.AppendLine(string.Format("OSVersion:\t{0}", Environment.OSVersion));
			//sb.AppendLine(string.Format("ProcessorCount:\t{0}", Environment.ProcessorCount));
			//sb.AppendLine(string.Format("Version:\t{0}", Environment.Version));
			Type typ = typeof(Environment);
			AppendProperty(sb, typ, null, "Is64BitOperatingSystem");
			AppendProperty(sb, typ, null, "Is64BitProcess");
			AppendProperty(sb, typ, null, "OSVersion");
			AppendProperty(sb, typ, null, "ProcessorCount");
			AppendProperty(sb, typ, null, "Version");
			sb.AppendLine(string.Format("AssemblyQualifiedName:\t{0}", typeof(Environment).AssemblyQualifiedName));
			// typeof(Environment).Assembly .
			sb.AppendLine("[Environment.Assembly]");
#if (NET20 || NET30 || NET35 || NET40 || SILVERLIGHT)
			Assembly assembly = typeof(Environment).Assembly;
#else
			Assembly assembly = typeof(Environment).GetTypeInfo().Assembly;
#endif
			typ = typeof(Assembly);
#if (SILVERLIGHT || WINDOWS_PHONE)
			// System.Reflection.RuntimeAssembly.get_FullName: [SecuritySafeCritical]
			// System.MethodAccessException: Attempt by method 'LibShared.LibSharedUtil.GetPropertyValue(System.Type, System.Object, System.String, Boolean ByRef)' to access method 'System.Reflection.RuntimeAssembly.get_FullName()' failed.
			//   at LibShared.LibSharedUtil.GetPropertyValue
			sb.AppendLine(string.Format("#FullName:\t{0}", assembly.FullName));
			//sb.AppendLine(string.Format("#ImageRuntimeVersion:\t{0}", assembly.ImageRuntimeVersion));

			// System.Reflection.RuntimeAssembly.get_Location: [SecurityCritical]
			// System.MethodAccessException: Attempt by method 'LibShared.LibSharedUtil.OutputEnvironment(System.Text.StringBuilder, System.String)' to access method 'System.Reflection.RuntimeAssembly.get_Location()' failed.
			//sb.AppendLine(string.Format("#Location:\t{0}", assembly.Location));
#else
#endif
			AppendProperty(sb, typ, assembly, "FullName");
			AppendProperty(sb, typ, assembly, "ImageRuntimeVersion");
			AppendProperty(sb, typ, assembly, "Location");
			sb.AppendLine(string.Format("#IsBigEndian:\t{0}", IsBigEndian()));
			sb.AppendLine(string.Format("#IsLittleEndian:\t{0}", IsLittleEndian()));
			sb.AppendLine();
		}

		/// <summary>
		/// Output define constants(Conditional compilation symbols) (输出定义常量(条件编译符号)).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputDefineConstants(StringBuilder sb, string onproject) {
			//string str = "[DefineConstants]\t# Conditional compilation symbols";
			//if (!string.IsNullOrEmpty(onproject)) str += " on " + onproject;
			//sb.AppendLine(str);
			sb.AppendLine(GetHeadString("DefineConstants", onproject, "Conditional compilation symbols."));
			foreach (string s in DefineConstants) {
				sb.AppendLine(s);
			}
			sb.AppendLine();
		}

	}
}
