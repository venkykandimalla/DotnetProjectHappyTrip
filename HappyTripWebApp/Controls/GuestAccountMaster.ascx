<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GuestAccountMaster.ascx.cs" Inherits="HappyTripWebApp.Controls.GuestAccountMaster" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
<div class="Signin">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div class="Left">
                    <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
                </div>
                <div class="Right">
                    <div class="col clearfix">
                        <asp:Image ID="Image1" ImageUrl="~/Images/suitcase.png" Style="margin-left: 40px;"
                            runat="server" Width="500" Height="500" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
