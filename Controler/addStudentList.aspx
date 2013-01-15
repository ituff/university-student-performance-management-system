<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="addStudentList.aspx.cs" Inherits="Controler_addStudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        学生信息管理&gt; <span>批量导入学生</span></div>
    <div class="controlarea ">
        <br />
        <p>
            <asp:FileUpload ID="excelFU" runat="server" Width="200px" /></p>
        <p>
            <asp:Button ID="uploadBtn" runat="server" Text="上传学生信息" OnClick="uploadBtn_Click" /></p>
        <p>
            <b>学生导入模板：</b><a href="download/学生上传示例文档.xls">学生上传示例文档.xls</a></p>
             <p>
            <b>上传注意事项：</b>请先下载导入模板，保存EXCEL模板时请确认文档中的数字都为字符串类型（可在数字前添加“'”符号）并保存为微软Excel 2003（.xls）格式。</p>
    </div>
</asp:Content>
