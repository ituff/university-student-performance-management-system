using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.BLL;

public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initial();
    }

    public string userName;

    private void initial()
    {
        int userId = Convert.ToInt32(Session["UserId"]);
        administratorBLL adminbll = new administratorBLL();
        string username = adminbll.GetModel(userId).userName;
        if (username != null) userName = username;
        if (Session["type"].ToString().Equals("1")) {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        if (Session["type"].ToString().Equals("2"))
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }
    }
}
