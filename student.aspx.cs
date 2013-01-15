using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.Utility;
using GS.BLL;
using GS.Model;

public partial class studentPage : System.Web.UI.Page
{
    public string stuNameStr = "";
    public string sumCreditStr = "";
    public string stuGXWCreditStr = "";
    public string stuGXWAverageCreditStr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "2");
        stuNameStr = getStuName(Session["UserId"].ToString().Trim());
        markUnder60();
        examrecordBLL ExamRecordBLL=new examrecordBLL();
        sumCreditStr=ExamRecordBLL.SumCredit(Session["UserId"].ToString().Trim());
        stuGXWCreditStr = ExamRecordBLL.SumGXWCredit(Session["UserId"].ToString().Trim());
        stuGXWAverageCreditStr = ExamRecordBLL.SumGXWAverageCredit(Session["UserId"].ToString().Trim());
    }

    protected void markUnder60()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (Convert.ToInt32(GridView1.Rows[i].Cells[7].Text.Trim()) < 60)
                GridView1.Rows[i].BackColor = System.Drawing.Color.Red;
        }
    }

    protected string getStuName(string stuId)
    {
        studentBLL StudentBLL = new studentBLL();
        return StudentBLL.GetStuName(stuId);
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("transcript.aspx");
    }
}