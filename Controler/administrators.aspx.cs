using System;
using System.Web.UI;
using GS.Utility;
using System.Web.UI.WebControls;
using GS.BLL;
using Maticsoft.Common;
using GS.Model;
using System.Data;

public partial class classPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
        if (!Page.IsPostBack)
        {
            dataBind();
        }
    }

    protected void dataBind() {
        administratorBLL AdminBLL = new administratorBLL();
        DataSet ds = AdminBLL.GetList("");
        GridView1.DataSource = ds;
        GridView1.DataBind();    
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        dataBind();
    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        dataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        administratorBLL AdminBLL = new administratorBLL();
        MessageBox.Show(this, "确定删除！");
        if (AdminBLL.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()))) MessageBox.Show(this, "删除成功！");
        else MessageBox.Show(this, "删除失败！");
        dataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        administratorBLL AdminBLL = new administratorBLL();
        administrator Admin = new administrator();
        Admin.id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        Admin.userName = Tools.safeUserInput(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
        Admin.passWord = Tools.encrypt(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim());
        Admin.type = Tools.safeUserInput(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim());
        if (AdminBLL.Update(Admin))
        {
            MessageBox.Show(this, "更新成功！");
            GridView1.EditIndex = -1;
            dataBind();
        }
        else
        {
            MessageBox.Show(this, "更新失败！");
            GridView1.EditIndex = -1;
        }
    }
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        string userNameStr=Tools.safeUserInput(TextBox1.Text.ToString().Trim());
        string passWordStr = Tools.safeUserInput(TextBox2.Text.ToString().Trim());
        if(userNameStr.Length<1){
        MessageBox.Show(this,"用户名不能为空！");
            return;
        }
        if(passWordStr.Length<1){
        MessageBox.Show(this,"密码不能为空！");
            return;
        }
        administratorBLL AdminBLL = new administratorBLL();
        if (AdminBLL.Exists(userNameStr)) {
            MessageBox.Show(this, "用户名已存在！");
            return;
        }
        administrator Admin = new administrator();
        Admin.userName = userNameStr;
        Admin.passWord = Tools.encrypt(passWordStr);
        Admin.type = DropDownList1.SelectedItem.Value;
        try
        {
            AdminBLL.Add(Admin);
        }
        catch {
            MessageBox.Show(this, "添加失败！");
        }
        MessageBox.Show(this, "添加成功！");
        dataBind();
    }
}