using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GS.DBUtility;//Please add references

namespace GS.DAL
{
	/// <summary>
	/// 数据访问类:classdetailDAL
	/// </summary>
	public partial class classdetailDAL
	{
		public classdetailDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "classDetail"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from classDetail");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GS.Model.classdetail model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.name != null)
			{
				strSql1.Append("name,");
				strSql2.Append("'"+model.name+"',");
			}
			if (model.type != null)
			{
				strSql1.Append("type,");
				strSql2.Append("'"+model.type+"',");
			}
			if (model.teacher != null)
			{
				strSql1.Append("teacher,");
				strSql2.Append("'"+model.teacher+"',");
			}
			if (model.startTime != null)
			{
				strSql1.Append("startTime,");
				strSql2.Append("'"+model.startTime.ToShortDateString()+"',");
			}
			if (model.endTime != null)
			{
				strSql1.Append("endTime,");
                strSql2.Append("'" + model.endTime.ToShortDateString() + "',");
			}
			if (model.period != null)
			{
				strSql1.Append("period,");
				strSql2.Append("'"+model.period+"',");
			}
			if (model.credit != null)
			{
				strSql1.Append("credit,");
				strSql2.Append("'"+model.credit+"',");
			}
			if (model.location != null)
			{
				strSql1.Append("location,");
				strSql2.Append("'"+model.location+"',");
			}
			if (model.remark != null)
			{
				strSql1.Append("remark,");
				strSql2.Append("'"+model.remark+"',");
			}
			if (model.classId != null)
			{
				strSql1.Append("classId,");
				strSql2.Append("'"+model.classId+"',");
			}
			strSql.Append("insert into classDetail(");
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
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GS.Model.classdetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update classDetail set ");
			if (model.name != null)
			{
				strSql.Append("name='"+model.name+"',");
			}
			if (model.type != null)
			{
				strSql.Append("type='"+model.type+"',");
			}
			if (model.teacher != null)
			{
				strSql.Append("teacher='"+model.teacher+"',");
			}
			else
			{
				strSql.Append("teacher= null ,");
			}
			if (model.startTime != null)
			{
				strSql.Append("startTime='"+model.startTime+"',");
			}
			else
			{
				strSql.Append("startTime= null ,");
			}
			if (model.endTime != null)
			{
				strSql.Append("endTime='"+model.endTime+"',");
			}
			else
			{
				strSql.Append("endTime= null ,");
			}
			if (model.period != null)
			{
				strSql.Append("period="+model.period+",");
			}
			else
			{
				strSql.Append("period= null ,");
			}
			if (model.credit != null)
			{
				strSql.Append("credit="+model.credit+",");
			}
			else
			{
				strSql.Append("credit= null ,");
			}
			if (model.location != null)
			{
				strSql.Append("location='"+model.location+"',");
			}
			else
			{
				strSql.Append("location= null ,");
			}
			if (model.remark != null)
			{
				strSql.Append("remark='"+model.remark+"',");
			}
			else
			{
				strSql.Append("remark= null ,");
			}
			if (model.classId != null)
			{
				strSql.Append("classId='"+model.classId+"',");
			}
			else
			{
				strSql.Append("classId= null ,");
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from classDetail ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from classDetail ");
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
		public GS.Model.classdetail GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,name,type,teacher,startTime,endTime,period,credit,location,remark,classId ");
			strSql.Append(" from classDetail ");
			strSql.Append(" where id="+id+"" );
			GS.Model.classdetail model=new GS.Model.classdetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=Convert.ToInt32(ds.Tables[0].Rows[0]["type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["teacher"]!=null && ds.Tables[0].Rows[0]["teacher"].ToString()!="")
				{
					model.teacher=ds.Tables[0].Rows[0]["teacher"].ToString();
				}
				if(ds.Tables[0].Rows[0]["startTime"]!=null && ds.Tables[0].Rows[0]["startTime"].ToString()!="")
				{
					model.startTime=DateTime.Parse(ds.Tables[0].Rows[0]["startTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["endTime"]!=null && ds.Tables[0].Rows[0]["endTime"].ToString()!="")
				{
					model.endTime=DateTime.Parse(ds.Tables[0].Rows[0]["endTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["period"]!=null && ds.Tables[0].Rows[0]["period"].ToString()!="")
				{
					model.period=ds.Tables[0].Rows[0]["period"].ToString();
				}
				if(ds.Tables[0].Rows[0]["credit"]!=null && ds.Tables[0].Rows[0]["credit"].ToString()!="")
				{
					model.credit=ds.Tables[0].Rows[0]["credit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["location"]!=null && ds.Tables[0].Rows[0]["location"].ToString()!="")
				{
					model.location=ds.Tables[0].Rows[0]["location"].ToString();
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null && ds.Tables[0].Rows[0]["remark"].ToString()!="")
				{
					model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["classId"]!=null && ds.Tables[0].Rows[0]["classId"].ToString()!="")
				{
					model.classId=ds.Tables[0].Rows[0]["classId"].ToString();
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
            strSql.Append("select id,name,(SELECT [classType].[name] FROM [classType] WHERE [classType].[id]=[classDetail].[type]) AS TYPE,teacher,startTime,endTime,period,credit,location,remark,classId ");
			strSql.Append(" FROM classDetail ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere );
			}
			return DbHelperSQL.Query(strSql.ToString()+ " ORDER BY id DESC");
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
			strSql.Append(" id,name,type,teacher,startTime,endTime,period,credit,location,remark,classId ");
			strSql.Append(" FROM classDetail ");
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

