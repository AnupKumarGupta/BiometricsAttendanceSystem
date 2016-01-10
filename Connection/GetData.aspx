<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetData.aspx.cs" Inherits="GetData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button Text="GetData" runat="server" ID="btn_getData" OnClick="btn_getData_Click"/>

        <asp:GridView runat="server" ID="grid_Data"></asp:GridView>
    </div>
    </form>
</body>
</html>
