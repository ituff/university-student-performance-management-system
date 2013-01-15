using System;
namespace GS.Model
{
	/// <summary>
	/// studentloginlog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class studentloginlog
	{
		public studentloginlog()
		{}
		#region Model
		private long _id;
		private string _student;
		private DateTime _time;
		private string _ip;
		/// <summary>
		/// 
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student
		{
			set{ _student=value;}
			get{return _student;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		#endregion Model

	}
}

