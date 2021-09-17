using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project.AdminPanel
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dsShowListUsers_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from u in database.tbl_users
                        orderby u.User_Id descending
                        select new
                        {
                            u.User_Id,
                            u.Username,
                            u.Name,
                            u.Family,
                            u.Mobile,
                            u.Email,
                            u.PicLocal,
                            u.Flag
                        }).ToList();
        }

        protected void grdShowListUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoDelete":
                    {
                        int userid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_users.First(c => c.User_Id == userid);
                        database.tbl_users.DeleteOnSubmit(info);
                        database.SubmitChanges();
                        grdShowListUsers.DataBind();
                        break;
                    }
                case "DoEdit":
                    {
                        int userid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_users.First(c => c.User_Id == userid);
                        txtUsername.Text = info.Username;
                        txtName.Text = info.Name;
                        txtFamily.Text = info.Family;
                        txtMobile.Text = info.Mobile;
                        txtEmail.Text = info.Email;
                        database.SubmitChanges();
                        txtUsername.ReadOnly = true;
                        ViewState["userid"] = userid;
                        mvShowListUsers.SetActiveView(vwUpdateUsers);
                        break;
                    }
                case "DoTrue" :
                    {
                        int userid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_users.First(c => c.User_Id == userid);
                        info.Flag = true;
                        info.CountFailedLogin = 0;
                        database.SubmitChanges();
                        grdShowListUsers.DataBind();
                        break;
                    }
                case "DoFalse" :
                    {
                        int userid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_users.First(c => c.User_Id == userid);
                        info.Flag = false;
                        database.SubmitChanges();
                        grdShowListUsers.DataBind();
                        break;
                    }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null)
            {
                if (txtEmail.Text == string.Empty)
                {
                    Alert.Show("لطفا ایمیل خود را وارد نمایید");
                    return;
                }
                if (txtMobile.Text == string.Empty)
                {
                    Alert.Show("لطفا شماره موبایل خود را وارد نمایید");
                    return;
                }
                else
                {
                    int userid = int.Parse(ViewState["userid"].ToString());
                    var info = database.tbl_users.First(c => c.User_Id == userid);
                    info.Name = txtName.Text;
                    info.Family = txtFamily.Text;
                    info.Mobile = txtMobile.Text;
                    info.Email = txtEmail.Text;
                    database.SubmitChanges();
                    Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                }

            }
            else
            {
                //Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                Response.End();
            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }

        public string get_status_user(object flag)
        {
            bool status = bool.Parse(flag.ToString());
            if (status == true)
                return "<span style=\"color:green\">فعال</span>";
            else
                return "<span style=\"color:red\">غیر فعال</span>";
        }


    }
}