using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["status"] = "false";
        Session["UserId"] = "0";
        Session["UserType"] = "0";
        Response.Redirect("Default.aspx");
    }
}