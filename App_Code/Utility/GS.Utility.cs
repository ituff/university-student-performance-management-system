using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace GS.Utility
{

    /// <summary>
    ///Utility 的摘要说明
    /// </summary>
    public class Tools
    {
        public static bool authentication(System.Web.UI.Page page, string type)
        {
            try
            {
                if ((page.Session["status"] == null) || (!page.Session["status"].Equals("true")))
                {
                    page.Response.Redirect("logout.aspx");
                    return false;
                }
                if ((page.Session["type"] == null) || (!page.Session["type"].Equals(type)))
                {
                    page.Response.Redirect("logout.aspx");
                    return false;
                }
            }
            catch
            {
                page.Response.Redirect("logout.aspx");
                return false;
            }
            return true;
        }

        public static bool authentication(System.Web.UI.Page page, string type,string type2)
        {
            try
            {
                if ((page.Session["status"] == null) || (!page.Session["status"].Equals("true")))
                {
                    page.Response.Redirect("logout.aspx");
                    return false;
                }
                if ((page.Session["type"] == null) || ((!page.Session["type"].Equals(type)) &&  (!page.Session["type"].Equals(type2))) )
                {
                    page.Response.Redirect("logout.aspx");
                    return false;
                }
            }
            catch
            {
                page.Response.Redirect("logout.aspx");
                return false;
            }
            return true;
        }

        public static string encrypt(string password)
        {
            ///获取Byte数组
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
            ///获取Hash值
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            ///获取加密后的信息
            return BitConverter.ToString(hashedBytes);
        }

        public static string getTextBoxText(TextBox tb)
        {
            return Tools.safeUserInput(tb.Text.Trim().ToString());
        }

        public static DataSet ExecleDs(string filenameurl, string table)
        {
            string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            DataSet ds = new DataSet();
            odda.Fill(ds, table);
            return ds;
        }

        public string filtRiskChar(string str) //过滤非法字符
        {
            string s = "";

            s = str.Replace("'", " ");
            s = s.Replace(";", " ");
            s = s.Replace("1=1", " ");
            s = s.Replace("|", " ");
            s = s.Replace("<", " ");
            s = s.Replace(">", " ");

            return s;
        }

        // 检测字符串中是否有非法的字符，如果有，返回true
        public static bool ChkBadWord(string badword)
        {
            string[] bw = strbadword();
            bool isok = false;
            foreach (string str in bw)
            {
                if (badword.IndexOf(str) > -1)
                {
                    isok = true;
                    return isok;
                }

            }
            return isok;
        }
        private static string[] strbadword()
        {
            string[] bad = new string[15];
            bad[0] = "'";
            bad[1] = "\"";
            bad[2] = ";";
            bad[3] = "--";
            bad[4] = ",";
            bad[5] = "!";
            bad[6] = "~";
            bad[7] = "@";
            bad[8] = "#";
            bad[9] = "$";
            bad[10] = "%";
            bad[11] = "^";
            bad[12] = "&";
            bad[13] = "  ";
            bad[14] = "_";
            return bad;
        }

   


        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        /// 
        public static string safeUserInput(string str){
            return CheckSql(ReplaceBadSQL(str));
    
    }

        public static string ReplaceBadSQL(string str)
        {
            string str2 = "";
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string str1 = str;
            string[] strArray = new string[] { "'", "--" };
            StringBuilder builder = new StringBuilder(str1);
            for (int i = 0; i < strArray.Length; i++)
            {
                str2 = builder.Replace(strArray[i], "").ToString();
            }
            return builder.Replace("@@", "@").ToString();
        }

        public static string CheckSql(string str)
        {
            string s = string.Empty;
            if (str == null)
            {
                s = string.Empty;
            }
            else
            {
                s = str.Replace("'", "").Replace("*", "").Replace("select", "")
                       .Replace("where", "").Replace(";", "").Replace("(", "").Replace(")", "").Replace("drop", "").Replace("DROP", "").Replace("and", "").Replace("or", "").Replace("delete", "").Replace("asc", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace(";", "").Replace("&", "").Replace("*", "").Replace(" ", "");
            }
            return s;
        }

    }



}