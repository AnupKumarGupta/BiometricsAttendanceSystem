<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDateWiseShiftToEmployee.aspx.cs" MasterPageFile="~/MasterPages/Admin.master" Inherits="Admin_AddDateWiseShiftToEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <div class="col s8 m5 l5" style="height: 50px;">
            Date<br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <div class="col s4 l4 m4 offset-l2 offset-m2">
            Shift:<br />
            <asp:DropDownList ID="ddlShift" runat="server" AppendDataBoundItems="True" CausesValidation="true" CssClass="dropdown-button btn l2 m2 s2" ValidationGroup="shift">
                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvDdlRole" ErrorMessage="Required" ControlToValidate="ddlShift" runat="server" ValidationGroup="shift" InitialValue="0" ForeColor="Red" SetFocusOnError="True" />
        </div>
        <div class="col s4 m4 l4 offset-s1 offset-m1 offset-l1 card">
            <asp:Button Text="Add Shift" ID="btnAddSession"  runat="server" ValidationGroup="shift" />
        </div>
    </div>

</asp:Content>
