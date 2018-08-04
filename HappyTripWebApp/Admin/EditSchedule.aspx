<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSchedule.aspx.cs" Inherits="HappyTripWebApp.Admin.EditSchedule" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Edit Schedule Flight" Width="50%" ShowPager="false">
        <Content>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" id="tbloutbound">
                        <tbody class="selected">
                        <tr>
                            <td>
                                Select Route
                            </td>
                            <td>
                                <asp:DropDownList ID="dpRoute" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Departure Time
                            </td>
                            <td>
                                Hours&nbsp;
                                <asp:DropDownList ID="dpDepartHours" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                                Mins&nbsp;
                                <asp:DropDownList ID="dpDepartMins" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Arrival Time
                            </td>
                            <td>
                                Hours&nbsp;
                                <asp:DropDownList ID="dpArrivalHours" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                                Mins&nbsp;
                                <asp:DropDownList ID="dpArrivalMins" runat="server" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="dpArrivalMins_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Duration in Mins
                            </td>
                            <td>
                                <asp:TextBox ID="txtDuration" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Class
                            </td>
                            <td>
                                <div id="lblErrorMessageLocal" runat="server" class="error_msg"></div>
                                
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                                    Width="100%" BorderWidth="0">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Class" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClass" Text='<%#Eval("Class") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtClass" Text='<%# ((FlightCost)Container.DataItem).Class.ToString()%>'
                                                    runat="server" ReadOnly="true" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cost" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCost" Text='<%#Eval("CostPerTicket") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCost" Text='<%# ((FlightCost)Container.DataItem).CostPerTicket %>'
                                                    runat="server" />
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error_msg"
                                                    ControlToValidate="txtCost" EnableClientScript="true" SetFocusOnError="true" Text="*" ErrorMessage="Cost should be in currency format" ValidationExpression="^[0-9]+(\.[0-9]+)?$"></asp:RegularExpressionValidator>--%>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Airline Name
                            </td>
                            <td>
                                <asp:DropDownList ID="dpAirlineName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpAirlineName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Flight Name
                            </td>
                            <td>
                                <asp:DropDownList ID="dpFlightName" runat="server">
                                </asp:DropDownList>
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
                        <tbody class="selected">
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

            <table border="0" id="Table1">
                <tr>
                    <th style="text-align:right">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click1" Text="Cancel" />
                    </th>
                </tr>
            </table>
        </Content>
        <BottomContent>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>
