<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenericErrorPage.aspx.cs" Inherits="HappyTripWebApp.GenericErrorPage" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<uc:MenuC ID="AdminMenu1" runat="server" />
    
    <br />


<h1 class="style1">An error occured while processing your request...</h1>
<hr />
    <asp:Label ID="lblError" runat="server" Text="" style="font-size: medium"></asp:Label>
</asp:Content>
