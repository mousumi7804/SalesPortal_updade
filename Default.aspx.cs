using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Session["username"] = User.Identity.Name;
            Response.Redirect("~/Account/intermediatepage.aspx");
            //  Server.Transfer("~/DataEntry/PersonalForm.aspx");
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

            string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(RecruitmentConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[procuserlogindetails]"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    cmd.Parameters.AddWithValue("@clientip", ipaddress);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }


            }

            Response.Redirect("~/Account/intermediatepage.aspx");
        }
        catch (Exception ex)
        {

            // Response.Write(ex.ToString());
            // Server.Transfer("~/Account/Login.aspx");
        }

    }
}
