<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="examRecord.aspx.cs" Inherits="classPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        成绩信息管理&gt; <span>添加考生成绩</span>
    </div>
    <div class="controlarea ">
        <div class="controltop">
            <p>
                搜索类型：<asp:DropDownList ID="searchTypeDDL" runat="server">
                    <asp:ListItem Value="0">课程名称</asp:ListItem>
                    <asp:ListItem Value="1">任课老师</asp:ListItem>
                </asp:DropDownList>
                &nbsp; 搜索关键词：<asp:TextBox ID="keyWordTB" runat="server" Width="175px"></asp:TextBox>
                &nbsp;
                <asp:Button ID="searchBtn" runat="server" Text="搜索" OnClick="searchBtn_Click" />
                &nbsp;<input id="searchAllBtn" type="button" value="显示全部" onclick="window.location.reload('examRecord.aspx');" />
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                    DataKeyNames="id" HorizontalAlign="Center" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                    BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="80%"
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                            Text="选择" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                </asp:GridView>
            </p>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="False" >
            <div class="controlcenter">
                <p>
                    <b>课程：<%=classNameStr %></b></p>
                <p>
                    <asp:FileUpload ID="excelFU" runat="server" Width="200px" />&nbsp;
                    <asp:Button ID="uploadBtn" runat="server" Text="上传成绩信息"
                        OnClick="uploadBtn_Click" /><br />
                    <b>成绩导入模板：</b><a href="download/成绩上传示例文档.xls">成绩上传示例文档.xls</a><br />
                    <b>上传注意事项：</b>请先下载导入模板，保存EXCEL模板时请确认文档中的数字都为字符串类型（可在数字前添加“'”符号）并保存为微软Excel 2003（.xls）格式。
                </p>
                <div class="controlleft">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
                        DataKeyNames="ID" OnRowCancelingEdit="GridView2_RowCancelingEdit" Width="80%"
                        OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating" OnRowEditing="GridView2_RowEditing">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="姓名" ReadOnly="True" />
                            <asp:BoundField DataField="SCORE" HeaderText="成绩" />
                            <asp:BoundField DataField="remark" HeaderText="备注" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    </asp:GridView>
                </div>
                <div class="controlright">
                    <p>
                        学生学号：
                        <asp:TextBox ID="stuIdTB" runat="server" Width="125px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"
                            MaxLength="50"></asp:TextBox>
                    </p>
                    <p>
                        学生成绩：
                        <asp:TextBox ID="scoreTB" runat="server" Width="125px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"
                            MaxLength="53"></asp:TextBox>
                    </p>
                    <p>
                        备注信息：
                        <asp:TextBox ID="remarkTB" runat="server" Width="125px" MaxLength="50"></asp:TextBox>
                    </p>
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="addBtn" runat="server" Text="添加成绩" OnClick="addBtn_Click" />
                    </p>
                </div>
            </div>
        </asp:Panel>
        <br />
    </div>
</asp:Content>
