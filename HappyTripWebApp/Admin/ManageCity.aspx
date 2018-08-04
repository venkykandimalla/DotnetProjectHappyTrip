<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCity.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageCity" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=grdCity.ClientID%> tr:first").wrap("<thead>");
            $("#<%=grdCity.ClientID%> tr:gt(0)").wrap('<tbody class="selected">');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Manage Cities" Width="40%" ShowPager="true" OnPreviousPageClick="lbtPreviousPage_Click" OnNextPageClick="lbtNextPage_Click">
        <Content>
            <asp:GridView ID="grdCity" runat="server" AllowPaging="True" BorderWidth="0" Width="100%" PagerSettings-Visible="false" 
                AutoGenerateColumns="False" onrowcancelingedit="grdCity_RowCancelingEdit" DataKeyNames="CityId"
                onrowediting="grdCity_RowEditing" onrowupdating="grdCity_RowUpdating" onpageindexchanging="grdCity_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="CityName" ItemStyle-Width="40%" >
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("Name") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCityName"  Text='<%#Eval("Name") %>' runat="server" />
                            <asp:RegularExpressionValidator ID="cityNameValidator" runat="server" CssClass="error_msg" 
                                ControlToValidate="txtCityName" EnableClientScript="True" SetFocusOnError="true" Text="*" ErrorMessage="City name should have only alphabets" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State" ItemStyle-Width="100%">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "StateInfo.Name")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtState"  Text='<%#DataBinder.Eval(Container.DataItem, "StateInfo.Name")%>' runat="server" ReadOnly="true" />
                            <asp:HiddenField ID="hdnStateId"  Value='<%#DataBinder.Eval(Container.DataItem, "StateInfo.StateId")%>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource ID="odsCity" runat="server" SelectMethod="GetCities" TypeName="HappyTrip.Model.BusinessLayer.AirTravel.CityManager"></asp:ObjectDataSource>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
