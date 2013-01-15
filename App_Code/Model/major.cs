using System;
namespace GS.Model
{
	/// <summary>
	/// major:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class major
	{
		public major()
		{}
		#region Model
		private string _id;
		private string _name;
		/// <summary>
		/// 专业编号
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 专业名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

