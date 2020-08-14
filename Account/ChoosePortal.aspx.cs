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

public partial class Account_ChoosePortal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");

        }
        if (!IsPostBack)
        {
            AllowReportPortal();
        }
    }
    protected void LBhrms_Click(object sender, EventArgs e)
    {
        string roleid;
        int isrepotingauthority;
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
                    isrepotingauthority = Convert.ToInt32(sdr["isreportingothority"]);
                    roleid = sdr["roleid"].ToString();

                }
                con.Close();

            }


        }

        switch (roleid)
        {
            case "1":
                {
                    if (isrepotingauthority == 0)
                    {

                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "2":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "3":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "4":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "5":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "6":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HREMPHome.aspx");
                    }
                    break;
                }
            case "8":
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/HR/HRSEmpHome.aspx");
                    }

                    break;
                }
            default:
                {
                    if (isrepotingauthority == 0)
                    {
                        Response.Redirect("~/LeaveModule/HPages/SEmpHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/LeaveModule/HPages/EmpHome.aspx");
                    }
                    break;
                }
        }
    }
    private void AllowReportPortal()
    {
        if (Session["username"].ToString() == "sandip.porel@mendine.com")
        {
            LBonlinereport.Visible = true;
        }
    }
    protected void LBonlinereport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OnlineReport/ListOfReport.aspx");
    }
}