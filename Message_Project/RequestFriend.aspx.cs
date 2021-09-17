using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class RequestFriend : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["AcceptReq"] !=null)
            {
                string Requer = Request.QueryString["AcceptReq"].ToString();
                tbl_FriendRequest t = database.tbl_FriendRequests.First(c => c.CurrentUser == Requer);
                t.Flag = true;
                database.SubmitChanges();
            }
            if (Request.QueryString["DontAccept"] != null)
            {
                string Requer = Request.QueryString["DontAccept"].ToString();
                var DelRequest = database.tbl_FriendRequests.First(c => c.CurrentUser == Requer);
                database.tbl_FriendRequests.DeleteOnSubmit(DelRequest);
                database.SubmitChanges();
                Alert.Show("درخواست دوستی با موفقیت لغو گردید");
            }

            getinformation();
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

        protected void btnShowMemebrs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowMembers.aspx?user=" + Session["Username"].ToString());
        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            string uname = Session["Username"].ToString();
            var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);

            info.Logined = false;
            database.SubmitChanges();
            

            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), true);

            //Session.Abandon();

            Response.Redirect("~/Default.aspx?Logout");

        }

        protected void dsShowListReqFriend_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_FriendRequests orderby a.FriendId ascending where a.Fusername==Session["Username"].ToString() && a.Flag==false
                        select new
                        {
                            a.FriendId,
                            a.CurrentUser,
                            
                        }).ToList();
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