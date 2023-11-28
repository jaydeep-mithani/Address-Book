<%@ Page Language="C#" AutoEventWireup="false" CodeFile="LoginForm.aspx.cs" Inherits="LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center">
            <h1 class="display-1">Login</h1>
        </div>
        <div class="mb-5"></div>
        <div class="container" style="border: 1px dashed lightgrey">
            <div class="mb-3"></div>
            <div class="input-group mb-4">
                <asp:Label runat="server" CssClass="col-md-12 input-group-text" ID="lblErr" Visible="false"></asp:Label>
            </div>
            <div class="input-group mb-4">
                <span class="input-group-text" id="basic-addon2">Username</span>
                <asp:TextBox ID="txtUsrName" runat="server" placeholder="enter your unique user-name here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-5">
                <span class="input-group-text" id="basic-addon3">Password</span>
                <asp:TextBox ID="txtPass" runat="server" placeholder="enter your password here..." TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-4">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="col-md-12 btn btn-outline-success" OnClick="btnLogin_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" data-bs-placement="bottom" title="Warning!" data-bs-content="Make sure you don't leave any fields empty in order to login." />
            </div>
        </div>
        <div class="mb-4"></div>
        <div class="container">
            <p class="text-center">
                <asp:HyperLink ID="hlSignupLink" runat="server" Text="Don't have an existing account? Click here to signup now." NavigateUrl="~/AddressBook/Signup"></asp:HyperLink>
            </p>
        </div>
    </form>
</body>
<script src="~/Scripts/jquery-3.6.0.min.js"></script>
<script src="Scripts/bootstrap.bundle.min.js"></script>
<script>
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    })
</script>
</html>
