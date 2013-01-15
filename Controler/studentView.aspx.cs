using System;
using System.Web.UI.WebControls;
using GS.Utility;
using Maticsoft.Common;
using GS.Model;
using GS.BLL;

public partial class Controler_studentView : System.Web.UI.Page
{
    int id;
    public string sumCreditStr = "";
    public string stuGXWCreditStr = "";
    public string stuGXWAverageCreditStr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1", "2");
        if (Session["type"].ToString().Equals("2")) Panel1.Visible = false;
        markUnder60();
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
            ViewState["id"] = id;
            studentBLL StudentBLL = new studentBLL();
            Session["StuId"] = StudentBLL.GetModel(id).stuId;
        }
        catch
        {
            MessageBox.Show(this, "你查询的页面不存在！");
            Response.Write("<script language=javascript>history.go(-2);</script>");
        }
        finally { }
        if (!Page.IsPostBack)
        {
            id = Convert.ToInt32(ViewState["id"]);
            initial(id);
        }
    }

    protected void markUnder60()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (Convert.ToInt32(GridView1.Rows[i].Cells[8].Text.Trim()) < 60)
                GridView1.Rows[i].BackColor = System.Drawing.Color.Red;
        }
    }


    protected void initial(int Id)
    {
        studentBLL StudentBLL = new studentBLL();
        student Student = StudentBLL.GetModel(Id);
        try
        {
            stuIdTB.Text = Student.stuId;
            nameTB.Text = Student.name;
            sexDDL.SelectedValue = Student.sex;
            nationTB.Text = Student.nation;
            birthdayTB.Text = Student.birthday;
            certificateTypeTB.Text = Student.certificateType;
            certificateIdTB.Text = Student.certificateId;
            majorIdTB.Text = Student.majorId;
            majorNameTB.Text = Student.majorName;
            colleageTB.Text = Student.colleage;
            degreeTB.Text = Student.degree;
            classTypeTB.Text = Student.classType;
            typeTB.Text = Student.type;
            placeOfWorkTB.Text = Student.placeOfWork;
            workPhoneTB.Text = Student.workPhone;
            phoneTB.Text = Student.phone;
            emailTB.Text = Student.email;
            addressTB.Text = Student.address;
            zipCodeTB.Text = Student.zipCode;
            schoolYearTB.Text = Student.admissionDate;
        }
        catch
        {
            MessageBox.Show(this, "该学生不存在！");
            Response.Write("<script language=javascript>history.go(-2);</script>");
        }
        finally { };
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        sumCreditStr = ExamRecordBLL.SumCredit(Session["StuId"].ToString().Trim());
        stuGXWCreditStr = ExamRecordBLL.SumGXWCredit(Session["StuId"].ToString().Trim());
        stuGXWAverageCreditStr = ExamRecordBLL.SumGXWAverageCredit(Session["StuId"].ToString().Trim());
    }

    protected void updateStudentBtn_Click(object sender, EventArgs e)
    {
        student Student = new student();
        if (isTextBoxEmpty(stuIdTB, "学生学号")) Student.stuId = getText(stuIdTB);
        else return;
        if (isTextBoxEmpty(nameTB, "学生姓名")) Student.name = getText(nameTB);
        else return;
        Student.sex = sexDDL.SelectedItem.Value;
        if (isTextBoxEmpty(nationTB, "民族")) Student.nation = getText(nationTB);
        else return;
        if (isTextBoxEmpty(birthdayTB, "出生日期"))
        {
            string birthday = getText(birthdayTB);
            if (birthday.Length != 8)
            {
                MessageBox.Show(this, "出生日期格式不正确！");
                return;
            }
            Student.birthday = birthday;
        }
        else return;
        if (isTextBoxEmpty(certificateTypeTB, "证件类型")) Student.certificateType = getText(certificateTypeTB);
        else return;
        if (isTextBoxEmpty(certificateIdTB, "证件号码")) Student.certificateId = getText(certificateIdTB);
        else return;
        if (isTextBoxEmpty(schoolYearTB, "入学时间")) Student.admissionDate = getText(schoolYearTB);
        else return;
        if (isTextBoxEmpty(majorIdTB, "专业代码")) Student.majorId = getText(majorIdTB);
        else return;
        if (isTextBoxEmpty(majorNameTB, "专业名称")) Student.majorName = getText(majorNameTB);
        else return;
        if (isTextBoxEmpty(colleageTB, "所在学院")) Student.colleage = getText(colleageTB);
        else return;
        Student.classType = getText(classTypeTB);
        Student.degree = getText(degreeTB);
        Student.type = getText(typeTB);
        Student.placeOfWork = getText(placeOfWorkTB);
        Student.workPhone = getText(workPhoneTB);
        if (isTextBoxEmpty(phoneTB, "移动电话")) Student.phone = getText(phoneTB);
        else return;
        Student.email = getText(emailTB);
        Student.address = getText(addressTB);
        Student.zipCode = getText(zipCodeTB);
        string passWord = Tools.safeUserInput(passWordTB.Text.Trim().ToString());
        studentBLL StudentBLL = new studentBLL();
        if (passWord.Length < 1) Student.passWord = StudentBLL.GetModel(id).passWord;
        else Student.passWord = Tools.encrypt(passWord);

        if (StudentBLL.GetModel(id).stuId != Student.stuId)
        {
            examrecordBLL ExamRecordBLL = new examrecordBLL();
            studentloginlogBLL StudentLoginLogBLL = new studentloginlogBLL();
            try
            {
                StudentBLL.Add(Student);
                ExamRecordBLL.repalaceStuId(StudentBLL.GetModel(id).stuId, Student.stuId);
                StudentLoginLogBLL.repalaceStuId(StudentBLL.GetModel(id).stuId, Student.stuId);
                StudentBLL.Delete(id);

            }
            catch
            {
                MessageBox.Show(this, "更新失败！");
            }
        }
        if (Session["StuId"].ToString().Trim().Equals(getText(stuIdTB)))
        {
            Student.id = id;
            try
            {
                StudentBLL.Update(Student);
            }
            catch
            {
                MessageBox.Show(this, "更新失败！");
            }
        }
        MessageBox.ShowAndRedirect(this, "更新成功！", "student.aspx");
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("transcript.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        studentBLL StudentBLL = new studentBLL();
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        studentloginlogBLL StudentLoginLogBLL = new studentloginlogBLL();

        try
        {
            ExamRecordBLL.Delete(Session["StuId"].ToString().Trim());
            StudentLoginLogBLL.Delete(Session["StuId"].ToString().Trim());
            StudentBLL.Delete(id);
        }
        catch
        {

            MessageBox.Show(this, "删除失败！");
        }
        MessageBox.ShowAndRedirect(this, "删除成功！", "student.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int classId = 0;
        int score = 0;
        string remark = "";
        try
        {
            classId = Convert.ToInt32(TextBox1.Text.Trim());
            score = Convert.ToInt32(TextBox2.Text.Trim());
            remark = Tools.safeUserInput(TextBox3.Text.Trim());
        }
        catch
        {
            MessageBox.Show(this, "输入格式不对，请重新输入!");
        }
        classdetailBLL ClassDetailBLL = new classdetailBLL();
        if (!ClassDetailBLL.Exists(classId))
        {
            MessageBox.Show(this, "课程不存在！");
            return;
        }
        examrecord ExamRecord = new examrecord();
        examrecordBLL ExamRecordBLL = new examrecordBLL();
        ExamRecord.classId = classId.ToString();
        ExamRecord.score = score.ToString();
        ExamRecord.student = Session["StuId"].ToString().Trim();
        ExamRecord.remark = remark;
        try
        {
            ExamRecordBLL.Add(ExamRecord);
        }
        catch
        {
            MessageBox.Show(this, "添加成绩失败！");
        }
        MessageBox.Show(this, "添加" + ClassDetailBLL.GetModel(classId).teacher.Trim() + "的" + ClassDetailBLL.GetModel(classId).name + "，分数："+score+"。");
        GridView1.DataBind();
    }
}