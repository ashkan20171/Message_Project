using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class AddPost : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();

        protected string today()
        {

            string myday = DateTime.Now.DayOfWeek.ToString();
            string day="";
            if (myday == DayOfWeek.Saturday.ToString())
                day = "شنبه";
            if (myday == DayOfWeek.Sunday.ToString())
                day = "یک شنبه";
            if (myday == DayOfWeek.Monday.ToString())
                day = "دوشنبه";
            if (myday == DayOfWeek.Tuesday.ToString())
                day = "سه شنبه";
            if (myday == DayOfWeek.Wednesday.ToString())
                day = "چهارشنبه";
            if (myday == DayOfWeek.Thursday.ToString())
                day = "پنج شنبه";
            if (myday == DayOfWeek.Friday.ToString())
                day = "جمعه";
            return day;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.End();
            }
            getinformation();
            
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

        protected void btnShowMemebrs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowMembers.aspx?user=" + Session["Username"].ToString());
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
        public string get_count_friends()
        {
            string html = "";
            var count = (from a in database.tbl_FriendRequests where a.Flag == false && a.Fusername == Session["Username"].ToString() select a).Count();
            html = "<span class='badge pull-left'>" + count + "</span> ";
            return html;

        }

        protected void dsShowListPost_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_Posts
                        orderby a.PostId descending
                        where a.Publisher == Session["Username"].ToString()
                        select new
                        {
                            a.PostId,
                            a.Title,
                            a.State,
                            a.Publisher,
                            a.Picture,
                            a.Date,
                            a.Content,
                        }).ToList();
        }

    

        protected void grdShowListPost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "DoDelete":
                    {
                        int postid = int.Parse(e.CommandArgument.ToString());
                        var QdeletePost = database.tbl_Posts.First(c => c.PostId == postid);
                        database.tbl_Posts.DeleteOnSubmit(QdeletePost);
                        database.SubmitChanges();
                        grdShowListPost.DataBind();
                        break;
                    }
                case "DoEdit":
                    {
                        
                        int postid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_Posts.First(c => c.PostId == postid);
                        txtContent.Text = Function.RemoveHTMLTags(info.Content);
                        txtTitle.Text = info.Title;
                        chkState.Checked =(bool)info.State;
                        database.SubmitChanges();
                        ViewState["PostId"] = postid;
                        mvShowListPost.SetActiveView(vwAddPost);
                        break;
                    }
            }
        }

        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            mvShowListPost.SetActiveView(vwAddPost);
            btnAddPost.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ViewState["PostId"] != null)
            {
                if (txtTitle.Text == string.Empty)
                {
                    Alert.Show("لطفا عنوان پست را وارد نمایید");
                    txtTitle.Focus();
                    return;
                }

                #region Upload Image
                string imgname = FileUpload1.FileName;
                if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
                {
                    string FileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
                    if (FileExt != ".png" && FileExt != ".jpg" && FileExt != ".jpeg" && FileExt != ".bmp" && FileExt != ".gif")
                    {
                        Alert.Show("فایل انتخاب شده مجاز نیست");
                        return;
                    }
                    int fileSize = FileUpload1.FileBytes.Length / 1024;
                    if (fileSize > 800)
                    {
                        Alert.Show("فایل انتخاب شده بیش از 800 کیلوبایت می باشد");
                        return;
                    }
                   
                    string ServerPath = Server.MapPath(Request.ApplicationPath) + @"\Upload\";
                    string picfilename = ServerPath + imgname;
                    try
                    {
                        FileUpload1.SaveAs(picfilename);
                    }
                    catch
                    {
                        Alert.Show("خطا در اپلود لطفا مجددا فایل را انتخاب و اپلود نمایید");
                    }
                }
                #endregion

                    int postid = int.Parse(ViewState["PostId"].ToString());
                    var PostStateTrue = database.tbl_Posts.Where(c => c.PostId == postid && c.State == true);
                    if (PostStateTrue.Count() != 0)
                    {
                        if (!FileUpload1.HasFile)  //=> if(FileUpload1.HasFile==false)
                        {
                            tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);
                            t.State = chkState.Checked;
                            t.Title = txtTitle.Text;
                            t.Content = txtContent.Text;
                            database.SubmitChanges();
                            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                        }
                        else
                        {
                            tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);
                            t.Picture = imgname;
                            t.State = chkState.Checked;
                            t.Title = txtTitle.Text;
                            t.Content = txtContent.Text;
                            database.SubmitChanges();
                            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                        }
                        //------
                    }
                    else
                    {
                        if (!FileUpload1.HasFile)  //=> if(FileUpload1.HasFile==false)
                        {
                            tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);
                            t.State = chkState.Checked;
                            t.Title = txtTitle.Text;
                            t.Content = txtContent.Text;
                            database.SubmitChanges();
                            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                        }
                        else
                        {
                            tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);

                            t.Picture = imgname;
                            t.State = chkState.Checked;
                            t.Title = txtTitle.Text;
                            t.Content = txtContent.Text;
                            t.Date = today() + " " + Function.shamsidate() + " " + Function.date();
                            database.SubmitChanges();
                            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                        }
                    }
            
            
                
            }
            else
            {
                if (txtTitle.Text == string.Empty)
                {
                    Alert.Show("لطفا عنوان پست را وارد نمایید");
                    txtTitle.Focus();
                    return;
                }
                string FileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
                if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
                {
                    if (FileExt != ".png" && FileExt != ".jpg" && FileExt != ".jpeg" && FileExt != ".bmp" && FileExt != ".gif")
                    {
                        Alert.Show("فایل انتخاب شده مجاز نیست");
                        return;
                    }
                    int fileSize = FileUpload1.FileBytes.Length / 1024;
                    if (fileSize > 800)
                    {
                        Alert.Show("فایل انتخاب شده بیش از 800 کیلوبایت می باشد");
                        return;
                    }
                    string imgname = FileUpload1.FileName;
                    string ServerPath = Server.MapPath(Request.ApplicationPath) + @"\Upload\";
                    string picfilename = ServerPath + imgname;
                    try
                    {
                        FileUpload1.SaveAs(picfilename);
                    }
                    catch
                    {
                        Alert.Show("خطا در اپلود لطفا مجددا فایل را انتخاب و اپلود نمایید");
                    }
                    //
                    tbl_Post table_post = new tbl_Post()
                    {
                        Title = txtTitle.Text,
                        Content = txtContent.Text,
                        Picture = imgname,
                        State = chkState.Checked,
                        Publisher = Session["Username"].ToString(),
                        Like = 0,
                        DisLike = 0,
                        Date = today() + " " + Function.shamsidate() + " " + Function.date()
                    };

                    database.tbl_Posts.InsertOnSubmit(table_post);
                    database.SubmitChanges();
                    Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());


                }
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }
        public string get_status_content(object flag)
        {
            bool status = bool.Parse(flag.ToString());
            if (status==true)
                return "<span style=\"color:green\" >منتشر شده</span>";
            else 
                return "<span style=\"color:red\" >پیش نویس</span>";
            

        }

    }
}