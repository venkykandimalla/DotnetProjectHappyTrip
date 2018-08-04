<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRoute.aspx.cs" Inherits="HappyTripWebApp.Admin.AddRoute" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Add Route" Width="30%" ShowPager="false">
        <Content>
            <table border="0" id="tbloutbound">
                <tbody class="selected">
                <tr>
                    <td>
                        From&nbsp;City&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dpFromCity" runat="server" Width="140px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        To&nbsp;City&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dpToCity" runat="server" Width="139px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Distance&nbsp;in&nbsp;Kms&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDistance" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display:none">
                    <td>
                        Active
                    </td>
                    <td>
                        <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                    </td>
                </tr>
                </tbody>
                <tr>
                    <th colspan="2" style="text-align:right">
                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                        <asp:Button ID="Button2" Text="Cancel" runat="server" onclick="Button2_Click" />
                    </th>
                </tr>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
