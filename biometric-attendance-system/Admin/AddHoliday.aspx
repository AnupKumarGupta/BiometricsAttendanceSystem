<%@ Page Title="Add Holiday" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AddHoliday.aspx.cs" Inherits="Admin_AddHoliday" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 breadcrumb">
                    <br />
                    <a href="~/Admin/ManageMasterEntries.aspx" class="grey-text">Home &nbsp;&nbsp;></a>
                    <a href="#!" class="teal-text">&nbsp;&nbsp;Add Holiday &nbsp;&nbsp;</a>
                </div>
                <div class="col s12 m12 l10 offset-l1 card">
                    <br />
                    <div class="row">
                        <div class="col s12 m12 l4 offset-l1" style="/*margin-left: 35px*/">
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="center picker__calendar-container" BackColor="White" BorderColor="#999999" DayNameFormat="Shortest" FirstDayOfWeek="Sunday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" ShowGridLines="True" Width="358px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" Height="10px" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                            <br />
                        </div>
                        <%-- GridView Starts--%>
                        <div class="col s12 m12 l5 offset-l1">
                            <asp:GridView ID="grdHoliday" runat="server" AutoGenerateColumns="false" CssClass="responsive-table striped" EmptyDataText="No Data">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Date" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date","{0:d}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Name Of Holiday" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameOfHoliday" runat="server" Text='<%#Eval("NameOfHoliday")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Status" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# (Convert.ToInt32(Eval("Status").ToString())) == 1  ? "Holiday" : "Weekly Off" %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label Text="Actions" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CausesValidation="false" CssClass="btn red text-white" CommandArgument='<%#Eval("Id")%>' runat="server" Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <%-- GridView Ends --%>
                    </div>


                    <div class="row center">
                        <asp:Label ID="lblDate" runat="server" CssClass="input-field teal-text" Text="Date"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtHoliday" placeholder="Name of Holiday" CssClass="input-field col l5 m5 s12" runat="server">
                        </asp:TextBox>
                        <asp:DropDownList runat="server" ID="ddlStatus" CssClass="input-field btn teal white-text col l5 m5 s12 offset-m2 offset-l2">
                            <asp:ListItem Text="Holiday" Value="1" />
                            <asp:ListItem Text="Weekly Off" Value="2" />
                        </asp:DropDownList>
                    </div>
                    <div class="row">
                        <div class="col s12 m4 l4 offset-m3 offset-l3">
                            <asp:Button ID="btnAddHoliday" runat="server" Text="Add Holiday" CssClass="btn" OnClick="btnAddHoliday_Click" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

