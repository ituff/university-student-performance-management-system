using System;
namespace GS.Model
{
	/// <summary>
	/// classdetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class classdetail
	{
		public classdetail()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _type;
		private string _teacher;
		private DateTime _starttime;
		private DateTime _endtime;
		private string _period;
		private string _credit;
		private string _location;
		private string _remark;
		private string _classid;
		/// <summary>
		/// 课程编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 课程名
		/// </summary>
        public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 课程类型
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 任课老师
		/// </summary>
		public string teacher
		{
			set{ _teacher=value;}
			get{return _teacher;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime startTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 学时
		/// </summary>
		public string period
		{
			set{ _period=value;}
			get{return _period;}
		}
		/// <summary>
		/// 学分
		/// </summary>
		public string credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// 上课地点
		/// </summary>
		public string location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		#endregion Model

	}
}

