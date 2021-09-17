using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class SendRequest : System.Web.UI.Page
    {
        DataClasses1DataContext database=new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "ارسال درخواست";
            if (Session["Username"] == null)
            {
                //Response.Redirect("~/Default.aspx");
                Response.End();

            }
            getinformation();

        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx?Logout");
        }

        protected void btnShowMemebrs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowMembers.aspx?user=" + Session["Username"].ToString());
        }

        //
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

               //
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

        protected void btnSendReq_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text==string.Empty)
            {
                Alert.Show("لطفا عنوان درخواست را وارد نمایید");
                txtSubject.Focus();
                return;
            }
            if (txtContent.Text==string.Empty)
            {
                Alert.Show("لطفا متن درخواست را وارد نمایید");
                txtContent.Focus();
                return;
            }
            else
            {
                tbl_Request tbl_req = new tbl_Request()
                {
                    Sender=Session["Username"].ToString(),
                    Subject=txtSubject.Text,
                    Description=txtContent.Text,
                    Date="تاریخ : " +  Function.shamsidate() + "در ساعت : " + Function.date(),
                   Flag=false
                };
                database.tbl_Requests.InsertOnSubmit(tbl_req);
                database.SubmitChanges();
                lit_msg.Text = "<div class=\"alert alert-success\" role=\"alert\">پیغام شما با موفقیت ارسال گردید</div>";
                //
                txtContent.Text = string.Empty;
                txtSubject.Text = string.Empty;

            }
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