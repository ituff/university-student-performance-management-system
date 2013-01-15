<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="Controler_about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="refresh" content="5" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" alt="" />
        成绩系统管理 &gt; <span>服务器运行状态</span>
    </div>
    <div class="controlarea ">
        <br />

        <p><b>南京工业大学工程硕士管理系统</b></p>
        <p><b>系统版本：</b>1.0.1 </p>
        <p><b>更新时间：</b>2010.12.10 14：17</p>
        <p><b>服务器IP：</b><%=Request.ServerVariables["LOCAL_ADDR"]%></p>
        <p><b>HTTP端口：</b><%=Request.ServerVariables["SERVER_PORT"]%></p>
        <p><b>服务器名：</b><%=Request.ServerVariables["SERVER_NAME"]%></p>
        <p><b>服务器域名 ：</b><% =Request.ServerVariables["SERVER_NAME"]%></p>
        <p><b>服务器时区：</b><% = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now -DateTime.UtcNow).TotalHours.ToString() : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString()%></p>
        <p><b>服务器时间：</b><%=DateTime .Now%></p>
        <p><b>CPU个数: </b><%=Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")%></p>
        <p><b>CPU类型: </b><%=Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")%></p>
        <p><b>操作系统信息：</b><%= Environment.OSVersion.ToString()%></p>
        <p><b>信息服务软件：</b><%=Request.ServerVariables["SERVER_SOFTWARE"]%></p>
        <p><b>虚拟服务绝对路径：</b><%= Request.ServerVariables["APPL_PHYSICAL_PATH"]%></p>
        <p><b>ASP.NET版本：</b><% =".NET CLR " + Environment.Version.ToString()%></p>
        <p><b>脚本超时时间 ：</b><% =Server.ScriptTimeout.ToString()%></p>
        <p><b>开机运行时长：</b><% =".NET CLR " + Environment.Version.ToString()%></p>
        <p><b>Session总数 ：</b><% = Session.Contents.Count.ToString()%></p>
        <p><b>Application总数 ：</b><% =  Application.Contents.Count.ToString()%></p>
        <p><b>应用程序缓存总数  ：</b><% =  Cache.Count.ToString()%></p>
        <p><b>应用程序占用内存  ：</b><% = ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M"%></p>
        <p><%= ramStatusStr%></p>
        <p><b>本页执行时间  ：</b><% = Server.ScriptTimeout.ToString() + "毫秒"%></p>
        <p><b>允许文件：</b><%=Request.ServerVariables["HTTP_ACCEPT"]%></p>
        <p><b>虚拟目录：</b><%=HttpContext.Current.Request.ApplicationPath%></p>
        <p><b>物理路径：</b><%=HttpRuntime.AppDomainAppPath%></p>
        <p><b>探针文件路径：</b><%=Context.Server.MapPath(Request.ServerVariables["SCRIPT_NAME"])%></p>
        <p><b>脚本超时时间：</b><%=Server.ScriptTimeout%>（秒）</p>
        <p><b>用户浏览器类型和版本：</b><%=Request.ServerVariables["HTTP_USER_AGENT"]%></p>

    </div>
</asp:Content>

