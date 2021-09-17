<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="RequestFriend.aspx.cs" Inherits="Message_Project.RequestFriend" %>
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
                       لیست درخواستهای دوستی 
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="container">



                                <%---------------------------------------------------------------%>

                                <div class="bs-example" data-example-id="thumbnails-with-custom-content">

                                    <div class="row">

                                        <asp:LinqDataSource ID="dsShowListReqFriend" runat="server" OnSelecting="dsShowListReqFriend_Selecting"></asp:LinqDataSource>
                                        <asp:ListView ID="lstShowListFreind" runat="server" DataSourceID="dsShowListReqFriend">
                                            <ItemTemplate>
                                                <div class="thumbnail" style="width: 170px; height: 130px">
                                                    <img class="img-thumbnail img-responsive img-circle" src="img/Add_Friend.png" style="height: 70px; width: 70px; border: 2px; display: block;">


                                                    <div>
                                                    ارسال توسط : <%#Eval("CurrentUser") %>  

                                                        <p>
                                                            <a href="RequestFriend.aspx?AcceptReq=<%#Eval("CurrentUser") %>" class="btn btn-success btn-sm">قبول</a>
                                                            &nbsp;&nbsp;
                                                                <a href="RequestFriend.aspx?DontAccept=<%#Eval("CurrentUser") %>" class="btn btn-danger btn-sm">رد کردن</a>
                                                        </p>

                                                    </div>



                                                </div>


                                            </ItemTemplate>
                                        </asp:ListView>


                                        <%--  <div class="thumbnail" style="width: 75px; height: 75px">
                                            <img alt="" src="img/yes.png" style="height: 25px; width: 25px; border: 2px; display: block;">
                                            <div class="caption">
                                                <h3 id="thumbnail-label"><a class="anchorjs-link" href="#thumbnail-label"><span class="anchorjs-icon"></span></a></h3>
                                                <asp:Literal ID="Literal1" Text="انلاين" runat="server"></asp:Literal>
                                                <p>
                                                    <a href="#" class="btn btn-success btn-xs">افزودن</a>
                                                </p>
                                            </div>
                                        </div>--%>
                                    </div>

                                </div>

                                <%---------------------------------------------------------------%>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <%----------------------------------------------------------------------%>

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
                        <a href="new.aspx">ارسال پیام </a>
                    </li>
                    <li>
                        <a href="Profile.aspx">شناسنامه </a>
                    </li>
                    <li>
                        <a href="trash.aspx">زباله دان</a>
                    </li>
                    <li >
                        <a href="Friends.aspx">لیست دوستان</a>
                    </li>
                     <li>
                        <a href="SendRequest.aspx">ارسال درخواست  </a>
                    </li>

                    <li class="active">
                        <a href="RequestFriend.aspx">لیست درخواستهای دوستی <%= get_count_friends() %></a>
                    </li>
                       <li>
                        <a href="AddPost.aspx">مدیریت مطالب</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>



    <%----------------------------------------------------------------------%>



</asp:Content>
