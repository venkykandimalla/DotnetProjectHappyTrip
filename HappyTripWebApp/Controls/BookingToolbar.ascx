<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingToolbar.ascx.cs" Inherits="HappyTripWebApp.Controls.BookingToolbar" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-base.css") %>" />
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-topbar.css") %>" />
<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu-sidebar.css") %>" />
<script type="text/javascript" src="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu.js") %>"></script>

<div id="ddtopmenubar" class="mattblackmenu">
    <ul>
        <li><a id="hlkHome" runat="server" href="~/Index.aspx">Search Flights</a></li>
        <li><a id="hlkCancelBooking" runat="server" href="~/Cancellation/CancellationRequest.aspx">Cancel Booking</a></li>
        <%if (Request.IsAuthenticated){%>
        <li><a id="hlkBookingHistory" runat="server" href="~/Booking/BookingHistory.aspx">My Trips</a></li>
        <%}%>
    </ul>
</div>
<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>
