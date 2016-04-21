<%@ Page Title="Monthly Leave Balance" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="LeaveBalanceTable.aspx.cs" Inherits="Reports_LeaveBalanceTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
    <title>MonthlyLateComersReport</title>

    <%--    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
   <link rel="stylesheet" href="/resources/demos/style.css"/>
     <script>
           $(function() {
                   var availableTags = [
                     "ActionScript",
                     "AppleScript",
                     "Asp",
                     "BASIC",
                     "C",
                     "C++",
                     "Clojure",
                     "COBOL",
                     "ColdFusion",
                     "Erlang",
                     "Fortran",
                     "Groovy",
                     "Haskell",
                     "Java",
                     "JavaScript",
                     "Lisp",
                     "Perl",
                     "PHP",
                     "Python",
                     "Ruby",
                     "Scala",
                     "Scheme"
                   ];
                   $( "#tags" ).autocomplete({
                         source: availableTags
                       });
             });
           6  </script>--%>
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
                    <a href="#!" class="teal-text">&nbsp;&nbsp;Monthly Leave Balance &nbsp;&nbsp;</a>
                </div>
                <div class="col s10 m10 l10 offset-s1 offset-m1 offset-l1 card">
                    <asp:DropDownList ID="ddlDepartments" Visible="true" CssClass=" col input-field btn grey lighten-4 teal-text l4 m4 s4 offset-l4 offset-m4 offset-s4" runat="server"></asp:DropDownList>
                    <div class="row">
                        <div class="col s8 m5 l5" style="height: 100px;">
                            Start Date<br />
                            <asp:TextBox runat="server" ID="txtStartDate" class="datepicker" />

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
                        <asp:Button ID="btnGetData" Text="Get Data" CssClass="btn waves-button-input" runat="server" OnClick="btnGetData_Click" />
                    </div>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" GridLines="Both" CssClass="col m10 l10 offset-l1 offset-m1 table-of-contents" EmptyDataText="No Data" OnRowDataBound="grid1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:TemplateField HeaderText="Old Stock">
                            <ItemTemplate>
                                <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                        <asp:BoundField DataField="EL" HeaderText="EL" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Leaves Due">
                            <ItemTemplate>
                                <asp:GridView ID="grid3" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Casual Leave" HeaderText="CL" />
                                        <asp:BoundField DataField="Earned Leave" HeaderText="EL" />
                                        <asp:BoundField DataField="Short Leave" HeaderText="SHL" />
                                        <asp:BoundField DataField="Half Day Leave" HeaderText="HDL" />
                                        <asp:BoundField DataField="Sick Leave" HeaderText="SL" />
                                        <asp:BoundField DataField="Restricted Holiday" HeaderText="RH" />
                                        <asp:BoundField DataField="D Leave" HeaderText="DL" />
                                        <asp:BoundField DataField="Compensatory Off" HeaderText="CO" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Leaves Availed">
                            <ItemTemplate>
                                <asp:GridView ID="grid4" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Casual Leave" HeaderText="CL" />
                                        <asp:BoundField DataField="Earned Leave" HeaderText="EL" />
                                        <asp:BoundField DataField="Short Leave" HeaderText="SHL" />
                                        <asp:BoundField DataField="Half Day Leave" HeaderText="HDL" />
                                        <asp:BoundField DataField="Sick Leave" HeaderText="SL" />
                                        <asp:BoundField DataField="Restricted Holiday" HeaderText="RH" />
                                        <asp:BoundField DataField="D Leave" HeaderText="DL" />
                                        <asp:BoundField DataField="Compensatory Off" HeaderText="CO" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Leaves Balance">
                            <ItemTemplate>
                                <asp:GridView ID="grid5" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Casual Leave" HeaderText="CL" />
                                        <asp:BoundField DataField="Earned Leave" HeaderText="EL" />
                                        <asp:BoundField DataField="Short Leave" HeaderText="SHL" />
                                        <asp:BoundField DataField="Half Day Leave" HeaderText="HDL" />
                                        <asp:BoundField DataField="Sick Leave" HeaderText="SL" />
                                        <asp:BoundField DataField="Restricted Holiday" HeaderText="RH" />
                                        <asp:BoundField DataField="D Leave" HeaderText="DL" />
                                        <asp:BoundField DataField="Compensatory Off" HeaderText="CO" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <%-- <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
    <asp:Button Text="Export to PDF" ID="btnExport" CssClass="btn waves-button-input" OnClick="btnExport_Click" runat="server" />
                </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

