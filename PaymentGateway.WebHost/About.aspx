<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="PaymentGateway.WebHost.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        Payment Gateway Service, which will
        <ul>
            <li>Validate the Credit Card</li>
            <li>Process the payment</li>
        </ul>
    </p>
</asp:Content>
