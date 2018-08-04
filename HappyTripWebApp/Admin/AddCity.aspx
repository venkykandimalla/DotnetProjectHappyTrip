<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="HappyTripWebApp.Admin.WebForm1" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Add City" Width="30%" ShowPager="false">
        <content>
            <table border="0" id="tbloutbound">
                <tbody class="selected">
                <tr>
                    <td>
                        City&nbsp;Name&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCrCity" runat="server" Width="134px" />
                        <asp:RegularExpressionValidator ID="cityNameValidator" runat="server" CssClass="error_msg" 
                            ControlToValidate="txtCrCity" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="City name should have only alphabets" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        State&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dpStateCity" runat="server" Width="169px">
                        </asp:DropDownList>
                    </td>
                </tr>
                </tbody>
                <tr>
                    <th colspan="2" style="text-align:right">
                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnClear" Text="Cancel" onclick="btnClear_Click" />
                    </th>
                </tr>
            </table>
        </content>
        <bottomcontent>
        </bottomcontent>
    </uc:AdminMaster>
</asp:Content>
