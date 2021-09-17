using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project.AdminPanel
{
    public partial class ManageContent : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dsShowListContent_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_Posts
                        orderby a.PostId descending
                        select new
                        {
                            a.PostId,
                            a.Picture,
                            a.Date,
                            a.Title,
                            a.Publisher,
                            a.Content,
                        }).ToList();
        }

        protected void grdShowListContent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "DoDelete":
                    {
                        int postid = int.Parse(e.CommandArgument.ToString());
                        var QDelete = database.tbl_Posts.First(c => c.PostId == postid);
                        database.tbl_Posts.DeleteOnSubmit(QDelete);
                        database.SubmitChanges();
                        grdShowListContent.DataBind();

                        break;
                    }
                case "DoShow" :
                    {
                        int postid = int.Parse(e.CommandArgument.ToString());
                        var Info = database.tbl_Posts.First(c => c.PostId == postid);
                        txtTitle.Text = Info.Title;
                        txtContent.Text = Function.RemoveHTMLTags(Info.Content);
                        database.SubmitChanges();
                        mvShowListContent.SetActiveView(vwShowDetailsPost);
                        break;
                    }
                case "ShowInfoUser":
                    {
                        string publisher = e.CommandArgument.ToString();
                        var infoUser = database.tbl_users.First(c => c.Username == publisher);
                        txtEmail.Text = infoUser.Email;
                        txtFullname.Text = infoUser.Name + " " + infoUser.Family;
                        txtMobile.Text = infoUser.Mobile;
                        txtUsername.Text = publisher;
                        imgUser.ImageUrl = "~/UserImage/" + infoUser.PicLocal;
                        database.SubmitChanges();
                        mvShowListContent.SetActiveView(vwShowInfoUser);
                        break;

                    }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }
    }
}