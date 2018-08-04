<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewHotelRooms.aspx.cs" Inherits="HappyTripWebApp.Admin.ViewHotelRooms" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />

         <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Hotel Rooms"></asp:Label>
    <br />
<br />
    <center><table style="width: 42%; height: 110px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Select City:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpCity" runat="server" Height="24px" Width="148px" 
                    AutoPostBack="True" onselectedindexchanged="dpCity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Select Hotel:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpHotel" runat="server" Height="24px" Width="148px" 
                    AutoPostBack="True" onselectedindexchanged="dpHotel_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
       <%-- <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Hotel Name:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:Label ID="lblHotelName" runat="server" Text="MTR Hotel"></asp:Label>
                </td>
        </tr>--%>
        </table>
        <br />
    <asp:GridView ID="grdRoom" runat="server" AutoGenerateColumns="True" 
        CellPadding="4" AllowPaging="True" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" PageSize="5">
        <Columns>
          <asp:HyperLinkField DataNavigateUrlFields="HotelId,TypeId" 
                DataNavigateUrlFormatString="~/Admin/EditHotelRoom.aspx?hotelid={0}&typeid={1}" Text="Edit" />   
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
        <br />
        <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add Room for Hotel" 
            onclick="btnAdd_Click" />
            <br />
        <br />
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " ForeColor="Red"></asp:Label>
    </center>

</asp:Content>
