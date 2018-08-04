<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoomsAdd.aspx.cs" Inherits="HappyTripWebApp.Admin.RoomsAdd" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc:MenuC id="MenuControl" runat="server" />

<h1>Add Room Types</h1>
<table align="center">
        <tr>
            <td align="center" class="style18">
&nbsp;<asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
            </td>
            <td align="center" class="style11">
                <asp:TextBox ID="TxtTitle" runat="server" ValidationGroup="g2" Width="118px"></asp:TextBox>
            </td>
            <td align="center" class="style15">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtTitle" ErrorMessage="Title field is empty" 
                    SetFocusOnError="True" Display="Dynamic" ForeColor="Red" 
                    ValidationGroup="g1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" class="style19">
                <asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
            </td>
            <td align="center" class="style12">
                <asp:TextBox ID="TxtDesc" runat="server" ValidationGroup="g2" Width="115px"></asp:TextBox>
            </td>
            <td align="center" class="style16">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TxtDesc" ErrorMessage="Description field  is empty" 
                    SetFocusOnError="True" ForeColor="Red" ValidationGroup="g1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" class="style19">
                <asp:Label ID="LblCode" runat="server" Text="Code:"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
            </td>
            <td align="center" class="style12">
                <asp:TextBox ID="Txtcode" runat="server" ValidationGroup="g2" Width="115px"></asp:TextBox>
            </td>
            <td align="center" class="style16">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtcode" Display="Dynamic" 
                    ErrorMessage="Code  should contain only capital 3 characters !!" 
                    SetFocusOnError="True" ValidationExpression="[A-Z]{3}" ForeColor="Red" 
                    ValidationGroup="g1">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Txtcode" ErrorMessage="Code Field is empty!!!" 
                    SetFocusOnError="True" Display="Dynamic" ForeColor="Red" 
                    ValidationGroup="g1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" class="style19">
                <asp:Label ID="lblActive" runat="server" Text="Active:"></asp:Label>
            </td>
            <td align="center" class="style12">
                <asp:CheckBox ID="CheckActive" runat="server" ValidationGroup="g2" />
            </td>
            <td align="center" class="style16">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style20">
                </td>
            <td align="center" class="style14">
                <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    DisplayMode="List" ForeColor="Red" ValidationGroup="g1" />
            </td>
            <td align="center" class="style17">
                </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="Save_Click" runat="server" 
            Text="Save" ValidationGroup="g1" onclick="Save_Click_Click" />
        <asp:Button ID="Button2" runat="server" Text="Clear" 
            ValidationGroup="g2" onclick="Button2_Click" />
    </p>
<hr style="height: 6px" />
<hr />
</asp:Content>
