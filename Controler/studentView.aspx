<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="studentView.aspx.cs" Inherits="Controler_studentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        学生信息管理&gt; <span>学生详情查看</span>
    </div>
    <div class="controlarea ">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="id" DataSourceID="SqlDataSource1" EnableModelValidation="True"
            ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="748px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="CLASSID" HeaderText="课程代码" SortExpression="CLASSID" />
                <asp:BoundField DataField="CLASS" HeaderText="科目名称" SortExpression="CLASS" />
                <asp:BoundField DataField="TEACHER" HeaderText="任课教师" SortExpression="TEACHER" />
                <asp:BoundField DataField="TYPE" HeaderText="课程类型" SortExpression="TYPE" />
                <asp:BoundField DataField="CREDIT" HeaderText="学分" SortExpression=" CREDIT" />
                <asp:BoundField DataField="PERIOD" HeaderText="学时" SortExpression=" PERIOD" />
                <asp:BoundField DataField="LOCATION" HeaderText="开课地点" SortExpression="LOCATION" />
                <asp:BoundField DataField="TIME" HeaderText="开课时间" SortExpression="TIME" DataFormatString="{0:d}" />
                <asp:BoundField DataField="SCORE" HeaderText="成绩" SortExpression="SCORE" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Larger"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [classDetail].[id] AS CLASSID,[classDetail].[location] AS LOCATION,[examRecord].[id] AS ID, [classDetail].[name] AS CLASS,[classDetail].[teacher] AS TEACHER, [classDetail].[startTime] AS TIME,[examRecord].[score] AS SCORE,[classDetail].[credit] AS CREDIT,[classDetail].[period] AS PERIOD,(SELECT [classType].[name] FROM [classType] WHERE [classType].[id]=(SELECT [classDetail].[type] FROM [classDetail] WHERE [classDetail].[id]=[examRecord].[class])) AS TYPE FROM [examRecord] INNER JOIN [classDetail] ON [examRecord].[class] = [classDetail].[id] WHERE ( [examRecord].[student] = @student) ORDER BY [examRecord].[id] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="student" SessionField="StuId" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <p style="text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="打印成绩单" OnClick="Button1_Click" />
        </p>
        <p>下载成绩单打印帮助文档：<a href="../download/南京工业大学工程硕士成绩管理系统成绩打印说明.pdf">南京工业大学工程硕士成绩管理系统成绩打印说明.pdf</a></p>
        <br />
        <p style="text-align: center"><b>总学分:</b><%=sumCreditStr%>&nbsp;&nbsp;&nbsp;&nbsp;<b>学位课总学分: </b><%=stuGXWCreditStr%>&nbsp;&nbsp;&nbsp;&nbsp;<b>学位课加权平均成绩:</b><%=stuGXWAverageCreditStr%></p>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <p style="text-align: center;">
                课程编号：<asp:TextBox ID="TextBox1" runat="server" Width="150px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                成绩：<asp:TextBox ID="TextBox2" runat="server" Width="50px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                备注<asp:TextBox ID="TextBox3" runat="server" Width="250px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" Text="添加成绩" OnClick="Button3_Click" />
            </p>
            <p>
                学生学号：<asp:TextBox ID="stuIdTB" runat="server" Width="175px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                学生姓名：<asp:TextBox ID="nameTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox>
            </p>
            <p>
                学生性别：<asp:DropDownList ID="sexDDL" runat="server" Width="77px">
                    <asp:ListItem Selected="True">男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
                学生民族：<asp:TextBox ID="nationTB" runat="server" Width="35px" MaxLength="10"></asp:TextBox>
                出生日期：<asp:TextBox ID="birthdayTB" runat="server" Width="75px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox><span
                    style="color: Red"> 格式：“yyyymmdd”</span>
            </p>
            <p>
                证件类型：<asp:TextBox ID="certificateTypeTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox>
                证件号码：<asp:TextBox ID="certificateIdTB" runat="server" Width="175px" MaxLength="50"
                    OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            </p>
            <p>
                专业代码：<asp:TextBox ID="majorIdTB" runat="server" Width="50px" MaxLength="20" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                专业名称：<asp:TextBox ID="majorNameTB" runat="server" Width="85px" MaxLength="20"></asp:TextBox>
                入学年份：<asp:TextBox ID="schoolYearTB" runat="server" Width="50px" MaxLength="6" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox><span
                    style="color: Red"> 格式：“yyyymm”</span>
            </p>
            <p>
                所在学院：<asp:TextBox ID="colleageTB" runat="server" Width="175px" MaxLength="20"></asp:TextBox>
                毕业学位：<asp:TextBox ID="degreeTB" runat="server" Width="75px" MaxLength="30"></asp:TextBox>
            </p>
            <p>
                集中办学：<asp:TextBox ID="classTypeTB" runat="server" Width="175px" MaxLength="50"></asp:TextBox>
                单位类型：<asp:TextBox ID="typeTB" runat="server" Width="75px" MaxLength="50"></asp:TextBox>
            </p>
            <p>
                工作单位：<asp:TextBox ID="placeOfWorkTB" runat="server" Width="150px" MaxLength="100"></asp:TextBox>
                办公电话：<asp:TextBox ID="workPhoneTB" runat="server" Width="100px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            </p>
            <p>
                移动电话：<asp:TextBox ID="phoneTB" runat="server" Width="100px" MaxLength="50" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                电子邮箱：<asp:TextBox ID="emailTB" runat="server" Width="150px" MaxLength="200"></asp:TextBox>
            </p>
            <p>
                工作地址：<asp:TextBox ID="addressTB" runat="server" Width="175px" MaxLength="200"></asp:TextBox>
                邮政编码：<asp:TextBox ID="zipCodeTB" runat="server" Width="75px" MaxLength="10" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
            </p>
            <p>
                学生密码：<asp:TextBox ID="passWordTB" runat="server" Width="200px" MaxLength="20"></asp:TextBox><span
                    style="color: Red"> 为空则不修改密码！</span>
            </p>
            <p>
                &nbsp;&nbsp;
            <asp:Button ID="updateStudentBtn" runat="server" Text="更新学生信息" OnClick="updateStudentBtn_Click"
                Width="120px" />
                &nbsp;
            <asp:Button ID="Button2" runat="server" Text="删除学生" OnClick="Button2_Click" />
                &nbsp;
            <input type="button" name="Submit" value="返回" onclick="javascript: history.back(1)" style="width: 80px;" />
            </p>
        </asp:Panel>
        <br />
    </div>
</asp:Content>
