<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="City_View" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<div class="input-group mb-3">
    </div>--%>
    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
        <asp:GridView ID="gvCities" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" OnRowCommand="gvCities_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CountryName" HeaderText="Country" />
                <asp:BoundField DataField="StateName" HeaderText="State" />
                <asp:BoundField DataField="CityName" HeaderText="City" />
                <asp:BoundField DataField="STDCode" HeaderText="STD" />
                <asp:BoundField DataField="PinCode" HeaderText="ZIP" />

                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" SkinID="btnDelete" Text="Delete" CommandName="DeleteCity" CommandArgument='<%# Eval("CityID").ToString().Trim() %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" SkinID="btnUpdate" runat="server" Text="Edit" NavigateUrl='<%# "~/AdminPanel/City/Edit/" + CommonDropDownFillMethods.Base64Encode(Eval("CityID").ToString().Trim()) %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>

