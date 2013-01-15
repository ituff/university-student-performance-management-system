using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;
using Maticsoft.Common;
using GS.BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
                 
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string userName = Tools.safeUserInput(stuIdTB.Text.Trim());
        string passWord = Tools.safeUserInput(passwordTB.Text.Trim());
        string yzmStr = yzmTB.Text.Trim();
        if (userName.Length < 1) { MessageBox.Show(this, "用户名不能为空"); return; }
        if (passWord.Length < 1) { MessageBox.Show(this, "密码不能为空"); return; }
        if (yzmStr.Length < 1) { MessageBox.Show(this, "验证码不能为空"); return; }
        if (yzmStr.Equals(Request.Cookies["CheckCode"].Value.ToString()))
        {
            studentBLL StudentBLL = new studentBLL();
            string loginMessage = StudentBLL.Login(userName, passWord);
            if (loginMessage.Equals("1"))
            {
                string stuIdStr = StudentBLL.GetModel(userName).stuId.ToString();
                Session["status"] = "true";
                Session["UserId"] = stuIdStr;
                Session["type"] = "2";
                studentloginlogBLL StudentLoginLogBLL = new studentloginlogBLL();
                StudentLoginLogBLL.login(Request.ServerVariables["REMOTE_ADDR"].ToString(), stuIdStr);
                MessageBox.ShowAndRedirect(this, "登录成功!", "student.aspx");
            }
            else
            {
                Session["status"] = "false";
                Session["UserId"] = "0";
                Session["type"] = "0";
                MessageBox.ShowAndRedirect(this, loginMessage, "logout.aspx");
            }
        }
        else {
            MessageBox.ShowAndRedirect(this, "验证码错误！", "logout.aspx");
            return;
        }
    }

    ///<summary>
    /// 获取用户登陆IP
    /// </summary>
    /// <returns>返回用户IP</returns>
    protected string GetIp()
    {
        string user_IP;
        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
        {
            user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else
        {
            user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        return user_IP;
    }
}