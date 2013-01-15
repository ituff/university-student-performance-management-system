using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GS.DBUtility;//Please add references
namespace GS.DAL
{
    /// <summary>
    /// 数据访问类:examrecordDAL
    /// </summary>
    public partial class examrecordDAL
    {
        public examrecordDAL()
        { }
        #region  Method

        /// <summary>
        /// 获取学位课程
        /// </summary>
        public DataSet getXueWeiKe(string StuId) {
            string strSql = "SELECT [classDetail].[name] AS CLASS,[examRecord].[score] AS SCORE,[classDetail].[credit] AS CREDIT,[classDetail].[period] AS PERIOD,[examRecord].[remark] AS REMARK FROM [examRecord] INNER JOIN [classDetail] ON (([examRecord].[class] = [classDetail].[id]) AND ([classDetail].[type] = 1 OR [classDetail].[type] = 2)) WHERE ( [examRecord].[student] ='" + StuId + "')";
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 重新绑定学号
        /// </summary>
        public bool repalaceStuId(string oldStuId, string newStuId)
        {
            StringBuilder sqlSB = new StringBuilder();
            sqlSB.Append("UPDATE [examRecord] SET [student]='");
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
        /// 获取非学位课程
        /// </summary>
        public DataSet getFeiXueWeiKe(string StuId)
        {
            string strSql = "SELECT [classDetail].[name] AS CLASS,[examRecord].[score] AS SCORE,[classDetail].[credit] AS CREDIT,[classDetail].[period] AS PERIOD,[examRecord].[remark] AS REMARK FROM [examRecord] INNER JOIN [classDetail] ON (([examRecord].[class] = [classDetail].[id]) AND ([classDetail].[type] = 3 OR [classDetail].[type] = 4)) WHERE ( [examRecord].[student] ='" + StuId + "')";
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from examRecord");
            strSql.Append(" where id=" + id + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(GS.Model.examrecord model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.student != null)
            {
                strSql1.Append("student,");
                strSql2.Append("'" + model.student + "',");
            }
            if (model.classId != null)
            {
                strSql1.Append("class,");
                strSql2.Append("" + model.classId + ",");
            }
            if (model.score != null)
            {
                strSql1.Append("score,");
                strSql2.Append("" + model.score + ",");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            strSql.Append("insert into examRecord(");
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
        public bool Update(GS.Model.examrecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update examRecord set ");
            if (model.student != null)
            {
                strSql.Append("student='" + model.student + "',");
            }
            if (model.classId != null)
            {
                strSql.Append("class=" + model.classId + ",");
            }
            if (model.score != null)
            {
                strSql.Append("score=" + model.score + ",");
            }
            else
            {
                strSql.Append("score= null ,");
            }
            if (model.remark != null)
            {
                strSql.Append("remark ='" + model.remark + "',");
            }
            else
            {
                strSql.Append("remark = null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from examRecord ");
            strSql.Append(" where id=" + id + "");
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

        public bool Delete(long id,string key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from examRecord ");
            strSql.Append(" where class=" + id + "");
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
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from examRecord ");
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
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from examRecord ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 获得成绩列表
        /// </summary>
        public DataSet Select(int classId)
        {
            string strSql = "SELECT examRecord.id AS ID, student.name AS NAME, examRecord.score AS SCORE,remark  FROM examRecord INNER JOIN student ON examRecord.student = student.stuId WHERE (examRecord.class = " + classId + ") ORDER BY examRecord.id DESC";
            DataSet ds = DbHelperSQL.Query(strSql);
            return ds;
        }
        /// <summary>
        /// 获取总学分
        /// </summary>
        public string SumCredit(string stuId)
        {
            string strSql = "SELECT SUM(CONVERT(int,[classDetail].[credit])) AS 总学分  FROM examRecord INNER JOIN [classDetail] ON [examRecord].[class] = [classDetail].[id] WHERE (student='" + stuId + "') AND (CONVERT(INT,[examRecord].[score])>=60)";
            try
            {
                DataSet ds = DbHelperSQL.Query(strSql);
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                return "0";
            }

        }
        public string SumGXWCredit(string stuId)
        {
            string strSql = "SELECT SUM(CONVERT(int,[classDetail].[credit])) AS 总学分 FROM examRecord INNER JOIN [classDetail] ON [examRecord].[class] = [classDetail].[id] WHERE ([classDetail].[type] = 1 OR [classDetail].[type] = 2) AND (student='" + stuId + "') AND (CONVERT(INT,[examRecord].[score])>=60)";
            try
            {
                DataSet ds = DbHelperSQL.Query(strSql);
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                return "0";
            }

        }
        public string SumGXWAverageCredit(string stuId)
        {
            string strSql = "SELECT(SUM((CONVERT(INT,[examRecord].[score]))* (CONVERT(INT,[classDetail].[period])))/(SUM(CONVERT(INT,[classDetail].[period])))) AS JQC FROM examRecord INNER JOIN [classDetail] ON [examRecord].[class] = [classDetail].[id] WHERE( ([classDetail].[type] = 1 OR [classDetail].[type] = 2) AND (student='" + stuId + "') AND (CONVERT(INT,[examRecord].[score])>=60))";
            try
            {
                DataSet ds = DbHelperSQL.Query(strSql);
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                return "0";
            }

        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GS.Model.examrecord GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,student,class,score,remark  ");
            strSql.Append(" from examRecord ");
            strSql.Append(" where id=" + id + "");
            GS.Model.examrecord model = new GS.Model.examrecord();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["student"] != null && ds.Tables[0].Rows[0]["student"].ToString() != "")
                {
                    model.student = ds.Tables[0].Rows[0]["student"].ToString();
                }
                if (ds.Tables[0].Rows[0]["class"] != null && ds.Tables[0].Rows[0]["class"].ToString() != "")
                {
                    model.classId = ds.Tables[0].Rows[0]["class"].ToString();
                }
                if (ds.Tables[0].Rows[0]["score"] != null && ds.Tables[0].Rows[0]["score"].ToString() != "")
                {
                    model.score = ds.Tables[0].Rows[0]["score"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,student,class,score,remark ");
            strSql.Append(" FROM examRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,student,class,score,remark ");
            strSql.Append(" FROM examRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
    }
}

