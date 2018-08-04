<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HappyTripWebApp.About" %>
<%@ Register TagPrefix="uc" TagName="AccountMaster" Src="~/Controls/AccountMaster.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <uc:AccountMaster ID="ctlAccountMaster" runat="server">
        <Content>
            <div class="col">
                <h1>About HappyTrip</h1>
                
                <h2 class="first">
                    HappyTrip is dedicated to making travel simple</h2>
                <p>
                    But it&rsquo;s hard to make things easy, so we&rsquo;ve put together an experienced
                    team with oodles of global experience in travel and ecommerce. Happyrippers come
                    in all shapes and sizes; and we&rsquo;re all passionate about just one thing - Making
                    travel simple.</p>
                <h2>
                    About HappyTrip.com</h2>
                <p>
                    HappyTrip.com is the travel site that gives you what you need without any annoying
                    fluff. Who needs banners, pop-ups and blinking glitz? Search, book, go. That&rsquo;s
                    what we&rsquo;re about - Making travel simple.</p>
                <p>
                    We made a list of some of the things we want to be:</p>
                <ul>
                    <li><strong>Simple:</strong> Simplicity is a religion at HappyTrip. If we&rsquo;re not
                        the easiest place to search and book your travel, feel free to give us a piece of
                        your mind.</li>
                    <li><strong>Comprehensive:</strong> Part of making travel simple is presenting you with
                        all the options for your trip. We&rsquo;re working closely with suppliers to add
                        more airlines and hotels to our search.</li>
                    <li><strong>Reliable:</strong> Making travel simple implies making a travel site that
                        just works and works. We still have the occasional hiccup, but being there for you,
                        reliably, is very important to us.</li>
                    <li><strong>Responsible:</strong> We take responsibility for what we give you. You won&rsquo;t
                        hear us making excuses for airlines or hotels or availability or prices. If we show
                        you a price, we will honour it, come what may.</li>
                </ul>
            </div>
        </Content>
    </uc:AccountMaster>
</asp:Content>
