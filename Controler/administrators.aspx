<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="administrators.aspx.cs" Inherits="classPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        成绩系统管理&gt; <span>管理员信息查询</span>
    </div>
    <div class="controlarea ">
        <p style="text-align: center;">
            管理员名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>密码：<asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
            账号类型：<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>超级管理员</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">管理员</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btn1" runat="server" Text="添加" OnClick="Unnamed2_Click"></asp:Button>
        </p>
        
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="id" HorizontalAlign="Center"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="80%"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="userName" HeaderText="用户名"
                    SortExpression="userName" />
                <asp:BoundField DataField="passWord" HeaderText="密码"
                    SortExpression="passWord" />
                <asp:BoundField DataField="type" HeaderText="帐户类型"
                    SortExpression="type" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>
        <br />
        <p>帐户类型：1，超级管理员；2，管理员。</p>
        <br />
    </div>
</asp:Content>
