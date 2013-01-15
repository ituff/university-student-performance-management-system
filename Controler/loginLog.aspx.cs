using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;

public partial class Controler_loginLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
    }
}