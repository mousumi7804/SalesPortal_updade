using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Globalization;
using System.Configuration;

public partial class Account_Register : System.Web.UI.Page
{
     
    string status;
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
    }
}
