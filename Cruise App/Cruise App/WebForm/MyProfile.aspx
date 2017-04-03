<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="Cruise_App.WebForm.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Decoration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Profile Page</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <ul>
        <li><a>
            <asp:LinkButton ID="lnkMyProfile" runat="server"><img  src="../Image/home24.png" />My Profile</asp:LinkButton></a></li>
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
    <div id="inner-content" style="height: 890px;">
        <%--inner content start--%>
        <div>
            <%--upper cotnent start--%>
            <%-- <h1>Put the Content Here</h1>--%>
            <div id="left-side">
                <%--left side start--%>
                <div id="logged">
                    <%--logged start--%>
                    <div class="image-profile">
                        <%--image profile start--%>
                        <img src="../Image/user-profile-icon.png" />
                    </div>
                    <%--image profile end--%>
                    <div class="user-info">
                        <%--user info start--%>
                        <asp:Label ID="lblUsername" runat="server" Text="Bry Mussolin"></asp:Label><br />
                        <asp:Label ID="lblEmail" runat="server" Text="b.ri88@hotmail.com"></asp:Label>
                    </div>
                    <%--user info end--%>
                </div>
                <%--logged end--%>
                <div class="sub-menu">
                    <%--sub menu start--%>
                    <h2>Sub Menu</h2>
                    <div class="side-menu">
                        <%--side menu start--%>
                        <div id="option">
                            <img src="../Image/user16.png" />
                            <asp:LinkButton CausesValidation="false" ID="LinkButton1" CssClass="menu1" runat="server" 
                                OnClick="LinkButton1_Click">View My Profile</asp:LinkButton>
                        </div>
                        <div class="option">
                            <img src="../Image/shoppingcart16.png" />
                            <asp:LinkButton CausesValidation="false" ID="LinkButton2" CssClass="menu1" runat="server" OnClick="LinkButton2_Click">
                                Pending Booking ( <asp:Label ID="lblTotalPendingBooking" runat="server" Text="0"></asp:Label> )
                            </asp:LinkButton>
                        </div>
                    </div>
                    <%--side menu end--%>
                </div>
                <%--sub menu end--%>
            </div>
            <%--left side end--%>
            <div id="right-side">
                <%--right side start--%>
                <div id="calendar">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" DayStyle-CssClass="no-decoration" runat="server" BackColor="#FFFFFF" BorderColor="#666666" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Palatino Linotype" Font-Size="11pt" ForeColor="White" Height="370px" ShowGridLines="True" Width="100%" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender">
                                <DayHeaderStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Bold="False" Height="1px" Font-Size="12pt" Font-Underline="False" />
                                <DayStyle Font-Size="11pt" BackColor="#CCCCCC" ForeColor="#232323"/>
                                <NextPrevStyle Font-Size="13pt" ForeColor="#333333" />
                                <OtherMonthDayStyle ForeColor="#232323" Font-Size="11px" BackColor="#FFFFFF" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="False" Font-Size="11pt" BorderWidth="0"/>
                                <SelectorStyle BackColor="#FFCC66"/>
                                <TitleStyle BackColor="#CCCCCC" Font-Bold="False" Font-Size="12pt" ForeColor="#333333" />
                                <TodayDayStyle BackColor="#666666" ForeColor="White" Wrap="true" BorderWidth="0"/>
                                <WeekendDayStyle Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--right side end--%>
            <div style="width: 500px; float: right; height: 61px; position: absolute; top: 658px; right: 180px;">
                <p style="display: inline;">Todays Date:</p>
                <asp:Label ID="Label1" runat="server" Height="35px" Width="100px" CssClass="diffcolor"></asp:Label>
                <p style="display: inline">Trips Date:</p>
                <asp:Label ID="Label2" runat="server" Height="35px" Width="100px" CssClass="diffcolor1"></asp:Label>
            </div>
        </div>
        <%--upper cotnent end--%>
        <div id="gridview">
            <%--gridview start--%>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Horizontal" Width="100%" HorizontalAlign="Center" CssClass="gridview-table" AlternatingRowStyle-CssClass="gridview-table" >
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
        <%--gridview end--%>
    </div>
    <%--inner contend end--%>
</asp:Content>


