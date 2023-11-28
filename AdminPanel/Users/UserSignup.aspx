<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSignup.aspx.cs" Inherits="SignupForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Address book signup</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-dark bg-dark">
            <div class="container-fluid">
                <span class="navbar-brand mb-1 h1">Address Book Sign-up</span>
            </div>
        </nav>
        <div class="mb-5"></div>
        <div class="container" style="border: 1px solid lightgrey;">
            <div class="mb-3"></div>
            <div class="container">
                <div class="input-group mb-4">
                    <span class="input-group-text" id="basic-addon1">Create a username</span>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="create a unique username" aria-label="Username" aria-describedby="basic-addon1" />
                    <span class="input-group-text" id="basic-addon8"><asp:Label ID="lblErrUsrName" runat="server"></asp:Label></span>
                </div>
                <div class="input-group mb-4">
                    <span class="input-group-text" id="basic-addon2">Password</span>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="enter a new password" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                    <span class="input-group-text" id="basic-addon3">Confirm Password</span>
                    <asp:TextBox ID="txtConfPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="re-enter the password" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                    <span class="input-group-text" id="basic-addon9"><asp:Label ID="lblErrPass" runat="server"></asp:Label></span>
                </div>
                <div class="input-group mb-4">
                    <span class="input-group-text" id="basic-addon4">First Name</span>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="enter your first name" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                    <span class="input-group-text" id="basic-addon5">Last Name</span>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="enter your last name" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                </div>
                <div class="input-group mb-5">
                    <span class="input-group-text" id="basic-addon6">Phone</span>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="enter a 10-digit phone number" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                    <span class="input-group-text" id="basic-addon7">E-mail</span>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="xyz@example.com" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                </div>
                <div class="input-group mb-4">
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Me Up!" CssClass="col-md-12 btn btn-outline-success" OnClick="btnSignUp_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" data-bs-placement="bottom" title="Warning!" data-bs-content="Make sure none of the fields are empty, or you won't get signed up." />
                </div>
            </div>
        </div>
        <div class="mb-2"></div>
        <div class="container">
            <%--<div class="input-group mb-3">--%>
            <p class="text-center">
                <asp:HyperLink ID="hlBackToLogin" runat="server" Text="return to login page" NavigateUrl="~/AdminPanel/Login"></asp:HyperLink></p>
            <%--</div>--%>
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.6.0.min.js"></script>
<script src="Scripts/bootstrap.bundle.min.js"></script>
<script>
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    })
</script>
</html>
