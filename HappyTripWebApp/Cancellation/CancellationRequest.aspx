<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancellationRequest.aspx.cs" Inherits="HappyTripWebApp.Cancellation.CancellationRequest" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Styles/flight_seats.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
    <!-- Begin : Main page body -->
    <div class="Results">
        <div id="Wrapper">
            <div class="Container">
                <div id="ContentFrame" class="clearfix">
                    <div class="Right clearfix">
                        <div class="col clearfix">
                            <div id="universalDiv" class="universal">
                                <div class="sector" id="outbound_div" runat="server" style="width:75%">
                                    <asp:label text="" runat="server" ID="lblErrMsg" CssClass="error_msg"></asp:label>

                                    <div id="sector_info_heading" class="sector_info">
                                        <h2>Flight Booking Cancelation Form</h2>
                                    </div>
                                    
                                    <table border="0">
                                    <thead>
                                        <tr>
                                            <th>
                                                Cancellation Policy
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody class="selected">
                                        <tr>
                                            <td>
                                                <ul>
                                                    <li>Flight can be canceled only 3 hours before the journey</li>
                                                    <li>A cancelation fee of INR 750/- is charged for each passenger ticket</li>
                                                    <li>Insurance is non-refundable</li>
                                                    <li>Happy Miles for the booking will be reveresed</li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Enter&nbsp;Booking&nbsp;Reference&nbsp;Number&nbsp;<span class="error_msg">*</span>&nbsp;&nbsp;
                                                <asp:textbox runat="server" ID="txtRefNo" />&nbsp;&nbsp;
                                                <asp:button text="Proceed for Booking Cancellation" runat="server" id="btnProcedeForCancel" onclick="btnProcedeForCancel_Click"/>&nbsp;&nbsp;
                                                <asp:requiredfieldvalidator ID="Requiredfieldvalidator1" errormessage="Reference number required" controltovalidate="txtRefNo" runat="server" ForeColor="Red"/>
                                            </td>
                                        </tr>
                                    </tbody>
                                    </table>


                                    <asp:placeholder runat="server" id="PlaceHolder1" Visible="false">
                                        <br />
                                        <table border="0">
                                        <thead>
                                            <tr>
                                                <th colspan="4">
                                                    Booking Details
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody class="selected">
                                            <tr>
                                                <td style="width:25%">Booking&nbsp;ID</td>
                                                <td style="width:25%"><asp:label text="text" runat="server" id="lblBookingID"/></td>
                                                <td style="width:25%">Booking&nbsp;Reference&nbsp;Number</td>
                                                <td style="width:25%"><asp:label text="text" runat="server" id="lblRefNo"/></td>
                                            </tr>
                                            <tr>
                                                <td>No&nbsp;of&nbsp;Seats</td>
                                                <td><asp:label text="text" runat="server" id="lblSeats"/></td>
                                                <td>Cost&nbsp;Per&nbsp;Ticket</td>
                                                <td><asp:label text="text" runat="server" id="lblCost"/></td>
                                            </tr>
                                            <tr>
                                                <td>Departure&nbsp;Date</td>
                                                <td><asp:label text="text" runat="server" id="lblDate"/></td>
                                                <td>Departure Time</td>
                                                <td><asp:label text="text" runat="server" id="lblDeptTime"/></td>
                                            </tr>
                                            <tr>
                                                <td>Arrival Time</td>
                                                <td><asp:label text="text" runat="server" id="lblArrivalTime"/></td>
                                                <td>Airline Name</td>
                                                <td><asp:label text="text" runat="server" id="lblAirlineName"/></td>
                                            </tr>
                                            <tr>
                                                <td>Flight Name</td>
                                                <td><asp:label text="text" runat="server" id="lblFlightName"/></td>
                                                <td>From City</td>
                                                <td><asp:label text="text" runat="server" id="lblFromCity"/></td>
                                            </tr>
                                            <tr>
                                                <td>To City</td>
                                                <td><asp:label text="text" runat="server" id="lblToCity"/></td>
                                                <td>Class</td>
                                                <td><asp:label text="text" runat="server" id="lblClassType"/></td>
                                            </tr>
                                            <tr>
                                                <td>Happy Miles</td>
                                                <td colspan="3"><asp:label text="0" runat="server" id="lblHappyMiles"/></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align:right">
                                                    <asp:button text="Confirm Cancelation" runat="server" ID="btnCancel" onclick="btnCancel_Click"/>
                                                </td>
                                            </tr>
                                        </tbody>
                                        </table>
                                    </asp:placeholder>


                                    <asp:placeholder runat="server" id="PlaceHolder2" Visible="false">
                                        <br />
                                        <asp:label text="" runat="server" ID="lblSuccessMessage" CssClass="error_msg"></asp:label>
                                        <table border="0">
                                        <tbody class="selected">
                                            <tr>
                                                <td style="width:25%">Cancelation Date</td>
                                                <td><asp:label text="text" runat="server" id="lblCancelationDate"/></td>
                                            </tr>
                                            <tr>
                                                <td>Refund Amount</td>
                                                <td><asp:label text="text" runat="server" id="lblRefundAmount"/></td>
                                            </tr>
                                        </tbody>
                                        </table>
                                    </asp:placeholder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
