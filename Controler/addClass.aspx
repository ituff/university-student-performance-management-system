<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="addClass.aspx.cs" Inherits="Controler_addStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        课程信息管理&gt; <span>添加新的课程</span></div>
    <div class="controlarea ">
        <br />
        <p>
            课程名称：<asp:TextBox ID="nameTB" runat="server" Width="350px" MaxLength="100"></asp:TextBox></p>
        <p>
            课程类别：<asp:DropDownList ID="typeDDL" runat="server" Width="200px" DataSourceID="classDateSource"
                DataTextField="name" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="classDateSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT * FROM [classType]"></asp:SqlDataSource>
        </p>
        <p>
            教师姓名：<asp:TextBox ID="teacherTB" runat="server" Width="350px" MaxLength="50"></asp:TextBox></p>
        <p>
            开始时间：<asp:TextBox ID="startYearTB" runat="server" Width="50px" MaxLength="4" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>年
            <asp:TextBox ID="startMonthTB" runat="server" Width="50px" MaxLength="2" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>月
            <asp:TextBox ID="startDayTB" runat="server" Width="50px" MaxLength="2" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>日
        </p>
        <p>
            结束时间：<asp:TextBox ID="endYearTB" runat="server" Width="50px" MaxLength="4" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>年
            <asp:TextBox ID="endMonthTB" runat="server" Width="50px" MaxLength="2" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>月
            <asp:TextBox ID="endDayTB" runat="server" Width="50px" MaxLength="2" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>日
        </p>
        <p>
            学时：<asp:TextBox ID="periodTB" runat="server" Width="165px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            学分：<asp:TextBox ID="creditTB" runat="server" Width="165px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox></p>
        <p>
            开课地点：<asp:TextBox ID="locationTB" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
        </p>
        <p>
            备注：<asp:TextBox ID="remarkTB" runat="server" Width="350px" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="addStudentBtn" runat="server" Text="添加新的课程" OnClick="addStudentBtn_Click" /></p>
        <br />
    </div>
</asp:Content>
