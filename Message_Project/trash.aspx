<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="trash.aspx.cs" Inherits="Message_Project.trash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

    <div class="container">
        <div class="row ">

            <div class="col-sm-9 col-md-9">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        پیام های پاک شده
                    </div>
                    <div class="panel-body">
                        <asp:Repeater ID="rep_trash" runat="server">
                            <HeaderTemplate>
                                <table id="table_outbox" class="table table-bordered table-hover table-responsive">
                                    <tr>
                                        <th>ارسال کننده
                                        </th>
                                        <th>عنوان پیام
                                        </th>
                                        <th>پیام
                                        </th>

                                        <th>عملیات
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("msg_sender") %>
                                    </td>
                                    <td>
                                        <a href="view.aspx?sender=1&msg_id=<%# Eval("msg_id") %>">
                                            <%# Eval("msg_subject") %>
                                        </a>
                                    </td>
                                    <td>
                                        <%# Eval("msg_content") %>
                                    </td>

                                    <td>
                                        <a href="trash.aspx?action=delete&msg_id=<%# Eval("msg_id") %>">
                                            <img src="img/delete.png" />
                                        </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="panel-footer"></div>
                </div>
            </div>

            

            <div class="col-sm-3 col-md-3">

                <ul class="nav nav-pills nav-stacked">
                    <li>
                        <a href="inbox.aspx">پیام های دریافتی                                 <%= get_unread_msg() %>
<%get_unread_msg(); %></a>
                    </li>
                    <li>
                        <a href="outbox.aspx">پیام های ارسالی</a>
                    </li>
                    <li>
                        <a href="new.aspx">ارسال پیام</a>
                    </li>
                    <li>
                        <a href="Profile.aspx">شناسنامه</a>
                    </li>
                    <li class="active">
                        <a href="trash.aspx">زباله دان</a>
                    </li>
                    <li>
                        <a href="Friends.aspx">لیست دوستان</a>
                    </li>
                     <li>
                        <a href="SendRequest.aspx">ارسال درخواست  </a>
                    </li>
                    <li>
                        <a href="RequestFriend.aspx"> لیست درخواستهای دوستی<%= get_count_friends() %></a>
                    </li>
                       <li>
                        <a href="AddPost.aspx">مدیریت مطالب</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
