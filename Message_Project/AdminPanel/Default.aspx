<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Message_Project.AdminPanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <style type="text/css">
        .lbl
        {
            font-family:'B Homa';
            font-size:medium;

        }
        .dir
        {
            float:left;
            padding-top:10px;
        }

    </style>
    <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">پیشخوان</h3>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-success">
                                     <asp:Button ID="btnExit" CssClass="btn btn-danger btn-sm dir" Text="خروج از پنل مدیریت" runat="server" OnClick="btnExit_Click" />
                                    <div class="panel-heading">
                                        <h3 class="panel-title">اطلاعات کاربری </h3>
                                        
                                    </div>
                                    <div class="panel-body">
                                        <asp:Image ID="imgAdmin" runat="server" Width="85px" Height="70px" />
                                        <br />
                                        <br />
                                        <asp:Label ID="label1" runat="server" Text="خوش امدید : "></asp:Label>
                                        &nbsp;&nbsp;
                                      
                                        <asp:Label ID="lblFullname" runat="server" CssClass="lbl"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="label2" runat="server" Text="نام کاربری : "></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblUsername" runat="server" CssClass="lbl"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="اخرین ورود شما : "></asp:Label>&nbsp;&nbsp;
                                         <asp:Label ID="lblLastLogin" runat="server" CssClass="lbl"></asp:Label>



                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="label4" runat="server" Text="امروز :" CssClass="lbl"></asp:Label> &nbsp;&nbsp;
                                        <asp:Label ID="lblMyDay" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="label5" runat="server" Text="تاریخ :" CssClass="lbl"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                                    </div>
                               
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
