<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassSuccess.aspx.cs" Inherits="HappyTripWebApp.Account.ChangePassSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="../Styles/main.css" />
    <link rel="stylesheet" href="../Styles/register.css" />
    <link type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <link type="text/css" href="../Styles/nivo-slider.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Styles/themes/default.css" type="text/css" media="screen" />
    
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.nivo.slider.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
        onchangedpassword="ChangePassword1_ChangedPassword">
        <SuccessTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Change Password Complete</td>
                            </tr>
                            <tr>
                                <td>
                                    Your password has been changed!</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" onclick="ContinuePushButton_Click" Text="Continue" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
</asp:Content>
