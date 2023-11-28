<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="Contacts_View" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="input-group mb-3">
    </div>--%>
    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
       <%-- <table>
            <tr>
                <td>--%>
                    <asp:GridView ID="gvContacts" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvContacts_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ContactName" HeaderText="Contact" />
                            <%--<asp:BoundField DataField="ContactCategoryName" HeaderText="Type" />--%>
                            <%--<asp:TemplateField HeaderText="Contact Category">
                    <ItemTemplate>
                        <asp:Button ID="btnShowContactCategory" runat="server" Text="View Categories" SkinID="btnCategories" style="border-radius: 50px;" CommandName="ViewContactCategory" CommandArgument='<%# Eval("ContactID").ToString().Trim() %>' />
                        <asp:BulletedList ID="blCategoryList" runat="server" BulletStyle="Square"></asp:BulletedList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <asp:BoundField DataField="ContactCategoryID" HeaderText="Categories" />
                            <asp:BoundField DataField="ContactNo" HeaderText="Number" />
                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                            <asp:BoundField DataField="StateName" HeaderText="State" />
                            <asp:BoundField DataField="CityName" HeaderText="City" />
                            <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsApp" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="BirthDate" HeaderText="Date Of Birth" DataFormatString="{0:MMM-dd-yyyy}" />
                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                            <asp:BoundField DataField="Email" HeaderText="Email Address" />
                            <asp:BoundField DataField="FaceBookID" HeaderText="Facebook" />
                            <asp:BoundField DataField="LinkedINID" HeaderText="Linked IN" />
                            <asp:BoundField DataField="Address" HeaderText="Residence" />
                            <%--<asp:BoundField DataField="FilePath" HeaderText="File Path" />--%>
                            <asp:BoundField DataField="FileDetails" HeaderText="Image Details" />

                            <asp:TemplateField HeaderText="Contact's Photo">
                                <ItemTemplate>
                                    <asp:Image ID="imgPhoto" runat="server" CssClass="img-thumbnail" ImageUrl='<%# Eval("FilePath").ToString().Trim() %>' AlternateText="Photo Not Uploaded" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" SkinID="btnDelete" Text="Delete" CommandName="DeleteContact" CommandArgument='<%# Eval("ContactID").ToString().Trim() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" SkinID="btnUpdate" NavigateUrl='<%# "~/AdminPanel/Contact/Edit/" + CommonDropDownFillMethods.Base64Encode(Eval("ContactID").ToString().Trim()) %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
               <%-- </td>--%>
                <%--<td>
                    <asp:GridView ID="gvCategories" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="height:727px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Categories" HeaderText="Categories" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>--%>
            <%--</tr>
        </table>--%>
    </div>
</asp:Content>

