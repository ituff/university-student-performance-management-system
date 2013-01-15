using System;
using Maticsoft.Common;
using GS.BLL;
using GS.Model;
using GS.Utility;

public partial class Controller_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string userName = Tools.safeUserInput(username.Text.Trim());
        string passWord = Tools.safeUserInput(password.Text.Trim());
        if (userName.Length < 1) { MessageBox.Show(this, "用户名不能为空"); return; }
        if (passWord.Length < 1) { MessageBox.Show(this, "密码不能为空"); return; }
        administratorBLL adminbll = new administratorBLL();
        string loginMessage = adminbll.Login(userName, passWord);
        if (loginMessage.Equals("1"))
        {
            string stuIdStr = adminbll.GetModel(userName).id.ToString();
            Session["status"] = "true";
            Session["UserId"] = stuIdStr;
            Session["type"] = "1";
            MessageBox.ShowAndRedirect(this, "登录成功!", "student.aspx");
        }
        else
        {
            if (loginMessage.Equals("2"))
            {
                string stuIdStr = adminbll.GetModel(userName).id.ToString();
                Session["status"] = "true";
                Session["UserId"] = stuIdStr;
                Session["type"] = "2";
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