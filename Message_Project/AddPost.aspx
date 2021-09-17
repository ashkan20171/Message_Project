<%@ Page Title="" Language="C#" MasterPageFile="~/Message.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="Message_Project.AddPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Kendo%20UI/Scripts/jquery-1.9.1.min.js"></script>
    <script src="Kendo%20UI/Scripts/kendo/2014.1.318/kendo.web.min.js"></script>
    <link href="Kendo%20UI/Content/kendo/kendo.common.min.css" rel="stylesheet" />

    <link href="Kendo%20UI/Content/kendo/kendo.highcontrast.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {

            $(".styleKendo").kendoEditor();
        });
        $(document).ready(function () {

            $(".btnKendo").kendoButton();
        });

    </script>

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
                        ارسال و مدیریت مطالب
                    </div>
                    <div class="panel-body">
                        <asp:Button ID="btnAddPost" runat="server" Text="ارسال مطلب" CssClass="btnKendo" OnClick="btnAddPost_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="Post.aspx" runat="server" class="btnKendo" >رفتن به صفحه مطالب</a>

                        <br />
                        <br />
                        <asp:LinqDataSource ID="dsShowListPost" runat="server" OnSelecting="dsShowListPost_Selecting"></asp:LinqDataSource>
                        <asp:MultiView ID="mvShowListPost" ActiveViewIndex="0" runat="server">
                            <asp:View ID="vwShowListPost" runat="server">
                                <asp:GridView ID="grdShowListPost" runat="server" Width="100%" CssClass="table table-hover table-bordered table-responsive table-condensed" DataSourceID="dsShowListPost" OnRowCommand="grdShowListPost_RowCommand" AutoGenerateColumns="false" >
                                    <Columns>
                                        <asp:BoundField HeaderText="عنوان مطلب" DataField="Title" />
                                        <asp:BoundField HeaderText="تاریخ انتشار" DataField="Date" />
                                       <asp:TemplateField HeaderText="وضعیت مطلب">
                                           <ItemTemplate>
                                               <%# get_status_content( Eval("State")) %>
                                           </ItemTemplate>
                                       </asp:TemplateField>


                                        <asp:TemplateField HeaderText="عملیات">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="حذف" CssClass="btn btn-danger btn-xs" CommandName="DoDelete" CommandArgument='<%#Eval("PostId") %>'></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lbtnEdit" runat="server" Text="ویرایش" CssClass="btn btn-primary btn-xs" CommandName="DoEdit" CommandArgument='<%#Eval("PostId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:View>
                            <asp:View ID="vwAddPost" runat="server">

                                <div class="form-group">

                                    <label for="lblTitle">عنوان : </label>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="70%"></asp:TextBox>
                                    <br />
                                    <label for="lblContent"></label>
                                    <asp:TextBox ID="txtContent" TextMode="MultiLine" CssClass="styleKendo" runat="server" Width="70%"></asp:TextBox>

                                    <br />
                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <br />
                                    <label for="lblState">وضعیت انتشار : </label>
                                    <asp:CheckBox ID="chkState" runat="server" />
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="ثبت" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="انصراف" OnClick="btnCancel_Click" />
                                </div>

                            </asp:View>
                        </asp:MultiView>


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
                    <li class="active">
                        <a href="AddPost.aspx">مدیریت مطالب</a>
                    </li>
                </ul>
            </div>

        </div>
    </div>


</asp:Content>
