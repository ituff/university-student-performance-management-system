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
        if (isTextBoxEmpty(majorIdTB, "专业代码")) Student.majorId = getText(majorIdTB);
        else return;
        if (isTextBoxEmpty(majorNameTB, "专业名称")) Student.majorName = getText(majorNameTB);
        else return;
        if (isTextBoxEmpty(colleageTB, "所在学院")) Student.colleage = getText(colleageTB);
        else return;
        Student.classType = getText(classTypeTB);
        if (isTextBoxEmpty(degreeTB, "毕业学位")) Student.degree = getText(degreeTB);
        else return;
        Student.type = getText(typeTB);
        Student.placeOfWork = getText(placeOfWorkTB);
        Student.workPhone = getText(workPhoneTB);
        if (isTextBoxEmpty(phoneTB, "移动电话")) Student.phone = getText(phoneTB);
        else return;
        Student.email = getText(emailTB);
        Student.address = getText(addressTB);
        Student.zipCode = getText(zipCodeTB);
        string passWord = Tools.safeUserInput(passWordTB.Text.Trim().ToString());
        if (passWord.Length < 1) Student.passWord = Tools.encrypt(Student.certificateId);
        else Student.passWord = Tools.encrypt(passWord);
        try
        {
            studentBLL StudentBLL = new studentBLL();
            StudentBLL.Add(Student);
        }
        catch
        {
            MessageBox.Show(this, "添加失败！");

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