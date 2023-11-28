<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="Contact_Add" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="input-group mb-4">
    </div>

     <div class="wrapper container">
    <div class="col-lg-6">
    <div class="input-group input-group-lg">
        <span class="input-group-text">Select Country</span>
            <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
    </div>
        <div class="input-group mb-3">
    </div>
    <div class="input-group input-group-lg">
        <span class="input-group-text">Select State</span>
            <asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Text="Select a country first" Value="-1" Selected="True"></asp:ListItem>
            </asp:DropDownList>
    </div>

    

    

    <div class="input-group mb-3">
    </div>

    <div class="input-group input-group-lg">
        <span class="input-group-text">City Name</span>
        <asp:TextBox ID="txtCity" runat="server" placeholder="enter city name here..." CssClass="form-control"></asp:TextBox>
        </div>
    <div class="input-group mb-3">
    </div>
    <div class="input-group input-group-lg">
        <span class="input-group-text">STD Code</span>
        <asp:TextBox ID="txtSTD" runat="server" placeholder="enter city STD code here..." CssClass="form-control"></asp:TextBox>
        </div>
    <div class="input-group mb-3">
    </div>
    <div class="input-group input-group-lg">
        <span class="input-group-text">PIN Code</span>
        <asp:TextBox ID="txtZIP" runat="server" placeholder="enter city ZIP code here..." CssClass="form-control"></asp:TextBox>
        </div>

    <div class="input-group mb-3">
    </div>

    <div class="input-group input-group-lg">
        <span class="d-inline-block" id="addCountry" tabindex="0">
            <asp:Button ID="btnAdd" SkinID="btnInsert" runat="server" Text="Insert" OnClick="btnCityAdd_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" title="Warning" data-bs-content="If any of the above fields are empty, no changes will take place. Please check the above fields carefully to avoid any problems." />
            <asp:Button ID="btnCancel" SkinID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </span>
    </div>
    </div>
</div>
    <div class="input-group mb-5">
    </div>

    <asp:Label ID="lblDebug" runat="server"></asp:Label>
</asp:Content>

