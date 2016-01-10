<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col l4 m4 s6 offset-l4 offset-m4 offset-s3 card z-depth-1-half" style="margin-top:110px;">
            <div class="card-panel teal text-white white-text" style="font:19px roboto bold">Enter Credentials</div>
            <div class="row">
                <asp:TextBox ID="txtEmployeeId" CssClass="input-field col l10 m10 s10 offset-l1 offset-m1 offset-s1" placeholder="Admin Id" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:TextBox ID="txtPassword" CssClass="input-field col l10 m10 s10 offset-l1 offset-m1 offset-s1" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Button ID="btnSubmit" CssClass="btn col offset-l4 offset-m4 offset-s4 l4 m4 s4" runat="server" Text="Login" OnClick="btnSubmit_Click" />
            </div>
            <div class="row">
                <asp:Label ID="lblMessage" CssClass="teal-text col offset-l1 offset-m1 offset-s1 m10 l10 s10 center " runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

