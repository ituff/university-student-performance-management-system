<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Controller_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 南京工业大学工程硕士成绩管理系统 </title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <meta name="GENERATOR" content="MSHTML 9.00.8112.16441" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <table class="wwFormTable">
            <asp:TextBox ID="username" runat="server" MaxLength="50"></asp:TextBox>
            <asp:TextBox ID="password" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="登录" onclick="submit_Click" />
        </table>
        <div id="notice">
        </div>
    </div>
    </form>
</body>
</html>

