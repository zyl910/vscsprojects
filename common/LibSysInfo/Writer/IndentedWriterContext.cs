﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LibSysInfo.Writer {
	/// <summary>
	/// 带格式输出时的环境.
	/// </summary>
	public class IndentedWriterContext {

		/// <summary>
		/// 成员选项.
		/// </summary>
		private IndentedWriterMemberOptions m_MemberOptions = IndentedWriterMemberOptions.Default;

		/// <summary>
		/// 输出过程表.
		/// </summary>
		private IEnumerable<IndentedWriterObjectProc> m_Procs;

		/// <summary>
		/// 开始枚举成员前.
		/// </summary>
		private IndentedWriterForEachMemberNotify m_ForEachMemberBegin;

		/// <summary>
		/// 枚举成员结束后.
		/// </summary>
		private IndentedWriterForEachMemberNotify m_ForEachMemberEnd;

		/// <summary>
		/// 每层的类型对象信息.
		/// </summary>
		private readonly List<KeyValuePair<Type, object>> m_TypeOwners = new List<KeyValuePair<Type, object>>();

		/// <summary>
		/// 访问过的对象的列表. 仅在有 <see cref="VisitOnce"/> 时才自动填充此列表. 注意需要手动清空此列表.
		/// </summary>
		private readonly List<object> m_VisitList = new List<object>();

		/// <summary>
		/// 是否仅访问一次. 即在NotifyForEachMemberBegin中检查该对象是否在 <see cref="VisitList"/> 列表中, 若已经存在便不再递归.
		/// </summary>
		private bool m_VisitOnce = false;

		/// <summary>
		/// 相同类型的最大数量.
		/// </summary>
		private int m_SameTypeMax = 10;

		/// <summary>
		/// 连续相同类型对象的最大数量.
		/// </summary>
		private int m_SameTypeGroupMax = 1;


		/// <summary>
		/// 用户自定义数据.
		/// </summary>
		private object m_Tag;

		/// <summary>
		/// 成员选项. 输出成员时( <see cref="IndentedWriterUtil.ForEachMember"/> )会将此属性与 options 参数做或运算.
		/// </summary>
		public IndentedWriterMemberOptions MemberOptions {
			get { return m_MemberOptions; }
			set { m_MemberOptions = value; }
		}

		/// <summary>
		/// 输出过程表. 输出成员时( <see cref="IndentedWriterUtil.ForEachMember"/> )会优先在该表格中查找匹配的输出过程.
		/// </summary>
		public IEnumerable<IndentedWriterObjectProc> Procs {
			get { return m_Procs; }
			set { m_Procs = value; }
		}

		/// <summary>
		/// 开始枚举成员前.
		/// </summary>
		public IndentedWriterForEachMemberNotify ForEachMemberBegin {
			get { return m_ForEachMemberBegin; }
			set { m_ForEachMemberBegin = value; }
		}

		/// <summary>
		/// 枚举成员结束后.
		/// </summary>
		public IndentedWriterForEachMemberNotify ForEachMemberEnd {
			get { return m_ForEachMemberEnd; }
			set { m_ForEachMemberEnd = value; }
		}

		/// <summary>
		/// 每层的类型对象信息.
		/// </summary>
		public List<KeyValuePair<Type, object>> TypeOwners {
			get { return m_TypeOwners; }
		}

		/// <summary>
		/// 访问过的对象的列表. 仅在有 <see cref="VisitOnce"/> 时才自动填充此列表. 注意需要手动清空此列表.
		/// </summary>
		public List<object> VisitList {
			get { return m_VisitList; }
		}

		/// <summary>
		/// 是否仅访问一次. 即在NotifyForEachMemberBegin中检查该对象是否在 <see cref="VisitList"/> 列表中, 若已经存在便不再递归.
		/// </summary>
		public bool VisitOnce {
			get { return m_VisitOnce; }
			set { m_VisitOnce = value; }
		}

		/// <summary>
		/// 相同类型的最大数量.
		/// </summary>
		public int SameTypeMax {
			get { return m_SameTypeMax; }
			set { m_SameTypeMax = value; }
		}

		/// <summary>
		/// 连续相同类型对象的最大数量.
		/// </summary>
		public int SameTypeGroupMax {
			get { return m_SameTypeGroupMax; }
			set { m_SameTypeGroupMax = value; }
		}

		/// <summary>
		/// 用户自定义数据.
		/// </summary>
		public object Tag {
			get { return m_Tag; }
			set { m_Tag = value; }
		}

		/// <summary>
		/// 构造 IndentedWriterContext 对象.
		/// </summary>
		public IndentedWriterContext()
			: base() {
		}

		/// <summary>
		/// 通知开始枚举成员.
		/// </summary>
		/// <param name="iw">带缩进输出者.</param>
		/// <param name="owner">欲查询成员的对象.</param>
		/// <param name="tp">类型.</param>
		/// <param name="options">成员选项. </param>
		/// <param name="handle">每个成员的处理过程. </param>
		/// <param name="context">环境对象. </param>
		/// <returns>若在开始枚举成员之前, 返回值表示是否允许枚举. 其他时候忽略.</returns>
		public bool NotifyForEachMemberBegin(IIndentedWriter iw, object owner, Type tp, IndentedWriterMemberOptions options, EventHandler<IndentedWriterMemberEventArgs> handle, IndentedWriterContext context) {
			bool rt = true;
			// check.
			if (null != owner && m_VisitOnce) {
				// 检查访问.
				if (m_VisitList.IndexOf(owner) >= 0) {
					return false;
				}
				m_VisitList.Add(owner);
			}
			if (null != tp && !tp.IsArray) {
				// 连续相同类型对象的最大数量.
				if (m_SameTypeGroupMax > 0 && null != owner) {
					int cnt = 0;
					for (int i = m_TypeOwners.Count - 1; i >= 0; --i) {
						KeyValuePair<Type, object> pr = m_TypeOwners[i];
						if (null == pr.Value) break;
						if (tp.Equals(pr.Key)) {
							++cnt;
							if (cnt >= m_SameTypeGroupMax) {
								return false;
							}
						}
						else {
							break;
						}
					}
				}
				// 相同类型的最大数量.
				if (m_SameTypeMax > 0) {
					int cnt = 0;
					foreach (KeyValuePair<Type, object> pr in m_TypeOwners) {
						if (tp.Equals(pr.Key)) {
							++cnt;
							if (cnt >= m_SameTypeMax) {
								return false;
							}
						}
					}
				}
			}
			// notify.
			m_TypeOwners.Add(new KeyValuePair<Type, object>(tp, owner));
			IndentedWriterForEachMemberNotify p = ForEachMemberBegin;
			if (null != p) rt = p(iw, owner, tp, options, handle, context);
			return rt;
		}

		/// <summary>
		/// 通知枚举成员结束.
		/// </summary>
		/// <param name="iw">带缩进输出者.</param>
		/// <param name="owner">欲查询成员的对象.</param>
		/// <param name="tp">类型.</param>
		/// <param name="options">成员选项. </param>
		/// <param name="handle">每个成员的处理过程. </param>
		/// <param name="context">环境对象. </param>
		/// <returns>若在开始枚举成员之前, 返回值表示是否允许枚举. 其他时候忽略.</returns>
		public bool NotifyForEachMemberEnd(IIndentedWriter iw, object owner, Type tp, IndentedWriterMemberOptions options, EventHandler<IndentedWriterMemberEventArgs> handle, IndentedWriterContext context) {
			bool rt = true;
			IndentedWriterForEachMemberNotify p = ForEachMemberEnd;
			if (null != p) rt = p(iw, owner, tp, options, handle, context);
			if (m_TypeOwners.Count > 0) m_TypeOwners.RemoveAt(m_TypeOwners.Count - 1);
			return rt;
		}

	}
}
