<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageRequest.aspx.cs" Inherits="Message_Project.AdminPanel.ManageRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="container">
        <div class="container-inner">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel panel-heading">
                        <h3 class="panel-title">مدیریت درخواستهای کاربران</h3>
                    </div>
                    <div class="panel-body">
                       
                        <asp:LinqDataSource ID="dsShowListRequest" runat="server" OnSelecting="dsShowListRequest_Selecting"></asp:LinqDataSource>
                        <asp:MultiView ID="mvShowListRequest" runat="server" ActiveViewIndex="0">
                            <asp:View ID="vwShowListRequest" runat="server">
                                <asp:GridView ID="grdShowListRequest" runat="server" DataSourceID="dsShowListRequest" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-hover table-responsive" Width="100%" OnRowCommand="grdShowListRequest_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="ارسال کننده" DataField="Sender" />
                                        <asp:BoundField HeaderText="موضوع" DataField="Subject" />
                                        <asp:BoundField HeaderText="تاریخ ارسال" DataField="Date" />

                                        <asp:TemplateField HeaderText="عملیات">
                                            <ItemTemplate >
                                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="حذف" CssClass="btn btn-danger btn-xs" CommandArgument='<%#Eval("Reqid") %>' CommandName="DoDelete"></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnReply" runat="server" Text="پاسخ" CssClass="btn btn-success btn-xs" CommandArgument='<%#Eval("Reqid") %>' CommandName="DoReply"></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnView" runat="server" Text="مشاهده" CssClass="btn btn-primary btn-xs" CommandArgument='<%#Eval("Reqid") %>' CommandName="DoView"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:View>
                            <asp:View ID="vwShowMsg" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <label for="lblSubject">عنوان : </label>
                                                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                       
                                           <div class="clearfix"></div>
                                            <br />
                                            <div class="col-md-6">
                                                <label id="lblContent">متن درخواست : </label>
                                                <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="clearfix"></div>
                                        <br />
                                      
                                   
                                        <asp:Button ID="btnDeleteThisMsg" runat="server" Text="حذف این درخواست" CssClass="btn btn-danger"  OnClick="btnDeleteThisMsg_Click"/>                                    
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="بازگشت" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="vwReply" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:Literal ID="lit_msg" runat="server"></asp:Literal>
                                            <div class="col-md-6">

                                                <label for="lblSubject2">عنوان : </label>
                                                <asp:TextBox ID="txtSubject2" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                            <div class="clearfix"></div>
                                            <br />
                                            <div class="col-md-6">
                                                <label  for="lblReciver">دریافت کننده : </label>
                                                <asp:TextBox ID="txtReciver" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clearfix"></div>
                                            <br />
                                            <div class="col-md-6">
                                                <label for="lblContent2">متن پاسخ شما : </label>
                                                <asp:TextBox ID="txtReply" runat="server" CssClass="form-control" TextMode="MultiLine" Width="395px" Height="200px"></asp:TextBox>
                                            </div>
                                           <div class="clearfix"></div>
                                            <br />
                                            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-success" Text="ارسال پاسخ" OnClick="btnSend_Click" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnback" runat="server" Text="بازگشت" CssClass="btn btn-primary" OnClick="btnback_Click" />
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
