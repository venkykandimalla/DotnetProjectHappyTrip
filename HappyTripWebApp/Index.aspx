<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.cs"
    Inherits="HappyTripWebApp.Index" %>
<%@ Register TagPrefix="uc" TagName="BookingToolbar" Src="~/Controls/BookingToolbar.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent" ID="headContent">
    <script type="text/javascript">
        $(function () {
            var MainContentId = $('#hdnMainContentId').val();
            $("#" + MainContentId + "_dpt_date").datepicker({
                showOn: "button",
                buttonImage: "Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                minDate: 0,
                maxDate:+90,
                yearRange: '-0:+2',
                changeMonth: true,
                changeYear: true
                //            onSelect: function (dateText, inst) {
                //                var d = new Date(dateText);
                //                var selday = d.getDay();
                //                var selmonth = d.getMonth() + 1; //Months are zero based
                //                var selyear = d.getFullYear();
                //                $("#" + MainContentId + "_dpt_date").val(selyear + "/" + selmonth + "/" + selday);
                //            }
            });
            $("#" + MainContentId + "_rtn_date").datepicker({
                showOn: "button",
                buttonImage: "Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true,
                minDate: 0,
                maxDate:+90,
                yearRange: '-0:+2',
                changeMonth: true,
                changeYear: true
                //            onSelect: function (dateText, inst) {
                //                var d = new Date(dateText);
                //                var selday = d.getDay();
                //                var selmonth = d.getMonth() + 1; //Months are zero based
                //                var selyear = d.getFullYear();
                //                $("#" + MainContentId + "_rtn_date").val(selyear + "/" + selmonth + "/" + selday);
                //            }
            });
            $('#slider').nivoSlider();
        });

    </script>
    <script type="text/javascript">

        $(function () {
            $("#MainContent_origin_autocomplete").autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "Index.aspx/GetCities",
                        dataType: "json",
                        data: "{ searchterm: '" + request.term + "' }",
                        type: "POST",
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $.each(data, function (index, element) {

                                response($.map($.parseJSON(element), function (item) {
                                    return {
                                        value: item.CityId,
                                        label: item.Name + ' (' + item.StateInfo.Name + ')'
                                    };
                                }))
                            });


                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                        }
                    });
                },
                select: function (event, ui) {
                    //alert("Here");
                    event.preventDefault();
                    $("#MainContent_hdnFrom").val(ui.item.value);
                    //$("#MainContent_origin_autocomplete").val(ui.item.label);
                    setTimeout(function () {
                        $('#MainContent_destination_autocomplete').focus();
                    }, 1);
                },
                focus: function (event, ui) { event.preventDefault(); $("#MainContent_origin_autocomplete").val(ui.item.label); },
                change: function (event, ui) { $("#MainContent_origin_autocomplete").val(ui.item.label); },
                minLength: 3
            });

            $("#MainContent_destination_autocomplete").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Index.aspx/GetCities",
                        dataType: "json",
                        data: "{ searchterm: '" + request.term + "' }",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $.each(data, function (index, element) {

                                response($.map($.parseJSON(element), function (item) {
                                    return {
                                        value: item.CityId,
                                        label: item.Name + ' (' + item.StateInfo.Name + ')'
                                    }
                                }))
                            });


                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                select: function (event, ui) {
                    //alert("Here");
                    event.preventDefault();
                    $("#MainContent_hdnTo").val(ui.item.value);
                    //$("#MainContent_destination_autocomplete").val(ui.item.label);
                    setTimeout(function () {
                        $('#MainContent_dpt_date').focus();
                    }, 0);
                },
                focus: function (event, ui) { event.preventDefault(); $("#MainContent_destination_autocomplete").val(ui.item.label); },
                change: function (event, ui) { $("#MainContent_destination_autocomplete").val(ui.item.label); },
                minLength: 3
            });


            $(document).ready(function () {
                //$("#MainContent_one_way").attr("checked", "checked");
                if ($("#MainContent_one_way").is(':checked')) {
                    $('#tdReturn').hide();
                };
                $('#MainContent_one_way').click(function () {
                    if (this.checked) {
                        $('#tdReturn').hide();
                    }
                });
                $('#MainContent_multi_city').click(function () {
                    if (this.checked) {
                        $('#tdReturn').show();
                    }
                });
            });

        });
    </script>
    <style type="text/css">
        #flt_err_contiainer
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <uc:BookingToolbar ID="ctlBookingToolbar" runat="server"></uc:BookingToolbar>
    <!-- Begin : Main page body -->
    <div class="Home Flights SixtyForty">
        <div id="Wrapper" style="clear:none">
            <div class="Container">
                <div id="ContentFrame">
                    <!-- Begin : Left side form content -->
                    <div class="Left">
                        <div class="col">
                            <h1>
                                Search Flights
                            </h1>
                            <!-- Begin : Area to display errors while searching for flights -->
                            <div id="flt_err_contiainer">
                                <div id="flt_err" class="errors">
                                    <span>There were errors in your submission</span><ol>
                                    </ol>
                                </div>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="color: #FF0000"></asp:Label>
                            </div>
                            <div id="mc_flt_err_contiainer" style="display: none">
                                <div id="mc_flt_err" class="errors">
                                    <span>There were errors in your submission</span><ol>
                                    </ol>
                                </div>
                            </div>
                            <!-- End : Area to display errors while searching for flights -->
                            <!-- Begin : Form to capture search information -->
                            <form method="get" class="search no-action-change removeSelflabels" id="AirSearch"
                            errorblockid="flt_err">
                            <fieldset class="search_type">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td width="100px;">
                                                <label for="<%=one_way.ClientID%>" class="encaps">
                                                    <asp:RadioButton ID="one_way" runat="server" GroupName="rnd_one" Checked="true" />
                                                    <strong>One way</strong></label>
                                            </td>
                                            <td width="100px;">
                                                <label for="<%=multi_city.ClientID%>" class="encaps">
                                                    <asp:RadioButton ID="multi_city" runat="server" GroupName="rnd_one" />
                                                    <strong>Return</strong></label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </fieldset>
                            <fieldset class="place">
                                <table>
                                    <colgroup>
                                        <col width="50%" />
                                        <col width="50%" />
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label for="origin_autocomplete" class="required">
                                                    From <span class="weak">(any city)</span></label>
                                                <asp:TextBox CssClass="autocomplete required" runat="server" ToolTip="From" ID="origin_autocomplete"></asp:TextBox>
                                                <asp:HiddenField ID="hdnFrom" runat="server" />
                                                <!--
                                                <select name="from" id="from" size="1" class="airportsDrodown" title="Origin locations" cookieselection="no"></select>
												-->
                                            </td>
                                            <td>
                                                <label for="destination_autocomplete" class="required">
                                                    To <span class="weak">(any city)</span></label>
                                                <asp:TextBox CssClass="autocomplete required" runat="server" ToolTip="To" ID="destination_autocomplete"></asp:TextBox>
                                                <asp:HiddenField ID="hdnTo" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </fieldset>
                            <fieldset class="date">
                                <table>
                                    <colgroup>
                                        <col width="25%">
                                        <col width="25%">
                                        <col width="50%">
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td id="tdDepart">
                                                <label for="dpt_date" class="required">
                                                    Depart on</label>
                                                <span class="enclosedPicker">
                                                    <asp:TextBox ID="dpt_date" CssClass="datePicker required" Rows="10" name="depart_date"
                                                        ToolTip="Departure date" runat="server"></asp:TextBox>
                                                </span>
                                            </td>
                                            <td id="tdReturn">
                                                <label for="rtn_date" class="required" style="">
                                                    Return on</label>
                                                <span class="enclosedPicker" style="">
                                                    <asp:TextBox ID="rtn_date" CssClass="datePicker second required no_autochange" maxdate="7/1/2014"
                                                        mindatefieldid="dpt_date" selflabel="dd/mm/yyyy" Rows="10" name="return_date"
                                                        ToolTip="Return date" runat="server"></asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                                <label for="adults" class="required">
                                                    No Of Seats</label>
                                                <select id="adults" runat="server" name="adults" size="1">
                                                    <option value="1">1</option>
                                                    <option value="2">2</option>
                                                    <option value="3">3</option>
                                                    <option value="4">4</option>
                                                    <option value="5">5</option>
                                                    <option value="6">6</option>
                                                    <option value="7">7</option>
                                                    <option value="8">8</option>
                                                    <option value="9">9</option>
                                                </select>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </fieldset>
                            <fieldset class="options" id="advanced_search1" style="">
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
                                                <label for="class" class="required">
                                                    Class of travel</label>
                                                <asp:DropDownList ID="ddlClass" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                            </fieldset>
                            <fieldset class="submit">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Button ID="button_flight_search" ToolTip="search" CssClass="booking" runat="server"
                                                    Text="Search flights" OnClick="button_flight_search_Click" />
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
