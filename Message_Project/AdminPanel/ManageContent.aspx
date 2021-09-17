<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageContent.aspx.cs" Inherits="Message_Project.AdminPanel.ManageContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
        <script src="../Kendo%20UI/Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Kendo%20UI/Scripts/kendo/2014.1.318/kendo.web.min.js"></script>
    <link href="../Kendo%20UI/Content/kendo/kendo.common.min.css" rel="stylesheet" />

    <link href="../Kendo%20UI/Content/kendo/kendo.highcontrast.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {

            $(".styleKendo").kendoEditor();
        });
 

    </script>

    <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">مدیریت مطالب کاربران</h3>
                    </div>
                    <div class="panel-body">
                        <asp:LinqDataSource ID="dsShowListContent" runat="server" OnSelecting="dsShowListContent_Selecting"></asp:LinqDataSource>
                        <asp:MultiView ID="mvShowListContent" runat="server" ActiveViewIndex="0">
                            <asp:View ID="vwShowContent" runat="server">
                                <asp:GridView ID="grdShowListContent" runat="server" DataSourceID="dsShowListContent" AutoGenerateColumns="false" OnRowCommand="grdShowListContent_RowCommand" CssClass="table table-bordered table-condensed table-hover table-responsive" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="عکس">
                                            <ItemTemplate>
                                                <asp:Image ID="imgContent" runat="server" ImageUrl='<%# "~/Upload/" +Eval("Picture") %>'  Width="90px" Height="60px"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="عنوان مطلب" DataField="Title" />
                                        <asp:BoundField HeaderText="ارسال کننده" DataField="Publisher" />
                                        <asp:BoundField HeaderText="تاریخ انتشار" DataField="Date" />
                                        <asp:TemplateField HeaderText="عملیات">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lbtnDelete" CssClass="btn btn-danger btn-xs" Text="حذف" CommandName="DoDelete" CommandArgument='<%# Eval("PostId") %>'></asp:LinkButton> &nbsp;
                                                <asp:LinkButton runat="server" ID="lbtnShowContent" CssClass="btn btn-success btn-xs" Text="مشاهده مطلب" CommandName="DoShow" CommandArgument='<%# Eval("PostId") %>'> </asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lbtnShowInfo" CssClass="btn btn-primary btn-xs" Text="اطلاعات ارسال کننده" CommandName="ShowInfoUser" CommandArgument='<%# Eval("Publisher") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                    
                            </asp:View>
                            <asp:View ID="vwShowDetailsPost" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <label for="lblTitle">عنوان</label>
                                                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-10">
                                                <label for="lblContent">متن مطلب</label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtContent" runat="server" CssClass="styleKendo"></asp:TextBox>

                                            </div>
                                        </div>
                                      
                                    </div>
                                     
                                </div>
                                <br />

                                 <asp:Button ID="btnBack" runat="server" Text="بازگشت"  CssClass="btn btn-danger" OnClick="btnBack_Click" />
                            </asp:View>

                            <asp:View ID="vwShowInfoUser" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <label for="lblImage">عکس کاربر</label>
                                                <asp:Image ID="imgUser" runat="server" Width="85px" Height="70px" />
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-md-6">
                                                <label for="lblUsername">نام کاربری</label>
                                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                              <div class="col-md-6">
                                                <label for="lblFullname">نام و نام خانوادگی</label>
                                                <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-md-6">
                                                <label for="lblEmail">ایمیل</label>
                                                <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-md-6">
                                                <label for="lblMobile">شماره موبایل</label>
                                                <asp:TextBox ID="txtMobile"  runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="بازگشت"  OnClick="btnCancel_Click"/>
                            </asp:View>
                        </asp:MultiView>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
