<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookingHistory.aspx.cs" Inherits="HappyTripWebApp.Booking.BookingHistory" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="../Styles/flight_seats.css" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#hlkModifySearch").click(function () {
                //$(this).addClass("active");
                $("#searchCriteria").slideDown();
            });

            $("#btnCloseSearchCriteria").click(function () {
                //$(this).addClass("active");
                $("#searchCriteria").slideUp();
            });
            $("#btnShowSearchResults").click(function () {
                $("#searchCriteria").slideUp();
                window.location = "BookingHistory.aspx?from=" + encodeURIComponent($("#bookings_from").val()) + "&to=" + encodeURIComponent($("#bookings_to").val()) + "";
            });

            $("#bookings_from").datepicker({
                showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true
            });
            $("#bookings_to").datepicker({
                showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true
            });
        });

        function showExtraBookingOptions(row) {
            $(row).children().last().children("div").show();
        }
        function hideExtraBookingOptions(row) {
            $(row).children().last().children("div").hide();
        }

        function showBookingDetails(id) {
            window.location = "Payment_Success.aspx?bookingid=" + id + "";
            return false;
        }
        function showBookingCancellation(id) {
            window.location = "../Cancellation/CancellationRequest.aspx?refnum=" + id + "";
            return false;
        }
    </script>
    <style type="text/css">
        .popup_box { display:none; position:absolute; }
        .pb_container { position:relative; width:100%; display:block; background-color:#eeeeee; border:solid 1px #cccccc; }
        .pb_content { padding:1em; }
        .pb_content p { padding-bottom:0.25em; }
        .pb_footer { padding:1em; background-color:#cccccc; }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
    <!-- Begin : Main page body -->
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
                                    <a id="hlkModifySearch" href="#" title="Click here to modify your search criteria" class="toggle_closed">Modify your search</a>
                                    <div id="searchCriteria" class="popup_box">
                                        <div class="pb_container clearfix">
                                            <div class="pb_footer">
                                                <a href="<%=ResolveClientUrl("~/Booking/BookingHistory.aspx")%>" class="toggle_closed">Show All Bookings</a>
                                            </div>
                                            <div class="pb_content">
                                                <p><input type="text" id="bookings_from" class="datePicker required" /></p>
                                                <p><input type="text" id="bookings_to" class="datePicker required" /></p>
                                            </div>
                                            <div class="pb_footer clearfix">
                                                <input type="button" id="btnShowSearchResults" value="Search" style="float:right;" />
                                                <input type="button" id="btnCloseSearchCriteria" value="Cancel" style="float:right;" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <ul class="inline">
                                    <li class="no_border">
                                        <label runat="server" id="lblResultsType">Showing all results</label>
                                    </li>
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

                    <asp:Panel ID="pnlBookingHistory" runat="server">
                        <!--  Begin : Right Div With Results Information -->
                        <div class="Right clearfix">
                            <!--  Begin : Col clearfix div -->
                            <div class="col clearfix">
                                <!--Begin : Search Results for Onward and Return Journeys to be displayed here-->
                                <div id="universalDiv" class="universal">
                                    <!-- Begin : Onward Journey Schedules -->
                                    <div class="sector" id="outbound_div" runat="server" style="width:90%">
                                        <div id="sector_info_heading" class="sector_info">
                                            <h2 runat="server" id="genDateCriteria"></h2>
                                        </div>
                                        <div id="outbound">
                                            <table border="0" id="tbloutbound">
                                                <!--Begin : List of Columns for the display of search results-->
                                                <colgroup>
                                                    <col width="9%" /><!--Reference No-->
                                                    <col width="10%" /><!--Booking Date-->
                                                    <col width="10%" /><!--Date Of Journey-->
                                                    <col width="11%" /><!--From City-->
                                                    <col width="11%" /><!--To City-->
                                                    <col width="6%" /><!--Airline Logo-->
                                                    <col width="13%" /><!--Airline Name-->
                                                    <col width="13%" /><!--Flight Name-->
                                                    <col width="8%" /><!--Total Cost-->
                                                    <col width="8%" /><!--Is Cancelled-->
                                                    <col width="1%" />
                                                </colgroup>
                                                <!--End : List of Columns for the display of search results-->
                                                <!--Begin : Header for Columns for the display of search results-->
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Reference&nbsp;No
                                                        </th>
                                                        <th>
                                                            Booking&nbsp;Date
                                                        </th>

                                                        <th>
                                                            Journey&nbsp;Date
                                                        </th>

                                                        <th>
                                                            From
                                                        </th>
                                                        <th>
                                                            To
                                                        </th>

                                                        <th>
                                                            &nbsp;
                                                        </th>
                                                        <th>
                                                            Airline&nbsp;Name
                                                        </th>
                                                        <th>
                                                            Flight&nbsp;Name
                                                        </th>

                                                        <th>
                                                            Total&nbsp;Cost
                                                        </th>
                                                        <th>
                                                            Status
                                                        </th>
                                                        <th>&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <!--End : Header for Columns for the display of search results-->

                                                <!--Booking history search results-->
                                                <tbody class="selected">
                                                <asp:Repeater ID="drpBookings" OnItemDataBound="drpBookings_ItemDataBound" runat="server">
                                                    <ItemTemplate>
                                                        <tr onmouseover="javascript:showExtraBookingOptions(this)" onmouseout="javascript:hideExtraBookingOptions(this)">
                                                            <td>
                                                                <%#DataBinder.Eval(Container.DataItem, "ReferenceNo")%>
                                                            </td>
                                                            <td>
                                                                <%#DataBinder.Eval(Container.DataItem, "BookingDate", "{0:MM/dd/yyyy}")%>
                                                            </td>
                                                            <td>
                                                                <%#DataBinder.Eval(Container.DataItem, "DateOfJourney", "{0:MM/dd/yyyy}")%>
                                                            </td>

                                                            <td>
                                                                <%#((HappyTrip.Model.Entities.Transaction.FlightBooking)Container.DataItem).TravelScheduleInfo.GetSchedules()[0].RouteInfo.FromCity.Name%>
                                                            </td>
                                                            <td>
                                                                <%#((HappyTrip.Model.Entities.Transaction.FlightBooking)Container.DataItem).TravelScheduleInfo.GetSchedules()[0].RouteInfo.ToCity.Name%>
                                                            </td>

                                                            <td>
                                                                <%--<%#((HappyTrip.Model.Entities.Transaction.FlightBooking)Container.DataItem).TravelScheduleInfo.GetSchedules()[0].FlightInfo.AirlineForFlight.Logo%>--%>
                                                                <div class="airline_logo"><div class="airline_logos AI"></div></div>
                                                            </td>
                                                            <td>
                                                                <%#((HappyTrip.Model.Entities.Transaction.FlightBooking)Container.DataItem).TravelScheduleInfo.GetSchedules()[0].FlightInfo.AirlineForFlight.Name%>
                                                            </td>

                                                            <td>
                                                                <%#((HappyTrip.Model.Entities.Transaction.FlightBooking)Container.DataItem).TravelScheduleInfo.GetSchedules()[0].FlightInfo.Name%>
                                                            </td>

                                                            <td>
                                                                <%#DataBinder.Eval(Container.DataItem, "TotalCost")%>
                                                            </td>
                                                            <td>
                                                                <%#GetStatus(DataBinder.Eval(Container.DataItem, "IsCanceled"), DataBinder.Eval(Container.DataItem, "DateOfJourney"))%>
                                                            </td>
                                                            <td>
                                                                <input type="hidden" value="<%#DataBinder.Eval(Container.DataItem, "BookingId")%>" />
                                                                <div class="popup_box">
                                                                    <div class="pb_container">
                                                                        <!-- <div class="pb_content">
                                                                            <input type="button" value="Details" style="width:100%" onclick="javascript: return showBookingDetails(<%#DataBinder.Eval(Container.DataItem, "BookingId")%>)" />
                                                                        </div>
                                                                        -->
                                                                        <%#BuildCancellationDiv(DataBinder.Eval(Container.DataItem, "ReferenceNo"), DataBinder.Eval(Container.DataItem, "IsCanceled"), DataBinder.Eval(Container.DataItem, "DateOfJourney"))%>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="11" class="connector">
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                </tbody>
                                                <!--End : Booking history search results-->
                                            </table>
                                        </div>
                                    </div>
                                    <!-- End : Onward Journey Schedules -->
                                </div>
                                <!--End : Search Results for Onward and Return Journeys to be displayed here-->
                            </div>
                            <!--  End : Col clearfix div -->
                        </div>
                        <!--  End : Right Div With Results Information -->
                    </asp:Panel>
                    <asp:Panel ID="pnlNoBookingHistory" runat="server" Visible="false">
                        <center>
                        <div class="sector" style="width:80%">
                            <div class="sector_info">
                                <h2>The search criteria did not find any bookings. Please click on the link to go back to your profile page</h2>
                            </div>
                            <div>
                                <a href="<%=ResolveClientUrl("~/Account/UpdateProfile.aspx")%>">Go back to My Account</a>
                            </div>
                        </div>
                        </center>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- End : Main page body-->
</asp:Content>
