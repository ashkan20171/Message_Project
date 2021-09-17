<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Message_Project.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="textbox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btndec" runat="server" Text="Decode" OnClick="btndec_Click" /> <br />
        <asp:Label ID="lblshowpass" runat="server"></asp:Label>
        <h3>-----------------------------------------------</h3>
        
        <asp:TextBox ID="textbox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Decode" OnClick="Button1_Click" /> <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>

    </div>
        ------------------------------------------------

  
        <br />
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnHash" runat="server" OnClick="btnHash_Click" Text="Hash" />

  
    </form>
</body>
</html>
