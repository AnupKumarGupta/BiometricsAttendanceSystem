<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Reports.master" AutoEventWireup="true" CodeFile="DailyBasicAttendanceReport.aspx.cs" Inherits="Reports_DailyBasicAttendanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />

    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
    <title>DailyAttendanceBasicReport</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 breadcrumb">
                    <br />
                    <a href="../Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                    <a href="../Admin/ReportMaster.aspx" class="grey-text">Reports &nbsp;&nbsp;></a>
                    <a href="#!" class="teal-text">&nbsp;&nbsp;Daily Attendance Basic &nbsp;&nbsp;</a>
                </div>
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

                        <%--                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false" SelectedDate="09/09/2015"></asp:Calendar>--%>
                        <asp:TextBox runat="server" ID="txtDate" class="datepicker" />

                        <%--<input type="date" class="datepicker">--%>
                        <script>
                            $('.datepicker').pickadate({
                                selectMonths: true, // Creates a dropdown to control month
                                selectYears: 15 // Creates a dropdown of 15 years to control year
                            });

                        </script>



                    </div>
                </div>
                <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
                    <asp:Button Text="Get Data" ID="btn_report" CssClass="btn waves-button-input" OnClick="btn_report_Click" runat="server" />
                </div>
            </div>
            <div class="row">
                <asp:GridView runat="server" ID="grid_dailyAttendance" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10 offset-l1 offset-m1" EmptyDataText="No Data">
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
                        <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Shift" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblShift" runat="server" Text='<%#Eval("Shift")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label Text="InTime" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblInTime" runat="server" Text='<%#Eval("InTime").ToString()== "12:00 AM" ? "--":(Eval("InTime"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label Text="OutTime" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOutTime" runat="server" Text='<%#Eval("OutTime").ToString()== "12:00 AM" ? "--":(Eval("OutTime"))%>'></asp:Label>
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
                        <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Over Time" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOverTime" runat="server" Text='**'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Total Duration" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalDuration" runat="server" Text='<%#Eval("TotalDuration")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

