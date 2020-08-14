using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ToutSolution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection con = new SqlConnection(RecruitmentConnectionString))
        {
            using (SqlCommand cmd1 = new SqlCommand("selectswillorder"))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@orderdate",txtdate.Text.Trim());
               // cmd1.Parameters.AddWithValue("@order", dt);
                //cmd1.Parameters.AddWithValue("@ordersequence", "MAD-");
               // cmd1.Parameters.Add("@Message", SqlDbType.VarChar, 300);
                //cmd1.Parameters["@Message"].Direction = ParameterDirection.Output;




                //cmd1.Connection = con;
                //con.Open();
                //cmd1.ExecuteNonQuery();
                //con.Close();

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd1.Connection = con;
                    sda.SelectCommand = cmd1;
                    using (DataTable dt1 = new DataTable())
                    {
                        sda.Fill(dt1);
                        GridViewresult.DataSource = dt1;
                        GridViewresult.DataBind();
                    }
                }

               


            }
        }
    }
    protected void btndelect_Click(object sender, EventArgs e)
    {


        string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection con = new SqlConnection(RecruitmentConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("deleteswillorder"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderdate", txtdate.Text.Trim());
                // cmd.Parameters.AddWithValue("@leavedescription", leavetype);


                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 300);
                cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                Showstatus_lbl.Text = cmd.Parameters["@msg"].Value.ToString();
                con.Close();


            }
        }
    }
}