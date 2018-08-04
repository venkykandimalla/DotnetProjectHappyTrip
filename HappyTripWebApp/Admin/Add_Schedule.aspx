<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_Schedule.aspx.cs" Inherits="HappyTripWebApp.Admin.Add_Schedule" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Add Schedule" Width="50%" ShowPager="false">
        <Content>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" id="tbloutbound">
                        <tbody class="selected">
                        <tr>
                            <td>
                                Select Route&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="dpRoute" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Departure&nbsp;Time&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                Hours&nbsp;
                                <asp:DropDownList ID="dpDepartHours" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                                Mins&nbsp;
                                <asp:DropDownList ID="dpDepartMins" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Arrival Time&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                Hours&nbsp;
                                <asp:DropDownList ID="dpArrivalHours" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                                Mins&nbsp;
                                <asp:DropDownList ID="dpArrivalMins" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Duration&nbsp;in&nbsp;Mins&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDuration" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Airline Name&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="dpAirlineName" runat="server" OnSelectedIndexChanged="dpAirlineName_SelectedIndexChanged" AutoPostBack="True" Width="135px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Flight Name&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="dpFlightName" runat="server" AutoPostBack="true" Width="131px" onselectedindexchanged="dpFlightName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Class Cost&nbsp;<span class="error_msg">*</span>
                            </td>
                            <td>
                                <table style="width:50%;">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th style="width:1%">
                                                    <asp:Label ID="ClassName" Text='<%# ((TravelClass)Container.DataItem).ToString() %>' runat="server" />&nbsp;&nbsp;
                                                </th>
                                                <th>
                                                    <asp:TextBox ID="txtCostPerTicket" Text="0" Width="50px" MaxLength="9" runat="server" />
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage= '<%# ((TravelClass)Container.DataItem).ToString() +" seat cost should be a positive currency value" %>' ControlToValidate="txtCostPerTicket" Text="*" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]+)?$" Display="Dynamic" SetFocusOnError="true" EnableClientScript="true"></asp:RegularExpressionValidator>--%>
                                                </th>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Active
                            </td>
                            <td>
                                <asp:CheckBox ID="chkStatus" runat="server" />
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

            <table style="width: 100%;" border="0" id="Table1">
                <tr>
                    <th style="text-align:right">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                    </th>
                </tr>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
