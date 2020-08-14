using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] == null)
        //{
        //if (!IsPostBack)
        //{
        //    Session.Abandon();
        //    FormsAuthentication.SignOut();
        //}
        //}
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
        Control txtblnk = (Control)Master.FindControl("txtblnk");
        txtblnk.Visible = false;
        Control txtblnk1 = (Control)Master.FindControl("txtblnk1");
        txtblnk1.Visible = false;
        
        try
        {
           
            List<string> keyList = new List<string>();
            IDictionaryEnumerator CacheEnum = HttpContext.Current.Cache.GetEnumerator();
            string cacheKey;

            while (CacheEnum.MoveNext())
            {
                cacheKey = CacheEnum.Key.ToString();
                keyList.Add(cacheKey);
            }

            foreach (string key in keyList)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            keyList.Clear();
            // Response.Write("Cache Cleared");
        }
        catch
        {
            //Response.Write("Cache NOT Cleared");
        }

       
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    
    }

    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        //TextBox txt = new TextBox();
        //txt = (TextBox)LoginUser.FindControl("txt_captha");

        //string captchastring;
        //try
        //{
        //    captchastring = Session["CAPTCHA"].ToString();
        //}
        //catch (Exception ex)
        //{
        //    captchastring = "";
        //}
        //if (captchastring.Equals(txt.Text))
        //    {
        //        Session["captha_check"] = "true";
        ////TextBox uname = (TextBox)LoginUser.FindControl("UserName");
        ////Session["uname"] = uname.Text;

        // Response.Redirect("~/Login/Intermediate.aspx");
        Response.Redirect("~/Account/intermediatepage.aspx");

        //    }
        //else
        //{
        //    Session["captha_check"] = "false";
        //    Response.Redirect("~/Account/Login.aspx");

        // System.Web.UI.WebControls.LoginView mn = (System.Web.UI.WebControls.LoginView)Master.FindControl("HeadLoginView");
        //mn.Visible = false;
        //Response.Write("wrong");
        //lbl.Text = "Enter the captha code carefully";
        // }

    }
}
