using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GS.Model;
using GS.DAL;

namespace GS.BLL
{
	/// <summary>
	/// studentloginlogBLL
	/// </summary>
	public partial class studentloginlogBLL
	{
		private readonly GS.DAL.studentloginlogDAL dal=new GS.DAL.studentloginlogDAL();
		public studentloginlogBLL()
		{}
		#region  Method


        public bool repalaceStuId(string oldStuId, string newStuId)
        {
            studentloginlogDAL StudentLoginLogDAL = new studentloginlogDAL();
            return StudentLoginLogDAL.repalaceStuId(oldStuId, newStuId);
        }

        /// <summary>
        /// 存储记录
        /// </summary>
        public bool login(string IPStr, string stuId) { 
        studentloginlog StudentLoginLog=new studentloginlog();
            StudentLoginLog.student=stuId;
            StudentLoginLog.ip=IPStr;
            StudentLoginLog.time=System.DateTime.Now;
            studentloginlogDAL StudentLoginLogDAL=new studentloginlogDAL();
            try
            {
                StudentLoginLogDAL.Add(StudentLoginLog);
            }
            catch {
                return false;
            }
            return true;
        
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
        /// 
        public bool Exists(long id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GS.Model.studentloginlog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GS.Model.studentloginlog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long id)
		{
			
			return dal.Delete(id);
		}
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GS.Model.studentloginlog GetModel(long id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GS.Model.studentloginlog GetModelByCache(long id)
		{
			
			string CacheKey = "studentloginlogModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GS.Model.studentloginlog)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GS.Model.studentloginlog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GS.Model.studentloginlog> DataTableToList(DataTable dt)
		{
			List<GS.Model.studentloginlog> modelList = new List<GS.Model.studentloginlog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GS.Model.studentloginlog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GS.Model.studentloginlog();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=long.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["student"]!=null && dt.Rows[n]["student"].ToString()!="")
					{
					model.student=dt.Rows[n]["student"].ToString();
					}
					if(dt.Rows[n]["time"]!=null && dt.Rows[n]["time"].ToString()!="")
					{
						model.time=DateTime.Parse(dt.Rows[n]["time"].ToString());
					}
					if(dt.Rows[n]["ip"]!=null && dt.Rows[n]["ip"].ToString()!="")
					{
					model.ip=dt.Rows[n]["ip"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

