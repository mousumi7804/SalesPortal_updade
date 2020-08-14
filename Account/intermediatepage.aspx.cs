using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Account_intermediatepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["username"] = User.Identity.Name;
            ChekPasswordChange();
            //  Server.Transfer("~/DataEntry/PersonalForm.aspx");
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
            using (SqlConnection con = new SqlConnection(RecruitmentConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [dbo].[Maduser] ('"+ Session["username"]+"')"))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                       string div= dt.Rows[0][0].ToString();
					   if(div=="MAD")
					   {
						   Session["div"]="MAD";
						    Response.Redirect("~/OnlineReport/DailySalesReportUserWise.aspx");
							
					   }
					   if(div=="EVA")
					   {
						   Session["div"]="EVA";
						    Response.Redirect("~/OnlineReport/DailySalesReportUserWise.aspx");
							
					   }
					   
					   if(div=="PHOENIX")
					   {
						   Session["div"]="PHOENIX";
						    Response.Redirect("~/OnlineReport/DailySalesReportUserWise.aspx");
							
					   }

                       if (div == "CONCORD")
                       {
                           Session["div"] = "CONCORD";
                           Response.Redirect("~/OnlineReport/DailySalesReportUserWise.aspx");

                       }
					   
                         if(div=="ADMIN")
					   
						{
							
							//ListOfReport
							//DailySalesReportAll
							
							Response.Redirect("~/OnlineReport/ListOfReport.aspx");
							
						}

                         if (div == "DEPOT")
                         {

                             //ListOfReport
                             //DailySalesReportAll

                             Response.Redirect("~/OnlineReport/DailyOrederViewDepot.aspx");

                         }
						else
						{
							Session.Abandon();
            //FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            //FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");
						}
                    }
                }

                }

               
            }
			
			
			
			//string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
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
			
			
			
			
            //CheckEmployee();
           // Response.Redirect("~/Pages/hr_home.aspx");
            //Response.Redirect("~/OnlineReport/DailySalesReportUserWise.aspx");
            //CheckEmployee();
           // Response.Redirect("~/Pages/hr_home.aspx");");
        }
        catch (Exception ex)
        {
            // Response.Write(ex.ToString());
            // Server.Transfer("~/Account/Login.aspx");
        }
    }
    //Checking for role and redirect depending on role
    private void CheckEmployee()
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
                   if(isrepotingauthority==0)
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
    //check password change
    private void ChekPasswordChange()
    {
        string msg;
        string esspconnection = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(esspconnection))
        {
            using (SqlCommand cmd = new SqlCommand("Procresetpassword"))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());

                cmd.Parameters.Add("@status", SqlDbType.VarChar, 300);
                cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = cmd.Parameters["@status"].Value.ToString();
            }
        }
       // Label1.Text = msg;
        if (msg == "1")
        {
            Response.Redirect("~/Account/ChangePassword.aspx");
        }
    }
}