<%@ Page Title="" Language="C#" MasterPageFile="~/Controler/admin.master" AutoEventWireup="true" CodeFile="loginLog.aspx.cs" Inherits="Controler_loginLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right01">
        <img src="images/04.gif" alt=""/>
        成绩系统管理&gt; <span>管理员密码修改</span></div>
    <div class="controlarea ">
    <br />
     <asp:GridView ID="GridView1" runat="server" Width="70%" HorizontalAlign="Center" 
            AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="id" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="Black" 
            GridLines="None" PageSize="30">
         <AlternatingRowStyle BackColor="PaleGoldenrod" />
         <Columns>
             <asp:BoundField DataField="student" HeaderText="学生" SortExpression="student" />
             <asp:BoundField DataField="time" HeaderText="登录时间" SortExpression="time" />
             <asp:BoundField DataField="ip" HeaderText="登录IP" SortExpression="ip" />
         </Columns>
         <FooterStyle BackColor="Tan" />
         <HeaderStyle BackColor="Tan" Font-Bold="True" />
         <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
             HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [studentLoginLog] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [studentLoginLog] ([student], [time], [ip]) VALUES (@student, @time, @ip)" 
            SelectCommand="SELECT * FROM [studentLoginLog] ORDER BY [id] DESC" 
            UpdateCommand="UPDATE [studentLoginLog] SET [student] = @student, [time] = @time, [ip] = @ip WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="student" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="ip" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="student" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="id" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
   

</asp:Content>

