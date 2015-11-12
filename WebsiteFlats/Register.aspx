<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<script runat="server">

    
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Checkbox1 {
            height: 140px;
            width: 454px;
        }
        #Text1 {
            margin-left: 117px;
        }
        #Text2 {
            margin-left: 85px;
        }
        #Text3 {
            margin-left: 22px;
        }
        #text1 {
            margin-left: 119px;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 166px;
        }
        .auto-style3 {
            width: 181px;
        }
        .auto-style4 {
            width: 166px;
            height: 29px;
        }
        .auto-style5 {
            width: 181px;
            height: 29px;
        }
        .auto-style6 {
            height: 29px;
        }
        #Reset1 {
            width: 88px;
            margin-left: 122px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Email</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter a proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" EnableTheming="True" ErrorMessage="Please enter an email" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please enter a password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Confirm password:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please enter a password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="Please enter the same password" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">You are a:</td>
                <td class="auto-style3">
               

               
                  <asp:DropDownList ID="StudentOrLandlord" runat="server" 
                OnSelectedIndexChanged="StudentOrLandlord_SelectedIndexChanged"
                AutoPostBack="True">
               <asp:ListItem Text="Select User Type" Value="0">
                </asp:ListItem>
                <asp:ListItem Text="Student" Value="1">
                </asp:ListItem>
                <asp:ListItem Text="Landlord" Value="2">
                </asp:ListItem>
            </asp:DropDownList>



                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="First Name:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter a name St" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox5" ErrorMessage="Please enter a name LN" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Last Name:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox6" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox6" ErrorMessage="Please enter a name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox7" ErrorMessage="Please enter a name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Address:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox8" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox8" ErrorMessage="Please enter an address" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox9" ErrorMessage="Please enter an address" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Post Code:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox10" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox10" ErrorMessage="Please enter a post code" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox11" ErrorMessage="Please enter a post code" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="City:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox12" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox12" ErrorMessage="Please enter a city" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox13" ErrorMessage="Please enter a city" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Country:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox14" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox14" ErrorMessage="Please enter a country" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox15" ErrorMessage="Please enter a country" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Phone:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox16" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox16" ErrorMessage="Please enter a phone number" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox17" ErrorMessage="Please enter a phone number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
            <asp:Button ID="Button1" runat="server" style="margin-left: 172px" Text="Next" OnClick="Button1_Click" />
                </td>
                <td>
            <input id="Reset1" type="reset" value="reset" /></td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
