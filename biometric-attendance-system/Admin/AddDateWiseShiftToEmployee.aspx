<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDateWiseShiftToEmployee.aspx.cs" MasterPageFile="~/MasterPages/Admin.master" Inherits="Admin_AddDateWiseShiftToEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />

    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s12 breadcrumb">
            <br />
            <a href="ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
            <a href="#!" class="teal-text">&nbsp;&nbsp;Add Date Wise Shift &nbsp;&nbsp;</a>
        </div>
    </div>
    <div class="row">
        <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
            <asp:TextBox runat="server" ID="txtEmployeeId" placeholder="Employee Id" ToolTip="Employee Id" ValidationGroup="shift"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtEmployeeId" CssClass="input-field btn grey lighten-4 teal-text " runat="server" ValidationGroup="shift" />
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
    </div>
    <div class="row">
        <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l4">
            Shift:<br />
            <asp:DropDownList ID="ddlShift" runat="server" AppendDataBoundItems="True" CausesValidation="true" CssClass="dropdown-button btn l2 m2 s2" ValidationGroup="shift">
                <asp:ListItem Text="Select Shift" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvDdlRole" ErrorMessage="Required" ControlToValidate="ddlShift" InitialValue="Select Shift" runat="server" ValidationGroup="shift"  ForeColor="Red" SetFocusOnError="True" />
        </div>
    </div>
    <div class="row">
        <div class="col s8 m4 l4 offset-s2 offset-m5 offset-l5">
            <asp:Button Text="Add Shift" ID="btnAddSession" runat="server" CssClass="btn" OnClick="btnAddSession_Click" ValidationGroup="shift" />
        </div>
    </div>


</asp:Content>
