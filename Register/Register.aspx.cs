using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Account_Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {


       

        Menu men = (Menu)Master.FindControl("NavigationMenu");
        if (Page.User.Identity.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser(Page.User.Identity.Name);
            if (!user.IsApproved)
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();

                Response.Redirect("~/Account/Register.aspx");
            }
        }
        men.Visible = false;
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
       
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

      //  string continueUrl = RegisterUser.ContinueDestinationPageUrl;

       
        
       // if (String.IsNullOrEmpty(continueUrl))
      //  {
          //  continueUrl = "~/";
       // }

        Menu men = (Menu)Master.FindControl("NavigationMenu");
        if (Page.User.Identity.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser(Page.User.Identity.Name);
            if (!user.IsApproved)
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();

                Response.Redirect("~/Account/Register.aspx");
            }
        }
        men.Visible = false;
       // ErrorMessage.Text = "SUCCESS";

      //  Literal lt = (Literal)this.FindControl("ErrorMessage");

        

       // Response.Write(RegisterUser.Email.ToString());


        //sqldinsert.InsertParameters[0].DefaultValue = RegisterUser.UserName.ToString();
        //sqldinsert.InsertParameters[1].DefaultValue = RegisterUser.Email.ToString();

        //sqldinsert.Insert();

        Response.Redirect("~/Account/Login.aspx");

    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {

    }
    protected void ContinueButton_Click(object sender, EventArgs e)

    {

        Response.Redirect("~/Account/Login.aspx");    //Menu men = (Menu)Master.FindControl("NavigationMenu");
        if (Page.User.Identity.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser(Page.User.Identity.Name);
            if (!user.IsApproved)
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();

                Response.Redirect("~/Account/Login.aspx");
            }
        }
       // men.Visible = false;

    }
    [System.Web.Services.WebMethod]
    public static string CheckEmail(string uname )
    {
        string status1;
        string constr = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procvalidateempemail"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@action", "Select");
                //cmd.Parameters.AddWithValue("@mailid", uemail);
                cmd.Parameters.AddWithValue("@email", uname);
                //cmd.Parameters.AddWithValue("@otp", uotp);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 500);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                status1 = cmd.Parameters["@message"].Value.ToString();
            }
        }
        return status1;
    }
}
