using System;
namespace GS.Model
{
	/// <summary>
	/// student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class student
	{
		public student()
		{}
		#region Model
		private long _id;
		private string _stuid;
		private string _name;
		private string _sex;
		private string _majorid;
		private string _majorname;
		private string _colleage;
		private string _classtype;
		private string _nation;
		private string _birthday;
		private string _certificatetype;
		private string _certificateid;
		private string _degree;
		private string _placeofwork;
		private string _workphone;
		private string _phone;
		private string _zipcode;
		private string _address;
		private string _email;
		private string _photo;
		private string _password;
		private string _type;
        private string _admissionDate;

        public string admissionDate
        {
            get { return _admissionDate; }
            set { _admissionDate = value; }
        }
		/// <summary>
		/// PK，自增长
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 学生学号
		/// </summary>
		public string stuId
		{
			set{ _stuid=value;}
			get{return _stuid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 专业代码
		/// </summary>
		public string majorId
		{
			set{ _majorid=value;}
			get{return _majorid;}
		}
		/// <summary>
		/// 专业名称
		/// </summary>
		public string majorName
		{
			set{ _majorname=value;}
			get{return _majorname;}
		}
		/// <summary>
		/// 学院
		/// </summary>
		public string colleage
		{
			set{ _colleage=value;}
			get{return _colleage;}
		}
		/// <summary>
		/// 集中办班
		/// </summary>
		public string classType
		{
			set{ _classtype=value;}
			get{return _classtype;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public string birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 证件类型
		/// </summary>
		public string certificateType
		{
			set{ _certificatetype=value;}
			get{return _certificatetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string certificateId
		{
			set{ _certificateid=value;}
			get{return _certificateid;}
		}
		/// <summary>
		/// 学位
		/// </summary>
		public string degree
		{
			set{ _degree=value;}
			get{return _degree;}
		}
		/// <summary>
		/// 工作单位
		/// </summary>
		public string placeOfWork
		{
			set{ _placeofwork=value;}
			get{return _placeofwork;}
		}
		/// <summary>
		/// 工作电话
		/// </summary>
		public string workPhone
		{
			set{ _workphone=value;}
			get{return _workphone;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public string zipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 考生类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

