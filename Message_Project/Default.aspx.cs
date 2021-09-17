using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.Linq;
using System.Web.Security;
using System.Net;
using System.Net.Mail;


namespace Message_Project
{

    public partial class Default__ : System.Web.UI.Page
    {
        public static string mob;
        public static int ValidCode;
        //
        DataClasses1DataContext database = new DataClasses1DataContext();
        public static string Fullname, UserLastLogin;

        protected void ClearItems()
        {
            txt_email.Text = string.Empty;
            txt_family.Text = string.Empty;
            txt_mobile.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_userN.Text = string.Empty;

        }
        protected int getOnlineUserCountLogined()
        {
            int Onlinecount = (from a in database.tbl_users where a.Logined == true select a).Count();
            //int count = database.tbl_users.Count(c=> c.Logined==true);
            return Onlinecount;
        }
        protected int getMembers()
        {
            int Membercount = (from a in database.tbl_users select a).Count();
            //int count = database.tbl_users.Count();
            return Membercount;
        }
        protected string date()
        {
            DateTime dt = DateTime.Now;
            string time = dt.Hour.ToString("00:") + dt.Minute.ToString("00:") + dt.Second.ToString("00");
            return time;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Register"] != null)
            {
                panel_register.Visible = true;

            }

            litCountUsers.Text = Application["OnLineUserCount"].ToString() + " نفر";
            litMembers.Text = getMembers().ToString() + " نفر";
            litOnlineUsers.Text = getOnlineUserCountLogined().ToString() + " نفر";

        }

        MyWebService.Send sms = new MyWebService.Send();
        protected void btn_regsiter_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Register"] == "user")
            {

                if (txt_name.Text == string.Empty)
                {
                    Alert.Show("نام را وارد کنید");
                    txt_name.Focus();
                    return;
                }
                else if (txt_family.Text == string.Empty)
                {
                    Alert.Show("نام خانوادگی را وارد نمایید");
                    txt_family.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txt_userN.Text.Trim()))
                {
                    Alert.Show("نام کاربری را وارد نمایید");
                    txt_userN.Focus();
                    return;
                }
                if (txt_password.Text == string.Empty)
                {
                    //message.Text = "<div class=\"alert alert-danger\" role=\"alert\">لطفا رمز عبور را وارد نمایید</div>";
                    Alert.Show("لطفا رمز عبور را وارد نمایید");
                    txt_password.Focus();
                    return;
                }

