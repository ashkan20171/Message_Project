using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class Friends : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.End();
            }

            if (Request.QueryString["DeleteUserId"] != null)
            {
                int userid = int.Parse(Request.QueryString["DeleteUserId"].ToString());
                var QDeleteFr = database.tbl_FriendRequests.First(c => c.FriendId == userid);
                database.tbl_FriendRequests.DeleteOnSubmit(QDeleteFr);
                database.SubmitChanges();
                Alert.Show("دوست مورد نظر با موفقیت حذف گردید");

            }
            if (Request.QueryString["BlockUser"]!=null)
            {
                int userid = int.Parse(Request.QueryString["BlockUser"].ToString());
                var info = database.tbl_users.First(c => c.User_Id == userid);
                string un;
                un = info.Username;
                //
                var AlreadyUn = database.tbl_Blocks.Where(c => c.UserId == userid && c.IsBlock==true);
                if (AlreadyUn.Count() !=0)
                {
                    tbl_Block t = database.tbl_Blocks.First(c => c.UserId == userid);
                    t.IsBlock = true;
                    database.SubmitChanges();
                    Alert.Show("این کاربر قبلا بلاک شده است");
                    return;
                }
                else
                {
                   
                    tbl_Block table = new tbl_Block()
                    {
                        UserId=userid,
                        Username=Session["Username"].ToString(),
                        IsBlock=true,
                        UserBlock=un,
                    };
                    database.tbl_Blocks.InsertOnSubmit(table);
                    database.SubmitChanges();
                    Alert.Show("کاربر با موفقیت بلاک گردید");
                }
               
            }
            else if (Request.QueryString["Unblock"] != null)
            {
                int userid=int.Parse( Request.QueryString["Unblock"].ToString());
             //   var prevUnblock = database.tbl_Blocks.Where(c => c.UserId == userid && c.IsBlock == false);
                
                var Qalreadyuser = database.tbl_Blocks.Where(c => c.UserId == userid && c.IsBlock == true);
                //
                //if (prevUnblock.Count() !=0)
                //{
                //    Alert.Show("این کاربر بلاک نمی باشد");
                //    return;
                //}
               if (Qalreadyuser.Count() !=0)
                {
                    var delete = database.tbl_Blocks.First(c => c.UserId == userid);
                    database.tbl_Blocks.DeleteOnSubmit(delete);
                    database.SubmitChanges();
                    Alert.Show("کاربر با موفقیت از حالت بلاک بیرون امد");
                }
               else
               {
                   Alert.Show("این کاربر بلاک نمی باشد");
                   return;
               }


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

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            string uname = Session["Username"].ToString();
            var info = database.tbl_users.FirstOrDefault(c => c.Username == uname);

            info.Logined = false;
            database.SubmitChanges();
            //Session.Abandon();

            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), true);

            Response.Redirect("~/Default.aspx?Logout");
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

        protected void dsShowListFreind_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_FriendRequests
                   
                        where a.CurrentUser == Session["Username"].ToString() && a.Flag==true
                        orderby a.FriendId ascending
                        select new
                            {
                                a.FriendId,
                                a.Fusername,
                                a.Fname,
                                a.Ffamily,
                                a.Fpicture
                            }).ToList();
        }
        public string get_count_friends()
        {
            string html = "";
            var count = (from a in database.tbl_FriendRequests where a.Flag == false && a.Fusername == Session["Username"].ToString() select a).Count();
            html = "<span class='badge pull-left'>" + count + "</span> ";
            return html;

        }

        protected void dsBlockUser_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_Blocks
                        where a.Username == Session["Username"].ToString()
                        select new
                        {
                            a.Username,
                            a.UserId,
                            a.UserBlock,
                            a.IsBlock,
                        }).ToList();

        }
        
    }
}