using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Message_Project.AdminPanel
{
    public partial class ManageRequest : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dsShowListRequest_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_Requests
                        orderby a.Reqid descending
                        select new
                        {
                            a.Reqid,
                            a.Sender,
                            a.Subject,
                            a.Description,
                            a.Date

                        }).ToList();
        }

        protected void grdShowListRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoDelete":
                    {
                        int reqid = int.Parse(e.CommandArgument.ToString());
                        var Qdelete = database.tbl_Requests.First(c => c.Reqid == reqid);
                        database.tbl_Requests.DeleteOnSubmit(Qdelete);
                        database.SubmitChanges();
                        grdShowListRequest.DataBind();
                        break;
                    }
                case "DoView" :
                    {
                        int reqid = int.Parse(e.CommandArgument.ToString());
                        var Info = database.tbl_Requests.First(c => c.Reqid == reqid);
                        txtSubject.Text = Info.Subject;
                        txtContent.Text = Info.Description;
                        database.SubmitChanges();
                        ViewState["ReqId"] = reqid;
                        mvShowListRequest.SetActiveView(vwShowMsg);
                        break;
                    }
                case "DoReply":
                    {
                        int reqid = int.Parse(e.CommandArgument.ToString());
                        var info = database.tbl_Requests.First(c => c.Reqid == reqid);
                        txtReciver.Text = info.Sender;
                        txtSubject2.Text = info.Subject;
                        database.SubmitChanges();
                        txtReciver.ReadOnly = true;
                        txtSubject2.ReadOnly = true;
                        ViewState["ReqId"] = reqid;
                        mvShowListRequest.SetActiveView(vwReply);
                        break;
                    }
            }
        }

        protected void btnDeleteThisMsg_Click(object sender, EventArgs e)
        {
            int requestid = int.Parse(ViewState["ReqId"].ToString());
            var Qdelete = database.tbl_Requests.First(c => c.Reqid == requestid);
            database.tbl_Requests.DeleteOnSubmit(Qdelete);
            database.SubmitChanges();
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSubject2.Text==string.Empty)
            {
                Alert.Show("عنوان درخواست نمیتواند خالی باشد");
                lit_msg.Text = string.Empty;
                return;
            }
            if (txtReciver.Text==string.Empty)
            {
                Alert.Show("دریافت کننده نمیتواند خالی باشد");
                lit_msg.Text = string.Empty;
                return;
            }
            if (txtReply.Text == string.Empty)
            {
                Alert.Show("لطفا متن پاسخ به درخواست را وارد کنید");
                lit_msg.Text = string.Empty;
                return;
            }
            else
            {
                var TrueReply = database.tbl_Requests.Where(c => c.Reqid == int.Parse(ViewState["ReqId"].ToString()) & c.Flag == true);
                if (TrueReply.Count() != 0)
                {
                    lit_msg.Text = "<div class=\"alert alert-danger\" role=\"alert\">شما قبلا پاسخ این درخواست را داده اید</div>";
                    return;
                }
                else
                {
                    tbl_Reply tb_reply = new tbl_Reply()
                    {
                        Subject = txtSubject2.Text,
                        Description = txtReply.Text,
                        Reciver = txtReciver.Text
                    };
                    database.tbl_Replies.InsertOnSubmit(tb_reply);
                    database.SubmitChanges();
                    //*******Start code for Update field [Flag]=True in tbl_request*****
                    tbl_Request t = database.tbl_Requests.First(c => c.Reqid == int.Parse(ViewState["ReqId"].ToString()) & c.Sender == txtReciver.Text);
                    t.Flag = true;
                    database.SubmitChanges();
                    //*******End code for Update field [Flag]=True in tbl_request*****
                    txtSubject2.Text = string.Empty;
                    txtReciver.Text = string.Empty;
                    txtReply.Text = string.Empty;
                    lit_msg.Text = "<div class=\"alert alert-success\" role=\"alert\">پاسخ شما با موفقیت ارسال گردید</div>";
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }     
    }
}