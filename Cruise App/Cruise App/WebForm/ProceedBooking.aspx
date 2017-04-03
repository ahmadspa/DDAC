<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="ProceedBooking.aspx.cs" Inherits="Cruise_App.WebForm.ProceedBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Decoration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Booking Page</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <ul>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkMyProfile" runat="server" OnClick="lnkMyProfile_Click"><img  src="../Image/home24.png" />My Profile</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkManageBooking" runat="server" OnClick="lnkManageBooking_Click"><img  src="../Image/file_add24.png" />Manage Booking</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnlTrackCuise" runat="server" OnClick="lnlTrackCuise_Click"><img src="../Image/wheels24.png" />Track Cruise Trip</asp:LinkButton></a></li>
        <%--<li><a href="Sign Up.aspx"><img src="../Image/user-add-icon.png" /></a>Others</li>--%>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"><img src="../Image/login_out24.png" />Logout</asp:LinkButton></a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="inner-content" style="height:800px"> <!--inner content start-->

        <div class="center-infor"><!--center informa start-->
            <h3>Booking Information...</h3>
        </div><!--center inform ends-->

        <div id="top-information1"><!--top information1 start-->
            <div class="top-info"><!--top start-->
                <div class="left">
                    <asp:Label ID="lblDays" runat="server" Text="0" CssClass="lblDay" Font-Bold="True"></asp:Label><br />
                    <asp:Label ID="Label1" runat="server" Text="Days" CssClass="lblDayName" Font-Bold="True"></asp:Label>
                </div>
                <div class="center">
                    <asp:Label ID="lblArrivalCity" runat="server" Text="Strait of Malacca" CssClass="lblArrivalCity"></asp:Label><br />
                    <asp:Label ID="lblTripOption" runat="server" Text="Roundtrip" CssClass="lblTripOption"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="From" CssClass="lblFrom"></asp:Label>
                    <asp:Label ID="lblDeparture" runat="server" Text="Any Port" CssClass="lblDestination"></asp:Label>
                </div>
            </div><!--top ends-->
            <div class="center-info"><!--center start-->
                <div class="left1">
                    <img src="../Image/singapore.jpg"/>
                </div>
                <div class="center1">
                    <asp:Label ID="Label3" runat="server" Text="Ship: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblShipName" runat="server" Text="Sapphire Princess"></asp:Label><br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Ports: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDepur" runat="server" Text="Deperture Port"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Text=" | " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDesti" runat="server" Text="Destination Port"></asp:Label><br />
                    <asp:Label ID="Label28" runat="server" Text="Departure Date: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDepartureDate" runat="server" Text="00/00/0000"></asp:Label><br />
                    <asp:Label ID="Label30" runat="server" Text="Departure Time: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDepartureTime" runat="server" Text="00:00"></asp:Label><br />
                    <asp:Label ID="Label32" runat="server" Text="Arrival Date: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblArrivalDate" runat="server" Text="00/00/0000"></asp:Label><br />
                    <asp:Label ID="Label34" runat="server" Text="Arrival Time: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblArrivalTime" runat="server" Text="00:00"></asp:Label>
                </div>
                <div class="right1">
                    <asp:Label ID="Label8" runat="server" Text="Stateroom Starting" CssClass="info"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text=" From: " CssClass="info1"></asp:Label><br />
                    <asp:Label ID="lblDollasSign" runat="server" Text="$" CssClass="info2"></asp:Label>
                    <asp:Label ID="lblTripCost" runat="server" Text="430.00" CssClass="info3"></asp:Label><br /><br /><br />
                    <asp:Label ID="Label14" runat="server" Text="Per Person" CssClass="info4"></asp:Label><br /><br />
                    <asp:Label ID="Label15" runat="server" Text="Port Expences" CssClass="info5"></asp:Label><br />
                    <asp:Label ID="Label16" runat="server" Text="Additional: " CssClass="info6"></asp:Label>
                    <asp:Label ID="Label17" runat="server" Text="$" CssClass="info7"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Text="75.00" CssClass="info8"></asp:Label><br />
                </div>
            </div><!--cente ends-->
            <div class="bottom-info"><!--bottom start-->
                <div class="Guest-number">
                    <table>
                        <tr>
                            <td>Number of Guest: </td>
                            <td class="table-column3"><asp:DropDownList ID="dpoGuestNumber" runat="server" CssClass="textbox1" Height="40px" Width="240px" OnSelectedIndexChanged="dpoGuestNumber_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Select Number of Guest</asp:ListItem>
                                <asp:ListItem>1 Guest Per Stater Room</asp:ListItem>
                                <asp:ListItem>2 Guest Per Stater Room</asp:ListItem>
                                <asp:ListItem>3 Guest Per Stater Room</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select guest number" ControlToValidate="dpoGuestNumber" Font-Size="Small" InitialValue="Select Number of Guest"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="booking-info">
                    <table class="booking-table-info">
                        <tr class="booking-table-info-row" style="background:rgba(0,0,0,0.6); color:rgba(255,255,255,0.9);">
                            <td class="booking-table-info-column"><p style="font-weight:bold">Stateroom Type</p></td>
                            <td class="booking-table-info-column"><asp:RadioButton ID="rdbOceanview" runat="server" Checked="True" Font-Bold="True" Text="Ocean View" OnCheckedChanged="rdbOceanview_CheckedChanged" AutoPostBack="true" /></td>
                            <td class="booking-table-info-column"><asp:RadioButton ID="rdbBalcony" runat="server" Font-Bold="True" Text="Balcony" OnCheckedChanged="rdbBalcony_CheckedChanged" AutoPostBack="true"/></td>
                            <td class="booking-table-info-column"><asp:RadioButton ID="rdbSuite" runat="server" Font-Bold="True" Text="Suite" OnCheckedChanged="rdbSuite_CheckedChanged" AutoPostBack="true"/></td>
                        </tr>
                        <tr class="booking-table-info-row">
                            <td class="booking-table-info-column">
                                <asp:Label ID="lblTripDate1" runat="server" Text="Trip Date" Font-Bold="True"></asp:Label><br />
                                <asp:Label ID="lblAnotherShipName" runat="server" Text="Ship Name" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblOceanViewPrice1" runat="server" Text="430.00" CssClass="price"></asp:Label></td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblBalconyPrice1" runat="server" Text="580.00" CssClass="price"></asp:Label></td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblSuitePrice1" runat="server" Text="1600.00" CssClass="price"></asp:Label></td>
                        </tr>
                        <tr class="booking-table-info-row">
                            <td class="booking-table-info-column"><p style="font-weight:bold">Guests 2 & 3 - Same Stateroom</p></td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblOceanViewPrice2" runat="server" Text="226.00" CssClass="price"></asp:Label></td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblBalconyPrice2" runat="server" Text="292.00" CssClass="price"></asp:Label></td>
                            <td class="booking-table-info-column"><p class="dollar-symbols">$ </p><asp:Label ID="lblSuitePrice2" runat="server" Text="820.00" CssClass="price"></asp:Label></td>
                        </tr>
                    </table>
                    <div class="book-button-section">
                        <asp:Button ID="btnBook" runat="server" Text="Book" CssClass="book-button" Height="45px" Width="116px" OnClick="btnBook_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button" Height="45px" Width="116px" OnClick="btnBack_Click" />
                        <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
                    </div>
                </div>
             
            </div><!--bottom ends-->
            
        </div><!--top information1 end-->

    </div><!--inner content ends-->
</asp:Content>
