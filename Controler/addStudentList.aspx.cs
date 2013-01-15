using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;
using GS.BLL;
using Maticsoft.Common;

public partial class Controler_addStudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this,"1");
    }
    protected void uploadBtn_Click(object sender, EventArgs e)
    {
        studentBLL StudentBLL = new studentBLL();
        int result=StudentBLL.Add(this, excelFU);
        if (result == 0) MessageBox.Show(this, "上传失败!");
        else MessageBox.ShowAndRedirect(this, "成功导入" + result + "个学生信息","student.aspx");
    }
}