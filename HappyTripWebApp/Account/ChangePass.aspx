<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="HappyTripWebApp.Account.ChangePass" %>
<%@ Register TagPrefix="uc" TagName="AccountMaster" Src="~/Controls/AccountMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AccountMaster ID="ctlAccountMaster" runat="server">
        <Content>
            <div class="col">
                <h1>
                    Change Your Password
                </h1>
                <asp:ChangePassword ID="ChangePassword1" runat="server" 
                    onchangedpassword="ChangePassword1_ChangedPassword" 
                    ContinueDestinationPageUrl="~/Account/UpdateProfile.aspx" CancelDestinationPageUrl="~/Account/UpdateProfile.aspx">
                    <ChangePasswordTemplate>
                        <div class="accountInfo">
                            <dl class="vertical">
                                <fieldset class="login">
                                    <dt>
                                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Password:</asp:Label>
                                    </dt>
                                    <dd>
                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                            ControlToValidate="CurrentPassword" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="ChangePassword1" CssClass="error_msg">*</asp:RequiredFieldValidator>
                                    </dd>
                                    <dt>
                                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                                    </dt>
                                    <dd>
                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                            ControlToValidate="NewPassword" ErrorMessage="New Password is required." 
                                            ToolTip="New Password is required." ValidationGroup="ChangePassword1" CssClass="error_msg">*</asp:RequiredFieldValidator>
                                    </dd>
                                    <dt>
                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                    </dt>
                                    <dd>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                            ControlToValidate="ConfirmNewPassword" 
                                            ErrorMessage="Confirm New Password is required." 
                                            ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1" CssClass="error_msg">*</asp:RequiredFieldValidator>
                                    </dd>
                                    <div class="error_msg">
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                            ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                            Display="Dynamic" 
                                            ErrorMessage="The Confirm New Password must match the New Password entry." 
                                            ValidationGroup="ChangePassword1" CssClass="error_msg"></asp:CompareValidator>
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </div>
                                </fieldset>
                                <p class="submitButton">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                        CommandName="ChangePassword" Text="Change Password" 
                                        ValidationGroup="ChangePassword1" />
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel" />
                                </p>
                            </dl>
                        </div>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </div>
        </Content>
    </uc:AccountMaster>
</asp:Content>
