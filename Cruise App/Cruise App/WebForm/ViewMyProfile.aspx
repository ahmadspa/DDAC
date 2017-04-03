<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/FunctionSite.Master" AutoEventWireup="true" CodeBehind="ViewMyProfile.aspx.cs" Inherits="Cruise_App.WebForm.ViewMyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Decoration.css" rel="stylesheet" />
    <link href="../Style/Style.css" rel="stylesheet" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>View My Profile Page</h1>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="inner-content" style="height:825px">
        <h2 style="margin-left:145px;">Personal Information:-</h2>
        <div>
            <table>
                <tr>
                    <td class="table-column1">First Name:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtFname" runat="server" CssClass="textbox" Height="40px" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your first name" ControlToValidate="txtFname" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Last Name:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtLname" runat="server" CssClass="textbox" Height="40px" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your last name" ControlToValidate="txtLname" Font-Size="Small" ForeColor="#333333"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Gender:<br /><br /></td>
                    <td class="table-column2"><asp:DropDownList ID="dpoGender" runat="server" CssClass="textbox" Height="45px" Width="455px">
                        <asp:ListItem>Select Your Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select your gender" ControlToValidate="dpoGender" Font-Size="Small" ForeColor="#333333" InitialValue="Select Your Gender" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Contact:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtContact" runat="server" CssClass="textbox" Height="40px" Width="450px" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your contact" ControlToValidate="txtContact" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Email:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Height="40px" Width="450px" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter your email" ControlToValidate="txtEmail" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Address:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" Height="40px" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your address" ControlToValidate="txtAddress" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Username:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Height="40px" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter your username" ControlToValidate="txtUsername" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Password:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Height="40px" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtPassword" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="table-column1">Confirm Password:<br /><br /></td>
                    <td class="table-column2"><asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" Height="40px" Width="450px" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator runat="server" ErrorMessage="Password do not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Font-Size="Small" ForeColor="#333333" Width="98%"></asp:CompareValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
            <div id="buttons-message">
                <div class="buttons">
                    <asp:Button ID="btnSignup" runat="server" Text="Update" CssClass="signup-button" CausesValidation="true" OnClick="btnSignup_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation ="false"  CssClass="cancel-button" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
