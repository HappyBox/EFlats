<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 251px;
        }
        .auto-style3 {
            width: 255px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dmaj0914_2Sem_4ConnectionString %>" SelectCommand="SELECT * FROM [LD_Main]"></asp:SqlDataSource>
                </td>
                <td class="auto-style3">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dmaj0914_2Sem_4ConnectionString %>" SelectCommand="SELECT * FROM [LD_Personal]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dmaj0914_2Sem_4ConnectionString %>" SelectCommand="SELECT * FROM [LD_Queue]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,Email" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                            <asp:CheckBoxField DataField="Confirmed" HeaderText="Confirmed" SortExpression="Confirmed" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style3">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                            <asp:BoundField DataField="PostCode" HeaderText="PostCode" SortExpression="PostCode" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="DateOfCreation" HeaderText="DateOfCreation" SortExpression="DateOfCreation" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
