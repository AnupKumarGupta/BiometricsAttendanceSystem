<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="ViewEmployeeLeaves.aspx.cs" Inherits="Admin_ViewEmployeeLeaves" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>--%>
    <script src="../materialize/js/materialize.min.js"></script>
    <link href="../materialize/css/materialize.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />
    <div class="row">
        <br />
        <br />
        <asp:DropDownList ID="ddlShowDepartment" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="dropdown-button col btn 12 m2 s2 offset-l5 offset-m5 offset-s5" OnSelectedIndexChanged="ddlShowDepartment_SelectedIndexChanged">
            <asp:ListItem Value="0">--Select Department--</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="LeaveName" HeaderText="LeaveName" />
                            <asp:BoundField DataField="LeaveCount" HeaderText="LeaveCount" />
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblAction" Text="Edit" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lkbEditLeaveAssinged" Text="Edit" OnClick="lkbEditLeaveAssinged_Click" CommandArgument='<%#Eval("EmployeeId")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="EditLeaveAssinged" runat="server" CssClass="modalPopup" Style="display: none; height: auto;">
        <asp:Button ID="btnforPopupRef" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditLeaveAssigned" runat="server" Enabled="True" TargetControlID="btnforPopupRef"
            CancelControlID="lkbClose" PopupControlID="EditLeaveAssinged" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="card z-depth-3 blue-grey lighten-5 col l6 m6 s6 offset-l3 offset-m3 offset-s3" style="overflow: scroll; height: 350px">
                        <center>
                            <div class="modal-header" >
                                <h5 id="H4" class="modal-title">Edit Leave
                                <asp:LinkButton ID="lkbClose" runat="server" CssClass="btn-close">&nbsp;x</asp:LinkButton></h5>
                            </div>
                            <hr />
                        </center>
                        <div class="col s10 l10 m10 offset-l1 offset-m1 offset-s1">
                            <div class="row">
                                <asp:Repeater ID="EditgvLeaves" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="txtLeave" runat="server" Text='<%# Eval("LeaveName") %>' CssClass="col l4 m4 s4 offset-l2 offset-m2 offset-s2" />
                                        <asp:TextBox ID="txtLeaveCount" runat="server" Text='<%# Eval("LeaveCount")  %>' CssClass="col l4 m4 s4 offset-l2 offset-m2 offset-s2" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="row">
                                <asp:Button ID="btnUpdate" CssClass="btn col l4 m4 s4 offset-l4 offset-m4 offset-s4 " Text="Update Leave" OnClick="btnUpdate_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>

