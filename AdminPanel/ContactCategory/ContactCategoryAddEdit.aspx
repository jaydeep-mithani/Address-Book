<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="ContactCategory_Add" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="input-group mb-4">
    </div>

    <div class="wrapper container">
        <div class="col-lg-9">
            <div class="input-group input-group-lg">
                <span class="input-group-text">Add a Contact Category</span>
                <asp:TextBox ID="txtCategory" runat="server" placeholder="enter a contact category here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>

            <div class="input-group input-group-lg">
                <span class="d-inline-block" id="addCountry" tabindex="0">
                    <asp:Button ID="btnAdd" SkinID="btnInsert" runat="server" Text="Insert" OnClick="btnContactCategoryAdd_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" title="Warning" data-bs-content="If any of the above fields are empty, no changes will take place. Please check the above fields carefully to avoid any problems." />
                    <asp:Button ID="btnCancel" SkinID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </span>
            </div>
        </div>
    </div>
    <div class="input-group mb-5">
    </div>
</asp:Content>

