<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true"
    CodeFile="student.aspx.cs" Inherits="studentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--body begin-->
    <div id="homeWrapper">
        <div id="personImg">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="id" DataSourceID="SqlDataSource1" EnableModelValidation="True"
                ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="748px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CLASS" HeaderText="科目名称" SortExpression="CLASS" />
                    <asp:BoundField DataField="TEACHER" HeaderText="任课教师" SortExpression="TEACHER" />
                    <asp:BoundField DataField="TYPE" HeaderText="课程类型" SortExpression="TYPE" />
                    <asp:BoundField DataField="CREDIT" HeaderText="学分" SortExpression=" CREDIT" />
                    <asp:BoundField DataField="PERIOD" HeaderText="学时" SortExpression=" PERIOD" />
                    <asp:BoundField DataField="LOCATION" HeaderText="开课地点" SortExpression="LOCATION" />
                    <asp:BoundField DataField="TIME" HeaderText="开课时间" SortExpression="TIME" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="SCORE" HeaderText="成绩" SortExpression="SCORE" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Larger"
                    HorizontalAlign="Center" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT [classDetail].[location] AS LOCATION,[examRecord].[id] AS ID, [classDetail].[name] AS CLASS,[classDetail].[teacher] AS TEACHER, [classDetail].[startTime] AS TIME,[examRecord].[score] AS SCORE,[classDetail].[credit] AS CREDIT,[classDetail].[period] AS PERIOD,(SELECT [classType].[name] FROM [classType] WHERE [classType].[id]=(SELECT [classDetail].[type] FROM [classDetail] WHERE [classDetail].[id]=[examRecord].[class])) AS TYPE FROM [examRecord] INNER JOIN [classDetail] ON [examRecord].[class] = [classDetail].[id] WHERE ( [examRecord].[student] = @student) ORDER BY [examRecord].[id] DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="student" SessionField="UserId" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br/>
            <p style="text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="打印成绩单" OnClick="Button1_Click" /></p>
            <p>下载成绩单打印帮助文档：<a href="download/南京工业大学工程硕士成绩管理系统成绩打印说明.pdf">南京工业大学工程硕士成绩管理系统成绩打印说明.pdf</a></p>

            <!-- <img src="./image/personImg.png">-->
        </div>

        <div id="line1">
            <div class="mail">
                <span style="float: right; color: white; font-size: 16px; margin-right: 20px; margin-top: 16px;">
                    <%=sumCreditStr%></span><span style="float: right; color: white; font-size: 16px;
                        margin-right: 20px; margin-top: 16px;"><b>总学分</b></span></div>
            <a href="changeInfo.aspx">
                <div class="person">
                    <img style="float: left; margin-top: 10px; margin-left: 20px;" src="./image/home-person.png">
                    <span style="float: right; color: white; font-size: 16px; margin-right: 20px; margin-top: 16px;">
                        个人信息管理</span> <span style="float: right; color: white; font-size: 16px; margin-right: 20px;
                            margin-top: 16px;">
                            <%=stuNameStr%></span>
                </div>
            </a>
        </div>
        <div id="line2">
            <div class="leftTraffic">
                <span style="float: right; color: white; font-size: 16px; margin-right: 20px; margin-top: 16px;">
                    <%=stuGXWCreditStr%></span><span style="float: right; color: white; font-size: 16px;
                        margin-right: 20px; margin-top: 16px;"><b>学位课总学分</b></span>
            </div>
            <div class="usedTraffic">
                <span style="float: right; color: white; font-size: 16px; margin-right: 20px; margin-top: 16px;">
                    <%=stuGXWAverageCreditStr%></span> <span style="float: right; color: white; font-size: 16px;
                        margin-right: 20px; margin-top: 16px;"><b>学位课加权平均成绩</b></span>
            </div>
            <p>
                说明:学位课加权平均成绩计算方法:∑(每门学位课成绩×学时)/学位课总学时，<span style="color:red;">低于60分</span>的课程将不被算入总学分！                
            </p>
        </div>
          <div style="height:45px;">
          </div>
    </div>
    <!--body end-->
</asp:Content>
