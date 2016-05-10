<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Reports.master" AutoEventWireup="true" CodeFile="DailyAbsentReport.aspx.cs" Inherits="Reports_DailyAbsentReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />

    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
    <title>DailyAbsentReport</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />

    <div class="row">
        <div class="col s12 breadcrumb">
            <br />
            <a href="../Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
            <a href="../Admin/ReportMaster.aspx" class="grey-text">Reports &nbsp;&nbsp;></a>
            <a href="#!" class="teal-text">&nbsp;&nbsp;Daily Absent Report &nbsp;&nbsp;</a>
        </div>
        <%--<div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
                    <asp:Label ID="lblRelaxationTime" Visible="true" CssClass="input-field btn grey lighten-4 teal-text" runat="server">Relaxation Time</asp:Label>
                </div>--%>
        <div class="col s12 m2 l0 offset-l5 offset-m4">
            <asp:DropDownList ID="ddlRelaxation" Visible="true" CssClass="input-field btn grey col s12 lighten-4 teal-text" runat="server">
                <asp:ListItem Value="00:00:00">Relaxation Time</asp:ListItem>
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
                Date
                        <asp:TextBox runat="server" ID="txtDate" class="datepicker" />
                <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtDate" CssClass="col s12" ForeColor="Red" runat="server" />
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
        <asp:GridView runat="server" ID="grid_dailyAbsent" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m10 l10 offset-l1 offset-m1" EmptyDataText="No Data">
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
                        <asp:Label Text="Department" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentName" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
        <asp:Button Text="Export to PDF" ID="btnExport" CssClass="btn waves-button-input" OnClick="btnExport_Click" Visible="false" runat="server" />
    </div>

</asp:Content>

