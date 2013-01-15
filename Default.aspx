<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.8.0.min.js"></script>
    <!--[if IE 6]>
<script src="js/DD_belatedPNG_0.0.8a-min.js"></script>
<script>DD_belatedPNG.fix('.login-registerBtn img,.loginBtn,.loginBtn_login,.loginHeader-left img');
</script>
<![endif]-->
    <title>南京工业大学 工程硕士成绩查询系统</title>
</head>
<body>
    <div id="problemsolve">
        <p>
            用户在登录过程中如有疑问，请联系研究生处。</p>
    </div>
    <div class="gap">
    </div>
    <!--header begin-->
    <div id="loginHeader">
        <div class="loginHeader-left">
            <img src="image/login-head.png" />
        </div>
        <div class="seeMore">
            <a href="" id="seemore_" target="_blank">
                <p class="white" id="seeMore_p">
                    使用指南.doc</p>
            </a>
        </div>
        <div id="hide" style="display: none">
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <!--header end-->
    <!--body begin-->
    <div id="loginWrapper">
        <div class="landscape">
            <img src="image/login-landscape.jpg" />
        </div>
        <div class="middle">
        </div>
        <form id="loginForm" class="loginForm" runat="server">
        <p class="words">
            工程硕士成绩查询</p>
        <div class="warning">
        </div>
        <ul class="loginTitle">
            <li>学号</li>
            <li>密码</li>
            <li>验证码</li>
        </ul>
        <ul class="loginTextBox">
            <li class="white">
                <asp:TextBox ID="stuIdTB" class="textBox-1" runat="server" TabIndex="1"></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="passwordTB" class="textBox-1" runat="server" TabIndex="2" Style="font-size: 14px;"
                    TextMode="Password"></asp:TextBox>
                <a href="forgetMyPassword.aspx" target="_blank" tabindex="-1" style="text-decoration: none;" class="forgetPassword">
                    忘记密码？</a> </li>
            <li>
                <img src="VerifyCode.aspx" alt="验证码" class="imgyzmindex" width="60px" height="30px" />
                <asp:TextBox ID="yzmTB" class="textBox-2" runat="server" TabIndex="3"></asp:TextBox>
            </li>
        </ul>
        <asp:Button ID="loginBtn" class="loginBtn_login" runat="server" Text="" OnClick="loginBtn_Click" />
        <a id="link_" class="white" href="#"></a>
        <div class="login-registerBtn">
            <a href="#" title="手机版">
                <img alt="手机版" src="image/login-registerBtn.png" />
            </a>
        </div>
        </form>
    </div>
    <!--body end-->
    <!--copyright-->
    <div class="footer-stickToBottom">
        <div class="copyright">
            <p class="bold">
                Copyright &copy; 2012  <a href="http://www.njut.edu.cn" style="color:Black;">南京工业大学</a><a href="controler/" style="color:Black;">研究生处</a>版权所有
            </p>
            <p>
                技术支持 <a href="http://green.njut.edu.cn/" style="color:Green;">Green Studio</a> 页面设计 <a href="http://www.renren.com/331386829">Tree</a>&<a href="http://www.njutmars.com">Mars Studio</a></p>
            <!-- Green Studio. 2012-->
        </div>
    </div>
</body>
</html>
