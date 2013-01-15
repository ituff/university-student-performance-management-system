<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true"
    CodeFile="forgetMyPassword.aspx.cs" Inherits="forgetMyPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--body begin-->
    <div id="homeWrapper">
        <asp:Panel ID="Panel1" Visible="true" runat="server">
            <div id="inputcount">
                <p>
                    找回密码</p>
                <div class="inputcount_inputxue">
                    您的学号:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="stuIdTB" name="schoolnumber"  OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" runat="server"></asp:TextBox>
                </div>
                <div class="inputcount_inputxue">
                    身份证号:&nbsp;&nbsp;&nbsp;&nbsp<asp:TextBox ID="idTB" name="mail"  OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" runat="server"></asp:TextBox>
                </div>
                <div class="inputcount_inputxue" style="text-align: center;">
                    <asp:Button ID="checkBtn" runat="server" Text="下一步" onclick="checkBtn_Click" />
                </div>
            </div>
        </asp:Panel>
         <asp:Panel ID="Panel2" Visible="false" runat="server">
          <div id="Div1">
                <p>
                    重置密码</p>
                <div class="inputcount_inputxue">
                    新密码:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="passWordTB1" name="schoolnumber" runat="server"></asp:TextBox>
                </div>
                <div class="inputcount_inputxue">
                    新密码:&nbsp;&nbsp;&nbsp;&nbsp<asp:TextBox ID="passWordTB2" name="mail" runat="server"></asp:TextBox>
                </div>
                <div class="inputcount_inputxue" style="text-align: center;">
                    <asp:Button ID="saveBtn" runat="server" Text="确定" onclick="saveBtn_Click" />
                </div>
            </div>
              </asp:Panel>
    </div>
    <!--body end-->
</asp:Content>
