<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="class.aspx.cs" Inherits="classPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        课程信息管理&gt; <span>课程信息查询</span>
    </div>
    <div class="controlarea ">
        <br />
        <p style="text-align: center">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                <asp:ListItem Value="2">课程代号</asp:ListItem>
                <asp:ListItem Selected="True" Value="0">课程名称</asp:ListItem>
                <asp:ListItem Value="1">任课教师</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
        </p>
        <br />
        <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="id" HorizontalAlign="Center" BackColor="LightGoldenrodYellow" BorderColor="Tan"
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="80%"
            AllowPaging="False" Visible="False">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="代码" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="课程名称" SortExpression="name" />
                <asp:BoundField DataField="TYPE" HeaderText="课程类型" SortExpression="TYPE" />
                <asp:BoundField DataField="teacher" HeaderText="任课教师" SortExpression="teacher" />
                <asp:BoundField DataField="location" HeaderText="开课地点" SortExpression="location" />
                <asp:BoundField DataField="startTime" HeaderText="开始时间" SortExpression="startTime"
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="endTime" HeaderText="结束时间" SortExpression="endTime" DataFormatString="{0:d}" />
                <asp:BoundField DataField="period" HeaderText="学时" SortExpression="period" />
                <asp:BoundField DataField="credit" HeaderText="学分" SortExpression="credit" />
                <asp:BoundField DataField="remark" HeaderText="备注"
                    SortExpression="remark" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="examRecord.aspx?id={0}"
                    Text="添加成绩" />
                <asp:HyperLinkField DataNavigateUrlFields="id"
                    DataNavigateUrlFormatString="classView.aspx?id={0}" Text="查看" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>
        <br />
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="id" HorizontalAlign="Center"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="80%"
            DataSourceID="GcssDataSource" AllowPaging="True" PageSize="30">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="代码" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="课程名称" SortExpression="name" />
                <asp:BoundField DataField="TYPE" HeaderText="课程类型" SortExpression="TYPE" />
                <asp:BoundField DataField="teacher" HeaderText="任课教师"
                    SortExpression="teacher" />
                <asp:BoundField DataField="location" HeaderText="开课地点" SortExpression="location" />
                <asp:BoundField DataField="startTime" HeaderText="开始时间"
                    SortExpression="startTime" DataFormatString="{0:d}" />
                <asp:BoundField DataField="endTime" HeaderText="结束时间"
                    SortExpression="endTime" DataFormatString="{0:d}" />
                <asp:BoundField DataField="period" HeaderText="学时"
                    SortExpression="period" />
                <asp:BoundField DataField="credit" HeaderText="学分"
                    SortExpression="credit" />
                <asp:BoundField DataField="remark" HeaderText="备注"
                    SortExpression="remark" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="examRecord.aspx?id={0}" Text="添加成绩" />
                <asp:HyperLinkField DataNavigateUrlFields="id"
                    DataNavigateUrlFormatString="classView.aspx?id={0}" Text="查看" />
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
            DeleteCommand="DELETE FROM [examRecord] WHERE [class] = @id;DELETE FROM [classDetail] WHERE [id] = @id"
            InsertCommand="INSERT INTO [classDetail] ([name], [type], [teacher], [startTime], [endTime], [period], [credit], [location], [remark], [classId]) VALUES (@name, @type, @teacher, @startTime, @endTime, @period, @credit, @location, @remark, @classId)"
            SelectCommand="SELECT [id],[name],(SELECT [classType].[name] FROM [classType] WHERE [classType].[id]=[classDetail].[type]) AS TYPE, [teacher], [startTime], [endTime], [period], [credit], [location], [remark], [classId] FROM [classDetail]  ORDER BY [id] DESC"
            UpdateCommand="UPDATE [classDetail] SET [name] = @name, [type] = @type, [teacher] = @teacher, [startTime] = @startTime, [endTime] = @endTime, [period] = @period, [credit] = @credit, [location] = @location, [remark] = @remark, [classId] = @classId WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="Object" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="teacher" Type="String" />
                <asp:Parameter Name="startTime" Type="DateTime" />
                <asp:Parameter Name="endTime" Type="DateTime" />
                <asp:Parameter Name="period" Type="String" />
                <asp:Parameter Name="credit" Type="String" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="remark" Type="String" />
                <asp:Parameter Name="classId" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="Object" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="teacher" Type="String" />
                <asp:Parameter Name="startTime" Type="DateTime" />
                <asp:Parameter Name="endTime" Type="DateTime" />
                <asp:Parameter Name="period" Type="String" />
                <asp:Parameter Name="credit" Type="String" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="remark" Type="String" />
                <asp:Parameter Name="classId" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
    </div>
</asp:Content>
