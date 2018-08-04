<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelSearch.aspx.cs" Inherits="HappyTripWebApp.HotelSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!-- Begin : Main page body -->
    <div class="Home Flights SixtyForty">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <!-- Begin : Left side form content -->
                <div class="Left">
                    <div class="col">
                        <h1>
                            Search Hotels</h1>
                        <!-- Begin : Area to display errors while searching for flights -->
                        <div id="flt_err_contiainer">
                                            <label for="origin_autocomplete" class="required">&nbsp; City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox CssClass="autocomplete required" runat="server" 
                                ToolTip="From" ID="txtCity" Width="196px"></asp:TextBox>
                                            </label>
                        </div>
                        <div id="mc_flt_err_contiainer" style="display: none">
                            <div id="mc_flt_err" class="errors">
                                <span>There were errors in your submission</span><ol>
                                </ol>
                            </div>
                        </div>
                        <!-- End : Area to display errors while searching for flights -->

                        <!-- Begin : Form to capture search information -->
                        <form method="get" id="HotelSearch">&nbsp;&nbsp;&nbsp;
                        
                        <fieldset>
                            <table>
                                <colgroup>
                                    <col width="50%"/>
                                    <col width="50%"/>
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <td class="style1">
                                            <label for="origin_autocomplete" class="required">&nbsp; Check In&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox CssClass="autocomplete required" runat="server" ToolTip="From" 
                                                ID="txtCheckIn" Width="119px"></asp:TextBox>
                                            </label>
&nbsp;<!--
                                                <select name="from" id="from" size="1" class="airportsDrodown" title="Origin locations" cookieselection="no"></select>
												--></td>
                                        <td>
                                            <label for="destination_autocomplete" class="required">
                                                Check Out&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                            <asp:TextBox CssClass="autocomplete required" runat="server" ToolTip="To" 
                                                ID="txtChckOut"></asp:TextBox>
                                            </label>
&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </fieldset>
                        <fieldset class="people">
                            <table>
                                <colgroup>
                                    <col width="25%">
                                    <col width="25%">
                                    <col width="25%">
                                    <col width="25%">
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <td>
                                            &nbsp; <strong>No Of Rooms</strong>&nbsp;&nbsp;
                                            <select runat="server" name="NoOfRooms" size="1">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                                <option value="6">6</option>
                                                <option value="7">7</option>
                                                <option value="8">8</option>
                                                <option value="9">9</option>
                                            </select></td>
                                    </tr>
                                </tbody>
                            </table>
                        </fieldset>
                        <fieldset class="options" id="advanced_search1" style="">
                            <table>
                                <colgroup>
                                    <col width="50%">
                                    <col width="50%">
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <td>
                                            &nbsp; <strong>No Of People</strong>&nbsp;&nbsp;
                                            <select id="Select1" runat="server" name="NoOfPeople" size="1">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                                <option value="6">6</option>
                                                <option value="7">7</option>
                                                <option value="8">8</option>
                                                <option value="9">9</option>
                                            </select></td>
                                    </tr>
                                </tbody>
                            </table>
                        </fieldset>
                        <fieldset class="submit">
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Button ID="button_hotel_search" ToolTip="search" CssClass="booking" 
                                                runat="server" Text="Search Hotels"  />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </fieldset>
                        </form>
                        <!-- End : Form to capture search information -->
                    </div>
                </div>
                <!-- End : Left side form content -->

                <!-- Begin : Right side slider with images-->
                <div class="Right">
                    <div class="col">
                        <div id="aside">
                            <div class="slider-wrapper theme-default">
                                <div id="slider" class="nivoSlider">
                                    <img src="images/pic1.jpg" data-thumb="images/pic1.jpg" alt="" />
                                    <a href="#">
                                        <img src="images/pic2.jpg" data-thumb="images/pic2.jpg" alt="" title="Welcome to happy trip" /></a>
                                    <img src="images/pic3.jpg" data-thumb="images/pic3.jpg" alt="" data-transition="slideInLeft" />
                                    <img src="images/pic4.jpg" data-thumb="images/pic4.jpg" alt="" title="#htmlcaption" />
                                </div>
                                <div id="htmlcaption" class="nivo-html-caption">
                                    <strong>Fly</strong> to <em>Paris with</em><a href="#">Happy Trip</a>.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End : Right side slider with images -->
            </div>
        </div>
    </div>
    </div>
    
<!-- End : Main page body-->
</asp:Content>
