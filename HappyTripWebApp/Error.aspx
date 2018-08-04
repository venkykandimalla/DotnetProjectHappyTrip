<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HappyTripWebApp.Error" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <h2>Sorry, we couldn't complete your request. Please check your input</h2>
    <p>Click <a href="<%=ResolveClientUrl("~/Index.aspx")%>">Here</a> to go back.</p>
</asp:Content>

