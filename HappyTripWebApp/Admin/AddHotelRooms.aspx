<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHotelRooms.aspx.cs" Inherits="HappyTripWebApp.Admin.AddHotelRooms" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
 <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Add Room for Hotel"></asp:Label>
    <br />
<br />
    <center><table style="width: 42%; height: 396px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Hotel Name:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:Label ID="lblHotelName" runat="server" Text="MTR Hotel"></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:Image ID="ImgPhoto" runat="server" Height="63px" Width="158px" />
            </td>
        </tr>--%>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="Bangalore"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Room Type:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpRoomType" runat="server" Height="23px" Width="172px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="No of Rooms:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:TextBox ID="txtNoOfRooms" runat="server" Height="24px" Width="69px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Cost Per Day:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:TextBox ID="txtCostPerDay" runat="server" Height="24px" Width="72px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2" align="center"">
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Clear" />
            </td>
        </tr>
    </table>
        <br />
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " ForeColor="Red"></asp:Label>
    </center>

</asp:Content>

