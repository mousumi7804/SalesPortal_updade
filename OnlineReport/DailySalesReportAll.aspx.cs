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
           
        //}
		//rpt_daily.Visible=false;
		//rpt_daily.Visible = false;
    }

    public void ReportBinding(string div)
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
                        rpt_daily.ReportName = "salesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	protected void  btnstocksearch_Click(object sender, EventArgs e)
	{
		
		if (DropDownstocklocation.SelectedValue == "MAD")
        {
			 rpt_daily.Visible =true;
			  Session["username"]=User.Identity.Name;
			 ReportBinding("MAD");
			 
			 
			 DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("MAD_userwise_higher"))
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
//DataView dv=new DataView(dt);
DataView view = dt.DefaultView;
view.Sort = "name";
                                ddlemp.DataSource = view;
                                ddlemp.DataTextField = "name";
                                ddlemp.DataValueField = "empemail";
                                ddlemp.DataBind();

                            }
                        }
                    }
                }
			
			 
			 
			 
			 
			
		}
		if (DropDownstocklocation.SelectedValue == "EVA")
		{
			rpt_daily.Visible =true;
			 Session["username"]=User.Identity.Name;
			ReportBindingeva("EVA");
			
			
			DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("EVA_userwise_higher"))
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

                               DataView view = dt.DefaultView;
view.Sort = "name";
                                ddlemp.DataSource = view;
                                ddlemp.DataTextField = "name";
                                ddlemp.DataValueField = "empemail";
                                ddlemp.DataBind();

                            }
                        }
                    }
                }
			
			
			
			
			
		}
		if (DropDownstocklocation.SelectedValue == "PHOENIX")
		{
			rpt_daily.Visible =true;
			 Session["username"]=User.Identity.Name;
			ReportBindingPhoenix("PHOENIX");
			
			
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

                                DataView view = dt.DefaultView;
view.Sort = "name";
                                ddlemp.DataSource = view;
                                ddlemp.DataValueField = "empemail";
                                ddlemp.DataBind();

                            }
                        }
                    }
                }
			
			
			
			
		}
		if (DropDownstocklocation.SelectedValue == "ROD")
		{
			rpt_daily.Visible =true;
			 Session["username"]=User.Identity.Name;
			ReportBindingROD("ROD");
			
			
			DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("rod_userwise_higher"))
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

                               DataView view = dt.DefaultView;
view.Sort = "name";
                                ddlemp.DataSource = view;
                                ddlemp.DataTextField = "name";
                                ddlemp.DataValueField = "empemail";
                                ddlemp.DataBind();

                            }
                        }
                    }
                }
			
			
			
			
			
		}

        if (DropDownstocklocation.SelectedValue == "CONCORD")
        {
            rpt_daily.Visible = true;
            Session["username"] = User.Identity.Name;
            ReportBindingCONCORD("CONCORD");


            DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("concord_userwise_higher"))
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
                            //lbldiv.Text = dt.Rows[0][0].ToString();
DataView view = dt.DefaultView;
view.Sort = "name";
                                ddlemp.DataSource = view;
                            ddlemp.DataTextField = "name";
                            ddlemp.DataValueField = "empemail";
                            ddlemp.DataBind();

                        }
                    }
                }
            }





        }
		
	}
	
	protected void ddlemp_DataBound(object sender, EventArgs e)
    {
      ddlemp.Items.Insert(0, new ListItem("--SELECT--", "0"));
   }
   
   
   
   
   protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
		
		  if(DropDownstocklocation.SelectedValue=="MAD")
			 {
		Session["username"]=ddlemp.SelectedValue;
		//lbldiv.Text = DropDownstocklocation.SelectedItem.ToString();//dt.Rows[0][0].ToString();
          rpt_daily.Visible =true;
			 ReportBinding("MAD");
			 }
		  
		   if(DropDownstocklocation.SelectedValue=="PHOENIX")
			 {
				 Session["username"]=ddlemp.SelectedValue;
				  ReportBindingPhoenix("PHOENIX");
			 }
			 
			  if(DropDownstocklocation.SelectedValue=="EVA")
			 {
				 Session["username"]=ddlemp.SelectedValue;
				rpt_daily.Visible =true;
			ReportBindingeva("EVA");
			 }
			 
			 if(DropDownstocklocation.SelectedValue=="ROD")
			 {
				 Session["username"]=ddlemp.SelectedValue;
				rpt_daily.Visible =true;
			ReportBindingROD("ROD");
			 }
             if (DropDownstocklocation.SelectedValue == "CONCORD")
             {
                 Session["username"] = ddlemp.SelectedValue;
                 rpt_daily.Visible = true;
                 ReportBindingCONCORD("CONCORD");
             }
    }
	
   
   
   
   
   
   
	
	 public void ReportBindingeva(string div)
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

            using (SqlCommand cmd = new SqlCommand("Eva_userwise_sale"))
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
                        rpt_daily.ReportName = "salesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	
	 public void ReportBindingPhoenix(string div)
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
	
	public void ReportBindingROD(string div)
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

            using (SqlCommand cmd = new SqlCommand("ROD_userwise_sale"))
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
    public void ReportBindingCONCORD(string div)
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

            using (SqlCommand cmd = new SqlCommand("CONCORD_userwise_sale"))
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
}