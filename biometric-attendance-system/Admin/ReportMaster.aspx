<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Admin.master" AutoEventWireup="true" CodeFile="ReportMaster.aspx.cs" Inherits="Admin_ReportMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s12">
            <div class="col s12 breadcrumb">
                <br />
                <a href="./ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                <a href="#!" class="teal-text">&nbsp;&nbsp;Reports &nbsp;&nbsp;</a>
            </div>
        </div>
        <div class="col card l8 m8 s8 offset-l2 offset-m2 center">
            <asp:LinkButton Text="Daily Attendance Basic Report" ID="DailyAttendanceBasicReport" href="../Reports/DailyAttendanceBasicReport.aspx" target="_blank" CssClass="btn" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Daily Attendance Detailed Report" ID="DailyAttendanceDetailedReport" href="../Reports/DailyAttendanceDetailedReport.aspx" target="_blank" CssClass="btn" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Monthly Attendance EmployeeWise Basic" ID="MonthlyAttendanceEmployeeWiseBasic" href="../Reports/MonthlyAttendanceEmployeeWiseBasic.aspx" target="_blank" CssClass="btn" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Monthly Attendance EmployeeWise Detailed" ID="MonthlyAttendanceEmployeeWise" href="../Reports/MonthlyAttendanceEmployeeWise.aspx" target="_blank" CssClass="btn" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Daily Late Comers" ID="DailyLateComers" CssClass="btn" href="../Reports/DailyLateComers.aspx" target="_blank" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Monthly Late Comers" ID="MonthlyLateComers" CssClass="btn" href="../Reports/MonthlyLateComers.aspx" target="_blank" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Daily Present Report" ID="DailyPresentReport" CssClass="btn" href="../Reports/DailyPresentReport.aspx" target="_blank" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Daily Absent Report" ID="DailyAbsentReport" CssClass="btn" href="../Reports/DailyAbsentReport.aspx" target="_blank" runat="server" />
            <br />
            <br />
            <asp:LinkButton Text="Monthly Status Report" ID="LeaveBalanceTable" CssClass="btn" href="../Reports/LeaveBalanceTable.aspx" target="_blank" runat="server" />
        </div>
</asp:Content>

