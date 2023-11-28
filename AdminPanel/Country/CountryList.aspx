<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="Country_View" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<div class="input-group mb-3">
        <asp:Label ID="lblTest" runat="server"></asp:Label>
    </div>--%>
    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
    <asp:GridView ID="gvCountries" runat="server" OnRowCommand="gvCountries_RowCommand">
        <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Code" />

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" SkinID="btnDelete" CommandName="deleteCountry"
                                CommandArgument='<%# Eval("CountryID").ToString()  %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" SkinID="btnUpdate" CommandName="editCountry"
                                NavigateUrl='<%# "~/AdminPanel/Country/Edit/" + CommonDropDownFillMethods.Base64Encode(Eval("CountryID").ToString().Trim()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
        </div>
</asp:Content>

