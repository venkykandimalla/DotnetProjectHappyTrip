<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageFlights.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageFlights" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Flight Details" Width="50%" ShowPager="true" OnPreviousPageClick="commandPrevious_Click" OnNextPageClick="commandNext_Click">
        <Content>
            <table border="0" id="tbloutbound">
                <thead>
                <tr>
                    <th style="display:none">
                        ID
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        AirLine
                    </th>
                    <th>
                        Class&nbsp;Wise&nbsp;Seats
                    </th>
                    <th style="width:1%">
                        Edit
                    </th>
                </tr>
                </thead>
                <tbody class="selected">
                    <asp:Repeater ID="dlFlight" runat="server" OnItemDataBound="dlFlight_ItemDataBound" onitemcommand="dlFlight_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="display:none">
                                   <asp:Label ID='lblflightid' runat="server" Text='<%# ((Flight)Container.DataItem).ID %>' /> 
                                </td>
                                <td>
                                    <%# ((Flight)Container.DataItem).Name %>
                                </td>
                                <td>
                                    <%# ((Flight)Container.DataItem).AirlineForFlight.Name %>
                                </td>
                                <td>
                                    <table>
                                        <asp:Repeater  ID="dlFlightClass" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <th>&nbsp;&nbsp;</th>
                                                    <th>
                                                        <%# ((FlightClass)Container.DataItem).ClassInfo.ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </th>
                                                    <th style="width:100%">
                                                        <%# ((FlightClass)Container.DataItem).NoOfSeats %>
                                                    </th>
                                                    <th>&nbsp;&nbsp;</th>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                                <td>
                                    <asp:Button Text="Edit" ID="btnEdit" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
