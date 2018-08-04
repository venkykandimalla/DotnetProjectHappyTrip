<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule_Flight.aspx.cs" Inherits="HappyTripWebApp.Admin.Schedule_Flight" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Schedule Flight" Width="100%" ShowPager="true" OnPreviousPageClick="commandPrevious_Click" OnNextPageClick="commandNext_Click">
        <Content>
            <table border="0" id="tbloutbound">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound1" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <thead>
                    <tr>
                        <th style="display:none">
                            ID
                        </th>
                        <th>
                            From City
                        </th>
                        <th>
                            To City
                        </th>
                        <th>
                            Distance In Kms
                        </th>
                        <th>
                            Departure Time
                        </th>
                        <th>
                            Arrival Time
                        </th>
                        <th>
                            Duration (Mins)
                        </th>
                        <th>
                            Ticket Prices
                        </th>
                        <th>
                            Airline Name
                        </th>
                        <th>
                            Flight Name
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Edit
                        </th>
                    </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody class="selected">
                    <tr>
                        <td style="display:none">
                            <asp:Label ID='lblscheduleid' runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' />
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.FromCity.Name")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.ToCity.Name")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.DistanceInKms")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "DepartureTime")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "ArrivalTime")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "DurationInMins")%>
                        </td>
                        <td>
                            <table>
                                <asp:Repeater ID="dlFlightCost" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th>&nbsp;&nbsp;</th>
                                            <th>
                                                <%# ((FlightCost)Container.DataItem).Class.ToString()%>
                                            </th>
                                            <th>
                                                <%# ((FlightCost)Container.DataItem).CostPerTicket %>
                                            </th>
                                            <th>&nbsp;&nbsp;</th>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "FlightInfo.AirlineForFlight.Name")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "FlightInfo.Name")%>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" Checked='<%#DataBinder.Eval(Container.DataItem, "IsActive")%>'
                                runat="server" Enabled="false" />
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Edit" />
                        </td>
                    </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
