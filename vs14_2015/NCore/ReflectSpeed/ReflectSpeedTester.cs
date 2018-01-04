using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
		public const int MaxCount = 1000000;

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
#if NET2 || NET3 || NET4
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
			// HardCode.
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
			sb.AppendLine(String.Format("HardCode: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
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
				pi.GetValue(null);
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
				MethodInfo mi = pi.GetMethod;
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
			sb.AppendLine(String.Format("GetMethod: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
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
			// HardCode.
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
			sb.AppendLine(String.Format("HardCode: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
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
				pi.GetValue(a);
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
				MethodInfo mi = pi.GetMethod;
				f = CreateDelegate<Func<int>>(mi, a);
			} catch (Exception ex) {
				sb.AppendLine(ex.ToString());
				return;
			}
			if (null == f) {
				sb.AppendLine("Can't get Item1 Delegate");
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
			sb.AppendLine(String.Format("GetMethod: {0:" + TimeSpanFormat + "} . Milliseconds={1}", msOnce, sw.ElapsedMilliseconds));
			// done.
			sb.AppendLine();
		}
	}
}
