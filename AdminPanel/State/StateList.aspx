<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="States_View" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<div class="input-group mb-3">
    </div>--%>
    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
    <asp:GridView ID="gvStates" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvStates_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <columns>
            <asp:BoundField DataField="CountryName" HeaderText="Country" />
            <asp:BoundField DataField="StateName" HeaderText="State" />
            <asp:BoundField DataField="StateCode" HeaderText="State Code" />

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" SkinID="btnDelete" Text="Delete" CommandName="deleteState" CommandArgument='<%# Eval("StateID").ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink ID="hlEdit" runat="server" SkinID="btnUpdate" Text="Edit" NavigateUrl='<%# "~/AdminPanel/State/Edit/" + CommonDropDownFillMethods.Base64Encode(Eval("StateID").ToString().Trim()) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </columns>

        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />

    </asp:GridView>
        </div>
</asp:Content>

