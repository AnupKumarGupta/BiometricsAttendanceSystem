<%@ Page Title="MonthlyAttendanceEmployeeWiseBasic" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="MonthlyAttendanceEmployeeWiseBasic.aspx.cs" Inherits="Reports_MonthlyAttendanceEmployeeWiseBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s12 m10 l10 offset-m1 offset-l1 card">
            <div class="row">
                <div class="col s12 breadcrumb">
                    <br />
                    <a href="../Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                    <a href="../Admin/ReportMaster.aspx" class="grey-text">Reports &nbsp;&nbsp;></a>
                    <a href="#!" class="teal-text">&nbsp;&nbsp;Monthly Leave Balance &nbsp;&nbsp;</a>
                </div>
                <asp:TextBox ID="txtEmployeeId" placeholder="Employee Id" CssClass="col input-field offset-l1 offset-m1 l4 m4 s12" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddlRelaxation" runat="server" CssClass=" col input-field btn grey lighten-4 teal-text l4 m4 s12 offset-l1 offset-m1">
                    <asp:ListItem Value="00:05:00">5 minutes</asp:ListItem>
                    <asp:ListItem Value="00:10:00">10 minutes</asp:ListItem>
                    <asp:ListItem Value="00:15:00">15 minutes</asp:ListItem>
                    <asp:ListItem Value="00:20:00">20 minutes</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col s12 m5 l5" style="/*height: 100px; */">
                            Start Date<br />
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                        </div>
                        <div class="col s12 m5 l5 offset-m2 offset-l2">
                            End Date<br />
                            <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m5 l5">
                            <asp:TextBox runat="server" CssClass="input-field text-darken-3" ID="txt_start_date" Enabled="false" />
                        </div>
                        <div class="col s12 m5 l5 offset-m2 offset-l2">
                            <asp:TextBox runat="server" ID="txt_end_date" Enabled="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col s12 m4 l4 offset-m5 offset-l5">
                <asp:Button ID="btnGetData" Text="Get Data" CssClass="btn waves-button-input" runat="server" OnClick="btn_report_Click" />
            </div>

            <br />
            <br />
        </div>

        <div class="row">
            <div class="row">
                <div class="col l10 m10 s12 offset-l1 offset-m1 card-content">
                    <asp:Label ID="lblName" CssClass="input-field" runat="server" />
                </div>
            </div>
            <asp:GridView runat="server" ID="grid_monthly_attendanceBasic" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10 offset-l1 offset-m1" EmptyDataText="No Data">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Date" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Date" runat="server" Text='<%#Eval("Date","{0:d}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="InTime" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblInTime" runat="server" Text='<%#Eval("InTime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="OutTime" runat="server" />
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
            <div class="row">
                <div class="col l10 m10 s12 offset-l1 offset-m1 collapsible">
                    <asp:Label ID="lblTotalDuration" runat="server" />
                    <asp:Label ID="lblPresentDays" runat="server" />
                    <asp:Label ID="lblLeaves" runat="server" />
                    <asp:Label ID="lblHolidays" runat="server" />
                    <asp:Label ID="lblAbsentDays" runat="server" />
                    <asp:Label ID="lblWeeklyOff" runat="server" />
                </div>
            </div>
        </div>
        <div class="col s12 m4 l4 offset-m5 offset-l5">
            <asp:Button Text="Export to PDF" ID="btnExport" CssClass="btn waves-button-input" OnClick="btnExport_Click" Visible="false" runat="server" />
        </div>
    </div>
</asp:Content>

