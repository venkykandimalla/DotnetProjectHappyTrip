<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Travel_Class.aspx.cs" Inherits="HappyTripWebApp.Admin.Travel_Class" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 614px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />

    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
    Text="Add Travel Class" />
<br />
<br />
<table style="width:100%;">
    <tr>
        <td class="style1" align="center">
            &nbsp;<asp:GridView ID="GridView1" runat="server" Width="450px" 
                AutoGenerateColumns="False" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                CellPadding="3" CellSpacing="1" GridLines="None" Height="185px">
                <Columns>
                    <asp:BoundField DataField="ClassId" HeaderText="ID" HeaderStyle-HorizontalAlign=Center HeaderStyle-VerticalAlign=Middle />
                    <asp:BoundField DataField="ClassType" HeaderText="Class Name"  HeaderStyle-HorizontalAlign=Center HeaderStyle-VerticalAlign=Middle/>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
            <br />
        </td>
        <td>
            <asp:Panel ID="Panel1" runat="server" Height="216px" style="margin-left: 0px" 
                Width="413px">
                <table style="width:100%; height: 214px;">
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Add Travel Class"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblClassName" runat="server" Text="Class Name:"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnAdd" runat="server" AccessKey="a" Text="Add" 
                                onclick="btnAdd_Click" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnClear" runat="server" AccessKey="c" Text="Clear" 
                                onclick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
    <br />
<br />
</asp:Content>
