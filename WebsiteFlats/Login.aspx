<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 76px;
        }
        .auto-style3 {
            width: 179px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">E-mail:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Please enter your e-mail" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter your password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
