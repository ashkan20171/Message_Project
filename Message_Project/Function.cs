using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Web.Security;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
namespace Message_Project
{
    public static class Function
    {

        // Method For Commands Select ****
        public static DataTable DoQeury(string Query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=BEHNAM;Initial Catalog=MsgDB;Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        // Method For Command Insert,Update,Delete , ...
        public static void DoDml(string Query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=BEHNAM;Initial Catalog=MsgDB;Integrated Security=True";
            SqlCommand cmd = new SqlCommand(Query, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //********* Get Shamsi Date
        public static string shamsidate()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string mydate = pc.GetYear(dt).ToString("0000/") + pc.GetMonth(dt).ToString("00/") + pc.GetDayOfMonth(dt).ToString("00");
            return mydate;
        }
        //********* Get Current Time 
        public static string date()
        {
            DateTime dt = DateTime.Now;
            string time = dt.Hour.ToString("00:") + dt.Minute.ToString("00:") + dt.Second.ToString("00");
            return time;
        }
        //********** Method For Encrypt Pass *************
        public static string Encrypt(string password)
        {
            char[] pass = password.ToCharArray();
            string[] symb = { "@", "#", "$", "%", "&" };
            Random rnd = new Random();
            string newpass = "";
            for (int i = pass.Length - 1; i >= 0; i--)
            {
                newpass += ((int)pass[i]).ToString() + symb[0] + pass[i] + symb[3];
            }
            return newpass;
        }

        //********** Method For Decrypt Pass *************
        public static string Decrypt(string password)
        {
            string[] tokens = password.Split('@', '#', '$', '%', '&');

            string pass = "";

            for (int i = tokens.Length - 2; i >= 0; i--)
            {
                pass += ((char)Convert.ToInt32(tokens[i])).ToString();
            }
            return pass;
        }

        //-------
        public static string Encrypt2(string password)
        {
            char[] pass = password.ToCharArray();

            string[] symb = { "@", "#", "$", "%", "&" };
            Random rnd = new Random();
            string newpass = "";
            string pw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");


            for (int i = pass.Length - 1; i >= 0; i--)
            {
                pw += ((int)pass[i]).ToString() + symb[0] + pass[i] + symb[3];
            }
            return pw;
        }

        //----------------
        public static string Decrypt2(string password)
        {
            string[] tokens = password.Split('@', '#', '$', '%', '&');
            //  string[] tokens = password.Split('@', '%');
            string pass = password;
            int b = pass.Length - 32;
            string x = pass.Substring(32, b);

            for (int i = tokens.Length - 2; i >= 0; i--)
            {
                x += ((char)Convert.ToInt32(tokens[i])).ToString();
            }
            return x;
        }

        //-------- My Formula //----
        /*            string a = "D41D8CD98F00B204E9800998ECF8427E110@n%105@i%109@m%100@d%97@a%";
            int b = a.Length - 32;    // = 29
            string x= a.Substring(32, b);
           // string y=x.Substring(0,b);
            lblshow
          */

        public static string RemoveHTMLTags(string content)
        {
            var cleaned = string.Empty;
            try
            {
                StringBuilder textOnly = new StringBuilder();
                using (var reader = XmlNodeReader.Create(new System.IO.StringReader("<xml>" + content + "</xml>")))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                            textOnly.Append(reader.ReadContentAsString());
                    }
                }
                cleaned = textOnly.ToString();
            }
            catch
            {
                //A tag is probably not closed. fallback to regex string clean.
                string textOnly = string.Empty;
                Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                Regex compressSpaces = new Regex(@"[\s\r\n]+");
                textOnly = tagRemove.Replace(content, string.Empty);
                textOnly = compressSpaces.Replace(textOnly, " ");
                cleaned = textOnly;
            }

            return cleaned;
        }
        



    }
}