<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewHotel.aspx.cs" Inherits="HappyTripWebApp.Admin.ViewHotel" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/GridviewStyle.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />

<br />
<br />
<center>
    <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="View Hotel" style="text-align: center"></asp:Label>
    <br />
    <asp:GridView ID="HotelGridView" runat="server" 
        CellPadding="4" Height="258px" 
        Width="647px" AllowPaging="True" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" 
        onpageindexchanging="HotelGridView_PageIndexChanging" PageSize="1">
        <%--<Columns>
            <asp:BoundField HeaderText="SlNo" />
            <asp:ImageField HeaderText="Photo">
            </asp:ImageField>
            <asp:BoundField HeaderText="Name" DataField=""/>
            <asp:BoundField HeaderText="Rating" DataField="" />
            <asp:BoundField HeaderText="City" />
            <asp:BoundField HeaderText="Address" />
            <asp:BoundField HeaderText="Pincode" />
            <asp:BoundField HeaderText="Contact No" />
            <asp:BoundField HeaderText="Email" />
            <asp:BoundField HeaderText="Website URL" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>--%>
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="HotelId" 
                DataNavigateUrlFormatString="~/Admin/EditHotel.aspx?hotelid={0}" Text="Edit" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <%-- <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />--%>
    </asp:GridView>
    <br />
    </center>
</asp:Content>
