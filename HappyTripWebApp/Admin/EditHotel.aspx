<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHotel.aspx.cs" Inherits="HappyTripWebApp.Admin.EditHotel" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 96px;
        }
        .style2
        {
            width: 124px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <uc:menuc id="MenuControl" runat="server" />
 <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Edit Hotel" style="text-align: center"></asp:Label>
    <br />
<br />
    <center><table style="width: 42%; height: 396px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Text="Hotel Id:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtHotelId" runat="server" Height="24px" Width="183px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtHotelName" runat="server" Height="24px" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Brief Note:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtBrief" runat="server" Height="108px" TextMode="MultiLine" 
                    Width="213px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Height="85px" Width="212px" 
                    TextMode="MultiLine"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:DropDownList ID="dpCity" runat="server" Height="24px" Width="148px">
                </asp:DropDownList>
                </td>
        </tr>
         <tr>
            <td class="style2">
                <asp:Label ID="Label8" runat="server" Text="Star Ranking:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:DropDownList ID="dpStarRanking" runat="server" Height="24px" Width="148px">
                    <asp:ListItem Text="1" Value="1"/>
                    <asp:ListItem Text="2" Value="2"/>
                    <asp:ListItem Text="3" Value="3"/>
                    <asp:ListItem Text="4" Value="4"/>
                    <asp:ListItem Text="5" Value="5"/>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Pincode:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtPincode" runat="server" Height="24px" Width="187px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Contact No:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtContact" runat="server" Height="24px" Width="183px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtEMail" runat="server" Height="24px" Width="212px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label9" runat="server" Text="Photo:"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtPhoto" runat="server" Height="24px" Width="212px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label17" runat="server" Text="Website URL"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server" Height="24px" Width="212px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2" align="center"">
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnAdd" runat="server" Text="Update" 
                    onclick="btnUpdate_Click" />
            </td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" 
                    onclick="btnClear_Click" />
            </td>
        </tr>
    </table>
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </center>
</asp:Content>
