<%@ Page Title="" Language="C#" MasterPageFile="~/MasterContent.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Message_Project.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <style>
        .align-left
        {
            float:left;
            text-align:left;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">صفحه مطالب</h3>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <asp:LinqDataSource ID="dsShowPosts" runat="server" OnSelecting="dsShowPosts_Selecting"></asp:LinqDataSource>
                            <asp:ListView ID="lstViewShowPost" runat="server" DataSourceID="dsShowPosts" OnItemCommand="lstViewShowPost_ItemCommand">
                                <ItemTemplate>
                                    <div class="col-md-10">
                                <div class="panel panel-success">
                                   

                                    <div class="panel-heading">
                                        <h3 class="panel-title"><%# Eval("Title") %></h3>
                                        <asp:LinkButton ID="lbtnDisLike"  CssClass="btn btn-danger btn-sm align-left" runat="server" CommandName="DisLike" CommandArgument='<%# Eval("Postid") %>'><%# Eval("DisLike") %></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="lbtnLike" runat="server" CssClass="btn btn-success btn-sm align-left" CommandName="AddLike" CommandArgument='<%# Eval("Postid") %>'> <%# Eval("Like") %> +</asp:LinkButton>
                             
                                    </div>
                                    <div class="panel-body">
                                        <asp:Image ID="imgPost" BorderWidth="1px"  BorderStyle="Dotted"   ImageUrl='<%#"/Upload/" + Eval("Picture") %>' ImageAlign="Middle"  runat="server" Width="46%" Height="129px" />
                                        <br />
                                        <br />
                                        <%--<asp:Label ID="lblContent" runat="server"> </asp:Label>--%>
                                        <p>
                                           <%# RemoveHTMLTags( Eval("Content").ToString()) %>
                                        </p>
                                  
                                   
                                        <br />
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="label4" runat="server" >منتشر شده در تاریخ :<%#Eval("Date") %> </asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
                                     
                                        <asp:Label ID="label5" runat="server">توسط :<%# Eval("Publisher") %> </asp:Label>&nbsp;&nbsp;
                                     
                                    </div>
                               
                                </div>

                            </div>
                                </ItemTemplate>
                            </asp:ListView>
                           

                            
                        </div>
                        <%--// صفحه بندی مطالب--%>
                        <div style="padding-right:350px">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="2" PagedControlID="lstViewShowPost">
                            <Fields>
                                <asp:NextPreviousPagerField ShowNextPageButton="false"  />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                            </div>
                        <%--// صفحه بندی مطالب--%>
                  
                    </div>
                </div>
            </div>
        </div>
    </div>



        </ContentTemplate>
    </asp:UpdatePanel>
   


</asp:Content>
