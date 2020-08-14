<%@ Page Title="Sign Up Here" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .container1 {
         
         background-color: #f2f2f2;
        padding-left:15px;
         margin-top:-19px;
          margin-left:-8px;
          margin-right:-8px;
       
          
}
.req_css
       {
            color:Red;
           
           }
    </style>
    <script type="text/javascript">
        function CheckEmail() {
            var bool = false;
            if (Page_ClientValidate()) {

                var uname = document.getElementById('<%= HiddenField_uname.ClientID %>').value;
                var uemail = document.getElementById('<%= HiddenField_uemail.ClientID %>').value;
                if (uname != uemail) {
                    alert("User Name or Email Is not Same")
                    bool = false;
                }

                else {


                    $.ajax({
                        url: '<%=ResolveUrl("Register.aspx/CheckEmail")%>',
                        data: '{uname: ' + JSON.stringify(uname) + '}',
                        method: "POST",
                        async: false,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var data1 = data.d;


                            if (data1 == "0") { bool = true; }
                            else if (data1 == "1") {

                                alert("Invalid Corporate Email id")
                                bool = false;
                            }
                            else {
                                alert("Invalid Corporate Email id ");
                                bool = false;
                            }

                        },
                        error: function (error) {
                            alert("eroor");
                            alert("Error: " + JSON.stringify(error));
                            bool = false;
                        }
                    });
                }


            }
            return bool;

        }
        // ------------------------------------------------------------------
        function myFunction(t) {

            document.getElementById('<%= HiddenField_uname.ClientID %>').value = t.value;

            submit = 0;

        }
        function myFunction1(t) {

            document.getElementById('<%= HiddenField_uemail.ClientID %>').value = t.value;

            submit = 0;

        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container1">
        <%--<asp:SqlDataSource ID="sqldinsert" runat="server" ConnectionString="<%$ ConnectionStrings:RecruitmentConnectionString %>"
            InsertCommand="proccandidatesignup" InsertCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:RecruitmentConnectionString.ProviderName %>">
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="MailId" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>--%>
        <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
            <LayoutTemplate>
                <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <WizardSteps>
                <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                    <ContentTemplate>
                        <h2>
                            Employee Sign Up
                        </h2>
                        <%--<p>
                            Use the form below to create a new account.<br />
                            <asp:Label ID="Label2" runat="server" Text="**Remember User Name & Password for Log In"
                                ForeColor="red" Font-Bold="true"></asp:Label>
                        </p>--%>
                        <p>
                            Passwords are required to be a minimum of
                            <%= Membership.MinRequiredPasswordLength %>
                            characters in length.
                        </p>
                        <span class="failureNotification">
                            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                        </span>
                        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                            ValidationGroup="RegisterUserValidationGroup" />
                        <div class="accountInfo">
                            <fieldset class="register">
                                <legend>Account Information</legend>
                                
                                 <div class="row">
                                <div class="col-md-6">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                 <asp:TextBox ID="UserName" runat="server"  onblur="myFunction(this)"  Width="90%"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="req_css"
                                                 ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            <label for="warn">Use Corporate Mail Id As User Name</label>
                                            
                                </div>
                                </div>
                                <div class="row">
                                <div class="col-md-6">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server"  onblur="myFunction1(this)"  Width="90%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                 ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                                                ValidationGroup="RegisterUserValidationGroup" CssClass="req_css">*</asp:RequiredFieldValidator><br />
                                            <label for="warn">Enter Email Id Same As User Name</label>
                                            
                                </div>
                                </div>
                                <div class="row">
                                <div class="col-md-6">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server"  TextMode="Password"   Width="90%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                 ErrorMessage="Password is required." ToolTip="Password is required."
                                                ValidationGroup="RegisterUserValidationGroup" CssClass="req_css">*</asp:RequiredFieldValidator>
                                </div>
                                </div>
                                <div class="row">
                                <div class="col-md-6">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server"  TextMode="Password" Width="90%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" 
                                                Display="Dynamic" ErrorMessage="Confirm Password is required." CssClass="req_css" ID="ConfirmPasswordRequired"
                                                runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                ControlToValidate="ConfirmPassword"  Display="Dynamic" CssClass="req_css"
                                                ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                </div>
                                </div>


         <%--                       <table id="register_tbl">
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>--%>
                                            
                            </fieldset>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User" CssClass=" btn btn-primary"
                                            OnClientClick="return CheckEmail();" ValidationGroup="RegisterUserValidationGroup" />
                                </div>
                                </div>
                           <%-- </td></tr>
                            <tr>
                                <td>
                                    <p class="submitButton">
                                        
                                </td>
                            </tr>
                            </table> </p>--%>
                        </div>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <asp:HiddenField ID="HiddenField_uname" runat="server" />
        <asp:HiddenField ID="HiddenField_uemail" runat="server" />
    </div>
</asp:Content>
