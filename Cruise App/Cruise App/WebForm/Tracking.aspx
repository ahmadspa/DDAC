<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="Cruise_App.WebForm.Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Decoration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tracking Cruise Trip Page</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="inner-content" style="height: 940px">
        <!--inner content start-->
        <div class="center-infor">
            <!--center informa start-->
            <h3>Track You Trip...</h3>
        </div>
        <!--center inform ends-->

        <div id="top-information2">
            <!--top information1 start-->
            <div class="top-info1">
                <!--top start-->
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                        <div class="my-content">
                            <asp:Label ID="lblHour" runat="server" Text="0" CssClass="time" Height="120px" Width="120px" Font-Bold="True"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text=":" CssClass="time" Height="130px" Width="40px" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblMinute" runat="server" Text="0" CssClass="time" Height="120px" Width="130px" Font-Bold="True"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text=":" CssClass="time" Height="130px" Width="40px" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblSecond" runat="server" Text="10" CssClass="time" Height="120px" Width="120px" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblMediterinian" runat="server" Text="AM" CssClass="time1" Font-Size="40pt" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="event-content">
                            <div class="info2">
                                <asp:Label ID="Label5" runat="server" Text="0" CssClass="Day" Width="129px" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text="Days Left" CssClass="Day" Font-Bold="True"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!--top ends-->
        </div>
        <!--top information1 end-->
        <div id="mytripinfo">
            <h3>My Trips List...</h3>
        </div>
        <div id="gridview2">
            <%--gridview start--%>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Horizontal" Width="100%" HorizontalAlign="Center" CssClass="gridview-table" AlternatingRowStyle-CssClass="gridview-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                <Columns>
                    <asp:ButtonField CommandName="Select" Text="Select" />
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
    <!--inner content ends-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <ul>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkMyProfile" runat="server" OnClick="lnkMyProfile_Click"><img  src="../Image/home24.png" />My Profile</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkManageBooking" runat="server" OnClick="lnkManageBooking_Click"><img  src="../Image/file_add24.png" />Manage Booking</asp:LinkButton></a></li>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnlTrackCuise" runat="server"><img src="../Image/wheels24.png" />Track Cruise Trip</asp:LinkButton></a></li>
        <%--<li><a href="Sign Up.aspx"><img src="../Image/user-add-icon.png" /></a>Others</li>--%>
        <li><a>
            <asp:LinkButton CausesValidation="false" ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"><img src="../Image/login_out24.png" />Logout</asp:LinkButton></a></li>
    </ul>
</asp:Content>