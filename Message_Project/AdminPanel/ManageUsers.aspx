<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Message_Project.AdminPanel.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

    <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">مدیریت کاربران</h3>
                    </div>
                    <div class="panel-body">
                         <asp:LinqDataSource ID="dsShowListUsers" runat="server" OnSelecting="dsShowListUsers_Selecting"></asp:LinqDataSource>
                        <asp:MultiView ID="mvShowListUsers" runat="server" ActiveViewIndex="0" >
                            <asp:View ID="vwShowListUsers" runat="server">
                              
                                <asp:GridView ID="grdShowListUsers" runat="server" AutoGenerateColumns="false" DataSourceID="dsShowListUsers" CssClass="table table-hover table-condensed table-bordered table-responsive" OnRowCommand="grdShowListUsers_RowCommand" Width="100%">
                                    <Columns>

                                        <asp:TemplateField HeaderText="تصویر کاربر">
                                            <ItemTemplate>
                                                <asp:Image ID="imgUser" runat="server" ImageUrl='<%# "/UserImage/" + Eval("PicLocal") %>' Width="80px" Height="60px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Username" HeaderText="نام کاربری" />
                                        <asp:BoundField DataField="Name" HeaderText="نام" />
                                        <asp:BoundField DataField="Family" HeaderText="فامیلی" />
                                        <asp:BoundField DataField="Mobile" HeaderText="موبایل" />
                                        <asp:BoundField DataField="Email" HeaderText="ایمیل" />
                                        <asp:TemplateField HeaderText="وضعیت حساب کاربر">
                                            <ItemTemplate>
                                                <%# get_status_user(Eval("Flag")) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnTrue" Text="فعال" runat="server" CommandName="DoTrue" CommandArgument='<%#Eval("User_Id") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnFalse" Text="غیر فعال" runat="server" CommandName="DoFalse" CommandArgument='<%#Eval("User_Id") %>' CssClass="btn btn-danger btn-xs"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="عملیات">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbEdit" Text="ویرایش" runat="server" CssClass="btn btn-warning btn-xs" CommandArgument='<%#Eval("User_Id") %>' CommandName="DoEdit"></asp:LinkButton>
                                                <asp:LinkButton ID="lbDelete" Text="حذف" runat="server" CssClass="btn btn-danger btn-xs" CommandArgument='<%#Eval("User_Id") %>' CommandName="DoDelete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                          
                                    </Columns>

                                </asp:GridView>

                            </asp:View>

                            <asp:View ID="vwUpdateUsers" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <asp:Label ID="lblUsername" runat="server" Text="نام کاربری : "></asp:Label>
                                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-md-6">
                                                 <asp:Label ID="lblName" runat="server" Text=" نام : "></asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                             <div class="col-md-6">
                                                 <asp:Label ID="lblFamily" runat="server" Text="فامیلی : "></asp:Label>
                                                <asp:TextBox ID="txtFamily" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                             <div class="col-md-6">
                                                 <asp:Label ID="lblMobile" runat="server" Text="موبایل : "></asp:Label>
                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                             <div class="col-md-6">
                                                 <asp:Label ID="lblEmail" runat="server" Text="ایمیل : "></asp:Label>
                                                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="clearfix"></div>
                                            <br />
                                            <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="btn btn-success" OnClick="btnSave_Click" /> &nbsp;&nbsp;&nbsp;      
                                            <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                                
                            </asp:View>

                        </asp:MultiView>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
