using System;
using System.Web.UI;
using GS.Utility;
using Maticsoft.Common;
using GS.Model;
using GS.BLL;

public partial class classPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
        if (!Page.IsPostBack)
        {
            GridView1.DataBind();
        }
    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        string classTypeStr = Tools.safeUserInput(classTypeTB.Text.Trim().ToString());
        if (classTypeStr.Length < 1)
        {
            MessageBox.Show(this, "课程类别不能为空！");
            return;
        }
        classtype ClassType = new classtype();
        ClassType.name = classTypeStr;
        classtypeBLL ClassTypeBLL = new classtypeBLL();
        try
        {
            ClassTypeBLL.Add(ClassType);
        }
        catch
        {
            MessageBox.Show(this, "添加失败！");
            return;
        }
        finally
        {
        }
        MessageBox.Show(this, "添加成功！");
        GridView1.DataBind();
    }
}