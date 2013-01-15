using System.Collections.Generic;
using GS.DAL;
using GS.Model;
using System.Data;
using GS.Utility;

namespace GS.BLL
{
    /// <summary>
    ///administratorBll 的摘要说明
    /// </summary>
    public partial class administratorBLL
    {
        private readonly administratorDAL dal = new administratorDAL();
        public administratorBLL()
        { }
        #region  Method

        /// <summary>
        /// 登录
        /// </summary>
        public string Login(string userName, string passWord) {
            administratorDAL adminDao = new administratorDAL();
            administrator admin = adminDao.GetModel(userName);
            if (admin == null) return "该用户名不存在";
            if (admin.passWord.Equals(Tools.encrypt(passWord))) return admin.type;
            else return "密码错误";
        
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(administrator model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(administrator model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public administrator GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public administrator GetModel(int id)
        {

            return dal.GetModel(id);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GS.Model.administrator> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GS.Model.administrator> DataTableToList(DataTable dt)
        {
            List<GS.Model.administrator> modelList = new List<GS.Model.administrator>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GS.Model.administrator model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GS.Model.administrator();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["userName"] != null && dt.Rows[n]["userName"].ToString() != "")
                    {
                        model.userName = dt.Rows[n]["userName"].ToString();
                    }
                    if (dt.Rows[n]["passWord"] != null && dt.Rows[n]["passWord"].ToString() != "")
                    {
                        model.passWord = dt.Rows[n]["passWord"].ToString();
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

