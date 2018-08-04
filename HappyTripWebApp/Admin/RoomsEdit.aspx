<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoomsEdit.aspx.cs" Inherits="HappyTripWebApp.Admin.RoomsEdit" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc:MenuC id="MenuControl" runat="server" />
<h1>Edit Room</h1>
 <center>
        <table style="width: 57%">
            <tr>
                <td class="style16" style="text-align: center;">
                    Title
                </td>
                <td class="style17" style="text-align: center;">
                    <asp:TextBox ID="txtTitle" runat="server" Width="176px"></asp:TextBox>
                </td>
                <td class="style18" style="text-align: center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title Must Not Be Empty"
                        SetFocusOnError="True" Width="142px" ControlToValidate="txtTitle" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style16" style="text-align: center;">
                    Description
                </td>
                <td class="style17" style="text-align: center;">
                    <asp:TextBox ID="txtDescription" runat="server" Width="176px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style18" style="text-align: center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Must not be  Empty"
                        Width="176px" ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style16" style="text-align: center;">
                    Code
                </td>
                <td class="style17" style="text-align: center;">
                    <asp:TextBox ID="txtCode" runat="server" Width="176px"></asp:TextBox>
                </td>
                <td class="style18" style="text-align: center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Code Must not be Empty"
                        Width="137px" ControlToValidate="txtCode" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCode"
                        ErrorMessage="Code is not valid" ForeColor="Red" SetFocusOnError="True" Style="margin-left: 0px;
                        height: 15px;" ValidationExpression="[A-Z]{3}" Width="120px"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style16" style="text-align: center;">
                    IsActive
                </td>
                <td class="style17" style="text-align: center;">
                    <asp:CheckBox ID="chkIsActive" runat="server" />
                </td>
                <td class="style18" style="text-align: center;">
                </td>
            </tr>
            <tr>
                <td class="style16" style="text-align: center;">
                    <asp:Button ID="btnEdit" runat="server" Text="EDIT" OnClick="btnEdit_Click" />
                </td>
                <td class="style17" style="text-align: center;">
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                </td>
                <td class="style12" style="text-align: center;">
                </td>
            </tr>
            <tr>
                <td class="style16" style="text-align: center;" colspan="3">
                    <asp:Label ID="lblUpdateResult" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
<hr />
</asp:Content>
