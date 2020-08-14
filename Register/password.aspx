<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Register/Site.master" AutoEventWireup="true"
    CodeFile="password.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


    <style type="text/css">
        .style1 {
            height: 23px;
        }

        .container1 {
            background-color: #f2f2f2;
            padding-left: 15px;
            margin-top: -19px;
            margin-left: -8px;
            margin-right: -8px;
            height: 75vh;
        }
    </style>


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container1">
        <hr />
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <label for="info">Forgot Your Password?</label>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-10">
                                <asp:PasswordRecovery ID="PasswordRecovery2" runat="server">
                                    <UserNameTemplate>



                                        <label for="info">Enter your User Name to receive your password.</label><br />
                                        <label for="info">(You will be receive password to your registered Email)</label><br />


                                        <asp:TextBox ID="UserName" runat="server" class="form-control rounded-0" Width="75%" placeholder="Enter User Name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                            ControlToValidate="UserName" ErrorMessage="User Name is required."
                                            ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator><br />

                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal><br />

                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" class="btn btn-primary"
                                            ValidationGroup="PasswordRecovery1" />

                                    </UserNameTemplate>
                                </asp:PasswordRecovery>



                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>



    </div>
</asp:Content>
