<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PaymentGateway.WebHost._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Payment Gateway Web Host !
    </h2>
    <p>
        Payment Gateway Server: Click <a href="PaymentGatewayService.svc">here</a> to see
        the details
    </p>
    <p>
        <center>
            <asp:GridView ID="grdCards" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                ForeColor="Black">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </center>
    </p>
</asp:Content>
