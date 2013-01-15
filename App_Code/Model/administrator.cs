using System;
namespace GS.Model
{
	/// <summary>
	/// administrator:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class administrator
	{
		public administrator()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}



		#endregion Model

	}
}

