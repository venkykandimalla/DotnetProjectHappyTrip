<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminControl.ascx.cs"
    Inherits="HappyTripWebApp.Admin.WebUserControl1" %>
<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-base.css" />
<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-topbar.css" />
<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-sidebar.css" />
<script type="text/javascript" src="<%= ResolveClientUrl("~/Admin/ddlevelsfiles/ddlevelsmenu.js") %>"></script>
<div id="ddtopmenubar" class="mattblackmenu">
    <ul>
        <li><a href="#" rel="schedulesubmenu">Schedule</a></li>
        <li><a href="#" rel="flightsubmenu">Flight</a></li>
        <li><a href="#" rel="citysubmenu">City</a></li>
        <li><a href="#" rel="airlinesubmenu">Airline</a></li>
        <li><a href="#" rel="routessubmenu">Route</a></li>
        <li><a href="#" rel="inventorysubmenu">Inventory</a></li>
        <!-- <li><a href="#" rel="hotelssubmenu">Hotel</a></li>
        <li><a href="#" rel="roomssubmenu">Room Type</a></li>
        -->
    </ul>
</div>
<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>
<ul id="schedulesubmenu" class="ddsubmenustyle">
    <li><a href="Add_Schedule.aspx">Add Schedule</a></li>
    <li><a href="Schedule_Flight.aspx">View & Edit Schedule</a></li>
</ul>
<ul id="flightsubmenu" class="ddsubmenustyle">
    <li><a href="AddFlight.aspx">Add Flight</a></li>
    <li><a href="ManageFlights.aspx">View & Edit Flight</a></li>
</ul>
<ul id="citysubmenu" class="ddsubmenustyle">
    <li><a href="AddCity.aspx">Add City</a></li>
    <li><a href="ManageCity.aspx">View & Edit City</a></li>
</ul>
<ul id="airlinesubmenu" class="ddsubmenustyle">
    <li><a href="AddAirline.aspx">Add Airline</a></li>
    <li><a href="ManageAirLines.aspx">View & Edit Airline</a></li>
</ul>
<ul id="routessubmenu" class="ddsubmenustyle">
    <li><a href="AddRoute.aspx">Add Route</a></li>
    <li><a href="RouteUI.aspx">View & Edit Route</a></li>
</ul>
<ul id="inventorysubmenu" class="ddsubmenustyle">
    <li><a href="TravelInventory.aspx">Travel Inventory</a></li>
</ul>
<!--
<ul id="hotelssubmenu" class="ddsubmenustyle">
    <li><a href="AddHotel.aspx">Add Hotel</a></li>
    <li><a href="ViewHotel.aspx">Edit Hotel</a></li>
    <li><a href="ViewHotel.aspx">View Hotel</a></li>
    <li><a href="ViewHotelRooms.aspx">Hotel Rooms</a></li>
</ul>
<ul id="roomssubmenu" class="ddsubmenustyle">
    <li><a href="RoomsAdd.aspx">Add Room Type</a></li>
    <li><a href="Rooms.aspx">View Room Type</a></li>
</ul>
-->
