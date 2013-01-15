using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GS.DBUtility;//Please add references
namespace GS.DAL
{
	/// <summary>
	/// 数据访问类:studentDAL
	/// </summary>
	public partial class studentDAL
	{
		public studentDAL()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string stuId,long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from student");
			strSql.Append(" where stuId='"+stuId+"' and id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GS.Model.student model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.stuId != null)
			{
				strSql1.Append("stuId,");
				strSql2.Append("'"+model.stuId+"',");
			}
			if (model.name != null)
			{
				strSql1.Append("name,");
				strSql2.Append("'"+model.name+"',");
			}
			if (model.sex != null)
			{
				strSql1.Append("sex,");
				strSql2.Append("'"+model.sex+"',");
			}
			if (model.majorId != null)
			{
				strSql1.Append("majorId,");
				strSql2.Append("'"+model.majorId+"',");
			}
			if (model.majorName != null)
			{
				strSql1.Append("majorName,");
				strSql2.Append("'"+model.majorName+"',");
			}
			if (model.colleage != null)
			{
				strSql1.Append("colleage,");
				strSql2.Append("'"+model.colleage+"',");
			}
			if (model.classType != null)
			{
				strSql1.Append("classType,");
				strSql2.Append("'"+model.classType+"',");
			}
			if (model.nation != null)
			{
				strSql1.Append("nation,");
				strSql2.Append("'"+model.nation+"',");
			}
			if (model.birthday != null)
			{
				strSql1.Append("birthday,");
				strSql2.Append("'"+model.birthday+"',");
			}
			if (model.certificateType != null)
			{
				strSql1.Append("certificateType,");
				strSql2.Append("'"+model.certificateType+"',");
			}
			if (model.certificateId != null)
			{
				strSql1.Append("certificateId,");
				strSql2.Append("'"+model.certificateId+"',");
			}
			if (model.degree != null)
			{
				strSql1.Append("degree,");
				strSql2.Append("'"+model.degree+"',");
			}
			if (model.placeOfWork != null)
			{
				strSql1.Append("placeOfWork,");
				strSql2.Append("'"+model.placeOfWork+"',");
			}
			if (model.workPhone != null)
			{
				strSql1.Append("workPhone,");
				strSql2.Append("'"+model.workPhone+"',");
			}
			if (model.phone != null)
			{
				strSql1.Append("phone,");
				strSql2.Append("'"+model.phone+"',");
			}
			if (model.zipCode != null)
			{
				strSql1.Append("zipCode,");
				strSql2.Append("'"+model.zipCode+"',");
			}
			if (model.address != null)
			{
				strSql1.Append("address,");
				strSql2.Append("'"+model.address+"',");
			}
			if (model.email != null)
			{
				strSql1.Append("email,");
				strSql2.Append("'"+model.email+"',");
			}
			if (model.photo != null)
			{
				strSql1.Append("photo,");
				strSql2.Append("'"+model.photo+"',");
			}
			if (model.passWord != null)
			{
				strSql1.Append("passWord,");
				strSql2.Append("'"+model.passWord+"',");
			}
			if (model.type != null)
			{
				strSql1.Append("type,");
				strSql2.Append("'"+model.type+"',");
			}
            if (model. admissionDate != null)
			{
				strSql1.Append(" admissionDate,");
				strSql2.Append("'"+model. admissionDate+"',");
			}
     		strSql.Append("insert into student(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GS.Model.student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update student set ");
			if (model.name != null)
			{
				strSql.Append("name='"+model.name+"',");
			}
			if (model.sex != null)
			{
				strSql.Append("sex='"+model.sex+"',");
			}
			else
			{
				strSql.Append("sex= null ,");
			}
			if (model.majorId != null)
			{
				strSql.Append("majorId='"+model.majorId+"',");
			}
			else
			{
				strSql.Append("majorId= null ,");
			}
			if (model.majorName != null)
			{
				strSql.Append("majorName='"+model.majorName+"',");
			}
			else
			{
				strSql.Append("majorName= null ,");
			}
			if (model.colleage != null)
			{
				strSql.Append("colleage='"+model.colleage+"',");
			}
			else
			{
				strSql.Append("colleage= null ,");
			}
			if (model.classType != null)
			{
				strSql.Append("classType='"+model.classType+"',");
			}
			else
			{
				strSql.Append("classType= null ,");
			}
			if (model.nation != null)
			{
				strSql.Append("nation='"+model.nation+"',");
			}
			else
			{
				strSql.Append("nation= null ,");
			}
			if (model.birthday != null)
			{
				strSql.Append("birthday='"+model.birthday+"',");
			}
			else
			{
				strSql.Append("birthday= null ,");
			}
			if (model.certificateType != null)
			{
				strSql.Append("certificateType='"+model.certificateType+"',");
			}
			else
			{
				strSql.Append("certificateType= null ,");
			}
			if (model.certificateId != null)
			{
				strSql.Append("certificateId='"+model.certificateId+"',");
			}
			else
			{
				strSql.Append("certificateId= null ,");
			}
			if (model.degree != null)
			{
				strSql.Append("degree='"+model.degree+"',");
			}
			else
			{
				strSql.Append("degree= null ,");
			}
			if (model.placeOfWork != null)
			{
				strSql.Append("placeOfWork='"+model.placeOfWork+"',");
			}
			else
			{
				strSql.Append("placeOfWork= null ,");
			}
			if (model.workPhone != null)
			{
				strSql.Append("workPhone='"+model.workPhone+"',");
			}
			else
			{
				strSql.Append("workPhone= null ,");
			}
			if (model.phone != null)
			{
				strSql.Append("phone='"+model.phone+"',");
			}
			else
			{
				strSql.Append("phone= null ,");
			}
			if (model.zipCode != null)
			{
				strSql.Append("zipCode='"+model.zipCode+"',");
			}
			else
			{
				strSql.Append("zipCode= null ,");
			}
			if (model.address != null)
			{
				strSql.Append("address='"+model.address+"',");
			}
			else
			{
				strSql.Append("address= null ,");
			}
			if (model.email != null)
			{
				strSql.Append("email='"+model.email+"',");
			}
			else
			{
				strSql.Append("email= null ,");
			}
			if (model.photo != null)
			{
				strSql.Append("photo='"+model.photo+"',");
			}
			else
			{
				strSql.Append("photo= null ,");
			}
			if (model.passWord != null)
			{
				strSql.Append("passWord='"+model.passWord+"',");
			}
			else
			{
				strSql.Append("passWord= null ,");
			}
			if (model.type != null)
			{
				strSql.Append("type='"+model.type+"',");
			}
			else
			{
				strSql.Append("type= null ,");
			}
            if (model.admissionDate != null)
			{
				strSql.Append("admissionDate='"+model.admissionDate+"',");
			}
			else
			{
                strSql.Append("admissionDate= null ,");
			}
   			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where id="+id+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string stuId,long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where stuId=@stuId and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@stuId", SqlDbType.NVarChar),
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = stuId;
			parameters[1].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GS.Model.student GetModel(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" id,stuId,name,sex,majorId,majorName,colleage,classType,nation,birthday,certificateType,certificateId,degree,placeOfWork,workPhone,phone,zipCode,address,email,photo,passWord,type,admissionDate ");
			strSql.Append(" from student ");
			strSql.Append(" where id="+id+"" );
			GS.Model.student model=new GS.Model.student();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["stuId"]!=null && ds.Tables[0].Rows[0]["stuId"].ToString()!="")
				{
					model.stuId=ds.Tables[0].Rows[0]["stuId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sex"]!=null && ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					model.sex=ds.Tables[0].Rows[0]["sex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["majorId"]!=null && ds.Tables[0].Rows[0]["majorId"].ToString()!="")
				{
					model.majorId=ds.Tables[0].Rows[0]["majorId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["majorName"]!=null && ds.Tables[0].Rows[0]["majorName"].ToString()!="")
				{
					model.majorName=ds.Tables[0].Rows[0]["majorName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["colleage"]!=null && ds.Tables[0].Rows[0]["colleage"].ToString()!="")
				{
					model.colleage=ds.Tables[0].Rows[0]["colleage"].ToString();
				}
				if(ds.Tables[0].Rows[0]["classType"]!=null && ds.Tables[0].Rows[0]["classType"].ToString()!="")
				{
					model.classType=ds.Tables[0].Rows[0]["classType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nation"]!=null && ds.Tables[0].Rows[0]["nation"].ToString()!="")
				{
					model.nation=ds.Tables[0].Rows[0]["nation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["birthday"]!=null && ds.Tables[0].Rows[0]["birthday"].ToString()!="")
				{
					model.birthday=ds.Tables[0].Rows[0]["birthday"].ToString();
				}
				if(ds.Tables[0].Rows[0]["certificateType"]!=null && ds.Tables[0].Rows[0]["certificateType"].ToString()!="")
				{
					model.certificateType=ds.Tables[0].Rows[0]["certificateType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["certificateId"]!=null && ds.Tables[0].Rows[0]["certificateId"].ToString()!="")
				{
					model.certificateId=ds.Tables[0].Rows[0]["certificateId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["degree"]!=null && ds.Tables[0].Rows[0]["degree"].ToString()!="")
				{
					model.degree=ds.Tables[0].Rows[0]["degree"].ToString();
				}
				if(ds.Tables[0].Rows[0]["placeOfWork"]!=null && ds.Tables[0].Rows[0]["placeOfWork"].ToString()!="")
				{
					model.placeOfWork=ds.Tables[0].Rows[0]["placeOfWork"].ToString();
				}
				if(ds.Tables[0].Rows[0]["workPhone"]!=null && ds.Tables[0].Rows[0]["workPhone"].ToString()!="")
				{
					model.workPhone=ds.Tables[0].Rows[0]["workPhone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["phone"]!=null && ds.Tables[0].Rows[0]["phone"].ToString()!="")
				{
					model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zipCode"]!=null && ds.Tables[0].Rows[0]["zipCode"].ToString()!="")
				{
					model.zipCode=ds.Tables[0].Rows[0]["zipCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["address"]!=null && ds.Tables[0].Rows[0]["address"].ToString()!="")
				{
					model.address=ds.Tables[0].Rows[0]["address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["photo"]!=null && ds.Tables[0].Rows[0]["photo"].ToString()!="")
				{
					model.photo=ds.Tables[0].Rows[0]["photo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["passWord"]!=null && ds.Tables[0].Rows[0]["passWord"].ToString()!="")
				{
					model.passWord=ds.Tables[0].Rows[0]["passWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
                if (ds.Tables[0].Rows[0]["admissionDate"] != null && ds.Tables[0].Rows[0]["admissionDate"].ToString() != "")
				{
                    model.admissionDate = ds.Tables[0].Rows[0]["admissionDate"].ToString();
				}
                return model;
			}
			else
			{
				return null;
			}
		}

        public GS.Model.student GetModel(string stuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,stuId,name,sex,majorId,majorName,colleage,classType,nation,birthday,certificateType,certificateId,degree,placeOfWork,workPhone,phone,zipCode,address,email,photo,passWord,type,admissionDate ");
            strSql.Append(" from student ");
            strSql.Append(" where stuId='" + stuId + "'");
            GS.Model.student model = new GS.Model.student();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stuId"] != null && ds.Tables[0].Rows[0]["stuId"].ToString() != "")
                {
                    model.stuId = ds.Tables[0].Rows[0]["stuId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["majorId"] != null && ds.Tables[0].Rows[0]["majorId"].ToString() != "")
                {
                    model.majorId = ds.Tables[0].Rows[0]["majorId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["majorName"] != null && ds.Tables[0].Rows[0]["majorName"].ToString() != "")
                {
                    model.majorName = ds.Tables[0].Rows[0]["majorName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["colleage"] != null && ds.Tables[0].Rows[0]["colleage"].ToString() != "")
                {
                    model.colleage = ds.Tables[0].Rows[0]["colleage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["classType"] != null && ds.Tables[0].Rows[0]["classType"].ToString() != "")
                {
                    model.classType = ds.Tables[0].Rows[0]["classType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["nation"] != null && ds.Tables[0].Rows[0]["nation"].ToString() != "")
                {
                    model.nation = ds.Tables[0].Rows[0]["nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["birthday"] != null && ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["certificateType"] != null && ds.Tables[0].Rows[0]["certificateType"].ToString() != "")
                {
                    model.certificateType = ds.Tables[0].Rows[0]["certificateType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["certificateId"] != null && ds.Tables[0].Rows[0]["certificateId"].ToString() != "")
                {
                    model.certificateId = ds.Tables[0].Rows[0]["certificateId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["degree"] != null && ds.Tables[0].Rows[0]["degree"].ToString() != "")
                {
                    model.degree = ds.Tables[0].Rows[0]["degree"].ToString();
                }
                if (ds.Tables[0].Rows[0]["placeOfWork"] != null && ds.Tables[0].Rows[0]["placeOfWork"].ToString() != "")
                {
                    model.placeOfWork = ds.Tables[0].Rows[0]["placeOfWork"].ToString();
                }
                if (ds.Tables[0].Rows[0]["workPhone"] != null && ds.Tables[0].Rows[0]["workPhone"].ToString() != "")
                {
                    model.workPhone = ds.Tables[0].Rows[0]["workPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["phone"] != null && ds.Tables[0].Rows[0]["phone"].ToString() != "")
                {
                    model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["zipCode"] != null && ds.Tables[0].Rows[0]["zipCode"].ToString() != "")
                {
                    model.zipCode = ds.Tables[0].Rows[0]["zipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["email"] != null && ds.Tables[0].Rows[0]["email"].ToString() != "")
                {
                    model.email = ds.Tables[0].Rows[0]["email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["photo"] != null && ds.Tables[0].Rows[0]["photo"].ToString() != "")
                {
                    model.photo = ds.Tables[0].Rows[0]["photo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passWord"] != null && ds.Tables[0].Rows[0]["passWord"].ToString() != "")
                {
                    model.passWord = ds.Tables[0].Rows[0]["passWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = ds.Tables[0].Rows[0]["type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["admissionDate"] != null && ds.Tables[0].Rows[0]["admissionDate"].ToString() != "")
                {
                    model.admissionDate = ds.Tables[0].Rows[0]["admissionDate"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,stuId,name,sex,majorId,majorName,colleage,classType,nation,birthday,certificateType,certificateId,degree,placeOfWork,workPhone,phone,zipCode,address,email,photo,passWord,type,admissionDate ");
			strSql.Append(" FROM student ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" id,stuId,name,sex,majorId,majorName,colleage,classType,nation,birthday,certificateType,certificateId,degree,placeOfWork,workPhone,phone,zipCode,address,email,photo,passWord,type,admissionDate ");
			strSql.Append(" FROM student ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
	}
}

