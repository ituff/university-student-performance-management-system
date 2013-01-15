using System;
namespace GS.Model
{
	/// <summary>
	/// classtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class classtype
	{
		public classtype()
		{}
		#region Model
		private int _id;
		private string _name;
		/// <summary>
		/// 课程类型编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 课程类型名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

