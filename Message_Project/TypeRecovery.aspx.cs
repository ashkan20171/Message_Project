using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project
{
    public partial class TypeRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdoSendByEmail_CheckedChanged(object sender, EventArgs e)
        {
          
                rdoSendBySms.Checked = false;
            
           
        }

        protected void rdoSendBySms_CheckedChanged(object sender, EventArgs e)
        {
            rdoSendByEmail.Checked = false;
        }

        protected void btnNextStep_Click(object sender, EventArgs e)
        {
            if (rdoSendByEmail.Checked==true && rdoSendBySms.Checked==false)
            {
                if (txtUnameForRecPass.Text=="")
                {
                    Alert.Show("لطفا نام کاربری را وارد نمایید");
                    return;
                }
                lit_msg.Text = "<div class=\"alert alert-danger\" role=\"alert\">در حال ارسال رمز عبور لطفا صبر کنید</div>";

                Response.Redirect("~/RecByEmail.aspx?un=" + txtUnameForRecPass.Text + "");
            }
            else if (rdoSendBySms.Checked==true && rdoSendByEmail.Checked==false)
            {
                if (txtUnameForRecPass.Text == "")
                {
                    Alert.Show("لطفا نام کاربری را وارد نمایید");
                    return;
                }
                lit_msg.Text = "<div class=\"alert alert-danger\" role=\"alert\">در حال ارسال رمز عبور لطفا صبر کنید</div>";
                Response.Redirect("~/RecBySms.aspx?un=" + txtUnameForRecPass.Text + "");
            }
            else
            {
                Alert.Show("لطفا یکی از گزینه ها را انتخاب کنید");
            }

                
        }
    }
}