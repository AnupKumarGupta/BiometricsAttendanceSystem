<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AddSession.aspx.cs" Inherits="Admin_AddSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
        <div class="col s12 breadcrumb">
            <br />
            <a href="~/Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
            <a href="#!" class="teal-text">&nbsp;&nbsp;Add Session &nbsp;&nbsp;</a>
        </div>
        <div class="col s4 m4 l4 offset-s1 offset-m1 offset-l1 card">
            <asp:GridView ID="grdSession" runat="server" AutoGenerateColumns="false" CssClass="responsive-table striped" EmptyDataText="No Data">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Session Start Date" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSessionStartDate" runat="server" Text='<%#Eval("SessionStartDate","{0:d}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="SessionEndDate" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSessionEndDate" runat="server" Text='<%#Eval("SessionEndDate","{0:d}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col s4 m4 l4 offset-s1 offset-m1 offset-l1 card">
            <asp:Button Text="Add Session" ID="btnAddSession"  OnClick="btnAddSession_Click" runat="server" />
        </div>
    </div>

</asp:Content>

