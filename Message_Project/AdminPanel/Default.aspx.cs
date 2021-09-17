using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project.AdminPanel
{
    public partial class Default : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();

      protected void Today()
        {
            string myday = DateTime.Now.DayOfWeek.ToString();
            if (myday == DayOfWeek.Saturday.ToString())
                lblMyDay.Text = "شنبه";
            else if (myday == DayOfWeek.Sunday.ToString())
                lblMyDay.Text = "یک شنبه";
            else if (myday == DayOfWeek.Monday.ToString())
                lblMyDay.Text = "دوشنبه";
            else if (myday == DayOfWeek.Tuesday.ToString())
                lblMyDay.Text = "سه شنبه";
            else if (myday == DayOfWeek.Wednesday.ToString())
                lblMyDay.Text = "چهارشنبه";
            else if (myday == DayOfWeek.Thursday.ToString())
                lblMyDay.Text = "پنج شنبه";
            else if (myday == DayOfWeek.Friday.ToString())
                lblMyDay.Text = "جمعه";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"]==null && Request.QueryString["Login"]==null)
            {
                Response.End();
            }
            else
            {
                var info = database.tbl_Admins.First(c => c.Username == Session["Admin"].ToString());
                lblFullname.Text = info.Name + " " + info.Family;
                lblUsername.Text = info.Username;
                lblLastLogin.Text = LoginAdmin.AdminLastLogin;
                imgAdmin.ImageUrl = "~/AdminImage/" + info.Image;
                //
                lbldate.Text = Function.shamsidate();
                Today();
             

            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/LoginAdmin.aspx?Logout=" + Session["Admin"]);
        }


    }
}