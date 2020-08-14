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
        if (!IsPostBack)
        {
             if(Session["div"]=="MAD")
			 {
               			
DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Mad_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
						
		   ReportBinding();
			 }
			 if(Session["div"]=="EVA")
			 {	

DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Eva_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
		 
		 
		   ReportBindingeva();
			 }
			 if(Session["div"]=="PHOENIX")
			 {

DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Phoenix_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
		 
		   ReportBindingPhoenix();
			 }
        }
    }
protected void DropDownstocklocation_DataBound(object sender, EventArgs e)
    {
      DropDownstocklocation.Items.Insert(0, new ListItem("--SELECT--", "0"));
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

            using (SqlCommand cmd = new SqlCommand("Mad_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
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
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	public void ReportBindingeva()
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

            using (SqlCommand cmd = new SqlCommand("eva_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
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
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	public void ReportBindingPhoenix()
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

            using (SqlCommand cmd = new SqlCommand("Phoenix_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
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
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	protected void DropDownstocklocation_SelectedIndexChanged(object sender, EventArgs e)
    {
		
		  if(Session["div"]=="MAD")
			 {
		Session["username"]=DropDownstocklocation.SelectedValue;
		//lbldiv.Text = DropDownstocklocation.SelectedItem.ToString();//dt.Rows[0][0].ToString();
          ReportBinding();
			 }
		  
		   if(Session["div"]=="PHOENIX")
			 {
				 Session["username"]=DropDownstocklocation.SelectedValue;
				  ReportBindingPhoenix();
			 }
			 
			  if(Session["div"]=="EVA")
			 {
				 Session["username"]=DropDownstocklocation.SelectedValue;
				 ReportBindingeva();
			 }
    }
	
	 protected void btnstocksearch_Click(object sender, EventArgs e)
    {
//lbldiv.Text = DropDownstocklocation.SelectedItem.ToString();
    }
}