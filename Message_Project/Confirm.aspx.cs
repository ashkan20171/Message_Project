using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Message_Project
{
    public partial class Confirm : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        public static string FullName, LastLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["username"] == null)
            {
                Response.End();
            }
          //  Response.Write(Default__.ValidCode);
            mobile();
        }

        protected void btn_identity_Click(object sender, EventArgs e)
        {
            if (txt_confirm.Text == Default__.ValidCode.ToString())
            {
                msglogin.Text = "<span style=color:white;font-family:'B Homa'>در حال ورود...</span>";

                string uname = Request.QueryString["username"].ToString();
                var Information = database.tbl_users.First(c => c.Username == uname);
                FullName = Information.Name.ToString() + " " + Information.Family.ToString();
                LastLogin = Information.LastLogin.ToString();

                string email = Information.Email;
                // send email with login //
                //try
                //{
                //    MailMessage msg = new MailMessage();
                //    msg.From = new MailAddress("Email form as ...");
                //    msg.To.Add(email);
                //    msg.Subject = "ورود به سایت";

                //    msg.Body = "<p style=\"text-align:right;font-family:'B Homa';font-size:medium\"> شما در تاریخ :  " + Function.shamsidate() + "در ساعت  :  " + Function.date() + "وارد وب سایت شدید\"</p>" + "<br /><p style='color:blue;text-align:right;font-family:'B Homa';font-size:medium;'><a href=www.daneshjooyar.com>گروه اموزشی دانشجویار</a></p>";
                //    msg.IsBodyHtml = true;
                //    SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //    smtp.Credentials = new NetworkCredential("Username Email","Password Email");
                //    smtp.EnableSsl = true;
                //    smtp.Send(msg);
                //}
                //catch
                //{
                //    Alert.Show("ایمیل ورود به سایت ارسال نشد لطفا دوباره امتحان کنید ");
                //    return;
                //}
                //
                // Update date & time lastlogin & Reset CountFailedLogin

                Information.LastLogin = Function.shamsidate() + " " + Function.date();
                Information.CountFailedLogin = 0;
                database.SubmitChanges();
               
               
                Response.Redirect("~/inbox.aspx?login=" + uname);
            }
            else
            {
                Alert.Show("کد وارد شده اشتباه می باشد");
                return;
            }
        }
        protected void mobile()
        {
            int a = int.Parse(Default__.mob.Substring(9, 2));
            litMobile.Text = "*********" + a.ToString();
        }
    }
}