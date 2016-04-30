<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="GetDataFromDevice.aspx.cs" Inherits="Admin_GetDataFromDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Get Data From Device</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <br />
        <br />
        <center>
             <asp:Button Text="Get Data From Device" runat="server" CssClass="btn" ID="btn_getData" OnClick="btn_getData_Click" />
             <asp:GridView runat="server" CssClass="responsive-table striped" ID="grid_Data"></asp:GridView>
        </center>
    </div>
</asp:Content>

