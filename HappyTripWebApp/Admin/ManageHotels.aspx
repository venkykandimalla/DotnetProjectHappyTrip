<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageHotels.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageHotels" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <uc:MenuC ID="AdminMenu1" runat="server" />
    
    <br />

<h1>Manage Hotels</h1>
<hr color="red" />
<center>
 
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
        DataSourceID="ObjectDataSource1" Height="50px" Width="625px" 
        CellPadding="10" ForeColor="#333333" Caption="Manage Hotel Details" 
        DataKeyNames="HotelId" EmptyDataText="No Hotels available" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowInsertButton="True" />

              
               
        </Fields>
        
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <InsertRowStyle BorderColor="#CC3300" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="HappyTrip.Model.Entities.Hotel.Hotel" DeleteMethod="DeleteHotel" 
        InsertMethod="SaveHotel" SelectMethod="GetAllHotels" 
        TypeName="HappyTrip.Model.BusinessLayer.Hotel.HotelManager" 
        UpdateMethod="UpdateHotel"></asp:ObjectDataSource>
        </center>

    </asp:Content>
