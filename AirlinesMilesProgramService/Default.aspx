<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AirlinesMilesProgramService.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h1>
                Welcome to Airlines Miles Program Service</h1>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdAirlines" runat="server" BackColor="White" 
                            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </td>
                    <td>
                        <table border="1">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Airline ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAirlineID" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Minimum Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinAmt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Exempted Amout"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExmptAmt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnAddAirlines" runat="server" Text="Add Airlines for Happy Miles Program"
                                        OnClick="btnAddAirlines_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
