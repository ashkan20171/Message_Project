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

    public partial class RecbyEmail : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();

        protected string date()
        {
            DateTime dt = DateTime.Now;
            string time = dt.Hour.ToString("00:") + dt.Minute.ToString("00:") + dt.Second.ToString("00");
            return time;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["un"] == null)
            {
                Response.Redirect("~/TypeRecovery.aspx");
            }

            string uname = Request.QueryString["un"];
            try
            {
                var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);
                string InfoEmail = info.Email.ToString();
                string InfoPass = Function.Decrypt(info.Password);
            }
            catch
            {
                Alert.Show("نام کاربری وارد شده اشتباه می باشد");
                

            }
            //--------- Send Pass to Email -------------//

            // send email with login //
            //try
            //{
            //    MailMessage msg = new MailMessage();
            //    msg.From = new MailAddress("Email From as ...");
            //    msg.To.Add(InfoEmail);
            //    msg.Subject = "فراموشی رمز عبور";

            //    msg.Body = "<p style=\"text-align:right;font-family:'B Homa';font-size:medium\"> با سلام <br />\" "+"نام کاربری شما : " +  uname  + " <br /> رمز عبور شما : " + InfoPass + " \"</p>" + "<br /><p style='color:blue;text-align:right;font-family:'B Homa';font-size:medium;'><a href=www.daneshjooyar.com>گروه اموزشی دانشجویار</a></p>";
            //    msg.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //    smtp.Credentials = new NetworkCredential("Username Email", "Password Email");
            //    smtp.EnableSsl = true;

            //    smtp.Send(msg);
            //    lblmsg.Text = "<div class=\"alert alert-danger\" role=\"alert\">رمز عبور به ایمیل شما ارسال شد</div>";

            //}
            //catch
            //{
            //    Alert.Show("ورود شما به ایمیل ارسال نشد لطفا دوباره لاگین کنید");
            //    return;
            //}

            //------------------------------------------//



        }
    }
}