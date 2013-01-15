<%@ Page Language="C#" AutoEventWireup="true" CodeFile="transcript.aspx.cs" Inherits="transcript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>南京工业大学硕士研究生成绩单</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h1 style="font-family: KaiTi;">南<span style="text-decoration: underline;">京工业大学硕士研究生成绩</span>单</h1>
            <table style="width: 800px; margin: 0px auto; text-align: center; border-width: 1px; border: solid; BORDER-COLLAPSE: collapse" border="1" cellspacing="0" bordercolor="#000000">
                <tr>
                    <td style="width: 73px; border: solid #000 1px;">学号</td>
                    <td colspan="2" style="width: 218px; border: solid #000 1px;"><%=stuIdStr %></td>
                    <td style="width: 72px; border: solid #000 1px;">姓名</td>
                    <td colspan="2" style="width: 145px; border: solid #000 1px;"><%=nameStr %></td>
                    <td style="width: 72px; border: solid #000 1px;">性别</td>
                    <td style="width: 72px; border: solid #000 1px;"><%=sexStr %></td>
                    <td style="width: 72px; border: solid #000 1px;">学制</td>
                    <td style="width: 72px; border: solid #000 1px;">3年</td>
                </tr>
                <tr>
                    <td style="width: 72px; border: solid #000 1px;">学院</td>
                    <td colspan="3" style="width: 200px; border: solid #000 1px;"><%=colleageStr %></td>
                    <td style="width: 72px; border: solid #000 1px;">专业</td>
                    <td colspan="5" style="width: 363px; border: solid #000 1px;"><%=majorStr %></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 180px; border: solid #000 1px;">入学日期</td>
                    <td colspan="3" style="width: 326px; border: solid #000 1px;"><%=schoolTimeStr %></td>
                    <td colspan="2" style="width: 145px; border: solid #000 1px;">导师姓名</td>
                    <td colspan="3" style="width: 218px; border: solid #000 1px;"></td>
                </tr>
                <tr>
                    <td style="width: 72px; border: solid #000 1px;">类别</td>
                    <td colspan="4" style="width: 273px; border: solid #000 1px;">课程名称</td>
                    <td style="width: 72px; border: solid #000 1px;">学时</td>
                    <td style="width: 72px; border: solid #000 1px;">学分</td>
                    <td style="width: 72px; border: solid #000 1px;">成绩</td>
                    <td colspan="2" style="width: 145px; border: solid #000 1px;">备注</td>
                </tr>
                <%=xueWeiKeStr %>
                <%=feiXueWeiKeStr  %>
                <tr>
                    <td colspan="2" style="width: 180px; border: solid #000 1px;">学术报告：</td>
                    <td colspan="3" style="width: 253px; border: solid #000 1px;"></td>
                    <td colspan="2" style="width: 145px; border: solid #000 1px;">学位课学分：</td>
                    <td style="width: 72px; border: solid #000 1px;"><%=xueWeiKeZongXueFenStr %></td>
                    <td style="width: 72px; border: solid #000 1px;">总学分：</td>
                    <td style="width: 72px; border: solid #000 1px;"><%=zongXueFenStr %></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 180px; font-size: 11pt; border: solid #000 1px;">学位课加权成绩：</td>
                    <td colspan="3" style="width: 253px; border: solid #000 1px;"><%=xueWeikeJiaQuanPingJunStr %></td>
                    <td colspan="2" style="width: 145px; border: solid #000 1px; font-size: 11pt;" rowspan="2">学校（盖章）：</td>
                    <td colspan="3" style="width: 145px; border: solid #000 1px;" rowspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 180px; border: solid #000 1px;">教学秘书签名：</td>
                    <td colspan="3" style="width: 253px; border: solid #000 1px;"></td>
                </tr>
            </table>
            <br />
            <p>
                <input type="button" id="buttony" name="print" value="确认打印" onclick="buttony.style.display = 'none'; window.print();" />
            </p>
        </div>
    </form>
</body>
</html>
