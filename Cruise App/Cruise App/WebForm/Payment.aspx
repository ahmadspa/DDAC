<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Cruise_App.WebForm.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Style/Decoration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h1>Transaction Page</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="inner-content" style="height:1215px"> <!--inner content start-->

        <div class="center-infor"><!--center informa start-->
            <h3>Trip Information...</h3>
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
                    <img src="../Image/pasific Costa.jpg"/>
                </div>
                <div class="center1">
                    <asp:Label ID="Label3" runat="server" Text="Ship: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblShipName" runat="server" Text="Sapphire Princess"></asp:Label><br />
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
                    <asp:Label ID="lblArrivalTime" runat="server" Text="00:00"></asp:Label><br />
                    <asp:Label ID="Label5" runat="server" Text="Cabin Type: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblCabin" runat="server" Text="Suite"></asp:Label><br />
                    <asp:Label ID="Label9" runat="server" Text="Cabin Description: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblCabinDesction" runat="server" Text="1 Guest Per Stater Room"></asp:Label><br />
                    <asp:Label ID="Label6" runat="server" Text="Meal Type: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblMeal" runat="server" Text="Masalodosa"></asp:Label>
                    
                </div>
                <div class="right1">
                    <%--<asp:Label ID="Label8" runat="server" Text="Stateroom Starting" CssClass="info"></asp:Label>--%>
                    <asp:Label ID="Label19" runat="server" Text=" Trip Cost " CssClass="info12"></asp:Label><br />
                    <asp:Label ID="lblDollasSign" runat="server" Text="$" CssClass="info13"></asp:Label>
                    <asp:Label ID="lblTripCost" runat="server" Text="000.00" CssClass="info14"></asp:Label><br /><br /><br />
               
                    <asp:Label ID="Label16" runat="server" Text="Additional: " CssClass="info6"></asp:Label>
                    <asp:Label ID="Label17" runat="server" Text="$" CssClass="info7"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Text="75.00" CssClass="info8"></asp:Label><br />
                    <asp:Label ID="lblTotal" runat="server" Text="Total Cost " CssClass="info9" ></asp:Label><br />
                    <asp:Label ID="Label2" runat="server" Text="$" CssClass="info10"></asp:Label>
                    <asp:Label ID="lblTotalCost" runat="server" Text="000.00" CssClass="info11"></asp:Label>
                </div>
            </div><!--cente ends-->
            <div class="bottom-info1"><!--bottom start-->
                <div class="Guest-number1">
                   <table class="purchasetable">
                       <tr>
                           <td class="table-column4">Package ID: <br /><br /> </td>
                           <td class="table-column5"><asp:TextBox ID="txtPackageID" runat="server" CssClass="textbox4" Height="35px" Width="380px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select the trip package below" ControlToValidate="txtPackageID" Font-Size="Small" Width="100%"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="table-column4">Full Name:<br /><br /> </td>
                           <td class="table-column5"><asp:TextBox ID="txtFullname" runat="server" CssClass="textbox4" Height="35px" Width="380px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your fullname" ControlToValidate="txtFullname" Font-Size="Small" Width="100%"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr >
                           <td class="table-column4">Todays Date: <br /><br /> </td>
                           <td class="table-column5"><asp:TextBox ID="txtDate" runat="server" CssClass="textbox4" Height="35px" Width="380px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter cabin description" ControlToValidate="txtDate" Font-Size="Small" Width="100%"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="table-column4">Payment:<br /><br />  </td>
                           <td class="table-column5"><asp:TextBox ID="txtPayment" runat="server" CssClass="textbox4" Height="35px" Width="380px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter payment" ControlToValidate="txtPayment" Font-Size="Small" Width="100%"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                   </table>
                </div>
                <div class="booking-info1">
                   
                    <div class="purchase-button-section">
                        <asp:Button ID="btnPurchase" runat="server" Text="Purchase" CssClass="purchase" Height="45px" Width="120px" OnClick="btnPurchase_Click"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel-button1" CausesValidation="false" Height="45px" Width="120px"/>
                        <asp:Label ID="lblMessage" runat="server"  CssClass="lblMessage12"></asp:Label>
                     
                    </div>
                    
                </div> <!--booking info ends-->
             
            </div><!--bottom ends-->
            
        </div><!--top information1 end-->
         <div id="gridview3">
                <%--gridview start--%>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Horizontal" Width="100%" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
        <%--gridview end--%>
    </div><!--inner content ends-->
</asp:Content>

