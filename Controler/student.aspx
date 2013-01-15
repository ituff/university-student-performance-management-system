<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="student.aspx.cs" Inherits="studentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        学生信息管理&gt; <span>学生信息查询</span>
    </div>
    <div class="controlarea ">
        <br />
        <p style="text-align: center">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                <asp:ListItem Selected="True" Value="0">学生学号</asp:ListItem>
                <asp:ListItem Value="1">学生姓名</asp:ListItem>
                <asp:ListItem Value="2">身份证号</asp:ListItem>
                <asp:ListItem Value="3">手机号</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
        </p>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                DataKeyNames="id" HorizontalAlign="Center"
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                ForeColor="Black" GridLines="None" Width="80%"
                DataSourceID="GcssDataSource" AllowPaging="True" PageSize="30">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="stuId" HeaderText="学号" SortExpression="stuId" />
                    <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                    <asp:BoundField DataField="sex" HeaderText="性别" SortExpression="sex" />
                    <asp:BoundField DataField="majorName" HeaderText="专业名称"
                        SortExpression="majorName" />
                    <asp:BoundField DataField="colleage" HeaderText="所属学院"
                        SortExpression="colleage" />
                    <asp:BoundField DataField="certificateId" HeaderText="身份证号"
                        SortExpression="certificateId" />
                    <asp:BoundField DataField="phone" HeaderText="移动电话"
                        SortExpression="phone" />
                    <asp:HyperLinkField DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="studentView.aspx?id={0}" Text="查看" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            </asp:GridView>
            <asp:SqlDataSource ID="GcssDataSource" runat="server"
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [studentLoginLog] WHERE [student]=(SELECT [stuId] FROM [student] WHERE [id] = @id);DELETE FROM [examRecord] WHERE [student]=(SELECT [stuId] FROM [student] WHERE [id] = @id);DELETE FROM [student] WHERE [id] = @id"
                InsertCommand="INSERT INTO [student] ([stuId], [name], [sex], [majorId], [majorName], [colleage], [classType], [nation], [birthday], [certificateType], [certificateId], [degree], [placeOfWork], [workPhone], [phone], [zipCode], [address], [email], [photo], [passWord], [type]) VALUES (@stuId, @name, @sex, @majorId, @majorName, @colleage, @classType, @nation, @birthday, @certificateType, @certificateId, @degree, @placeOfWork, @workPhone, @phone, @zipCode, @address, @email, @photo, @passWord, @type)"
                SelectCommand="SELECT * FROM [student] ORDER BY [id] DESC"
                UpdateCommand="UPDATE [student] SET [stuId] = @stuId, [name] = @name, [sex] = @sex, [majorId] = @majorId, [majorName] = @majorName, [colleage] = @colleage, [classType] = @classType, [nation] = @nation, [birthday] = @birthday, [certificateType] = @certificateType, [certificateId] = @certificateId, [degree] = @degree, [placeOfWork] = @placeOfWork, [workPhone] = @workPhone, [phone] = @phone, [zipCode] = @zipCode, [address] = @address, [email] = @email, [photo] = @photo, [passWord] = @passWord, [type] = @type WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int64" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="stuId" Type="String" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="majorId" Type="String" />
                    <asp:Parameter Name="majorName" Type="String" />
                    <asp:Parameter Name="colleage" Type="String" />
                    <asp:Parameter Name="classType" Type="String" />
                    <asp:Parameter Name="nation" Type="String" />
                    <asp:Parameter Name="birthday" Type="String" />
                    <asp:Parameter Name="certificateType" Type="String" />
                    <asp:Parameter Name="certificateId" Type="String" />
                    <asp:Parameter Name="degree" Type="String" />
                    <asp:Parameter Name="placeOfWork" Type="String" />
                    <asp:Parameter Name="workPhone" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="zipCode" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="photo" Type="String" />
                    <asp:Parameter Name="passWord" Type="String" />
                    <asp:Parameter Name="type" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="stuId" Type="String" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="majorId" Type="String" />
                    <asp:Parameter Name="majorName" Type="String" />
                    <asp:Parameter Name="colleage" Type="String" />
                    <asp:Parameter Name="classType" Type="String" />
                    <asp:Parameter Name="nation" Type="String" />
                    <asp:Parameter Name="birthday" Type="String" />
                    <asp:Parameter Name="certificateType" Type="String" />
                    <asp:Parameter Name="certificateId" Type="String" />
                    <asp:Parameter Name="degree" Type="String" />
                    <asp:Parameter Name="placeOfWork" Type="String" />
                    <asp:Parameter Name="workPhone" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="zipCode" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="photo" Type="String" />
                    <asp:Parameter Name="passWord" Type="String" />
                    <asp:Parameter Name="type" Type="String" />
                    <asp:Parameter Name="id" Type="Int64" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                DataKeyNames="id" HorizontalAlign="Center"
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                ForeColor="Black" GridLines="None" Width="80%"
                DataSourceID="GcssDataSource" AllowPaging="True" PageSize="30">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="stuId" HeaderText="学号" SortExpression="stuId" />
                    <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                    <asp:BoundField DataField="sex" HeaderText="性别" SortExpression="sex" />
                    <asp:BoundField DataField="majorName" HeaderText="专业名称"
                        SortExpression="majorName" />
                    <asp:BoundField DataField="colleage" HeaderText="所属学院"
                        SortExpression="colleage" />
                    <asp:BoundField DataField="certificateId" HeaderText="身份证号"
                        SortExpression="certificateId" />
                    <asp:BoundField DataField="phone" HeaderText="移动电话"
                        SortExpression="phone" />
                    <asp:HyperLinkField DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="studentView.aspx?id={0}" Text="查看" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [student] WHERE [id] = @id"
                InsertCommand="INSERT INTO [student] ([stuId], [name], [sex], [majorId], [majorName], [colleage], [classType], [nation], [birthday], [certificateType], [certificateId], [degree], [placeOfWork], [workPhone], [phone], [zipCode], [address], [email], [photo], [passWord], [type]) VALUES (@stuId, @name, @sex, @majorId, @majorName, @colleage, @classType, @nation, @birthday, @certificateType, @certificateId, @degree, @placeOfWork, @workPhone, @phone, @zipCode, @address, @email, @photo, @passWord, @type)"
                SelectCommand="SELECT * FROM [student] ORDER BY [id] DESC"
                UpdateCommand="UPDATE [student] SET [stuId] = @stuId, [name] = @name, [sex] = @sex, [majorId] = @majorId, [majorName] = @majorName, [colleage] = @colleage, [classType] = @classType, [nation] = @nation, [birthday] = @birthday, [certificateType] = @certificateType, [certificateId] = @certificateId, [degree] = @degree, [placeOfWork] = @placeOfWork, [workPhone] = @workPhone, [phone] = @phone, [zipCode] = @zipCode, [address] = @address, [email] = @email, [photo] = @photo, [passWord] = @passWord, [type] = @type WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int64" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="stuId" Type="String" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="majorId" Type="String" />
                    <asp:Parameter Name="majorName" Type="String" />
                    <asp:Parameter Name="colleage" Type="String" />
                    <asp:Parameter Name="classType" Type="String" />
                    <asp:Parameter Name="nation" Type="String" />
                    <asp:Parameter Name="birthday" Type="String" />
                    <asp:Parameter Name="certificateType" Type="String" />
                    <asp:Parameter Name="certificateId" Type="String" />
                    <asp:Parameter Name="degree" Type="String" />
                    <asp:Parameter Name="placeOfWork" Type="String" />
                    <asp:Parameter Name="workPhone" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="zipCode" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="photo" Type="String" />
                    <asp:Parameter Name="passWord" Type="String" />
                    <asp:Parameter Name="type" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="stuId" Type="String" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="majorId" Type="String" />
                    <asp:Parameter Name="majorName" Type="String" />
                    <asp:Parameter Name="colleage" Type="String" />
                    <asp:Parameter Name="classType" Type="String" />
                    <asp:Parameter Name="nation" Type="String" />
                    <asp:Parameter Name="birthday" Type="String" />
                    <asp:Parameter Name="certificateType" Type="String" />
                    <asp:Parameter Name="certificateId" Type="String" />
                    <asp:Parameter Name="degree" Type="String" />
                    <asp:Parameter Name="placeOfWork" Type="String" />
                    <asp:Parameter Name="workPhone" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="zipCode" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="photo" Type="String" />
                    <asp:Parameter Name="passWord" Type="String" />
                    <asp:Parameter Name="type" Type="String" />
                    <asp:Parameter Name="id" Type="Int64" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" Visible="False">
                <asp:GridView ID="GridView3" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                DataKeyNames="id" HorizontalAlign="Center"
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                ForeColor="Black" GridLines="None" Width="80%" >
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="stuId" HeaderText="学号" SortExpression="stuId" />
                    <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                    <asp:BoundField DataField="sex" HeaderText="性别" SortExpression="sex" />
                    <asp:BoundField DataField="majorName" HeaderText="专业名称"
                        SortExpression="majorName" />
                    <asp:BoundField DataField="colleage" HeaderText="所属学院"
                        SortExpression="colleage" />
                    <asp:BoundField DataField="certificateId" HeaderText="身份证号"
                        SortExpression="certificateId" />
                    <asp:BoundField DataField="phone" HeaderText="移动电话"
                        SortExpression="phone" />
                    <asp:HyperLinkField DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="studentView.aspx?id={0}" Text="查看" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            </asp:GridView>

        </asp:Panel>


    </div>
</asp:Content>
