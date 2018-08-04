<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFlight.aspx.cs" Inherits="HappyTripWebApp.Admin.AddFlight" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Add Flight" Width="40%" ShowPager="false">
        <Content>
            <table border="0" id="tbloutbound">
                <tbody class="selected">
                <tr>
                    <td style="width:30%">
                        Name&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td style="width:100%">
                        <asp:TextBox ID="txtName" runat="server" Width="60%" />
                        <asp:RegularExpressionValidator ID="rexFlightName" runat="server" CssClass="error_msg" 
                            ControlToValidate="txtName" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Flight name can contain only alphanumerics and hyphen(-)" ValidationExpression="[a-zA-Z0-9 -]+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Airline&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAirLine" runat="server" Width="60%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Class/Seats&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <table style="width:60%">
                            <tr>
                                <th>
                                    Class
                                </th>
                                <th>
                                    Seats
                                </th>
                            </tr>
                            <asp:Repeater ID="dlClass" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <th>
                                            <asp:Label ID="lblClass" Text='<%# ((TravelClass)Container.DataItem).ToString() %>' runat="server" />    
                                        </th>
                                        <th>
                                            <asp:TextBox CssClass="ClassNoOfSeats" ID="txtNoOfSeats" Text="0" Width="50px" MaxLength="5" runat="server" />
                                            <asp:RegularExpressionValidator ID="seatValidator" runat="server" CssClass="error_msg" 
                                                ControlToValidate="txtNoOfSeats" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage='<%# ((TravelClass)Container.DataItem).ToString() +" seat count should be a positive number" %>' ValidationExpression="^[0-9]\d*$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                </tbody>
                <tr>
                    <th colspan="2" style="text-align:right">
                        <asp:Button Text="Add" ID="btnAdd" runat="server" onclick="btnAdd_Click" />
                        <asp:Button Text="Cancel" ID="btnCancel" runat="server" onclick="btnCancel_Click" />
                    </th>
                </tr>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
