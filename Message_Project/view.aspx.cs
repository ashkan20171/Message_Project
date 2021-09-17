using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Message_Project
{
    public partial class view : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                //Response.Redirect("~/Default.aspx");
                Response.End();

            }

            if(Request.QueryString["msg_id"] !=null)
            {
                string msg_id = Request.QueryString["msg_id"].ToString();
                DAL dal = new DAL();
                dal.Connect();
                SqlDataReader reader = dal.reader("select * from tbl_message where msg_id=" + msg_id);
                rep_view.DataSource = reader;
                rep_view.DataBind();
                reader.Close();
                dal.docommand("update tbl_message SET msg_read=1 where msg_id=" + msg_id);
                dal.Disconnect();
                    
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["msg_id"] !=null)
            {
                string msg_id = Request.QueryString["msg_id"].ToString();
                DAL dal = new DAL();
                dal.Connect();
                if (Request.QueryString["reciver"] != null)
                {
                    int deleted = dal.GetOne("select msg_deleted from tbl_message where msg_id=" + msg_id);
                    if (deleted == 0)   // Sender Not Deleted Message
                    {
                        dal.docommand("Update tbl_message SET msg_deleted=2 Where msg_id=" + msg_id);
                        Response.Redirect("~/inbox.aspx");
                    }
                    else
                    {
                        dal.docommand("Delete from tbl_message where msg_id=" + msg_id);
                        Response.Redirect("~/inbox.aspx");
                    }
                }
                  if (Request.QueryString["sender"] != null)
                  {
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

        public string get_count_friends()
        {
            string html = "";
            var count = (from a in database.tbl_FriendRequests where a.Flag == false && a.Fusername == Session["Username"].ToString() select a).Count();
            html = "<span class='badge pull-left'>" + count + "</span> ";
            return html;

        }

    }
}