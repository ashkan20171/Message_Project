using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

using System.Security;
using System.Windows.Forms;
using System.ComponentModel;

using System.Security.Cryptography;
using System.Security;
using System.Text;
namespace Message_Project
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndec_Click(object sender, EventArgs e)
        {

            // lblshowpass.Text = Function.Encrypt2(textbox1.Text);
            //  lblshowpass.Text = Function.Decrypt2(textbox1.Text);
            //----------my formula ------------------
            //string a = "D41D8CD98F00B204E9800998ECF8427E110@n%105@i%109@m%100@d%97@a%";
            //int b = a.Length - 32;    // = 29
            //string x = a.Substring(32, b);
            //// string y=x.Substring(0,b);
            //lblshowpass.Text = x;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            HashAlgorithm hash = new MD5Cng();
            byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(txtPass.Text));
            byte[] resultFinal = hash.ComputeHash(result);
            lbl.Text = Convert.ToBase64String(resultFinal);
        }


    }
}