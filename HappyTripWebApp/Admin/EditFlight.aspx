<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFlight.aspx.cs" Inherits="HappyTripWebApp.Admin.EditFlight" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Edit Flight" Width="50%" ShowPager="false">
        <Content>
            <table border="0" id="tbloutbound">
                <tbody class="selected">
                <tr>
                    <td>
                        Name&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnName" runat="server" />
                        <asp:TextBox ID="txtName" runat="server" />
                        <asp:RegularExpressionValidator ID="rexFlightName" runat="server" CssClass="error_msg" 
                            ControlToValidate="txtName" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Flight name can contain only alphanumerics and hyphen(-)" ValidationExpression="[a-zA-Z0-9 -]+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Airline&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAirLine" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Class/Seats&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0"
                            onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="Class" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" Text='<%#Eval("ClassInfo") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtClass" Text='<%# ((FlightClass)Container.DataItem).ClassInfo.ToString() %>' runat="server"  ReadOnly="true" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Seats" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoOfSeats" Text='<%#Eval("NoOfSeats") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNoOfSeats" Text='<%# ((FlightClass)Container.DataItem).NoOfSeats %>' runat="server" MaxLength="5" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error_msg" 
                                            ControlToValidate="txtNoOfSeats" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Seats should be a positive number" ValidationExpression="^[0-9]\d*$"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="Edit" ShowEditButton="True" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                </tbody>
                <tr>
                    <th colspan="2" style="text-align:right">
                        <asp:Button Text="Update" ID="btnUpdate" runat="server" onclick="btnUpdate_Click"  />
                        <asp:Button Text="Cancel" ID="btnCancel" runat="server" onclick="btnCancel_Click" />
                    </th>
                </tr>
            </table>
        </Content>
    </uc:AdminMaster>
</asp:Content>
