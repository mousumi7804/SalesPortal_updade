using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OnlineReport_Transactionbilltrends : System.Web.UI.Page
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
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ReportBinding();
    }
    public void ReportBinding()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("[Transactionbilltrendsautomationafterprocess]"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@endate", txtfrmdate.Text.Trim());
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
               // cmd.Parameters.AddWithValue("@Action", DropDowndiv.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        lblstatus.Text = cmd.Parameters["@message"].Value.ToString();
                        if (cmd.Parameters["@message"].Value.ToString() == "")
                        {
                            rpt_Transactionbilltrends.ReportTitle = "Transactionbilltrends";
                            rpt_Transactionbilltrends.ReportName = "Transactionbilltrends";
                            rpt_Transactionbilltrends.DataBind(ds);
                            rpt_Transactionbilltrends.Visible = true;
                        }
                        
                    }
                }
            }
        }
    }
}