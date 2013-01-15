<%@ Page Title="" Language="C#" MasterPageFile="~/Controler/admin.master" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="Controler_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt=""/>
        成绩系统管理&gt; <span>管理员密码修改</span></div>
    <div class="controlarea ">
    <p style="text-align:center">新的密码：<asp:TextBox ID="passWordTB1" runat="server" TextMode="Password"></asp:TextBox></p>
    <p style="text-align:center">重复密码：<asp:TextBox ID="passWordTB2" runat="server" TextMode="Password"></asp:TextBox></p>
    <p style="text-align:center"><asp:Button ID="Button1" runat="server" Text="保存" 
            onclick="Button1_Click" /></p>
    </div>
</asp:Content>

