<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeRecovery.aspx.cs" Inherits="Message_Project.TypeRecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/login-box.css" rel="stylesheet" type="text/css" />
    <style>
        .lbl {
            font-family: 'Comic Sans MS';
            font-size: 14px;
        }
    </style>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div style="padding: 100px 0 0 250px;">


            <div id="login-box">
                <asp:Literal ID="lit_msg" runat="server"></asp:Literal>

                <fieldset>



                    <legend style="font-family: 'Comic Sans MS';">باز یابی رمز عبور</legend>

                    <asp:Label ID="lblmsg" Font-Names="Comic Sans MS" runat="server" Text="نوع ارسال رمز عبور را انتخاب کنید"></asp:Label>
                    <br />
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:RadioButton ID="rdoSendByEmail" runat="server" AutoPostBack="true" CssClass="lbl" OnCheckedChanged="rdoSendByEmail_CheckedChanged" Text="Email" />
                            <br />
                            <br />
                            <asp:RadioButton ID="rdoSendBySms" runat="server" AutoPostBack="true" CssClass="lbl" OnCheckedChanged="rdoSendBySms_CheckedChanged" Text="SMS" />
                            <br />
                        </ContentTemplate>

                    </asp:UpdatePanel>
                    <br />
                    <center> 
    <asp:Label ID="label1" CssClass="lbl" runat="server">لطفا نام کاربری خود را وارد کنید</asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtUnameForRecPass" CssClass="form-control" runat="server" ></asp:TextBox>
    <br />
    <br />
    
        <asp:Button ID="btnNextStep" CssClass="btn btn-success" Text="مرحله بعدی" runat="server" OnClick="btnNextStep_Click" />
    </center>
                    <div id="login-box-name" style="margin-top: 20px;"></div>
                    <div id="login-box-field" style="margin-top: 20px;">

                        <br />
                        <br />

                    </div>
                    <span class="login-box-options"></span>

                </fieldset>
            </div>

        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    </form>
</body>
</html>
