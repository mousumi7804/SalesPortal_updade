using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();


    }
    protected void Page_Init()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }
    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    //protected void Page_Init(object sender, EventArgs e)
    //{


    //    if (Context.Session != null)
    //    {
    //        if (Session.IsNewSession)
    //        {
    //            HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
    //            if (newSessionIdCookie != null)
    //            {
    //                string newSessionIdCookieValue = newSessionIdCookie.Value;
    //                if (newSessionIdCookieValue != string.Empty)
    //                {
    //                    // This means Session was timed Out and New Session was started
    //                    FormsAuthentication.SignOut();
    //                    //or use Response.Redirect to go to a different page
    //                    FormsAuthentication.RedirectToLoginPage();
    //                    Response.Redirect("~/Account/Login.aspx");
    //                }
    //            }
    //        }
    //    }
    //}
}
