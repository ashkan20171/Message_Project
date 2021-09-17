<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="new.aspx.cs" Inherits="Message_Project._new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-sm-12 col-md-12">
       <div class="panel panel-info">
           <asp:Image ID="Image1" runat="server" CssClass="img-rounded" BorderWidth="2px"  Width="52px" Height="51px" />
            &nbsp;&nbsp; &nbsp;&nbsp;
           <asp:Label ID="Label1" runat="server" Text="خوش امدید :"></asp:Label>
           &nbsp;&nbsp;<asp:Label ID="lbl_fullname" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="نام کاربری : "></asp:Label>
            &nbsp;&nbsp;  <asp:Label ID="lbl_username" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="اخرین ورود شما :"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="lbl_LastLogin" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp; <a> <asp:Button ID="btn_exit" CssClass="btn btn-danger" runat="server" Text="خروج" Height="30px" Width="60px" OnClick="btn_exit_Click" ></asp:Button></a>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:Button ID="btnShowMemebrs" runat="server" CssClass="btn btn-primary btn-xs" Text="جست و جوی کاربران" OnClick="btnShowMemebrs_Click" />
        </div>
            </div>

    <div class="container">
        <div class="row ">

            <div class="col-sm-9 col-md-9">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       افزودن و مدیریت مطالب ارسالی
                    </div>
                    <div class="panel-body">
                        <asp:Literal ID="lit_msg" runat="server"></asp:Literal>
                        <div class="form-group">
                            <label for="lbl_username">نام کاربری : </label>
                            
                            <asp:TextBox ID="txt_username" runat="server" CssClass="form-control"  Width="200px" OnTextChanged="txt_username_TextChanged" AutoPostBack="true"    /> &nbsp;&nbsp;
                            
                            
                            <br />
                            <label for="txtEmail">Email : </label>
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                          <div class="form-group">
                            <label for="lbl_subject">موضوع :  </label>
                            
                            <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control"  Width="400" />
                        </div>
                         <div class="form-group">
                            <label for="lbl_content">متن</label>
                            
                            <asp:TextBox ID="txt_content" TextMode="MultiLine" Height="200px" runat="server" CssClass="form-control" Width="368px" />
                        </div>
                        <asp:Button ID="btn_send" Text="ارسال" runat="server" CssClass="btn btn-danger" OnClick="btn_send_Click" Width="80px" />
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
                    <li class="active">
                        <a href="new.aspx">ارسال پیام </a>
                    </li>
                     <li>
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
