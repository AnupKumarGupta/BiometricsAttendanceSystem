<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="LeaveBalanceTable.aspx.cs" Inherits="Reports_LeaveBalanceTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s10 m10 l10 offset-s1 offset-m1 offset-l1 card">
            <asp:DropDownList ID="ddlDepartments"  Visible="true" CssClass="input-field btn grey lighten-4 teal-text" runat="server"></asp:DropDownList>
            <div class="row">
                <div class="col s8 m5 l5">
                    Start Date<br />
                    <asp:Calendar ID="Calendar1" runat="server"  OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </div>
                <div class="col s8 m5 l5 offset-s2 offset-m2 offset-l2">
                    End Date<br />
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                </div>
            </div>
            <div class="row">
                <div class="col s8 m5 l5">
                    <asp:TextBox runat="server" CssClass="input-field text-darken-3" ID="txt_start_date" Enabled="false" />
                </div>
                <div class="col s8 m5 l5 offset-s2 offset-m2 offset-l2">
                    <asp:TextBox runat="server" ID="txt_end_date" Enabled="false" />
                </div>
            </div>
            <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
                <asp:Button ID="btnGetData" Text="Get Data" CssClass="btn waves-button-input" runat="server" OnClick="btnGetData_Click" />
            </div>
            <br />
            <br />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10" EmptyDataText="No Data" Width="100%" OnRowDataBound="grid1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="grid3" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="LeaveName" HeaderText="LeaveName" />
                                <asp:BoundField DataField="LeaveCount" HeaderText="LeaveCount" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="grid4" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="LeaveName" HeaderText="LeaveName" />
                                <asp:BoundField DataField="LeaveCount" HeaderText="LeaveCount" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="grid5" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="LeaveName" HeaderText="LeaveName" />
                                <asp:BoundField DataField="LeaveCount" HeaderText="LeaveCount" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

