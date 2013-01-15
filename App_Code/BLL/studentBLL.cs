using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GS.Model;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using GS.Utility;
using GS.DAL;

namespace GS.BLL
{
    /// <summary>
    /// studentBLL
    /// </summary>
    public partial class studentBLL
    {
        private readonly GS.DAL.studentDAL dal = new GS.DAL.studentDAL();
        public studentBLL()
        { }
        #region  Method


        ///<summary>
        ///用户登录
        ///</summary>
        public string Login(string userName, string passWord)
        {
            studentDAL studentDao = new studentDAL();
            student Student = studentDao.GetModel(userName);
            if (Student == null) return "该用户名不存在";
            if (Student.passWord.Equals(Tools.encrypt(passWord))) return "1";
            else return "密码错误";

        }

        ///<summary>
        ///获取学生姓名
        ///</summary>
        public string GetStuName(string stuId) {
            studentDAL studentDao = new studentDAL();
            student Student = studentDao.GetModel(stuId);
            if (Student != null)
            {
                return Student.name;
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// 批量导入信息
        /// </summary>
        public int Add(Page page, FileUpload fu)
        {
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
                string path = page.Server.MapPath("storage/studentInput/");
                string strpath = fu.PostedFile.FileName.ToString();   //获取Execle文件路径
                string filename = "批量学生信息" + System.DateTime.Now.ToString("yyyyMMddHHmmss").Trim() + ".xls"; //从时间获取文件路径
                fu.PostedFile.SaveAs(path + filename);
                DataSet ds = Tools.ExecleDs(path + filename, filename);
                DataRow[] dr = ds.Tables[0].Select();                        //定义一个DataRow数组
                int rowsnum = ds.Tables[0].Rows.Count;
                if (rowsnum == 0)
                {
                    MessageBox.Show(page, "Excel表为空表,无数据！");//当Excel表为空时,对用户进行提示
                    return 0;
                }
                else
                {
                    for (i = 0; i < dr.Length; i++)
                    {
                        student Student = new student();
                        string stuId = dr[i]["学生学号"].ToString();
                        if (stuId.Length < 1)
                        {
                            MessageBox.Show(page, "第" + (i + 1).ToString() + "学生学号不能为空，请检查数据");
                            return i;
                        }
                        else Student.stuId = stuId;
                        string name = dr[i]["学生姓名"].ToString();
                        if (name.Length < 1)
                        {
                            MessageBox.Show(page, "第" + (i + 1).ToString() + "学生姓名不能为空，请检查数据");
                            return i;
                        }
                        else Student.name = name;
                        Student.nation = Tools.safeUserInput(dr[i]["学生民族"].ToString());
                        Student.birthday = Tools.safeUserInput(dr[i]["出生日期"].ToString());
                        Student.certificateType = Tools.safeUserInput(dr[i]["证件类型"].ToString());
                        Student.certificateId = Tools.safeUserInput(dr[i]["证件号码"].ToString());
                        Student.majorId = Tools.safeUserInput(dr[i]["专业代码"].ToString());
                        Student.majorName = Tools.safeUserInput(dr[i]["专业名称"].ToString());
                        Student.colleage = Tools.safeUserInput(dr[i]["所在学院"].ToString());
                        Student.classType = Tools.safeUserInput(dr[i]["集中办学"].ToString());
                        Student.degree = Tools.safeUserInput(dr[i]["毕业学位"].ToString());
                        Student.placeOfWork =Tools.safeUserInput( dr[i]["工作单位"].ToString());
                        Student.type = Tools.safeUserInput(dr[i]["单位类型"].ToString());
                        Student.workPhone = Tools.safeUserInput(dr[i]["办公电话"].ToString());
                        Student.phone = Tools.safeUserInput(dr[i]["移动电话"].ToString());
                        Student.email = Tools.safeUserInput(dr[i]["电子邮箱"].ToString());
                        Student.address = Tools.safeUserInput(dr[i]["工作地址"].ToString());
                        Student.zipCode = Tools.safeUserInput(dr[i]["邮政编码"].ToString());
                        Student.passWord = Tools.encrypt(Student.certificateId);
                        Student.sex = Tools.safeUserInput(dr[i]["学生性别"].ToString());
                        Student.admissionDate = Tools.safeUserInput(dr[i]["入学年份"].ToString());
                        Add(Student);
                        string oldStuId = Tools.safeUserInput(dr[i]["进修学号"].ToString().Trim());
                        if (oldStuId.Length > 1)
                        {
                            examrecordBLL ExamRecordBLL = new examrecordBLL();
                            studentloginlogBLL StudentLoginLogBLL = new studentloginlogBLL();
                            ExamRecordBLL.repalaceStuId(oldStuId, Student.stuId);
                            StudentLoginLogBLL.repalaceStuId(oldStuId, Student.stuId);
                            Delete(GetModel(oldStuId).id);
                        }
                    }
                    return i+1;
                }
            }
            catch { return 0; }
            finally { }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stuId, long id)
        {
            return dal.Exists(stuId, id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(GS.Model.student model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GS.Model.student model)
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string stuId, long id)
        {

            return dal.Delete(stuId, id);
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
        public GS.Model.student GetModel(long id)
        {

            return dal.GetModel(id);
        }
        public GS.Model.student GetModel(string stuId)
        {

            return dal.GetModel(stuId);
        }

    
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public GS.Model.student GetModelByCache(long id)
        {
            string CacheKey = "studentModel-" + id;
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
            return (GS.Model.student)objModel;
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
        public List<GS.Model.student> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GS.Model.student> DataTableToList(DataTable dt)
        {
            List<GS.Model.student> modelList = new List<GS.Model.student>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GS.Model.student model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GS.Model.student();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = long.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["stuId"] != null && dt.Rows[n]["stuId"].ToString() != "")
                    {
                        model.stuId = dt.Rows[n]["stuId"].ToString();
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.sex = dt.Rows[n]["sex"].ToString();
                    }
                    if (dt.Rows[n]["majorId"] != null && dt.Rows[n]["majorId"].ToString() != "")
                    {
                        model.majorId = dt.Rows[n]["majorId"].ToString();
                    }
                    if (dt.Rows[n]["majorName"] != null && dt.Rows[n]["majorName"].ToString() != "")
                    {
                        model.majorName = dt.Rows[n]["majorName"].ToString();
                    }
                    if (dt.Rows[n]["colleage"] != null && dt.Rows[n]["colleage"].ToString() != "")
                    {
                        model.colleage = dt.Rows[n]["colleage"].ToString();
                    }
                    if (dt.Rows[n]["classType"] != null && dt.Rows[n]["classType"].ToString() != "")
                    {
                        model.classType = dt.Rows[n]["classType"].ToString();
                    }
                    if (dt.Rows[n]["nation"] != null && dt.Rows[n]["nation"].ToString() != "")
                    {
                        model.nation = dt.Rows[n]["nation"].ToString();
                    }
                    if (dt.Rows[n]["birthday"] != null && dt.Rows[n]["birthday"].ToString() != "")
                    {
                        model.birthday = dt.Rows[n]["birthday"].ToString();
                    }
                    if (dt.Rows[n]["certificateType"] != null && dt.Rows[n]["certificateType"].ToString() != "")
                    {
                        model.certificateType = dt.Rows[n]["certificateType"].ToString();
                    }
                    if (dt.Rows[n]["certificateId"] != null && dt.Rows[n]["certificateId"].ToString() != "")
                    {
                        model.certificateId = dt.Rows[n]["certificateId"].ToString();
                    }
                    if (dt.Rows[n]["degree"] != null && dt.Rows[n]["degree"].ToString() != "")
                    {
                        model.degree = dt.Rows[n]["degree"].ToString();
                    }
                    if (dt.Rows[n]["placeOfWork"] != null && dt.Rows[n]["placeOfWork"].ToString() != "")
                    {
                        model.placeOfWork = dt.Rows[n]["placeOfWork"].ToString();
                    }
                    if (dt.Rows[n]["workPhone"] != null && dt.Rows[n]["workPhone"].ToString() != "")
                    {
                        model.workPhone = dt.Rows[n]["workPhone"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["zipCode"] != null && dt.Rows[n]["zipCode"].ToString() != "")
                    {
                        model.zipCode = dt.Rows[n]["zipCode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["photo"] != null && dt.Rows[n]["photo"].ToString() != "")
                    {
                        model.photo = dt.Rows[n]["photo"].ToString();
                    }
                    if (dt.Rows[n]["passWord"] != null && dt.Rows[n]["passWord"].ToString() != "")
                    {
                        model.passWord = dt.Rows[n]["passWord"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
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

        #endregion  Method
    }
}

