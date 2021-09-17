using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.End();
            }
            txt_username.Enabled = false;
            // 
            var info = database.tbl_users.First(c => c.Username == Session["Username"].ToString());
            txt_username.Text = info.Username.ToString();
            //txt_email.Text = info.Email.ToString();
            //txt_family.Text = info.Family.ToString();
            //txt_mobile.Text = info.Mobile.ToString();
            //txt_name.Text = info.Name.ToString();
         //   chk_TwoStep.Checked = (bool)info.TwoStepValidation;
           // txt_username.Text = Session["Username"].ToString();
            getinformation();

        }
        public void getinformation()
        {
            string uname = Session["Username"].ToString();

            var Qlogin = database.tbl_users.Where(c => c.Username == uname && c.TwoStepValidation == false);
            var QloginTwoStage = database.tbl_users.Where(c => c.Username == uname && c.TwoStepValidation == true);
            if (Qlogin.Count() != 0)
            {
                lbl_fullname.Text = Message_Project.Default__.Fullname;
                lbl_username.Text = uname; // Session["Username"].ToString();
                lbl_LastLogin.Text = Message_Project.Default__.UserLastLogin;
                Image1.ImageUrl = "~/Handler1.ashx?login=" + Session["Username"];
            }
            else if (QloginTwoStage.Count() != 0)
            {
                lbl_fullname.Text = Confirm.FullName.ToString();
                lbl_username.Text = uname;
                lbl_LastLogin.Text = Confirm.LastLogin.ToString();
                Image1.ImageUrl = "~/Handler1.ashx?login=" + Session["Username"];
            }


        }
        public string get_unread_msg()
        {
            string html = "";
            DAL dal = new DAL();
            dal.Connect();
            string Current_User = Session["Username"].ToString();
            string query = string.Format("select COUNT(msg_id) from tbl_message where msg_recipient='{0}' AND msg_read=0", Current_User);
            int row = dal.GetOne(query);
            if (row > 0)
            {
                html = "<span class='badge pull-left'>" + row + "</span> ";
            }
            dal.Disconnect();
            return html;

        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            string uname = Session["Username"].ToString();
            var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);
            Session.Abandon();
            info.Logined = false;
            database.SubmitChanges();
 
            Response.Redirect("~/Default.aspx?Logout");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_name.Text==string.Empty)
            {
                Alert.Show("نام را وارد کنید");
                txt_name.Focus();
                return;
            }
           if (txt_family.Text==string.Empty)
           {
               Alert.Show("نام خانوادگی را وارد نمایید");
               txt_family.Focus();
               return;
           }
            if (txt_mobile.Text==string.Empty)
            {
                Alert.Show("شماره مویایل را وارد نمایید");
                txt_mobile.Focus();
                return;
            }
            if (txt_email.Text==string.Empty)
            {
                Alert.Show("ایمیل خود را وارد نمایید ");
                txt_email.Focus();
                return;
            }
         
         
            if (txt_pass.Text == string.Empty)
            {
                string uname = Session["Username"].ToString();
                tbl_user t = database.tbl_users.First(c => c.Username == uname);
                t.Email = txt_email.Text;
                t.Family = txt_family.Text;
                t.Mobile = txt_mobile.Text;
                t.Name = txt_name.Text;
                t.TwoStepValidation = chk_TwoStep.Checked;
                database.SubmitChanges();
                getinformation();
                lit_msgUpdate.Text = "<div class=\"alert alert-success\" role=\"alert\">اطلاعات پروفایل با موفقیت ویرایش شد</div>";
                return;
            }
            else if (txt_pass.Text !=string.Empty)
            {

                if (txt_pass2.Text != txt_pass.Text)
                {
                    Alert.Show("رمز عبور با هم مطابقت ندارد");
                    txt_pass.Focus();
                    return;
                }

                string uname = txt_username.Text;
                tbl_user t = database.tbl_users.First(c => c.Username == uname);
                t.Email = txt_email.Text;
                t.Family = txt_family.Text;
                t.Mobile = txt_mobile.Text;
                t.Name = txt_name.Text;
                t.TwoStepValidation = chk_TwoStep.Checked;
                t.Password = Function.Encrypt(txt_pass.Text);
                database.SubmitChanges();
                getinformation();
                lit_msgUpdate.Text = "<div class=\"alert alert-success\" role=\"alert\">اطلاعات پروفایل با موفقیت ویرایش شد</div>";
                return;
                 
            }
        }

        protected void btnShowMemebrs_Click(object sender, EventArgs e)
        {

        }
        public string get_count_friends()
        {
            string html = "";
            var count = (from a in database.tbl_FriendRequests where a.Flag == false && a.Fusername == Session["Username"].ToString() select a).Count();
            html = "<span class='badge pull-left'>" + count + "</span> ";
            return html;

        }
    }
}