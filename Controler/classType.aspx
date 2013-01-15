<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="classType.aspx.cs" Inherits="classPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt=""/>
        学生信息管理&gt; <span>课程类别查询</span></div>
    <div class="controlarea ">

      <p style="text-align:center;">课程类别：
        <asp:TextBox ID="classTypeTB" runat="server" Width="180px"></asp:TextBox>&nbsp;<asp:Button ID="addBtn"
            runat="server" Text="添加" onclick="addBtn_Click" /></p>
          <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="id" HorizontalAlign="Center" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="300px" 
            DataSourceID="GcssDataSource" AllowPaging="True" PageSize="30">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="课程类别" SortExpression="name" >
                <ControlStyle Width="240px" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True">
                <ControlStyle Width="30px" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True">
                <ControlStyle Width="30px" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>
        <asp:SqlDataSource ID="GcssDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [classType] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [classType] ([id], [name]) VALUES (@id, @name)" 
            SelectCommand="SELECT * FROM [classType] ORDER BY [id]" 
            
            UpdateCommand="UPDATE [classType] SET [name] = @name WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="String" />
                <asp:Parameter Name="name" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="id" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
      
    </div>
</asp:Content>
