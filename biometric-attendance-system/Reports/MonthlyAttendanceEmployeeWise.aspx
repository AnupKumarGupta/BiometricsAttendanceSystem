<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="MonthlyAttendanceEmployeeWise.aspx.cs" Inherits="Reports_MonthlyAttendanceEmployeeWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s10 m10 l10 offset-s1 offset-m1 offset-l1 card">
            <div class="row">
                <asp:TextBox ID="txtEmployeeId" placeholder="Employee Id" CssClass="col input-field offset-l1 offset-m1 offset-s1 l4 m4 s4" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddlRelaxation" runat="server" CssClass=" col input-field btn grey lighten-4 teal-text l4 m4 s4 offset-l1 offset-m1 offset-s1">
                    <asp:ListItem Value="00:05:00">5 minutes</asp:ListItem>
                    <asp:ListItem Value="00:10:00">10 minutes</asp:ListItem>
                    <asp:ListItem Value="00:15:00">15 minutes</asp:ListItem>
                    <asp:ListItem Value="00:20:00">20 minutes</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="row">
                <div class="col s8 m5 l5" style="height: 100px;">
                    Start Date<br />
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
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
                <asp:Button ID="btnGetData" Text="Get Data" CssClass="btn waves-button-input" runat="server" OnClick="btn_report_Click" />
            </div>
            <br />
            <br />
        </div>
        <div class="row">
            <div class="row">
                <div class="col l10 m10 s10 offset-l1 offset-s1 offset-m1 card-content">
                    <asp:Label ID="lblName" CssClass="input-field" runat="server" />
                </div>
            </div>
            <asp:GridView runat="server" ID="grid_monthly_attendanceDetailed" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10 offset-l1 offset-m1" EmptyDataText="No Data">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Date" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Date" runat="server" Text='<%#Eval("Date", "{0:d}")%>'></asp:Label>
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
            <div class="row">
                <div class="col l10 m10 s10 offset-l1 offset-s1 offset-m1 collapsible">
                    <asp:Label ID="lblTotalDuration" runat="server" />
                    <asp:Label ID="lblPresentDays" runat="server" />
                    <asp:Label ID="lblLeaves" runat="server" />
                    <asp:Label ID="lblHolidays" runat="server" />
                    <asp:Label ID="lblAbsentDays" runat="server" />
                    <asp:Label ID="lblWeeklyOff" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

