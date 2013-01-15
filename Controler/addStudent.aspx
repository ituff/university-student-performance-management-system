<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="addStudent.aspx.cs" Inherits="Controler_addStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        学生信息管理&gt; <span>添加新的学生</span></div>
    <div class="controlarea ">
        <br />
        <p>
            学生学号：<asp:TextBox ID="stuIdTB" runat="server" Width="175px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            学生姓名：<asp:TextBox ID="nameTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox></p>
        <p>
            学生性别：<asp:DropDownList ID="sexDDL" runat="server" Width="77px">
                <asp:ListItem Selected="True">男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
            学生民族：<asp:TextBox ID="nationTB" runat="server" Width="35px" MaxLength="10"></asp:TextBox>
            出生日期：<asp:TextBox ID="birthdayTB" runat="server" Width="75px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox><span
                style="color: Red"> 格式：“yyyymmdd”</span></p>
        <p>
            证件类型：<asp:TextBox ID="certificateTypeTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox>
            证件号码：<asp:TextBox ID="certificateIdTB" runat="server" Width="175px" MaxLength="50"
                OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox></p>
        <p>
            专业代码：<asp:TextBox ID="majorIdTB" runat="server" Width="50px" MaxLength="20" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            专业名称：<asp:TextBox ID="majorNameTB" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
        <p>
            所在学院：<asp:TextBox ID="colleageTB" runat="server" Width="175px" MaxLength="20"></asp:TextBox>
            毕业学位：<asp:TextBox ID="degreeTB" runat="server" Width="75px" MaxLength="30"></asp:TextBox></p>
        <p>
            集中办学：<asp:TextBox ID="classTypeTB" runat="server" Width="175px" MaxLength="50"></asp:TextBox>
            单位类型：<asp:TextBox ID="typeTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox></p>
        <p>
            工作单位：<asp:TextBox ID="placeOfWorkTB" runat="server" Width="150px" MaxLength="100"></asp:TextBox>
            办公电话：<asp:TextBox ID="workPhoneTB" runat="server" Width="100px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox></p>
        <p>
            移动电话：<asp:TextBox ID="phoneTB" runat="server" Width="100px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            电子邮箱：<asp:TextBox ID="emailTB" runat="server" Width="150px" MaxLength="200"></asp:TextBox></p>
        <p>
            工作地址：<asp:TextBox ID="addressTB" runat="server" Width="175px" MaxLength="200"></asp:TextBox>
            邮政编码：<asp:TextBox ID="zipCodeTB" runat="server" Width="75px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox></p>
        <p>
            学生密码：<asp:TextBox ID="passWordTB" runat="server" Width="200px" MaxLength="20"></asp:TextBox><span
                style="color: Red"> 如果密码为空，则默认为学生身份证号！</span></p>
       <p> <asp:Button ID="addStudentBtn" runat="server" Text="添加新的学生" OnClick="addStudentBtn_Click" /></p>
        <br />
    </div>
</asp:Content>
