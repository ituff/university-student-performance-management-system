using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GS.Model;
using GS.DAL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using GS.Utility;

namespace GS.BLL
{
    /// <summary>
    /// classdetailBLL
    /// </summary>
    public partial class classdetailBLL
    {
        private readonly classdetailDAL dal = new classdetailDAL();
        public classdetailBLL()
        {
        }
        #region  Method

        /// <summary>
        /// 查询指定课程
        /// </summary>
        public DataSet Select(string parm, string type)
        { 
            classdetailDAL ClassDetailDAL=new classdetailDAL();
            try
            {
                if (type == "0")
                {
                    return ClassDetailDAL.GetList("name like '%" + parm + "%'");
                }
                if (type == "1")
                {
                    return ClassDetailDAL.GetList("teacher like '%" + parm + "%'");
                }
                if (type == "2")
                {
                    return ClassDetailDAL.GetList("id= " + parm + "");
                }
            }
            catch
            {
                return null;
            }
            return null;
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GS.Model.classdetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加excel数据库
        /// </summary>
        public int Add(Page page, FileUpload fu)
        {
            classtypeBLL ClassTypeBLL=new classtypeBLL();
            classdetailBLL ClassDetailBLL = new classdetailBLL();
            try
            {
                int i = 0;
                if (fu.HasFile == false)
                {
                    MessageBox.Show(page, "请选择您要上传的Excel文件！");
                    return 0;//当无文件时,返回
                }
                string IsXls = System.IO.Path.GetExtension(fu.FileName).ToString().ToLower();
                if (IsXls != ".xls")
                {
                    MessageBox.Show(page, "只可以上传Excel文件！");
                    return 0;//当选择的不是Excel文件时,返回
                }
                string path = page.Server.MapPath("storage/classInput/");
                string strpath = fu.PostedFile.FileName.ToString();   //获取Execle文件路径
                string filename = "批量课程信息" + System.DateTime.Now.ToString("yyyyMMddHHmmss").Trim() + ".xls"; //从时间获取文件路径
                fu.PostedFile.SaveAs(path + filename);
                DataSet ds = Tools.ExecleDs(path + filename, filename);
                DataRow[] dr = ds.Tables[0].Select();                        //定义一个DataRow数组
                int rowsnum = ds.Tables[0].Rows.Count;
                if (rowsnum == 0)
                {
                    //Response.Write("<script>alert('Excel表为空表,无数据!')</script>");
                    MessageBox.Show(page, "Excel表为空表,无数据！");//当Excel表为空时,对用户进行提示
                    return 0;
                }
                else
                {
                    for (i = 0; i < dr.Length; i++)
                    {
                        classdetail ClassDetail = new classdetail();
                        string name = dr[i]["课程名称"].ToString();
                        if (name.Length < 1)
                        {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "门课程信息失败，课程名称不能为空，请检查数据");
                            return i;
                        }
                        else ClassDetail.name = name;
                        int classType=0;
                        try
                        {
                            classType = Convert.ToInt32(dr[i]["课程类别"]);
                        }
                        catch {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "门课程信息失败，课程类别必须为数字，请检查数据");
                            return i;
                        }
                        if (!(ClassTypeBLL.Exists(classType.ToString())))
                        {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "门课程信息失败，课程类别不存在，请检查数据");
                            return i;
                        }
                        else ClassDetail.type = classType;
                        ClassDetail.teacher = dr[i]["教师姓名"].ToString();
                        try
                        {
                            ClassDetail.startTime = Convert.ToDateTime(dr[i]["开始时间"]);
                        }
                        catch {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "门课程信息失败，开始时间格式不正确，请确保为“yyyy/mm/dd  hh:mm:ss”，请检查数据");
                            return i;
                        }
                        try
                        {
                            ClassDetail.endTime = Convert.ToDateTime(dr[i]["结束时间"]);
                        }
                        catch
                        {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "门课程信息失败，结束时间格式不正确，请确保为“yyyy/mm/dd  hh:mm:ss”，请检查数据");
                            return i;
                        }
                        ClassDetail.period = dr[i]["学时"].ToString();
                        ClassDetail.credit = dr[i]["学分"].ToString();
                        ClassDetail.location = dr[i]["开课地点"].ToString();
                        ClassDetail.remark = dr[i]["备注"].ToString();
                        ClassDetailBLL.Add(ClassDetail);
                    }
                    return i ;
                }
            }
            catch { return 0; }
            finally { }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GS.Model.classdetail model)
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
        public GS.Model.classdetail GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GS.Model.classdetail GetModelByCache(int id)
        {

            string CacheKey = "classdetailModel-" + id;
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
                catch { }
            }
            return (GS.Model.classdetail)objModel;
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
        public List<GS.Model.classdetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GS.Model.classdetail> DataTableToList(DataTable dt)
        {
            List<GS.Model.classdetail> modelList = new List<GS.Model.classdetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GS.Model.classdetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GS.Model.classdetail();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = Convert.ToInt32(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["teacher"] != null && dt.Rows[n]["teacher"].ToString() != "")
                    {
                        model.teacher = dt.Rows[n]["teacher"].ToString();
                    }
                    if (dt.Rows[n]["startTime"] != null && dt.Rows[n]["startTime"].ToString() != "")
                    {
                        model.startTime = DateTime.Parse(dt.Rows[n]["startTime"].ToString());
                    }
                    if (dt.Rows[n]["endTime"] != null && dt.Rows[n]["endTime"].ToString() != "")
                    {
                        model.endTime = DateTime.Parse(dt.Rows[n]["endTime"].ToString());
                    }
                    if (dt.Rows[n]["period"] != null && dt.Rows[n]["period"].ToString() != "")
                    {
                        model.period =dt.Rows[n]["period"].ToString();
                    }
                    if (dt.Rows[n]["credit"] != null && dt.Rows[n]["credit"].ToString() != "")
                    {
                        model.credit = dt.Rows[n]["credit"].ToString();
                    }
                    if (dt.Rows[n]["location"] != null && dt.Rows[n]["location"].ToString() != "")
                    {
                        model.location = dt.Rows[n]["location"].ToString();
                    }
                    if (dt.Rows[n]["remark"] != null && dt.Rows[n]["remark"].ToString() != "")
                    {
                        model.remark = dt.Rows[n]["remark"].ToString();
                    }
                    if (dt.Rows[n]["classId"] != null && dt.Rows[n]["classId"].ToString() != "")
                    {
                        model.classId = dt.Rows[n]["classId"].ToString();
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

