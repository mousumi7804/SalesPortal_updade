<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
 .container1 {
         
         background-color: #f2f2f2;
        
         padding-left:15px;
         margin-top:-20px;
          margin-left:-8px;
          margin-right:-8px;
        
}
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container1">

    <h2>
        Change Password
    </h2>
    <p>
        Use the form below to change your password.
    </p>
    <p>
        New passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
    </p>
    <div class="row">
    <div class="col-md-6">
    </div>
    </div>
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false" 
         SuccessPageUrl="ChangePasswordSuccess.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ChangeUserPasswordValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                        <div class="row">
                    <div class="col-md-7">
                    <asp:TextBox ID="CurrentPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                     </div>
                        
                        
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                        <div class="row">
                    <div class="col-md-6">
                    <asp:TextBox ID="NewPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                             CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                     </div>
                        
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                        <div class="row">
                     <div class="col-md-6">
                      <asp:TextBox ID="ConfirmNewPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                             ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                        </div>
                         </div>
                       
                    </p>
                </fieldset>
                <p class="submitButton">
                <div class="row">
                <div class="col-md-4">
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"  class="btn btn-success btn-sm" Text="Change Password" 
                         ValidationGroup="ChangeUserPasswordValidationGroup"/>
                </div>
                <div class="col-md-3">
                     <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" class="btn btn-success btn-sm" CommandName="Cancel" Text="Cancel"/>
                </div>
                </div>
   
                    
                    
                </p>
            </div>
            
        </ChangePasswordTemplate>
    </asp:ChangePassword>
    </div>
</asp:Content>