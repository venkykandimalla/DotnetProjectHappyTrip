<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HappyTripWebApp.Admin.Home" %>
<%@ Register TagPrefix="uc" TagName="AdminMaster" Src="~/Controls/AdminMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminMaster ID="ctlAdminMaster" runat="server" Heading="Hi Admin" Width="75%" ShowPager="false">
        <Content>
            <table border="0" id="tbloutbound">
                <thead>
                <tr>
                    <th>&nbsp;&nbsp;</th>
                    <th>
                        <div class="error_msg" style="text-align:center; font-size:large">Welcome Home !!!</div>
                    </th>
                    <th>&nbsp;&nbsp;</th>
                </tr>
                </thead>
            </table>
        </Content>
        <BottomContent>
            <%--<div class="col">
                <h1>Quick Links</h1>
            </div>--%>
        </BottomContent>
    </uc:AdminMaster>
</asp:Content>