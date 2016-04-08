<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col l4 m4 s6 offset-l4 offset-m4 offset-s3 card z-depth-1-half" style="margin-top: 110px;">
            <div class="card-panel teal text-white white-text" style="font: 19px roboto bold">Enter Credentials</div>
            <div class="row">

                <div class="input-field col l10 m10 s10 offset-l1 offset-m1 offset-s1 ">
                    <i class="material-icons prefix">account_circle</i>
                    <asp:TextBox ID="txtEmployeeId" class="validate" runat="server" />
                    <label for="txtEmployeeId">Admin ID</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col l10 m10 s10 offset-l1 offset-m1 offset-s1 ">
                    <i class="material-icons prefix">lock</i>
                    <asp:TextBox ID="txtPassword" type="password" class="validate" runat="server" />
                    <label for="txtPassword">Password</label>
                </div>
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

