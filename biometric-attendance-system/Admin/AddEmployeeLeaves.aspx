<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Admin.master" CodeFile="AddEmployeeLeaves.aspx.cs" Inherits="Admin_AddEmployeeLeaves" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>--%>
    <script src="../materialize/js/materialize.min.js"></script>
    <link href="../materialize/css/materialize.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  
        <asp:DropDownList ID="ddlShowLeaves" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="dropdown-button btn 12 m2 s2" OnSelectedIndexChanged="ddlShowDepartment_SelectedIndexChanged">
        <asp:ListItem Value="0">--Select Department--</asp:ListItem>
    </asp:DropDownList>
    --%>

    <%--  
      <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="LeaveName" HeaderText="LeaveName" />
                            <asp:BoundField DataField="LeaveCount" HeaderText="LeaveCount" />
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    --%>
</asp:Content>

