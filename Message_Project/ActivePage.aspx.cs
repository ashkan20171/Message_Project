using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class ActivePage : System.Web.UI.Page
    {
        DataClasses1DataContext database=new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"]==null || Request.QueryString["ActiveCode"]==null)
            {
                Response.End();
            }
            else
            {
                var AlreadyUser = database.tbl_users.Where(c => c.Username == Request.QueryString["Username"].ToString().Replace("'","") && c.ActiveCode == Request.QueryString["ActiveCode"].ToString().Replace("'",""));
                if (AlreadyUser.Count()==1)
                {
                    tbl_user t = database.tbl_users.First(c => c.Username == Request.QueryString["Username"].ToString());
                    t.ActiveMail = true;
                    database.SubmitChanges();
                    Response.Redirect("~/Default.aspx?Username=" + Request.QueryString["Username"] +" IsActivate=true");
                }
                else
                {
                    Response.Write("<span style=\"text-align:right;font-family:'B Homa';font-size:medium\">خطا</span>");

                }

            }
        }
    }
}