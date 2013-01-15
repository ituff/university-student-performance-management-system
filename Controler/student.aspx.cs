using System;
using System.Web.UI;
using GS.Utility;
using GS.BLL;
using GS.Model;
using Maticsoft.Common;
using System.Data;

public partial class studentPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1","2");
        if (Session["type"].ToString().Equals("1"))
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        if (Session["type"].ToString().Equals("2"))
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }
        if (!Page.IsPostBack)
        {
            GridView1.DataBind();
            GridView2.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        studentBLL StudentBLL = new studentBLL();
        student Student = new student();
        DataSet Students = new DataSet();
        int select = Convert.ToInt32(DropDownList1.SelectedValue);
        try
        {
            switch (select)
            {
                case 0: Students = StudentBLL.GetList("[stuId] LIKE '%" + Tools.safeUserInput(TextBox1.Text.Trim()) + "%'");
                    GridView3.DataSource = Students;
                    GridView3.DataBind();
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    break;
                    break;
                case 1: Students = StudentBLL.GetList("[name] LIKE '%" + Tools.safeUserInput(TextBox1.Text.Trim()) + "%'");
                    GridView3.DataSource = Students;
                    GridView3.DataBind();
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    break;
                case 2: Student = StudentBLL.GetModelList("[certificateId] ='" +Tools.safeUserInput( TextBox1.Text.Trim() )+ "'")[0];
                    Response.Redirect("studentView.aspx?id=" + Student.id);
                    break;
                case 3: Student = StudentBLL.GetModelList("[phone] ='" + Tools.safeUserInput(TextBox1.Text.Trim()) + "'")[0];
                    Response.Redirect("studentView.aspx?id=" + Student.id);
                    break;

            }
        }
        catch {
            MessageBox.Show(this, "查询失败！");
        }
            
    }
}