<%@ Page Title="View Employee" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="ViewEmployee.aspx.cs" Inherits="Admin_ViewEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="row" style="overflow-y:scroll">
        <div class="col s12">
            <div class="col s12 breadcrumb">
                <br />
                <a href="./ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                <a href="#!" class="teal-text">&nbsp;&nbsp;Employees Details &nbsp;&nbsp;</a>
            </div>
        </div>
        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="false" EmptyDataText="No Employees" CssClass="responsive-table striped card z-depth-2 col m8 l8 offset-m2 offset-l2">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="First Name" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Joining Date" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblJoiningDate" runat="server" Text='<%#Eval("JoiningDate","{0:d}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Contact Number" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblContactNumber" runat="server" Text='<%#Eval("ContactNumber")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Department Name" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentName" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Role" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Edit" runat="server"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button Id="btnEdit" Text="Edit" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnEdit_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label Text="Delete" runat="server"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" Text="Delete" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnDelete_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

