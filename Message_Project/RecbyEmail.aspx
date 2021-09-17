<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecbyEmail.aspx.cs" Inherits="Message_Project.RecbyEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <link href="css/login-box.css" rel="stylesheet" type="text/css" />
    <style>
       .lbl
       {
           font-family:'Comic Sans MS';
           font-size:14px;
           color:white;
           

       }
    </style>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
<div style="padding: 100px 0 0 250px;">


<div id="login-box">
<fieldset>  
    
        
    
    <legend style="font-family:'Comic Sans MS';">بازیابی به وسیله ایمیل</legend>
    
 
    <br />
    <br />

    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <br />

    <a href="Default.aspx" class="lbl">بازگشت به صفحه ورود</a>
    
    
    
 <div id="login-box-name" style="margin-top:20px;"></div>
    <div id="login-box-field" style="margin-top:20px;">
 
       <br />
     <br />
 
      </div>
<span class="login-box-options">
</span>
    
    </fieldset>
</div>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    </form>
</body>
</html>
