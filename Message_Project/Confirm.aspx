<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="Message_Project.Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <link href="css/login-box.css" rel="stylesheet" type="text/css" />
    <style>
       .lbl
       {
           font-family:'B Homa';
           font-size:14px;

       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 
<div style="padding: 100px 0 0 250px;">


<div id="login-box">

<H4>Validation Code</H4>
برای ورود به حساب کاربری کد ارسال شده به شماره موبایل تان را وارد کنید
    <h3>We Send Code Valiation To : <asp:Literal ID="litMobile" runat="server"></asp:Literal></h3>
<br />
   
<br />
     <asp:Label runat="server" ID="msglogin"></asp:Label>

 <div id="login-box-name" style="margin-top:20px;"><asp:Label CssClass="lbl" runat="server">کد فعال سازی</asp:Label></div><div id="login-box-field" style="margin-top:20px;">
   <asp:TextBox ID="txt_confirm" runat="server" MaxLength="6" CssClass="form-login"></asp:TextBox>
       <br />
     <br />
     <asp:Button ID="btn_identity" runat="server" CssClass="btn btn-default" Text="Verify" OnClick="btn_identity_Click" />
      </div>
<span class="login-box-options">
</span>

</div>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    </form>
   
</body>
</html>
