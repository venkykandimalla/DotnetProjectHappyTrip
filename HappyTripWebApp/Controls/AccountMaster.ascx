<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountMaster.ascx.cs" Inherits="HappyTripWebApp.Controls.AccountMaster" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-base.css") %>" />
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-topbar.css") %>" />
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-sidebar.css") %>" />
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/register.css")%>" type="text/css" />
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/account.css")%>" type="text/css" />
<script type="text/javascript" src="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu.js") %>"></script>

<div id="ddtopmenubar" class="mattblackmenu">
    <ul>
        <li><a id="hlkHome" runat="server" href="~/Index.aspx">Search Flights</a></li>
        <li><a id="hlkViewProfile" runat="server" href="~/Account/UpdateProfile.aspx">My Account</a></li>
        <%--<li><a id="hlkUpdateProfile" runat="server" href="~/Account/UpdateProfile.aspx?upd=1">Update Profile</a></li>--%>
        <li><a id="hlkChangePassword" runat="server" href="~/Account/ChangePass.aspx">Change Password</a></li>
        <li><a id="hlkCancelBooking" runat="server" href="~/Cancellation/CancellationRequest.aspx">Cancel Booking</a></li>
        <li><a id="hlkBookingHistory" runat="server" href="~/Booking/BookingHistory.aspx">My Trips</a></li>
    </ul>
</div>
<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>

<div class="Signin">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div class="Left">
                    <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
                </div>
                <div class="Right">
                    <div class="col clearfix">
                        <asp:Image ID="Image1" ImageUrl="~/Images/suitcase.png" Style="margin-left: 40px;"
                            runat="server" Width="500" Height="500" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
