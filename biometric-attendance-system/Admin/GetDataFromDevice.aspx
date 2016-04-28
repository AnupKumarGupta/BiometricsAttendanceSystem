<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="GetDataFromDevice.aspx.cs" Inherits="Admin_GetDataFromDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Get Data From Device</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button Text="GetData" runat="server" ID="btn_getData" OnClick="btn_getData_Click" />
        <asp:GridView runat="server" ID="grid_Data"></asp:GridView>
    </div>
</asp:Content>

