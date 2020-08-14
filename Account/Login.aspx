<%@ Page Title="Sales Portal | Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .container1
        {
            background-color: #f2f2f2;
            padding-left: 15px;
            margin-top: -19px;
            margin-left: -8px;
            margin-right: -8px;
            height: 80vh;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container1">
        <hr />
        <h2>
            Log In
        </h2>
        <p>
            Please enter your username and password.
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Register/Register.aspx">Sign Up</asp:LinkButton>
            if you don't have an account.
        </p>
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
            <LayoutTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" />
                <div class="accountInfo">
                    <fieldset class="login">
                        <p>
                            <table id="login_tbl">
                                <tr>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="RememberMe" runat="server" />
                                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </fieldset>
                    </td></tr>
                    <tr>
                        <td scope="row">
                            <asp:HyperLink ID="fpassword_link" runat="server" NavigateUrl="~/Register/password.aspx">Forgot Password</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="submitButton">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                                    class="btn btn-success btn-lg" OnClick="LoginButton_Click" />
                            </p>
                        </td>
                    </tr>
                    </table> </p>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>
