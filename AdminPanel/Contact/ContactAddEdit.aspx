<%@ Page Title="" Language="C#" MasterPageFile="~/Delete_View.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="Contact" Theme="Accents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="input-group mb-4">
    </div>

    <div class="wrapper container" style="overflow-y: scroll; height: 540px;">
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
                <asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="ddlStates_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Select a country first" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Select City</span>
                <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" Enabled="false">
                </asp:DropDownList>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Select a Contact Category</span>
                <asp:CheckBoxList ID="cblContactCategory" runat="server" CssClass="form-control">
                </asp:CheckBoxList>
            </div>
        </div>

        <div class="input-group mb-3">
        </div>

        <div class="col-lg-7">
            <div class="input-group input-group-lg">
                <span class="input-group-text">Contact Name</span>
                <asp:TextBox ID="txtContactName" runat="server" placeholder="enter contact name here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Contact Number</span>
                <asp:TextBox ID="txtCountactNumber" runat="server" TextMode="Number" placeholder="enter contact no. here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Contact Email</span>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="enter email here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Whats App Number (Optional)</span>
                <asp:TextBox ID="txtWhatsApp" runat="server" TextMode="Number" placeholder="enter WhatsApp no. here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Facebook (Optional)</span>
                <asp:TextBox ID="txtFacebook" runat="server" placeholder="enter facebook id here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Linked IN (Optional)</span>
                <asp:TextBox ID="txtLinkedIn" runat="server" placeholder="enter linked-in id here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Age (Optionl)</span>
                <asp:TextBox ID="txtAge" runat="server" TextMode="Number" placeholder="enter age here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Birth date (Optionl)</span>
                <asp:TextBox ID="txtBirthdate" runat="server" TextMode="Date" placeholder="choose birthdate here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Blood Group (Optionl)</span>
                <asp:TextBox ID="txtBloodGroup" runat="server" placeholder="enter blood group here..." CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="input-group mb-3">
        </div>
        <div class="col-lg-9">
            <div class="input-group input-group-lg">
                <span class="input-group-text">Address</span>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" placeholder="enter address here..." CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            </div>
            <div class="input-group input-group-lg">
                <span class="input-group-text">Contact photo (Optional)</span>
                <span class="input-group-text">
                    <asp:Image ID="imgPreview" runat="server" CssClass="img-thumbnail" Visible="false" Height="150px" Width="250px" AlternateText="No image uploaded" />
                </span>
                <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" accept=".png,.jpg,.jpeg,.gif" />
                <%--<span class="input-group-text"><asp:Label ID="lblNoFile" runat="server" Visible="false"></asp:Label></span>--%>
            </div>
        </div>
        <div class="input-group mb-4">
        </div>

        <div class="input-group input-group-lg">
            <span class="d-inline-block" id="addCountry" tabindex="0">
                <asp:Button ID="btnAdd" SkinID="btnInsert" runat="server" Text="Insert" OnClick="btnContactAdd_Click" data-bs-toggle="popover" data-bs-trigger="hover focus" title="Warning" data-bs-content="If any of the above fields are empty, no changes will take place. Please check the above fields carefully to avoid any problems." />
                <asp:Button ID="btnCancel" SkinID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </span>
        </div>

        <div class="input-group mb-4">
        </div>

    </div>
    <%--<script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=fuPhoto.ClientID %>');
            var file = document.querySelector('#<%=fuPhoto.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>--%>
</asp:Content>

