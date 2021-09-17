using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class ShowMembers : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();


        //var stateOnline = from a in database.tbl_users where a.Logined == true select a;
        //var stateOffline = from b in database.tbl_users where b.Logined == false select b;
        //if (stateOnline.Count() != 0)
        //{
        //    string login;
        //    login = "<span style=\"color:green\">انلاین</span>";
        //    return login;
        //}
        //if (stateOffline.Count() != 0)
        //{
        //    string login2;
        //    login2 = "<span style=\"color:red\">افلاین</span>";
        //    return login2;
        //}
        //return "";
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Username"]==null)
           {
               Response.End();
           }

           string Curr_User=Session["Username"].ToString();
            if (Request.QueryString["AddFreind"]!=null)
            {
                int userid = int.Parse( Request.QueryString["AddFreind"].ToString());
                var AlreadyFr = database.tbl_Freinds.Where(c => c.FreindId == userid && c.CurrentUser==Curr_User);
                
                
                
                if (AlreadyFr.Count() != 0)
                {
                    Alert.Show("این کاربر قبلا به لیست دوستان اضافه شده است");
                    return;
                }
                else
                {

                    var info = database.tbl_users.First(c => c.User_Id == userid);
                    tbl_Freind t = new tbl_Freind()
                    {
                        FreindId = userid,
                        CurrentUser = Curr_User,
                        Username = info.Username,
                        Name = info.Name,
                        Family = info.Family,
                        Mobile = info.Mobile,
                        Online = true,
                        Email = info.Email,
                        Picture = info.PicLocal
                    };
                    database.tbl_Freinds.InsertOnSubmit(t);
                    database.SubmitChanges();
                    Alert.Show("کاربر با موفقیت به لیست دوستان اضافه شد"); 

                }
            }
            if (Request.QueryString["SendReqFId"] != null)
            {
                int user_idd = int.Parse(Request.QueryString["SendReqFid"].ToString());
                var Already = database.tbl_FriendRequests.Where(c => c.FriendId == user_idd && c.DoSendRequest == true);
                if (Already.Count() !=0)
                {
                    Alert.Show("شما قبلا به این کاربر درخواست دوستی داده اید");
                   
                    return;
                }
                else
                    {

                    var info=database.tbl_users.First(c=> c.User_Id==user_idd);
                    tbl_FriendRequest table = new tbl_FriendRequest()
                    {
                        CurrentUser=Curr_User,
                        FriendId=user_idd,
                        Fusername=info.Username,
                        Femail=info.Email,
                        Ffamily=info.Family,
                        Fmobile=info.Mobile,
                        Fname=info.Name,
                        Fpicture=info.PicLocal,
                        Flag=false,
                        DoSendRequest=true,

                    };
                    database.tbl_FriendRequests.InsertOnSubmit(table);
                    database.SubmitChanges();
                    Alert.Show("درخواست دوستی با موفقیت ارسال شد");

                    }
            }

        }

        protected void dsShowMemebers_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            string Curr_User = Session["Username"].ToString();
            e.Result = (from a in database.tbl_users
                        where a.Username != Curr_User
                        orderby a.Username ascending
                        select new
                        {
                            a.User_Id,
                            a.Username,
                            a.Name,
                            a.Family,
                            a.PicLocal,
                            a.Logined

                        }).ToList();

            //------------------
            //var info = (from a in database.tbl_users select a).First();

            //foreach (var a in database.tbl_users )
            //{
            //    if (info.Logined.ToString() == "True")
            //    {
            //        State = "<span style=\"color:green\">انلاین</span>";

            //    }



            //    else if (info.Logined.ToString() == "False")
            //    {
            //        State = "<span style=\"color:red\">افلاین</span>";
            //    }
            //}



        }

        public string get_status_users(object status_login)
        {
            bool status = bool.Parse(status_login.ToString());
            if (status == true)
                return "<span style=\"color:green\">انلاین</span>";
            else
                return "<span style=\"color:red\">افلاین</span>";
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("inbox.aspx?login=" + Session["Username"]);
        }



    }
}