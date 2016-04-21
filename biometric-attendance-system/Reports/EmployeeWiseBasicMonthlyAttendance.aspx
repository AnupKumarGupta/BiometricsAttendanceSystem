<%@ Page Title="MonthlyAttendanceEmployeeWiseBasic" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="EmployeeWiseBasicMonthlyAttendance.aspx.cs" Inherits="Reports_EmployeeWiseBasicMonthlyAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
   
     <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
    <title>MonthlyAttendanceEmployeeWiseReport</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Literal ID="lit_autocomplete" runat="server" />
    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s10 m10 l10 offset-s1 offset-m1 offset-l1 card">
                    <div class="row">
                        <div class="col s12 breadcrumb">
                            <br />
                            <a href="../Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                            <a href="../Admin/ReportMaster.aspx" class="grey-text">Reports &nbsp;&nbsp;></a>
                            <a href="#!" class="teal-text">&nbsp;&nbsp;Monthly Leave Balance &nbsp;&nbsp;</a>
                        </div>
                        <input id="tags" />
                        <asp:TextBox ID="txtEmployeeId" placeholder="Employee Id" CssClass="col input-field offset-l1 offset-m1 offset-s1 l4 m4 s4" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlRelaxation" runat="server" CssClass=" col input-field btn grey lighten-4 teal-text l4 m4 s4 offset-l1 offset-m1 offset-s1">
                            <asp:ListItem Value="00:00:00">Relaxation Time</asp:ListItem>
                            <asp:ListItem Value="00:05:00">5 minutes</asp:ListItem>
                            <asp:ListItem Value="00:10:00">10 minutes</asp:ListItem>
                            <asp:ListItem Value="00:15:00">15 minutes</asp:ListItem>
                            <asp:ListItem Value="00:20:00">20 minutes</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlName" runat="server" CssClass=" col input-field btn grey lighten-4 teal-text l4 m4 s4 offset-l1 offset-m1 offset-s1">
                        </asp:DropDownList>
                    </div>
                    <div class="row">
                        <div class="col s8 m5 l5" style="height: 100px;">
                            Start Date<br />
                            <asp:TextBox runat="server" ID="txtStartDate" class="datepicker" />
                            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtStartDate" CssClass="col s12" ForeColor ="Red" runat="server" />
                        <%--<input type="date" class="datepicker">--%>
                        <script>
                            $('.datepicker').pickadate({
                                selectMonths: true, // Creates a dropdown to control month
                                selectYears: 15 // Creates a dropdown of 15 years to control year
                            });

                        </script>
                        </div>
                        <div class="col s8 m5 l5 offset-s2 offset-m2 offset-l2">
                            End Date<br />
                           <asp:TextBox runat="server" ID="txtEndDate" class="datepicker" />
                            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtEndDate" CssClass="col s12" ForeColor ="Red" runat="server" />
                        <%--<input type="date" class="datepicker">--%>
                        <script>
                            $('.datepicker').pickadate({
                                selectMonths: true, // Creates a dropdown to control month
                                selectYears: 15 // Creates a dropdown of 15 years to control year
                            });

                        </script>
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
                            <asp:Label ID="lblDepartment" CssClass="input-field" runat="server" />
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
                <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
                    <asp:Button Text="Export to PDF" ID="btnExport" CssClass="btn waves-button-input" OnClick="btnExport_Click" Visible="false" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


