using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security;
using System.Text;

namespace Message_Project.AdminPanel
{
    public partial class Profile : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.End();
            }
            else
            {

                txtUsername.Text = Session["Admin"].ToString();
                txtUsername.ReadOnly = true;
                //
                //var info = database.tbl_Admins.First(c => c.Username == txtUsername.Text);
                //txtEmail.Text = info.Email;
                //txtName.Text = info.Name;
                //txtFamily.Text = info.Family;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                Alert.Show("لطفا نام خود را وارد نمایید");
                return;
            }
            if (txtFamily.Text == string.Empty)
            {
                Alert.Show("لطفا نام خانوادگی خود را وارد نمایید");
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                Alert.Show("لطفا ایمیل خود را وارد نمایید");
                return;
            }
            if (txtPass.Text == string.Empty)
            {
                Alert.Show("لطفا رمز عبور خود را وارد نمایید");
                return;
            }
            if (txtPass2.Text !=txtPass.Text)
            {
                Alert.Show("کلمه عبور با مطابقت ندارد");
                return;
            }
            else
            {
                // start code for operation Double Hash //
                HashAlgorithm hash = new MD5Cng();
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(txtPass.Text));
                byte[] resultFinal = hash.ComputeHash(result);
                string Pass = Convert.ToBase64String(resultFinal);
                // end code for operation Double Hash //

                // start code for operation update profile admin //
                tbl_Admin t = database.tbl_Admins.First(c => c.Username == txtUsername.Text);
                t.Name = txtName.Text;
                t.Family = txtFamily.Text;
                t.Email = txtEmail.Text;
                t.Password = Pass;
                database.SubmitChanges();
                litmsg.Text = "<div class=\"alert alert-success\" role=\"alert\">اطلاعات کاربری با موفقیت ویرایش گردید</div>";
                // end code for operation update profile admin //
            }

        }
    }
}