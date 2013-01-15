using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GS.BLL;
using GS.Model;
using System.Text;
using System.Data;
using GS.Utility;

public partial class transcript : System.Web.UI.Page
{
    public string stuIdStr;
    public string nameStr;
    public string sexStr;
    public string colleageStr;
    public string majorStr;
    public string schoolTimeStr;

    public string xueWeiKeStr;
    public string feiXueWeiKeStr;

    public string zongXueFenStr;
    public string xueWeiKeZongXueFenStr;
    public string xueWeikeJiaQuanPingJunStr;

    private string stuId;

    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "2");
        stuId = Session["UserId"].ToString().Trim();
        InitializePage();
        InitializeXueWeike();
        InitializeFeiXueWeike();
    }

    protected void InitializePage()
    {
        studentBLL StudentBAll = new studentBLL();
        student Student = StudentBAll.GetModel(stuId);
        stuIdStr = Student.stuId;
        nameStr = Student.name;
        sexStr = Student.sex;
        colleageStr = Student.colleage;
        majorStr = Student.majorName;
        if (Student.admissionDate != null && Student.admissionDate.ToString().Length == 6)
            schoolTimeStr = Student.admissionDate.Insert(4, "年").Insert(7, "年");
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        zongXueFenStr = ExamRecordBLL.SumCredit(stuId);
        xueWeiKeZongXueFenStr = ExamRecordBLL.SumGXWCredit(stuId);
        xueWeikeJiaQuanPingJunStr = ExamRecordBLL.SumGXWAverageCredit(stuId);
    }

    protected void InitializeXueWeike()
    {
        int i = 0;
        StringBuilder sb = new StringBuilder();
        examrecordBLL ExamrecordBLL = new examrecordBLL();
        DataSet ds = ExamrecordBLL.getXueWeiKe(stuId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            sb.Append("<tr>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\" rowspan=\"15\">学位课程</td>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[0].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[3].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[2].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[1].ToString()).Append("</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[4].ToString()).Append("</td>");
            sb.Append("</tr>");
            i++;
        }
        for (; i < ds.Tables[0].Rows.Count; i++) {
            sb.Append("<tr>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[0].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[3].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[2].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[1].ToString()).Append("</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[4].ToString()).Append("</td>");
            sb.Append("</tr>");
        }
        for (; i < 15; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("</tr>");
        }
        xueWeiKeStr = sb.ToString();
    }

    protected void InitializeFeiXueWeike()
    {
        int i = 0;
        StringBuilder sb = new StringBuilder();
        examrecordBLL ExamrecordBLL = new examrecordBLL();
        DataSet ds = ExamrecordBLL.getFeiXueWeiKe(stuId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            sb.Append("<tr>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\" rowspan=\"15\">非学位课程</td>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[0].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[3].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[2].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[1].ToString()).Append("</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[4].ToString()).Append("</td>");
            sb.Append("</tr>");
            i++;
        }
        for (; i < ds.Tables[0].Rows.Count; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[0].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[3].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[2].ToString()).Append("</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[1].ToString()).Append("</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">").Append(ds.Tables[0].Rows[i].ItemArray[4].ToString()).Append("</td>");
            sb.Append("</tr>");
        }
        for (; i < 15; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td colspan=\"4\" style=\"width: 273px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td style=\"width: 72px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("<td colspan=\"2\" style=\"width: 145px;border: solid #000 1px;\">&nbsp;</td>");
            sb.Append("</tr>");
        }
        feiXueWeiKeStr = sb.ToString();
    }
}