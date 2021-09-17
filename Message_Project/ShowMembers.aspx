<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMembers.aspx.cs" Inherits="Message_Project.ShowMembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap-rtl.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/justified-nav.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

         <div id="header">
            <div id="header-inner" class="container">
                <div class="row">
                    <div class="col-md-6">
                        <img src="#" alt="daneshjooyar" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="container-inner">
                <div class="page-header">
                    <asp:Button ID="btn_back" runat="server" CssClass="btn btn-danger btn-xs" Text="بازگشت" OnClick="btn_back_Click" />
                    <div class="glyphicon glyphicon-user"><span>لیست دوستان  </span></div>
                </div>

                <div class="bs-example" data-example-id="thumbnails-with-custom-content">
                    <div class="row">
                   <asp:LinqDataSource ID="dsShowMemebers" runat="server" OnSelecting="dsShowMemebers_Selecting"  ></asp:LinqDataSource>
                        <asp:ListView runat="server" ID="lstShowListMembers" DataSourceID="dsShowMemebers"  >
                            <ItemTemplate>
                        <div class="col-sm-6 col-md-4">
                                    <div class="thumbnail" >
                                        <img  alt="" src="<%# "/UserImage/" + Eval("PicLocal") %>"   style="height: 100px; width: 100px; border:2px ; display: block;">
                                        
                                        <div class="caption">
                                            <h3 id="thumbnail-label"><%# Eval("Name") +" "+ Eval("Family") %><a class="anchorjs-link" href="#thumbnail-label"><span class="anchorjs-icon"></span></a></h3>
                                            <p  style="font-family:'B Homa';font-size:medium"><%# Eval("Username") %></p>
                                          <p><%# get_status_users(Eval("Logined")) %></p>
                                            
                                            <p>
                                                <a href="ShowMembers.aspx?AddFreind=<%#Eval("User_Id") %>" class="btn btn-success" >افزودن</a>
                                                &nbsp;&nbsp;&nbsp;
                                                <a  href="ShowMembers.aspx?SendReqFId=<%#Eval("User_Id") %>" class="btn btn-danger btn-xs" >ارسال درخواست دوستی </a>
                                              
                                            </p>
                                        </div>
                                    </div>
                               </div>
                                                                                                                        
                            </ItemTemplate>
                        </asp:ListView>
                       
                      
                    </div>
                </div>
                
            </div>
        </div>


    </form>
</body>
</html>
