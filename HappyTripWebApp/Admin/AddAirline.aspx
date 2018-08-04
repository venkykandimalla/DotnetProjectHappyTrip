<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAirline.aspx.cs" Inherits="HappyTripWebApp.Admin.AddAirline" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Add Airline" Width="30%" ShowPager="false">
        <Content>
            <table border="0" id="tbloutbound">
                <tbody class="selected">
                <tr>
                    <td>
                        Airline&nbsp;Name&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcrAirlineName" MaxLength="50"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error_msg" 
                            ControlToValidate="txtcrAirlineName" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Airline name can contain only alphabets and hyphen(-)" ValidationExpression="[a-zA-Z -]+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Airline&nbsp;Code&nbsp;<span class="error_msg">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcrAirlineCode" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rexValAirlineCode" runat="server" CssClass="error_msg" 
                            ControlToValidate="txtcrAirlineCode" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Airline Code can contain only alphabets numbers and hyphen '-'" ValidationExpression="[a-zA-Z0-9 -]+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Airline Logo
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtcrAirlineLogoPath" Text="Images/air_logos/air_logos3.gif" style="display:none"></asp:Label>
                        <div class="airline_logos AI"></div>
                    </td>
                </tr>
                <tbody class="selected">
                <tr>
                    <th colspan="2" style="text-align:right">
                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnClear" Text="Cancel" onclick="btnClear_Click" />
                    </th>
                </tr>
            </table>
        
            <asp:SqlDataSource ID="sdsAirline" runat="server" 
                ConnectionString="<%$ ConnectionStrings:HappyTripConnectionString %>" 
                DeleteCommand="DELETE FROM [Airlines] WHERE [AirlineId] = @AirlineId" 
                InsertCommand="IF NOT EXISTS(SELECT 1 FROM Airlines WHERE AirlineCode=@AirlineCode) INSERT INTO [Airlines] ([AirlineName], [AirlineCode], [AirlineLogo]) VALUES (@AirlineName, @AirlineCode, @AirlineLogo)" 
                SelectCommand="SELECT * FROM [Airlines]" 
                UpdateCommand="UPDATE [Airlines] SET [AirlineName] = @AirlineName, [AirlineCode] = @AirlineCode, [AirlineLogo] = @AirlineLogo WHERE [AirlineId] = @AirlineId">
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
    </uc:AdminMaster>
</asp:Content>
