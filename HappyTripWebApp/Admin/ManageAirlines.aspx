<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAirlines.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageAirlines" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=grdAirline.ClientID%> tr:first").wrap("<thead>");
            $("#<%=grdAirline.ClientID%> tr:gt(0)").wrap('<tbody class="selected">');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Manage Airlines" Width="50%" ShowPager="true" OnPreviousPageClick="lbtPreviousPage_Click" OnNextPageClick="lbtNextPage_Click">
        <Content>
            <asp:GridView ID="grdAirline" runat="server" AllowPaging="True" BorderWidth="0" Width="100%" PagerSettings-Visible="false" 
                DataSourceID="sdsAirline" AutoGenerateColumns="False" 
                DataKeyNames="AirlineId" PageSize="5" 
                onpageindexchanged="grdAirline_PageIndexChanged" OnRowDataBound="grdAirline_RowDataBound" OnRowUpdating="grdAirline_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="AirlineId" HeaderText="AirlineId" InsertVisible="False" ReadOnly="True" SortExpression="AirlineId" Visible="false" />
                    <asp:BoundField DataField="AirlineName" HeaderText="AirlineName" SortExpression="AirlineName" ItemStyle-Width="100%" />
                    <asp:BoundField DataField="AirlineCode" HeaderText="AirlineCode" SortExpression="AirlineCode" />
                    <%--<asp:BoundField DataField="AirlineLogo" HeaderText="AirlineLogo" SortExpression="AirlineLogo" InsertVisible="false" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="AirlineLogo">
                        <ItemTemplate>
                            <div class="airline_logos AI"></div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="AirlineLogo" runat="server" Value='<%# Bind("AirlineLogo")%>' />
                            <div class="airline_logos AI"></div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            
            <asp:SqlDataSource ID="sdsAirline" runat="server" ConnectionString="<%$ ConnectionStrings:HappyTripConnectionString %>"
                DeleteCommand="DELETE FROM [Airlines] WHERE [AirlineId] = @AirlineId" InsertCommand="INSERT INTO [Airlines] ([AirlineName], [AirlineCode], [AirlineLogo]) VALUES (@AirlineName, @AirlineCode, @AirlineLogo)"
                SelectCommand="SELECT * FROM [Airlines]" 
                UpdateCommand="IF NOT EXISTS(SELECT 1 FROM [Airlines] WHERE [AirlineCode]=@AirlineCode AND [AirlineId] <> @AirlineId) UPDATE [Airlines] SET [AirlineName] = @AirlineName, [AirlineCode] = @AirlineCode, [AirlineLogo] = @AirlineLogo WHERE [AirlineId] = @AirlineId" 
                onupdated="sdsAirline_Updated">
                <DeleteParameters>
                    <asp:Parameter Name="AirlineId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="AirlineName" Type="String" />
                    <asp:Parameter Name="AirlineCode" Type="String" />
                    <asp:Parameter Name="AirlineLogo" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="AirlineName" Type="String" />
                    <asp:Parameter Name="AirlineCode" Type="String" />
                    <asp:Parameter Name="AirlineLogo" Type="String" />
                    <asp:Parameter Name="AirlineId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
