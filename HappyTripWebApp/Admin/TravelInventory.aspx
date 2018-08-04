<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TravelInventory.aspx.cs" Inherits="HappyTripWebApp.Admin.TravelInventory" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=gridTravelInventory.ClientID%> tr:first").wrap("<thead>");
            $("#<%=gridTravelInventory.ClientID%> tr:gt(0)").wrap('<tbody class="selected">');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Travel Inventory" Width="100%" ShowPager="false">
        <Content>
            <asp:GridView ID="gridTravelInventory" runat="server" AutoGenerateColumns="False" BorderWidth="0" Width="100%">
                <Columns>
                    <asp:BoundField DataField="cityname" HeaderText="From&nbsp;City" />
                    <asp:BoundField DataField="cityname1" HeaderText="To&nbsp;City" />
                    <asp:BoundField DataField="flightname" HeaderText="Flight&nbsp;Name" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="airlinename" HeaderText="Airline&nbsp;Name" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="departuretime" HeaderText="Departure&nbsp;Time" />
                    <asp:BoundField DataField="arrivaltime" HeaderText="Arrival&nbsp;Time" />
                    <asp:BoundField DataField="durationinmins" HeaderText="Duration&nbsp;In&nbsp;Minutes" />
                    <asp:TemplateField HeaderText="Inventory" ConvertEmptyStringToNull="False">
                        <ItemTemplate>
                            <asp:GridView ID="gridClassDetails" runat="server" AutoGenerateColumns="False" BorderWidth="0" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="classtype" HeaderText="Class" />
                                    <asp:BoundField DataField="noofseats" HeaderText="Total&nbsp;Seats" />
                                    <asp:BoundField DataField="totalbooked" HeaderText="Total&nbsp;Booked" SortExpression="totalbooked" />
                                    <asp:BoundField DataField="totalavailable" HeaderText="Total&nbsp;Available" SortExpression="totalavailable" />
                                </Columns>
                                <%--<FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />--%>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" CssClass="error_msg" />
                <EmptyDataTemplate>Sorry !!! No Bookings Done For The Day</EmptyDataTemplate>
                <%--<FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />--%>
            </asp:GridView>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
