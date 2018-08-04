<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Passengers.aspx.cs"
    Inherits="HappyTripWebApp.Passengers" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="../Styles/flight_seats.css" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".datePicker").datepicker({ showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                changeMonth: true,
                changeYear: true,
                buttonImageOnly: true,
                yearRange: '-90:+0',
                maxDate: 0
            });
            $('input[dob="1"]').attr("readonly", true);
        });
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
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
                            <div id="divOnward" style="float:left; padding:0px;" class="dynamic_price">
                                <span id="Span1" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px;background-image: none; background-color: rgb(255, 255, 255);">
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
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %> -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    <span class="departs"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span> – 
                                                    <span class="arrives"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div id="divReturn" runat="server" visible="false" style="float:left; padding:0px;" class="dynamic_price">
                                <br />
                                <br />
                                <span id="Span2" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px;background-image: none; background-color: rgb(255, 255, 255);">
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
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %> -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    <span class="departs"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span> – 
                                                    <span class="arrives"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                            </tbody>
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
                            <h1 style="border-bottom-width:0px;"><b>Total Price</b>: INR <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h1>
                            <div>
                                <h3>Insurance:</h3>
                                <span>
                                Would you like to go in for travel insurance.<br />
                                (* Please note this is non-refundable)<br />
                                (* This is going to be charged for each passenger)
                                </span>
                        
                            </div>
                            <br />
                            <div>
                                <asp:CheckBox ID="InsuranceOption" runat="server" />
                                <span>
                                    Travel Insurance For Each Passenger Would Be : INR <asp:Label ID="lblOnwardInsuranceValue" runat="server"></asp:Label> /- Per Passenger
                                    <br /> 
                                     +
                                    <asp:Label ID="lblINR" runat="server" Text="INR" Visible="false"></asp:Label> <asp:Label ID="lblReturnInsuranceValue" runat="server" Visible="false"></asp:Label> /- Per Passenger
                                </span>
                            </div>
                        
                        

                            <br />
                            <br />
                            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="error_msg" DisplayMode="List" ValidationGroup="passenger" EnableClientScript="true" />
                            <div class="sector_info">
                                <h2>
                                    Passenger Details
                                </h2>
                            </div>
                            <table>
                                <tbody class="selected">
                                <tr>
                                    <td>
                                        <!-- Single Traveller block -->
                                        <asp:Repeater ID="rptrPassengerInfo" runat="server">
                                            <ItemTemplate>
                                                <div id="intADDAD1" style="display: block;" class="blockOptInBG clearFix active">
                                                    <dl class="horizontal travellers row">
                                                        <dt style="text-align: right;">
                                                            <label class="" id="AdultOne" style="margin: 0; padding: 0; border: 0; font-weight: bold;
                                                                font-style: normal; font-size: 120%; font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif;">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </label>
                                                        </dt>
                                                        <dd id="addAD1">
                                                            Name:
                                                            <asp:TextBox runat="server" ID="AdultFname" MaxLength="18" CssClass="required travellerFName name span four placeholder" minchars="1" title="Passenger's first name" placeholder="First / Given Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAdultFname" runat="server" CssClass="error_msg" 
                                                                ControlToValidate="AdultFname" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Name cannot be empty"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="AdultFnameValidator" runat="server" CssClass="error_msg" 
                                                                ControlToValidate="AdultFname" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" ValidationExpression="^[a-zA-Z ]+$" Text="*" ErrorMessage="Passenger name should have only alphabets"></asp:RegularExpressionValidator>
                                                            Gender:
                                                            <asp:DropDownList ID="ddlGender" runat="server">
                                                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            Date of Birth:
                                                            <asp:TextBox runat="server" ID="txtDOB" size="10" CssClass="datePicker required" placeholder="Date of Birth" dob="1"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtDOB" runat="server" CssClass="error_msg" 
                                                                ControlToValidate="txtDOB" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Date of Birth is required"></asp:RequiredFieldValidator>
                                                        </dd>
                                                    </dl>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                </tbody>
                            </table>



                            <br /><br />
                            <div class="sector_info">
                                <h2>
                                    Contact Information
                                </h2>
                            </div>
                            <table>
                                <tbody class="selected">
                                <tr>
                                    <td>
                                        Name
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtName" runat="server" maxlength="18" minchars="1" title="Contact's first name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtName" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Contact name is required"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="txtNameValidator" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtName" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Contact name should have only alphabets" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" Rows="3" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtAddress" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        City
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtCity" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        State
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtState" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="State is required"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phone&nbsp;Number
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtPhoneNumber" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Please enter a correct phone number" ValidationExpression="^\+?[0-9-]+$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        Mobile
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvMobile" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtMobile" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Mobile number is required"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtMobile" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Mobile numbers should be numeric" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email Id
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtEmailId" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Email Id is required"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtEmailId" ValidationGroup="passenger" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Please enter a valid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                        </div>
                        </div>



                        <br />
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <br />
                        <div id="button">
                            <asp:Button ID="btnBook" ValidationGroup="passenger" OnClick="btnBook_Click" Text="Proceed to Confirm" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- end of universal div -->
        </div>
    </div>
</div>
</asp:Content>
