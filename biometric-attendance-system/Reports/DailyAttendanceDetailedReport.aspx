<%@ Page Title="Attendance Detail" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="DailyAttendanceDetailedReport.aspx.cs" Inherits="Reports_DailyAttendanceDetailedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
            <asp:DropDownList ID="ddlDepartments" Visible="true" CssClass="input-field btn grey lighten-4 teal-text" runat="server"></asp:DropDownList>
        </div>
        <div class="col s8 m3 l2 offset-s2">
            <asp:DropDownList ID="ddlRelaxation" Visible="true" CssClass="input-field btn grey lighten-4 teal-text" runat="server">
                <asp:ListItem Value="00:05:00">5 minutes</asp:ListItem>
                <asp:ListItem Value="00:10:00">10 minutes</asp:ListItem>
                <asp:ListItem Value="00:15:00">15 minutes</asp:ListItem>
                <asp:ListItem Value="00:20:00">20 minutes</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="row">
            <div class="col s8 m4 l4 offset-l4 offset-m4">
                <br />
                <br />
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <asp:TextBox runat="server" ID="txt_date" />
            </div>
        </div>
        <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
            <asp:Button Text="Get Data" ID="btn_report" CssClass="btn waves-button-input" OnClick="btn_report_Click" runat="server" />
        </div>
    </div>
    <div class="row">
        <asp:GridView runat="server" ID="grid_daily_attendanceDetailed" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10 offset-l1 offset-m1" EmptyDataText="No Data">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Employee Id" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EmployeeId")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Name" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Shift In" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShiftIn" runat="server" Text='<%#Eval("FirstHalfStartTime")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Shift Out" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShiftOut" runat="server" Text='<%#Eval("SecondHalfEndTime")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="A. InTime" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInTime" runat="server" Text='<%#Eval("InTime")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="A. OutTime" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOutTime" runat="server" Text='<%#Eval("OutTime")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Work Duration" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblWorkDuration" runat="server" Text='<%#Eval("TotalDuration")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Late By" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLateBy" runat="server" Text='<%#Eval("LateByDuration")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Early Going By" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEarlyGoingBy" runat="server" Text='<%#Eval("EarlyGoingByDuration")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Status" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Remarks" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPunchRecords" runat="server" Text='<%#Eval("PunchRecords")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
     <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
    <asp:Button Text="Export to PDF" ID="btnExport" CssClass="btn waves-button-input" OnClick="btnExport_Click" Visible="false" runat="server" />
                </div>
</asp:Content>

