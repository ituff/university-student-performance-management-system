using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;
using GS.BLL;
using GS.Model;
using Maticsoft.Common;

public partial class changeInfo : System.Web.UI.Page
{
    public string stuIdStr;
    public string nameStr;
    public string majorNameStr;
    public string idStr;


    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "2");
        if(!IsPostBack)
        initial(Session["UserId"].ToString().Trim());
    }

    protected void initial(string stuId)
    {
        studentBLL StudentBLL = new studentBLL();
        student Student = StudentBLL.GetModel(stuId);
        stuIdStr = Student.stuId;
        nameStr = Student.name;
        majorNameStr = Student.majorName;
        idStr = Student.certificateId;
        emailTB.Text = Student.email;
        cellPhoneTB.Text = Student.phone;
    }


    protected void saveBtn_Click(object sender, EventArgs e)
    {
        string emailStr = Tools.safeUserInput(emailTB.Text.ToString().Trim());
        string cellPhoneStr = Tools.safeUserInput(cellPhoneTB.Text.ToString().Trim());
        studentBLL StudentBLL = new studentBLL();
        student Student = StudentBLL.GetModel(Session["UserId"].ToString().Trim());
        Student.phone = cellPhoneStr;
        Student.email = emailStr;
        try
        {
            if (StudentBLL.Update(Student))
            {
                MessageBox.Show(this, "修改成功！");
                initial(Session["UserId"].ToString().Trim());
            }
            else MessageBox.Show(this, "修改失败！");
        }
        catch
        {
            MessageBox.Show(this, "修改失败！");
        }
    }
    protected void changeBtn_Click(object sender, EventArgs e)
    {
        string passWordStr1 = Tools.safeUserInput(passWordTB1.Text.ToString().Trim());
        string passWordStr2 = Tools.safeUserInput(passWordTB2.Text.ToString().Trim());
        if (passWordStr1.Length > 0 && passWordStr2.Length > 0 && passWordStr1.Equals(passWordStr2))
        {
            studentBLL StudentBLL = new studentBLL();
            student Student = StudentBLL.GetModel(Session["UserId"].ToString().Trim());
            Student.passWord = Tools.encrypt(passWordStr1);
            try
            {
                if (StudentBLL.Update(Student))
                {
                    MessageBox.Show(this, "修改成功！");
                    initial(Session["UserId"].ToString().Trim());
                }
                else MessageBox.Show(this, "修改失败！");
            }
            catch
            {
                MessageBox.Show(this, "修改失败！");
            }
        }
        else {
            MessageBox.Show(this, "密码为空或者密码不同！");
        }
    }
}