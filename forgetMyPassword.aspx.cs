using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using GS.BLL;
using GS.Model;
using GS.Utility;

public partial class forgetMyPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["check"] != null && Session["check"].ToString().Trim().Equals("1")) {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }*/
        if (!IsPostBack) { }
    }
    protected void checkBtn_Click(object sender, EventArgs e)
    {
        string stuIdStr = Tools.safeUserInput(stuIdTB.Text.ToString().Trim());
        string idStr = Tools.safeUserInput(idTB.Text.ToString().Trim());
        if (stuIdStr.Length < 1) {
            MessageBox.Show(this, "学号不能为空！");
            return;
        }
        if (idStr.Length < 1) {
            MessageBox.Show(this, "身份证号不能为空！");
            return;
        }
        studentBLL StudentBLL = new studentBLL();
        student Student = StudentBLL.GetModel(stuIdStr);
        if (Student == null) {
            MessageBox.Show(this, "你输入的学号不存在！");
            return;
        }
        if (Student.certificateId.Equals(idStr))
        {
            Session["check"] = "1";
            ViewState["stuId"] = stuIdStr;
            Panel1.Visible = false;
            Panel2.Visible = true;
            
        }
        else
        {
            Session["check"] = "0";
            MessageBox.Show(this, "您输入的学号与身份证号不匹配！");
            return;
        }
    }
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        if (!Session["check"].ToString().Trim().Equals("1")) {
            Session["check"] = "0";
            Panel1.Visible = true;
            Panel2.Visible = false;
            return;
        }
        string passwordStr1 = Tools.safeUserInput(passWordTB1.Text.ToString().Trim());
        string passwordStr2 = Tools.safeUserInput(passWordTB2.Text.ToString().Trim());
        if (passwordStr1.Equals(passwordStr2))
        {
            studentBLL StudentBLL = new studentBLL();
            student Student = StudentBLL.GetModel(ViewState["stuId"].ToString());
            Student.passWord = Tools.encrypt(passwordStr1);
            try
            {
                StudentBLL.Update(Student);
            }
            catch
            {
                MessageBox.Show(this, "密码修改失败！");
                return;
            }
            MessageBox.ShowAndRedirect(this, "密码修改成功！", "Default.aspx");
        }
        else {
            MessageBox.Show(this, "密码不一致！");
            return;
        }
    }
}