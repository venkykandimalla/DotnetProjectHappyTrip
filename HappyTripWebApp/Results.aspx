<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" MasterPageFile="~/Site.Master"
    Inherits="HappyTripWebApp.Results" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="Styles/flight_seats.css" type="text/css" />
    <script type="text/javascript">
        function costanimate() {
            var onwardfare = $("input:radio[name='onewayJourneyId']:checked").parent().parent().find('#onwardcost').html();
            var returnfare = 0;
            if ($('#MainContent_hdnTravelDirection').val() == '2') {
                returnfare = $("input:radio[name='returnJourneyId']:checked").parent().parent().find('#returncost').html();
            }
            var cost = parseInt(onwardfare) + parseInt(returnfare);
            var fromcost = 0;
            var tocost = cost;
            //            if (!isNaN(parseInt($('#total_price').text())))
            //                fromcost = parseInt($('#total_price').text());
            $("#extras").show();
            jQuery({ someValue: fromcost }).animate({ someValue: tocost }, {
                duration: 800,
                easing: 'swing', // can be anything
                step: function () { // called on every step
                    // Update the element's text with rounded-up value:
                    $('#total_price').text(Math.ceil(this.someValue));
                },
                complete: function () {
                    $('#total_price').text("INR. " + tocost);
                }
            });

        }

        $(document).ready(function () {
            $('#SelectionInfo').hide();

            var depart = new Date($('#hdnDepartDate').val());
            $('#headerdepart').html();

            $('input:radio[name=onewayJourneyId]').live('change', function () {
                costanimate();
                displaySelectionInfo();
            });

            $('input:radio[name=returnJourneyId]').live('change', function () {
                costanimate();
                displaySelectionInfo();
            });

            $('#MainContent_outbound_div #outbound').find("#onewayJourneyId:first").attr('checked', 'checked');
            $('#MainContent_return_div #return').find("#returnJourneyId:first").attr('checked', 'checked');
            costanimate();
            //costanimate($('#MainContent_dlOuterReturn').find("#onewayJourneyId:first"));
            displaySelectionInfo();
            //$('input:radio[name=onewayJourneyId]:first').attr('checked', true);
            //$('input:radio[name=returnJourneyId]:first').attr('checked', true);
        });


        function displaySelectionInfo() {
            var selectedflightonward = $("input:radio[name='onewayJourneyId']:checked");
            var selectedflightreturn = $("input:radio[name='returnJourneyId']:checked");
            $('#selectedreturn').hide();

            var flightname = $(selectedflightonward).parent().parent().parent().find('#flightname').html();
            var flightcode = $(selectedflightonward).parent().parent().parent().find('#flightcode').html();
            var date = $('#MainContent_lblHeaderDepart').html();
            $('#MainContent_hdnScheduleOnwardSelectedId').val($(selectedflightonward).parent().parent().find('#hdnOnwardScheduleId').val());

            var depart = $(selectedflightonward).parent().parent().find('#depart').html();
            var arrive = $(selectedflightonward).parent().parent().find('#arrive').html();
            var fare = $(selectedflightonward).parent().parent().find('#onwardcost').html();

            if ($(selectedflightonward).parent().parent().parent().next().find('#hdnconnecting').length > 0) {
                var flightname = 'Multiple Carriers';
                flightcode = flightcode + ' - ' + $(selectedflightonward).parent().parent().parent().next().find('#flightcode').html();
                arrive = $(selectedflightonward).parent().parent().parent().next().find('#arrive').html();
                $('#MainContent_hdnScheduleOnwardSelectedId').val($('#MainContent_hdnScheduleOnwardSelectedId').val() + '|' + $(selectedflightonward).parent().parent().parent().next().find('#hdnOnwardScheduleId').val());
            }

            $('#resultonwardflightname').html(flightname);
            $('#resultonwarddate').html(date);
            $('#resultonwarddepart').html(depart);
            $('#resultonwardarrive').html(arrive);
            $('#resultonwardflightcode').html(flightcode);
            $('#resultonwardfare').html(fare);

            if ($('#MainContent_hdnTravelDirection').val() == '2') {//if travel direction is return

                var flightname = $(selectedflightreturn).parent().parent().parent().find('#flightname').html();
                var flightcode = $(selectedflightreturn).parent().parent().parent().find('#flightcode').html();
                var date = $('#MainContent_lblHeaderReturn').html();
                $('#MainContent_hdnScheduleReturnSelectedId').val($(selectedflightreturn).parent().parent().find('#hdnReturnScheduleId').val());

                var depart = $(selectedflightreturn).parent().parent().find('#depart').html();
                var arrive = $(selectedflightreturn).parent().parent().find('#arrive').html();
                var fare = $(selectedflightreturn).parent().parent().find('#returncost').html();

                if ($(selectedflightreturn).parent().parent().parent().next().find('#hdnconnecting').length > 0) {
                    var flightname = 'Multiple Carriers';
                    flightcode = flightcode + ' - ' + $(selectedflightreturn).parent().parent().parent().next().find('#flightcode').html();
                    arrive = $(selectedflightreturn).parent().parent().parent().next().find('#arrive').html();
                    $('#MainContent_hdnScheduleReturnSelectedId').val($('#MainContent_hdnScheduleReturnSelectedId').val() + '|' + $(selectedflightreturn).parent().parent().parent().next().find('#hdnReturnScheduleId').val());
                }

                $('#resultreturnflightname').html(flightname);
                $('#resultreturndate').html(date);
                $('#resultreturndepart').html(depart);
                $('#resultreturnarrive').html(arrive);
                $('#resultreturnfare').html(fare);
                $('#resultreturnflightcode').html(flightcode);

                $('#selectedreturn').show();
            }
            $('#SelectionInfo').show();
        }
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
    <!-- Begin : Main page body -->
    <asp:Panel ID="resultPanel" runat="server">
        <div class="Results">
            <div id="Wrapper">
                <div class="Container">
                    <div id="ContentFrame" class="clearfix">
                        <!--  Begin : Left Div With Search Information -->
                        <div id="ModifySearchWrapper">
                            <!-- Begin : First Row - Search, Display Details and Contact Over Phone Info-->
                            <div id="SearchParams">
                                <div id="SPRow">
                                    <div id="mod_link_wrapper">
                                        <a href="<%= ResolveClientUrl("~/Index.aspx")%>" title="Click here to make a new search"
                                            id="mod_link" class="toggle_closed">Modify your search</a>
                                    </div>
                                    <ul class="inline">
                                        <li class="no_border">
                                            <asp:Label ID="lblHeaderFromCity" runat="server"></asp:Label>
                                            –
                                            <asp:Label ID="lblHeaderToCity" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblHeaderDepart" runat="server"></asp:Label>
                                            <asp:Label ID="lblHeaderDateSeparator" runat="server" Visible="true"> - </asp:Label>
                                            <asp:Label ID="lblHeaderReturn" runat="server"></asp:Label>,
                                            <asp:Label runat="server" ID="lblAdults"></asp:Label>
                                            Seat</li>
                                    </ul>
                                    <div id="SalesUpsell">
                                        <div class="clearfix" id="SUWrapper">
                                            Prefer booking over the phone? <span class="channel phone">Call 08066006600 <span
                                                class="weak">local call from any phone</span> </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End : First Row - Search, Display Details and Contact Over Phone Info-->
                        </div>
                        <!--  End : Left Div With Search Information -->
                        <!--  Begin : Right Div With Results Information -->
                        <div class="Right clearfix">
                            <!--  Begin : Col clearfix div -->
                            <div class="col clearfix">
                                <!-- Begin : Form to display all elements regarding flight search results -->
                                <%--<form id="universal_display" action="passengers.html" method="post" name="results">--%>
                                <!-- Begin : Flight and Price Info for Selected Flights by User -->
                                <div id="SelectionInfo" class="clearfix">
                                    <!-- Begin : Display Total Price -->
                                    <div id="dynamic_price" class="dynamic_price">
                                        <!--[if IE]>
											<br style="clear:both;line-height:0px;" />
										<![endif]-->
                                        <div id="button" style="float:right">
                                            <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" />
                                        </div>
                                        <span id="total_price" style="background-image: none; background-color: rgb(255, 255, 255);">
                                        </span>
                                        <br style="line-height: 0px; clear: both;">
                                        <span id="extras" style="display: none;">Includes all charges </span>
                                    </div>
                                    <!-- End : Display Total Price -->
                                    <!-- Begin : Users current selection Flight Info -->
                                    <div id="CurrentSelection" class="clearfix deal">
                                        <div id="selectedflights">
                                            <div id="selectedreturn" class="flight clearfix">
                                                <!--First Display the Return and then the Onward
                                        Divs will align accordingly-->
                                                <div class="airline_logos AI">
                                                </div>
                                                <h3>
                                                    <span id="resultreturnflightname"></span>
                                                </h3>
                                                <span id="resultreturnflightcode"></span>
                                                <br />
                                                <span id="resultreturndate"></span>
                                                <br>
                                                <span class="departs" id="resultreturndepart"></span>– <span class="arrives" id="resultreturnarrive">
                                                </span>
                                                <br>
                                                INR. <span id="resultreturnfare"></span>
                                            </div>
                                            <div id="selectedoutbound" class="flight clearfix">
                                                <div class="airline_logos AI">
                                                </div>
                                                <h3>
                                                    <span id="resultonwardflightname"></span>
                                                </h3>
                                                <span id="resultonwardflightcode"></span>
                                                <br />
                                                <span id="resultonwarddate"></span>
                                                <br>
                                                <span class="departs" id="resultonwarddepart"></span>– <span class="arrives" id="resultonwardarrive">
                                                </span>
                                                <br>
                                                INR. <span id="resultonwardfare"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End : Users current selection Flight Info -->
                                </div>
                                <!-- End : Flight and Price Info for Selected Flights by User -->
                                <!-- Begin : Message to be displayed while updating results -->
                                <div id="update_note" class="UpdateMessage">
                                    <span>Updating Results...</span>
                                </div>
                                <!-- End : Message to be displayed while updating results -->
                                <!--Begin : Search Results for Onward and Return Journeys to be displayed here-->
                                <div id="universalDiv" class="universal">
                                    <!-- Begin : Onward Journey Schedules -->
                                    <div class="sector" id="outbound_div" runat="server">
                                        <div id="sector_info_heading" class="sector_info">
                                            <h2>
                                                <asp:Label ID="lblOneWayFromCity" runat="server"></asp:Label>
                                                to
                                                <asp:Label ID="lblOneWayToCity" runat="server"></asp:Label></h2>
                                        </div>
                                        <div id="outbound">
                                            <table border="0" id="tbloutbound">
                                                <!--Begin : List of Columns for the display of search results-->
                                                <colgroup>
                                                    <col width="21" />
                                                    <!--Radio Button-->
                                                    <col width="36" />
                                                    <!--Airline Logo, With Name-->
                                                    <col width="17%" />
                                                    <!--Departure Time, Below City Name-->
                                                    <col width="17%" />
                                                    <!--Arrival Time, Below City Name-->
                                                    <col width="20%" />
                                                    <!--Duration In Hours and Minutes-->
                                                    <col width="24%" />
                                                    <!--Price INR-->
                                                </colgroup>
                                                <!--End : List of Columns for the display of search results-->
                                                <!--Begin : Header for Columns for the display of search results-->
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <!--Radio Button-->
                                                        </th>
                                                        <th>
                                                            <!--Airline Logo, With Name-->
                                                        </th>
                                                        <th>
                                                            Departs
                                                        </th>
                                                        <th>
                                                            Arrives
                                                        </th>
                                                        <th>
                                                            Duration
                                                        </th>
                                                        <th>
                                                            Price
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <!--End : Header for Columns for the display of search results-->
                                                <!--Begin : Onward Journey - Body Cotent : Columns for the display of search results-->
                                                <asp:Repeater ID="dlOuterOnward" OnItemDataBound="dlOuterOnward_ItemDataBound" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Repeater ID="dlInnerOnward" runat="server">
                                                            <ItemTemplate>
                                                                <tbody class="selected">
                                                                    <!--Begin : Direct Flights Row - Results-->
                                                                    <tr>
                                                                        <%# Container.ItemIndex.Equals(0) ? "<td rowspan=\"2\" class=\"button\"><input type=\"radio\" name=\"onewayJourneyId\" value=\"\" id=\"onewayJourneyId\" /></td><td rowspan=\"2\" class=\"airline_logo\"><div class=\"airline_logos AI\"><!--Logo of the Airline  - image to be displayed here--></div></td>" : "<td></td><td></td>"%>
                                                                        <td>
                                                                            <%# Container.ItemIndex.Equals(1) ? "<input type=\"hidden\" id=\"hdnconnecting\" value=\"true\"/>" : ""%>
                                                                            <input type="hidden" id="hdnOnwardScheduleId" value='<%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ID %>' />
                                                                            <div>
                                                                                <span id="depart">
                                                                                    <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span></div>
                                                                        </td>
                                                                        <td>
                                                                            <div>
                                                                                <span id="arrive">
                                                                                    <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span></div>
                                                                        </td>
                                                                        <td>
                                                                            <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DurationInMins%>min
                                                                        </td>
                                                                        <td>
                                                                            <%# Container.ItemIndex.Equals(0) ? "INR. " : "" %><span id="onwardcost"><%# GetText(Container.ItemIndex, DataBinder.Eval(Container.Parent.Parent, "DataItem.TotalCostPerTicket"))%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <%# Container.ItemIndex.Equals(0) ? "" : "<td class='noborder weak'></td><td class='noborder weak'></td>"%>
                                                                        <td class="noborder weak">
                                                                            <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name%>
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                            <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name%>
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td colspan="4" class="noborder weak">
                                                                            <!--Airline Name With Flight Name to be displayed here-->
                                                                            <span id="flightname">
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name%></span>
                                                                            : <span id="flightcode">
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="6" class="connector">
                                                                        </td>
                                                                    </tr>
                                                                    <!--End : Direct Flights Row - Results-->
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <!--End : Onward Journey - Body Cotent : Columns for the display of search results-->
                                            </table>
                                        </div>
                                    </div>
                                    <!-- End : Onward Journey Schedules -->
                                    <!-- Begin : Return Journey Schedules -->
                                    <div class="sector" id="return_div" runat="server">
                                        <div class="sector_info">
                                            <h2>
                                                <asp:Label ID="lblReturnFromCity" runat="server"></asp:Label>
                                                to
                                                <asp:Label ID="lblReturnToCity" runat="server"></asp:Label>
                                            </h2>
                                        </div>
                                        <div id="return">
                                            <table id="tblreturn">
                                                <!--Begin : List of Columns for the display of search results-->
                                                <colgroup>
                                                    <col width="21" />
                                                    <!--Radio Button-->
                                                    <col width="36" />
                                                    <!--Airline Logo, With Name-->
                                                    <col width="17%" />
                                                    <!--Departure Time, Below City Name-->
                                                    <col width="17%" />
                                                    <!--Arrival Time, Below City Name-->
                                                    <col width="20%" />
                                                    <!--Duration In Hours and Minutes-->
                                                    <col width="24%" />
                                                    <!--Price INR-->
                                                </colgroup>
                                                <!--End : List of Columns for the display of search results-->
                                                <!--Begin : Header for Columns for the display of search results-->
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <!--Radio Button-->
                                                        </th>
                                                        <th>
                                                            <!--Airline Logo, With Name-->
                                                        </th>
                                                        <th>
                                                            Departs
                                                        </th>
                                                        <th>
                                                            Arrives
                                                        </th>
                                                        <th>
                                                            Duration
                                                        </th>
                                                        <th>
                                                            Price
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <!--End : Header for Columns for the display of search results-->
                                                <!--Begin : Body- Cotent : Columns for the display of search results-->
                                                <asp:Repeater ID="dlOuterReturn" OnItemDataBound="dlOuterReturn_ItemDataBound" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Repeater ID="dlInnerReturn" runat="server">
                                                            <ItemTemplate>
                                                                <tbody class="selected">
                                                                    <!--Begin : Direct Flights Row - Results-->
                                                                    <tr>
                                                                        <%# Container.ItemIndex.Equals(0) ? "<td rowspan=\"2\" class=\"button\"><input type=\"radio\" name=\"returnJourneyId\" value=\"\" id=\"returnJourneyId\" /></td><td rowspan=\"2\" class=\"airline_logo\"><div class=\"airline_logos AI\"><!--Logo of the Airline  - image to be displayed here--></div></td>" : "<td></td><td></td>"%>
                                                                        <td>
                                                                            <%# Container.ItemIndex.Equals(1) ? "<input type=\"hidden\" id=\"hdnconnecting\" value=\"true\"/>" : ""%>
                                                                            <input type="hidden" id="hdnReturnScheduleId" value='<%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ID %>' />
                                                                            <div>
                                                                                <span id="depart">
                                                                                    <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span></div>
                                                                        </td>
                                                                        <td>
                                                                            <div>
                                                                                <span id="arrive">
                                                                                    <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span></div>
                                                                        </td>
                                                                        <td>
                                                                            <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DurationInMins%>min
                                                                        </td>
                                                                        <td>
                                                                            <%# Container.ItemIndex.Equals(0) ? "INR. " : "" %><span id="returncost"><%# GetText(Container.ItemIndex, DataBinder.Eval(Container.Parent.Parent, "DataItem.TotalCostPerTicket"))%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <%# Container.ItemIndex.Equals(0) ? "" : "<td class='noborder weak'></td><td class='noborder weak'></td>"%>
                                                                        <td class="noborder weak">
                                                                            <div>
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name%></div>
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                            <div>
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name%></div>
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td class="noborder weak">
                                                                        </td>
                                                                        <td colspan="4" class="noborder weak">
                                                                            <!--Airline Name With Flight Name to be displayed here-->
                                                                            <span id="flightname">
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name%></span>
                                                                            : <span id="flightcode">
                                                                                <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="6" class="connector">
                                                                        </td>
                                                                    </tr>
                                                                    <!--End : Direct Flights Row - Results-->
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- End : Return Journey Schedules -->
                                </div>
                                <!--End : Search Results for Onward and Return Journeys to be displayed here-->
                                <%--</form>--%>
                                <!-- End : Form to display all elements regarding flight search results -->
                            </div>
                            <!--  End : Col clearfix div -->
                        </div>
                        <!--  End : Right Div With Results Information -->
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnTravelDirection" runat="server" />
            <asp:HiddenField ID="hdnScheduleOnwardSelectedId" runat="server" />
            <asp:HiddenField ID="hdnScheduleReturnSelectedId" runat="server" />
        </div>
    </asp:Panel>
    <asp:Panel ID="searchFailedPanel" runat="server" Visible="false">
        <h1>Your search did not yield any result. Please try again</h1>
        <a href="<%= ResolveClientUrl("~/Index.aspx")%>">Go back to modify your search</a>
    </asp:Panel>
    <!-- End : Main page body-->
</asp:Content>
