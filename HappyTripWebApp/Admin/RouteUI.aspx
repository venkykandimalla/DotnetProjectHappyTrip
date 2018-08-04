<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RouteUI.aspx.cs" Inherits="HappyTripWebApp.Admin.RouteUI" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=GridView1.ClientID%> tr:first").wrap("<thead>");
            $("#<%=GridView1.ClientID%> tr:gt(0)").wrap('<tbody class="selected">');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Manage Routes" Width="50%" ShowPager="true" OnPreviousPageClick="lbtPreviousPage_Click" OnNextPageClick="lbtNextPage_Click">
        <Content>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderWidth="0" Width="100%" PagerSettings-Visible="false" 
                AutoGenerateColumns="False" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblDist" Text='<%#Eval("RouteId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="FromCityName" HeaderText="From City" ReadOnly="true" ItemStyle-Width="40%" />
                    <asp:BoundField DataField="ToCityName" HeaderText="To City" ReadOnly="true" ItemStyle-Width="40%" />
                    
                    <asp:TemplateField HeaderText="Distance&nbsp;in&nbsp;Kms">
                        <ItemTemplate>
                            <asp:Label ID="lblDist" Text='<%#Eval("DistanceInKms") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDist" Text='<%#Eval("DistanceInKms") %>' runat="server" MaxLength="5" Width="75px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error_msg"
                                ControlToValidate="txtDist" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Distance should be a positive number" ValidationExpression="^[0-9]\d*$"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="Status" HeaderText="Active" Visible="false" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
