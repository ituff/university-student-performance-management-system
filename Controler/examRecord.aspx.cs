using System;
using System.Web.UI;
using GS.Utility;
using Maticsoft.Common;
using System.Data;
using System.Web.UI.WebControls;
using GS.BLL;
using GS.Model;

public partial class classPage : System.Web.UI.Page
{
    int id = 0;
    DataSet ds = new DataSet();
    public string classNameStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
        }
        catch
        {
            id = 0;
        }
        if (!Page.IsPostBack)
        {
            ds = getClassDetail();
            ViewState["source"] = ds;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds = (DataSet)ViewState["source"];
        }
        if (id != 0)
        {
            classNameStr = getClassName();
            if (isClassIdExisted(id))
                Panel1.Visible = true;
            else Panel1.Visible = false;
            if (!Page.IsPostBack)
            {
                GV2DataBind();
            }
        }
        else Panel1.Visible = false;
    }

    protected bool isClassIdExisted(int classId)
    {
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        return ClassDetailBLL.Exists(classId);
    }

    protected string getClassName()
    {
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        classdetail ClassDetail = ClassDetailBLL.GetModel(id);
        string result;
        if (ClassDetail != null)
        {
            result = ClassDetail.name + " " + ClassDetail.teacher + " " + ClassDetail.startTime.ToShortDateString() + "～" + ClassDetail.endTime.ToShortDateString();
        }
        else
            result = "你选择的课程不存在！";
        return result;

    }

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        ds = ClassDetailBLL.Select(keyWordTB.Text.ToString(), searchTypeDDL.SelectedItem.Value);
        if (ds == null) MessageBox.Show(this, "未找到符合条件的课程！");
        else
        {
            ViewState["source"] = ds;
            GridViewDataBind(GridView1, ds);
        }
    }

    protected DataSet getClassDetail()
    {
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        return ClassDetailBLL.GetList("");
    }

    protected void GridViewDataBind(GridView gv, DataSet ds)
    {
        gv.DataSource = ds;
        gv.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds;//调用绑定的具体方法 
        GridView1.DataBind();
    }

    protected void GV2DataBind()
    {
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        DataSet dSet = ExamRecordBLL.Select(id);
        GridView2.DataSource = dSet;
        GridView2.DataBind();
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GV2DataBind();
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        MessageBox.Show(this, "确定删除！");
        try
        {
            if (ExamRecordBLL.Delete(Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value))) MessageBox.Show(this, "删除成功！");
            else MessageBox.Show(this, "删除失败！");
        }
        catch
        {
            MessageBox.Show(this, "删除失败！");
        }
        GV2DataBind();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        examrecord ExamRecord = new examrecord();
        ExamRecord.id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
        ExamRecord.student = ExamRecordBLL.GetModel(ExamRecord.id).student;
        try
        {
            ExamRecord.score = (Convert.ToInt32(((TextBox)(GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim())).ToString();
            ExamRecord.remark = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        }
        catch
        {
            MessageBox.Show(this, "成绩只能为数字！更新失败！");
            return;
        }
        if (ExamRecordBLL.Update(ExamRecord)) MessageBox.Show(this, "更新成功！");
        else MessageBox.Show(this, "更新失败！");
        GridView2.EditIndex = -1;
        GV2DataBind();
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        GV2DataBind();
    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        examrecord ExamRecord = new examrecord();
        string stuIdStr = Tools.safeUserInput(stuIdTB.Text.ToString().Trim());
        if (stuIdStr.Length < 1)
        {
            MessageBox.Show(this, "学生学号不能为空！");
            return;
        }
        else
        {
            ExamRecord.student = stuIdStr;
        }
        string scoreStr = Tools.safeUserInput(scoreTB.Text.ToString().Trim());
        if (scoreStr.Length < 1)
        {
            MessageBox.Show(this, "学生成绩不能为空！");
            return;
        }
        else
        {
            int scoreInt = -1;
            try
            {
                scoreInt = Convert.ToInt32(scoreStr);
            }
            catch
            {
                MessageBox.Show(this, "学生成绩只能为数字！");
                return;
            }
            if (scoreInt != -1)
                ExamRecord.score = scoreInt.ToString();
            else MessageBox.Show(this, "学生成绩只能为数字！");
        }
        string remarkStr = Tools.safeUserInput(remarkTB.Text.ToString().Trim());
        ExamRecord.remark = remarkStr;
        ExamRecord.classId = id.ToString();
        if (ExamRecordBLL.Add(ExamRecord) != 0)
        {
            MessageBox.Show(this, "添加成功！");
            GV2DataBind();
        }
        else MessageBox.Show(this, "添加失败！");
    }
    protected void uploadBtn_Click(object sender, EventArgs e)
    {
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        int result = ExamRecordBLL.Add(this, excelFU,id);
        if (result == 0) MessageBox.Show(this, "上传失败!");
        else
        {
            MessageBox.Show(this, "成功导入" + result + "条成绩信息");
            GV2DataBind();
        }
    }
}