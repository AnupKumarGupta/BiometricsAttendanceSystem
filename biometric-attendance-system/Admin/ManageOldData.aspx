<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="ManageOldData.aspx.cs" Inherits="Admin_ManageOldData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManagerDepartment" runat="server" />
    <div class="row">
        <div class="col s12 breadcrumb">
            <br />
            <a href="../Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
            <a href="#!" class="teal-text">&nbsp;&nbsp;Manage Old Data &nbsp;&nbsp;</a>
        </div>
        <br />
        <div class="col s8 m3 l2 offset-s2 offset-m5 offset-l5">
            <label for="ddlDate">Session</label>
            <asp:DropDownList ID="ddlDate" runat="server" CssClass="input-field col s12 btn grey lighten-3 teal-text">
                <asp:ListItem Text="2015-2016" Value="0" />
                <asp:ListItem Text="2016-2017" Value="1" />
            </asp:DropDownList>
        </div>
    </div>
    <asp:GridView ID="grd_Employees" AutoGenerateColumns="false" CssClass="responsive-table striped" runat="server" EmptyDataText="No Data">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblemployeeId" Text="Employee Id" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblemployeeId" runat="server" Text='<%#Eval("employeeId")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblemployeeName" Text="employeeName" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblemployeeName" runat="server" Text='<%#Eval("employeeName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblslCount" Text="SL Count" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblslCount" runat="server" Text='<%#Eval("slCount")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblelCount" Text="EL Count" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblelCount" runat="server" Text='<%#Eval("elCount")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblsessionStartDate" Text="Session Start Date" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblsessionStartDate" runat="server" Text='<%#Eval("sessionStartDate")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblsessionEndDate" Text="Session End Date" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblsessionEndDate" runat="server" Text='<%#Eval("sessionEndDate")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lkbEditData" Text="Edit" OnClick="lkbEditData_Click" CommandArgument='<%#Eval("employeeId") + ";" + Eval("employeeName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel ID="EditData" runat="server" DefaultButton="lkbClose" CssClass="modalPopup active card" Style="display: none; width: 61% !important; height: auto;">
        <asp:Button ID="btnforPopupRef" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="popupEditData" runat="server" Enabled="True" TargetControlID="btnforPopupRef"
            CancelControlID="lkbClose" PopupControlID="EditData" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <div class="modal-header">
            <h3 id="H1" class="modal-title">Edit Data
               
                <asp:LinkButton ID="lkbClose" runat="server" CssClass="left0 btn-close"><b class="glyphicon glyphicon-remove-sign"></b>&nbsp;x</asp:LinkButton></h3>
        </div>
        <div style="min-height: 120px; width: 100%">
            <div class="col s2 l2 m2 offset-l4 offset-m4 offset-s4">
                Employee Name
               
                <asp:Label ID="lblName" runat="server" />
                <asp:TextBox runat="server" ID="txtEditSL" placeholder="SL"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtEditEL" placeholder="EL"></asp:TextBox>
                <asp:Button ID="btnUpdate" Text="Update Data" OnClick="btnUpdate_Click" runat="server" />
            </div>
        </div>
        <div class="modal-footer"></div>
    </asp:Panel>
</asp:Content>

