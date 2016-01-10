<%@ Page Title="Assign Leave" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AssignLeave.aspx.cs" Inherits="Admin_AssignLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col s6 m6 l6 offset-s3 offset-m3 offset-l3">
            <div class="row">
                <asp:DropDownList ID="ddlDepartment" runat="server" Visible="true" CssClass="input-field btn grey lighten-4 teal-text col m4 l4 s4 offset-s4 offset-m4 offset-l4">
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Button ID="Button1" runat="server" Text="Employees"  CssClass="btn col m4 l4 s4 offset-s4 offset-m4 offset-l4" OnClick="btnGetAllEmployess_Click" />
            </div>
            <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="false" CssClass="responsive-table striped card z-depth-2 col m8 l8 offset-m2 offset-l2"  EmptyDataText="No Data">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Name" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
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
                            <asp:Label Text="Leave" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" Text="Assign Leave" runat="server" CommandArgument='<%#Eval("Id") +";"+Eval("Name") %>' OnClick="btnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