                if (txt_pass2.Text != txt_password.Text)
                {
                    //message.Text = "<div class=\"alert alert-danger\" role=\"alert\">رمز عبور با هم مطابقت ندارد</div>";

                    Alert.Show("رمز عبور با هم مطابقت ندارد");
                    txt_password.Focus();
                    return;
                }
                if (txt_password.Text.Length <= 6)
                {
                    Alert.Show("رمز عبور باید بیشتر از 6 رقم باشد");
                    txt_password.Focus();
                    return;
                }
                else if (txt_mobile.Text == string.Empty)
                {
                    Alert.Show("لطفا شماره موبایل را وارد نمایید");
                    txt_mobile.Focus();
                    return;
                }
                else if (txt_email.Text == string.Empty)
                {
                    Alert.Show("لطفا ایمیل خود را وارد نمایید");
                    txt_email.Focus();
                    return;
                }
                else if (FileUpload1.HasFile == false)
                {
                    Alert.Show("لطفا عکس خود را انتخاب کنید");
                    return;
                }
                else
                {
                    string uName = txt_userN.Text.Trim();
                    string uMobile = txt_mobile.Text;
                    string uEmail = txt_email.Text;
                    //
                    var AlreadyUname = database.tbl_users.Where(c => c.Username == uName);
                    var AlreadyUmobile = database.tbl_users.Where(c => c.Mobile == uMobile);
                    var AlreadyUemail = database.tbl_users.Where(c => c.Email == uEmail);
                    //
                    if (AlreadyUname.Count() != 0)
                    {
                        msg_register.Text = "<div class=\"alert alert-danger\" role=\"alert\">نام کاربری وارد شده تکراری است</div>";
                        txt_userN.Focus();
                        return;
                    }
                    if (AlreadyUmobile.Count() != 0)
                    {
                        msg_register.Text = "<div class=\"alert alert-danger\" role=\"alert\">شماره موبایل وارد شده تکراری است</div>";
                        txt_mobile.Focus();
                        return;
                    }
                    if (AlreadyUemail.Count() != 0)
                    {
                        msg_register.Text = "<div class=\"alert alert-danger\" role=\"alert\">ایمیل وارد شده تکراری است</div>";
                        txt_email.Focus();
                        return;
                    }
                    else
                    {

                        string FileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
                        if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
                        {

                            if (FileExt != ".jpeg" && FileExt != ".png" && FileExt != ".jpg")
                            {
                                Alert.Show("فایل انتخاب شده مجاز نیست");
                                return;
                            }
                            if (FileUpload1.FileBytes.Length / 1024 > 500)
                            {

                                Alert.Show("عکس انتخاب شده بیش از 500 کیلو بایت می باشد");
                                return;
                            }
                            // Store Pic User in Host //
                            string imgname = FileUpload1.FileName;
                            string serverpath = Server.MapPath(Request.ApplicationPath) +
                                @"\UserImage\";
                            string picFilename = serverpath + txt_userN.Text + FileExt;
                            try
                            {
                                FileUpload1.SaveAs(picFilename);
                            }
                            catch
                            {
                                    
                            }

                            // Save Image User  Binary
                            byte[] filebyte = FileUpload1.FileBytes;
                            Binary obj = new Binary(filebyte);
                            //*********************
                            Random rand = new Random();
                            string ActivateCode = txt_userN.Text;
                            for (int i = 0; i < 10; i++)
                            {
                                ActivateCode += rand.Next(9);
                            }

                            tbl_user t = new tbl_user()
                            {
                                Email = txt_email.Text,
                                Family = txt_family.Text,
                                Mobile = txt_mobile.Text,
                                Name = txt_name.Text,
                                Password = Function.Encrypt(txt_password.Text),
                                Picture = obj,
                                Username = txt_userN.Text,
                                ActiveCode = ActivateCode,
                                ActiveMail = false,
                                TwoStepValidation = false,
                                Logined = false,
                                PicLocal = imgname,
                                Flag=true,
                                CountFailedLogin=0

                            };
                            database.tbl_users.InsertOnSubmit(t);
                            database.SubmitChanges();
                            msg_register.Visible = true;
                            // unit send message
                            //string message = "ثبت نام شما با موفقیت انجام شد\n" + "نام کاربری :" + txt_userN.Text.Trim() + "\n" + "گروه اموزشی دانشجویار";
                            //long[] recid = null;
                            //byte[] status = null;
                            //int ReturN = sms.SendSms("Username sms", "password sms", "number mobile", txt_mobile.Text.Split(new char[] { ',' }) /* Function.smsMobile.Split(new char[] { ',' }) */  , message, false, ref status, ref recid);
                            //
                            // unit send activare link to email

                            //MailMessage msg = new MailMessage();
                            //msg.From = new MailAddress("email form as ...");
                            //msg.To.Add(txt_email.Text);
                            //msg.Subject = "تکمیل ثبت نام";
                            //msg.Body = "<p style=\"text-align:right;font-family:'B Homa';font-size:medium\">جهت فعال سازی حساب کاربری بر روی لینک زیر کلیک نمایید<a href=" + Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "ActivePage.aspx?Username=" + txt_userN.Text + "&ActiveCode=" + ActivateCode + ">\nکلیک</a></p>";
                            //msg.IsBodyHtml = true;
                            //SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                            //smtp.Credentials = new NetworkCredential("Username Email", "Passwrord Email");
                            //smtp.EnableSsl = true;
                            //smtp.Send(msg);
                            //

                            msg_register.Text = "<div class=\"alert alert-success\" role=\"alert\">ثبت نام با موفقیت انجام شد<br>برای فعال سازی حساب کاربری به ایمیلتان مراجعه کنید </div>";
                            ClearItems();

                        }
                    }
                }
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">نام کاربری را وارد نمایید</div>";
                return;
            }
            if (txt_pass.Text == string.Empty)
            {
                msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">رمز عبور را وارد نمایید</div>";
                return;
            }
            var uname = txt_username.Text.Replace("'", "");
            var upass = txt_pass.Text.Replace("'", "");
            //******* Query LoginTwoStage ********//
            //string pw=txt_pass.Text;
            //pw = Function.Encrypt(txt_pass.Text);
            var Qlogin = database.tbl_users.Where(c => c.Username == uname && c.Password == Function.Encrypt(txt_pass.Text) && c.ActiveMail == true && c.TwoStepValidation == false);
            var QloginTwoStage = database.tbl_users.Where(c => c.Username == uname && c.Password == Function.Encrypt(txt_pass.Text) && c.ActiveMail == true && c.TwoStepValidation == true);
            var lockAccountbyAdmin = database.tbl_users.Where(c => c.Username == txt_username.Text && c.Flag == false && c.CountFailedLogin < 3);
            var QActiveFalseMail = database.tbl_users.Where(c => c.Username == txt_username.Text && c.ActiveMail == false);
            if (QActiveFalseMail.Count() !=0)
            {
                msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">لطفا حسابتان را فعال سازی کنید</div>";
                return;
            }
            if (lockAccountbyAdmin.Count() != 0)
            {
                msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">حساب کاربری شما توسط مدیر قفل شده است</div>";
                return;
            }
            else if (Qlogin.Count() != 0)
            {

                var Info = database.tbl_users.First(c => c.Username == uname);
                UserLastLogin = Info.LastLogin;
                string EMAIL = Info.Email;




                // send email with login //
                //try
                //{
                //    MailMessage msg = new MailMessage();
                //    msg.From = new MailAddress("Email From as");
                //    msg.To.Add(EMAIL);
                //    msg.Subject = "ورود به سایت";

                //    msg.Body = "<p style=\"text-align:right;font-family:'B Homa';font-size:medium\"> شما در تاریخ :  " + Function.shamsidate() + "در ساعت  :  " + date() + "وارد وب سایت شدید\"</p>" + "<br /><p style='color:blue;text-align:right;font-family:'B Homa';font-size:medium;'><a href=www.daneshjooyar.com>گروه اموزشی دانشجویار</a></p>";
                //    msg.IsBodyHtml = true;
                //    SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //    smtp.Credentials = new NetworkCredential("Username Email", "Password Email");
                //    smtp.EnableSsl = true;

                //    smtp.Send(msg);
                //}
                //catch
                //{
                //    Alert.Show("ورود شما به ایمیل ارسال نشد لطفا دوباره لاگین کنید");
                //    return;
                //}

                //
                Info.LastLogin = Function.shamsidate() + " " + Function.date();
                Session["Username"] = Info.Username;
                Info.Logined = true;
                Fullname = Info.Name + " " + Info.Family;
                database.SubmitChanges();

                //-----------Start Code for Save Cookie To Explorer -------------
                if (chkRememberMe.Checked == true && chkRememberMe != null)
                {
                    //HttpCookie cookie = new HttpCookie("Username", txt_username.Text);
                    //cookie.Expires.AddYears(1);
                    //Response.Cookies.Add(cookie);

                    Response.Cookies["Username"].Expires = DateTime.Now.AddDays(10);

                }
                else
                {
                    Response.Cookies["Username"].Expires = DateTime.Now.AddDays(1);

                }


                Response.Cookies["Username"].Value = txt_username.Text;
                Info.CountFailedLogin = 0;
                database.SubmitChanges();
                //-----------End Code for Save Cookie To Explorer -------------
                Response.Redirect("~/inbox.aspx?login=" + Session["Username"]);


            }
            else if (QloginTwoStage.Count() != 0)
            {
                var Information = database.tbl_users.First(c => c.Username == uname);
                Session["Username"] = Information.Username;
                mob = Information.Mobile;
                Random rnd = new Random();
                ValidCode = rnd.Next(1, 999999);
                //unit send validcode to mobile // 
                //string msg = "سلام کد تایید شما : " + ValidCode + "\n شبکه اجتماعی دانشجویار\n" + "http://www.daneshjooyar.com";
                //long[] recid = null;
                //byte[] status = null;
                //int ReturN = sms.SendSms(Function.smsUsername, Function.smsPassword, Function.smsNumber, mob.Split(new char[] { ',' }) /* Function.smsMobile.Split(new char[] { ',' }) */  , msg, false, ref status, ref recid);
                
                Response.Redirect("Confirm.aspx?username=" + Session["Username"]);
                //

            }


