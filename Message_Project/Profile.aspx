<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Message_Project.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .tgl {
            position: relative;
            display: inline-block;
            height: 30px;
            cursor: pointer;
        }

            .tgl > input {
                position: absolute;
                opacity: 0;
                z-index: -1;
                /* Put the input behind the label so it doesn't overlay text */
                visibility: hidden;
            }

            .tgl .tgl_body {
                width: 60px;
                height: 30px;
                background: white;
                border: 1px solid #dadde1;
                display: inline-block;
                position: relative;
                border-radius: 50px;
            }

            .tgl .tgl_switch {
                width: 30px;
                height: 30px;
                display: inline-block;
                background-color: white;
                position: absolute;
                left: -1px;
                top: -1px;
                border-radius: 50%;
                border: 1px solid #ccd0d6;
                -moz-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.13);
                -webkit-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.13);
                box-shadow: 0 2px 2px rgba(0, 0, 0, 0.13);
                -moz-transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, -moz-transform cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                -o-transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, -o-transform cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                -webkit-transition: left cubic-bezier(0.34, 1.61, 0.7, 1), -webkit-transform cubic-bezier(0.34, 1.61, 0.7, 1);
                -webkit-transition-delay: 250ms, 250ms;
                transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, transform cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                z-index: 1;
            }

            .tgl .tgl_track {
                position: absolute;
                left: 0;
                top: 0;
                right: 0;
                bottom: 0;
                overflow: hidden;
                border-radius: 50px;
            }

            .tgl .tgl_bgd {
                position: absolute;
                right: -10px;
                top: 0;
                bottom: 0;
                width: 55px;
                -moz-transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, right cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                -o-transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, right cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                -webkit-transition: left cubic-bezier(0.34, 1.61, 0.7, 1), right cubic-bezier(0.34, 1.61, 0.7, 1);
                -webkit-transition-delay: 250ms, 250ms;
                transition: left cubic-bezier(0.34, 1.61, 0.7, 1) 250ms, right cubic-bezier(0.34, 1.61, 0.7, 1) 250ms;
                background: #439fd8 url("/img/tgl_check.png") center center no-repeat;
            }

            .tgl .tgl_bgd-negative {
                right: auto;
                left: -45px;
                background: white url("/img/tgl_x.png") center center no-repeat;
            }

            .tgl:hover .tgl_switch {
                border-color: #b5bbc3;
                -moz-transform: scale(1.06);
                -ms-transform: scale(1.06);
                -webkit-transform: scale(1.06);
                transform: scale(1.06);
            }

            .tgl:active .tgl_switch {
                -moz-transform: scale(0.95);
                -ms-transform: scale(0.95);
                -webkit-transform: scale(0.95);
                transform: scale(0.95);
            }

            .tgl > :not(:checked) ~ .tgl_body > .tgl_switch {
                left: 30px;
            }

            .tgl > :not(:checked) ~ .tgl_body .tgl_bgd {
                right: -45px;
            }

                .tgl > :not(:checked) ~ .tgl_body .tgl_bgd.tgl_bgd-negative {
                    right: auto;
                    left: -10px;
                }
    </style>


    <%-----------------------------------------------------------------%>
    <div class="col-sm-12 col-md-12">
        <div class="panel panel-info">
            <asp:Image ID="Image1" runat="server" CssClass="img-rounded" BorderWidth="2px" Width="52px" Height="51px" />
            &nbsp;&nbsp; &nbsp;&nbsp;
           <asp:Label ID="Label1" runat="server" Text="خوش امدید :"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="lbl_fullname" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="نام کاربری : "></asp:Label>
            &nbsp;&nbsp; 
            <asp:Label ID="lbl_username" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="اخرین ورود شما :"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="lbl_LastLogin" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp; <a>
                <asp:Button ID="btn_exit" CssClass="btn btn-danger" runat="server" Text="خروج" Height="30px" Width="60px" OnClick="btn_exit_Click"></asp:Button></a>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:Button ID="btnShowMemebrs" runat="server" CssClass="btn btn-primary btn-xs" Text="جست و جوی کاربران" OnClick="btnShowMemebrs_Click" />



        </div>
    </div>
    <%------------------------------------------------------------%>
    <div class="container">
        <div class="row ">

            <div class="col-sm-9 col-md-9">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        ویرایش اطلاعات کاربری
                    </div>
                    <div class="panel-body">
                        <div class="form-group">

                            <asp:Literal ID="lit_msgUpdate" runat="server"></asp:Literal>

                            <label for="lbl_username">نام کاربری : </label>

                            <asp:TextBox ID="txt_username" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_name">نام : </label>

                            <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_family">نام خانوادگی :</label>

                            <asp:TextBox ID="txt_family" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_mobile">موبایل : </label>

                            <asp:TextBox ID="txt_mobile" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_email">ابمیل : </label>

                            <asp:TextBox ID="txt_email" TextMode="Email" runat="server" CssClass="text-left form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_pass">رمز عبور : </label>

                            <asp:TextBox ID="txt_pass" TextMode="Password" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                        <div class="form-group">
                            <label for="lbl_pass2">تکرار رمز عبور : </label>

                            <asp:TextBox ID="txt_pass2" TextMode="Password" runat="server" CssClass="form-control" Width="200px" />
                        </div>
                   
                  ورود 2 مرحله ای :  &nbsp;&nbsp;
                       
                <label class="tgl">
		<asp:CheckBox ID="chk_TwoStep" runat="server" Checked="false" />
		<span class="tgl_body">
			<span class="tgl_switch"></span>
			<span class="tgl_track">
				<span class="tgl_bgd"></span>
				<span class="tgl_bgd tgl_bgd-negative"></span>
			</span>
		</span>
	</label>
                        <br />
                        <br />

      
                        <asp:Button ID="btn_update" Text="ویرایش اطلاعات" runat="server" CssClass="btn btn-danger" Width="122px" OnClick="btn_update_Click" />
                    </div>
                    <div class="panel-footer"></div>

                </div>


            </div>
            <div class="col-sm-3 col-md-3">

                <ul class="nav nav-pills nav-stacked">
                    <li>
                        <a href="inbox.aspx">پیام های دریافتی
                              <%= get_unread_msg() %>
                        </a>
                    </li>
                    <li>
                        <a href="outbox.aspx">پیام های ارسالی</a>
                    </li>
                    <li>
                        <a href="new.aspx">ارسال پیام</a>
                    </li>
                    <li class="active">
                        <a href="Profile.aspx">شناسنامه </a>
                    </li>
                    <li>
                        <a href="trash.aspx">زباله دان</a>
                    </li>
                    <li>
                        <a href="Friends.aspx">لیست دوستان</a>
                    </li>
                     <li>
                        <a href="SendRequest.aspx">ارسال درخواست  </a>
                    </li>
                    <li>
                        <a href="RequestFriend.aspx">لیست درخواستهای دوستی<%= get_count_friends() %></a>
                    </li>
                       <li>
                        <a href="AddPost.aspx">مدیریت مطالب</a>
                    </li>
                </ul>
            </div>

        </div>
    </div>

</asp:Content>
