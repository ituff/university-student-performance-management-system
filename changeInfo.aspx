<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true"
    CodeFile="changeInfo.aspx.cs" Inherits="changeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--body begin-->
    <div id="managementWrapper">
        <div class="step">
            <div class="stepImg">
                <img src="./image/management-stepOne.jpg">
            </div>
            <ul class="managementTitle">
                <li>学号</li>
                <li>姓名</li>
                <li>专业</li>
                <li>身份证号码</li>
            </ul>
            <ul class="managementTitle">
                <li style="color: black;">
                    <%=stuIdStr %></li>
                <li style="color: black;">
                    <%=nameStr %></li>
                <li style="color: black;">
                    <%=majorNameStr %></li>
                <li style="color: black;">
                    <%=idStr %></li>
            </ul>
            <div class="color1">
            </div>
        </div>
        <div class="step">
            <div class="stepImg">
                <img src="./image/management-stepTwo.jpg">
            </div>
            <form class="managementForm" method="get" action="http://a.njut.edu.cn/j_management.njut#">
            <ul class="managementTitle">
                <li>电子邮箱</li>
                <li>手机号码</li>
                <li style="height: 19px"></li>
                <li>
                    <asp:Button ID="saveBtn" class="opener_d" runat="server" Text="修改" OnClick="saveBtn_Click" />
                </li>
            </ul>
            <ul class="managementTitle">
                <li style="color: black;" id="managementTitle1">
                    <asp:TextBox ID="emailTB" runat="server"></asp:TextBox></li>
                <li style="color: black;" id="managementTitle2">
                    <asp:TextBox ID="cellPhoneTB"  OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" runat="server"></asp:TextBox></li>
            </ul>
            </form>
            <div class="color2">
            </div>
        </div>
        <div class="step">
            <div class="stepImg">
                <img src="./image/management-stepThree.jpg">
            </div>
            <ul class="modifyPassword">
                <li>
                    <div class="opener_b" style="text-align:center;">
                        <asp:TextBox ID="passWordTB1" TextMode="Password" Width="160px" style="filter: Alpha(Opacity=80);" runat="server"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <div class="opener_b" style="text-align:center;">
                        <asp:TextBox ID="passWordTB2" TextMode="Password" Width="160px" style="filter: Alpha(Opacity=80);" runat="server"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <asp:Button ID="changeBtn" class="opener_b" runat="server" Text="修改密码" 
                        onclick="changeBtn_Click" /></li>
            </ul>
            <div class="managementPerson">
                <img src="./image/personImg.png"></div>
            <!--<div class="color3"></div>-->
        </div>
    <div class="backToHome">
        <a href="student.aspx">
            <p>
                回到主页</p>
        </a>
    </div>
    </div>
    <!--body end-->
</asp:Content>
