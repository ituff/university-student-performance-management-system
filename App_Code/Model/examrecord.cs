using System;
namespace GS.Model
{
	/// <summary>
	/// examrecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class examrecord
	{
		public examrecord()
		{}
		#region Model
		private long _id;
		private string _student;
		private string _classId;
		private string _score;
        private string _remark;

        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
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
		public string classId
		{
			set{ _classId=value;}
			get{return _classId;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

