<%@ Page Title="Add Holiday" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AddHoliday.aspx.cs" Inherits="Admin_AddHoliday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s12 breadcrumb">
            <br />
            <a href="~/Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
            <a href="#!" class="teal-text">&nbsp;&nbsp;Add Holiday &nbsp;&nbsp;</a>
        </div>
        <div class="col s6 m6 l6 offset-s3 offset-m3 offset-l3 card">
            <br />
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="picker__calendar-container"></asp:Calendar>
            <br />
            <asp:Label ID="lblDate" runat="server" CssClass="input-field" Text="Date"></asp:Label>
            <asp:TextBox ID="txtHoliday" placeholder="Name of Holiday" CssClass="input-field" runat="server">
            </asp:TextBox>
            <div class="row">
                <div class="col s4 m4 l4 offset-s4 offset-m4 offset-l4">
                    <asp:Button ID="btnAddHoliday" runat="server" Text="Add Holiday" CssClass="btn" OnClick="btnAddHoliday_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>

