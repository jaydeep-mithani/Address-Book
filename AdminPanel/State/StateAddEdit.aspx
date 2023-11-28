<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="State_Add" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="input-group mb-4">
    </div>

    <div class="wrapper container">

    <div class="col-lg-4">
    <div class="input-group input-group-lg">
        <span class="input-group-text">Select Country</span>
            <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control">
            </asp:DropDownList>
    </div>

    </div>

    <div class="input-group mb-3">
    </div>

    <div class="col-lg-6">
    <div class="input-group input-group-lg">
        <span class="input-group-text">State Name</span>
        <asp:TextBox ID="txtState" runat="server" placeholder="enter state name here..." CssClass="form-control"></asp:TextBox>
        </div>
        
         <div class="input-group mb-3">
    </div>

    <div class="input-group input-group-lg">
        <span class="input-group-text">State Code</span>
        <asp:TextBox ID="txtCode" runat="server" placeholder="enter state code here..." CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="input-group mb-3">
    </div>

    <div class="input-group input-group-lg">
        <span class="d-inline-block" id="addCountry" tabindex="0">
            <asp:Button ID="btnAdd" SkinID="btnInsert" runat="server" Text="Insert" OnClick="btnStateAdd_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" title="Warning" data-bs-content="If any of the above fields are empty, no changes will take place. Please check the above fields carefully to avoid any problems." />
            <asp:Button ID="btnCancel" SkinID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </span>
    </div>

        </div>
    </div>

    <div class="input-group mb-5">
    </div>

    <asp:Label ID="lblDebug" runat="server"></asp:Label>

</asp:Content>

