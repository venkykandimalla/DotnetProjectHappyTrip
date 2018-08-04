<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdateProfile.aspx.cs" Inherits="HappyTripWebApp.UpdateProfile" %>
<%@ Register TagPrefix="uc" TagName="AccountMaster" Src="~/Controls/AccountMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#<%=date.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                yearRange: '-90:+0',
                changeMonth: true,
                changeYear: true
            });

            /*$('#<=ctlAccountMaster.ViewControlClientID%>').click(function () {
                $('#Edit_Div').hide();
                $('#Display_Div').show();
                return false;
            })*/

            //$('#<=ctlAccountMaster.UpdateControlClientID%>').click(function () {
            $('#<%=btnUpdateProfile.ClientID%>').click(function () {
                $("#<%=UpdateLabel.ClientID%>").text("");
                $("#<%=UpdateLabel_container.ClientID%>").hide();
                
                $('#Edit_Div').show();
                $('#Display_Div').hide();
                return false;
            })

            $('#<%=btnCancel.ClientID%>').click(function () {
                $('#Edit_Div').hide();
                $('#Display_Div').show();
                return false;
            })

            if (($("#<%=hdnShowEditControls.ClientID%>").val() == "1") || ('<%=Request.QueryString["upd"]%>' == "1")) {
                $('#Edit_Div').show();
                $('#Display_Div').hide();
            }
        });

        //        function display() {
        //            document.getElementById('Edit_Div').style.display = 'block'
        //            document.getElementById('Display_Div').style.display = 'none'
        //            return false;
        //        }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body Content -->
    <uc:AccountMaster ID="ctlAccountMaster" runat="server">
        <Content>
            <div class="col">
                <div id="Step1">
                    <div class="clearfix">
                        <h1 style="float:left">
                            <%--Welcome to your Happytrip Account--%>
                            My Account
                        </h1>
                        <h1 style="float:right">
                            <asp:Button ID= "btnUpdateProfile" runat="server" Text="Update Profile" style="float:right" />
                        </h1>
                    </div>
                    <!-- Begin : Area to display errors during profile update -->
                    <div id="step1_errors" class="errors clearfix">
                        <span>Oops, you’ll need to fix these issues before we can confirm your account</span>
                    </div>
                    <!-- End : Area to display errors during profile update -->
                    <!-- Begin : Form to display and update profile information-->
                    <fieldset class="primary">
                        <div id="Display_Div">
                            <dl class="vertical">
                                <dt id="lbl_error_container" runat="server" visible="false">
                                    <asp:Label ID="lbl_error" runat="server" CssClass="error_msg"></asp:Label>
                                </dt>
                                <dt>
                                    <label for="title">
                                        <strong>Your name</strong></label></dt>
                                <dd>
                                    <asp:Label ID="lbname" runat="server"></asp:Label>
                                    &nbsp;</dd>
                                <dt>
                                    <label class="required" for="gender">
                                        Gender</label></dt>
                                <dd>
                                    <asp:Label ID="lbgender" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="address1">
                                        Date Of Birth (mm/dd/yyyy)</label></dt>
                                <dd>
                                    <asp:Label ID="lbDOB" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="address1">
                                        Address line
                                    </label>
                                </dt>
                                <dd>
                                    <asp:Label ID="lbAddress" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="city">
                                        City</label></dt>
                                <dd>
                                    <asp:Label ID="lbCity" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="state">
                                        State</label></dt>
                                <dd>
                                    <asp:Label ID="lbState" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label class="required" for="pin">
                                        Pin Code</label></dt>
                                <dd>
                                    <asp:Label ID="lbPib" runat="server"></asp:Label>
                                </dd>
                                <dt>
                                    <label for="mobile_number">
                                        <strong>Mobile number</strong></label></dt>
                                <dd>
                                    <asp:Label ID="lbMobile" runat="server"></asp:Label>
                                    &nbsp;</dd>
                            </dl>
                        </div>
                        <div id="Edit_Div" style="display: none">
                            <dl class="vertical">
                                <dt id="UpdateLabel_container" runat="server" visible="false">
                                    <label for="title" id="update">
                                        <asp:Label ID="UpdateLabel" CssClass="error_msg" runat="server"></asp:Label>
                                    </label>
                                </dt>
                                <dt>
                                    <label for="title">
                                        Your name</label></dt>
                                <dd>
                                    <asp:TextBox ID="Name" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;</dd>
                                <dt>
                                    <label class="required" for="gender">
                                        Gender</label></dt>
                                <dd>
                                    <asp:DropDownList ID="Gender" runat="server">
                                        <asp:ListItem Selected="True">None</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </dd>
                                <dt>
                                    <label class="required" for="address1">
                                        Date Of Birth</label></dt>
                                <dd>
                                    <asp:TextBox class="datePicker required" type="text" name="dateOfBirth" title="Date Of Birth"
                                        runat="server" ID="date" size="10" />
                                </dd>
                                <dt>
                                    <label class="required" for="<%=Address1.ClientID%>">
                                        Address line
                                    </label>
                                </dt>
                                <dd>
                                    <asp:TextBox ID="Address1" runat="server" Width="334px"></asp:TextBox>
                                </dd>
                                <dt>
                                    <label class="required" for="city">
                                        City</label></dt>
                                <dd>
                                    <asp:TextBox ID="City" runat="server" Width="154px"></asp:TextBox>
                                </dd>
                                <dt>
                                    <label class="required" for="state">
                                        State</label></dt>
                                <dd>
                                    <asp:TextBox ID="State" runat="server"></asp:TextBox>
                                </dd>
                                <dt>
                                    <label class="required" for="pin">
                                        Pin Code</label></dt>
                                <dd>
                                    <asp:TextBox ID="Pincode" runat="server"></asp:TextBox>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="Pincode" ErrorMessage="Pincode Should be 6 Digits" Font-Bold="True"
                                        ForeColor="Red" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                </dd>
                                <dt>
                                    <label for="mobile_number">
                                        Mobile number</label></dt>
                                <dd>
                                    <asp:TextBox ID="MobileNo" runat="server"></asp:TextBox>
                                    &nbsp;
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="MobileNo"
                                        ErrorMessage="Mobile Number should be 10 digits only" Font-Bold="True" ForeColor="Red"
                                        ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                </dd>
                            </dl>
                            <p class="submitButton">
                                <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />
                                <asp:Button ID= "btnCancel" runat="server" Text="Cancel" />
                                <input type="hidden" id="hdnShowEditControls" runat="server" value="0" />
                            </P>
                        </div>
                    </fieldset>
                    <!-- End : Form to display and update profile information -->
                    <br />
                </div>
            </div>
        </Content>
    </uc:AccountMaster>
    <!-- End : Main Body Content -->
</asp:Content>
