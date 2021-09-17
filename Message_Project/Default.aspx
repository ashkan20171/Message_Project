<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Message_Project.Default__" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  >
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title></title>
    <link href="css/bootstrap-rtl.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
  
</head>
    
<body style="width:auto">
   
    <form id="form1" runat="server">
          <div class="col-sm-12 col-md-12" >
              <a href="LoginAdmin.aspx" class="btn btn-danger btn-xs" >ورود مدیر</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              تعداد افراد حاضر در سایت : <asp:Literal ID="litCountUsers" runat="server"></asp:Literal>
              &nbsp;&nbsp;&nbsp;
              تعداد اعضا : <asp:Literal ID="litMembers"  runat="server"></asp:Literal>
              &nbsp;&nbsp;&nbsp;
              تعداد افراد آنلاین : <asp:Literal ID="litOnlineUsers" runat="server"></asp:Literal>
       <div class="panel panel-info">
           </div>
              </div>
        <div class="container">
            <div class="row">


<%--  --------------Guid WebForm Login-----------------%>
                <div class="col-sm-12 col-md-4">


                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            ورود کاربران
                        </div>
                        <div class="panel-body">
                            <asp:Literal ID="msg_login" runat="server">

                            </asp:Literal>
                            <div class="form-group">
                                <label for="txt_username">نام کاربری</label>
                                <asp:TextBox ID="txt_username" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txt_pass">کلمه عبور </label>
                                <asp:TextBox ID="txt_pass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkRememberMe" Text="RememberMe" runat="server" Checked="false" />
                            </div>
                            <asp:Button ID="btn_login" runat="server" Text="ورود" CssClass="btn btn-3 btn-3e icon-bar" OnClick="btn_login_Click" />
                            <br />

                            <a href="Default.aspx?Register=user"><span style="color: blue;">ثبت نام</span>

                            </a>
                            <br />
                            <a href="TypeRecovery.aspx"><span style="color: red">فراموشی رمز عبور</span></a>
                        </div>
                        <div class="panel-footer ">
                        </div>
                    </div>
                </div>


                <%--  --------------Guid WebForm Register-----------------%>

              <asp:Panel ID="panel_register" runat="server" Visible="false">
                <div class="col-sm-12 col-md-8" runat="server">
                    <div class="panel panel-primary">


                        <div class="panel-heading">
                            <span style="text-align: center">ثبت نام</span>
                        </div>

                        <div class="panel-body">
                            <asp:Literal ID="msg_register" runat="server">

                            </asp:Literal>
                            <div class="form-group">
                                <label for="txt_name">نام</label>
                                <asp:TextBox ID="txt_name" CssClass="form-control" runat="server" Width="236px"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label for="txt_family">نام خانوادگی</label>
                                <asp:TextBox ID="txt_family" CssClass="form-control" runat="server" Width="236px"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="txt_userN">نام کاربری </label>
                                <asp:TextBox ID="txt_userN" CssClass="form-control" runat="server" Width="236px"></asp:TextBox>
                            </div>
                            <div class="form-group">
                        <asp:CheckBox  ID="chkShowPass" runat="server" Text="نمایش رمز عبور"  OnCheckedChanged="chkShowPass_CheckedChanged" AutoPostBack="true" />
                                       <br />

                                <label for="txt_password">کلمه عبور </label> 
                                <asp:TextBox ID="txt_password" TextMode="Password"   CssClass="form-control" runat="server" Width="236px"></asp:TextBox>
                               
                                
                            </div>
                            <div class="form-group">
                                <label for="txt_pass2">تکرار رمز عبور </label>
                                <asp:TextBox ID="txt_pass2" TextMode="Password"   CssClass="form-control" Width="236px" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txt_email">ایمیل </label>
                                <asp:TextBox ID="txt_email" TextMode="Email" CssClass="form-control" Width="236px" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txt_mobile">موبایل</label>
                                <asp:TextBox ID="txt_mobile" CssClass="form-control" runat="server" Width="236px"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="FileUpload1">عکس</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />
                            </div>
                             <asp:Button ID="btn_regsiter"  runat="server" Text="ثبت نام" CssClass="btn btn-danger" OnClick="btn_regsiter_Click" />
                           
                            <br />
                        </div>
                        <div class="panel-footer ">
                        </div>
                    </div>
                </div>
               </asp:Panel>
                

            </div>
        </div>


    </form>
     <script src="js/bootstrap.min.js"></script>
</body>
</html>
