<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHotelRoom.aspx.cs" Inherits="HappyTripWebApp.Admin.EditHotelRoom" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <uc:MenuC id="MenuControl" runat="server" />
<h1>Edit Hotel Room</h1>
<center>
        <table align="center" style="width: 50%;">
            <tr>
                <td align="center" width="85">
                    <asp:Label ID="Label1" runat="server" Text="HotelName :"></asp:Label>
                </td>
                <td align="center" width="85">
                    <asp:TextBox ID="txtHotelName" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="justify" width="85">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" width="85">
                    <asp:Label ID="Label2" runat="server" Text="TypeId :"></asp:Label>
                </td>
                <td align="center" width="85">
                    <asp:TextBox ID="txtTypeId" runat="server" ValidationGroup="g1" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="justify" width="85">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" width="85">
                    <asp:Label ID="Label" runat="server" Text="Title :"></asp:Label>
                </td>
                <td align="center" width="85">
                    <asp:TextBox ID="txtTitle" runat="server" ValidationGroup="g1" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="justify" width="85">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTitle"
                        Display="None" ErrorMessage="Title Connot be Empty!!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" width="85">
                    <asp:Label ID="Label3" runat="server" Text="CostPerDay :"></asp:Label>
                </td>
                <td align="center" width="85">
                    <asp:TextBox ID="txtCostPerDay" runat="server" ValidationGroup="g1"></asp:TextBox>
                </td>
                <td align="justify" width="85">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCostPerDay"
                        Display="None" ErrorMessage="Cost Per Day Coonot beEmpty!!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCostPerDay"
                        Display="None" ErrorMessage="Cost Per Day Value Should be Floating point!!" ValidationExpression="^\d*\.?\d*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" width="85">
                    <asp:Label ID="Label4" runat="server" Text="NoOfRooms :"></asp:Label>
                </td>
                <td align="center" width="85">
                    <asp:TextBox ID="txtNoOfRooms" runat="server" ValidationGroup="g1"></asp:TextBox>
                </td>
                <td align="justify" width="85">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOfRooms"
                        Display="None" ErrorMessage="Number Of Rooms Coonot beEmpty!!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNoOfRooms"
                        Display="None" ErrorMessage="No. Of Rooms must be integer!!" SetFocusOnError="True"
                        ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" width="85">
                    &nbsp;
                </td>
                <td align="center" width="85">
                    &nbsp;
                </td>
                <td align="justify" width="85">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <asp:Button ID="btnEdit" runat="server" Text="Update / Edit" 
                        OnClick="btnEdit_Click" />
                </td>
                <td align="right">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel" ValidationGroup="g1" />
                </td>
                <td align="justify">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="updtmsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <br />
        <br />
    </center>
<hr />
</asp:Content>
