using System;
using System.Web.UI;
using GS.Utility;
using GS.BLL;
using GS.Model;
using System.Data;
using Maticsoft.Common;
using System.Web.UI.WebControls;

public partial class classPage : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1","2");

        if (!Page.IsPostBack)
        {
            GridView1.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        ds = ClassDetailBLL.Select(Tools.safeUserInput(TextBox1.Text.ToString()), DropDownList1.SelectedItem.Value);
        if (ds == null) MessageBox.Show(this, "未找到符合条件的课程！");
        else
        {
            ViewState["source"] = ds;
            GridViewDataBind(GridView2, ds);
            GridView2.Visible = true;
            GridView1.Visible = false;
        }
    }

    protected void GridViewDataBind(GridView gv, DataSet ds)
    {
        gv.DataSource = ds;
        gv.DataBind();
    }
}