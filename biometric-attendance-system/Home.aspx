<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <table>
                <tr>
                    <td>Employee Id:</td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <asp:Button ID="btnSubmit" runat="server" Text="LOGIN" OnClick="btnSubmit_Click" />
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
