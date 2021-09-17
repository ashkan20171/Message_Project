using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class RecBySms : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        MyWebService.Send sms = new MyWebService.Send();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["un"] == null)
            {
                Response.Redirect("~/TypeRecovery.aspx");
            }
            string uname = Request.QueryString["un"].ToString();
            var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);
            //---- Get Number Mobile  -----//
            

              string InfoMobile=info.Mobile;
              string Infopass = Function.Decrypt(info.Password);
            //-------- Send Pass To Mobile By SMS -----///
              try
              {
                  string msg = "Username : " + uname + "\n رمز عبور شما : " + Infopass;

                  long[] recid = null;
                  byte[] status = null;
                  int ReturN = sms.SendSms("Username", "password", "number mobile", InfoMobile.Split(new char[] { ',' }) /* Function.smsMobile.Split(new char[] { ',' }) */  , msg, false, ref status, ref recid);
              }
            catch
              {
                  Alert.Show("خطا ! لطفا دوباره امتحان کنید");
                  Response.Redirect("~/TypeRecovery.aspx"); 
                  return;
              }
            //
              int a = int.Parse(info.Mobile.Substring(9, 2));
              litMobile.Text = "*********" + a.ToString();
        }
        //protected void mobile()
        //{
        //     string uname = Request.QueryString["un"].ToString();
        //    var info=database.tbl_users.FirstOrDefault(c=> c.Username==uname);
            
        //}
    }
}