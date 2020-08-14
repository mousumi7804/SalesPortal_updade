using System;
using System.Web.Security;

public partial class Account_ChangePasswordSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        //or use Response.Redirect to go to a different page
        FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("~/Account/Login.aspx");
    }
}
