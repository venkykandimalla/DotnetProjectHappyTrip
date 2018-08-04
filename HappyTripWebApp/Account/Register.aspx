<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="HappyTripWebApp.Account.Register" %>
<%@ Register TagPrefix="uc" TagName="GuestAccountMaster" Src="~/Controls/GuestAccountMaster.ascx" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server" ID="headContent">
    <link rel="stylesheet" href="../Styles/account.css" type="text/css"/>
    <link rel="stylesheet" href="../Styles/register.css" />
    <!-- Begin : Javascript Content -->
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=date.ClientID %>").datepicker({
                showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                yearRange: '-90:+0',
                maxDate: 0,
                changeMonth: true,
                changeYear: true
            });

            $('#<%=bt_Submit.ClientID %>').click(function () {
                var flag = true;
                if ($('#<%=EMailId.ClientID %>').val() == '') {
                    flag = false
                    $('#<%=email_error.ClientID %>').html('E-mail Id not entered');
                    $('#<%=email_error.ClientID %>').attr("class", "error_msg");
                }
                else if (!validateEmail($('#<%=EMailId.ClientID %>').val())) {
                    flag = false
                    $('#<%=email_error.ClientID %>').html('E-mail Id invailded');
                    $('#<%=email_error.ClientID %>').attr("class", "error_msg");
                }
                else
                    $('#<%=email_error.ClientID %>').html('')

                if ($('#<%=password.ClientID %>').val() == '') {
                    flag = false
                    $('#<%=lb_password_error.ClientID %>').html('Password not entered')
                }
                else
                    $('#<%=lb_password_error.ClientID %>').html('')

                if ($('#<%=password_confirmation.ClientID %>').val() != ($('#<%=password.ClientID %>').val())) {
                    flag = false
                    $('#<%=lb_error_conformpassword.ClientID %>').html('Password mismatch')
                }
                else
                    $('#<%=lb_error_conformpassword.ClientID %>').html('')

                if ($('#<%=last_name.ClientID %>').val() == '') {
                    flag = false
                    $('#<%=lb_error_username.ClientID %>').html('User name not entered')
                }
                else
                    $('#<%=lb_error_username.ClientID %>').html('')

                if ($('#<%=date.ClientID %>').val() == '') {
                    flag = false
                    $('#<%=lb_error_DOB.ClientID %>').html('DOB not entered')
                }
                else
                    $('#<%=lb_error_DOB.ClientID %>').html('')

                return flag
            })
        });


        //E mail validation
        function validateEmail($email) {
            var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
            if (!emailReg.test($email)) {
                return false;
            } else {
                return true;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body -->
    <uc:GuestAccountMaster ID="ctlGuestAccountMaster" runat="server">
        <Content>
            <div class="col" id="stepContainer">
                <div id="Step1">
                    <!-- Begin : Registration Header Text-->
                    <h1>
                        <%--Welcome to your Happytrip Account--%>
                        Register New Account
                    </h1>
                    <!-- End : Registration Header Text-->
                    <!-- Begin : Area to display errors during registration -->
                    <div id="step1_errors" class="errors clearfix">
                        <span>Oops, you’ll need to fix these issues before we can confirm your account</span>
                        <asp:Label ID="gendral_error" runat="server" CssClass="required error_msg"></asp:Label>
                    </div>
                    <!-- Begin : Form For Registration-->
                    <%--<form id="signin_details" runat="server">--%>
                    <!-- Begin : Form Fields For Registration-->
                    <div class="primary">
                        <h3 class="legend">
                            <%--Set a password to get started--%>Provide following details to get started
                        </h3>
                        <dl class="vertical">
                            <fieldset class="login">
                                <dt>
                                    <label for="username">
                                        Your email address</label></dt>
                                <dd>
                                <div style="display:none">
                                    <asp:ScriptManager ID="aspButtonLink" runat="server">
                                    </asp:ScriptManager></div>
                                    <asp:UpdatePanel ID="emailNameCheck" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox name="email" ID="EMailId" size="32" runat="server" class="textvalidation" />
                                            &nbsp;<asp:Button ID="hlCheckAvailaibilty" runat="server" Text="Check Availaibility"
                                                ToolTip="Click to Check User Avaibility" BorderColor="White" ClientIDMode="Static"
                                                CssClass="bubble" Width="131px" OnClick="hlCheckAvailaibilty_Click"></asp:Button><br />
                                            <asp:Label ID="email_error" runat="server" class="error_msg"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </dd>
                                <dd class="hint">
                                    This will be the username for your Happytrip Account
                                </dd>
                                <dt>
                                    <label class="required" for="password">
                                        Your password</label></dt>
                                <dd>
                                    <asp:TextBox class="required" name="user[password]" type="password" runat="server"
                                        ID="password" size="24" title="Your account password" TextMode="Password" />
                                    <asp:Label ID="lb_password_error" runat="server" class="error_msg"></asp:Label>
                                </dd>
                                <dt>Re-type your password </dt>
                                <dd>
                                    <asp:TextBox class="required" name="retype_password" type="password" ID="password_confirmation"
                                        runat="server" size="24" title="Password verification" TextMode="Password" />
                                    <asp:Label ID="lb_error_conformpassword" runat="server" class="error_msg"></asp:Label>
                                </dd>
                                <dt>
                                    <label for="title">
                                        Your name</label></dt>
                                <dd>
                                    <asp:TextBox name="personal_data[last_name]" ID="last_name" selflabel="Full name"
                                        runat="server" class="required selflabel" title="Your full name / surname" />
                                    <asp:Label ID="lb_error_username" runat="server" class="error_msg"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="gender">
                                        Gender</label></dt>
                                <dd>
                                    <asp:DropDownList ID="dl_gender" runat="server">
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </dd>
                                <dt>
                                    <label class="required" for="address1">
                                        Date Of Birth</label></dt>
                                <dd>
                                    <input type="text" id="date" runat="server" class="datePicker required" title="Your full name / surname"
                                        readonly="readonly" />
                                    <asp:Label ID="lb_error_DOB" runat="server" class="error_msg"></asp:Label>
                                </dd>
                            </fieldset>
                            <p class="submitButton">
                                <asp:Button ID="bt_Submit" runat="server" CssClass="next primary" Text="Submit →" OnClick="bt_Submit_Click" />
                            </p>
                        </dl>
                    </div>
                    <!-- End : Form Fields For Registration-->
                    <!-- Begin : Submit Button For Registration-->
                    &nbsp;<!-- End : Submit Button For Registration--><%--</form>--%><!-- End : Form For Registration--></div>
            </div>
        </Content>
    </uc:GuestAccountMaster>
    <!-- End : Main Body -->
</asp:Content>
