using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Message_Project
{
    public partial class _new : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "ارسال پیام جدید";
            if (Session["Username"] == null)
            {
                //Response.Redirect("~/Default.aspx");
                Response.End();

            }
            if (Request.QueryString["SendMsgTo"] != null)
            {

                string un = Request.QueryString["SendMsgTo"].ToString();
                txt_username.ReadOnly = true;
                txt_username.Text = un;
            
            }
            getinformation();
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == string.Empty)
            {
                Alert.Show("لطفا نام کاربری را وارد نمایید");
                return;

            }
             
            else
            {
                var QuserBlock = database.tbl_Blocks.Where(c => c.Username == txt_username.Text && c.IsBlock == true);

                if (QuserBlock.Count() != 0)
                {
                    var info = database.tbl_users.First(c => c.Username == txt_username.Text.Trim());
                    string blocker;
                    blocker = info.Name + " " + info.Family;

                    lit_msg.Text = "<div class=\"alert alert-danger\" role=\"alert\">شما توسط  " + blocker + " بلاک شده اید</div>";
                    return;
                }
                else
                {
                    string checkUser = "select * from tbl_users where username='" + txt_username.Text + "' ";
                    DataTable dt = new DataTable();
                    dt = Function.DoQeury(checkUser);
                    if (dt.Rows.Count != 0)
                    {
                        DAL dal = new DAL();
                        string Current_User = Session["Username"].ToString();
                        string Query = "insert Into tbl_message (msg_sender,msg_recipient,msg_subject,msg_content,date,msg_read,msg_deleted)";
                        Query += "values ('{0}','{1}','{2}','{3}','{4}',{5},{6})";
                        Query = string.Format(Query, Current_User, txt_username.Text.Trim(), txt_subject.Text, txt_content.Text, Function.shamsidate(), 0, 0);
                        dal.Connect();
                        dal.docommand(Query);
                        dal.Disconnect();
                        Response.Redirect("~/outbox.aspx");
                    }

                    else
                    {
                        Alert.Show("فردی با این نام کاربری وجود ندارد");
                        return;
                    }
                }
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
            Session.Abandon();
            Response.Redirect("~/Default.aspx?Logout");
        }

        protected void txt_username_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selEmail = "select * from tbl_users where username='" + txt_username.Text + "'";
                DataTable dt = new DataTable();
                dt = Function.DoQeury(selEmail);
                if (dt.Rows.Count != 0)
                {
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                }
                else
                {
                    txtEmail.Text = "";
                }
            }
            catch
            {
                Alert.Show("خطایی رخ داده است لطفا دوباره امتحان کنید");
            }
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