<%@ Page Title="EditEmployee" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="EditEmployee.aspx.cs" Inherits="Admin_EditEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s12">
            <div class="col s12 breadcrumb">
                <br />
                <a href="./ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                <a href="./ViewEmployee.aspx" class="grey-text">Employees Details &nbsp;&nbsp;></a>
                <a href="#!" class="teal-text">&nbsp;&nbsp;Edit Employees &nbsp;&nbsp;</a>
            </div>
        </div>
        <br />
        <div class="col s8 m6 l4 offset-s2 offset-m4 offset-l4">
            <label for="txtName">Employee Name</label>
            <asp:TextBox runat="server" ID="txtName" placeholder="Name" Enabled="false" ToolTip="Name"></asp:TextBox>
            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="&nbsp;Required" ControlToValidate="txtName" CssClass="input-field btn grey lighten-4 teal-text " runat="server" />
        </div>
        <div class="row">
            <div class="col s8 m3 l2 offset-s2 offset-m4 offset-l4">
                 <label for="txtDateOfJoining" class="text-black text-darken-4">Date Of Joining</label>
                <asp:TextBox runat="server" ID="txtDateOfJoining" placeholder="Date of Joining"></asp:TextBox>
            </div>
            <div class="col s8 m3 l2 offset-s2">
                <label for="ddlDays">Weekly Off Day</label>
                <asp:DropDownList ID="ddlDays" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text">
                    <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Sunday" Value="7"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage="Required" ControlToValidate="txtDateOfJoining" CssClass="input-field btn grey lighten-4 teal-text" runat="server" />
            <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ControlToValidate="txtDateOfJoining" ErrorMessage=" DD/MM/YYYY Format" CssClass="input-field btn grey lighten-4 teal-text" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
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
                <%--                <asp:RequiredFieldValidator SetFocusOnError="true" ErrorMessage=" Required" ControlToValidate="txtContactNumber" CssClass="input-field btn grey lighten-4 teal-text" runat="server" />--%>
                <%--                <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ControlToValidate="txtContactNumber" ErrorMessage=" Invalid Mobile Number" CssClass="input-field btn grey lighten-4 teal-text" ValidationExpression="^([0-9]*){10}$"></asp:RegularExpressionValidator>--%>
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
                        <asp:LinkButton ID="lnkUpdateEmployee" runat="server" CssClass="btn waves-teal" OnClick="lnkUpdateEmployee_Click">
                                Update Employee
                        </asp:LinkButton>
                 </div>
        </center>
    </div>
</asp:Content>

