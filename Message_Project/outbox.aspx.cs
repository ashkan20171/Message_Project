using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Message_Project
{
    public partial class outbox : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                //Response.Redirect("~/Default.aspx");
                Response.End();

            }
            DAL dal = new DAL();
            dal.Connect();
            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "delete")
            {
                string msg_id = Request.QueryString["msg_id"].ToString();

                int deleted = dal.GetOne("select msg_deleted from tbl_message where msg_id=" + msg_id);
                if (deleted == 0)   // Sender Not Deleted Message
                {
                    dal.docommand("Update tbl_message SET msg_deleted=1 Where msg_id=" + msg_id);

                    Response.Redirect("~/outbox.aspx");
                }
                else
                {
                    dal.docommand("Delete from tbl_message where msg_id=" + msg_id);
                    Response.Redirect("~/outbox.aspx");
                }
            }

            string Query = "select * from tbl_message where msg_sender='{0}' AND msg_deleted <> 1 ";
            Query = string.Format(Query, Session["Username"]);
            
            SqlDataReader reader = dal.reader(Query);
            rep_outbox.DataSource = reader;
            rep_outbox.DataBind();
            dal.Disconnect();
            getinformation();
        }

        public string get_msg_status(object msg)
        {
            int Read = int.Parse(msg.ToString());
            if (Read == 1)
            {
                return "<span class='read'>خوانده شده</span>";
            }
            else
            {
                return "<span class='unread'>خوانده نشده</span>";
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

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            string uname = Session["Username"].ToString();
            var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);
            Session.Abandon();
            info.Logined = false;
            database.SubmitChanges();
 
            Response.Redirect("~/Default.aspx?Logout");
        }

        protected void btnShowMemebrs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowMembers.aspx?user=" + Session["Username"].ToString());
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