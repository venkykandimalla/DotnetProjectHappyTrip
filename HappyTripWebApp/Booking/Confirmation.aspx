<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Confirmation.aspx.cs" Inherits="HappyTripWebApp.Confirmation" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Styles/flight_seats.css" type="text/css" />
    <style type="text/css">
        tr.FlighSearchResult td
        {
            border: 1px solid black;
        }
        
        
        tr.FlighSearchResultHeader td
        {
         border: 1px solid black;   
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script>
    var intlSearchToBookDays = 1;
</script>
<uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
<div class="Results">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div id="ModifySearchWrapper">
                <div id="SearchParams">
                    <div id="SPRow">
                        <div id="mod_link_wrapper">
                            <a class="toggle_closed" id="mod_link" title="Click here to make a new search" href="<%= ResolveClientUrl("~/Index.aspx")%>">Modify your search</a>
                        </div>
                        <ul class="inline">
                            <li class="no_border"><asp:Label ID="lblHeaderFromCity" runat="server"></asp:Label> &ndash; <asp:Label ID="lblHeaderToCity" runat="server"></asp:Label></li>
                            <li><asp:Label ID="lblHeaderDepart" runat="server"></asp:Label> <asp:Label ID="lblHeaderDateSeparator" runat="server" Visible="true"> - </asp:Label> <asp:Label ID="lblHeaderReturn" runat="server"></asp:Label>, <asp:Label runat="server" ID="lblAdults"></asp:Label> </li>
                        </ul>
                        <div id="SalesUpsell">
                            <div id="SUWrapper" class="clearfix">
                                Prefer booking over the phone? <span class="channel phone">Call 080123456789 <span class="weak">local call from any phone</span> </span>
                            </div>
                        </div>
                    </div>
                </div>
                </div>

                <!--  end of search params div -->
                <div class="Left">
                    <div class="col">
                    </div>
                    <!--  end of col div -->
                </div>
                <!--  end of left div -->
                <!--  Begin : Right Div With Results Information -->
                <div class="Right clearfix">
                    <!--  Begin : Col clearfix div -->
                    <div class="col clearfix">
                        <!-- Begin : Form to display all elements regarding flight search results -->
                        <!-- Begin : Flight and Price Info for Selected Flights by User -->
                        <div id="SelectionInfo" class="clearfix">
                        <div class="universal">
                        <div class="sector" style="width:70%">
                            <!-- Begin : Display Total Price -->
                            <div id="divOnward" style="width:49%; float:left; padding:0px;" class="dynamic_price">
                                <span id="Span1" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px; background-image: none; background-color: rgb(255, 255, 255);">
                                    Onward</span>
                                <br style="line-height: 0px; clear: both;">
                                <table cellspacing="1" cellpadding="5">
                                    <asp:Repeater ID="rptrOnwardFlightInfo" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                            <tr>
                                                <th>
                                                    <div class="airline_logos AI">
                                                    </div>
                                                </th>
                                                <th>
                                                    <b>Flight No</b>
                                                </th>
                                                <th>
                                                    <b>Route</b>
                                                </th>
                                                <th>
                                                    <b>Time</b>
                                                </th>
                                            </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tbody class="selected">
                                            <tr>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %>
                                                    -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    <span class="departs">
                                                        <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span>
                                                    – <span class="arrives">
                                                        <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div id="divReturn" runat="server" visible="false" style="width:49%; float:right; padding:0px;" class="dynamic_price">
                                <span id="Span2" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px; background-image: none; background-color: rgb(255, 255, 255);">
                                    Return</span>
                                <br style="line-height: 0px; clear: both;">
                                <table cellspacing="1" cellpadding="5">
                                    <asp:Repeater ID="rptrReturnFlightInfo" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                            <tr>
                                                <th>
                                                    <div class="airline_logos AI">
                                                    </div>
                                                </th>
                                                <th>
                                                    <b>Flight No</b>
                                                </th>
                                                <th>
                                                    <b>Route</b>
                                                </th>
                                                <th>
                                                    <b>Time</b>
                                                </th>
                                            </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tbody class="selected">
                                            <tr>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %>
                                                    -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    <span class="departs">
                                                        <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span>
                                                    – <span class="arrives">
                                                        <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                        </div>
                        </div>



                        <br />
                        <div class="universal clearfix">
                        <div class="sector" style="width:70%">
                            <h1 style="border-bottom-width:0px;"><b>Total Price:</b> <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h1>
                            <div>
                                <h3>
                                    Insurance :
                                    <asp:Label ID="lblInsuranceText" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInsuranceValue" runat="server" Text="" Visible="false"></asp:Label>
                                </h3>
                                <h3>
                                    Grand Total :
                                    <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                </h3>
                            </div>
                        </div>
                        </div>



                        <br />
                        <div class="universal clearfix">
                        <div class="sector" style="width:70%">
                        <div id="intADDAD1" style="width:49%; float:left;">
                            <div class="sector_info">
                                <h2>
                                    Passenger Details
                                </h2>
                            </div>
                            <!-- Single Traveller block -->
                            <table cellpadding="5" cellspacing="1">
                                <asp:Repeater ID="rptrPassengerInfo" runat="server">
                                    <HeaderTemplate>
                                        <thead>
                                        <tr>
                                            <th>
                                                <b>Name</b>
                                            </th>
                                            <th>
                                                <b>Gender</b>
                                            </th>
                                            <th>
                                                <b>Date of Birth</b>
                                            </th>
                                        </tr>
                                        </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tbody class="selected">
                                        <tr>
                                            <td>
                                                <%#((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).Name.Trim()%>
                                            </td>
                                            <td>
                                                <%# ((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).Gender%>
                                            </td>
                                            <td>
                                                <%#((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).DateOfBirth.ToString("dd-MM-yyyy").Trim()%>
                                            </td>
                                        </tr>
                                        </tbody>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        </div>
                        </div>



                        <br />
                        <br />
                        <div class="universal clearfix">
                        <div class="sector" style="width:70%">
                            <div class="sector_info">
                                <h2>
                                    Contact Information:
                                </h2>
                            </div>
                            <table cellspacing="1" cellpadding="5">
                                <tbody class="selected">
                                <tr>
                                    <td>
                                        <b>Name:</b>
                                    </td>
                                    <td colspan="5">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Address:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAddressline1" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <b>City:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <b>State:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Phone Number:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPhno" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <b>Mobile No:</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblMobno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Email Id:</b>
                                    </td>
                                    <td colspan="5">
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                        </div>
                        </div>



                        <br />
                        <br />
                        <div id="button">
                            <asp:Button ID="btnBook" ValidationGroup="passenger" OnClick="btnBook_Click" Text="Proceed to Payment" runat="server"  />
                        </div>
                    </div>
                </div>
            </div>
            <!-- end of universal div -->
        </div>
    </div>
</div>
</asp:Content>
