using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GS.DBUtility;//Please add references
namespace GS.DAL
{
	/// <summary>
	/// 数据访问类:studentloginlogDAL
	/// </summary>
	public partial class studentloginlogDAL
	{
		public studentloginlogDAL()
		{}
		#region  Method

        /// <summary>
        /// 重新绑定学号
        /// </summary>
        public bool repalaceStuId(string oldStuId, string newStuId)
        {
            StringBuilder sqlSB = new StringBuilder();
            sqlSB.Append("UPDATE [studentLoginLog] SET [student]='");
            sqlSB.Append(newStuId);
            sqlSB.Append("' WHERE [student]='");
            sqlSB.Append(oldStuId).Append("'");
            int rowsAffected = DbHelperSQL.ExecuteSql(sqlSB.ToString());
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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from studentLoginLog");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GS.Model.studentloginlog model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.student != null)
			{
				strSql1.Append("student,");
				strSql2.Append("'"+model.student+"',");
			}
			if (model.time != null)
			{
				strSql1.Append("time,");
				strSql2.Append("'"+model.time+"',");
			}
			if (model.ip != null)
			{
				strSql1.Append("ip,");
				strSql2.Append("'"+model.ip+"',");
			}
			strSql.Append("insert into studentLoginLog(");
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
		public bool Update(GS.Model.studentloginlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update studentLoginLog set ");
			if (model.student != null)
			{
				strSql.Append("student='"+model.student+"',");
			}
			if (model.time != null)
			{
				strSql.Append("time='"+model.time+"',");
			}
			if (model.ip != null)
			{
				strSql.Append("ip='"+model.ip+"',");
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
			strSql.Append("delete from studentLoginLog ");
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
		}
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from studentLoginLog ");
            strSql.Append(" where student='" + id + "'");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from studentLoginLog ");
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
		public GS.Model.studentloginlog GetModel(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,student,time,ip ");
			strSql.Append(" from studentLoginLog ");
			strSql.Append(" where id="+id+"" );
			GS.Model.studentloginlog model=new GS.Model.studentloginlog();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["student"]!=null && ds.Tables[0].Rows[0]["student"].ToString()!="")
				{
					model.student=ds.Tables[0].Rows[0]["student"].ToString();
				}
				if(ds.Tables[0].Rows[0]["time"]!=null && ds.Tables[0].Rows[0]["time"].ToString()!="")
				{
					model.time=DateTime.Parse(ds.Tables[0].Rows[0]["time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ip"]!=null && ds.Tables[0].Rows[0]["ip"].ToString()!="")
				{
					model.ip=ds.Tables[0].Rows[0]["ip"].ToString();
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
			strSql.Append("select id,student,time,ip ");
			strSql.Append(" FROM studentLoginLog ");
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
			strSql.Append(" id,student,time,ip ");
			strSql.Append(" FROM studentLoginLog ");
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

