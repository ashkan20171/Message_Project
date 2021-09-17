<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Message_Project.view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row ">

                <div class="col-sm-9 col-md-9">
                
                <asp:Repeater ID="rep_view" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <%# Eval("msg_subject") %>
                            </div>
                            <div class="panel-body">
                                <%# Eval("msg_content") %>
                            </div>
                            <div class="panel-footer"></div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                
            </div>
             <asp:Button ID="btnDelete" Text="حذف این پیغام" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" />

            <div class="col-sm-3 col-md-3">

                <ul class="nav nav-pills nav-stacked">
                    <li class="active">
                        <a href="inbox.aspx">پیام های دریافتی
                            <%= get_unread_msg() %>
                        </a>

                    </li>
                    <li>
                        <a href="outbox.aspx">پیام های ارسالی</a>
                    </li>
                    <li>
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
