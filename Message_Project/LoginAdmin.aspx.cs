using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security;
using System.Text;

namespace Message_Project
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        public static string AdminLogin, AdminLastLogin;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text==string.Empty)
            {
                Alert.Show("لطفا نام کاربری را وارد نمایید");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                Alert.Show("لطفا رمز عبور خود را وارد نمایید");
                txtPassword.Focus();
                return;
            }
            else
            {
                 // start code for operation Double Hash //
                HashAlgorithm hash = new MD5Cng();
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
                byte[] resultFinal = hash.ComputeHash(result);
                string Pass = Convert.ToBase64String(resultFinal);
                // end code for operation Double Hash //
                txtPassword.Text = Pass;

                var Qlogin = database.tbl_Admins.Where(c => c.Username == txtUsername.Text && c.Password == txtPassword.Text);
                AdminLogin=txtUsername.Text;
                if (Qlogin.Count() != 0)
                {
                    var info = database.tbl_Admins.First(c => c.Username == AdminLogin);
                    AdminLastLogin = info.LastLogin;
                    //start code for operation update last login
                    info.LastLogin = Function.shamsidate() + " " + Function.date();
                    database.SubmitChanges();
                    // end code for opeartion update last login
                    Session["Admin"] = info.Username;

                    //
                    Response.Redirect("/AdminPanel/Default.aspx?Login=" + AdminLogin);
                }
                else
                {
                    litmsg.Text = "<div class=\"alert alert-danger\" role=\"alert\" >نام کاربری یا رمز عبور اشتباه هست</div>";
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx?CancelLogin=true");
        }
    }
}