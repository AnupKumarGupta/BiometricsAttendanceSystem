<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="Admin_AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css" />
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="row">
        <div class="col s12">
            <div class="col s12 breadcrumb">
                <br />
                <a href="./ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                <a href="#!" class="teal-text">&nbsp;&nbsp;Add Employees &nbsp;&nbsp;</a>
            </div>
        </div>
        <br />
        <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
            <label for="txtName">Employee Id</label>
            <asp:TextBox runat="server" ID="txtEmployeeId" placeholder="Id" ToolTip="Id"></asp:TextBox>
            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtEmployeeId" CssClass="input-field btn grey lighten-4 teal-text " runat="server" />
        </div>
        <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
            <label for="txtName">Employee Name</label>
            <asp:TextBox runat="server" ID="txtName" placeholder="Name" ToolTip="Name"></asp:TextBox>
            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtName" CssClass="input-field btn grey lighten-4 teal-text " runat="server" />
        </div>
        <div class="row">
            <div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
                <label for="txtDateOfJoining" class="text-black text-darken-4">Date Of Joining</label>
                <asp:TextBox runat="server" ID="txtDateOfJoining" placeholder="Date of Joining" class="datepicker"></asp:TextBox>
                <script>
                    $('.datepicker').pickadate({
                        selectMonths: true, // Creates a dropdown to control month
                        selectYears: 15 // Creates a dropdown of 15 years to control year
                    });

                </script>
                <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtDateOfJoining" CssClass="input-field btn grey lighten-4 teal-text" runat="server" />
            </div>
            <div class="col s8 m3 l2 offset-s2">
                <label class="text-darken-4">Weekly Off Day</label>
                <asp:DropDownList ID="ddlDays" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text">
                    <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Sunday" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <div class="row">
            <div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
                <label for="ddlDepartments">Department</label>
                <asp:DropDownList ID="ddlDepartments" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text">
                </asp:DropDownList>
            </div>
            <div class="col s8 m3 l2 offset-s2">
                <label for="ddlRoles">Role</label>
                <asp:DropDownList ID="ddlRoles" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
                <label for="txtContactNumber">Contact Number</label>
                <asp:TextBox runat="server" ID="txtContactNumber" placeholder="Contact Number">
                </asp:TextBox>
                <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage=" Required" ControlToValidate="txtContactNumber" CssClass="input-field btn grey lighten-4 teal-text" runat="server" />

            </div>
            <div class="col s8 m3 l2 offset-s2">
                <label for="ddlShifts">Shift</label>
                <asp:DropDownList ID="ddlShifts" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text">
                </asp:DropDownList>
            </div>
        </div>

        <br />
        <center></center>
        <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
            <asp:RadioButton ID="rdrbtnFemale" GroupName="Gender" Text="Female" CssClass="with-gap" Checked="true" runat="server" />
            &nbsp;
                    <asp:RadioButton ID="rdrbtnMale" GroupName="Gender" Text="Male" CssClass="with-gap" runat="server" />
        </div>
        </center>
        <br />
        <br />
        <br />
        <br />
        <center>
                 <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
                        <asp:LinkButton ID="lnkUpdateEmployee" runat="server" CssClass="btn waves-teal" OnClick="btnSUbmit_Click">
                                Add Employee
                        </asp:LinkButton>
                 </div>
        </center>
    </div>
</asp:Content>

