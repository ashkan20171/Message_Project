<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="Message_Project.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Admin</title>
    <link href="Content/css/bootstrap-rtl.css" rel="stylesheet" />
    <link href="Content/css/demo.css" rel="stylesheet" />
    <link href="Content/css/justified-nav.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div id="header-inner" class="container">
                <div class="row">
                    <div class="col-md-6">
                        <img src="#" alt="دانشجویار" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="container-inner">
                <div class="page-header">
                    <div class="glyphicon glyphicon-user"><span class="fontyekan">  ورود مدیران</span></div>
                </div>
              
                 
                       

                <div class="row">
                    
                    <div class="col-md-6">
                     
                        <div class="form-group">
                            <div class="col-sm-8">
                                      <asp:Literal ID="litmsg" runat="server" ></asp:Literal>
                                <asp:Label ID="labe1" runat="server" Text="نام کاربری : "></asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-8">
                                <asp:Label ID="label2" runat="server" Text="کلمه عبور : "></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <br /> 
                        
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-8">
                                <asp:Button ID="btnLogin" runat="server" Text="ورود" CssClass="btn btn-success" OnClick="btnLogin_Click" /> &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <p>
                            شبکه اجتماعی دانشجویار
                            <br />
                            www.daneshjooyar.com
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
