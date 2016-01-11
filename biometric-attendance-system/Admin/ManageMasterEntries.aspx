<%@ Page Title="Manage Master Entries" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="ManageMasterEntries.aspx.cs" Inherits="ManageMasterEntries" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>--%>
    <script src="../materialize/js/materialize.min.js"></script>
    <link href="../materialize/css/materialize.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="btnDepartments" runat="server" Text="Departments" CssClass="waves-effect waves-ripple btn-large" OnClick="btnDepartments_Click" />
    <asp:Button ID="btnLeaves" runat="server" Text="Leaves" CssClass="waves-effect waves-ripple btn-large" OnClick="btnLeaves_Click" />
    <asp:Button ID="btnRoles" runat="server" Text="Roles" CssClass="waves-effect waves-ripple btn-large" OnClick="btnRoles_Click" />
    <asp:Button ID="btnLeaveAssignedByRole" runat="server" Text="Leave Assigned By Role" CssClass="waves-effect waves-ripple btn-large" OnClick="btnLeaveAssignedByRole_Click" />
    <asp:Button ID="btnEmployee" runat="server" Text="Employee" CssClass="waves-effect waves-ripple btn-large" OnClick="btnEmployee_Click" />
    <asp:Button ID="btnLeaveForEmployee" runat="server" Text="Leave Assigned To Employees" CssClass="waves-effect waves-ripple btn-large" OnClick="btnLeaveForEmployee_Click" />
    <asp:Button ID="btnDuration" runat="server" Text="Duration" CssClass="waves-effect waves-ripple btn-large" OnClick="btnDuration_Click" />
    <asp:Button ID="btnShifts" runat="server" Text="Shifts" CssClass="waves-effect waves-ripple btn-large" OnClick="btnShifts_Click" />
    <asp:Button ID="btnReports" runat="server" Text="Reports" CssClass="waves-effect waves-ripple btn-large" OnClick="btnReports_Click" />

    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />

    <asp:Panel ID="pnlDepartment" runat="server" Visible="true">
        <div>
            <asp:UpdatePanel ID="upnlDepartment" runat="server">
                <ContentTemplate>
                    <br />
                    <div class="row">
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtDepartment" placeholder="Department"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2">
                            <asp:LinkButton ID="lnkAddDepartment" CssClass="btn waves-effect waves-light" runat="server" OnClick="lnkAddDepartment_Click">
                                 <i class="material-icons">add </i> Add Department
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4" style="overflow: scroll; height: 400px">
                            <asp:GridView ID="grdDepartment" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Departments" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbEditDepartment" Text="Edit" OnClick="lkbEditDepartment_Click" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Panel ID="EditDepartment" runat="server" DefaultButton="lkbClose" CssClass="modalPopup" Style="display: none; width: 61% !important; height: auto;">
        <asp:Button ID="btnforPopupRef" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditDepartment" runat="server" Enabled="True" TargetControlID="btnforPopupRef"
            CancelControlID="lkbClose" PopupControlID="EditDepartment" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H1" class="modal-title">Edit Department
                <asp:LinkButton ID="lkbClose" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                <asp:TextBox runat="server" ID="txtEditDepartment" placeholder="Department"></asp:TextBox>
                <asp:Button ID="btnUpdateDepartment" Text="Update Department" OnClick="btnUpdateDepartment_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>

    </asp:Panel>


    <asp:Panel ID="pnlLeave" runat="server" Visible="true">
        <div>
            <asp:UpdatePanel ID="upnlLeave" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtLeave" placeholder="Leave"></asp:TextBox>
                        </div>
                        <%-- <div class="col s2 l2 m2">
                            <asp:DropDownList ID="ddlMaterLeaveType" runat="server" Visible="true" CssClass="dropdown-button btn l2 m2 s2">
                                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                                <asp:ListItem Value="1">Full Day Leave</asp:ListItem>
                                <asp:ListItem Value="2">Half Day Leave</asp:ListItem>
                                <asp:ListItem Value="3">Short Leave</asp:ListItem>
                                <asp:ListItem Value="4">Bulk Leave</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:LinkButton ID="lnkAddLeave" CssClass="btn waves-effect waves-light col s12 l12 m12" runat="server" OnClick="lnkAddLeave_Click">
                                 <i class="material-icons">add </i> Add Leave
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:GridView ID="grdLeave" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Leaves" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeave" runat="server" Text='<%#Eval("LeaveName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Type of Leaves" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTypeOfLeaves" runat="server" Text='<%#Eval("MasterLeaveType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbEditLeave" Text="Edit" OnClick="lkbEditLeave_Click" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Panel ID="EditLeave" runat="server" DefaultButton="lkbClose1" CssClass="modalPopup" Style="display: none; width: 61% !important; height: auto;">
        <asp:Button ID="btnforPopupRef1" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditLeave" runat="server" Enabled="True" TargetControlID="btnforPopupRef1"
            CancelControlID="lkbClose1" PopupControlID="EditLeave" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H2" class="modal-title">Edit Leave
                <asp:LinkButton ID="lkbClose1" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                <asp:TextBox runat="server" ID="txtEditLeave" placeholder="Leave"></asp:TextBox>

                <asp:Button ID="btnUpdateLeave" Text="Update Leave" OnClick="btnUpdateLeave_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>

    </asp:Panel>

    <asp:Panel ID="pnlLeaveAssignedByRole" runat="server" Visible="true">
        <div>
            <asp:UpdatePanel ID="upnlLeaveAssignedByRole" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col s2 l2 m2">
                            Role:
                            <asp:DropDownList ID="ddlRole" runat="server" AppendDataBoundItems="True" CssClass="dropdown-button btn l2 m2 s2">
                                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col s2 l2 m2">
                            Leave:<asp:DropDownList ID="ddlLeave" runat="server" AppendDataBoundItems="True" CssClass="dropdown-button btn l2 m2 s2">
                                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtNoOfLeaves" placeholder="No. of Leaves"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtLimit" placeholder="Limit"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2">
                            <asp:DropDownList ID="ddlIsPromoted" runat="server" Visible="true" CssClass="dropdown-button btn l2 m2 s2">
                                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                                <asp:ListItem Value="1">True</asp:ListItem>
                                <asp:ListItem Value="2">False</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:LinkButton ID="lnkAddLeaveAsssignedByRole" CssClass="btn waves-effect waves-light col s12 l12 m12" runat="server" OnClick="lnkAddLeaveAsssignedByRole_Click">
                                 <i class="material-icons"> </i> Add Leave For Role
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:GridView ID="gvViewLeaveAssignedByRole" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRole" Text="Role" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblLeave" Text="Leave" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeave" runat="server" Text='<%#Eval("LeaveName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblNoOfLeaves" Text="No Of Leaves" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoOfLeaves" runat="server" Text='<%#Eval("NoOfLeaves")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblLimit" Text="Limit" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLimit" runat="server" Text='<%#Eval("Limit")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblIsPromoted" Text="Is Promoted" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsPromoted" runat="server" Text='<%#Eval("IsPromoted")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbEditLeaveAssingedByRole" Text="Edit" OnClick="lkbEditLeaveAssingedByRole_Click" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Panel ID="EditLeaveAssingedByRole" runat="server" DefaultButton="lkbClose3" CssClass="modalPopup" Style="display: none; height: auto;">
        <asp:Button ID="btnforPopupRef4" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditLeaveAssignedByRole" runat="server" Enabled="True" TargetControlID="btnforPopupRef4"
            CancelControlID="lkbClose3" PopupControlID="EditLeaveAssingedByRole" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H4" class="modal-title">Edit Leave
                <asp:LinkButton ID="lkbClose3" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                <asp:TextBox runat="server" ID="TextBox1" placeholder="Leave"></asp:TextBox>
                Role:
                            <asp:DropDownList ID="ddlRole1" runat="server" AppendDataBoundItems="True" CssClass="dropdown-button btn l2 m2 s2">
                                <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                            </asp:DropDownList>
                Leave:<asp:DropDownList ID="ddlLeaveEdit" runat="server" AppendDataBoundItems="True" CssClass="dropdown-button btn l2 m2 s2">
                    <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox runat="server" ID="txtNoOfLeave" placeholder="No. of Leaves"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtLimitEdit" placeholder="Limit"></asp:TextBox>
                <asp:DropDownList ID="ddlIsPromotedEdit" runat="server" Visible="true" CssClass="dropdown-button btn l2 m2 s2">
                    <asp:ListItem Value="0">--- Select ----</asp:ListItem>
                    <asp:ListItem Value="1">True</asp:ListItem>
                    <asp:ListItem Value="2">False</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnUpdate" Text="Update Leave" OnClick="btnUpdate_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>

    </asp:Panel>

    <asp:Panel ID="pnlRole" runat="server" Visible="false">
        <div>
            <asp:UpdatePanel ID="upanelRole" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtRole" placeholder="Roles"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2">
                            <asp:LinkButton ID="lnkAddRole" CssClass="btn waves-effect waves-light" runat="server" OnClick="lnkAddRole_Click">
                                 <i class="material-icons">add </i> Add Role
                            </asp:LinkButton>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:GridView ID="grdRole" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Roles" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoles" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbEditRole" Text="Edit" OnClick="lkbEditRole_Click" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Panel ID="EditRole" runat="server" DefaultButton="lkbClose2" CssClass="modalPopup" Style="display: none; width: 61% !important; height: auto;">
        <asp:Button ID="btnforPopupRef2" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditRole" runat="server" Enabled="True" TargetControlID="btnforPopupRef2"
            CancelControlID="lkbClose2" PopupControlID="EditRole" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H3" class="modal-title">Edit Role
                <asp:LinkButton ID="lkbClose2" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                <asp:TextBox runat="server" ID="txtEditRole" placeholder="Role"></asp:TextBox>
                <asp:Button ID="btnUpdateRole" Text="Update Role" OnClick="btnUpdateRole_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>

    </asp:Panel>


    <asp:Panel ID="pnlDuration" runat="server" Visible="false">
        <div>
            <asp:UpdatePanel ID="upnlDuration" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <asp:DropDownList ID="ddlSuggestions" runat="server" CssClass="dropdown-button btn l2 m2 s2">
                            <asp:ListItem Value="00:45:00">45 minutes</asp:ListItem>
                            <asp:ListItem Value="01:00:00">1 hour</asp:ListItem>
                            <asp:ListItem Value="01:15:00">1 hour 15 minutes</asp:ListItem>
                            <asp:ListItem Value="01:30:00">1 hour 30 minutes</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlLeaves" runat="server" CssClass="dropdown-button btn l2 m2 s2">
                            <asp:ListItem Value="0">--Select Leave--</asp:ListItem>
                            <asp:ListItem Value="3">Short Leave</asp:ListItem>
                            <asp:ListItem Value="4">Half Day Leave</asp:ListItem>
                        </asp:DropDownList>
                        <div class="col s2 l2 m2">
                            <asp:LinkButton ID="lnkAddDuration" CssClass="btn waves-effect waves-light" runat="server" OnClick="lnkAddDuration_Click">
                                 <i class="material-icons">add </i> Add Role
                            </asp:LinkButton>
                        </div>
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:GridView ID="gvDuration" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Leave Name" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstHalfStartTiming" runat="server" Text='<%#Eval("leaveName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Duration" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstHalfStartTiming" runat="server" Text='<%#Eval("duration")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbEditDuration" Text="Edit" OnClick="lkbEditDuration_Click" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlEditDuration" runat="server" DefaultButton="lkbClose6" CssClass="modalPopup" Style="display: none; width: 61% !important; height: auto;">
        <asp:Button ID="btnforPopupRef6" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditDuration" runat="server" Enabled="True" TargetControlID="btnforPopupRef6"
            CancelControlID="lkbClose6" PopupControlID="EditRole" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H5" class="modal-title">Edit Role
                <asp:LinkButton ID="lkbClose6" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                <asp:TextBox runat="server" ID="txtEditDuration" placeholder="Role"></asp:TextBox>
                <asp:Button ID="btnEditDuration" Text="Update Duration" OnClick="btnEditDuration_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>

    </asp:Panel>

    <asp:Panel ID="pnlShifts" runat="server" Visible="false">
        <div>
            <asp:UpdatePanel ID="upanelShifts" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtFirstHalfStart" placeholder="First Half Start Timing"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2">
                            <asp:TextBox runat="server" ID="txtFirstHalfEnd" placeholder="First Half End Timing"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                            <asp:TextBox runat="server" ID="txtSecondHalfStart" placeholder="Second Half Start Timing"></asp:TextBox>
                        </div>
                        <div class="col s2 l2 m2">
                            <asp:TextBox runat="server" ID="txtSecondHalfEnd" placeholder="Second Half End Timing"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:LinkButton ID="lnkbtnShifts" CssClass="btn waves-effect waves-light col s12 l12 m12" runat="server" OnClick="lnkbtnShifts_Click">
                                 <i class="material-icons">add </i> Add Shift
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 l4 m4 offset-l4 offset-m4 offset-s4">
                            <asp:GridView ID="gvShifts" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="First Half Start Timing" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstHalfStartTiming" runat="server" Text='<%#Eval("FirstHalfStart")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="First Half End Timing" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstHalfEndTiming" runat="server" Text='<%#Eval("FirstHalfEnd")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Second Half Start Timing" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSecondHalfStartTiming" runat="server" Text='<%#Eval("SecondHalfStart")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="First Half End Timing" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSecondHalfEndTiming" runat="server" Text='<%#Eval("SecondHalfEnd")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
</asp:Content>

