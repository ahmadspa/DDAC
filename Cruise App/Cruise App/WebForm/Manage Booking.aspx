<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="Manage Booking.aspx.cs" Inherits="Cruise_App.WebForm.Manage_Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Decoration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Booking Page</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <ul>
        <li><a>
            <asp:LinkButton ID="lnkMyProfile" runat="server" OnClick="lnkMyProfile_Click"><img  src="../Image/home24.png" />My Profile</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton ID="lnkManageBooking" runat="server" OnClick="lnkManageBooking_Click"><img  src="../Image/file_add24.png" />Manage Booking</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton ID="lnlTrackCuise" runat="server" OnClick="lnlTrackCuise_Click"><img src="../Image/wheels24.png" />Track Cruise Trip</asp:LinkButton></a></li>
        <%--<li><a href="Sign Up.aspx"><img src="../Image/user-add-icon.png" /></a>Others</li>--%>
        <li><a>
            <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"><img src="../Image/login_out24.png" />Logout</asp:LinkButton></a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="inner-content" style="height: 1120px">
        <div class="center-infor">
            <h3>Find Your Shipment</h3>
        </div>
        <div id="top-information">
            <div class="left-top-info">
                <table>
                    <tr>
                        <td class="table-column3">
                            <asp:DropDownList ID="dpoCountry" runat="server" Height="40px" Width="300px" CssClass="textbox1">
                                <asp:ListItem>Country - Any</asp:ListItem>
                                <asp:ListItem>Ireland</asp:ListItem>
                                <asp:ListItem>Mexico</asp:ListItem>
                                <asp:ListItem>Belize</asp:ListItem>
                            </asp:DropDownList></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="table-column3">
                            <asp:DropDownList ID="dpoLenght" runat="server" Height="40px" Width="300px" CssClass="textbox1">
                                <asp:ListItem>Lenght of Shipment - Any</asp:ListItem>
                                <asp:ListItem>1 - 5 Days</asp:ListItem>
                                <asp:ListItem>6 - 8 Days</asp:ListItem>
                                <asp:ListItem>9 - 15 Days</asp:ListItem>
                                <asp:ListItem>16 or More Days</asp:ListItem>
                            </asp:DropDownList></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="table-column3">
                            <asp:DropDownList ID="dpoShip" runat="server" Height="40px" Width="300px" CssClass="textbox1">
                                <asp:ListItem>Ship - Any</asp:ListItem>
                                <asp:ListItem>DHL</asp:ListItem>
                                <asp:ListItem>Fedex</asp:ListItem>
                                <asp:ListItem>Lightning</asp:ListItem>
                                
                            </asp:DropDownList></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="table-column3">
                            <asp:DropDownList ID="dpoDeparture" runat="server" Height="40px" Width="300px" CssClass="textbox1">
                                <asp:ListItem>Departure Port - Any</asp:ListItem>
                                <asp:ListItem>Hoston, Texas</asp:ListItem>
                                <asp:ListItem>Ft. Lauderdale, Florida</asp:ListItem>
                                <asp:ListItem>London (Southampton), England</asp:ListItem>
                                <asp:ListItem>New York City (Manhattan or Brooklyn), New York</asp:ListItem>
                            </asp:DropDownList></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="table-column3">
                            <asp:DropDownList ID="dpoDestination" runat="server" Height="40px" Width="300px" CssClass="textbox1">
                                <asp:ListItem>Destination Port - Any</asp:ListItem>
                                <asp:ListItem>Dublin, Ireland</asp:ListItem>
                                <asp:ListItem>Belize City, Belize</asp:ListItem>
                                <asp:ListItem>Progreso, Mexico</asp:ListItem>
                                <asp:ListItem>Island of Cozumel, Mexico</asp:ListItem>
                            </asp:DropDownList></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="right-top-info">
                <div class="calendar">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" DayStyle-CssClass="no-decoration" runat="server" BackColor="#FFFFFF" BorderColor="#666666" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Palatino Linotype" Font-Size="11pt" ForeColor="White" Height="300px" ShowGridLines="True" Width="100%" NextPrevFormat="FullMonth">
                                <DayHeaderStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Bold="False" Height="1px" Font-Size="12pt" Font-Underline="False" />
                                <DayStyle Font-Size="11pt" BackColor="#CCCCCC" ForeColor="#232323" />
                                <NextPrevStyle Font-Size="13pt" ForeColor="#333333" />
                                <OtherMonthDayStyle ForeColor="#232323" Font-Size="11px" BackColor="#FFFFFF" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="False" Font-Size="11pt" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#CCCCCC" Font-Bold="False" Font-Size="12pt" ForeColor="#333333" />
                                <TodayDayStyle BackColor="#666666" ForeColor="White" BorderWidth="0"/>
                                <WeekendDayStyle Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="search-navigation">
            <div class="search-button">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Search11" OnClick="btnSearch_Click" /></div>
        </div>
        <div style="width: 500px; float: right; height: 61px; position: absolute; top: 678px; right: 180px;">
            <p style="display: inline;">Todays Date:</p>
            <asp:Label ID="Label1"  runat="server" Height="35px" Width="100px" CssClass="diffcolor"></asp:Label>
            <p style="display: inline">Trips Date:</p>
            <asp:Label ID="Label2" runat="server" Height="35px" Width="100px" CssClass="diffcolor1"></asp:Label>
            
        </div>
        <div id="gridview1">
            <%--gridview start--%>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Horizontal" Width="100%" HorizontalAlign="Center" CssClass="gridview-table" AlternatingRowStyle-CssClass="gridview-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                <Columns>
                    <asp:ButtonField CommandName="Select" Text="Details" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
