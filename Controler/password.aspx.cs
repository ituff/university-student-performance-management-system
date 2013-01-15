using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;
using GS.Model;
using GS.BLL;
using Maticsoft.Common;

public partial class Controler_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1","2");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        administratorBLL AdminBLL=new administratorBLL();
        administrator Admin = AdminBLL.GetModel(Convert.ToInt32(Session["UserId"]));
        string passwordStr1 = Tools.safeUserInput(passWordTB1.Text.Trim());
        string passwordStr2 = Tools.safeUserInput(passWordTB2.Text.Trim());
        if (passwordStr1.Length < 1 || passwordStr2.Length < 1)
        {
            MessageBox.Show(this, "密码不能为空！");
            return;
        }
        else {
            if (passwordStr1.Equals(passwordStr2))
            {
                Admin.passWord = Tools.encrypt(passwordStr1);
                AdminBLL.Update(Admin);
                MessageBox.Show(this, "修改成功！");
            }
            else {
                MessageBox.Show(this, "两次密码不同！");
                return;
            }
        }

    }
}