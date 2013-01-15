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
    /// examrecordBLL
    /// </summary>
    public partial class examrecordBLL
    {
        private readonly GS.DAL.examrecordDAL dal = new GS.DAL.examrecordDAL();
        public examrecordBLL()
        { }
        #region  Method

        /// <summary>
        /// 重新绑定学号
        /// </summary>
        public bool repalaceStuId(string oldStuId, string newStuId)
        { 
            examrecordDAL ExamRecordDAL=new examrecordDAL();
            return ExamRecordDAL.repalaceStuId(oldStuId, newStuId);
        }

        /// <summary>
        /// 获取学位课程
        /// </summary>
        public DataSet getXueWeiKe(string StuId)
        {
            examrecordDAL ExamRecordDAL = new examrecordDAL();
            return ExamRecordDAL.getXueWeiKe(StuId);
        }

        /// <summary>
        /// 获取非学位课程
        /// </summary>
        public DataSet getFeiXueWeiKe(string StuId)
        {
            examrecordDAL ExamRecordDAL = new examrecordDAL();
            return ExamRecordDAL.getFeiXueWeiKe(StuId);
        }


        /// <summary>
        /// 获取总学分
        /// </summary>
        public string SumCredit(string stuId) { 
            examrecordDAL ExamRecordDAL=new examrecordDAL();
            return ExamRecordDAL.SumCredit(stuId);
        }
        public string SumGXWCredit(string stuId)
        { 
            examrecordDAL ExamRecordDAL=new examrecordDAL();
            return ExamRecordDAL.SumGXWCredit(stuId);
        }
        public string SumGXWAverageCredit
     (string stuId)
        { 
            examrecordDAL ExamRecordDAL=new examrecordDAL();
            return ExamRecordDAL.SumGXWAverageCredit
      (stuId);
        }
        

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(GS.Model.examrecord model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 添加EXCEL信息
        /// </summary>
        public int Add(Page page, FileUpload fu, int classId)
        {

            examrecordDAL ExamRecordDAL = new examrecordDAL();
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
                string path = page.Server.MapPath("storage/scoreInput/");
                string strpath = fu.PostedFile.FileName.ToString();   //获取Execle文件路径
                string filename = "批量成绩信息" + System.DateTime.Now.ToString("yyyyMMddHHmmss").Trim() + ".xls"; //从时间获取文件路径
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
                        if (isInClass(dr[i]["任课教师"].ToString(), dr[i]["课程名称"].ToString(), classId))
                        {
                            examrecord ExamRecord = new examrecord();
                            string stuId = dr[i]["学生学号"].ToString();
                            if (stuId.Length < 1)
                            {
                                MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生学号不能为空，请检查数据");
                                return i;
                            }
                            else
                            {
                                studentBLL StudentBLL = new studentBLL();
                                student Student = null;
                                try
                                {
                                    Student = StudentBLL.GetModelList("stuId='" + stuId + "'")[0];
                                }
                                catch
                                {
                                    MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生学号不存在，请检查数据");
                                    return i;
                                }
                                if (Student != null)
                                {
                                    if (Student.name.Trim().Equals(dr[i]["学生姓名"].ToString().Trim()))
                                    {
                                        ExamRecord.student = stuId;
                                    }
                                    else
                                    {
                                        MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生学号不存在，请检查数据");
                                        return i;
                                    }
                                }

                            }
                            int score = 0;
                            try
                            {
                                score = Convert.ToInt32(dr[i]["成绩"].ToString());
                            }
                            catch
                            {
                                MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生成绩仅可以为数字且不能为空，请检查数据");
                                return i;
                            }
                            if (score != 0)
                            {
                                ExamRecord.score = score.ToString();
                            }
                            else
                            {
                                MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生成绩仅可以为数字且不能为空，请检查数据");
                                return i;
                            }
                            ExamRecord.classId = classId.ToString();
                            ExamRecordDAL.Add(ExamRecord);
                        }
                        else
                        {
                            MessageBox.Show(page, "导入第" + (i + 1).ToString() + "个成绩信息失败，学生课程名称不存在，请检查数据");
                            return i;
                        }
                    }
                    return i;
                }


            }
            catch { return 0; }
            finally { }
        }

        protected bool isInClass(string teacher, string className, int classId)
        {
            classdetailBLL ClassDetailBLL = new classdetailBLL();
            classdetail ClassDetail = ClassDetailBLL.GetModel(classId);
            if (teacher.Trim().Equals(ClassDetail.teacher.Trim()) && className.Trim().Equals(ClassDetail.name.Trim())) return true;
            else return false;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GS.Model.examrecord model)
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
        public bool Delete(long id,string key)
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
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GS.Model.examrecord GetModel(long id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GS.Model.examrecord GetModelByCache(long id)
        {

            string CacheKey = "examrecordModel-" + id;
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
            return (GS.Model.examrecord)objModel;
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
        public List<GS.Model.examrecord> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GS.Model.examrecord> DataTableToList(DataTable dt)
        {
            List<GS.Model.examrecord> modelList = new List<GS.Model.examrecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GS.Model.examrecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GS.Model.examrecord();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = long.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["student"] != null && dt.Rows[n]["student"].ToString() != "")
                    {
                        model.student = dt.Rows[n]["student"].ToString();
                    }
                    if (dt.Rows[n]["class"] != null && dt.Rows[n]["class"].ToString() != "")
                    {
                        model.classId = dt.Rows[n]["class"].ToString();
                    }
                    if (dt.Rows[n]["score"] != null && dt.Rows[n]["score"].ToString() != "")
                    {
                        model.score = dt.Rows[n]["score"].ToString();
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

        /// <summary>
        /// 获取成绩列表
        /// </summary>
        public DataSet Select(int classId)
        {
            GS.DAL.examrecordDAL ExamRecordDAL = new GS.DAL.examrecordDAL();
            return ExamRecordDAL.Select(classId);
        }

        #endregion  Method
    }
}

