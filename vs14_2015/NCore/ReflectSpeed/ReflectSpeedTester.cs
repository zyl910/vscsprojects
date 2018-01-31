using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReflectSpeed {
	/// <summary>
	/// 反射速度测试者.
	/// </summary>
	public class ReflectSpeedTester {
		/// <summary>
		/// 最大次数.
		/// </summary>
		//public const int MaxCount = 1000000;
		public const int MaxCount = 1000;

		/// <summary>
		/// 重复显示次数.
		/// </summary>
		public const int MaxShow = 2;

		/// <summary>
		/// 时间查的格式.
		/// </summary>
		public const string TimeSpanFormat = "0.000000";

		/// <summary>
		/// 运行测试.
		/// </summary>
		/// <param name="sb">字符串输出缓冲区.</param>
		public void Run(StringBuilder sb) {
			for(int i=0; i<MaxShow; ++i) {
				try {
					RunEnvironment(sb);
					RunTuple(sb);
				} catch (Exception ex) {
					sb.AppendLine(ex.ToString());
				}
			}
		}

		/// <summary>
		/// 取得属性信息对象.
		/// </summary>
		/// <param name="name">属性名.</param>
		/// <param name="obj">对象.</param>
		/// <param name="objtype">对象类型. 若 obj 为 null，且 objtype 有值，则表示是静态属性.</param>
		/// <returns>返回属性对象.</returns>
		private PropertyInfo GetPropertyInfo(string name, object obj, Type objtype) {
			if (null == obj && null == objtype) throw new ArgumentNullException("objtype", "obj and objtype is null!");
			if (null == objtype) objtype = obj.GetType();
#if NET2 || NET3 || NET4 || SILVERLIGHT
			return objtype.GetProperty(name);
#else
			//TypeInfo typeInfo = objtype.GetTypeInfo();
			return objtype.GetRuntimeProperty(name);
#endif
		}

		/// <summary>
		/// 根据 MethodInfo 创建委托.
		/// </summary>
		/// <typeparam name="T">委托类型.</typeparam>
		/// <param name="mi">方法信息.</param>
		/// <param name="target">作为委托目标的对象.</param>
		/// <returns>返回所创建的委托.</returns>
		private T CreateDelegate<T>(MethodInfo mi, object target) {
#if NET2 || NET3 || NET4
			return (T)(object)Delegate.CreateDelegate(typeof(T), mi, obj);
#else
			return (T)(object)mi.CreateDelegate(typeof(T), target);
#endif
		}

		/// <summary>
		/// 利用IL Emit技术, 根据 PropertyInfo , 创建 Func 委托, 具有 casttarget/castresult 参数可控制是否总是做转型.
		/// </summary>
		/// <typeparam name="T">目标对象的类型.</typeparam>
		/// <typeparam name="TResult">返回值的类型.</typeparam>
		/// <param name="pi">属性信息.</param>
		/// <param name="casttarget">是否对目标对象进行转型. 即转为 pi.DeclaringType .</param>
		/// <param name="castresult">是否对返回值进行转型. 即转为 TResult. </param>
		/// <returns>返回所创建的 Func 委托.</returns>
		private static Func<T, TResult> CreateGetFunctionEmit<T, TResult>(PropertyInfo pi, bool casttarget = false, bool castresult = false) {
			MethodInfo getMethod = pi.GetGetMethod();
			if (null== getMethod) throw new InvalidOperationException( string.Format("Cannot find a readable \"{0}\" from the type \"{1}\".", pi.Name, pi.DeclaringType.FullName));
			DynamicMethod method = new DynamicMethod("GetValue", typeof(object), new Type[] { typeof(object) });
			ILGenerator ilGenerator = method.GetILGenerator();
			ilGenerator.DeclareLocal(typeof(TResult));
			ilGenerator.Emit(OpCodes.Ldarg_0);
			ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
			ilGenerator.EmitCall(OpCodes.Call, getMethod, null);
			if (getMethod.ReturnType.IsValueType) {
				ilGenerator.Emit(OpCodes.Box, getMethod.ReturnType);
			}
			ilGenerator.Emit(OpCodes.Stloc_0);
			ilGenerator.Emit(OpCodes.Ldloc_0);
			ilGenerator.Emit(OpCodes.Ret);
			method.DefineParameter(1, ParameterAttributes.In, "value");
			return (Func<T, TResult>)method.CreateDelegate(typeof(Func<T, TResult>));

			//ParameterExpression target = Expression.Parameter(typeof(T), "target");
			//Expression castedTarget = (getMethod.IsStatic) ? null :
			//	(casttarget) ? Expression.Convert(target, pi.DeclaringType) as Expression : target;
			//MemberExpression getProperty = Expression.Property(castedTarget, pi);
			//Expression castPropertyValue = (castresult) ? Expression.Convert(getProperty, typeof(TResult)) as Expression : getProperty;
			//return Expression.Lambda<Func<T, TResult>>(castPropertyValue, target).Compile();
		}

		/// <summary>
		/// 利用IL Emit技术, 根据 PropertyInfo , 创建 Func 委托.
		/// </summary>
		/// <param name="pi"></param>
		/// <returns>返回所创建的 Func 委托.</returns>
		private static Func<object, object> CreateGetFunctionEmit(PropertyInfo pi) {
			return CreateGetFunctionEmit<object, object>(pi, true, true);
		}

		/// <summary>
		/// 利用Expression技术, 根据 PropertyInfo , 创建 Func 委托, 具有 casttarget/castresult 参数可控制是否总是做转型.
		/// </summary>
		/// <typeparam name="T">目标对象的类型.</typeparam>
		/// <typeparam name="TResult">返回值的类型.</typeparam>
		/// <param name="pi">属性信息.</param>
		/// <param name="casttarget">是否对目标对象进行转型. 即转为 pi.DeclaringType .</param>
		/// <param name="castresult">是否对返回值进行转型. 即转为 TResult. </param>
		/// <returns>返回所创建的 Func 委托.</returns>
		private static Func<T, TResult> CreateGetFunctionExpression<T, TResult>(PropertyInfo pi, bool casttarget = false, bool castresult = false) {
			MethodInfo getMethod = pi.GetGetMethod();
			ParameterExpression target = Expression.Parameter(typeof(T), "target");
			Expression castedTarget = (getMethod.IsStatic) ? null :
				(casttarget) ? Expression.Convert(target, pi.DeclaringType) as Expression : target;
			MemberExpression getProperty = Expression.Property(castedTarget, pi);
			Expression castPropertyValue = (castresult) ? Expression.Convert(getProperty, typeof(TResult)) as Expression : getProperty;
			return Expression.Lambda<Func<T, TResult>>(castPropertyValue, target).Compile();
		}

		/// <summary>
		/// 利用Expression技术, 根据 PropertyInfo , 创建 Func 委托.
		/// </summary>
		/// <param name="pi"></param>
		/// <returns>返回所创建的 Func 委托.</returns>
		private static Func<object, object> CreateGetFunctionExpression(PropertyInfo pi) {
			return CreateGetFunctionExpression<object, object>(pi, true, true);
		}

		/// <summary>
		/// 测试 Environment
		/// </summary>
		/// <param name="sb">字符串输出缓冲区.</param>
		public void RunEnvironment(StringBuilder sb) {
			Stopwatch sw = new Stopwatch();
			int tmp = 0;
			int cnt;
			double msOnce;
			PropertyInfo pi = null;
			sb.AppendLine("[Environment.ProcessorCount]");
			// Native.
			sw.Start();
			cnt = 0;
			for (int i=0; i< MaxCount; ++i) {
				tmp ^= Environment.ProcessorCount;
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("Native: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// GetValue.
			try {
				pi = GetPropertyInfo("ProcessorCount", null, typeof(Environment));
			}catch(Exception ex) {
				sb.AppendLine(ex.ToString());
				return;
			}
			if (null== pi) {
				sb.AppendLine("Can't get ProcessorCount PropertyInfo");
				return;
			}
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				pi.GetValue(null, null);
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("GetValue: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// GetMethod.
			Func<int> f = null;
			try {
				MethodInfo mi = pi.GetGetMethod();
				f = CreateDelegate<Func<int> >(mi, null);
			} catch (Exception ex) {
				sb.AppendLine(ex.ToString());
				return;
			}
			if (null == f) {
				sb.AppendLine("Can't get ProcessorCount Delegate");
				return;
			}
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				tmp ^= f();
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("DelegateCall: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// done.
			sb.AppendLine();
		}

		/// <summary>
		/// 测试 Tuple
		/// </summary>
		/// <param name="sb">字符串输出缓冲区.</param>
		public void RunTuple(StringBuilder sb) {
			Tuple<int> a = new Tuple<int>(1);
			Stopwatch sw = new Stopwatch();
			int tmp = 0;
			int cnt;
			double msOnce;
			PropertyInfo pi = null;
			sb.AppendLine("[Tuple]");
			// Native.
			sw.Start();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				tmp ^= a.Item1;
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("Native: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// GetValue.
			try {
				pi = GetPropertyInfo("Item1", a, null);
			} catch (Exception ex) {
				sb.AppendLine(ex.ToString());
				return;
			}
			if (null == pi) {
				sb.AppendLine("Can't get Item1 PropertyInfo");
				return;
			}
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				pi.GetValue(a, null);
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("GetValue: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// GetMethod.
			MethodInfo mi = null;
			Func<int> f = null;
			try {
				mi = pi.GetGetMethod();
				f = CreateDelegate<Func<int>>(mi, a);
			} catch (Exception ex) {
				sb.AppendLine(ex.ToString());
				return;
			}
			if (null == f) {
				sb.AppendLine("Can't get Item1 Delegate");
				return;
			}
			// MethodInfo
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				mi.Invoke(a, null);
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("MethodInfo: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// DelegateInvoke
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				tmp ^= f.Invoke();
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("DelegateInvoke: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// DelegateCall
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				tmp ^= f();
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("DelegateCall: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// CreateGetFunctionEmit
			//Func<Tuple<int>, int> f2 = CreateGetFunctionEmit<Tuple<int>, int>(pi);
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				// CreateGetFunctionEmit 构造速度太慢. 大约 0.14 秒才能构造一个, 比普通反射约慢了500倍.
				Func<object, object> f2 = CreateGetFunctionEmit(pi);
				object t = f2(a);
				//tmp ^= f2(a);
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("CreateGetFunctionEmit: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// CreateGetFunctionExpression
			Func<Tuple<int>, int> f3 = CreateGetFunctionExpression<Tuple<int>, int>(pi);
			sw.Restart();
			cnt = 0;
			for (int i = 0; i < MaxCount; ++i) {
				tmp ^= f3(a);
				++cnt;
			}
			sw.Stop();
			Debug.WriteLine(tmp);
			if (cnt <= 0) cnt = 1;
			msOnce = (double)sw.ElapsedMilliseconds / cnt;
			sb.AppendLine(String.Format("CreateGetFunctionExpression: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// CreateGetFunctionExpression 构造速度太慢. 大约 0.14 秒才能构造一个, 比普通反射约慢了500倍.
			//// CreateGetFunctionExpression_create
			//sw.Restart();
			//cnt = 0;
			//for (int i = 0; i < MaxCount; ++i) {
			//	Func<Tuple<int>, int> ft = CreateGetFunctionExpression<Tuple<int>, int>(pi);
			//	tmp ^= ft(a);
			//	++cnt;
			//}
			//sw.Stop();
			//Debug.WriteLine(tmp);
			//if (cnt <= 0) cnt = 1;
			//msOnce = (double)sw.ElapsedMilliseconds / cnt;
			//sb.AppendLine(String.Format("CreateGetFunctionExpression_create: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// done.
			sb.AppendLine();
		}

#if SILVERLIGHT
		private class Stopwatch {
			private int m_StartTick = 0;
			private int m_ElapsedTick = 0;

			public int ElapsedMilliseconds {
				get {
					return m_ElapsedTick - m_StartTick;
				}
			}

			internal void Restart() {
				m_StartTick = Environment.TickCount;
				m_ElapsedTick = m_StartTick;
			}

			internal void Start() {
				Restart();
			}

			internal void Stop() {
				m_ElapsedTick = Environment.TickCount;
			}
		}
#endif

	}
}
