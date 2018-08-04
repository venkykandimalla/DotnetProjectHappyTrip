<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register_Success.aspx.cs" Inherits="HappyTripWebApp.Account.Register_Success" %>
<%@ Register TagPrefix="uc" TagName="GuestAccountMaster" Src="~/Controls/GuestAccountMaster.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Begin : Link to css files -->
    <link rel="stylesheet" href="../Styles/account.css" type="text/css" />
    <link rel="stylesheet" href="../Styles/register.css"  type="text/css" />
    <!-- End : Link to css files -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body -->
    <uc:GuestAccountMaster ID="ctlGuestAccountMaster" runat="server">
        <Content>
            <div class="col" id="stepContainer">
                <div id="Step1">
                    <h1>
                        Registration Success!
                    </h1>
                    <div class="primary">
                        <h3 class="legend">Thank You for creating an account with Happy Trip</h3>
                        <h3 class="legend">Please <a href="Login.aspx">click here</a> to log in</h3>
                    </div>
                </div>
            </div>
        </Content>
    </uc:GuestAccountMaster>
    <!-- End : Main Body -->
</asp:Content>
