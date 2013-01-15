<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true"
    CodeFile="addClassList.aspx.cs" Inherits="Controler_addStudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        课程信息管理&gt; <span>批量导入课程</span></div>
    <div class="controlarea ">
        <br />
        <p>
            <asp:FileUpload ID="excelFU" runat="server" Width="200px" /></p>
        <p>
            <asp:Button ID="uploadBtn" runat="server" Text="上传课程信息" OnClick="uploadBtn_Click" /></p>
        <p>
            <b>课程导入模板：</b><a href="download/课程上传示例文档.xls">课程上传示例文档.xls</a></p>
             <p>
            <b>上传注意事项：</b>请先下载导入模板，保存EXCEL模板时请确认文档中的数字都为字符串类型（可在数字前添加“'”符号）并保存为微软Excel 2003（.xls）格式。<br/>
            其中：（1）开始和结束时间请以“yyyy/mm/dd  hh:mm:ss”格式写入；<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; （2）课程类别请用数字填写，并确保该类别已存在数据库中，目前数据库中存在的类别有下列：</p>
         <div style="margin-left:65px;margin-top:-10px;"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" DataSourceID="SqlDataSource1" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="课程类型编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="课程类型名称" SortExpression="name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [classType]"></asp:SqlDataSource></div>
    </div>
</asp:Content>
