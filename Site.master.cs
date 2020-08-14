using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
       



    }
    //protected void Page_Init()
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //}
    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {


        if (Context.Session != null)
        {
            if (Session.IsNewSession)
            {
                HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
                if (newSessionIdCookie != null)
                {
                    string newSessionIdCookieValue = newSessionIdCookie.Value;
                    if (newSessionIdCookieValue != string.Empty)
                    {
                        // This means Session was timed Out and New Session was started
                        FormsAuthentication.SignOut();
                        //or use Response.Redirect to go to a different page
                        FormsAuthentication.RedirectToLoginPage();
                        Response.Redirect("~/Account/Login.aspx");
                    }
                }
            }
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        //string strDisAbleBackButton;
        //strDisAbleBackButton = "<script language='javascript'>\n";
        //strDisAbleBackButton += "window.history.forward(1);\n";
        //strDisAbleBackButton += "\n</script>";

        //Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "clientScript", strDisAbleBackButton);
    }
    protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Session.Abandon();
        //Response.Redirect("~/Account/Login.aspx");
    }
    //retrive role id depending on username
    protected string AccessRoleid()
    {
        string roleid1;

        string Constr = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(Constr))
        {
            using (SqlCommand cmd = new SqlCommand("[procidentifyempone]"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empemail", Session["username"].ToString());

                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();

                    roleid1 = sdr["roleid"].ToString();

                }
                con.Close();

            }


        }
        return roleid1;
    }

}
