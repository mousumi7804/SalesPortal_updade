using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class OnlineReport_DailySalesReport : System.Web.UI.Page
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
        //if (!IsPostBack)
        //{
        //    ReportBinding();
        //}
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

            using (SqlCommand cmd = new SqlCommand("Mad_designationwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", null);
                cmd.Parameters.AddWithValue("@Action", DropDowndiv.SelectedValue.ToString());
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
                        rpt_daily.ReportTitle = "Daily Sales Report MAD";
                        rpt_daily.ReportName = "salesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
    protected void searchbtn_Click(object sender, EventArgs e)
    {
        ReportBinding();
    }
}