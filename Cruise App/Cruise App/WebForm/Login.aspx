<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cruise_App.WebForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/LoginStyle.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 511px;
        }
        .send {
            width: 126px;
        }
        .Hp-login{
            position:absolute;
            top:35px;
            right:115px;
            color:rgba(0,0,0,0.6);
            font-size:18px;
            text-align:center;
            font-weight:bold;
            height: 30px;
            text-decoration:none;
        }
        .Hp-login:hover{
            position:absolute;
            top:35px;
            right:115px;
            color:#0094ff;
            font-size:18px;
            text-align:center;
            font-weight:bold;
            cursor:pointer;         
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="outer">
            <div class="inner">
                <div>
                    <div class="info">
                        <h1>Login Authentication</h1>
                        <img src="../Image/add_user24.png" style="height: 22px; width: 22px; position: absolute; top: 38px; right: 190px" />

                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Hp-login" CausesValidation="false" OnClick="LinkButton1_Click">Sing Up</asp:LinkButton>
                    </div>
                    <h4>Please Enter Your Login Credentials Below.</h4>
                </div>
                <table class="table">
                    <tr>
                        <td class="text">Username:<br />
                            <br />
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Height="35px" Width="390px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUsername" Font-Size="Small" Width="75%" CssClass="valid">Please enter your username</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">Password:<br />
                            <br />
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Height="35px" Width="390px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword" Font-Size="Small" Width="75%" CssClass="valid">Please enter your password</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                </table>
                <div class="buttons">
                    <div class="message">
                        <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
                    </div>
                    <div class="cancel">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="" OnClick="btnCancel_Click" CausesValidation="false" />
                    </div>
                    <div class="send">
                        <asp:Button ID="btnSend" runat="server" Text="Login" OnClick="btnSend_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
