<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Message_Project.AdminPanel.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

    <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">ویرایش اطلاعات کاربری</h3>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Literal ID="litmsg" runat="server"></asp:Literal>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblUsername" runat="server" Text="نام کاربری : "></asp:Label>
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                      <div class="col-md-6">
                                        <asp:Label ID="lblName" runat="server" Text="نام : "></asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                  

                                      <div class="col-md-6">
                                        <asp:Label ID="lblFamily" runat="server" Text="نام خانوادگی : "></asp:Label>
                                        <asp:TextBox ID="txtFamily" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                  

                                      <div class="col-md-6">
                                        <asp:Label ID="lblEmail" runat="server" Text="ایمیل : "></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                      <div class="col-md-6">
                                        <asp:Label ID="lblPass" runat="server" Text="رمز عبور : "></asp:Label>
                                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
                                      <div class="col-md-6">
                                        <asp:Label ID="lblPass2" runat="server" Text="تکرار رمز عبور : "></asp:Label>
                                        <asp:TextBox ID="txtPass2" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    
                                    <div class="clearfix"></div>
                                   <br />

                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="ذخیره" OnClick="btnSave_Click" />
                                </div>
                                
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
