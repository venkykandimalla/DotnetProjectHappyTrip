<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQs.aspx.cs" Inherits="HappyTripWebApp.FAQs" %>
<%@ Register TagPrefix="uc" TagName="AccountMaster" Src="~/Controls/AccountMaster.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AccountMaster ID="ctlAccountMaster" runat="server">
        <Content>
            <div class="col">
                <h1>
                    Help &amp; FAQ
                </h1>
                <a name="before" style="display: none"></a>
                <h2>
                    Questions before you book
                </h2>
            
                <div id="FaqContainer">
                    <dl>
                        <dt><a href="#">What&rsquo;s an e&ndash;ticket?</a></dt>
                        <dd>
                            An e&ndash;ticket (electronic ticket) is a paperless electronic document with a
                            unique confirmation number that neatly replaces the hassles of a paper ticket. When
                            you purchase an e&ndash;ticket, we email it to you within 30 minutes of your booking.
                            Simply print it out and bring it with you &ndash; along with a valid photo ID &ndash;
                            to the airline counter when checking in for your flight.</dd>
                        <dt><a href="#">What is the maximum number of seats I can book?</a></dt>
                        <dd>
                            A maximum of 9 seats can be booked at one time. If you need to book for more than
                            9 travelers you will have to re&ndash;complete the booking process for the additional
                            travelers.</dd>
                        <dt><a href="#">Can I book a multi&ndash;city trip?</a></dt>
                        <dd>
                            Yes.</dd>
                        <dt><a href="#">Does Hapytrip offer any loyalty programmes?</a></dt>
                        <dd>
                            No, but there are attractive offers running on the homepage. Stay sharp and you
                            might grab a great deal.</dd>
                    </dl>
                </div>
            
                <a name="while" class="anchor_tag"></a>
                <h2>
                    Questions while you book
                </h2>
                <div id="FaqContainer">
                    <dl>
                        <dt><a href="#">I&rsquo;ve been getting zero flight results on the search page. What
                            gives?</a></dt>
                        <dd>
                            Clear your browser cache and try the search again. If you still don&rsquo;t get
                            any flight results, it may either be because we can&rsquo;t find flights for that
                            route or because there&rsquo;s no availability of flights for your dates.</dd>
                        <dt><a href="#">Where do I enter my frequent flyer number while booking domestic flights?</a></dt>
                        <dd>
                            We do not have an option of entering the frequent flier number at the time of booking
                            domestic flights. However, we can certainly pass on your frequent flier number to
                            the airline. Just call us as soon as you book your ticket and tell us your trip
                            id and your frequent flier number.</dd>
                        <dt><a href="#">I entered my payment details and hit submit &ndash; and all I got was
                            a blank screen! I got charged but don&rsquo;t have an e&ndash;ticket. What now?</a></dt>
                        <dd>
                            We&rsquo;re really sorry for the inconvenience. Please don&rsquo;t worry. We&rsquo;ll
                            call you within four hours and complete this booking offline. We suggest you do
                            not try booking again as you may end up getting charged twice.
                            <p>
                                If you&rsquo;re really impatient, call us at 1800 600 9000 (local call from any
                                phone) and we&rsquo;ll help you fix this immediately.</p>
                        </dd>
                    </dl>
                </div>
            </div>
        </Content>
    </uc:AccountMaster>
</asp:Content>
