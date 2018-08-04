<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMaster.ascx.cs" Inherits="HappyTripWebApp.Controls.AdminMaster" %>
<%@ Register TagPrefix="uc" TagName="AdminMenu" Src="~/Admin/AdminControl.ascx" %>
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/register.css")%>" type="text/css" />
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/account.css")%>" type="text/css" />
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/flight_seats.css")%>" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#AdminMasterMain input:submit, #AdminMasterMain a").click(function () {
            $("#<%=lblErrorMessage.ClientID%>").hide();
        });
    });
</script>
<uc:AdminMenu id="ctlAdminMenu" runat="server" />
<div class="Results">
    <div id="Wrapper">
        <div class="Container">
            <center>
            <div id="ContentFrame" runat="server" class="clearfix" style="width:100%">
                <br />
                <div id="lblErrorMessage" runat="server" class="error_msg" visible="false"></div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error_msg" DisplayMode="List" />
                <asp:PlaceHolder ID="phMessageContent" runat="server"></asp:PlaceHolder>
                <div class="universal">
                    <div id="AdminMasterMain" class="sector" style="width:100%">
                        <div class="sector_info">
                            <h2 id="hdHeading" runat="server" style="font-size:large"></h2>
                        </div>

                        <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>

                        <div class="sector_info">
                            <h2 style="padding:0px; font-size:1px;">&nbsp;</h2>
                        </div>
                    </div>
                </div>

                <div id="ModifySearchWrapper" runat="server">
                    <div id="SearchParams">
                            <div id="SalesUpsell" style="padding-left:10px; padding-right:10px">
                                <div id="SUWrapper" style="text-align:center">
                                    <span class="channel" style="padding-left:0px; padding-right:0px;">
                                        <asp:LinkButton Text="Prev" ID="lbtPreviousPage" runat="server" OnClick="lbtPreviousPage_Click" />
                                        <asp:Label Text="" ID="lblCurrentPage" runat="server" />
                                        <asp:LinkButton Text="Next" ID="lbtNextPage" runat="server" OnClick="lbtNextPage_Click" />
                                    </span>
                                </div>
                            </div>
                    </div>
                </div>

                <asp:PlaceHolder ID="phBottomContent" runat="server"></asp:PlaceHolder>
            </div>
            </center>
        </div>
    </div>
</div>