            else
            {
             //   msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">نام کاربری یا رمز عبور اشتباه هست</div>";

                var lockbyAdmin = database.tbl_users.Where(c => c.Username == txt_username.Text && c.Flag == false && c.CountFailedLogin < 3);
                if (lockbyAdmin.Count() != 0)
                {
                    msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">حساب کاربری شما توسط مدیر قفل شده است</div>";
                    return;
                }
                var lockAccount = database.tbl_users.Where(c => c.Username == txt_username.Text && c.Flag == false && c.CountFailedLogin > 3);
                if (lockAccount.Count() != 0)
                {
                    msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">حساب کاربری شما قبلا قفل شده است</div>";
                    return;
                }
                else
                {
                    msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">نام کاربری یا رمز عبور اشتباه هست</div>";
                    try
                    {
                        tbl_user t = database.tbl_users.First(c => c.Username == txt_username.Text);

                        t.CountFailedLogin += 1;
                        database.SubmitChanges();
                        if (t.CountFailedLogin > 3)
                        {
                            msg_login.Text = "<div class=\"alert alert-warning\" role=\"alert\"> حساب کاربری شما قفل شد</div>";
                            t.Flag = false;
                            database.SubmitChanges();
                        }
                    }
                    catch
                    {

                    }
                }
            }




            //************************************************************
            // login by ado.net & sql injection //

            //string login = "select * from tbl_users where Username='" + un + "'AND Password='" + upass + "'";
            //DataTable dt = new DataTable();
            //dt = Function.DoQeury(login);
            //if (dt.Rows.Count !=0)
            //{
            //    Response.Redirect("~/inbox.aspx");
            //}
            //else
            //{
            //    msg_login.Text = "<div class=\"alert alert-danger\" role=\"alert\">نام کاربری یا رمز عبور اشتباه هست</div>";
            //}

        }

        protected void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txt_password.TextMode = TextBoxMode.SingleLine;
                txt_pass2.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txt_password.TextMode = TextBoxMode.Password;
                txt_pass2.TextMode = TextBoxMode.Password;
            }
        }


    }
}