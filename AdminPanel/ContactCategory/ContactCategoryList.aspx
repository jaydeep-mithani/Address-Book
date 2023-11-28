<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="ContactCategory_View" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="input-group mb-3">
    </div>--%>
    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
        <asp:GridView ID="gvContactCategory" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvContactCategory_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Type" />

                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" SkinID="btnDelete" Text="Delete" CommandName="DeleteContactCategory" CommandArgument='<%# Eval("ContactCategoryID").ToString().Trim() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" SkinID="btnUpdate" runat="server" Text="Edit"
                            NavigateUrl='<%# "~/AdminPanel/ContactCategory/Edit/" + CommonDropDownFillMethods.Base64Encode(Eval("ContactCategoryID").ToString().Trim()) %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
</asp:Content>

