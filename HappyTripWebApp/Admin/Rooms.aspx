<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Rooms.aspx.cs" Inherits="HappyTripWebApp.Rooms" %>

<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC ID="MenuControl" runat="server" />
    <br />
    <br />

    <center>
        <h1>View Rooms</h1>
        <asp:GridView ID="RoomTypesGridView" runat="server" Width="450px" 
            CellPadding="4" Height="185px"
            GridLines="Horizontal" ForeColor="Black" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="TypeId" DataNavigateUrlFormatString="~/Admin/RoomsEdit.aspx?typeid={0}"
                    Text="Edit" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </center>
    <br />
    <br />
</asp:Content>
