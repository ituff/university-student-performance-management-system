using System;
using System.Web.UI.WebControls;
using GS.Utility;
using Maticsoft.Common;
using GS.Model;
using GS.BLL;

public partial class Controler_addStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
    }
    protected void addStudentBtn_Click(object sender, EventArgs e)
    {
        classdetail ClassDetail = new classdetail();
        if (isTextBoxEmpty(nameTB, "课程名称")) ClassDetail.name = getText(nameTB);
        else return;
         ClassDetail.type = Convert.ToInt32(typeDDL.SelectedItem.Value);
        if (isTextBoxEmpty(teacherTB, "教师姓名")) ClassDetail.teacher= getText(teacherTB);
        else return;
        string startTimeStr = ""; 
        if (isTextBoxEmpty(startYearTB, "开始时间-年"))
        {
            string year = getText(startYearTB);
            if (year.Length != 4)
            {
                MessageBox.Show(this, "开始时间-年:格式不正确！");
                return;
            }
            startTimeStr += year+"-";
        }
        if (isTextBoxEmpty(startMonthTB, "开始时间-月"))
        {
            int month = Convert.ToInt32(getText(startMonthTB));
            if (month<1||month>12)
            {
                MessageBox.Show(this, "开始时间-月:格式不正确！");
                return;
            }
            if (month < 10)
                startTimeStr += "0" + month.ToString()+"-";
            else startTimeStr += month.ToString()+"-";
        }
        if (isTextBoxEmpty(startDayTB, "开始时间-日"))
        {
            int day = Convert.ToInt32(getText(startDayTB));
            if (day < 1 || day > 31)
            {
                MessageBox.Show(this, "开始时间-日:格式不正确！");
                return;
            }
            if(day<10)
            startTimeStr += "0"+day.ToString();
            else startTimeStr += day.ToString() ;
        }
            ClassDetail.startTime=Convert.ToDateTime(startTimeStr);
         string endTimeStr = ""; 
        if (isTextBoxEmpty(endYearTB, "结束时间-年"))
        {
            string year = getText(endYearTB);
            if (year.Length != 4)
            {
                MessageBox.Show(this, "结束时间-年:格式不正确！");
                return;
            }
            endTimeStr += year + "-";
        }
        if (isTextBoxEmpty(endMonthTB, "结束时间-月"))
        {
            int month = Convert.ToInt32(getText(endMonthTB));
            if (month<1||month>12)
            {
                MessageBox.Show(this, "结束时间-月:格式不正确！");
                return;
            }
            if (month < 10)
                endTimeStr += "0" + month.ToString() + "-";
            else endTimeStr += month.ToString() + "-";
        }
        if (isTextBoxEmpty(endDayTB, "结束时间-日"))
        {
            int day = Convert.ToInt32(getText(endDayTB));
            if (day < 1 || day > 31)
            {
                MessageBox.Show(this, "结束时间-日:格式不正确！");
                return;
            }
            if (day < 10)
                endTimeStr += "0" + day.ToString();
            else endTimeStr += day.ToString();
        }
            ClassDetail.endTime=Convert.ToDateTime(endTimeStr);

            if (isTextBoxEmpty(periodTB, "学时")) ClassDetail.period = getText(periodTB);
        else return;
            if (isTextBoxEmpty(creditTB, "学分")) ClassDetail.credit = getText(creditTB);
        else return;
        if (isTextBoxEmpty(locationTB, "开课地点")) ClassDetail.location = getText(locationTB);
        else return;
        ClassDetail.remark=getText(remarkTB);
        try
        {
            classdetailBLL ClassDetailBLL = new classdetailBLL();
            ClassDetailBLL.Add(ClassDetail);
        }
        catch(Exception ex)
        {
            MessageBox.Show(this, "添加失败！");
            Console.WriteLine(ex.Message);

        }
        MessageBox.Show(this, "添加成功！");
    }
    protected bool isTextBoxEmpty(TextBox tb, string item)
    {
        if (tb.Text.Trim().ToString().Length < 1)
        {
            MessageBox.Show(this, item + "不能为空！");
            return false;
        }
        else return true;
    }
    protected string getText(TextBox tb)
    {
        return Tools.safeUserInput(tb.Text.Trim().ToString());
    }
}