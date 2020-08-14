using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class OnlineReport_TransactionBillData : System.Web.UI.Page
{
    protected void Page_Load (object sender, EventArgs e)
    {
		if (Session["username"].ToString() == "pradip.sarkar@mendine.co.in")
       {
           Menu mainMenu = (Menu)Page.Master.FindControl("NavigationMenu");
           mainMenu.Visible = false;
        }
		
		
		
		else
		if(Session["username"].ToString() == "sanjay.mukherjee@mendine.co.in")
		{
			
			Menu mainMenu = (Menu)Page.Master.FindControl("NavigationMenu");
           mainMenu.Visible = false;
		}
		else
if(Session["username"].ToString() == "lincon.banerjee@mendine.co.in")
		{
			
			Menu mainMenu = (Menu)Page.Master.FindControl("NavigationMenu");
           mainMenu.Visible = false;
			//Ddlselect.Items[3].Enabled = false;
		}
      
	else
	  {
		 Menu mainMenu = (Menu)Page.Master.FindControl("NavigationMenu");
           mainMenu.Visible = true;
	  }
		
		
		
        //if (!IsPostBack)
        //{
        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
        //    Transactionbilltaxable dsCustomers = GetData();
        //    ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);
        //}
    }
    private Transactionbilltaxable GetData()
    {
        string listvalue = "";
        foreach (ListItem item in SKT.Items)
        {
            if (item.Selected)
            {
                listvalue += item.Value + ",";
            }
        }
        string Productvalue = "";
        foreach (ListItem item1 in PPS.Items)
        {
            if (item1.Selected)
            {
                Productvalue += item1.Value + ",";
            }
        }
        string customertypevalue = "";
        foreach (ListItem item2 in customertype.Items)
        {
            if (item2.Selected)
            {
                customertypevalue += item2.Value + ",";
            }
        }
        
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        SqlCommand cmd = new SqlCommand("Transactionbilltaxableamtautomation_test");
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                cmd.Parameters.AddWithValue("@customercode", Customercode.Text.Trim());               
                cmd.Parameters.AddWithValue("@customertype", customertypevalue);
                cmd.Parameters.AddWithValue("@Billno", BillNo.Text.Trim());
                cmd.Parameters.AddWithValue("@SKT", listvalue);
                cmd.Parameters.AddWithValue("@HQ", HQ.Text.Trim());
                cmd.Parameters.AddWithValue("@pps", Productvalue);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sda.SelectCommand = cmd;
                
                using (Transactionbilltaxable dsCustomers = new Transactionbilltaxable())
                {
                    sda.Fill(dsCustomers, "DataTable1");
                    lblstatus.Text = cmd.Parameters["@message"].Value.ToString();
                    return dsCustomers;
                }                
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Report.rdlc");
        Transactionbilltaxable dsCustomers = GetData();
        ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
        ReportParameter rp = new ReportParameter("Startdate", txtfrmdate.Text.ToString());
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        ReportParameter rp1 = new ReportParameter("Enddate", txttodate.Text.ToString());
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });


        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
    }
}